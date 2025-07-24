using System.Windows.Controls;
using JTechPixelLED.Plugins;


namespace JTechPixelLED.Plugins.NuvotonUploader
{
    public class NuvotonUploader : IUploaderPlugin
    {
        public string Name => "Nuvoton (Nu-Link) Uploader";

        public UserControl GetUploaderPanel()
        {
            return new NuvotonUploaderPanel();
        }

        public void Upload(string filePath, string comPort, System.Action<string> logCallback)
        {
            // TODO: Call Nu-Link ISP tool and capture output
            logCallback("Uploading to Nuvoton via Nu-Link ISP tool...");
        }
    }
} 