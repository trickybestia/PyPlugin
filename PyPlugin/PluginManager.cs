// -----------------------------------------------------------------------
// <copyright file="PluginManager.cs" company="TrickyBestia">
// Copyright (c) TrickyBestia. All rights reserved.
// Licensed under the CC BY-NC-SA 4.0 license.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;

using Microsoft.Scripting.Hosting;

namespace PyPlugin
{
    /// <summary>
    /// A class that helps with manipulating Python plugins.
    /// </summary>
    public static class PluginManager
    {
        static PluginManager()
        {
            Engine = IronPython.Hosting.Python.CreateEngine();
            Plugins = new List<PythonPlugin>();

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                Engine.Runtime.LoadAssembly(assembly);
            }
        }

        /// <summary>
        /// Gets a <see cref="ScriptEngine"/> associated with this <see cref="PluginManager"/>.
        /// </summary>
        public static ScriptEngine Engine { get; }

        /// <summary>
        /// Gets a list of loaded Python plugins.
        /// </summary>
        public static List<PythonPlugin> Plugins { get; }

        /// <summary>
        /// Loads all plugins from directory.
        /// </summary>
        /// <param name="root">Path to the directory.</param>
        public static void LoadPlugins(string root)
        {
            foreach (var pluginRoot in Directory.GetDirectories(root))
            {
                Plugins.Add(PythonPluginLoader.Load(pluginRoot));
            }
        }

        /// <summary>
        /// Disables all loaded plugins.
        /// </summary>
        public static void DisableAll()
        {
            foreach (var plugin in Plugins)
            {
                plugin.Disable();
            }
        }

        /// <summary>
        /// Enables all loaded plugins.
        /// </summary>
        public static void EnableAll()
        {
            foreach (var plugin in Plugins)
            {
                plugin.Enable();
            }
        }
    }
}