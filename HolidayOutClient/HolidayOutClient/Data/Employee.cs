using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayOutClient.Data
{
    public class Employee
    {
        public string name { get; set; }
        public string birthdate { get; set; }
        public string nachname { get; set; }
        public string username { get; set; }

        public Employee()
        {

        }

        public Employee(string name, string birthdate, string username, string nachname)
        {
            this.name = name;
            this.birthdate = birthdate;
            this.username = username;
            this.nachname = nachname;
        }
    }
    
}
