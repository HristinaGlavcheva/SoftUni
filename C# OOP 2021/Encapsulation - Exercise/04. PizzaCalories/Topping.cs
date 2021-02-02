namespace _04._PizzaCalories
{
    public class Topping
    {
        private const double BaseCaloriesPerGram = 2;

        private string name;
        private int weight;

        public Topping(string name, int weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name
        {
            get
            { 
                return this.name; 
            }
            private set
            {
                ToppingValidator.ValidateTopping(value);

                this.name = value;
            }
        }

        public int Weight
        {
            get
            { 
                return this.weight;
            }
            private set
            {
                ToppingValidator.ValidateWeight(value, this.Name);

                this.weight = value;
            }
        }

        public double GetTotalCalories()
        {
            double calories = this.Weight
                * BaseCaloriesPerGram
                * ToppingValidator.Toppings[this.Name.ToLower()];

            return calories;
        }
    }
}
