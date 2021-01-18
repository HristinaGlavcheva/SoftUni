using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05._Directory_Traversal
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] allFiles = Directory.GetFiles(".", "*.*");

            Dictionary<string, Dictionary<string, double>> directory = new Dictionary<string, Dictionary<string, double>>();

            DirectoryInfo dirInfo = new DirectoryInfo(".");

            FileInfo[] fileInfo = dirInfo.GetFiles();

            foreach (var file in fileInfo)
            {
                double size = file.Length / 1024d;
                string name = file.Name;
                string extension = file.Extension;

                if (!directory.ContainsKey(extension))
                {
                    directory[extension] = new Dictionary<string, double>();
                }

                directory[extension].Add(name, size);
            }

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/report.txt";

            directory = directory.OrderByDescending(d => d.Value.Count)
                .ThenBy(d => d.Key)
                .ToDictionary(d => d.Key, d => d.Value);

            foreach (var (extension, nameAndSize) in directory)
            {
                File.AppendAllText(desktopPath, extension + Environment.NewLine);

                foreach (var (name, size) in nameAndSize)
                {
                    File.AppendAllText(desktopPath, $"--{name} - {Math.Round(size, 3)}kb" + Environment.NewLine);
                }
            }
        }
    }
}
