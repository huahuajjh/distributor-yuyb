using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.Model
{
    public class DepartureCity
    {
        public int id { get; set; }
        public string CityName { get; set; }
        public int Sort { get; set; }
        public int isLock { get; set; }
    }
}
