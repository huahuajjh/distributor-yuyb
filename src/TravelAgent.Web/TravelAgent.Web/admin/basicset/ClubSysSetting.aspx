<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClubSysSetting.aspx.cs" Inherits="TravelAgent.Web.admin.basicset.ClubSysSetting" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <script type="text/javascript" src="/js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="/js/jquery.validate.min.js"></script>
    <script type="text/javascript" src="/js/validate.js"></script>
    <script type="text/javascript" src="../js/singleupload.js"></script>
    <script type="text/javascript" src="../js/select-ui.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="/ueditor/ueditor.all.js"></script>
    <script type="text/javascript" charset="utf-8" src="/ueditor/ueditor.config.js"></script>
    <script src="/ueditor/lang/zh-cn/zh-cn.js" type="text/javascript"></script>
    <script type="text/javascript" src="/ueditor/editorconfig.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">系统设置</a></li>
    <li><a href="#">
        会员系统设置</a></li>
    </ul>
    </div>
    <div style="padding-bottom:10px;">
        <table border="0" cellpadding="0" cellspacing="0" style="width:100%; " class="formtable">
            <tr>
                <td width="100px" style="text-align:right; color:#056dae;background: #F5F5F5;  line-height:30px;">会员注册：</td>
                <td>
                    <asp:RadioButtonList ID="rbtnWebLock" runat="server" 
            RepeatDirection="Horizontal" RepeatLayout="Flow">
            <asp:ListItem Value="1" Selected="True">开启</asp:ListItem>
            <asp:ListItem Value="0">关闭</asp:ListItem>
        </asp:RadioButtonList>
                </td>
            </tr>
             <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">注册服务条款：</td>
                <td><textarea id="txtRegContent" name="txtRegContent" cols="100" rows="8" style="width:88%; height:400px;" runat="server"></textarea></td>
             </tr>
             <tr>
            <td style="text-align:right; color:#056dae;background: #F5F5F5; "></td>
            <td style=" padding-left:15px">
                <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="btn" 
                    onclick="btnSave_Click" /> &nbsp;
                <input name="重置" type="reset" class="resetbtn" value="重置" />
            </td>
        </tr>
        </table>
    </div>
    <script type="text/javascript">
        $(function() {
            CreateEditor('txtRegContent', 'full');
        })
       
    </script>
    </form>
</body>
</html>
