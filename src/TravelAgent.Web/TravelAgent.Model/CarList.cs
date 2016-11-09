using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.Model
{
    public class CarList
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public string CarPic { get; set; }
        public int BrandId { get; set; }
        public int ClassId { get; set; }
        public int Seat { get; set; }
        public string CarDesc { get; set; }
        public string CarOrderTip { get; set; }
        public string State { get; set; }
        public int IsLock { get; set; }
        public int Sort { get; set; }
        public DateTime AddDate { get; set; }
        public string BrandName { get; set; }
        public string ClassName { get; set; }
    }
}
