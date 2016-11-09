using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web.UI;
namespace TravelAgent.Tool
{
    public class CommonOprate
    {
        /// <summary>
        /// 通过值获得状态的组合
        /// </summary>
        /// <param name="value">值，如0,1；0表示隐藏,1表示推荐</param>
        /// <returns>隐藏,推荐</returns>
        public static string GetStatesByValue(string value)
        {
            string strReturnValue = "";

            if (!value.Equals(""))
            {
                string[] strArryValue = value.Split(new char[] { ',' });

                foreach (string s in strArryValue)
                {
                    if (!s.Equals("")&&!s.Equals("0"))
                    {
                        strReturnValue = strReturnValue + EnumHelper.GetMemberName<EnumSummary.State>(s) + ",";
                    }
                }

                if (!strReturnValue.Equals(""))
                {
                    strReturnValue = strReturnValue.Substring(0, strReturnValue.Length - 1);
                }
            }

            return strReturnValue;
        }
        /// <summary>
        /// 查找是否包含字符串
        /// </summary>
        /// <param name="value">要查找的字符串</param>
        /// <param name="strValue">被查找的字符串</param>
        /// <returns></returns>
        public static bool IsContainValue(string value, string strValue)
        {
            bool bolContain = true;

            value = "," + value + ",";
            strValue = "," + strValue + ",";

            if (strValue.IndexOf(value) < 0)
            {
                bolContain = false;
            }

            return bolContain;
        }
        /// <summary>
        /// 显示线路的状态
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ShowLineState(string value)
        {
            string strValue = "";
            int v;
            if (!string.IsNullOrEmpty(value))
            {
                value = value.Trim(',');
                string[] arryValue = value.Split(',');
                foreach (string s in arryValue)
                { 
                    v=Convert.ToInt32(s);
                    if (v == Convert.ToInt32(EnumSummary.State.热卖))
                    {
                        strValue += "<i class=\"remai\"></i>";
                    }
                    else if (v == Convert.ToInt32(EnumSummary.State.特价))
                    {
                        strValue += "<i class=\"tejia\"></i>";
                    }
                    else if (v == Convert.ToInt32(EnumSummary.State.推荐))
                    {
                        strValue += "<i class=\"tuijian\"></i>";
                    }
                }
            }
            return strValue;
        }
        /// <summary>
        /// 显示餐饮状态
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ShowCatering(int value)
        {
            return value == 0 ? "自理" : "已含";
        }
        /// <summary>
        /// 显示行程标题
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ShowLineTitle(string value)
        {
            string strValue = value;
            if (!string.IsNullOrEmpty(strValue))
            {
                strValue = strValue.Replace("[飞机]", "<img alt=\"飞机\" title=\"飞机\" src=\"/images/air.png\" />");
                strValue = strValue.Replace("[火车]", "<img alt=\"火车\" title=\"火车\" src=\"/images/train.png\" />");
                strValue = strValue.Replace("[汽车]", "<img alt=\"汽车\" title=\"汽车\" src=\"/images/car.png\" />");
                strValue = strValue.Replace("[船]", "<img alt=\"船\" title=\"船\" src=\"/images/ship.png\" />");
            }
            return strValue;
        }
    }
}
