using AquaShop.Core.Contracts;
using AquaShop.Models;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private Dictionary<string, IAquarium> aquariums;

        public Controller()
        {
            this.decorations    = new DecorationRepository();
            this.aquariums      = new Dictionary<string, IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            aquariums.Add(aquariumName, Factory.CreateObject<IAquarium>(
                                                aquariumType, 
                                                ExceptionMessages.InvalidAquariumType, 
                                                aquariumName
                                                ));

            return string.Format(OutputMessages.SuccessfullyAdded,aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            decorations.Add(Factory.CreateObject<IDecoration>(decorationType, ExceptionMessages.InvalidDecorationType));

            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            var aquarium = aquariums[aquariumName];

            IFish fish = Factory.CreateObject<IFish>(fishType, ExceptionMessages.InvalidFishType, fishName, fishSpecies, price);

            if (fishType.Replace("Fish", "") == aquarium.GetType().Name.Replace("Aquarium", ""))
            {
                aquarium.AddFish(fish);
                return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }

            return OutputMessages.UnsuitableWater;
        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = aquariums[aquariumName];

            return string.Format(OutputMessages.AquariumValue, aquariumName,
                                                               aquarium.Fish.Sum(f => f.Price) +
                                                               aquarium.Decorations.Sum(d => d.Price));
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = aquariums[aquariumName];

            aquarium.Feed();

            return string.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var decoration = decorations.FindByType(decorationType);

            if (decoration == null)
            {
                string message = string.Format(ExceptionMessages.InexistentDecoration, decorationType);
                throw new InvalidOperationException(message);
            }

            aquariums[aquariumName].AddDecoration(decoration);

            decorations.Remove(decoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            return string.Join(Environment.NewLine, aquariums.Values.Select(a => a.GetInfo()));
        }
    }
}
