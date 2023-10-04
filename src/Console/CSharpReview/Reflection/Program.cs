using Reflection;

Student student = new Student(1, "JON", "NL, 4521", 10029, "017013015018019");

//Console.WriteLine(student.GetInfo());

var StudentClassInfo = typeof(Student);
string assemblyname = StudentClassInfo.Assembly.FullName;
Console.WriteLine(assemblyname);

var constructorInfo = StudentClassInfo.GetConstructor(new Type[] { typeof(string) });

Console.WriteLine(constructorInfo);

var methods = StudentClassInfo.GetMethods();
foreach (var methodInfo in methods)
{
    Console.WriteLine("Return Type: " + methodInfo.ReturnType + "Method Name: " + methodInfo.Name);
}