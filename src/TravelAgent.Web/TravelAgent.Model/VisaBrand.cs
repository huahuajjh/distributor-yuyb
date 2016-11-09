using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.Model
{
    public class VisaBrand
    {
        public int Id { set; get; }
        public string PicUrl { set; get; }
        public string Title { set; get; }
        public string SubTitle { set; get; }
        public int Sort { set; get; }
        public int isLock { set; get; }
        public int Type { set; get; }
    }
}
