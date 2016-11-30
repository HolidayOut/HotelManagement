using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayOutClient.Data
{
    public class Account
    {
        public string username { get; set; }
        public string password {  get; set; }
        public int role_ID { get;  set; }

        public Account()
        {
        }

        public Account(string _username, string _password, int _role_ID)
        {
            this.username = _username;
            this.password = _password;
            this.role_ID = _role_ID;
        }
        
        public override string ToString()
        {
            return username + ", " + password + " " + role_ID;
        }
    }
}
