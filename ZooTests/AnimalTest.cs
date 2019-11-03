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
            var typeStub = new AnimalType("", 0, Diet.Carnivore, 0);
            const string name = "Simba";
            const int weight = 0;

            var animal = new Animal(typeStub, name, weight);

            Assert.Equal(name, animal.Name);
            Assert.Equal(weight, animal.Weight);
        }
    }
}