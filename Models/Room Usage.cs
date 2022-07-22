using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DJResortWebsite.Models
{
    public class Room_Usage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public int NoOfAdult { get; set; }
        public int NoOfChildren { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public string TransactionNo { get; set; }
        public string Note { get; set; }
        public int RoomID { get; set; }
    }
}