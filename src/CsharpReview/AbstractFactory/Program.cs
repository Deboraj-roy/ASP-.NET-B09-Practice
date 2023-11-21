// See https://aka.ms/new-console-template for more information
using AbstractFactory;
using AbstractFactory.BMW;

Console.WriteLine("Abstract Factory Pattern, World!");
CarFactory factory = new BMWFactory();
IEngine engine = factory.CreateEngine();
ITire tire = factory.CreateTire();
IHeadLight headLight = factory.CreateHeadLight();