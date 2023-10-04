namespace PrintAll
{
    public class CustomPrint
    {
        private string name;

        public void Print()
        {
            Console.WriteLine("Printing From Print");
        }

        public string GetName()
        {
            return name;
        }

        public void PrintName()
        {
            Console.WriteLine($"Name set as {name}");
        }

        public void Print(string name)
        {
            Console.WriteLine($"Name passed: {name}");
        }

        private void PrintPrivate()
        {
            Console.WriteLine("Print from private");
        }

        public string Name => name;

        public static string StaticName => "Static property name";

    }
}
