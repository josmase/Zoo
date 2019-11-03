using System;
using Xunit;
using Zoo;

namespace ZooTests
{
    public class AnimalTest
    {
        [Fact]
        public void ShouldCreateAnAnimalWithProperties()
        {
            const string animalType = "Lion";
            const Diet diet = Diet.Carnivore;
            const string name = "Simba";
            const double ratio = 0.3;
            const double meatPercent = 0.0;
            
            var animal = new Animal(animalType, diet, name, ratio, meatPercent);

            Assert.Equal(animalType, animal.AnimalType);
            Assert.Equal(diet, animal.Diet);
            Assert.Equal(name, animal.Name);
            Assert.Equal(ratio, animal.Ratio);
            Assert.Equal(meatPercent, animal.MeatPercent);
        }
    }
}