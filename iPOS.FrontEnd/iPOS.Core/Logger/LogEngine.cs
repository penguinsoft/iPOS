using System;
using System.IO;
using iPOS.Core.Helper;

namespace iPOS.Core.Logger
{
    public class LogEngine : ILogEngine
    {
        private string FileName = string.Format(@"{0}\iPOSLog_{1}.txt", ConfigEngine.LogPath, DateTime.Now.ToString("yyyy_MM_dd"));

        public LogEngine()
        {
            FileEngine.CreateDirectory(ConfigEngine.LogPath);
            FileEngine.CreateFile(FileName);
        }

        private void WriteMessage(string message, string type)
        {
            using (StreamWriter writer = File.AppendText(FileName))
            {
                writer.WriteLine(string.Format("\nLog Entry: {0} {1} {2} from IP {3} - {4}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), type.ToUpper(), "localhost", message));
            }
        }

        public void Info(string message)
        {
            WriteMessage(message, "info");
        }

        public void Warn(string message)
        {
            WriteMessage(message, "warn");
        }

        public void Debug(string message)
        {
            WriteMessage(message, "debug");
        }

        public void Error(string message)
        {
            WriteMessage(message, "error");
        }

        public void Error(Exception ex)
        {
            WriteMessage(ex.Message, "error");
        }

        public void Error(Exception ex, string message)
        {
            WriteMessage(message + " (" + ex.Message + ")", "error");
        }

        public void Fatal(string message)
        {
            WriteMessage(message, "fatal");
        }

        public void Fatal(Exception ex)
        {
            WriteMessage(ex.Message, "fatal");
        }

        public void Fatal(Exception ex, string message)
        {
            WriteMessage(message + " (" + ex.Message + ")", "fatal");
        }
    }
}
