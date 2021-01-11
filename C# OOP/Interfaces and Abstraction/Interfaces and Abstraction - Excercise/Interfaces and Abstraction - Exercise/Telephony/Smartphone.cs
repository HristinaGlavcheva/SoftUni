using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telephony.Contracts;

namespace Telephony
{
    public class Smartphone : ICollable, IBrowsable
    {
        public string Call(string number)
        {
            foreach (char digit in number)
            {
                if (!char.IsDigit(digit))
                {
                    throw new ArgumentException(Common.GlobalConstants.InvalidNumberMessage);
                }
            }

            return $"Calling... {number}";
        }

        public string Browse(string url)
        {
            //if(url.Any(ch => char.IsDigit(ch)))...(без foreach)
            
            foreach (char symbol in url)
            {
                if (char.IsDigit(symbol))
                {
                    throw new ArgumentException(Common.GlobalConstants.InvalidUrlMessage);
                }
            }

            return $"Browsing: {url}!";
        }
    }
}
