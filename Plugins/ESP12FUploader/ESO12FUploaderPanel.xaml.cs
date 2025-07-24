using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using JTechPixelLED.Plugins;

namespace JTechPixelLED.Plugins.ESP12FUploader
{
    public partial class ESP12FUploaderPanel : UserControl, IUploaderPlugin
    {
        public ESP12FUploaderPanel()
        {
            InitializeComponent();
            PortSelector.ItemsSource = SerialPort.GetPortNames();
        }

        public string GetPluginName()
        {
            return "ESP12F Uploader";
        }

        public void Upload(string filePath)
        {
            try
            {
                if (string.IsNullOrEmpty(filePath))
                {
                    MessageBox.Show("Please select a valid .bin file.");
                    return;
                }

                string selectedPort = PortSelector.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(selectedPort))
                {
                    MessageBox.Show("Please select a COM port.");
                    return;
                }

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "esptool.py",
                    Arguments = $"--port {selectedPort} write_flash 0x00000 {filePath}",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = false
                };

                using (Process process = Process.Start(startInfo))
                {
                    process.WaitForExit();
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    if (process.ExitCode == 0)
                    {
                        File.WriteAllText("Logs/upload_log.txt", $"Uploaded {filePath} at {DateTime.Now}");
                        MessageBox.Show("ESP12F upload successful!");
                    }
                    else
                    {
                        File.WriteAllText("Logs/error_log.txt", $"Error: {error} at {DateTime.Now}");
                        MessageBox.Show($"ESP12F upload failed:\n{error}");
                    }
                }
            }
            catch (Exception ex)
            {
                File.WriteAllText("Logs/error_log.txt", $"Error: {ex.Message} at {DateTime.Now}");
                MessageBox.Show($"Error during upload: {ex.Message}");
            }
        }

        public void DetectIC()
        {
            try
            {
                string selectedPort = PortSelector.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(selectedPort))
                {
                    MessageBox.Show("Please select a COM port.");
                    return;
                }

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "esptool.py",
                    Arguments = $"--port {selectedPort} chip esp12f detect",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = false
                };

                using (Process process = Process.Start(startInfo))
                {
                    process.WaitForExit();
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    if (process.ExitCode == 0)
                    {
                        MessageBox.Show($"Detected ESP12F:\n{output}");
                    }
                    else
                    {
                        MessageBox.Show($"IC detection failed:\n{error}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error detecting IC: {ex.Message}");
            }
        }

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Bin Files (*.bin)|*.bin|All Files (*.*)|*.*",
                Title = "Select .bin File to Upload"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                Upload(openFileDialog.FileName);
            }
        }

        private void DetectICButton_Click(object sender, RoutedEventArgs e)
        {
            DetectIC();
        }

        private void UserManual_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://example.com/esp12f-user-manual");
        }

        private void License_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("License information...");
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("ESP12F Uploader v1.0\nBy J Tech Pixel LED");
        }
    }
}
public partial class ESP12FUploaderPanel : UserControl
{
    private ESP12FUploader _uploader = new ESP12FUploader();

    public ESP12FUploaderPanel()
    {
        InitializeComponent();
        LogTextBox.Text = _uploader.GetLog();
    }

    private void SelectFile_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog dialog = new OpenFileDialog();
        if (dialog.ShowDialog() == true)
        {
            FilePathTextBox.Text = dialog.FileName;
        }
    }

    private async void Upload_Click(object sender, RoutedEventArgs e)
    {
        string filePath = FilePathTextBox.Text;
        string port = "COM3"; // Default port, can be made configurable
        string baudRate = "115200";
        string chipModel = "esp12f";

        string result = await _uploader.UploadAsync(filePath, port, baudRate, chipModel);
        LogTextBox.Text = _uploader.GetLog();
    }
}