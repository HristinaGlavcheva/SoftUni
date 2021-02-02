namespace _04._PizzaCalories
{
    public class Dough
    {
        private const double BaseCaloriesPerGram = 2;

        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get
            {
                return this.flourType;
            }
            private set
            {
                DoughValidator.ValidateDouhgType(value);

                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            private set
            {
                DoughValidator.ValidateBakingTechnique(value);

                this.bakingTechnique = value;
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
                DoughValidator.ValidateWeight(value);
                
                this.weight = value;
            }
        }

        public double GetTotalCalories()
        {
            double calories = this.Weight 
                * BaseCaloriesPerGram 
                * DoughValidator.FlourTypes[this.FlourType.ToLower()] 
                * DoughValidator.BakingTechniques[this.BakingTechnique.ToLower()];

            return calories;
        }
    }
}