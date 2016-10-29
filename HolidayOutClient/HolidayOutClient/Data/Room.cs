using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayOutClient.Data
{
    class Room
    {
        public int id { get; set; }
        public int Roomsize { get; set; }
        public int Roomprize { get; set; }

        public Room(int _id, int _Roomsize, int _RoomPrize)
        {
            id = _id;
            Roomsize = _Roomsize;
            Roomprize = _RoomPrize;
        }
    }
}
