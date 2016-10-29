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
       
        private String CS = "User Id = " + "d5b20" + ";Password=" + "d5b" + ";Data Source=" + "212.152.179.117:1521/ora11g;";
        public Account GetAccountByUsername(String username, String password)
        {
            Account acc = null;
            string commandText = "SELECT * FROM ACCOUNTs WHERE USERNAME = " + "'"+username+"'" + "AND Password='" + password+ "'";
            String account_username;
            String account_password;
            int account_role_id;

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
                        throw;
                    }

                    acc = new Account(account_username, account_password, account_role_id);
                }
                reader.Close();
                return acc;
            }
        }

        public Role GetRoleByUsername(String username)
        {
            Role r = new Role();
            string commandText = "SELECT ID_Role, Rolename, ID_Permission, Permissionname FROM Accounts " +
                                    "INNER JOIN Roles ON Accounts.Role_ID = Roles.ID_Role " +
                                        "INNER JOIN RoleHasPermissions ON RoleHasPermissions.KEY_ROLE = Roles.ID_Role " +
                                            "INNER JOIN permissions ON ROLEHASPERMISSIONS.KEY_PERMISSIONS = Roles.ID_Role " +
                                                "WHERE username = '" + username + "'";
            int role_ID_Role;
            String role_Rolename;
            int role_ID_Permission;
            String role_Permissionname;

            bool isFirst = true;

            using (OracleConnection conn = new OracleConnection(this.CS))
            {
                OracleCommand cmd = new OracleCommand(commandText, conn);
                conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    try
                    {
                        role_ID_Role = Decimal.ToInt32(reader.GetDecimal(0));
                        role_Rolename = reader.GetString(1);
                        role_ID_Permission = Decimal.ToInt32(reader.GetDecimal(2));
                        role_Permissionname = reader.GetString(3);
                    }
                    catch (Exception e)
                    {
                        throw;
                    }

                    if(isFirst)
                    {
                        r.ID_Role = role_ID_Role;
                        r.Name = role_Rolename;
                        r.AddPermission(new Permission(role_ID_Permission, role_Permissionname));
                        isFirst = false;
                    }
                    else
                    {
                        r.AddPermission(new Permission(role_ID_Permission, role_Permissionname));
                    }
                }
                reader.Close();
                return r;
            }
        }

        public List<Room> getAllRooms()
        {
            List<Room> allRooms = new List<Room>();
            string commandText = "SELECT * FROM ROOMS";
            int id = 0;
            int roomSize = 0;
            int roomPrize = 0;

            using (OracleConnection conn = new OracleConnection(this.CS))
            {
                OracleCommand cmd = new OracleCommand(commandText, conn);
                conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    try
                    {
                        id = Decimal.ToInt32(reader.GetDecimal(0));
                        roomSize = Decimal.ToInt32(reader.GetDecimal(1));
                        roomPrize = Decimal.ToInt32(reader.GetDecimal(2));

                        Room r = new Room(id, roomSize, roomPrize);

                        allRooms.Add(r);
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                }
                reader.Close();
                return allRooms;
            }
        }
    }
}
