using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.Model
{
    public class LineJourney
    {
        public int id { get; set; }
        public int lineId { get; set; }
        public string title { get; set; }
        public int breakfast { get; set; }
        public int nooning { get; set; }
        public int dinner { get; set; }
        public string Accom { get; set; }
        public string journeyContent { get; set; }
        public int journeySort { get; set; }
    }
}
