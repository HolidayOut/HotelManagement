using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayOutClient.Data
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string Username { get; set; }
        public string Nachname { get; set; }
        public int id_Role { get; set; }

        public Employee()
        {

        }

        public Employee(int id, string name, DateTime birthdate, string username, string nachname, int id_role)
        {
            ID = id;
            Name = name;
            Birthdate = birthdate;
            Username = username;
            Nachname = nachname;
            id_Role = id_role;
        }
    }
    
}
