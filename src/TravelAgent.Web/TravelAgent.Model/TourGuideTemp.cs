using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.Model
{
    public class TourGuideTemp
    {
        public int Id { get; set; }
        public string userid { get; set; }
        public string nickname { get; set; }
        public string title { get; set; }
        public DateTime createtime { get; set; }
        public string imagelist { get; set; }
        public int imagecount { get; set; }
        public int commentcount { get; set; }
        public string areamatch { get; set; }
        public string areamathrow { get; set; }
        public int istuijian { get; set; }
        public int ispublish { get; set; }
        public int tourdays { get; set; }
        public int browsecount { get; set; }
        public DateTime updatetime { get; set; }
        public int prasecount { get; set; }
        public int ishot { get; set; }
        public int isindex { get; set; }
        public int tourrange { get; set; }
        public int tourtype { get; set; }
    }
}
