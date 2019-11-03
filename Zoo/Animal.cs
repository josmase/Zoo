namespace Zoo
{
    public class Animal
    {
        private AnimalType AnimalType;

        public Animal(AnimalType animalType, string name,int weight)
        {
            AnimalType = animalType;
            Name = name;
            Weight = weight;
        }


        public string Name { get; }
        public int Weight { get; }
    }
}