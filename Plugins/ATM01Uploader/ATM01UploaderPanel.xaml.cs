using System.Windows.Controls;
using JTechPixelLED.Utils;
using Microsoft.Win32;
using System;

namespace JTechPixelLED.Plugins.ATM01Uploader
{
    public partial class ATM01UploaderPanel : UserControl
    {
        public ATM01UploaderPanel()
        {
            InitializeComponent();
            ComPortCombo.ItemsSource = SerialPortHelper.GetAvailablePorts();
            if (ComPortCombo.Items.Count > 0)
                ComPortCombo.SelectedIndex = 0;
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "HEX Files (*.hex)|*.hex|BIN Files (*.bin)|*.bin";
            if (dlg.ShowDialog() == true)
            {
                FilePathBox.Text = dlg.FileName;
            }
        }

        private async void Upload_Click(object sender, RoutedEventArgs e)
        {
            if (ComPortCombo.SelectedItem == null || string.IsNullOrWhiteSpace(FilePathBox.Text))
            {
                StatusText.Text = "Please select a COM port and file.";
                return;
            }

            string comPort = ComPortCombo.SelectedItem.ToString();
            string filePath = FilePathBox.Text;

            SetControlsEnabled(false);
            UploadProgress.Visibility = System.Windows.Visibility.Visible;
            UploadProgress.IsIndeterminate = true;
            StatusText.Text = "Uploading...";

            await Task.Run(() =>
            {
                var plugin = new ATM01Uploader();
                string result = await plugin.Upload(filePath, comPort);
                
                Application.Current.Dispatcher.Invoke(() =>
                {
                    LogBox.Text += _log;
                    StatusText.Text = result == "Success" ? "Upload successful." : "Upload failed.";
                    UploadProgress.Visibility = System.Windows.Visibility.Collapsed;
                    SetControlsEnabled(true);
                });
            });
        }

        private void ClearLog_Click(object sender, RoutedEventArgs e)
        {
            LogBox.Text = string.Empty;
        }

        private void SetControlsEnabled(bool enabled)
        {
            UploadButton.IsEnabled = enabled;
            ComPortCombo.IsEnabled = enabled;
            FilePathBox.IsEnabled = enabled;
        }
    }
}