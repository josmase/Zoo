﻿using System;
using Microsoft.Extensions.DependencyInjection;
using Zoo.Parsers;

namespace Zoo
{
    internal class Program
    {
        private static IServiceProvider _serviceProvider;

        private static void Main(string[] args)
        {
            RegisterServices();
            var cli = _serviceProvider.GetService<ICli>();
            cli.Start().Wait();
            DisposeServices();
        }

        private static void RegisterServices()
        {
            var collection = new ServiceCollection()
                .AddSingleton<ICli, Cli>()
                .AddSingleton<IPriceParser, PriceParser>()
                .AddSingleton<IAnimalTypeParser, AnimalTypeParser>()
                .AddSingleton<IAnimalParser, AnimalParser>();
            _serviceProvider = collection.BuildServiceProvider();
        }

        private static void DisposeServices()
        {
            if (_serviceProvider is IDisposable disposable) disposable.Dispose();
        }
    }
}