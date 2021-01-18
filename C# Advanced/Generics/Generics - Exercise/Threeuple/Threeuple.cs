namespace Threeuple
{
    public class Threeuple<TItem1, TItem2, TItem3>
    {
        private TItem2 item2;
        private TItem3 item3;
        private TItem1 item1;

        public TItem1 Item1
        {
            get { return this.item1; }

            set { this.item1 = value; }
        }

        public TItem2 Item2
        {
            get { return this.item2; }

            set { this.item2 = value; }
        }

        public TItem3 Item3
        {
            get { return item3; }

            set { this.item3 = value; }
        }

        public Threeuple(TItem1 item1, TItem2 item2, TItem3 item3)
        {
            this.Item1 = item1;
            this.Item2 = item2;
            this.Item3 = item3;
        }

        public override string ToString()
        {
            return $"{this.item1} -> {this.item2} -> {this.item3}";
        }
    }
}
