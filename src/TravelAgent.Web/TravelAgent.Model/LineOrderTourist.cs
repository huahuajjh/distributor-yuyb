using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.Model
{
    public class LineOrderTourist
    {
        public int id { get; set; }
        public int orderId { get; set; }
        public string touristName { get; set; }
        public string touristSex { get; set; }
        public string mobile { get; set; }
        public int papersType { get; set; }
        public string papersNo { get; set; }
        public string birthDate { get; set; }
        public int touristType { get; set; }
    }
}
