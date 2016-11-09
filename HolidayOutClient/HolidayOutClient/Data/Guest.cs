using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayOutClient.Data
{
    class Guest
    {
        public string Name { get; set; }
        public int RoomId { get; set; }
        public Guest(string _name, int _roomId)
        {
            Name = _name;
            RoomId = _roomId;
        }
    }
}
