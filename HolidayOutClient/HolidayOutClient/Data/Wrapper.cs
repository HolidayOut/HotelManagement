using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayOutClient.Data
{
    public class Wrapper
    {
        public int Id_role { get; set; }
        public int Id_permission { get; set; }

        public Wrapper()
        {
        }
        public Wrapper(int id, int id2)
        {
            Id_role = id;
            Id_permission = id2;
        }
    }
}
