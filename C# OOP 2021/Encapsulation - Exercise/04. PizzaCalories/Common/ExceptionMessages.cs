namespace _04._PizzaCalories.Common
{
    public static class ExceptionMessages
    {
        public const string InvalidDoughTypeExceptionMessage = "Invalid type of dough.";
        public const string InvalidDoughWeihgtExceptionMessage = "Dough weight should be in the range [1..200].";
        public const string InvalidToppingExceptionMessage = "Cannot place {0} on top of your pizza.";
        public const string InvalidToppingWeightExceptionMessage = "{0} weight should be in the range[1..50].";
        public const string InvalidPizzaNameExceptionMessage = "Pizza name should be between 1 and 15 symbols.";
        public const string MaximumToppingsCountReachedMessage = "Number of toppings should be in range [0..10].";
    }
}
