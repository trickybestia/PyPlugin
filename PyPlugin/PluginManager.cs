using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.IO;

namespace PyPlugin
{
    public static class PluginManager
    {
        /// <summary>
        /// Scripts host.
        /// </summary>
        public static ScriptEngine Engine { get; }
        /// <summary>
        /// Loaded plugins.
        /// </summary>
        public static List<PythonPlugin> Plugins { get; }

        static PluginManager()
        {
            Engine = IronPython.Hosting.Python.CreateEngine();
            Plugins = new List<PythonPlugin>();

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                Engine.Runtime.LoadAssembly(assembly);
        }
        /// <summary>
        /// Loads all plugins from directory.
        /// </summary>
        /// <param name="root">Path to the directory.</param>
        public static void LoadPlugins(string root)
        {
            foreach (var pluginRoot in Directory.GetDirectories(root))
                Plugins.Add(PythonPluginLoader.Load(pluginRoot));
        }
        /// <summary>
        /// Disables all loaded plugins.
        /// </summary>
        public static void DisableAll()
        {
            foreach (var plugin in Plugins)
                plugin.Disable();
        }
        /// <summary>
        /// Enables all loaded plugins.
        /// </summary>
        public static void EnableAll()
        {
            foreach (var plugin in Plugins)
                plugin.Enable();
        }
    }
}
