namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Car car = new Car(100, 3.3);
            Car sportCar = new SportCar(100, 3.3);
            var motorcycle = new Motorcycle(20, 60);

            System.Console.WriteLine(car.FuelConsumption);
            System.Console.WriteLine(sportCar.FuelConsumption);
            System.Console.WriteLine(motorcycle.FuelConsumption);
        }
    }
}
