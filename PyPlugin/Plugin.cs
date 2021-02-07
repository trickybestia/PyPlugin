using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using System.IO;
using System.Reflection;

namespace PyPlugin
{
    internal class Plugin : Plugin<PluginConfig>
    {
        /// <summary>
        /// Instance of <see cref="Plugin"/>.
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
        public override Version Version => Assembly.GetName().Version;

        /// <inheritdoc/>
        public Plugin()
        {
            Instance = this;
        }
        /// <inheritdoc/>
        public override void OnEnabled()
        {
            Directory.CreateDirectory(Config.PluginsPath);

            PluginManager.LoadPlugins(Config.PluginsPath);
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
