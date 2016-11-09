using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.Model
{
    public class ClubLineCollect
    {
        public int Id { get; set; }
        public int LineId { get; set; }
        public int ClubId { get; set; }
        public DateTime CollectDate { get; set; }
    }
}
