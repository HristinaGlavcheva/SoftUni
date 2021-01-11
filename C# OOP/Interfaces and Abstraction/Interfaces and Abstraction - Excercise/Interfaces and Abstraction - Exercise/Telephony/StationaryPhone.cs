using System;
using Telephony.Contracts;

namespace Telephony
{
    public class StationaryPhone : ICollable
    {
        public string Call(string number)
        {
            //if(!number.All(ch => ch.IsDigit(ch)))...

            foreach (char digit in number)
            {
                if (!char.IsDigit(digit))
                {
                    throw new ArgumentException(Common.GlobalConstants.InvalidNumberMessage);
                }
            }

            return $"Dialing... {number}";
        }
    }
}
