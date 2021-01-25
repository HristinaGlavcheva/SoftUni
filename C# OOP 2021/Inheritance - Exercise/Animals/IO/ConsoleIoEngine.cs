using System;

namespace Animals.IO
{
    public class ConsoleIoEngine : IIoEngine
    {
        public string ReadLine ()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string str)
        {
            Console.WriteLine(str);
        }
    }
}

