using MilitaryElite.Contracts;
using MilitaryElite.Core;
using MilitaryElite.Models;
using System;

namespace MilitaryElite
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

