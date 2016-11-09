using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.Model
{
    public class References
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }

        public static References NullReferences()
        {
            return new References() { SchoolId = -1, Name = "未知", Id=-1, SchoolName="未知", Tel="未知"};
        }
    }
}
