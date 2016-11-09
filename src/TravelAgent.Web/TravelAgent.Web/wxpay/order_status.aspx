<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order_status.aspx.cs" Inherits="TravelAgent.Web.wxpay.order_status" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    输入订单号：<asp:TextBox ID="order_no" runat="server"></asp:TextBox>
        </br>
    
        <asp:Button ID="button" runat="server"  Text="查询" onclick="button_Click"  />
    </div>
    </form>
</body>
</html>
