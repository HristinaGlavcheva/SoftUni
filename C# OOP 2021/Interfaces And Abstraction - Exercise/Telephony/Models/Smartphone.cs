using System;
using System.Linq;

using Telephony.Common;
using Telephony.Contracts;

namespace Telephony.Models
{
    public class Smartphone : ICaller, IBrowser
    {
        
        public string Call(string number)
        {
            if(string.IsNullOrWhiteSpace(number) || !number.All(c => char.IsDigit(c)))
            {
                throw new ArgumentException(ExceptionMessages.InvalidNumber);
            }
            
            if(number.Length != Constants.SmartphoneNumberLength)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberLength, Constants.SmartphoneNumberLength));
            }
            
            return $"Calling... {number}";
        }

        public string Browse(string url)
        {
            if(string.IsNullOrWhiteSpace(url) || url.Any(c => char.IsDigit(c)))
            {
                throw new ArgumentException(ExceptionMessages.InvalidUrl);
            }

            return $"Browsing: {url}";
        }
    }
}

