using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayOutClient.Data
{
    public class Guest
    {
        public string Name { get; set; }
        public int RoomId { get; set; }
        public string username { get; set; }
        public Guest(string _name, int _roomId, string username)
        {
            Name = _name;
            RoomId = _roomId;
            this.username = username;

        }

        public override string ToString()
        {
            return Name;
        }
    }
}
