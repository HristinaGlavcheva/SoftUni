using System;
using System.Collections.Generic;
using System.Linq;

using SOLID___Exercise.Appenders;
using SOLID___Exercise.Loggers;
using SOLID___Exercise.Factories;
using SOLID___Exercise.Core;

namespace SOLID___Exercise
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int appendersCount = int.Parse(Console.ReadLine());

            ICollection<IAppender> appenders = new List<IAppender>();
            ParseAppendersInput(appendersCount, appenders);

            ILogger logger = new Logger(appenders);

            IEngine engine = new Engine(logger);
            engine.Run();
        } 

        private static void ParseAppendersInput(int appendersCount, ICollection<IAppender> appenders)
        {
            AppenderFactory appenderFactory = new AppenderFactory();

            for (int i = 0; i < appendersCount; i++)
            {
                string[] appenderInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray(); ;

                string appenderType = appenderInfo[0];
                string layout = appenderInfo[1];
                string reportLevel = "INFO";

                if (appenderInfo.Length == 3)
                {
                    reportLevel = appenderInfo[2];
                }

                try
                {
                    IAppender appender = appenderFactory.CreateAppender(appenderType, layout, reportLevel);
                    appenders.Add(appender);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
