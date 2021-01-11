using PersonInfo.Contracts;

namespace PersonInfo.Models
{
    public class Citizen : IPerson, IIdentifiable, IBirthable, IBuyer
    {
        public const int IntialFoodQuantity = 0;

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
            this.Food = IntialFoodQuantity;
        }
        
        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Id { get; private set; }

        public string Birthdate { get; private set; }

        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
