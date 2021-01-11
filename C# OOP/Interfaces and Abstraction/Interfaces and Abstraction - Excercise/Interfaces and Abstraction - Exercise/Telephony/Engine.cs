using System;
using System.Collections.Generic;
using System.Text;
using Telephony.Contracts;

namespace Telephony
{
    class Engine
    {
        private StationaryPhone stationaryPhone;
        private Smartphone smartphone;

        public Engine()
        {
            this.stationaryPhone = new StationaryPhone();
            this.smartphone = new Smartphone();
        }
        
        public void Run()
        {
            string[] phoneNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            ICollable phone = null;

            foreach (var number in phoneNumbers)
            {
                try
                {
                    if (number.Length == 7)
                    {
                        phone = this.stationaryPhone;
                    }
                    else if (number.Length == 10)
                    {
                        phone = this.smartphone;
                    }

                    Console.WriteLine(phone.Call(number));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            string[] sites = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var site in sites)
            {
                try
                {
                    Console.WriteLine(this.smartphone.Browse(site));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
