namespace ClassLibrary
{
    public class Class1
    {
        private string name;

        public void Print()
        {
            Console.WriteLine("Printing From Print");
        }
        public string GetName() { return this.name; }

        public void PrintName() { Console.WriteLine($"Name set as {this.name}"); }

        public void Print(string name)
        {
            Console.WriteLine($"Name pass: {name}");
        }
        private void PrintPrivate()
        {
            Console.WriteLine("Printing from Private");
        }

        public static void PrintStatic()
        {
            Console.WriteLine("Print From Static method");
        }
        public string Name => name;

        public static string StaticName => "Static property name";

    }
}
