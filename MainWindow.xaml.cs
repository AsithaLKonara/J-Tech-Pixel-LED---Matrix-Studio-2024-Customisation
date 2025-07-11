using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using JTechPixelLED.Plugins;

namespace JTechPixelLED
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Title = "J Tech Pixel LED - LED Matrix Studio";
            StatusText.Text = "Ready - All plugins loaded successfully";
            VersionText.Text = "v1.0.0";
            LoadPlugins();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            var about = new AboutDialog();
            about.ShowDialog();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void License_Click(object sender, RoutedEventArgs e)
        {
            var license = new Licensing.LicenseDialog();
            license.ShowDialog();
        }

        private void UserManual_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Open the user manual file if it exists
                string manualPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "USER_MANUAL.md");
                if (System.IO.File.Exists(manualPath))
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = manualPath,
                        UseShellExecute = true
                    });
                }
                else
                {
                    MessageBox.Show("User manual not found. Please check the documentation folder.", 
                        "User Manual", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening user manual: {ex.Message}", 
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadPlugins()
        {
            string pluginsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");
            if (!Directory.Exists(pluginsPath))
                Directory.CreateDirectory(pluginsPath);

            // For now, manually instantiate plugins (dynamic loading can be added later)
            var pluginTypes = new Type[]
            {
                typeof(JTechPixelLED.Plugins.ArduinoUploader.ArduinoUploader),
                typeof(JTechPixelLED.Plugins.ESP01Uploader.ESP01Uploader),
                typeof(JTechPixelLED.Plugins.NuvotonUploader.NuvotonUploader),
                typeof(JTechPixelLED.Plugins.ATM01Uploader.ATM01Uploader), // Register ATM01/RA508 placeholder
            };

            foreach (var type in pluginTypes)
            {
                if (Activator.CreateInstance(type) is IUploaderPlugin plugin)
                {
                    var tab = new TabItem
                    {
                        Header = plugin.Name,
                        Content = plugin.GetUploaderPanel()
                    };
                    PluginTabs.Items.Add(tab);
                }
            }
        }
    }
}