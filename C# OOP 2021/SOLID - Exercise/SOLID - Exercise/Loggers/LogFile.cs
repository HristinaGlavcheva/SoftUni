using System;
using System.IO;
using System.Linq;

namespace SOLID___Exercise.Loggers
{
    public class LogFile : ILogFile
    {
        private const string LogFilePath = "../../../logfile.txt";
        
        public void Write(string text)
        {
            File.AppendAllText(LogFilePath, text + Environment.NewLine);
        }

        public int Size
            => File.ReadAllText(LogFilePath).Where(char.IsLetter).Sum(x => x);
    }
}
