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
       
        private String CS = "USER ID =" + "d5b20" + ";PASSWORD=" + "d5b" + ";DATA SOURCE= aphrodite4:1521/ora11g;";
        private String ex;
        private String account_username = null;
        private String account_password = null;
        private int account_role_id = 0;
        public Account GetAccountByUsername(String username, String Password)
        {
            Account acc = null;
            string commandText = "SELECT * FROM ACCOUNTs WHERE USERNAME = " + "'"+username+"'" + "AND Password='" + Password+ "'";

            using (OracleConnection conn = new OracleConnection(this.CS))
            {
                OracleCommand cmd = new OracleCommand(commandText, conn);
                conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    try
                    {
                        account_username = reader.GetString(0);
                        account_password = reader.GetString(1);
                        account_role_id = Decimal.ToInt32(reader.GetDecimal(2));
                    }
                    catch (Exception e)
                    {
                        ex = e.Message;
                        throw;
                    }

                    acc = new Account(account_username, account_password, account_role_id);
                }
                reader.Close();
                return acc;
            }
        }
    }
}
