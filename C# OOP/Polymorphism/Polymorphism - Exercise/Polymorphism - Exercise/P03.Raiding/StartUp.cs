using P03.Raiding.Core;
using System;

namespace P03.Raiding
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Engine engine = new Engine();

            engine.Run();
        }
    }
}
