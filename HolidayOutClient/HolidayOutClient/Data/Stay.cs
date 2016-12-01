﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HolidayOutClient.Data
{
    class Stay
    {
        public string checkin { get; set; }
        public string checkout { get; set; }
        public int id { get; set; }
        public int roomID { get; set; }
        public string username { get; set; }

        public Stay(int id, string username, string checkin, string checkout, int roomId)
        {
            this.id = id;
            this.username = username;
            this.checkin = checkin;
            this.checkout = checkout;
            this.roomID = roomId;
        }

        public override string ToString()
        {
            return checkin + ","+ ", "+","+ checkout + ","+id +  ","+roomID + username;
        }



    }
}