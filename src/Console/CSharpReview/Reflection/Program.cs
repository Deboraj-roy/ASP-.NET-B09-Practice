/*using Reflection;
using System.Reflection;

Student student = new Student(1, "JON", "NL, 4521", 10029, "017013015018019");

//Console.WriteLine(student.GetInfo());

var StudentClassInfo = typeof(Student);
string assemblyname = StudentClassInfo.Assembly.FullName;
Console.WriteLine(assemblyname);

var constructorInfo = StudentClassInfo.GetConstructor(new Type[] { typeof(string) });

Console.WriteLine(constructorInfo);

Console.WriteLine("\n\n    Get Methods       \n\n");
var methods = StudentClassInfo.GetMethods();
foreach (var methodInfo in methods)
{
    Console.WriteLine("Return Type: " + methodInfo.ReturnType + "Method Name: " + methodInfo.Name);
}

// Get Properties
//public only
//var properties = StudentClassInfo.GetProperties();

//private Only
//var properties = StudentClassInfo.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);


//Get Properties all


Console.WriteLine("\n\n    Get Properties       \n\n");

var properties = StudentClassInfo.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
foreach (var propertyInfo in properties)
{
    Console.WriteLine(propertyInfo.Name);
}


Console.WriteLine("\n\n    Get Fields       \n\n");

var getFields = StudentClassInfo.GetFields();
foreach (var getFieldInfo in getFields)
{
    Console.WriteLine(getFieldInfo.Name);
    Console.WriteLine(getFieldInfo.FieldType);
}*/

using System.Reflection;


string dllFilePath = @"C:\Users\UseR\source\Git and GitHub\ASP-.NET-B09-Practice\src\Console\CSharpReview\PrintAll\bin\Debug\net7.0\PrintAll.dll";

try
{
    Assembly assembly = Assembly.LoadFile(dllFilePath);
    // Now, 'assembly' holds a reference to the loaded assembly.
    // You can use 'assembly' to access types and members from the loaded DLL.


    Console.WriteLine(assembly.GetType());

    Console.WriteLine("==================================");

    foreach (var type in assembly.GetTypes())
    {
        Console.WriteLine($"Type: {type.Name}");

        Console.WriteLine("==================================");
        
        var instance = Activator.CreateInstance(type);

        ///Field

        foreach (var field in type.GetFields(BindingFlags.NonPublic |
            BindingFlags.Instance |
            BindingFlags.DeclaredOnly))
        {
            Console.WriteLine($"Field: {field.Name}");
            field.SetValue(instance, "Frodo");
        }
        Console.WriteLine("==================================");


        foreach (var method in type.GetMethods(BindingFlags.Public |
            BindingFlags.NonPublic |
            BindingFlags.Instance |
            BindingFlags.DeclaredOnly).
            Where(m => !m.IsSpecialName))
        {
            Console.WriteLine($"Method: {method.Name}");

            if(method.GetParameters().Length > 0)
            {
                method.Invoke(instance, new[] {"Bilbo"});
            }
            else if(method.ReturnType.Name != "Void")
            {
                var returnedValue = method.Invoke(instance, null);
                Console.WriteLine($"Returned Value from method: {returnedValue}");
            }
            else
            {
                method.Invoke(instance, null);
            }
        }
        Console.WriteLine("==================================");


        foreach (var property in type.GetProperties())
        {
            Console.WriteLine($"Property: {property.Name}");
            var propertyValue = property.GetValue(instance);
            Console.WriteLine($"Property Value: {propertyValue}");
        }

    }

}
catch (Exception ex)
{
    Console.WriteLine($"Error loading assembly: {ex.Message}");
}


// var assembly = Assembly.LoadFrom(@"D:\PrintAll.dll");


