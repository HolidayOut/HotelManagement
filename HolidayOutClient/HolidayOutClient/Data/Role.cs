using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayOutClient.Data
{
    public class Role
    {
        public int ID_Role { get; set; }
        public string Name { get; set; }

        public List<Permission> collPermissions { get; }

        public Role ()
        {
            this.collPermissions = new List<Permission>();
        }

        public Role (int _ID_Role, string _Name)
        {
            this.ID_Role = _ID_Role;
            this.Name = _Name;
            this.collPermissions = new List<Permission>();
        }

        public void AddPermission(Permission p)
        {
            collPermissions.Add(p);
        }

        public override string ToString()
        {
            return ID_Role + "";
        }

    }
}
