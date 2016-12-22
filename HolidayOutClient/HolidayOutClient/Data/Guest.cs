using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayOutClient.Data
{
    public class Guest
    {
        public string name { get; set; }
        public string username { get; set; }
        public Guest(string _name, string username)
        {
            name = _name;
            this.username = username;

        }

        public override string ToString()
        {
            return name;
        }
    }
}
