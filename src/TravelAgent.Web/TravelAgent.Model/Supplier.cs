using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.Model
{
    public class Supplier
    {
        public int Id { get; set; }
        public string supplyName { get; set; }
        public string contactName { get; set; }
        public string telephone { get; set; }
        public string mobilephone { get; set; }
        public string email { get; set; }
        public string remark { get; set; }
        public int isLock { get; set; }
    }
}
