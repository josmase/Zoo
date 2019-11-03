using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Xunit;
using Zoo;
using Zoo.Parsers;

namespace ZooTests.Parsers
{
    public class AnimalParserTest
    {
        [Fact]
        public void ShouldFindOneAnimal()
        {
            const string name = "name";
            const int weight = 0;
            const string animalTypeName = "Lion";
            var document = new XDocument(
                new XElement("Zoo",
                    new XElement($"{animalTypeName}s",
                        new XElement(animalTypeName,
                            new XAttribute("name", name),
                            new XAttribute("kg", weight))
                    )));

            var typeMock = new AnimalType(animalTypeName, 0, Diet.Carnivore);
            var typesMock = new List<AnimalType> {typeMock};
            var animals = new AnimalParser().ParseAnimal(document, typesMock).ToList();
            var animal = animals[0];
            Assert.Single(animals);
            Assert.Equal(name, animal.Name);
            Assert.Equal(weight, animal.Weight);
        }
    }
}