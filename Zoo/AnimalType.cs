namespace Zoo
{
    public class AnimalType
    {
        public AnimalType(string animal, double ratio, Diet diet, double meatPercent = 0)
        {
            Animal = animal;
            Ratio = ratio;
            Diet = diet;
            MeatPercent = meatPercent;
        }

        public string Animal { get; }
        public double Ratio { get; }
        public Diet Diet { get; }
        public double MeatPercent { get; }

        public double CalculatePrice(int weight, Prices prices)
        {
            if (Diet != Diet.Omnivore)
            {
                var foodPrice = Diet == Diet.Herbivore ? prices.Fruits : prices.Meat;
                return foodPrice * weight * Ratio;
            }

            var meatRatio = Ratio * MeatPercent;
            var fruitRatio = Ratio - meatRatio;
            return prices.Fruits * weight * fruitRatio + prices.Meat * weight * meatRatio;
        }
    }
}