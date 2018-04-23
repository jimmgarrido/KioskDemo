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
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),"Build_Scripts", "test.bat");
            var process = new ProcessStartInfo(path);
            Process.Start(process);
        }
    }
}