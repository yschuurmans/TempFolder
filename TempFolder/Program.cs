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
    static class Program
    {
        private static int DAYS_TO_PRESERVE = 10;
        private static int FOLDERS_TO_PRESERVE = 10;

        static void Main(string[] args)
        {
            DateTime date = DateTime.Now;
            var existed = CreateFolder(date);
            Process.Start("explorer.exe", GetPath(date));

            if (!existed)
                RemoveOldFolders(DateTime.Now);
            Environment.Exit(0);
        }

        public static string GetPath(this DateTime date)
        {
            return Path.Combine(Path.GetTempPath(), "_TEMP_", date.ToString("yyyyMMdd"));
        }

        public static bool CreateFolder(DateTime date)
        {
            if (!Directory.Exists(GetPath(date)))
            {
                Directory.CreateDirectory(GetPath(date));
                return false;
            }
            return true;
        }

        public static void RemoveOldFolders(DateTime currentDate)
        {
            int removedFolders = 0;
            for (int i = DAYS_TO_PRESERVE; i < 365; i++)
            {
                if(RemoveFolder(currentDate.AddDays(-i)))
                    removedFolders++;
                
                if(removedFolders >= FOLDERS_TO_PRESERVE)
                    break;
            }
        }

        public static bool RemoveFolder(DateTime date)
        {
            if (!Directory.Exists(GetPath(date)))
                return false;

            Directory.Delete(GetPath(date), true);
            RemoveOldFolders(DateTime.Now);
            return true;
        }


    }
}
