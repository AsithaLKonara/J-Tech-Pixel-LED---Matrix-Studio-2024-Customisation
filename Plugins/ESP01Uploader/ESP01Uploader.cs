using JTechPixelLED.Plugins;
using System.Diagnostics;

namespace JTechPixelLED.Plugins.ESP12FUploader
{
    public class ESP12FUploader : IUploaderPlugin
    {
        public string GetPluginName() => "ESP12F Uploader";

        public void Upload(string filePath)
        {
            try
            {
                if (string.IsNullOrEmpty(filePath))
                {
                    MessageBox.Show("Please select a valid .bin file.");
                    return;
                }

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "esptool.py",
                    Arguments = $"--port COM4 write_flash 0x00000 {filePath}",
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
                        MessageBox.Show("ESP12F upload successful!");
                    }
                    else
                    {
                        MessageBox.Show($"ESP12F upload failed:\n{error}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        public void DetectIC()
        {
            // Add logic to detect ESP12F via esptool.py
        }
    }
}