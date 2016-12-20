using HolidayOutClient.Data;
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
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Http;
using System.Xml.Serialization;
using System.Xml;
using System.Globalization;

namespace HolidayOutClient
{
    class DB
    {

        private String CS = "User Id = " + "d5b20" + ";Password=" + "d5b" + ";Data Source=" + "212.152.179.117:1521/ora11g;";  //212.152.179.117:1521
        public List<Account> Accounts = new List<Account>();
        public List<Guest> Guests = new List<Guest>();
        public Account GetAccountByUsername(String username, String password)
        {
            Account acc = new Account(username, password, -2);

            WebRequest request = WebRequest.Create(@"http://localhost:18080/HolidayOutServer/webresources/validateacc");
            request.Method = "POST";

            string postData = JsonConvert.SerializeObject(acc);
            MessageBox.Show(postData);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            Account ret = JsonConvert.DeserializeObject<Account>(responseFromServer);
            return ret;

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
                    var des = JsonConvert.DeserializeObject<List<Stay>>(accJSON);
                    stays = des;
                }
            }
            else
            {
                MessageBox.Show(string.Format("Status Code: {0}, Status Description: {1}", resp.StatusCode, resp.StatusDescription));
            }
            return stays;

        }


        public List<Meal> LoadMeals()
        {
            return new List<Meal>()
            {
                new Data.Meal("test", DateTime.Now),
                new Data.Meal("test1", DateTime.Now),
                new Data.Meal("test2", DateTime.Now)
            };


            List<Meal> meals = new List<Meal>();
            WebRequest req = WebRequest.Create(@"http://localhost:18080/HolidayOutServer/webresources/meals");

            req.Method = "GET";

            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            if (resp.StatusCode == HttpStatusCode.OK)
            {
                using (Stream respStream = resp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream, Encoding.UTF8);
                    string accJSON = reader.ReadToEnd();
                    meals = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Meal>>(accJSON);
                }
            }
            else
            {
                Console.WriteLine(string.Format("Status Code: {0}, Status Description: {1}", resp.StatusCode, resp.StatusDescription));
            }
            return meals;

        }

        public void InsertStay(Guest g, Room r, DateTime? d_in, DateTime? d_out)
        {
            Stay acc = new Stay(-2, g.username, d_in.Value.ToString("dd.MMM.yyyy"), d_out.Value.ToString("dd.MMM.yyyy"), r.ID);
            MessageBox.Show(acc.checkin.ToString());
            WebRequest request = WebRequest.Create(@"http://localhost:18080/HolidayOutServer/webresources/stays");
            request.Method = "POST";

            string postData = JsonConvert.SerializeObject(acc);
            MessageBox.Show(postData);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
        }


        public void InsertAccount(string v, string n, string pw, int roleID)
        {
            Account acc = new Account(GenerateUsername(v, n), pw, roleID);
            WebRequest request = WebRequest.Create(@"http://localhost:18080/HolidayOutServer/webresources/accounts");
            request.Method = "POST";

            string postData = JsonConvert.SerializeObject(acc);
            MessageBox.Show(postData);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

        }

        public void InsertHotelGuest(string v, string n)
        {
            Guest gu = new Guest(v + " " + n, GenerateUsername(v, n));
            WebRequest request = WebRequest.Create(@"http://localhost:18080/HolidayOutServer/webresources/guests");
            request.Method = "POST";

            string postData = JsonConvert.SerializeObject(gu);
            MessageBox.Show(postData);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
        }
        

        #region Rooms

        public void updateRoom(int roomIDToUpdate, Room r)
        {
            WebRequest request = WebRequest.Create(@"http://localhost:18080/HolidayOutServer/webresources/rooms");
            request.Method = "PUT";

            string postData = JsonConvert.SerializeObject(r);
            MessageBox.Show(postData);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

        }

        public void deleteRoom(int roomIDToDelete)
        {
            WebRequest request = WebRequest.Create(@"http://localhost:18080/HolidayOutServer/webresources/rooms");
            request.Method = "DELETE";

            string postData = JsonConvert.SerializeObject(roomIDToDelete);
            MessageBox.Show(postData);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

        }

        public void addRoom(Room r)
        {
            WebRequest request = WebRequest.Create(@"http://localhost:18080/HolidayOutServer/webresources/rooms");
            request.Method = "POST";

            string postData = JsonConvert.SerializeObject(r);
            MessageBox.Show(postData);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

        }

        public Room getRoomByID(int ID)
        {
            WebRequest req = WebRequest.Create(@"http://localhost:18080/HolidayOutServer/webresources/rooms?id="+ID);
            req.Method = "GET";
            Room des = null;
            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            if (resp.StatusCode == HttpStatusCode.OK)
            {
                using (Stream respStream = resp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream, Encoding.UTF8);
                    string accJSON = reader.ReadToEnd();
                    des = JsonConvert.DeserializeObject<Room>(accJSON);
                    
                }
            }
            else
            {
                MessageBox.Show(string.Format("Status Code: {0}, Status Description: {1}", resp.StatusCode, resp.StatusDescription));
            }
            return des;

        }

        public List<Room> getAllRooms()
        {
            List<Room> rooms = new List<Room>();
            WebRequest req = WebRequest.Create(@"http://localhost:18080/HolidayOutServer/webresources/allrooms");
            
            req.Method = "GET";

            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            if (resp.StatusCode == HttpStatusCode.OK)
            {
                using (Stream respStream = resp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream, Encoding.UTF8);
                    string accJSON = reader.ReadToEnd();
                    var des = JsonConvert.DeserializeObject<List<Room>>(accJSON);
                    rooms = des;
                }
            }
            else
            {
                MessageBox.Show(string.Format("Status Code: {0}, Status Description: {1}", resp.StatusCode, resp.StatusDescription));
            }
            return rooms;
        }

        #endregion

        #region RoleAndPermission

        public Role GetRoleByUsername(string username)
        {
            WebRequest req = WebRequest.Create(@"http://localhost:18080/HolidayOutServer/webresources/roles?u=" + username);
            req.Method = "GET";
            Role des = null;
            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            if (resp.StatusCode == HttpStatusCode.OK)
            {
                using (Stream respStream = resp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream, Encoding.UTF8);
                    string accJSON = reader.ReadToEnd();
                    des = JsonConvert.DeserializeObject<Role>(accJSON);
                }
            }
            else
            {
                MessageBox.Show(string.Format("Status Code: {0}, Status Description: {1}", resp.StatusCode, resp.StatusDescription));
            }
            return des;


        }
        public List<Role> GetAllRoles()
        {
            List<Role> roles = new List<Role>();
            WebRequest req = WebRequest.Create(@"http://localhost:18080/HolidayOutServer/webresources/allroles");

            req.Method = "GET";

            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            if (resp.StatusCode == HttpStatusCode.OK)
            {
                using (Stream respStream = resp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream, Encoding.UTF8);
                    string accJSON = reader.ReadToEnd();
                    var des = JsonConvert.DeserializeObject<List<Role>>(accJSON);
                    roles = des;
                }
            }
            else
            {
                MessageBox.Show(string.Format("Status Code: {0}, Status Description: {1}", resp.StatusCode, resp.StatusDescription));
            }
            return roles;
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
                    string commandText = "INSERT INTO Roles (ID_Role, rolename) VALUES (sequenceIncrementIDRole.nextVal, '" + roleName + "')";
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
