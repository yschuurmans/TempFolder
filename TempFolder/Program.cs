using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace TempFolder
{
    class Program
    {
        static void Main(string[] args)
        {
            string dateName = DateTime.Now.ToString("yyyyMMdd");//Path.Combine("%TEMP\\", DateTime.Now.ToLongDateString());
            
            if (!Directory.Exists(Path.Combine(Path.GetTempPath(), dateName)))
            {
                Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), dateName));
            }
            Process.Start(Path.Combine(Path.GetTempPath(), dateName));

            Environment.Exit(0);
        }
    }
}
