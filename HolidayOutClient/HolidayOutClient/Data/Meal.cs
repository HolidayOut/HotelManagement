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
        public DateTime Time { get; set; }
        public int MealType { get; set; }
        public decimal Price { get; set; }

        public Meal(string _name, DateTime _time, int type, decimal pr)
        {
            Name = _name;
            Time = _time;
            MealType = type;
            Price = pr;
        }

        public Meal(string _name, DateTime _time)
        {
            Name = _name;
            Time = _time;
            MealType = 0;
            Price = 0;
        }
    }
}
