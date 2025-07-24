using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using JTechPixelLED.Plugins;

namespace JTechPixelLED
{
public static class PluginManager
{
    public static List<IUploaderPlugin> LoadPlugins()
    {
        List<IUploaderPlugin> plugins = new List<IUploaderPlugin>();
        string pluginPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");

        foreach (string dll in Directory.GetFiles(pluginPath, "*.dll"))
        {
            try
            {
                Assembly assembly = Assembly.LoadFile(dll);
                foreach (Type type in assembly.GetTypes())
                {
                    if (typeof(IUploaderPlugin).IsAssignableFrom(type) && !type.IsInterface)
                    {
                        IUploaderPlugin plugin = (IUploaderPlugin)Activator.CreateInstance(type);
                        plugins.Add(plugin);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to load plugin {dll}: {ex.Message}");
            }
        }
        return plugins;
    }
}
}