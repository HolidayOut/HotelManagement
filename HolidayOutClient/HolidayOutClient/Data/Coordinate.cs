using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayOutClient.Data
{
    class Coordinate
    {
        public Coordinate(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public int x { get; set; }
        public int y { get; set; }
    }
}
