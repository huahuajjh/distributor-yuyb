using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.Model
{
    public class LineSpePrice
    {
        public int Id { set; get; }
        public int lineId { set; get; }
        public string lineDate { set; get; }
        public string linePrice { set; get; }
        public int tag { set; get; }
    }
}
