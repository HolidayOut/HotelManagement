using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayOutClient.Data
{
    class Account
    {
        private String username { get; set; }
        private String password { get; set; }
        private int Role_ID { get; set; }

        public Account(String _username, String _password, int _role_ID)
        {
            this.username = _username;
            this.password = _password;
            this.Role_ID = _role_ID;
        }

        public Account()
        {
        }
    }
}
