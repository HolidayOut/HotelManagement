using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayOutClient.Data
{
    class Meal
    {
        public string Name { get; set; }
        public DateTime time { get; set; }

        public Meal(string _name, DateTime _time)
        {
            Name = _name;
            time = _time;
        }
    }
}
