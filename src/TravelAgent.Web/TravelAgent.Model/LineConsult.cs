using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.Model
{
    public class LineConsult
    {
        public int Id { get; set; }
        public int LineId { get; set; }
        public string LinkTel { get; set; }
        public string LinkEmail { get; set; }
        public string ConsultContent { get; set; }
        public DateTime ConsultDate { get; set; }
        public string ReplyContent { get; set; }
        public int ReplyUserId { get; set; }
        public DateTime ReplyDate { get; set; }
        public int IsReply { get; set; }
    }
}
