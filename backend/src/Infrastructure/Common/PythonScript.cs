using System.Reflection;

namespace GameApp.Infrastructure.Common
{
    internal static class PythonScript
    {
        public static string GetScriptPath(string fileName)
        {
            // Get the directory path of the executing assembly (C# project)
            string assemblyPath = Assembly.GetExecutingAssembly().Location;
            string assemblyDirectory = Path.GetDirectoryName(assemblyPath);

            // Construct the full path to the Python script file
            string scriptPath = Path.Combine(assemblyDirectory, "PythonScripts", fileName);

            return scriptPath;
        }
    }
}
