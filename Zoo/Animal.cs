namespace Zoo
{
    public class Animal
    {
        private readonly AnimalType _animalType;

        public Animal(AnimalType animalType, string name, int weight)
        {
            _animalType = animalType;
            Name = name;
            Weight = weight;
        }


        public string Name { get; }
        public int Weight { get; }

        public double CalculatePrice(Prices prices)
        {
            return _animalType.CalculatePrice(Weight, prices);
        }
    }
}