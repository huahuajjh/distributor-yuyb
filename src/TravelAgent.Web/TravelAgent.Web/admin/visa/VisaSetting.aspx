<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisaSetting.aspx.cs" Inherits="TravelAgent.Web.admin.visa.VisaSetting" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
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
    <li><a href="#">产品管理</a></li>
    <li><a href="#">签证产品</a></li>
    <li><a href="#">
        签证基本设置</a></li>
    </ul>
    </div>
    <div style="padding-bottom:10px;">
        <table border="0" cellpadding="0" cellspacing="0" style="width:100%; " class="formtable">
            <tr>
                <td width="100px" style="text-align:right; color:#056dae;background: #F5F5F5;  line-height:30px;">签证注意事项：</td>
                <td>
                    <textarea id="txtVisa01" name="txtVisa01" cols="100" rows="4" style="width:95%; height:200px;" runat="server"></textarea>
                </td>
            </tr>
             <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">免责声明：</td>
                <td><textarea id="txtVisa02" name="txtVisa02" cols="100" rows="4" style="width:95%; height:200px;" runat="server"></textarea></td>
             </tr>
             <tr>
            <td style="text-align:right; color:#056dae;background: #F5F5F5; "></td>
            <td colspan="2" style=" padding-left:15px">
                <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="btn" 
                    onclick="btnSave_Click" /> &nbsp;
                <input name="重置" type="reset" class="resetbtn" value="重置" />
            </td>
        </tr>
        </table>
    </div>
    <script type="text/javascript">
        $(function() {
            CreateEditor('txtVisa01', 'full');
            CreateEditor('txtVisa02', 'full');
        })
    </script>
    </form>
</body>
</html>
