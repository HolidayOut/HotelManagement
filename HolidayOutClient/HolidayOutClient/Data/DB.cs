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
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Http;
using System.Xml.Serialization;
using System.Xml;
using System.Globalization;

namespace HolidayOutClient
{
    class DB
    {

        public List<Account> Accounts = new List<Account>();

        public List<Employee> loadEmployees()
        {

            List<Employee> emp = null;
            WebRequest req = WebRequest.Create(@"http://localhost:18080/HolidayOutServer/webresources/employees");

            req.Method = "GET";
            try
            {
                HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
                if (resp.StatusCode == HttpStatusCode.OK)
                {
                    using (Stream respStream = resp.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(respStream, Encoding.UTF8);
                        string accJSON = reader.ReadToEnd();
                        emp = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Employee>>(accJSON);
                    }
                }
                else
                {
                    MessageBox.Show(string.Format("Status Code: {0}, Status Description: {1}", resp.StatusCode, resp.StatusDescription));
                }
            }catch(Exception ex)
            {
                throw ex;
            }
            return emp;
        }

        public List<Guest> Guests = new List<Guest>();
        public Account GetAccountByUsername(String username, String password)
        {
            Account ret;
            try
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
                ret = JsonConvert.DeserializeObject<Account>(responseFromServer);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return ret;

        }

        public void InsertMeal(Meal m)
        {
            WebRequest request = WebRequest.Create(@"http://localhost:18080/HolidayOutServer/webresources/meals");
            request.Method = "POST";

            string postData = JsonConvert.SerializeObject(m);
            MessageBox.Show(postData);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
        }

