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
            var directory = assembly.Substring(0, index);

            System.Diagnostics.Debug.WriteLine(directory);
            Directory.SetCurrentDirectory(directory);

            string processPath;
            ProcessStartInfo process;

            if(args.Length > 2)
            {
                switch(args[2])
                {
                    case "/setup":
                        processPath = "setup.bat";
                        process = new ProcessStartInfo(processPath);
                        process.WindowStyle = ProcessWindowStyle.Minimized;
                        Process.Start(process);
                        break;
                    case "/clean":
                        processPath = "cleanup.bat";
                        process = new ProcessStartInfo(processPath);
                        process.WindowStyle = ProcessWindowStyle.Minimized;
                        Process.Start(process);
                        break;
                    case "/archive":
                        processPath = "cleanup.bat";
                        process = new ProcessStartInfo(processPath)
                        {
                            WindowStyle = ProcessWindowStyle.Hidden,
                            Arguments = "archive"
                        };
                        Process.Start(process);
                        break;
                    case "/reset":
                        processPath = "cleanup.bat";
                        process = new ProcessStartInfo(processPath)
                        {
                            WindowStyle = ProcessWindowStyle.Hidden,
                            Arguments = "reset"
                        };
                        Process.Start(process);
                        break;
                }
            }   
        }
    }
}