using CarDealer.Data;
using CarDealer.DTO.Export;
using CarDealer.DTO.Import;
using CarDealer.Models;
using CarDealer.XMLHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;

namespace CarDealer
{
    public class StartUp
    {
        private const string ResultDirectoryPath = "../../../Datasets/Results";
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();

            //Problem 09
            //string suppliersXmlString = File.ReadAllText("Datasets/suppliers.xml");
            //string result = ImportSuppliers(context, suppliersXmlString);

            //Problem 10
            //string partsXmlString = File.ReadAllText("Datasets/parts.xml");
            //string result = ImportParts(context, partsXmlString);

            //Problem 11
            //string carsXmlString = File.ReadAllText("Datasets/cars.xml");
            //string result = ImportCars(context, carsXmlString);

            //Problem 12
            //string customersXmlString = File.ReadAllText("Datasets/customers.xml");
            //string result = ImportCustomers(context, customersXmlString);

            //Problem 13
            //string salesXmlString = File.ReadAllText("Datasets/sales.xml");
            //string result = ImportSales(context, salesXmlString);

            //Problem 14
            //string result = GetCarsWithDistance(context);
            //File.WriteAllText(ResultDirectoryPath + "/cars.xml", result);

            //Problem 15
            //string result = GetCarsFromMakeBmw(context);
            //File.WriteAllText(ResultDirectoryPath + "/bmw-cars.xml", result);

            //Problem 16
            //string result = GetLocalSuppliers(context);
            //File.WriteAllText(ResultDirectoryPath + "/local-suppliers.xml", result);

            //Problem 17
            //string result = GetCarsWithTheirListOfParts(context);
            //File.WriteAllText(ResultDirectoryPath + "/cars-and-parts.xml", result);

            //Problem 18
            //string result = GetTotalSalesByCustomer(context);
            //File.WriteAllText(ResultDirectoryPath + "/customers-total-sales.xml", result);

            //Problem 19
            string result = GetSalesWithAppliedDiscount(context);
            File.WriteAllText(ResultDirectoryPath + "/sales-discounts.xml", result);

            //Console.WriteLine(result);
        }

        //Problem 09
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            string rootElement = "Suppliers";

            var importSuppliersDTOs = XMLConverter.Deserializer<ImportSuppliersDTO>(inputXml, rootElement);

