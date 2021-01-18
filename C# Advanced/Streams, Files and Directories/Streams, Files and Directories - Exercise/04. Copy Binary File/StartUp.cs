using System;
using System.IO;

namespace _04._Copy_Binary_File
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string picturePath = "copyMe.png";
            string pictureCopyPath = "copyMe-Copy.png";

            using (FileStream streamReader = new FileStream(picturePath, FileMode.Open))
            {
                using (FileStream streamWriter = new FileStream(pictureCopyPath, FileMode.Create))
                {
                    while (true)
                    {
                        byte[] buffer = new byte[4096];

                        int size = streamReader.Read(buffer, 0, buffer.Length);

                        if(size == 0)
                        {
                            break;
                        }

                        streamWriter.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
