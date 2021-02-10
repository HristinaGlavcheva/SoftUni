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
            EngineBorderControl engineBorderControl = new EngineBorderControl(new ConsoleReader(), new ConsoleWriter());
            engineBorderControl.Run();

            //EngineFoodShortage engineFoodShortage = new EngineFoodShortage(new ConsoleReader(), new ConsoleWriter());
            //engineFoodShortage.Run();
        }
    }
}
