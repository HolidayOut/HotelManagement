﻿using HolidayOutClient.Data;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Windows;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace HolidayOutClient
{
    class DB
    {

        private String CS = "User Id = " + "d5b20" + ";Password=" + "d5b" + ";Data Source=" + "212.152.179.117:1521/ora11g;";  //212.152.179.117:1521
        public List<Account> Accounts = new List<Account>();
        public List<Guest> Guests = new List<Guest>();
        public Account GetAccountByUsername(String username, String password)
        {
            Account acc = null;
            WebRequest req = WebRequest.Create(@"http://localhost:18080/HolidayOutServer/webresources/accounts?user="+username+"&pw="+password);

            req.Method = "GET";

            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            if (resp.StatusCode == HttpStatusCode.OK)
            {
                using (Stream respStream = resp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream, Encoding.UTF8);
                    string accJSON = reader.ReadToEnd();
                    acc = Newtonsoft.Json.JsonConvert.DeserializeObject<Account>(accJSON);
                }
            }
            else
            {
                Console.WriteLine(string.Format("Status Code: {0}, Status Description: {1}", resp.StatusCode, resp.StatusDescription));
            }
            return acc;
        }
        
        public List<Stay> LoadStays()
        {
            List<Stay> stays = new List<Stay>();
            WebRequest req = WebRequest.Create(@"http://localhost:18080/HolidayOutServer/webresources/stays");

            req.Method = "GET";

            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            if (resp.StatusCode == HttpStatusCode.OK)
            {
                using (Stream respStream = resp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream, Encoding.UTF8);
                    string accJSON = reader.ReadToEnd();
                    RootStay list = Newtonsoft.Json.JsonConvert.DeserializeObject<RootStay>(accJSON);
                    stays = list.stay;
                    foreach(Stay ss in stays)
                    {
                        MessageBox.Show(ss.ToString());
                    }
                }
            }
            else
            {
                Console.WriteLine(string.Format("Status Code: {0}, Status Description: {1}", resp.StatusCode, resp.StatusDescription));
            }
            return stays;

        }

        public void InsertStay(Guest g, Room r, DateTime? d_in, DateTime? d_out)
        {
            /*var commandText = "insert into stays (id_stays,username,checkin, checkout, room_id) values(STAY_SEQ.nextval,:username,:checkin, :checkout, :room_id)";

            using (OracleConnection connection = new OracleConnection(this.CS))
            using (OracleCommand command = new OracleCommand(commandText, connection))
            {
                command.Parameters.AddWithValue("username", g.username);
                command.Parameters.AddWithValue("checkin", d_in);
                command.Parameters.AddWithValue("checkout", d_in);
                command.Parameters.AddWithValue("room_id", r.ID);
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }*/
           
        }

        public void InsertAccount(string v, string n, string pw, int roleID)
        {
            var commandText = "insert into accounts (username,password,role_id) values(:username,:password,:role_id)";

            using (OracleConnection connection = new OracleConnection(this.CS))
            using (OracleCommand command = new OracleCommand(commandText, connection))
            {
                command.Parameters.AddWithValue("username", GenerateUsername(v, n));
                command.Parameters.AddWithValue("password", pw);
                command.Parameters.AddWithValue("role_id", roleID);
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }
        }

        public void InsertHotelGuest(string v, string n)
        {
            var commandText = "insert into hotelguests (name,username) values(:name,:username)";
            //int c = getAllGuests().Count;
            using (OracleConnection connection = new OracleConnection(this.CS))
            using (OracleCommand command = new OracleCommand(commandText, connection))
            {
                command.Parameters.AddWithValue("name", v + " " + n);
                command.Parameters.AddWithValue("username", GenerateUsername(v, n));
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }
        }


        #region Rooms

        public void updateRoom(int roomIDToUpdate, Room r)
        {
            using (OracleConnection conn = new OracleConnection(this.CS))
            {
                string commandText = "UPDATE Rooms SET ID_Room = " + r.ID + " , Roomsize = " + r.Roomsize + " , Roomprice = " + r.Roomprice + " WHERE ID_Room = " + roomIDToUpdate;
                OracleCommand cmd = new OracleCommand(commandText, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void deleteRoom(int roomIDToDelete)
        {
            using (OracleConnection conn = new OracleConnection(this.CS))
            {
                string commandText = "DELETE FROM Rooms WHERE ID_Room = " + roomIDToDelete;
                OracleCommand cmd = new OracleCommand(commandText, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void addRoom(Room r)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(this.CS))
                {
                    string commandText = "INSERT INTO Rooms (ID_Room, Roomsize, Roomprice) VALUES (" + r.ID + ",'" + r.Roomsize + "','" + r.Roomprice + "')";
                    OracleCommand cmd = new OracleCommand(commandText, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Room getRoomByID(int ID)
        {
            Room r = null;
            string commandText = "SELECT * FROM ROOMS WHERE ID_ROOM = " + ID;
            int id = 0;
            int roomSize = 0;
            int roomPrice = 0;

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
                        roomPrice = Decimal.ToInt32(reader.GetDecimal(2));
                        
                        r = new Room(id, roomSize, roomPrice);
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                }
                reader.Close();
                return r;
            }
        }

        public List<Room> getAllRooms()
        {
            List<Room> allRooms = new List<Room>();
            string commandText = "SELECT * FROM ROOMS ORDER BY ID_ROOM";
            int id = 0;
            int roomSize = 0;
            int roomPrice = 0;

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
                        roomPrice = Decimal.ToInt32(reader.GetDecimal(2));

                        Room r = new Room(id, roomSize, roomPrice);

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

        #endregion

        #region RoleAndPermission

        public Role GetRoleByUsername(string username)
        {
            Role r = new Role();
            string commandText = "SELECT ID_Role, Rolename, ID_Permission, Permissionname FROM Accounts " +
                                    "INNER JOIN Roles ON Accounts.Role_ID = Roles.ID_Role " +
                                        "INNER JOIN RoleHasPermissions ON RoleHasPermissions.KEY_ROLE = Roles.ID_Role " +
                                            "INNER JOIN permissions ON ROLEHASPERMISSIONS.KEY_PERMISSIONS = Roles.ID_Role " +
                                                "WHERE username = '" + username + "'";
            int role_ID_Role;
            string role_Rolename;
            int role_ID_Permission;
            string role_Permissionname;

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
                        role_ID_Role = decimal.ToInt32(reader.GetDecimal(0));
                        role_Rolename = reader.GetString(1);
                        role_ID_Permission = decimal.ToInt32(reader.GetDecimal(2));
                        role_Permissionname = reader.GetString(3);


                        if (isFirst)
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
                    catch (Exception e)
                    {
                        throw;
                    }
                }
                reader.Close();
                return r;
            }
        }
        public List<Role> GetAllRoles()
        {
            List<Role> collRoles = new List<Role>();
            int role_ID_Role;
            String role_Rolename;

            string commandText = "SELECT * FROM Roles";

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
                    }
                    catch (Exception e)
                    {
                        throw;
                    }

                    collRoles.Add(new Role(role_ID_Role, role_Rolename));
                }
                reader.Close();
                return collRoles;
            }
        }

        public List<Permission> GetAllPermissionsByRole(int ID_Role)
        {
            List<Permission> collPermission = new List<Permission>();
            int permission_ID_Permission;
            String permission_name;

            string commandText = "SELECT ID_Permission, Permissionname " +
                                    "FROM rolehaspermissions " +
                                    "INNER JOIN roles ON roles.ID_ROLE = rolehaspermissions.KEY_ROLE " +
                                    "INNER JOIN permissions ON permissions.ID_PERMISSION = rolehaspermissions.KEY_PERMISSIONS " +
                                    "WHERE ID_ROLE = " + ID_Role;

            using (OracleConnection conn = new OracleConnection(this.CS))
            {
                OracleCommand cmd = new OracleCommand(commandText, conn);
                conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    try
                    {
                        permission_ID_Permission = Decimal.ToInt32(reader.GetDecimal(0));
                        permission_name = reader.GetString(1);
                    }
                    catch (Exception e)
                    {
                        throw;
                    }

                    collPermission.Add(new Permission(permission_ID_Permission, permission_name));
                }
                reader.Close();
                return collPermission;
            }
        }

        public void addRole(String roleName)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(this.CS))
                {
                    string commandText = "INSERT INTO Roles (ID_Role, rolename) VALUES (sequenceIncrementIDRole.nextVal, '"+ roleName +"')";
                    OracleCommand cmd = new OracleCommand(commandText, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void removeRole(int ID_Role)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(this.CS))
                {
                    string commandText = "DELETE FROM Roles WHERE ID_Role = " + ID_Role;
                    OracleCommand cmd = new OracleCommand(commandText, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Permission> getAllPermissions()
        {
            List<Permission> collPermission = new List<Permission>();
            int permission_ID_Permission;
            String permission_Permission;

            string commandText = "SELECT * FROM Permissions";

            using (OracleConnection conn = new OracleConnection(this.CS))
            {
                OracleCommand cmd = new OracleCommand(commandText, conn);
                conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    try
                    {
                        permission_ID_Permission = Decimal.ToInt32(reader.GetDecimal(0));
                        permission_Permission = reader.GetString(1);
                    }
                    catch (Exception e)
                    {
                        throw;
                    }

                    collPermission.Add(new Permission(permission_ID_Permission, permission_Permission));
                }
                reader.Close();
                return collPermission;
            }
        }

        #endregion

        private string GenerateUsername(string v, string n)
        {
            return v + n[0];
        }

        #region Guests
        public List<Guest> getAllGuests()
        {
            List<Guest> allGuests = new List<Guest>();
            string commandText = "SELECT * FROM HOTELGUESTS";
            string username = null;
            string password = null;
            int id = 0;
            int roomId;
            string name = null;


            using (OracleConnection conn = new OracleConnection(this.CS))
            {
                OracleCommand cmd = new OracleCommand(commandText, conn);
                conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    try
                    {
                        name = reader.GetString(0);
                        username = reader.GetString(1);


                        Guest g = new Guest(name, username);
                        allGuests.Add(g);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
                reader.Close();
                return allGuests;
            }
        }

        public Role GetRoleByID(int ID_Role)
        {
            Role r = new Data.Role();
            int role_ID_Role;
            String role_Rolename;

            string commandText = "SELECT * FROM Roles WHERE ID_Role = " + ID_Role;

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
                    }
                    catch (Exception e)
                    {
                        throw;
                    }

                    r = new Role(role_ID_Role, role_Rolename);
                }
                reader.Close();
                return r;
            }
        }

        public void removePermissionFromRole(int ID_Role, int ID_Permission)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(this.CS))
                {
                    string commandText = "DELETE FROM RoleHasPermissions WHERE key_Role = " + ID_Role + " AND key_Permissions = " + ID_Permission;
                    OracleCommand cmd = new OracleCommand(commandText, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void addPermissionToRole(int ID_Role, int ID_Permission)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(this.CS))
                {
                    string commandText = "INSERT INTO RoleHasPermissions (key_role, key_permissions) VALUES ( " + ID_Role + ", " + ID_Permission + ")";
                    OracleCommand cmd = new OracleCommand(commandText, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
