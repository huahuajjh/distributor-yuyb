using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.Model
{
    public class VisaCountry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PicUrl { get; set; }
        public string Tips { get; set; }
        public string EnglishName { get; set; }
        public string FirstWord { get; set; }
        public int Sort { set; get; }
        public int isLock { get; set; }
        public int ParentId { get; set; }
        public string ClassList { get; set; }
        public int ClassLayer { get; set; }
    }
}
