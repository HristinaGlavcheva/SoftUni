using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class Tuple<Titem1, Titem2>
    {
        private Titem1 item1;
        private Titem2 item2;

        public Tuple(Titem1 item1, Titem2 item2)
        {
            this.item1 = item1;
            this.item2 = item2;
        }

        public override string ToString()
        {
            return $"{this.item1} -> {this.item2}";
        }
    }
}
