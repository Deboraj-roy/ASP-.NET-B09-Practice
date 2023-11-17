// See https://aka.ms/new-console-template for more information
using Singleton;

Console.WriteLine("Singleton, Logger!");

Logger logger1 = Logger.CreateLogger();
Logger logger2 = Logger.CreateLogger();

if (logger1 != logger2)
    Console.WriteLine("Same Logger");
