using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.Model
{
    public class SMSRecord
    {
        public int SMSId { get; set; }
        public string SMSTelephone { get; set; }
        public string SMSSendDate { get; set; }
        public string SMSContent { get; set; }
        public int State { get; set; }
    }
}
