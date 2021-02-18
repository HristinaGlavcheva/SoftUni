using System;

using _01._Vehicles.Core;

namespace _01._Vehicles
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                Engine engine = new Engine();
                engine.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
