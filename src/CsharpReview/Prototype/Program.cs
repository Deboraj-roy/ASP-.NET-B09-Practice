// See https://aka.ms/new-console-template for more information
using Prototype;

Console.WriteLine("Prototype, World!");

Product product = new Product();
product.Name = "Camera";
product.Price = 100;

Product product2 = (Product)product.Clone();

if (product != product2)
    Console.WriteLine("Different object");
Console.WriteLine($"Product 1 name:{product.Name}, Product 1 price:{product.Price}");
Console.WriteLine($"Product 2 name:{product2.Name}, Product 2 price:{product2.Price}");