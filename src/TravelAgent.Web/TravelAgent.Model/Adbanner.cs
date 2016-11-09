using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.Model
{
    public class Adbanner
    {
        public int Id { get; set; }
        public int Aid { get; set; }
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string AdUrl { get; set; }
        public string LinkUrl { get; set; }
        public string AdRemark { get; set; }
        public int IsLock { get; set; }
        public DateTime? AddTime { get; set; }
    }
}
