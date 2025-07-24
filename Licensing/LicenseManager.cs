using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace JTechPixelLED.Licensing
{
    public static class LicenseManager
    {
        private const string LicenseFile = "license.dat";
        private static readonly string[] ValidChips = { "ATM01", "RA508" };

        public static bool IsActivated { get; private set; }
        public static string LicenseKey { get; private set; }
        public static string Email { get; private set; }
        public static string[] AllowedModes { get; private set; } = new string[0];
        public static string[] AllowedFeatures { get; private set; } = new string[0];

        public static bool IsModeAllowed(string mode) => Array.Exists(AllowedModes, m => m.Equals(mode, StringComparison.OrdinalIgnoreCase));
        public static bool IsFeatureAllowed(string feature) => Array.Exists(AllowedFeatures, f => f.Equals(feature, StringComparison.OrdinalIgnoreCase));

        public static bool ValidateLicense(string key, string email, string[] allowedModes = null, string[] allowedFeatures = null)
        {
            try
            {
                if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(email))
                {
                    return false;
                }

                // Basic validation
                if (!key.StartsWith("LMS-") || key.Length != 16 || !email.Contains("@"))
                {
                    return false;
                }

                // Check if license is already activated
                if (File.Exists(LicenseFile))
                {
                    string[] data = File.ReadAllLines(LicenseFile);
                    if (data.Length >= 4)
                    {
                        if (data[0] == key && data[1] == email)
                        {
                            IsActivated = true;
                            LicenseKey = key;
                            Email = email;
                            AllowedModes = data[2].Split(',');
                            AllowedFeatures = data[3].Split(',');
                            return true;
                        }
                    }
                }

                // Simulate online validation
                if (key == "LMS-DEMO-ATM01" && email.Contains("@"))
                {
                    SaveLicense(key, email, allowedModes ?? new[] { "Normal", "ATM01" }, allowedFeatures ?? new[] { "Export", "Upload" });
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"License validation error: {ex.Message}");
                return false;
            }
        }

        private static void SaveLicense(string key, string email, string[] allowedModes, string[] allowedFeatures)
        {
            try
            {
                string licenseData = $"{key}\n{email}\n{string.Join(",", allowedModes)}\n{string.Join(",", allowedFeatures)}";
                File.WriteAllText(LicenseFile, licenseData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"License save error: {ex.Message}");
            }
        }

        public static void LoadLicense()
        {
            try
            {
                if (File.Exists(LicenseFile))
                {
                    string[] data = File.ReadAllLines(LicenseFile);
                    if (data.Length >= 4)
                    {
                        IsActivated = true;
                        LicenseKey = data[0];
                        Email = data[1];
                        AllowedModes = data[2].Split(',');
                        AllowedFeatures = data[3].Split(',');
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"License load error: {ex.Message}");
            }
        }
    }
}