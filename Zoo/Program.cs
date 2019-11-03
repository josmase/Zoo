using System;
using Microsoft.Extensions.DependencyInjection;
using Zoo.Parsers;

namespace Zoo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DiSetup();
        }

        private static void DiSetup()
        {
            var serviceProvider = new ServiceCollection().AddSingleton<IPriceParser, PriceParser>();
        }
    }
}