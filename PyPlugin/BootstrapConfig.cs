using Exiled.API.Interfaces;
using System.ComponentModel;

namespace PyPlugin
{
    public class BootstrapConfig : IConfig
    {
        [Description("Should plugin be enabled.")]
        public bool IsEnabled { get; set; } = false;
        [Description("Path to the scripts folder.")]
        public string PluginsPath { get; set; }
    }
}
