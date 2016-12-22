using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayOutClient.Data
{
    public class Permission
    {
        public int id_permission { get; set; }
        public string Name { get; set; }

        public Permission()
        {
        }

        public Permission(int _ID_Permission, string _Name)
        {
            this.id_permission = _ID_Permission;
            this.Name = _Name;
        }

        public override string ToString()
        {
            return id_permission + "";
        }
    }
}
