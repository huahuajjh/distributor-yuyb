<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SmsInterface.aspx.cs" Inherits="TravelAgent.Web.admin.basicset.SmsInterface" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>无标题文档</title>
<link href="../css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/js/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="/js/jquery.validate.min.js"></script>
<script type="text/javascript" src="/js/validate.js"></script>
<script type="text/javascript" src="/js/jquery.form.js"></script>
<script type="text/javascript" src="../js/singleupload.js"></script>
<script type="text/javascript">
    $(function() {
        //表单验证JS
        $("#form1").validate({
            //出错时添加的标签
            errorElement: "span",
            success: function(label) {
                //正确时的样式
                label.text(" ").addClass("success");
            }
        });
    });
</script>
</head>

<body>
        <div id="divMsg"></div>
	<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">系统设置</a></li>
    <li><a href="#">接口设置</a></li>
    <li><a href="#">短信接口设置</a></li>
    </ul>
    </div>
    
    <div class="formbody">
    <div class="itab">
  	<ul> 
    <li><a href="PayInterface.aspx">支付接口设置</a></li> 
    <li><a href="EmailInterface.aspx">邮件接口设置</a></li>
    <li><a href="#" class="selected">短信接口设置</a></li>
  	</ul>
    </div> 
    <%--<div class="formtitle"><span>网站基本信息</span></div>--%>
    <div style="padding-top:5px;">
    <form id="form1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="line-height:50px; width:100%;" class="formtable">
            <tr>
                <td colspan="2">
                    * 本系统暂且支持【天雨讯达短信平台】
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; width:12%;">主机名：
                </td>
                <td><asp:TextBox ID="txtHostName" runat="server" CssClass="dfinput required" MaxLength="25" Width="200px" ></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5;">用户名：
                </td>
                <td><asp:TextBox ID="txtUsername" runat="server" CssClass="dfinput required" MaxLength="25" Width="200px" ></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5;">密码：
                </td>
                <td><asp:TextBox ID="txtPassword" runat="server" CssClass="dfinput required" MaxLength="25" Width="200px"  TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5;">开启状态：</td>
                <td>
                    <asp:RadioButtonList ID="rbtnLock" runat="server" 
            RepeatDirection="Horizontal" RepeatLayout="Flow">
            <asp:ListItem Value="1" Selected="True">开启</asp:ListItem>
            <asp:ListItem Value="0">关闭</asp:ListItem>
        </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; height:60px;"></td>
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
