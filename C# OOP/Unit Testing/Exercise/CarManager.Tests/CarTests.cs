using CarManager;
using NUnit.Framework;
using System.Data;

namespace Tests
{
    public class CarTests
    {
        private const string Make = "Renault";
        private const string Model = "Modus";
        private const double FuelConsumption = 13;
        private const double FuelCapacity = 100;
        private const double DefaultFuelAmount = 0;

        private Car car;

        [SetUp]
        public void Setup()
        {
            this.car = new Car(Make, Model, FuelConsumption, FuelCapacity);
        }

        [Test]
        public void ConstructorShoudCreateCarWithDefaultFuelAmountEqualToZero()
        {
            Assert.That(this.car.FuelAmount.Equals(0));
        }

        [Test]
        public void ConstructorShouldInitializeCarCorrectly()
        {
            Assert.That(this.car.Make.Equals(Make));
            Assert.That(this.car.Model.Equals(Model));
            Assert.That(this.car.FuelConsumption.Equals(FuelConsumption));
            Assert.That(this.car.FuelCapacity.Equals(FuelCapacity));
        }

        [Test]
        [TestCase(null, Model, FuelConsumption, FuelCapacity)]
        [TestCase(Make, null, FuelConsumption, FuelCapacity)]
        [TestCase(Make, Model, 0, FuelCapacity)]
        [TestCase(Make, Model, -5, FuelCapacity)]
        [TestCase(Make, Model, FuelConsumption, 0)]
        [TestCase(Make, Model, FuelConsumption, -5)]
        public void AllPropertiesShouldThrowArgumentExceptionForInvalidValues
            (string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.That(
                () =>
                {
                    Car car = new Car(make, model, fuelConsumption, fuelCapacity);
                },
                Throws.ArgumentException);
        }

        //[Test]
        //public void MakeSetterShouldThrowArgumentExceptionIfMakeIsNull()
        //{
        //    Assert.That(
        //        () =>
        //        {
        //            Car car = new Car(null, Model, FuelConsumption, FuelCapacity);
        //        },
        //        Throws.ArgumentException);
        //}

        //[Test]
        //public void ModelSetterShouldThrowArgumentExceptionIfModelIsNull()
        //{
        //    Assert.That(
        //        () =>
        //        {
        //            Car car = new Car(Make, null, FuelConsumption, FuelCapacity);
        //        },
        //        Throws.ArgumentException);
        //}

        //[Test]
        //public void FuelConsumptionSetterShouldThrowArgumentExceptionIfFuelConsumptionIsZeroOrNegative()
        //{
        //    Assert.That(
        //        () =>
        //        {
        //            Car car = new Car(Make, Model, 0, FuelCapacity);
        //        },
        //        Throws.ArgumentException);

        //    Assert.That(
        //        () =>
        //        {
        //            Car car = new Car(Make, Model, -5, FuelCapacity);
        //        },
        //        Throws.ArgumentException);
        //}

        //[Test]
        //public void FuelCapacitySetterShouldThrowArgumentExceptionIfFuelAmountIsZeroOrNegative()
        //{
        //    Assert.That(
        //        () =>
        //        {
        //            Car car = new Car(Make, Model, FuelConsumption, 0);
        //        },
        //        Throws.ArgumentException);

        //    Assert.That(
        //        () =>
        //        {
        //            Car car = new Car(Make, Model, FuelConsumption, -5);
        //        },
        //        Throws.ArgumentException);
        //}

        [Test]
        [TestCase(0)]
        [TestCase(-5)]
        public void RefuelOperationShouldThrowArgumentExceptionIfFuelAmountToRefuelIsZeroOrNegative(double fuelToRefuelWith)
        {
            Assert.That(
                () => car.Refuel(fuelToRefuelWith),
                Throws.ArgumentException);
        }

        [Test]
        public void RefuelOperationIncreasesAmountOfFuelIfFuelAmountToRefuelIsPositive()
        {
            double fuelToRefuelWith = 15;

            car.Refuel(fuelToRefuelWith);

            double expectedFuelAmount = DefaultFuelAmount + fuelToRefuelWith;

            Assert.That(car.FuelAmount.Equals(expectedFuelAmount));
        }

        [Test]
        public void RefuelOperationSetsAmountOfFuelToFuelCapacityIfCapacitiyIsExceeded()
        {
            double fuelToRefuelWith = 110;

            car.Refuel(fuelToRefuelWith);

            double expectedFuelAmount = FuelCapacity;

            Assert.That(car.FuelAmount.Equals(expectedFuelAmount));
        }

        [Test]
        public void DriveOperationShouldThrowInvalidOperationExceptionIfFuelAmountIsNotEnough()
        {
            car.Refuel(5);

            double distance = 100;

            Assert.That(() => car.Drive(distance),
                Throws.InvalidOperationException);
        }

        [Test]
        public void DriveOperationShoudDecreaseFuelWithProperAmount()
        {
            car.Refuel(20);
            car.Drive(100);

            double expectedFuelAmount = 7;

            Assert.That(car.FuelAmount.Equals(expectedFuelAmount));
        }
    }
}