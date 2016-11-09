using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.data
{
    public partial class Product_Holiday : System.Web.UI.Page
    {
        private static readonly TravelAgent.BLL.LineHoliday HolidayBll = new TravelAgent.BLL.LineHoliday();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request["tag"] != null)
                {
                    string strTag = Request["tag"];
                    if (strTag == "holiday_save")//目的地设置
                    {
                        int holiday_editid = Convert.ToInt32(Request["hidId"]);
                        TravelAgent.Model.LineHoliday model = new TravelAgent.Model.LineHoliday();
                        model.holidayName = Request["txtThemeName"];
                        model.holidaybgurl = Request["txtImgUrl"];
                      
                        try
                        {
                            if (holiday_editid != 0)
                            {
                                model.Id = holiday_editid;
                                HolidayBll.Update(model);
                            }
                            else
                            {
                                HolidayBll.Add(model);
                            }
                            Response.Write("true");
                        }
                        catch
                        {
                            Response.Write("false");
                        }
                    }
                    else if (strTag == "holiday_delete")
                    {
                        int holidayid = Convert.ToInt32(Request["holidayid"]);
                        try
                        {
                            HolidayBll.Delete(holidayid);
                            Response.Write("true");
                        }
                        catch
                        {
                            Response.Write("false");
                        }
                    }
                }
            }
        }
    }
}
