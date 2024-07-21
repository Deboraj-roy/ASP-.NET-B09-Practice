using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class Building
    {
        public Room room { get; set; }
        private Builder? BuilderInformation { get; set; }
        public static string? Name { get; set; }
        public Cars Car { get; set; }
        internal string[]? HouseNames { get; set; }
        protected House[]? houses { get; set; }
        public string? BuildingNumber { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
