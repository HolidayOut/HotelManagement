using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayOutClient.Data
{
    class Room
    {
        public int ID { get; set; }
        public int Roomsize { get; set; }
        public int Roomprice { get; set; }

        public Room()
        {
        }
        public Room(int _id, int _Roomsize, int _RoomPrice)
        {
            ID = _id;
            Roomsize = _Roomsize;
            Roomprice = _RoomPrice;
        }

        public override string ToString()
        {
            return ID + "";
        }
    }
}
