using System;
using System.IO;

namespace Zoo.Parsers
{
    public interface IPriceParser
    {
        Prices ParsePrices(TextReader file);
    }

    public class PriceParser : IPriceParser
    {
        private const string MeatKey = "Meat";
        private const string FruitKey = "Fruit";

        public Prices ParsePrices(TextReader file)
        {
            string line;
            double meatPrice = 0;
            double fruitPrice = 0;
            while ((line = file.ReadLine()) != null)
            {
                var priceData = line.Split("=");
                var price = Convert.ToDouble(priceData[1]);
                switch (priceData[0])
                {
                    case MeatKey:
                        meatPrice = price;
                        break;
                    case FruitKey:
                        fruitPrice = price;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException($"Unkown price: {priceData[0]}");
                }
            }

            return new Prices(fruitPrice, meatPrice);
        }
    }
}