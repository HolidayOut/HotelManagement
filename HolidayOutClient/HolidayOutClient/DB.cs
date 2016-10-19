using HolidayOutClient.Data;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayOutClient
{
    class DB
    {
        private String ConnectionString = "PROVIDER=OraOLEDB.Oracle; OLEDB.NET= True; DATA SOURCE=aphrodite4:1521/ora11g;USER ID=D5B20; PASSWORD=D5B";

        public Account GetAccountByUsername(String username)
        {
            Account acc = null;
            string commandText = "SELECT * FROM ACCOUNTs WHERE USERNAME = " + username;

            using (OleDbConnection conn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand(commandText, conn);
                conn.Open();
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    String account_username = reader.GetString(0);
                    String account_password = reader.GetString(1);
                    int account_role_id = Decimal.ToInt32(reader.GetDecimal(2));

                    acc = new Account(account_username, account_password, account_role_id);
                }
                reader.Close();
                return acc;
            }
        }
    }
}
