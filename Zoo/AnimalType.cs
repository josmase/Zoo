namespace Zoo
{
    public class AnimalType
    {
        public AnimalType(string animal, double ratio, Diet diet, double? meatPercent = null)
        {
            Animal = animal;
            Ratio = ratio;
            Diet = diet;
            MeatPercent = meatPercent;
        }

        public string Animal { get; }
        public double Ratio { get; }
        public Diet Diet { get; }
        public double? MeatPercent { get; }
    }
}