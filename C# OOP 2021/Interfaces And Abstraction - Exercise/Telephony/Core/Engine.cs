using System;
using System.Collections.Generic;
using System.Linq;

using Telephony.Common;
using Telephony.Contracts;
using Telephony.Models;

namespace Telephony.Core
{
    public class Engine
    {
        private IReader reader;
        private IWriter writer;
        
        private Smartphone smartphone;
        private StationaryPhone stationaryPhone;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            
            this.smartphone = new Smartphone();
            this.stationaryPhone = new StationaryPhone();
        }
        
        public void Run()
        {
            string[] phoneNumbers = ReadInput();
            CallNumbers(phoneNumbers);

            string[] urls = ReadInput();
            BrowseUrls(urls);
        }

        private void BrowseUrls(string[] urls)
        {
            foreach (var url in urls)
            {
                try
                {
                    this.writer.WriteLine(smartphone.Browse(url));
                }
                catch (ArgumentException ae)
                {
                    this.writer.WriteLine(ae.Message);
                }
            }
        }

        private void CallNumbers(string[] phoneNumbers)
        {
            foreach (var number in phoneNumbers)
            {
                try
                {
                    if (number.Length == Constants.SmartphoneNumberLength)
                    {
                        this.writer.WriteLine(this.smartphone.Call(number)); ;
                    }
                    else if (number.Length == Constants.StationaryProneNumberLength)
                    {
                        this.writer.WriteLine(this.stationaryPhone.Call(number)); ;
                    }
                }
                catch (ArgumentException ae)
                {
                    this.writer.WriteLine(ae.Message);
                }
            }
        }

        private string[] ReadInput()
        {
            return this.reader.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();
        }
    }
}

