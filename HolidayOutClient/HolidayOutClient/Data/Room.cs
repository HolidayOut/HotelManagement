using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayOutClient.Data
{
    public class Room
    {
        public int id{ get; set; }
        public int roomsize { get; set; }
        public int roomprize { get; set; }

        public Room()
        {
        }
        public Room(int _id, int _Roomsize, int _RoomPrice)
        {
            id = _id;
            roomsize = _Roomsize;
            roomprize = _RoomPrice;
        }

        public override string ToString()
        {
            return id.ToString() + ", " + roomsize.ToString() +" "+ roomprize.ToString();
        }
    }
}
