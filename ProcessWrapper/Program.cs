using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace ProcessWrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var assembly = Assembly.GetExecutingAssembly().Location;
            var index = assembly.LastIndexOf("\\");
            var packageRoot = assembly.Substring(0, index);

            Directory.SetCurrentDirectory(packageRoot);

            var path = Path.Combine("scripts", "setup.bat");
            var process = new ProcessStartInfo(path);
            Process.Start(process);
        }
    }
}