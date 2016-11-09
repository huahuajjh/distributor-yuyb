using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace TravelAgent.Tool
{
    public static class JsonUtil
    {
        public static string ToJson(object o)
        { 
            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(o);
        }

        public static T ToObj<T>(string json_str)
        { 
            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Deserialize<T>(json_str);
        }
    }
}
