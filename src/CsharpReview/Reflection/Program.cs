using System;
using System.Linq;
using System.Reflection;

namespace Reflection.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var assembly = Assembly.LoadFile(@"C:\Users\UseR\source\Git and GitHub\ASP-.NET-B09-Practice\src\CsharpReview\PrintAll\bin\Debug\net7.0\PrintAll.dll");

            foreach (var type in assembly.GetTypes())
            {
                Console.WriteLine($"Type: {type.Name}");
                Console.WriteLine("============================");
                //var instance = Activator.CreateInstance(type);

                foreach (var field in type.GetFields(BindingFlags.NonPublic |
                    BindingFlags.Instance |
                    BindingFlags.DeclaredOnly))
                {
                    Console.WriteLine($"Field: {field.Name}");
                   // field.SetValue(instance, "Frodo");
                }
                

            }

        }
    }
}
