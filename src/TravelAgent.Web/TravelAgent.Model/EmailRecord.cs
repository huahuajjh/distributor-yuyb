using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.Model
{
    public class EmailRecord
    {
        public int EmailID { get; set; }
        public string Email { get; set; }
        public string EmailContent { get; set; }
        public DateTime? EmailSendDate { get; set; }
        public int State { get; set; }
    }
}
