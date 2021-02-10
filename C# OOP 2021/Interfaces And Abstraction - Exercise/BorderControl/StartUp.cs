using BorderControl.Contracts;
using BorderControl.Core;
using BorderControl.IO;
using System;

namespace BorderControl
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Engine engine = new Engine(new ConsoleReader(), new ConsoleWriter());
            engine.Run();
        }
    }
}
