using System;
using System.IO.Compression;

namespace _06._Zip_and_Extract
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string picFolderPath = ".";

            string targetPath = "../../../archive.zip";

            ZipFile.CreateFromDirectory(picFolderPath, targetPath);

            ZipFile.ExtractToDirectory(targetPath, "../../");
        }
    }
}
