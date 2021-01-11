using SUS.MvcFramework;
using System;
using System.Threading.Tasks;

namespace MusacaMvcApp___Exam_18_Dec_2018
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            await Host.CreateHostAsync(new Startup(), 80);
        }
    }
}
