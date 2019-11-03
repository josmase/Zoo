namespace Zoo
{
    public class Animal
    {
        public Animal(string animalType, Diet diet, string name, double ratio, double meatPercent)
        {
            AnimalType = animalType;
            Diet = diet;
            Name = name;
            Ratio = ratio;
            MeatPercent = meatPercent;
        }

        public string AnimalType { get; }
        public Diet Diet { get; }
        public string Name { get; }
        public double Ratio { get; }
        public double MeatPercent { get; }
    }
}