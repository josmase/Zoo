using System;
using System.Collections.Generic;
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
                var nodeName = typeNode.Name.LocalName;
                var animalType = animalTypes.FirstOrDefault(x => x.Animal == nodeName.Remove(nodeName.Length - 1));

                foreach (var animalNode in typeNode.Descendants())
                {
                    var name = animalNode.Attribute("name")?.Value;
                    var weight = animalNode.Attribute("kg")?.Value;
                    if (name != null && weight != null)
                        animals.Add(new Animal(animalType, name, Convert.ToInt32(weight)));
                }
            }

            return animals;
        }
    }
}