using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories.Contracts;
using AquaShop.Utilities.Messages;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IDecoration> decorations;
        private readonly ICollection<IAquarium> aquariums;

        public Controller()
        {
            this.aquariums = new List<IAquarium>();
            this.decorations = new DecorationRepository();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium;

            if (aquariumType == "FreshwaterAquarium")
            //if (aquariumType == nameof(FreshwaterAquarium))
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            this.aquariums.Add(aquarium);

            string result = string.Format(OutputMessages.SuccessfullyAdded, aquariumType);

            return result;
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration;

            if(decorationType == nameof(Ornament))
            {
                decoration = new Ornament();
            }
            else if (decorationType == nameof(Plant)) //(decorationType == "Plant")
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            this.decorations.Add(decoration);

            string result = string.Format(OutputMessages.SuccessfullyAdded, decorationType);

            return result;
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish;
            IAquarium aquarium = CreateAquarium(aquariumName);

            if (fishType == nameof(FreshwaterFish))
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);

                if (aquarium.GetType().Name == nameof(FreshwaterAquarium))
                {
                    aquarium.AddFish(fish);
                }
                else
                {
                    return ReturnUnsuitableWaterMessage();
                }
            }
            else if (fishType == nameof(SaltwaterFish))
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);

                if (aquarium.GetType().Name == nameof(SaltwaterAquarium))
                {
                    aquarium.AddFish(fish);
                }
                else
                {
                    return ReturnUnsuitableWaterMessage();
                }
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            string result = string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);

            return result;
        }

        private IAquarium CreateAquarium(string aquariumName)
        {
            return this.aquariums.FirstOrDefault(a => a.Name == aquariumName);
        }

        private static string ReturnUnsuitableWaterMessage()
        {
            return OutputMessages.UnsuitableWater;
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = CreateAquarium(aquariumName);

            decimal totalPrice = aquarium.Fish.Sum(f => f.Price) + aquarium.Decorations.Sum(d => d.Price);

            //decimal totalPrice = 0;

            //foreach (var fish in aquarium.Fish)
            //{
            //    totalPrice += fish.Price;
            //}

            //foreach (var decoration in aquarium.Decorations)
            //{
            //    totalPrice += decoration.Price;
            //}

            string result = string.Format(OutputMessages.AquariumValue, aquariumName, totalPrice);

            return result;
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = CreateAquarium(aquariumName);

            foreach (var fish in aquarium.Fish)
            {
                fish.Eat();
            }

            string result = string.Format(OutputMessages.FishFed, aquarium.Fish.Count);

            return result;
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decoration = this.decorations.FindByType(decorationType);

            IAquarium aquarium = CreateAquarium(aquariumName);

            if (decoration == null)
            {
                string exceptionMessage = string.Format(ExceptionMessages.InexistentDecoration, decorationType);
                throw new InvalidOperationException(exceptionMessage);
            }

            aquarium.AddDecoration(decoration);
            decorations.Remove(decoration);

            string result = string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);

            return result;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
