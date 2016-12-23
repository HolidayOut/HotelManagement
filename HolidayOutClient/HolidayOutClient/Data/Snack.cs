using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayOutClient.Data
{
    class Snack
    {
        public int ID { get; set; }
        public int snacktype { get; set; }
        public string snackname { get; set; }
        public decimal price { get; set; }


        public Snack(int id, int type, string name, decimal _price)
        {
            ID = id;
            snacktype = type;
            snackname = name;
            price = _price;
        }

        public Snack()
        { }
    }
}
