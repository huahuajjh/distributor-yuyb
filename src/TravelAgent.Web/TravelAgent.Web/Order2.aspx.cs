using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web
{
    public partial class Order2 : System.Web.UI.Page
    {
        public int oid;
        public TravelAgent.Model.Line Line;
        public TravelAgent.Model.Order order;
        private static readonly TravelAgent.BLL.Order LineOrderBll = new TravelAgent.BLL.Order();
        private static readonly TravelAgent.BLL.Line LineBll = new TravelAgent.BLL.Line();
        private static readonly TravelAgent.BLL.Insure InsureBll = new TravelAgent.BLL.Insure();
        private static readonly TravelAgent.BLL.LineOrderTourist OTBll = new TravelAgent.BLL.LineOrderTourist();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "填写游客信息-" + Master.webinfo.WebName;
            int.TryParse(Request.QueryString["oid"], out oid);
            if (!this.IsPostBack)
            {
                if (oid > 0)
                {
                    order = LineOrderBll.GetModel(oid);
                    if (order != null)
                    {
                        Line = LineBll.GetModel(order.lineId);
                    }
                    else
                    {
                        Response.Redirect("/Opr.aspx?t=error&msg=opr", false);
                    }
                }
                else
                {
                    Response.Redirect("/Opr.aspx?t=error&msg=opr", false);
                }
                //提交游客信息
                if (Request["txtHiddenUList"] != null)
                {
                    //TravelAgent.Model.LineOrderTourist tourist = null;
                    string[] arryUlist = Request["txtHiddenUList"].Split('$');
                    string strsql = "";
                    string[] strdetail=null;
                    for(int i=0;i<arryUlist.Length;i++)
                    {
                        strdetail=arryUlist[i].Split('^');
                        strsql += "insert into LineOrderTourist(orderId,touristName,touristSex,mobile,papersType,papersNo,birthDate,touristType) values";
                        strsql+="('"+order.Id+"','"+strdetail[0]+"','"+strdetail[3]+"','"+strdetail[5]+"','"+strdetail[1]+"','"+strdetail[2]+"','"+strdetail[4]+"','"+strdetail[8]+"');";
                    }
                    if (!strsql.Equals(""))
                    {
                        //Access
                        //if (TravelAgent.Tool.DbHelperOleDb.ExecuteSql(strsql) > 0)
                        if (TravelAgent.Tool.DbHelperSQL.ExecuteSql(strsql) > 0)
                        {
                            //urlrewrite
                            Response.Redirect("/lineorder/3/" + oid+".html", false);
                        }
                        else
                        {
                            Response.Redirect("/Opr.aspx?t=error&msg=opr", false);
                        }
                    }
                }
            }
            if (order == null) { Response.Redirect("/Opr.aspx?t=error&msg=opr", false); order = new Model.Order(); }
            if (Line == null) { Response.Redirect("/Opr.aspx?t=error&msg=opr", false); Line = new Model.Line(); }
        }
        /// <summary>
        /// 绑定附加产品
        /// </summary>
        /// <returns></returns>
        public string BindAttach()
        {
            StringBuilder sbAttach = new StringBuilder();
            if (order.attachPrice > 0)
            {
                TravelAgent.Model.Insure insure = InsureBll.GetModel(Line.InsureId);
                sbAttach.Append("<li class=\"li2\" id=\"AddPList\" style=\"\">");
                sbAttach.Append("<p class=\"p1\">附加产品</p>");
                sbAttach.Append("<div class=\"last\"><p>" + insure.InsureName + "</p><p><b>¥<s>" + order.attachPrice + "</s></b>" + (order.attachPrice / insure.InsurePrice) + "份×¥" + insure.InsurePrice + "</p></div>");
                sbAttach.Append("</li>");
            }
            return sbAttach.ToString();
        }
        /// <summary>
        /// 绑定游客信息
        /// </summary>
        /// <returns></returns>
        public string BindTouristInfo()
        {
            StringBuilder sbTour = new StringBuilder();
            for (int i = 0; order != null && i < order.adultNumber; i++)
            {
                sbTour.Append("<div class=\"userType userTypeAdault\" id=\"div_ch_person_"+i+"\">");
                sbTour.Append("<div class=\"hd\">");
                //sbTour.Append("<label><input type=\"checkbox\" checked=\"checked\" id=\"chk_ch_person_"+i+"\" />保存到常用游客</label>成人游客：");
                sbTour.Append("成人游客：");
                sbTour.Append("<div class=\"tip\">填写说明");
                sbTour.Append("<div style=\"display: none;\">");
                sbTour.Append("<p class=\"smname\">填写说明:</p>");
                sbTour.Append("<p> 1、乘客姓名必须与登机所持证件一致。<br />2、持护照登机，如使用中文姓名，请确保护照上有相应的中文姓名。<br />3、持护照登机的外宾，请以姓在前名在后的方式填写，例：Zhang（姓）/Sam（名），不区分大小写。<br />4、英文名字长度不超过26个字符，过长请使用缩写。<br />5、名字中含生僻字可直接输入拼音代替。例：\"王麙\"可输入为\"王yan\"或者\"王-yan\"。<br /></p>");
                sbTour.Append("</div></div></div>");
                sbTour.Append("<div class=\"bd\">");
                sbTour.Append("<table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" class=\"tb1\">");
                sbTour.Append("<tr><td class=\"td1\"><i>*</i> 真实姓名：</td>");
                sbTour.Append("<td><div class=\"floatDiv guestInputList\" style=\"z-index: 1000\"><input class=\"input1\" maxlength=\"26\" id=\"txt_ch_person_RealName_"+i+"\" autocomplete='off' /><ul id=\"ul_ch_person_"+i+"\"></ul><span style=\"color: Red;\"></span><input type=\"hidden\" id=\"txt_ch_person_UserId_"+i+"\" /></div></td>");
                sbTour.Append("<td class=\"td1\"><i>*</i> 手机：</td>");
                sbTour.Append("<td><div class=\"floatDiv\"><input class=\"input1\" maxlength=\"11\" id=\"txt_ch_person_Phone_"+i+"\" value=\"\" /><span style=\"color: Red;\"></span></div></td></tr>");
                sbTour.Append("<tr><td class=\"td1\" class=\"td1\"><i>*</i> 证件类别：</td>");
                sbTour.Append("<td><select style=\"width: 162px;\" id=\"ddl_ch_person_CodeType_"+i+"\"><option value=\"0\">身份证</option><option value=\"4\">护照</option><option value=\"2\">军官证</option><option value=\"6\">台胞证</option><option value=\"7\">回乡证</option></select></td>");
                sbTour.Append("<td class=\"td1\" id=\"td_ch_person_CodeTitle_"+i+"\"><i>*</i> 证件号码：</td>");
                sbTour.Append("<td id=\"td_ch_person_CodeInput_"+i+"\"><input class=\"input1\" maxlength=\"20\" id=\"txt_ch_person_Code_"+i+"\" /><span style=\"color: Red;\"></span></td></tr>");
                sbTour.Append("<tr id=\"tr_ch_person_sexandbirthday_"+i+"\" style=\"display: none;\">");
                sbTour.Append("<td class=\"td1\"><i>*</i> 性别：</td>");
                sbTour.Append("<td><div class=\"floatDiv\"><select id=\"ddl_ch_person_Sex_"+i+"\"><option value=\"1\">男</option><option value=\"0\">女</option></select></div></td>");
                sbTour.Append("<td class=\"td1\"><i>*</i> 出生日期：</td>");
                sbTour.Append("<td><div class=\"floatDiv\" style=\"z-index: 3; height: 26px;\"><input class=\"input1 b_date\" id=\"txt_ch_person_Birthday_"+i+"\" /><span style=\"color: Red;\"></span></div></td>");
                sbTour.Append("</tr></table>");
                sbTour.Append("<div class=\"notice\" style=\"display: none;\" id=\"divwrongId_"+i+"\">");
                sbTour.Append("据此身份证号码判断出游客为儿童，与之前选择的游客类型\"成人\"不符，请核对身份证号码是否有误，若无误，说明之前选择的游客类型有误，因订单"+order.ordercode+"已生成，请直接联系客服"+Master.webinfo.WebTel+"为您修改。");
                sbTour.Append("</div></div></div>");
               
            }
            for (int k = 0; order != null && k < order.childNumber; k++)
            {
                sbTour.Append("<div class=\"userType userTypeChildren\" id=\"div_ch_child_"+k+"\">");
                sbTour.Append("<div class=\"hd\">");
                //sbTour.Append("<label><input type=\"checkbox\" checked=\"checked\" id=\"chk_ch_child_"+k+"\" />保存到常用游客</label>儿童游客：");
                sbTour.Append("儿童游客：");
                sbTour.Append("<div class=\"tip\">填写说明");
                sbTour.Append("<div style=\"display: none;\">");
                sbTour.Append("<p class=\"smname\">填写说明:</p>");
                sbTour.Append("<p> 1、乘客姓名必须与登机所持证件一致。<br />2、持护照登机，如使用中文姓名，请确保护照上有相应的中文姓名。<br />3、持护照登机的外宾，请以姓在前名在后的方式填写，例：Zhang（姓）/Sam（名），不区分大小写。<br />4、英文名字长度不超过26个字符，过长请使用缩写。<br />5、名字中含生僻字可直接输入拼音代替。例：\"王麙\"可输入为\"王yan\"或者\"王-yan\"。<br /></p>");
                sbTour.Append("</div></div></div>");
                sbTour.Append("<div class=\"bd\">");
                sbTour.Append("<table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" class=\"tb1\">");
                sbTour.Append("<tr><td class=\"td1\"><i>*</i> 真实姓名：</td>");
                sbTour.Append("<td><div class=\"floatDiv guestInputList\" style=\"z-index: 1000\"><input class=\"input1\" maxlength=\"26\" id=\"txt_ch_child_RealName_"+k+"\" autocomplete='off' /><ul id=\"ul_ch_child_"+k+"\"></ul><span style=\"color: Red;\"></span><input type=\"hidden\" id=\"txt_ch_child_UserId_"+k+"\" /></div></td>");
                sbTour.Append("<td class=\"td1\" id=\"td_ch_child_BirthdayTitle_"+k+"\" > <i>*</i> 出生日期：</td>");
                sbTour.Append("<td id=\"td_ch_child_BirthdayInput_"+k+"\" ><div class=\"floatDiv\" style=\"z-index: 3; height: 26px;\"><input class=\"input1 b_date\" id=\"txt_ch_child_Birthday_"+k+"\" /><span style=\"color: Red;\"></span></div></td></tr>");
                sbTour.Append("<tr id=\"tr_ch_child_sex_"+k+"\" ><td class=\"td1\"><i>*</i> 性别：</td>");
                sbTour.Append("<td colspan=\"3\"><div class=\"floatDiv\"><select id=\"ddl_ch_child_Sex_"+k+"\"><option value=\"1\">男</option><option value=\"0\">女</option></select></div></td></tr>");
                sbTour.Append("</table>");
                sbTour.Append("<div class=\"notice\" style=\"display: none;\" id=\"divwrongbdays_"+k+"\">");
                sbTour.Append("据此出生日期判断出游客为成人或婴儿，与之前选择的游客类型\"儿童\"不符，请核对出生日期是否有误，若无误，说明之前选择的游客类型有误，因订单" + order.ordercode + "已生成，请直接联系康辉客服" + Master.webinfo.WebTel + "为您修改。");
                sbTour.Append("</div></div></div>");
            }
            return sbTour.ToString();
        }
    }
}
