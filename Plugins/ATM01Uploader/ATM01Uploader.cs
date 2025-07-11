using System.Windows.Controls;
using JTechPixelLED.Plugins;

namespace JTechPixelLED.Plugins.ATM01Uploader
{
    public class ATM01Uploader : IUploaderPlugin
    {
        public string Name => "ATM01 / RA508 Uploader (Custom/Future)";

        public UserControl GetUploaderPanel()
        {
            return new ATM01UploaderPanel();
        }

        public void Upload(string filePath, string comPort, System.Action<string> logCallback)
        {
            logCallback("ATM01/RA508 upload is not supported in this version. Please contact support for custom plugin development.");
        }
    }
} 