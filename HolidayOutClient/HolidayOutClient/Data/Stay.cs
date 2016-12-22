using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HolidayOutClient.Data
{
    public class Stay
    {
        public string checkin { get; set; }
        public string checkout { get ; set; }
        public int id { get; set; }
        public int roomID { get; set; }
        public string username { get; set; }

        public Stay(int id, string username, string checkin, string checkout, int roomId)
        {
            this.id = id;
            this.username = username; 
            this.roomID = roomId;
            this.checkin = checkin;
            this.checkout = checkout;
        }

        public override string ToString()
        {
            return checkin + ","+ ", "+","+ checkout + ","+id +  ","+roomID + username;
        }



    }
}
