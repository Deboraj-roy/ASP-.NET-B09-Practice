using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class Room
    {
        private int roomNum { get; set; }
        public Room(int roomNum) => this.roomNum = roomNum;
        public string RoomNumber { get; set; }
        public List<Window> Windows { get; set; }
    }
}
