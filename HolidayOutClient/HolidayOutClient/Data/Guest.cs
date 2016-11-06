using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayOutClient.Data
{
    class Guest
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int RoomId { get; set; }

        public Guest(int _id, string _name, int _roomId)
        {
            ID = _id;
            Name = _name;
            RoomId = _roomId;
        }
    }
}
