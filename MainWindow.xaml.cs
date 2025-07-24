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
        public string SelectedMode { get; set; } // Add this property

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
                var plugins = PluginManager.LoadPlugins();
    foreach (var plugin in plugins)
    {
        var pluginUI = new ATM01UploaderPanel(); // Replace with dynamic UI loading
        pluginContainer.Children.Add(pluginUI);
    }
            string pluginsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");
            if (!Directory.Exists(pluginsPath))
                Directory.CreateDirectory(pluginsPath);

            var pluginFiles = Directory.GetFiles(pluginsPath, "*.dll", SearchOption.TopDirectoryOnly);

            foreach (var file in pluginFiles)
            {
                try
                {
                    var asm = Assembly.LoadFrom(file);
                    var pluginTypes = asm.GetTypes()
                        .Where(t => typeof(IUploaderPlugin).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

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
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load plugin from {file}.\n\n{ex.Message}",
                        "Plugin Load Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            StatusText.Text = $"Loaded {PluginTabs.Items.Count - 1} plugins."; // minus 1 for Pixel Drawing tab
        }

    }
}
