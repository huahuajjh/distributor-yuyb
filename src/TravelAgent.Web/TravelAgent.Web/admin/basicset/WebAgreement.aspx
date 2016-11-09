<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebAgreement.aspx.cs" Inherits="TravelAgent.Web.admin.basicset.WebAgreement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>无标题文档</title>
<link href="../css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/js/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="/js/jquery.validate.min.js"></script>
<script type="text/javascript" src="/js/validate.js"></script>
<script type="text/javascript" charset="utf-8" src="/ueditor/ueditor.all.js"></script>
    <script type="text/javascript" charset="utf-8" src="/ueditor/ueditor.config.js"></script>
    <script src="/ueditor/lang/zh-cn/zh-cn.js" type="text/javascript"></script>
    <script type="text/javascript" src="/ueditor/editorconfig.js"></script>
</head>

<body>
        <div id="divMsg"></div>
	<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">系统设置</a></li>
    <li><a href="#">网站基础设置</a></li>
    <li><a href="#">网站基本信息</a></li>
    </ul>
    </div>
    
    <div class="formbody">
    <div class="itab">
  	<ul> 
    <li><a href="WebBasicInfo.aspx">网站基本信息</a></li> 
    <li><a href="WebContactInfo.aspx">网站联系信息</a></li>
    <li><a href="WebServices.aspx">网站客服信息</a></li>
    <li><a href="WebSEO.aspx">网站SEO设置</a></li>
    <li><a href="#" class="selected">网站合同协议</a></li>
    <li><a href="WebPoints.aspx">网站积分设置</a></li>
  	</ul>
    </div> 
    <%--<div class="formtitle"><span>网站基本信息</span></div>--%>
    <div style="padding-top:5px;">
    <form id="form1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="width:100%; " class="formtable">
            <tr>
                <td width="100px" style="text-align:right; color:#056dae;background: #F5F5F5;  line-height:30px;">出境合同内容：</td>
                <td>
                    <textarea id="txtChujingAgreeMent" name="txtChujingAgreeMent" cols="100" rows="4" style="width:95%; height:200px;" runat="server"></textarea>
                </td>
            </tr>
            <tr>
                <td width="100px" style="text-align:right; color:#056dae;background: #F5F5F5;  line-height:30px;">国内合同内容：</td>
                <td>
                    <textarea id="txtGuoneiAgreeMent" name="txtGuoneiAgreeMent" cols="100" rows="4" style="width:95%; height:200px;" runat="server"></textarea>
                </td>
            </tr>
             <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">会员服务协议：</td>
                <td><textarea id="txtMemberAgreeMent" name="txtMemberAgreeMent" cols="100" rows="4" style="width:95%; height:200px;" runat="server"></textarea></td>
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
        <script type="text/javascript">
            $(function() {
                CreateEditor('txtChujingAgreeMent', 'full');
                CreateEditor('txtGuoneiAgreeMent', 'full');
                CreateEditor('txtMemberAgreeMent', 'full');
            })
    </script>
     </form>
    </div>
    </div>


</body>

</html>
