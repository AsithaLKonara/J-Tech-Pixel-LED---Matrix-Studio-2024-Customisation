using System.Windows;
using System.Windows.Controls;

namespace JTechPixelLED.Licensing
{
    public partial class LicenseDialog : UserControl
    {
        public LicenseDialog()
        {
            InitializeComponent();
        }

        private void Activate_Click(object sender, RoutedEventArgs e)
        {
            string key = LicenseKeyBox.Text.Trim();
            string email = EmailBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(email))
            {
                StatusText.Text = "Please enter both license key and email.";
                LicenseSnackbar.MessageQueue?.Enqueue("Please enter both license key and email.");
                return;
            }
            // Simulate validation (replace with real logic)
            if (key.StartsWith("LMS-") && email.Contains("@"))
            {
                StatusText.Text = "License activated!";
                StatusText.Foreground = System.Windows.Media.Brushes.Green;
                LicenseSnackbar.MessageQueue?.Enqueue("License activated!");
            }
            else
            {
                StatusText.Text = "Invalid license key or email.";
                StatusText.Foreground = System.Windows.Media.Brushes.Red;
                LicenseSnackbar.MessageQueue?.Enqueue("Invalid license key or email.");
            }
        }
    }
}