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
            var type = new AnimalType("Lion", 0.3, Diet.Carnivore, 0.3);
            const string name = "Simba";
            
            var animal = new Animal(type, name);

            Assert.Equal(name, animal.Name);
        }
    }
}