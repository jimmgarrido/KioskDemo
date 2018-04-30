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

            string processPath;
            ProcessStartInfo process;

            if(args.Length > 2)
            {
                switch(args[2])
                {
                    case "/setup":
                        processPath = Path.Combine("scripts", "setup.bat");
                        process = new ProcessStartInfo(processPath);
                        Process.Start(process);
                        break;
                    case "/clean":
                        processPath = Path.Combine("scripts", "cleanup.bat");
                        process = new ProcessStartInfo(processPath);
                        Process.Start(process);
                        break;
                    case "/archive":
                        processPath = Path.Combine("scripts", "cleanup.bat");
                        process = new ProcessStartInfo(processPath)
                        {
                            Arguments = "archive"
                        };
                        Process.Start(process);
                        break;
                }
            }   
        }
    }
}