using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace PyPlugin
{
    /// <summary>
    /// Gives functionality to load <see cref="PythonPlugin"/>s.
    /// </summary>
    public static class PythonPluginLoader
    {
        /// <summary>
        /// Loads <see cref="PythonPlugin"/> from given directory.
        /// </summary>
        /// <param name="root">Directory of <see cref="PythonPlugin"/>.</param>
        /// <returns>Loaded <see cref="PythonPlugin"/>.</returns>
        public static PythonPlugin Load(string root)
        {
            var scriptScope = PluginManager.Engine.CreateScope();

            LoadEmbeddedScripts(scriptScope);

            var files = Directory.EnumerateFiles(root, "*.py", SearchOption.AllDirectories).ToList();
            var sources = files.Select(file => GetScriptDataFromFile(file));
            var prioritySortedSources = sources.OrderByDescending(data => data.priority);
            foreach (var (priority, source) in prioritySortedSources)
                source.Execute(scriptScope);

            return new PythonPlugin(scriptScope);
        }
        /// <summary>
        /// Loads embedded scripts into given <see cref="ScriptScope"/>.
        /// </summary>
        /// <param name="scriptScope">Given <see cref="ScriptScope"/>.</param>
        private static void LoadEmbeddedScripts(ScriptScope scriptScope)
        {
            var resources = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            var embeddedScripts = resources.Where(resource => Regex.IsMatch(resource, @".*EmbeddedScripts\..*\.py"));
            var sources = embeddedScripts.Select(script =>
            {
                using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(script);
                return GetScriptDataFromStream(stream);
            });
            var prioritySortedSources = sources.OrderByDescending(data => data.priority);
            foreach (var (priority, source) in prioritySortedSources)
                source.Execute(scriptScope);
        }
        private static (int priority, ScriptSource source) GetScriptDataFromFile(string file)
        {
            using var stream = new FileStream(file, FileMode.Open);
            return GetScriptDataFromStream(stream);
        }
        private static (int priority, ScriptSource source) GetScriptDataFromStream(Stream stream)
        {
            string code = null;
            using (StreamReader reader = new StreamReader(stream))
                code = reader.ReadToEnd();

            var firstLine = code.Substring(0, code.IndexOf('\n') + 1);
            var match = Regex.Match(firstLine.Replace(" ", string.Empty), @"#PRIORITY(\d+)");
            int priority = 0;
            if (match.Success)
                int.TryParse(match.Result("$1"), out priority);

            return (priority, PluginManager.Engine.CreateScriptSourceFromString(code, SourceCodeKind.File));
        }
    }
}
