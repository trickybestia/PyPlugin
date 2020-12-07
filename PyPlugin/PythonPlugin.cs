using Exiled.API.Features;
using Microsoft.Scripting.Hosting;
using System;

namespace PyPlugin
{
    /// <summary>
    /// Represents a plugin written in Python.
    /// </summary>
    public class PythonPlugin
    {
        /// <summary>
        /// Gets a value indicating whether or not the plugin is enabled.
        /// </summary>
        public bool IsEnabled { get; private set; }
        /// <summary>
        /// Gets a plugin <see cref="ScriptScope"/>.
        /// </summary>
        public ScriptScope Scope { get; }
        /// <summary>
        /// Gets name of this plugin.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Gets author of this plugin.
        /// </summary>
        public string Author { get; }
        /// <summary>
        /// Gets version of a plugin.
        /// </summary>
        public Version Version { get; }

        /// <summary>
        /// Creates new instance of <see cref="PythonPlugin"/>.
        /// </summary>
        /// <param name="scope">Plugin's <see cref="ScriptScope"/>.</param>
        internal PythonPlugin(ScriptScope scope)
        {
            Scope = scope;

            if (Scope.TryGetVariable("NAME", out string name))
                Name = name;
            else Name = "Unknown";

            if (Scope.TryGetVariable("AUTHOR", out string author))
                Author = author;
            else Author = "Unknown";

            var version = new Version(1, 0, 0, 0);
            if (Scope.TryGetVariable("VERSION", out string versionText))
                Version.TryParse(versionText, out version);
            Version = version;
        }
        /// <summary>
        /// Enables plugin.
        /// </summary>
        public void Enable()
        {
            if (!IsEnabled)
            {
                IsEnabled = true;
                if (Scope.TryGetVariable("onEnabled", out Action enabledEventHandler))
                {
                    try
                    {
                        enabledEventHandler();
                    }
                    catch (Exception exception)
                    {
                        Log.Error($"Plugin \"{Name}\" threw an exception while enabling: {exception}");
                    }
                }
                Log.Info($"{Name} v{Version.Major}.{Version.Minor}.{Version.Build}, made by {Author}, has been enabled!");
            }
        }
        /// <summary>
        /// Disables plugin.
        /// </summary>
        public void Disable()
        {
            if (IsEnabled)
            {
                IsEnabled = false;
                if (Scope.TryGetVariable("onDisabled", out Action disabledEventHandler))
                {
                    try
                    {
                        disabledEventHandler();
                    }
                    catch (Exception exception)
                    {
                        Log.Error($"Plugin \"{Name}\" threw an exception while disabling: {exception}");
                    }
                }
                Log.Info($"{Name} v{Version.Major}.{Version.Minor}.{Version.Build}, made by {Author}, has been disabled!");
            }
        }
    }
}
