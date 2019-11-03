using Xunit;
using Zoo;

namespace ZooTests
{
    public class PricesTest
    {
        [Fact]
        public void ShouldCreatePrices()
        {
            const double meatPrice = 20.4;
            const double fruitPrice = 10.2;

            var prices = new Prices(fruitPrice, meatPrice);

            Assert.Equal(fruitPrice, prices.Fruits);
            Assert.Equal(meatPrice, prices.Meat);
        }
    }
}