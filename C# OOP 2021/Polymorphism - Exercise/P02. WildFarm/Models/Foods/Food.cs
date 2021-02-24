using System;

using P02._WildFarm.Common;

namespace P02._WildFarm.Models.Foods
{
    public abstract class Food
    {
        private int quantity;

        public Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity
        {
            get 
            { 
                return this.quantity;
            }
            private set
            {
                if(value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFoodQuantityMessage);
                }
                
                this.quantity = value;
            }
        }
    }
}
