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
            this.Title = "J Tech Pixel LED";
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