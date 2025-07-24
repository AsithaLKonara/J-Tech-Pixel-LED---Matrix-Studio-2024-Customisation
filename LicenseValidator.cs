using System;
using System.IO;
using System.Windows;

namespace JTechPixelLED
{
    public class LicenseValidator
    {
        private const string LicenseFile = "license.txt";

        public static bool ValidateLicense()
        {
            if (!File.Exists(LicenseFile))
            {
                // Show license input dialog
                var dialog = new LicenseDialog();
                if (dialog.ShowDialog() == true)
                {
                    SaveLicense(dialog.Email, dialog.LicenseKey);
                    return true;
                }
                return false;
            }

            string[] lines = File.ReadAllLines(LicenseFile);
            if (lines.Length < 2 || !lines[1].StartsWith("JTECH-") || lines[1].Length != 25)
            {
                return false;
            }

            return true;
        }

        private static void SaveLicense(string email, string key)
        {
            File.WriteAllText(LicenseFile, $"{email}\n{key}");
        }
    }
}