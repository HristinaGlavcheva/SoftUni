using System;

namespace P03_StudentSystem.IO
{
    public class ConsoleIoEngine : IIoEngine
    {
        public string Read()
        {
            return Console.ReadLine();
        }

        public void Write(string str)
        {
            Console.WriteLine(str);
        }
    }
}
