using System;
using System.Linq;

using SOLID___Exercise.Errors;
using SOLID___Exercise.Factories;
using SOLID___Exercise.Loggers;

namespace SOLID___Exercise.Core
{
    public class Engine : IEngine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;

        public Engine(ILogger logger)
        {
            this.logger = logger;
            this.errorFactory = new ErrorFactory();
        }
        
        public void Run()
        {
            string command = Console.ReadLine();
            
            while (command != "END")
            {
                string[] cmdArgs = command
                    .Split("|", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string reportLevel = cmdArgs[0];
                string datetime = cmdArgs[1];
                string message = cmdArgs[2];

                try
                {
                    IError error = this.errorFactory.CreateError(datetime, reportLevel, message);
                    this.logger.Log(error);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
               
                command = Console.ReadLine();
            }

            Console.WriteLine(this.logger);
        }
    }
}
