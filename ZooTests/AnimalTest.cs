using Xunit;
using Zoo;

namespace ZooTests
{
    public class AnimalTest
    {
        [Fact]
        public void ShouldCreateAnAnimalWithProperties()
        {
            var typeStub = new AnimalType("", 0, Diet.Carnivore);
            const string name = "Simba";
            const int weight = 0;

            var animal = new Animal(typeStub, name, weight);

            Assert.Equal(name, animal.Name);
            Assert.Equal(weight, animal.Weight);
        }

        [Fact]
        public void ShouldBeOfSameType()
        {
            var type = new AnimalType("type", 0, Diet.Carnivore);
            var animal = new Animal(type, "name", 0);
            Assert.True(animal.IsType(type));
        }
    }
}