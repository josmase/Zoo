using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Zoo.Parsers;

namespace Zoo
{
    internal interface ICli
    {
        Task Start();
    }

    public class Cli : ICli
    {
        private readonly IAnimalParser _animalParser;
        private readonly IPriceParser _priceParser;
        private readonly IAnimalTypeParser _typeParser;

        public Cli(IAnimalTypeParser typeParser, IAnimalParser animalParser, IPriceParser priceParser)
        {
            _typeParser = typeParser;
            _animalParser = animalParser;
            _priceParser = priceParser;
        }

        public async Task Start()
        {
            Console.WriteLine("Welcome to our zoo!");
            var animalTypes = (await AskForAnimalTypes()).ToList();
            var prices = await AskForPrices();
            var animals = AskForZoo(animalTypes);

            do
            {
                var typesToCalculateFor = AskWhatTypesShouldBeCalculated(animalTypes);
                var totalCost = 0.0;
                foreach (var type in typesToCalculateFor)
                {
                    var cost = CalculateCost(animals, type, prices);
                    Console.WriteLine($"Cost for {type.Animal} is: {Math.Round(cost, 3)}");
                    totalCost += cost;
                }

                Console.WriteLine($"Total cost is: {Math.Round(totalCost, 3)}");
            } while (!ShouldExit());
        }

        private static bool ShouldExit()
        {
            do
            {
                Console.WriteLine("Do you want to calculate more prices? Y/n");
                var answer = Console.ReadLine();
                if (string.IsNullOrEmpty(answer) || answer.ToLower() == "y")
                {
                    return false;
                }

                if (answer.ToLower() == "n")
                {
                    return true;
                }
            } while (true);
        }

        private static double CalculateCost(IEnumerable<Animal> animals, AnimalType type, Prices prices)
        {
            return animals.Where(animal => animal.IsType(type))
                .Aggregate(0.0, ((cost, animal) => cost + animal.CalculatePrice(prices)));
        }


        private IEnumerable<AnimalType> AskWhatTypesShouldBeCalculated(IEnumerable<AnimalType> types)
        {
            var typesList = types.ToList();
            Console.WriteLine("What types of animals do you want to know the cost of?");
            var counter = 0;
            foreach (var type in typesList)
            {
                Console.WriteLine($"{counter} - {type.Animal}s");
                counter++;
            }

            Console.WriteLine(
                "Enter the animals as a comma separated list or nothing for all animals (Invalid input is ignored): ");
            var input = Console.ReadLine();

            return !string.IsNullOrEmpty(input)
                ? input.Split(",")
                    .Select(index => index.Trim())
                    .Where(index => int.TryParse(index, out var n))
                    .Where(index => int.Parse(index) < typesList.Count)
                    .Select(index => typesList[int.Parse(index)])
                    .ToList()
                : typesList;
        }

        private async Task<IEnumerable<AnimalType>> AskForAnimalTypes()
        {
            var path = AskForFile("Please enter the path to you animals file: ");
            using var reader = new StreamReader(path);
            var types = await reader.ReadToEndAsync();
            using var stringReader = new StringReader(types);
            return _typeParser.ParseTypes(stringReader);
        }

        private async Task<Prices> AskForPrices()
        {
            var path = AskForFile("Please enter the path to the price file: ");
            using var reader = new StreamReader(path);
            var prices = await reader.ReadToEndAsync();
            using var stringReader = new StringReader(prices);
            return _priceParser.ParsePrices(stringReader);
        }

        private IEnumerable<Animal> AskForZoo(IEnumerable<AnimalType> types)
        {
            var path = AskForFile("Please enter the path to the zoo file: ");
            var document = XDocument.Load(path);
            return _animalParser.ParseAnimal(document, types);
        }

        private string AskForFile(string message)
        {
            var path = "";
            var exists = false;
            do
            {
                Console.WriteLine(message);
                path = Console.ReadLine();
                if (!Path.IsPathRooted(path)) path = Path.Combine(Directory.GetCurrentDirectory(), path);

                exists = File.Exists(path);

                if (!exists) Console.WriteLine($"File not found: {path}");
            } while (!exists);

            return path;
        }
    }
}