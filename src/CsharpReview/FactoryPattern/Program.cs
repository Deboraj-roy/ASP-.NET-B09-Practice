// See https://aka.ms/new-console-template for more information
using FactoryPattern;

Console.WriteLine("Factory Pattern, World!");

CarFactory factory = new BMWFactory();
ICar car = factory.Create("Red", "XO20N9", 2100);
