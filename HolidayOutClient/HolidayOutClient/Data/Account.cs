using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayOutClient.Data
{
    public class Account
    {
        public String username { get; private set; }
        public String password {  get; private set; }
        public int Role_ID { get; private set; }

        public Account()
        {
        }

        public Account(String _username, String _password, int _role_ID)
        {
            this.username = _username;
            this.password = _password;
            this.Role_ID = _role_ID;
        }
        
        public override string ToString()
        {
            return username;
        }
    }
}
