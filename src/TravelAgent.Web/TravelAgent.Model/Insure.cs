using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.Model
{
    public class Insure
    {
        public int Id { get; set; }
        public string InsureName { get; set; }
        public int InsurePrice { get; set; }
        public string InsureContent { get; set; }
        public DateTime AddDate { get; set; }
        public int IsLock { get; set; }
    }
}
