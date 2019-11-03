using Xunit;
using Zoo;

namespace ZooTests
{
    public class AnimalTypeTest
    {
        [Theory]
        [InlineData(10, 0.4, 0.5, Diet.Omnivore, 10)]
        [InlineData(16, 0.4, 0.5, Diet.Omnivore, 16)]
        [InlineData(10, 0.4, 0.4, Diet.Omnivore, 9.6)]
        [InlineData(10, 0.1, 0.4, Diet.Omnivore, 2.4)]
        [InlineData(10, 0.4, 0, Diet.Carnivore, 12)]
        [InlineData(16, 0.4, 0, Diet.Carnivore, 19.2)]
        [InlineData(10, 0.4, 0, Diet.Herbivore, 8)]
        [InlineData(16, 0.4, 0, Diet.Herbivore, 12.8)]
        [InlineData(16000, 0.4, 0, Diet.Herbivore, 12800)]
        [InlineData(10, 0.33333, 0, Diet.Herbivore, 6.667)]
        public void ShouldCalculatePrice(int weight, double ratio, double meatPercent, Diet diet, double expected)
        {
            var prices = new Prices(2, 3);
            var type = new AnimalType("", ratio, diet, meatPercent);
            var price = type.CalculatePrice(weight, prices);
            Assert.Equal(expected, price);
        }

        [Fact]
        public void ShouldCreateAnimalTypeWithMeatPercent()
        {
            const string animalType = "Lion";
            const Diet diet = Diet.Carnivore;
            const double ratio = 0.3;
            const double meatPercent = 0.0;


            var type = new AnimalType(animalType, ratio, diet);

            Assert.Equal(animalType, type.Animal);
            Assert.Equal(diet, type.Diet);
            Assert.Equal(ratio, type.Ratio);
            Assert.Equal(meatPercent, type.MeatPercent);
        }

        [Fact]
        public void ShouldCreateAnimalTypeWithoutMeatPercent()
        {
            const string animalType = "Lion";
            const Diet diet = Diet.Carnivore;
            const double ratio = 0.3;

            var type = new AnimalType(animalType, ratio, diet);

            Assert.Equal(animalType, type.Animal);
            Assert.Equal(diet, type.Diet);
            Assert.Equal(ratio, type.Ratio);
            Assert.Equal(0, type.MeatPercent);
        }
    }
}