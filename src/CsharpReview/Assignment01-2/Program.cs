using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var house = new House
        {
            Address = "123 Main St",
            Rooms = new List<string> { "kitchen", "living room" },
            YearBuilt = 2005
        };

        var building = new Building
        {
            Address = "",
            Rooms = new List<string>()
        };

        SimpleMapper mapper = new SimpleMapper();
        mapper.Copy(house, building);

        Console.WriteLine(building);

        //SimpleMapper(house, building);

        Console.WriteLine("House Properties:");
        PrintObjectProperties(house);

        Console.WriteLine();

        Console.WriteLine("Building Properties:");
        PrintObjectProperties(building);

        Console.ReadLine();
    }
/*
    static void SimpleMapper(object source, object destination)
    {
        var sourceProps = source.GetType().GetProperties();
        var destProps = destination.GetType().GetProperties();

        foreach (var sourceProp in sourceProps)
        {
            foreach (var destProp in destProps)
            {
                if (sourceProp.Name == destProp.Name && sourceProp.PropertyType == destProp.PropertyType)
                {
                    if (sourceProp.PropertyType.IsArray)
                    {
                        var sourceArray = (Array)sourceProp.GetValue(source);
                        var destArray = Array.CreateInstance(destProp.PropertyType.GetElementType(), sourceArray.Length);

                        for (int i = 0; i < sourceArray.Length; i++)
                        {
                            var newObj = Activator.CreateInstance(destProp.PropertyType.GetElementType());
                            SimpleMapper(sourceArray.GetValue(i), newObj);
                            destArray.SetValue(newObj, i);
                        }

                        destProp.SetValue(destination, destArray);
                    }
                    else
                    {
                        destProp.SetValue(destination, sourceProp.GetValue(source));
                    }
                    break;
                }
            }
        }
    }*/


        

static void PrintObjectProperties(object obj)
    {
        var props = obj.GetType().GetProperties();

        foreach (var prop in props)
        {
            var value = prop.GetValue(obj);
            Console.WriteLine($"{prop.Name}: {value}");
        }
    }
}

class House
{
    public string Address { get; set; }
    public List<string> Rooms { get; set; }
    public int YearBuilt { get; set; }
}

class Building
{
    public string Address { get; set; }
    public List<string> Rooms { get; set; }

    public override string ToString()
    {
        return $"Address: {Address}, Rooms: {string.Join(", ", Rooms)}";
    }
}

public class SimpleMapper
{
    public void Copy(object source, object destination)
    {
        if (source == null || destination == null || source.GetType() != destination.GetType())
        {
            throw new ArgumentNullException("Source and destination objects cannot be null, and their types must be the same.");
        }

        CopyProperties(source, destination);
    }

    private void CopyProperties(object source, object destination)
    {
        var sourceProps = source.GetType().GetProperties();
        var destProps = destination.GetType().GetProperties();

        foreach (var sourceProp in sourceProps)
        {
            var destProp = destProps.FirstOrDefault(p => p.Name == sourceProp.Name && p.PropertyType == sourceProp.PropertyType);

            var sourceValue = sourceProp.GetValue(source);
            var destinationValue = destProp.GetValue(source);
            if (destProp != null)
            {
                if (sourceProp.PropertyType.IsArray || sourceProp.PropertyType.GetInterface("IEnumerable") != null)
                {
                    // Handle lists and arrays
                    IEnumerable sourceList = (IEnumerable)sourceValue;
                    IEnumerable destinationList = (IEnumerable)destinationValue;

                    IEnumerator sourceEnumerator = sourceList.GetEnumerator();
                    IEnumerator destinationEnumerator = destinationList.GetEnumerator();

                    while (sourceEnumerator.MoveNext() && destinationEnumerator.MoveNext())
                    {
                        //Recursively Call nested objects
                        CopyProperties(sourceEnumerator.Current, destinationEnumerator.Current);
                    }
                }
                else if (sourceProp.PropertyType.IsPrimitive || sourceProp.PropertyType == typeof(string))
                {
                    destProp.SetValue(destination, sourceProp.GetValue(source));
                }
                else
                {
                    var sourceValue1 = sourceProp.GetValue(source);
                    var destValue1 = destProp.GetValue(destination) ?? Activator.CreateInstance(destProp.PropertyType);
                    CopyProperties(sourceValue1, destValue1);
                    destProp.SetValue(destination, destValue1);
                }
            }
        }
    }
}
