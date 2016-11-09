using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.Model
{
    public class Order
    {
        public int Id { get; set; }
        public int lineId { get; set; }
        public string ordercode { get; set; }
        public int peopleNumber { get; set; }
        public int adultNumber { get; set; }
        public int childNumber { get; set; }
        public DateTime? orderDate { get; set; }
        public string TravelDate { get; set; }
        public int orderPrice { get; set; }
        public int attachPrice { get; set; }
        public int usePoints { get; set; }
        public int donatePoints { get; set; }
        public string contactName { get; set; }
        public string contactMobile { get; set; }
        public string contactEmail { get; set; }
        public string contactTelephone { get; set; }
        public string orderRemark { get; set; }
        public string operRemark { get; set; }
        public int orderState { get; set; }
        public int clubid { get; set; }
        public int adultPrice { get; set; }
        public int childPrice { get; set; }
        public int payType { get; set; }
        public int subPrice { get; set; }
        public int orderType { get; set; }
        public string contactSex { get; set; }
        public string proName { get; set; }
        public int sourceType { get; set; }
        public int dealType { get; set; }
        public string tuijianren { get; set; }
        public string IDcard { get; set; }
        private string _usedate = "";
        public string usedate 
        {
            get { return _usedate; }
            set { _usedate = value; }
        }
        private int _timedot = 0;
        public int timedot 
        {
            get { return _timedot;}
            set { _timedot=value;} 
        }

        private string _huandate = "";
        public string huandate 
        {
            get { return _huandate;}
            set { _huandate=value;}
        }

        private int _account = 0;
        public int account {
            get { return _account;}
            set { _account=value;}
        }
    }
}
