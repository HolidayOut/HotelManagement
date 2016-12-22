using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayOutClient.Data
{
    public class Meal
    {
        public int id { get; set; }
        public string name { get; set; }
        public string time { get; set; }
        public int mealType { get; set; }
        public decimal price { get; set; }

        public Meal(int id,string _name, string _time, int type, decimal pr)
        {
            id = id;
            name = _name;
            time = _time;
            mealType = type;
            price = pr;
        }

        public Meal(string _name, string _time)
        {
            name = _name;
            time = _time;
            mealType = 0;
            price = 0;
        }

        public Meal()
        {
        }
    }
}
