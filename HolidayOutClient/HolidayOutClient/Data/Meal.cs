using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayOutClient.Data
{
    public class Meal
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public int MealType { get; set; }
        public decimal Price { get; set; }

        public Meal(int id,string _name, DateTime _time, int type, decimal pr)
        {
            ID = id;
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

        public Meal()
        {
        }
    }
}
