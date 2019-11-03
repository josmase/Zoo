using System;

namespace Zoo
{
    public class Animal
    {
        private readonly AnimalType _animalType;

        public Animal(AnimalType animalType, string name, double weight)
        {
            _animalType = animalType;
            Name = name;
            Weight = weight;
        }


        public string Name { get; }
        public double Weight { get; }

        public bool IsType(AnimalType animalType)
        {
            return animalType.Animal == _animalType.Animal;
        }

        public double CalculatePrice(Prices prices)
        {
            return _animalType.CalculatePrice(Weight, prices);
        }
    }
}