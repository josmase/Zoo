using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Zoo.Parsers
{
    public interface IAnimalTypeParser
    {
        IEnumerable<AnimalType> ParseTypes(TextReader file);
    }

    public class AnimalTypeParser : IAnimalTypeParser
    {
        public IEnumerable<AnimalType> ParseTypes(TextReader file)
        {
            var animalTypes = new List<AnimalType>();
            string line = null;
            while ((line = file.ReadLine()) != null)
            {
                var data = line.Split(";");


                double? meatPercent = null;
                if (data.Length == 4)
                {
                    var percent = data[3].Replace("%", "");
                    meatPercent = Convert.ToDouble(percent) / 100;
                }

                var ratio = Convert.ToDouble(data[1]);

                var animalType = new AnimalType(data[0], ratio, GetDietType(data[2]), meatPercent);

                animalTypes.Add(animalType);
            }

            return animalTypes;
        }

        private Diet GetDietType(string type)
        {
            return type switch
            {
                "fruit" => Diet.Herbivore,
                "meat" => Diet.Carnivore,
                _ => Diet.Omnivore
            };
        }
    }
}