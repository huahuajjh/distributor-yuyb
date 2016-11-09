<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="DiyResult.aspx.cs" Inherits="TravelAgent.Web.DiyResult" %>
<%@ MasterType VirtualPath="~/Common.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" type="text/css" href="/css/style.css" />
<link rel="stylesheet" type="text/css" href="/css/diy.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form method="post" id="form1">
  <div style="height: 540px;background: url(/images/diy1.jpg) center;" class="clearfix">
   <div class="srdzWrap container">
<div class="ss">
        <table style="width:90%">
          <tbody>
          <tr>
            <td>
            <img src="/images/suess.gif" />
             </td>
          </tr>
          <tr>
            <td style="width: 248px; color:#5a5a5a; padding-left:20px;  font-size:20px;">
            <p>您的定制信息已提交成功！我们的客服人员将尽快与您取得联系，请您保持电话畅通，并耐心等待...</p>
          <p>您也可以主动联系我们，联系电话：<b style="color:#f60;"><%=Master.webinfo.WebTel %></b></p>
            </td>
          </tr>
        </tbody>
        </table>
      
      </div>
    </div>
  </div>
</form>
</asp:Content>
