// -----------------------------------------------------------------------
// <copyright file="PluginConfig.cs" company="TrickyBestia">
// Copyright (c) TrickyBestia. All rights reserved.
// Licensed under the CC BY-NC-SA 4.0 license.
// </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel;
using System.IO;

using Exiled.API.Features;
using Exiled.API.Interfaces;

namespace PyPlugin
{
    /// <summary>
    /// A config for the <see cref="Plugin"/> plugin.
    /// </summary>
    public class PluginConfig : IConfig
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PluginConfig"/> class.
        /// </summary>
        public PluginConfig()
        {
            this.PluginsPath = Path.Combine(Paths.Plugins, "Python");
        }

        /// <inheritdoc/>
        [Description("Should plugin be enabled.")]
        public bool IsEnabled { get; set; } = false;

        /// <summary>
        /// Gets or sets the Python plugins directory.
        /// </summary>
        [Description("Path to the scripts folder.")]
        public string PluginsPath { get; set; }
    }
}