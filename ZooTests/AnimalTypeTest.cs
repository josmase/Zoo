using Xunit;
using Zoo;

namespace ZooTests
{
    public class AnimalTypeTest
    {
        [Fact]
        public void ShouldCreateAnimalTypeWithMeatPercent()
        {
            const string animalType = "Lion";
            const Diet diet = Diet.Carnivore;
            const double ratio = 0.3;
            const double meatPercent = 0.0;


            var type = new AnimalType(animalType, ratio, diet, meatPercent);

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
            Assert.Null(type.MeatPercent);
        }
    }
}