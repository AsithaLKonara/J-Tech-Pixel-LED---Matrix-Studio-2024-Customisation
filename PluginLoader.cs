public static class PluginLoader
{
	public static List<IUploaderPlugin> LoadPlugins(string pluginFolder)
	{
		var plugins = new List<IUploaderPlugin>();

		foreach (var dll in Directory.GetFiles(pluginFolder, "*.dll"))
		{
			var assembly = Assembly.LoadFrom(dll);
			foreach (var type in assembly.GetTypes())
			{
				if (typeof(IUploaderPlugin).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
				{
					if (Activator.CreateInstance(type) is IUploaderPlugin plugin)
						plugins.Add(plugin);
				}
			}
		}

		return plugins;
	}
}
