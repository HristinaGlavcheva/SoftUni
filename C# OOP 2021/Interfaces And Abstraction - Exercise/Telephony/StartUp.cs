using System;

using Telephony.Core;
using Telephony.IO;

namespace Telephony
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                Engine engine = new Engine(new ConsoleReader(), new ConsoleWriter());
                engine.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

