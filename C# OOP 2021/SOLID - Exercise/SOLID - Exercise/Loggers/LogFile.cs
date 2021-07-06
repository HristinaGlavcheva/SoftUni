using System;
using System.Globalization;
using System.IO;
using System.Linq;

using SOLID___Exercise.Common;
using SOLID___Exercise.Errors;
using SOLID___Exercise.IO;
using SOLID___Exercise.Layouts;

namespace SOLID___Exercise.Loggers
{
    public class LogFile : ILogFile
    {
        private IOManager IOManager;

        public LogFile(string folderName, string fileName)
        {
            this.IOManager = new IOManager(folderName, fileName);
            this.IOManager.EnsureDirectoryAndFileExist();
        }

        public string Path => this.IOManager.CurrentFilePath;

        public int Size
            => File.ReadAllText(this.Path).Where(char.IsLetter).Sum(ch => ch);

        string ILogFile.Write(ILayout layout, IError error)
        {
            string formattedMessage = string.Format(layout.Format, error.DateTime.ToString(GlobalConstants.DatetimeFormat, CultureInfo.InvariantCulture),
                    error.ReportLevel,
                    error.Message) + Environment.NewLine;
            
            return formattedMessage;
        }
    }
}
