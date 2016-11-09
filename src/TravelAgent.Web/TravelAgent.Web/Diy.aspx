<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="Diy.aspx.cs" Inherits="TravelAgent.Web.Diy" %>
<%@ MasterType VirtualPath="~/Common.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" type="text/css" href="/css/style.css" />
<link rel="stylesheet" type="text/css" href="/css/diy.css" />
<script src="/js/jquery-1.7.2.min.js" type="text/javascript"></script>
<script src="/js/jquery.form.js" type="text/javascript"></script>
<script src="/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form method="post" id="form1">
  <div style="height: 540px;background: url(/images/diy.jpg) center;" class="clearfix">
   <div class="srdzWrap container">
<div class="ss">
        <table>
          <tbody><tr>
            <td colspan="2">
            <div> <span class="">景点城市</span>
                <input onclick="this.value = '';" value="多个景点城市以逗号间隔" id="jingdian" name="jingdian" class="t3" autocomplete="off" style="color: rgb(170, 170, 170);">
              </div></td>
            <td><div> <span>业务类型</span>
                <div style="box-shadow: 1px 1px 3px #DDDDDD inset;border: 1px solid #ccc;width: 238px;">
                  <select class="type" name="type">
                    <%=BindBusinessType()%>
                  </select>
                </div>
              </div></td>
          </tr>
          <tr>
            <td style="width: 248px;"><div> <span>行程天数</span>
                <input type="text" id="days" name="days" class="lt required number" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" >
              </div></td>
            <td style="width: 248px;"><div> <span>出游人数</span>
                <input type="text" id="renshu" name="renshu" class="lt required number" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" >
              </div></td>
            <td style="width: 248px;"><div> <span>单人预算</span>
                <input type="text" id="price" name="price" class="lt required number" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" >
              </div></td>
          </tr>
          <tr>
            <td><div> <span>游玩日期</span>
                <input type="text" readonly="" autocomplete="off" id="shijian" name="shijian" class="lt Wdate required" onfocus="WdatePicker({doubleCalendar:true,dateFmt:'yyyy-MM-dd'})"/>
              </div></td>
            <td><div> <span>联系人</span>
                <input type="text" id="xingming" name="xingming" class="lt required">
              </div></td>
            <td><div> <span>联系电话</span>
                <input type="text" id="dianhua" name="dianhua" class="lt required">
              </div></td>
          </tr>
          <tr>
            <td style="position: relative;padding-top: 12px;" colspan="2"><span style="float:left;display: inline-block;height: 72px;line-height: 72px;">其他需求</span>
              <textarea class="remarkt" name="remark"></textarea>
            </td>
            <td style="position: relative;padding-top: 8px;">
<input type="hidden" id="today" name="shijian1" value="2015/7/24 下午4:05:56">
<input type="hidden" value="jingdian,text;type,text;days,text;renshu,text;price,text;shijian,text;xingming,text;dianhua,text;remark,multitext;shijian1,text" name="dede_fields">
<input type="hidden" value="5ad2542935be3ed70816f21c0593f07e" name="dede_fieldshash">
<button class="mc_btn1" id="save" type="button">确定提交</button>
              <p class="error_tip"></p></td>
          </tr>
        </tbody></table>
          <!--     <div class="successWrap"><img src="/images/success.png">
          <p>您的定制信息已提交成功！我们的客服人员将尽快与您取得联系，请您保持电话畅通，并耐心等待...</p>
          <p>您也可以主动联系我们，联系电话：<b style="color:#f60;">400-659-0029 029-88880743</b></p>
        </div>-->
      </div>
    </div>
  </div>
</form>
<script type='text/javascript' src='/js/diy.js'></script>
</asp:Content>
