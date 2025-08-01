using System.Windows;

namespace JTechPixelLED
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }
        protected override void OnStartup(StartupEventArgs e)
{
    base.OnStartup(e);
    
    // Load license from file
    LicenseManager.LoadLicense();
    
    // 1. License enforcement
    if (!LicenseManager.IsActivated)
    {
        var licenseDialog = new Licensing.LicenseDialog();
        bool? licenseResult = licenseDialog.ShowDialog();
        if (licenseResult != true)
        {
            // User did not activate, exit
            Shutdown();
            return;
        }
    }

    // 2. Mode selection dialog
    var modeDialog = new ModeSelectionDialog();
    if (modeDialog.ShowDialog() != true)
    {
        Shutdown();
        return;
    }

    // 3. Launch main window with selected mode
    var mainWindow = new MainWindow();
    mainWindow.SelectedMode = modeDialog.SelectedMode;
    mainWindow.Show();
}
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // 1. License enforcement
            var licenseDialog = new Licensing.LicenseDialog();
            bool? licenseResult = licenseDialog.ShowDialog();
            if (licenseResult != true)
            {
                // User did not activate, exit
                Shutdown();
                return;
            }

            // 2. Mode selection dialog
            var modeDialog = new ModeSelectionDialog();
            bool? modeResult = modeDialog.ShowDialog();
            if (modeResult != true || modeDialog.SelectedMode == null)
            {
                Shutdown();
                return;
            }

            // 3. Launch main window with selected mode
            var mainWindow = new MainWindow();
            mainWindow.SelectedMode = modeDialog.SelectedMode;
            mainWindow.Show();
        }
    }
}
