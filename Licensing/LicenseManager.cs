namespace JTechPixelLED.Licensing
{
    public static class LicenseManager
    {
        public static bool IsActivated { get; private set; }
        public static string LicenseKey { get; private set; }
        public static string Email { get; private set; }

        public static bool ValidateLicense(string key, string email)
        {
            // TODO: Implement real validation (offline or online)
            if (key == "DEMO-1234" && email.Contains("@"))
            {
                IsActivated = true;
                LicenseKey = key;
                Email = email;
                // Save to file for persistence
                return true;
            }
            return false;
        }
    }
}