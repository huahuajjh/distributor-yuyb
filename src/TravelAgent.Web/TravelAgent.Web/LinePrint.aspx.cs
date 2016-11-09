using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web
{
    public partial class LinePrint : TravelAgent.Web.UI.mBasePage
    {
        public TravelAgent.Model.Line LineModel;
        private static readonly TravelAgent.BLL.Line LineBll = new TravelAgent.BLL.Line();
        private static readonly TravelAgent.BLL.Destination DestBll = new TravelAgent.BLL.Destination();
        private static readonly TravelAgent.BLL.JoinProperty ProBll = new TravelAgent.BLL.JoinProperty();
        private static readonly TravelAgent.BLL.DepartureCity CityBll = new TravelAgent.BLL.DepartureCity();
        private static readonly TravelAgent.BLL.LineSpePrice SpePriceBll = new TravelAgent.BLL.LineSpePrice();
        private static readonly TravelAgent.BLL.LineContent LineContentBll = new TravelAgent.BLL.LineContent();
        protected void Page_Load(object sender, EventArgs e)
        {
            int id;
            if (!string.IsNullOrEmpty(Request.QueryString["id"]) && int.TryParse(Request.QueryString["id"], out id))
            {
                LineModel = LineBll.GetModel(id);
                if (LineModel == null)
                {
                    Response.Redirect("");
                }
            }
        }
        /// <summary>
        /// 显示出发城市
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public string ShowCityName(int cityId)
        {
            TravelAgent.Model.DepartureCity cityModel = CityBll.GetModel(cityId);
            return cityModel != null ? cityModel.CityName : "";
        }
        /// <summary>
        /// 显示线路类型
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public string ShowLineTypeName(int typeId)
        {
            TravelAgent.Model.JoinProperty proModel = ProBll.GetModel(typeId);
            return proModel != null ? proModel.joinName : "";
        }
        /// <summary>
        /// 显示行程
        /// </summary>
        /// <returns></returns>
        public string ShowLine()
        {
            StringBuilder sb = new StringBuilder();
            if (LineModel.EditModel == 0)
            {
                List<TravelAgent.Model.LineContent> lstLineContent = LineContentBll.GetlstLineContentByLineId(LineModel.Id);
                TravelAgent.Model.LineContent content = null;
                for (int i = 0; i < lstLineContent.Count; i++)
                {
                    content = lstLineContent[i];
                    sb.Append("<div class=\"day\">");
                    sb.Append(" <div class=\"title\"><h5>第<span>"+ content.DaySort +"</span>天</h5>"+content.Title+"</div>");
                    sb.Append("<div class=\"nr\">");
                    sb.Append(content.Content);
                    sb.Append("</div>");
                    sb.Append("<div class=\"eat\">");
                    sb.Append("<s></s>用餐：<span>早餐（" + TravelAgent.Tool.CommonOprate.ShowCatering(content.Morn) + "）</span>，<span>中餐（" + TravelAgent.Tool.CommonOprate.ShowCatering(content.Noon) + "）</span>，<span>晚餐（" + TravelAgent.Tool.CommonOprate.ShowCatering(content.Night) + "）</span>");
                    sb.Append("</div>");
                    sb.Append("<div class=\"house\">");
                    sb.Append("<s></s>住宿："+content.Accom);
                    sb.Append("</div>");
                    sb.Append("</div>");
                }
            }
            else
            {
                sb.Append(LineModel.LineContent);
            }

            return sb.ToString();
        }
    }
}
