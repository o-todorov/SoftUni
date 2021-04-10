
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;

namespace AquaShop.Models
{
    public static class Factory
    {
        public static IAquarium CreateAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType == typeof(FreshwaterAquarium).Name)
            {
                return new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == typeof(SaltwaterAquarium).Name)
            {
                return new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }
        }

        public static IDecoration CreateDecoration(string decorationType)
        {
            if (decorationType == nameof(Ornament))
            {
                return new Ornament();
            }
            else if (decorationType == nameof(Plant))
            {
                return new Plant();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }
        }

        public static IFish CreateFish(string fishType, string fishName, string fishSpecies, decimal price)
        {
            if (fishType == nameof(FreshwaterFish))
            {
                return new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == nameof(SaltwaterFish))
            {
                return new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }
        }
    }
}
