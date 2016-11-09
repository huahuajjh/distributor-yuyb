using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.Model
{
    public class ClubPoints
    {
        public int id { get; set; }
        public int clubid { get; set; }
        public string Content { get; set; }
        public int points { get; set; }
        public string remark { get; set; }
        public int pType { get; set; }
        public DateTime adddate { get; set; }
    }
}
