using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.Model
{
    public class TourGuideGallery
    {
        public int id { get; set; }
        public int guideid { get; set; }
        public string image { get; set; }
        public DateTime routetime { get; set; }
        public string areaname { get; set; }
        public int routeid { get; set; }
        public int spotid { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }
}
