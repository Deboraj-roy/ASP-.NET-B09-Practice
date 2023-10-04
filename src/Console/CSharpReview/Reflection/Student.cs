using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int RegNo { get; set; }
        private string Phone { get; set; }
        private string sex = "Male/Female";

        public Student(int id, string name, string address, int regno, string phone)
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
    }
}