            var suppliers = importSuppliersDTOs
                .Select(s => new Supplier
                {
                    Name = s.Name,
                    IsImporter = s.IsImporter
                })
                .ToArray();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";
        }

        //Problem 10
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            const string rootElement = "Parts";

            var importPartsDTOs = XMLConverter.Deserializer<ImportPartsDTO>(inputXml, rootElement);

            var parts = importPartsDTOs
                .Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId))
                .Select(p => new Part
                {
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    SupplierId = p.SupplierId
                })
                .ToArray();

            context.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}";
        }

        //Problem 11
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            string rootElement = "Cars";

            var importCarsDTOs = XMLConverter.Deserializer<ImportCarsDTO>(inputXml, rootElement);

            var cars = new List<Car>();

            foreach (var carDTO in importCarsDTOs)
            {
                var uniquePartsIds = carDTO.Parts.Select(p => p.Id).Distinct().ToArray();
                var realPartsIds = uniquePartsIds.Where(id => context.Parts.Any(p => p.Id == id));

                Car car = new Car
                {
                    Make = carDTO.Make,
                    Model = carDTO.Model,
                    TravelledDistance = carDTO.TravelledDistance,
                    PartCars = realPartsIds.Select(id => new PartCar
                    {
                        PartId = id
                    })
                    .ToArray()
                };

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            //var cars = new List<Car>();
            //var carParts = new List<PartCar>();

            //var partsCount = context.Parts.Count();
            //var resultCarDtos = XmlConverter.Deserializer<CarDTO>(inputXml, rootName);

            //foreach (var car in resultCarDtos)
            //{
            //    var newCar = new Car { Make = car.Make, Model = car.Model, TravelledDistance = car.TraveledDistance };

            //    cars.Add(newCar);
            //    foreach (var partId in car.CarParts.Select(x => new { partId = x.PartId }).Distinct())
            //    {
            //        var newCarPart = new PartCar
            //        {
            //            PartId = partId.partId,
            //            Car = newCar
            //        };
            //        carParts.Add(newCarPart);
            //    }
            //}
            //context.Cars.AddRange(cars);
            //context.PartCars.AddRange(carParts);
            //context.SaveChanges();
            //----------------------------------------------------------------
            //List<Car> cars = new List<Car>();
            //List<PartCar> partCars = new List<PartCar>();

            //foreach (var c in carsDto)
            //{
            //    var car = new Car()
            //    {
            //        Make = c.Make,
            //        Model = c.Model,
            //        TravelledDistance = c.TravelledDistance
            //    };

            //    var parts = c
            //        .Parts
            //        .Select(p => p.Id)
            //        .Where(p => context.Parts.Any(part => part.Id == p))
            //        .Distinct();

            //    foreach (var partId in parts)
            //    {
            //        var carPart = new PartCar()
            //        {
            //            PartId = partId,
            //            Car = car
            //        };

            //        partCars.Add(carPart);
            //    }

            //    cars.Add(car);
            //}

            //context.Cars.AddRange(cars);
            //context.PartCars.AddRange(partCars);
            //context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        //Problem 12
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            string rootElement = "Customers";

            var importCustormersDTOs = XMLConverter.Deserializer<ImportCustomersDTO>(inputXml, rootElement);

            var customers = importCustormersDTOs
                .Select(c => new Customer
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                    //BirthDate = DateTime.Parse(c.BirthDate) - понякога xml не работи добре с формат DateTime и оставямв пропъртито в DTO-то string, тук си го парсваме сами. Ако се изисква специфичен формат също тък го подаваме.
                })
                .ToArray();

            context.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}";
        }

        //Problem 13
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            string rootElement = "Sales";

            var importSalesDTOs = XMLConverter.Deserializer<ImportSalesDTO>(inputXml, rootElement);

            var sales = importSalesDTOs
                .Where(s => context.Cars.Any(c => c.Id == s.CarId))
                .Select(s => new Sale
                {
                    CarId = s.CarId,
                    CustomerId = s.CustomerId,
                    Discount = s.Discount
                })
                .ToArray();

            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}";
        }

        //Problem 14
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            string rootElement = "cars";

            var targetCars = context
                .Cars
                .Where(c => c.TravelledDistance > 2000000)
                .Select(c => new GetCarsWithDistanceDTO
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToList();

            var xml = XMLConverter.Serialize(targetCars, rootElement);

            return xml;
        }

        //Problem  15
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            string rootElement = "cars";

            var targetCars = context
                .Cars
                .Where(c => c.Make == "BMW")
                .Select(c => new GetCarsFromMakeBmwDTO
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToList();

            string xml = XMLConverter.Serialize(targetCars, rootElement);

            return xml;
        }

        //Problem 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            string rootElement = "suppliers";

            var targetCars = context
                .Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new GetLocalSuppliersDTO
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToList();

            string xml = XMLConverter.Serialize(targetCars, rootElement);

            return xml;
        }

        //Problem 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            string rootElement = "cars";

            var cars = context
                .Cars
                .Select(c => new GetCarsWithTheirListOfPartsDTO
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars.Select(pc => new ExportPartsOfTheCarDTO
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price
                    })
                    .OrderByDescending(p => p.Price)
                    .ToList()
                })
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToList();

            string xml = XMLConverter.Serialize(cars, rootElement);

            return xml;
        }

        //Problem 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            string rootElement = "customers";

            //var targetCustormes = context
            //    .Customers
            //    .Where(c => c.Sales.Count > 0)
            //    .Select(c => new GetTotalSalesByCustomerDTO
            //    {
            //        Name = c.Name,
            //        BoughtCarsCount = c.Sales.Count,
            //        TotalSpentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))
            //    })
            //    .OrderByDescending(c => c.TotalSpentMoney)
            //    .ToList();

            //Минава в Judge, локално не може да изпълни вложените sum

            //Get all customers that have bought at least 1 car and get their names, 
            //    bought cars count and total spent money on cars.Order the result list by total spent money descending.


            var targetCustormes = context
                .Sales
                .Where(s => s.Customer.Sales.Any())
                .Select(s => new GetTotalSalesByCustomerDTO
                {
                    Name = s.Customer.Name,
                    BoughtCarsCount = s.Customer.Sales.Count(),
                    TotalSpentMoney = s.Car.PartCars.Sum(pc => pc.Part.Price)
                })
                .OrderByDescending(s => s.TotalSpentMoney)
                .ToList();

            string xml = XMLConverter.Serialize(targetCustormes, rootElement);

            return xml;
        }

        //Problem 19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            string rootElement = "sales";

            var sales = context
                .Sales
                .Select(s => new GetSalesWithAppliedDiscountDTO
                {
                    Car = new ExportCarFromSalesWithDiscount
                    { 
                         Make = s.Car.Make,
                         Model = s.Car.Model,
                         TravelledDistance = s.Car.TravelledDistance
                    },
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartCars.Sum(pc => pc.Part.Price),
                    PriceWithDiscount = s.Car.PartCars.Sum(pc => pc.Part.Price) * (100 - s.Discount) / 100
                })
                .ToList();

            string xml = XMLConverter.Serialize(sales, rootElement);

            return xml;
        }
    }
}


