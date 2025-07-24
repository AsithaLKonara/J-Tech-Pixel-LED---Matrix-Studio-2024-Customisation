using System;
using System.Windows.Controls;
using JTechPixelLED.Plugins;

namespace JTechPixelLED.Plugins.ATM01Uploader
{
    public class ATM01Uploader : UploaderPluginBase
    {
        public override string[] SupportedFormats => new string[] { ".bin", ".hex" };
        public override string Name => "ATM01/RA508 Uploader";
        public override string Description => "Supports ATM01/RA508 via custom protocol";

        public UserControl GetUploaderPanel()
        {
            return new ATM01UploaderPanel();
        }

        public override async Task<string> Upload(string filePath, string comPort, string additionalParams = null)
        {
            // Custom implementation for ATM01/RA508
            string arguments = $"upload -p {comPort} -f \"{filePath}\"";
            
            // Example of custom validation
            if (!comPort.StartsWith("COM") && !comPort.StartsWith("/dev/tty"))
            {
                Log("Error: Invalid COM port format for ATM01/RA508");
                return "Failure";
            }

            return await RunCliTool("atm01uploader", arguments);
        }
    }
}