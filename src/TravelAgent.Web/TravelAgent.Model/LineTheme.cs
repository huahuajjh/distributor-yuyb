using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.Model
{
   public  class LineTheme
    {
        public int Id { get; set; }
        public string themeName { get; set; }
        public string themeTopPic { get; set; }
        public string themeTopBgPic { get; set; }
        public int Sort { get; set; }
        public int isLock { get; set; }
    }
}
