using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.Model
{
    public class CarPrice
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string PriceName { get; set; }
        public string Unit { get; set; }
        public int CarTypeID { get; set; }
        public int CarCityId { get; set; }
        public string TranDisc { get; set; }
        public int NumberId { get; set; }
        public int MemshiPrice { get; set; }
        public int XiaoshuPrice { get; set; }
        public int JiesuanPrice { get; set; }
        public int UsePoints { get; set; }
        public int DonatePoints { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int DealType { get; set; }
        public int IsLock { get; set; }
        public int BSQ { get; set; }
        public string SpeXiaoshuPrice { get; set; }
        public string NumName { get; set; }
    }
}
