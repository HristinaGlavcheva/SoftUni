using System;
using System.IO;
using System.IO.Compression;

namespace _06._Zip_and_Extract
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string archivePath = "../../../archive.zip";

            string picPath = "copyMe.png";

            using(ZipArchive archive = ZipFile.Open(archivePath, ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile(picPath, Path.GetFileName(picPath));
            }

            ZipFile.ExtractToDirectory(archivePath, "../../");
        }
    }
}
