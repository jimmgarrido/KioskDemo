using System;
using System.Diagnostics;

namespace ProcessWrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var process = new ProcessStartInfo("test.bat")
            {
                WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };

            Process.Start(process);
        }
    }
}
