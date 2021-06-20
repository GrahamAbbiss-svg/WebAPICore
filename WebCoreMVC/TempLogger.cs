using System;
using System.IO;

namespace Civica.Core.EPortal.Web
{
    public class TempLogger
    {
        private readonly string _logFile;
        public TempLogger(string logNamePath)
        {
            _logFile = logNamePath;
        }
        public void LogToFile(string methodName, string messageType, string logLine)
        {
            using (StreamWriter w = File.AppendText(_logFile))
            {
                w.WriteLine(DateTime.Now + " - " + methodName + " - " + messageType + " - " + logLine);
            }
        }
    }
}
