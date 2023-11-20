// See https://aka.ms/new-console-template for more information

using Delegates;


Console.WriteLine("Delegates, World!");

BubbleSort<int> bubbleSort = new();

var result = bubbleSort.Sort(new int[] { 2, 6, 9, 0, 3, 5, 6, 8, 11, 2, 3, 4, 5 }, Check);

foreach (var item in result)
{
    Console.Write(item);
    Console.Write(',') ;
}
Console.WriteLine();

bool Check(int a, int b) => a < b;



Person[] persons = new Person[]
{
    new Person(){ Name = "jalaluddin", Age = 26 },
    new Person(){ Name = "tareq", Age = 39 },
    new Person(){ Name = "tareq", Age = 14 }
};

BubbleSort<Person> bubbleSort1 = new();
var result1 = bubbleSort1.Sort(persons, Compare1);

bool Compare1(Person a, Person b)
{
    if (a.Name == b.Name)
    {
        return a.Age < b.Age;
    }
    else
        return a.Name.CompareTo(b.Name) > 0;
}

foreach (var item in result1)
{
    Console.WriteLine($"Name: {item.Name}, Age : {item.Age}");
}