using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    class Clinic
    {
        private List<Pet> data;

        public Clinic(int capacity)
        {
            Capacity  = capacity;
            this.data = new List<Pet>();
        }
        public int Capacity { get; }
        public int Count { get => data.Count; }
        public void Add(Pet pet)
        {
            if (data.Count < Capacity)
            {
                data.Add(pet);
            }
        }
        public bool Remove(string name)
        {
            int idx = data.FindIndex(pet => pet.Name == name);
            if (idx == -1) return false;

            data.RemoveAt(idx);
            return true;
        }
        public Pet GetPet(string name, string owner)
        {
            Func<Pet, bool> findFilter = pet => 
                            pet.Name  == name && 
                            pet.Owner == owner;

            return data.FirstOrDefault(findFilter);
        }
        public Pet GetOldestPet()
        {
            var maxAges = data.Max(pet => pet.Age);
            return data.FirstOrDefault(pet => pet.Age == maxAges);
        }
        public string GetStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");

            data.ForEach(pet => 
            sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}"));

            return sb.ToString();
        }
    }
}
