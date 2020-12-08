using Exiled.API.Features;
using Exiled.API.Interfaces;
using System.ComponentModel;
using System.IO;

namespace PyPlugin
{
    public class BootstrapConfig : IConfig
    {
        [Description("Should plugin be enabled.")]
        public bool IsEnabled { get; set; } = false;
        [Description("Path to the scripts folder.")]
        public string PluginsPath { get; set; }

        public BootstrapConfig()
        {
            PluginsPath = Path.Combine(Paths.Plugins, "Python");
            Directory.CreateDirectory(PluginsPath);
        }
    }
}
