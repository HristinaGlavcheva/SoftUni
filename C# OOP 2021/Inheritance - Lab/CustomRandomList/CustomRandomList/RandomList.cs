using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random random = new Random();

        public string RandomString()
        {
            var randomIndex = this.random.Next(0, this.Count);
            var randomElement = this[randomIndex];
            this.RemoveAt(randomIndex);
            return randomElement;
        }
    }
}
