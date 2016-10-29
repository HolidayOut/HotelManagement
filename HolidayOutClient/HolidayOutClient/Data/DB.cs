using HolidayOutClient.Data;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
namespace HolidayOutClient
{
    class DB
    {
       
        private String CS = "USER ID = " + "d5b20" + ";PASSWORD=" + "d5b" + ";DATA SOURCE=" + "212.152.179.117:1521/ora11g;";
        public Account GetAccountByUsername(String username)
        {
            Account acc = null;
            string commandText = "SELECT * FROM ACCOUNTs WHERE USERNAME = " + "'"+username+"'";

            using (OracleConnection conn = new OracleConnection(this.CS))
            {
                OracleCommand cmd = new OracleCommand(commandText, conn);
                conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();

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
