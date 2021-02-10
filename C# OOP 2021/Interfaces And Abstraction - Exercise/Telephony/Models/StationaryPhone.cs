using System;
using System.Linq;

using Telephony.Common;
using Telephony.Contracts;

namespace Telephony.Models
{
    public class StationaryPhone : ICaller
    {
        public string Call(string number)
        {
            if (string.IsNullOrWhiteSpace(number) || !number.All(c => char.IsDigit(c)))
            {
                throw new ArgumentException(ExceptionMessages.InvalidNumber);
            }

            if (number.Length != Constants.StationaryProneNumberLength)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberLength, Constants.StationaryProneNumberLength));
            }

            return $"Dialing... {number}";
        }
    }
}

