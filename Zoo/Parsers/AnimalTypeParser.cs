using System.Collections.Generic;
using System.Globalization;
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


                double meatPercent = 0;
                if (data.Length == 4 && data[3] != "")
                {
                    var percent = data[3].Replace("%", "");
                    meatPercent = double.Parse(percent, CultureInfo.InvariantCulture) / 100;
                }

                var ratio = double.Parse(data[1], CultureInfo.InvariantCulture);
                var dietType = GetDietType(data[2]);
                var name = data[0];
                var animalType = new AnimalType(name, ratio, dietType, meatPercent);

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