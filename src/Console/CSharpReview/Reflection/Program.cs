using Reflection;
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
}