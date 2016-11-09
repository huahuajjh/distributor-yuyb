using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.Model
{
    public  class TourGuideSpot
    {
        public int id { get; set; }
        public int guideid { get; set; }
        public string areaname { get; set; }
        public DateTime routetime { get; set; }
        public string gallery { get; set; }
        public int sort { get; set; }
        public int routeid { get; set; }
    }
}
