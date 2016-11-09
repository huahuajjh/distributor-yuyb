using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.Model
{
    public class TourGuideRoute
    {
        public int id { get; set; }
        public int guideid { get; set; }
        public DateTime routetime { get; set; }
        public string title { get; set; }
        public string contents { get; set; }
    }
}
