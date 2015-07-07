using iPOS.Core.Helper;
using System;
using System.IO;

namespace iPOS.Core.Logger
{
    public class Logger 
    {
        private static void CreateLogFile()
        {
            string strFileName = new IO().Read("Extensions", "LogPath") + @"\iPOSLog_" + DateTime.Now.ToString("yyyy_MM_dd") + ".txt";
            Files.CreateDirectory(new Configuration().LogPath);
            Files.CreateFile(strFileName);
        }

        private static void WriteMessage(string message, string type)
        {
            using (StreamWriter writer = File.AppendText(new IO().Read("Extensions", "LogPath") + @"\iPOSLog_" + DateTime.Now.ToString("yyyy_MM_dd") + ".txt"))
            {
                writer.WriteLine(string.Format("\nLog Entry: {0} {1} {2} from IP {3} - {4}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), type.ToUpper(), Helper.Helper.GetIPLAN(), message));
            }
        }

        public static void Info(string message)
        {
            CreateLogFile();
            WriteMessage(message, "info");
        }

        public static void Warn(string message)
        {
            CreateLogFile();
            WriteMessage(message, "warn");
        }

        public static void Debug(string message)
        {
            CreateLogFile();
            WriteMessage(message, "debug");
        }

        public static void Error(string message)
        {
            CreateLogFile();
            WriteMessage(message, "error");
        }

        public static void Error(string message, Exception ex)
        {
            CreateLogFile();
            WriteMessage(message + " (" + ex.Message + ")", "error");
        }

        public static void Error(Exception ex)
        {
            CreateLogFile();
            WriteMessage(ex.Message, "error");
        }

        public static void Fatal(string message)
        {
            CreateLogFile();
            WriteMessage(message, "fatal");
        }

        public static void Fatal(Exception ex)
        {
            CreateLogFile();
            WriteMessage(ex.Message, "fatal");
        }
    }
}
