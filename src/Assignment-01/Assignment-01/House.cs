using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class House
    {
        public Cars Car {  get; set; }
        public Room room {  get; set; }
        private Builder BuilderInformation { get; set; }
        public House(Builder builderInformation) => BuilderInformation = builderInformation;
        public static string? Name { get; set; }
        internal string[]? HouseNames { get; set; }
        public House[]? houses { get; set; }
        public List<Room>? Rooms { get; set; }
    }
}
