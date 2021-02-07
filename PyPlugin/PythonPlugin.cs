// -----------------------------------------------------------------------
// <copyright file="PythonPlugin.cs" company="TrickyBestia">
// Copyright (c) TrickyBestia. All rights reserved.
// Licensed under the CC BY-NC-SA 4.0 license.
// </copyright>
// -----------------------------------------------------------------------

using System;

using Exiled.API.Features;
using Microsoft.Scripting.Hosting;

namespace PyPlugin
{
    /// <summary>
    /// A class that represents a plugin written in Python.
    /// </summary>
    public class PythonPlugin
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PythonPlugin"/> class.
        /// </summary>
        /// <param name="scope"><see cref="ScriptScope"/> with plugin.</param>
        internal PythonPlugin(ScriptScope scope)
        {
            this.Scope = scope;

            if (this.Scope.TryGetVariable("NAME", out string name))
            {
                this.Name = name;
            }
            else
            {
                this.Name = "Unknown";
            }

            if (this.Scope.TryGetVariable("AUTHOR", out string author))
            {
                this.Author = author;
            }
            else
            {
                this.Author = "Unknown";
            }

            var version = new Version(1, 0, 0, 0);
            if (this.Scope.TryGetVariable("VERSION", out string versionText))
            {
                Version.TryParse(versionText, out version);
            }

            this.Version = version;
        }

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
        /// Enables plugin.
        /// </summary>
        public void Enable()
        {
            if (!this.IsEnabled)
            {
                this.IsEnabled = true;
                if (this.Scope.TryGetVariable("onEnabled", out Action enabledEventHandler))
                {
                    try
                    {
                        enabledEventHandler();
                    }
                    catch (Exception exception)
                    {
                        Log.Error($"Plugin \"{this.Name}\" threw an exception while enabling: {exception}");
                    }
                }

                Log.Info($"{this.Name} v{this.Version}, made by {this.Author}, has been enabled!");
            }
        }

        /// <summary>
        /// Disables plugin.
        /// </summary>
        public void Disable()
        {
            if (this.IsEnabled)
            {
                this.IsEnabled = false;
                if (this.Scope.TryGetVariable("onDisabled", out Action disabledEventHandler))
                {
                    try
                    {
                        disabledEventHandler();
                    }
                    catch (Exception exception)
                    {
                        Log.Error($"Plugin \"{this.Name}\" threw an exception while disabling: {exception}");
                    }
                }

                Log.Info($"{this.Name} v{this.Version}, made by {this.Author}, has been disabled!");
            }
        }
    }
}