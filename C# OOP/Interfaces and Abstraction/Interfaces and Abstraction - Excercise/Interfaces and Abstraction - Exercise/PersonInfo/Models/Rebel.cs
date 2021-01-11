using PersonInfo.Contracts;

namespace PersonInfo.Models
{
    public class Rebel : IPerson, IBuyer
    {
        public const int IntialFoodQuantity = 0;

        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
            this.Food = IntialFoodQuantity;
        }
        
        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Group { get; private set; }

        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
