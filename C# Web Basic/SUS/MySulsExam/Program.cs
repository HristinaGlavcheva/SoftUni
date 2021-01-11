using SUS.MvcFramework;
using System;
using System.Threading.Tasks;

namespace MySulsExam
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await Host.CreateHostAsync(new StartUp());
        }
    }
}
