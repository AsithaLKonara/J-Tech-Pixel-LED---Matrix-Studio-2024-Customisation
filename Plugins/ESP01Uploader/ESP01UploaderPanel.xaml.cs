using System.Windows.Controls;
using JTechPixelLED.Utils;
using Microsoft.Win32;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;

namespace JTechPixelLED.Plugins.ESP01Uploader
{
    public partial class ESP01UploaderPanel : UserControl
    {
        public ESP01UploaderPanel()
        {
            InitializeComponent();
            ComPortCombo.ItemsSource = SerialPortHelper.GetAvailablePorts();
            if (ComPortCombo.Items.Count > 0)
                ComPortCombo.SelectedIndex = 0;
        }

        private void Browse_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "All Files|*.*";
            if (dlg.ShowDialog() == true)
            {
                FilePathBox.Text = dlg.FileName;
            }
        }

        private async void Upload_Click(object sender, System.Windows.RoutedEventArgs e)
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
                var psi = new ProcessStartInfo
                {
                    FileName = "esptool.py", // Ensure esptool.py is in PATH or provide full path
                    Arguments = $"--port {comPort} write_flash 0x00000 \"{filePath}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                try
                {
                    var process = Process.Start(psi);
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        LogBox.Text += output + error;
                        StatusText.Text = process.ExitCode == 0 ? "Upload successful." : "Upload failed.";
                        UploadProgress.Visibility = System.Windows.Visibility.Collapsed;
                        SetControlsEnabled(true);
                    });
                }
                catch (System.Exception ex)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        LogBox.Text += $"Error: {ex.Message}\n";
                        StatusText.Text = "Upload failed.";
                        UploadProgress.Visibility = System.Windows.Visibility.Collapsed;
                        SetControlsEnabled(true);
                    });
                }
            });
        }

        private void ClearLog_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            LogBox.Text = string.Empty;
        }

        private void SetControlsEnabled(bool enabled)
        {
            UploadButton.IsEnabled = enabled;
            Browse_Click.IsEnabled = enabled;
            ComPortCombo.IsEnabled = enabled;
            FilePathBox.IsEnabled = enabled;
        }
    }
} 