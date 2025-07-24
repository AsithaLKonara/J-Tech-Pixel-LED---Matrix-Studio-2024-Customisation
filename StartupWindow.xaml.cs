using System.Windows;

namespace JTechPixelLED
{
    public partial class StartupWindow : Window
    {
        public StartupWindow()
        {
            InitializeComponent();
        }

        private void ModeSelected(object sender, RoutedEventArgs e)
        {
            string selectedMode = (sender as Button)?.Content.ToString();
            switch (selectedMode)
            {
                case "Normal LED Programming":
                    MainWindow.ShowNormalMode();
                    break;
                case "Buduras Mala":
                    MainWindow.ShowBudurasMalaMode();
                    break;
                // Add cases for other modes
            }
            this.Close();
        }
    }

    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            if (!LicenseValidator.ValidateLicense())
            {
                MessageBox.Show("License validation failed. Exiting...");
                Current.Shutdown();
                return;
            }

            var startupWindow = new StartupWindow();
            startupWindow.Show();
        }
    }
}