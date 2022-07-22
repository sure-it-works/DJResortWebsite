using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DJResortWebsite.Models
{
    public class Space
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }


        public string[] Types => new string[] {"Family","Barkada","Single","Couple" };


    }
}