using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintAll
{ 
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int RegNo { get; set; }
        private string Phone { get; set; }
        private string sex = "Male/Female";
        private string name;

        public Person(int id, string name, string address, int regno, string phone)
        {
            Id = id;
            Name = name;
            Address = address;
            RegNo = regno;
            Phone = phone;

        }

        public string GetInfo()
        {
            return "ID: " + Id + " Name: " + Name + " Address: " + Address + " Registration Number: " + RegNo;

        }
        public string GetPhone()
        {
            return Phone;
        }
        private void GetSex()
        {
            Console.WriteLine(sex);
        }
        public void GetAddressTest() { }

        public void Print()
        {
            Console.WriteLine("Printing From Print");
        }

        public string GetName()
        {
            return this.name;
        }

        public void PrintName()
        {
            Console.WriteLine($"Name set as {this.name}");
        }

        public void Print(string name)
        {
            Console.WriteLine($"Name passed: {name}");
        }

        private void PrintPrivate()
        {
            Console.WriteLine("Print from private");
        }


        public static string StaticName => "Static property name";

    }
}
