using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using JTechPixelLED.Plugins;

namespace JTechPixelLED.Plugins.STM32Uploader
{
    public partial class STM32UploaderPanel : UserControl, IUploaderPlugin
    {
        public STM32UploaderPanel()
        {
            InitializeComponent();
            PortSelector.ItemsSource = SerialPort.GetPortNames();
        }

        public string GetPluginName()
        {
            return "STM32F030F4P6 Uploader";
        }

        public void Upload(string filePath)
        {
            try
            {
                if (string.IsNullOrEmpty(filePath))
                {
                    MessageBox.Show("Please select a valid .hex or .bin file.");
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
                    FileName = "stm32flash",
                    Arguments = $"--port {selectedPort} {filePath}",
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
                        MessageBox.Show("STM32 upload successful!");
                    }
                    else
                    {
                        File.WriteAllText("Logs/error_log.txt", $"Error: {error} at {DateTime.Now}");
                        MessageBox.Show($"STM32 upload failed:\n{error}");
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
                    FileName = "stm32flash",
                    Arguments = $"--port {selectedPort} --version",
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
                        MessageBox.Show($"Detected STM32:\n{output}");
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
                Filter = "Hex Files (*.hex)|*.hex|Bin Files (*.bin)|*.bin|All Files (*.*)|*.*",
                Title = "Select .hex or .bin File to Upload"
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
            Process.Start("https://example.com/stm32-user-manual");
        }

        private void License_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("License information...");
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("STM32 Uploader v1.0\nBy J Tech Pixel LED");
        }
    }
}