        public void RemoveEmployee(Employee emp)
        {
            try
            {
                WebRequest request = WebRequest.Create(@"http://localhost:18080/HolidayOutServer/webresources/employees/" + emp.username);
                request.Method = "DELETE";
                request.GetResponse();
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        public void UpdateEmployee(Employee emp)
        {
            WebRequest request = WebRequest.Create(@"http://localhost:18080/HolidayOutServer/webresources/employees");
            request.Method = "PUT";

            string postData = JsonConvert.SerializeObject(emp);
            MessageBox.Show(postData);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
        }

        public List<Meal> LoadMeals()
        {
           

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
            Stay acc = new Stay(-2, g.username, d_in.Value.ToString("dd.MMM.yyyy"), d_out.Value.ToString("dd.MMM.yyyy"), r.id);
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

        public void InsertEmployee(Employee e)
        {
            WebRequest request = WebRequest.Create(@"http://localhost:18080/HolidayOutServer/webresources/employees");
            request.Method = "POST";

            string postData = JsonConvert.SerializeObject(e);
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
            MessageBox.Show(postData+"****");
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
            try
            {
                WebRequest request = WebRequest.Create(@"http://localhost:18080/HolidayOutServer/webresources/rooms/" + roomIDToDelete);
                request.Method = "DELETE";
                request.GetResponse();
            }
            catch(Exception ex)
            {
                throw ex;
            }
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

        public void UpdateMeal(Meal m)
        {
            WebRequest request = WebRequest.Create(@"http://localhost:18080/HolidayOutServer/webresources/meals");
            request.Method = "PUT";

            string postData = JsonConvert.SerializeObject(m);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

        }



        public void RemoveMeal(Meal m)
        {
            WebRequest request = WebRequest.Create(@"http://localhost:18080/HolidayOutServer/webresources/meals");
            request.Method = "DELETE";

            string postData = JsonConvert.SerializeObject(m);
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
            WebRequest req = WebRequest.Create(@"http://localhost:18080/HolidayOutServer/webresources/rooms?id=" + ID);
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
            WebRequest req = WebRequest.Create(@"http://localhost:18080/HolidayOutServer/webresources/rooms/allrooms");

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
            WebRequest req = WebRequest.Create(@"http://localhost:18080/HolidayOutServer/webresources/roles/allroles");

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
            List<Permission> perm = new List<Permission>();
            WebRequest req = WebRequest.Create(@"http://localhost:18080/HolidayOutServer/webresources/permissions?id_role="+ID_Role);

            req.Method = "GET";

            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            if (resp.StatusCode == HttpStatusCode.OK)
            {
                using (Stream respStream = resp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream, Encoding.UTF8);
                    string accJSON = reader.ReadToEnd();
                    var des = JsonConvert.DeserializeObject<List<Permission>>(accJSON);
                    perm = des;
                }
            }
            else
            {
                MessageBox.Show(string.Format("Status Code: {0}, Status Description: {1}", resp.StatusCode, resp.StatusDescription));
            }
            return perm;
        }

        public void addRole(String roleName)
        {
            WebRequest request = WebRequest.Create(@"http://localhost:18080/HolidayOutServer/webresources/roles");
            request.Method = "POST";
            Role r = new Data.Role(-3, roleName);
            string postData = JsonConvert.SerializeObject(r);
            
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
        }

        public void removeRole(int ID_Role)
        {
            try
            {
                WebRequest request = WebRequest.Create(@"http://localhost:18080/HolidayOutServer/webresources/roles/" + ID_Role);
                request.Method = "DELETE";

                request.GetResponse();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<Permission> getAllPermissions()
        {
            List<Permission> perm = new List<Permission>();
            WebRequest req = WebRequest.Create(@"http://localhost:18080/HolidayOutServer/webresources/allpermissions");

            req.Method = "GET";

            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            if (resp.StatusCode == HttpStatusCode.OK)
            {
                using (Stream respStream = resp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream, Encoding.UTF8);
                    string accJSON = reader.ReadToEnd();
                    var des = JsonConvert.DeserializeObject<List<Permission>>(accJSON);
                    perm = des;
                }
            }
            else
            {
                MessageBox.Show(string.Format("Status Code: {0}, Status Description: {1}", resp.StatusCode, resp.StatusDescription));
            }
            return perm;
        }

        #endregion

        public string GenerateUsername(string v, string n)
        {
            return v + n[0];
        }

        #region Guests
        public List<Guest> getAllGuests()
        {
            List<Guest> guests = new List<Guest>();
            WebRequest req = WebRequest.Create(@"http://localhost:18080/HolidayOutServer/webresources/guests");

            req.Method = "GET";

            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            if (resp.StatusCode == HttpStatusCode.OK)
            {
                using (Stream respStream = resp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream, Encoding.UTF8);
                    string accJSON = reader.ReadToEnd();
                    var des = JsonConvert.DeserializeObject<List<Guest>>(accJSON);
                    MessageBox.Show(des[0].name);
                    guests = des;
                }
            }
            else
            {
                MessageBox.Show(string.Format("Status Code: {0}, Status Description: {1}", resp.StatusCode, resp.StatusDescription));
            }
            return guests;
        }

        public Role GetRoleByID(int ID_Role)
        {
            WebRequest req = WebRequest.Create(@"http://localhost:18080/HolidayOutServer/webresources/rolebyid?id=" + ID_Role);
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

        public void removePermissionFromRole(int ID_Role, int ID_Permission)
        {
            WebRequest request = WebRequest.Create(@"http://localhost:18080/HolidayOutServer/webresources/permissions");
            request.Method = "DELETE";
            Wrapper w = new Wrapper(ID_Role, ID_Permission);
            string postData = JsonConvert.SerializeObject(w);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
        }

        public void addPermissionToRole(int ID_Role, int ID_Permission)
        {
            Wrapper w = new Wrapper(ID_Role, ID_Permission);

            WebRequest request = WebRequest.Create(@"http://localhost:18080/HolidayOutServer/webresources/permissions");
            request.Method = "POST";
            string postData = JsonConvert.SerializeObject(w);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

        }

        #endregion
    }
}