using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HolidayOutClient.Data
{
    class Stay
    {
        public decimal ID { get; set; }
        public string username { get; set; }
        public decimal roomId { get; set; }

        public Stay(decimal id, string username, DateTime checkin, DateTime checkout, decimal roomId)
        {
            ID = id;
            this.username = username;
            this.checkin = checkin;
            this.checkout = checkout;
            this.roomId = roomId;
            MessageBox.Show(this.roomId.ToString());
        }

       
       
        public DateTime checkin { get; set; }
        public DateTime checkout { get; set; }
       
    }
}
