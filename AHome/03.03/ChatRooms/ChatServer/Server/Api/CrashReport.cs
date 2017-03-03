using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Server.Api
{
    public static class CrashReport
    {
        private const string FILE_PATH = "CrashFile";
        private static object locker;

        static CrashReport()
        {
            locker = new object();
            File.AppendAllText(FILE_PATH, DateTime.Now.ToString() + Environment.NewLine);
        }

        public static void CrashReportToFile(params string[] message)
        {
            lock (locker)
            {
                File.AppendAllText(FILE_PATH, String.Format("{0} {1}", message[0], message[1]) + Environment.NewLine);
            }
        }
    }
}