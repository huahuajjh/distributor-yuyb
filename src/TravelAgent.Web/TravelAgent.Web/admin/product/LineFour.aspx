<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LineFour.aspx.cs" Inherits="TravelAgent.Web.admin.product.LineFour" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>无标题文档</title>
<link href="../css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/js/jquery-1.3.2.min.js"></script>
<script type="text/javascript" charset="utf-8" src="/ueditor/ueditor.all.js"></script>
    <script type="text/javascript" charset="utf-8" src="/ueditor/ueditor.config.js"></script>
    <%--<script src="/ueditor/lang/zh-cn/zh-cn.js" type="text/javascript"></script>--%>
    <script type="text/javascript" src="/ueditor/editorconfig.js"></script>
<script type="text/javascript">
    $(function() {
    CreateEditor('txtCost', 'full');
    CreateEditor('txtOrder', 'full');
    CreateEditor('txtTravel', 'full');
    })
</script>
</head>

<body>
	<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">产品管理</a></li>
    <li><a href="#">线路产品</a></li>
    <li><a href="#">编辑线路</a></li>
    </ul>
    </div>
    
    <div class="formbody">
    <div class="itab">
  	<ul> 
    <li><a href="LineOne.aspx?id=<%= lineid %>&tag=<%=tag %>">第一步：线路描述</a></li> 
    <li><a href="LineTwo.aspx?id=<%= lineid %>&tag=<%=tag %>">第二步：价格计划</a></li>
    <li><a href="LineThree.aspx?id=<%= lineid %>&tag=<%=tag %>">第三步：行程安排</a></li>
    <li><a href="#" class="selected">第四步：线路内容</a></li>
  	</ul>
    </div> 
    <%--<div class="formtitle"><span>网站基本信息</span></div>--%>
    <div style="padding-top:5px;">
    <form id="form1" runat="server">
         <table border="0" cellpadding="0" cellspacing="0" style="width:100%;" class="formtable">
        <tr>
            <td style="width:10%;background: #F5F5F5; text-align:right ">费用说明：</td>
            <td>
                <textarea id="txtCost" name="txtCost" cols="100" rows="4" style="width:100%; height:200px;" runat="server"></textarea>
            </td>
        </tr>
        <tr>
            <td style="background: #F5F5F5; text-align:right ">预定须知：</td>
            <td>
                <textarea id="txtOrder" name="txtOrder" cols="100" rows="4" style="width:100%; height:200px;" runat="server"></textarea>
            </td>
        </tr>
        <tr>
            <td style="background: #F5F5F5; text-align:right ">出游提醒：</td>
            <td>
                <textarea id="txtTravel" name="txtTravel" cols="100" rows="4" style="width:100%; height:200px;" runat="server"></textarea>
            </td>
        </tr>
        <tr>
            <td style="background: #F5F5F5; text-align:right "></td>
            <td>
                    <asp:Button ID="btnSave" runat="server" Text="确定保存" CssClass="btn" 
                        onclick="btnSave_Click" />
            </td>
        </tr>
        </table>
     </form>
    </div>
    </div>


</body>

</html>
