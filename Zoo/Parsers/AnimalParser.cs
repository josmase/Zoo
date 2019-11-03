using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace Zoo.Parsers
{
    public interface IAnimalParser
    {
        IEnumerable<Animal> ParseAnimal(XDocument document, IEnumerable<AnimalType> animalTypes);
    }

    public class AnimalParser : IAnimalParser
    {
        public IEnumerable<Animal> ParseAnimal(XDocument document, IEnumerable<AnimalType> animalTypes)
        {
            var animalTypeNodes = document.Descendants("Zoo").Descendants();
            var animals = new List<Animal>();
            animalTypes = animalTypes.ToList();

            foreach (var typeNode in animalTypeNodes)
            {
                foreach (var animalNode in typeNode.Descendants())
                {
                    var nodeName = animalNode.Name.LocalName;
                    var animalType = animalTypes.FirstOrDefault(x => x.Animal == nodeName);
                    var name = animalNode.Attribute("name")?.Value;
                    var weight = animalNode.Attribute("kg")?.Value;
                    if (name != null && weight != null)
                        animals.Add(new Animal(animalType, name, double.Parse(weight, CultureInfo.InvariantCulture)));
                }
            }

            return animals;
        }
    }
}