using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.Model
{
    public class VisaList
    {
        public int id { get; set; }
        public string visaName { get; set; }
        public int typeId { get; set; }
        public int signId { get; set; }
        public int countryId { get; set; }
        public int price { get; set; }
        public int usePoints { get; set; }
        public int donatePoints { get; set; }
        public string dealTime { get; set; }
        public string stayTime { get; set; }
        public string enterNumber { get; set; }
        public string interview { get; set; }
        public string expiryDate { get; set; }
        public int dealType { get; set; }
        public string State { get; set; }
        public string tips { get; set; }
        public string needMaterial { get; set; }
        public DateTime adddate { get; set; }
        public int Sort { get; set; }
        public int isLock { get; set; }
        public string picurl { get; set; }
        public string countryName { get; set; }
    }
}
