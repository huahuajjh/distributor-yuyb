using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.Model
{
    public class School
    {

        public School()
        {
            ShortName = "";
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual string ShortName { get; set; }
        public int AreaId { get; set; }
        public string AreaName { get; set; }

        public static School NullSchool()
        { 
            return new School(){ AreaName="未知", Name="未知", AreaId=-1, Id=-1, ShortName="未知"};
        }
    }
}
