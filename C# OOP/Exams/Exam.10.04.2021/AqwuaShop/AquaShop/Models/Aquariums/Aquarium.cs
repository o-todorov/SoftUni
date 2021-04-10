using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private readonly List<IDecoration> decorations;
        private readonly Dictionary<string, IFish> fishes;
        protected Aquarium(string name, int capacity)
        {
            Name        = name;
            Capacity    = capacity;
            decorations = new List<IDecoration>();
            fishes      = new Dictionary<string, IFish>();
        }
        public string Name
        {
            get => name;

            private set => name = Validator.StringNotNullOrEmpty(value, ExceptionMessages.InvalidAquariumName);
        }

        public int Capacity { get; }

        public int Comfort                                  => decorations.Sum(d => d.Comfort);

        public ICollection<IDecoration> Decorations         => decorations;

        public ICollection<IFish> Fish                      => fishes.Values;

        public void AddDecoration(IDecoration decoration)   => decorations.Add(decoration);

        public void Feed()                                  => fishes.Values.ToList().ForEach(f => f.Eat());

        public void AddFish(IFish fish)
        {
            if (fishes.Count == Capacity)
            {
                var message = ExceptionMessages.NotEnoughCapacity;
                throw new ArgumentException(message);
            }

            if (!fishes.ContainsKey(fish.Name))
            {
                fishes.Add(fish.Name, fish);
            }

        }

        public string GetInfo()
        {
            var fishesString = (fishes.Count != 0) ? string.Join(", ", fishes.Keys) : "none";

            return $"{Name} ({this.GetType().Name}):"
                                                    + Environment.NewLine
                                                    + $"Fish: {fishesString}"
                                                    + Environment.NewLine
                                                    + $"Decorations: { decorations.Count}"
                                                    + Environment.NewLine
                                                    + $"Comfort: {Comfort}";
        }

        public bool RemoveFish(IFish fish)
        {
            if (!fishes.ContainsKey(fish.Name))
            {
                return false;
            }

            fishes.Remove(fish.Name);
            return true;
        }
    }
}
