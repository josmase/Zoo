using System;
using System.IO;
using Xunit;
using Zoo.Parsers;

namespace ZooTests.Parsers
{
    public class PriceParserTest
    {
        [Fact]
        public void ShouldGetPrices()
        {
            const double meatPrice = 12.3;
            const double fruitPrice = 2.3;
            var priceString = $@"Meat={meatPrice}
Fruit={fruitPrice}";
            var reader = new StringReader(priceString);
            var parser = new PriceParser();
            var prices = parser.ParsePrices(reader);

            Assert.Equal(fruitPrice, prices.Fruits);
            Assert.Equal(meatPrice, prices.Meat);
        }

        [Fact]
        public void ShouldThrowWExceptionForInvalidKey()
        {
            const string invalidKey = "invalid";
            var priceString = $@"{invalidKey}=123
Fruit=123";
            var reader = new StringReader(priceString);
            Assert.Throws<ArgumentOutOfRangeException>(() => new PriceParser().ParsePrices(reader));
        }
    }
}