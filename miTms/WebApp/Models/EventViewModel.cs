using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class EventViewModel
    {
       public string title { get; set; }
        public DateTime start { get; set; }   
          public DateTime? end { get; set; }
          public bool allDay { get; set; }
         public string[] className { get; set; }
        public string icon { get; set; }
        public string description { get; set; }
    }
}