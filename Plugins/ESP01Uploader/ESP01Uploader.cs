using System.Windows.Controls;

namespace JTechPixelLED.Plugins.ESP01Uploader
{
    public class ESP01Uploader : IUploaderPlugin
    {
        public string Name => "ESP01 Uploader";

        public UserControl GetUploaderPanel()
        {
            return new ESP01UploaderPanel();
        }

        public void Upload(string filePath, string comPort, System.Action<string> logCallback)
        {
            // TODO: Call esptool.py and capture output
            logCallback("Uploading to ESP01 via esptool.py...");
        }
    }
} 