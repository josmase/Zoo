namespace Zoo
{
    public class Animal
    {
        private AnimalType AnimalType;

        public Animal(AnimalType animalType, string name)
        {
            AnimalType = animalType;
            Name = name;
        }


        public string Name { get; }

    }
}