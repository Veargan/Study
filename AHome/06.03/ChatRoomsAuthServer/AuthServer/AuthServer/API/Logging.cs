using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer
{
    public class Logging
    {
        private const string FILE_PATH = "LogFile";
        private static object locker;

        static Logging()
        {
            locker = new object();
        }

        public static void LogToFile(params string[] message)
        {
            try
            {
                lock (locker)
                {
                    File.AppendAllText(FILE_PATH, DateTime.Now.ToString() + " " + String.Format("{0}", message[0]) + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("METHOD: LogToFile" + ex.StackTrace + ex.Message, ex.InnerException);
            }
        }
    }
}
