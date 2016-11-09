using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.Model
{
    public class TourComment
    {
        public int id { get; set; }
        public string contents { get; set; }
        public int comment_type { get; set; }
        public int comment_rel_id { get; set; }
        public int user_id { get; set; }
        public string nickname { get; set; }
        public DateTime create_time { get; set; }
    }
}
