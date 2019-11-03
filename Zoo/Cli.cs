using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;
using Zoo.Parsers;

namespace Zoo
{
    interface ICli
    {
        Task Start();
    }

    public class Cli : ICli
    {
        private readonly IAnimalTypeParser _typeParser;
        private readonly IAnimalParser _animalParser;
        private readonly IPriceParser _priceParser;

        public Cli(IAnimalTypeParser typeParser, IAnimalParser animalParser, IPriceParser priceParser)
        {
            _typeParser = typeParser;
            _animalParser = animalParser;
            _priceParser = priceParser;
        }

        public async Task Start()
        {
            Console.WriteLine("Welcome to our zoo!");
            var animalTypes = await AskForAnimalTypes();
            var prices = await AskForPrices();
            var animals = AskForZoo(animalTypes);
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
                exists = File.Exists(path);
                if (!exists)
                {
                    Console.WriteLine("The file could not be found. Please try again.");
                }
            } while (!exists);

            return path;
        }
    }
}