using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TravelAgent.Model
{
    public class InfoSetting
    {
        public InfoSetting()
        { }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public DataSet ds { get; set; }
        public string getValue(string strName)
        {
            string value = "";
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row["Name"].ToString().Equals(strName))
                {
                    value = row["Value"].ToString();
                    break;
                }
            }
            return value;
        }
    }
}
