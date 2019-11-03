using System;

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

        public double CalculatePrice(double weight, Prices prices)
        {
            double price = 0;
            if (Diet != Diet.Omnivore)
            {
                var foodPrice = Diet == Diet.Herbivore ? prices.Fruits : prices.Meat;
                price = foodPrice * weight * Ratio;
            }
            else
            {
                var meatRatio = Ratio * MeatPercent;
                var fruitRatio = Ratio - meatRatio;
                price = prices.Fruits * weight * fruitRatio + prices.Meat * weight * meatRatio;
            }

            return Math.Round(price, 3);
        }
    }
}