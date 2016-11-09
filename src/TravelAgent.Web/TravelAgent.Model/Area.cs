using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.Model
{
    public class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Pid { get; set; }
        public string ShortName { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public int Level { get; set; }
        public string Position { get; set; }
        public int Sort { get; set; }
    }
}
