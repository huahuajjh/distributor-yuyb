using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.Model
{
    public class VisaCity
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public string Tips { get; set; }
        public int Sort { get; set; }
        public int isLock { get; set; }
    }
}
