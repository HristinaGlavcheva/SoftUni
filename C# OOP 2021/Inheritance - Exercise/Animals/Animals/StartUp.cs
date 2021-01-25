using Animals.IO;
using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Engine engine = new Engine(new ConsoleIoEngine());
            engine.Run();
        }
    }
}
