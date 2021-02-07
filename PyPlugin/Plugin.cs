// -----------------------------------------------------------------------
// <copyright file="Plugin.cs" company="TrickyBestia">
// Copyright (c) TrickyBestia. All rights reserved.
// Licensed under the CC BY-NC-SA 4.0 license.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.IO;

using Exiled.API.Enums;
using Exiled.API.Features;

namespace PyPlugin
{
    /// <inheritdoc/>
    internal class Plugin : Plugin<PluginConfig>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Plugin"/> class.
        /// </summary>
        public Plugin()
        {
            Instance = this;
        }

        /// <summary>
        /// Gets an instance of the <see cref="Plugin"/> class.
        /// </summary>
        public static Plugin Instance { get; private set; }

        /// <inheritdoc/>
        public override string Author { get; } = "TrickyBestia";

        /// <inheritdoc/>
        public override string Name { get; } = "PyPlugin";

        /// <inheritdoc/>
        public override string Prefix { get; } = "PyPlugin";

        /// <inheritdoc/>
        public override Version RequiredExiledVersion { get; } = new Version(2, 1, 18);

        /// <inheritdoc/>
        public override PluginPriority Priority { get; } = PluginPriority.Default;

        /// <inheritdoc/>
        public override Version Version => this.Assembly.GetName().Version;

        /// <inheritdoc/>
        public override void OnEnabled()
        {
            Directory.CreateDirectory(this.Config.PluginsPath);

            PluginManager.LoadPlugins(this.Config.PluginsPath);
            PluginManager.EnableAll();

            base.OnEnabled();
        }

        /// <inheritdoc/>
        public override void OnDisabled()
        {
            PluginManager.DisableAll();

            base.OnDisabled();
        }
    }
}