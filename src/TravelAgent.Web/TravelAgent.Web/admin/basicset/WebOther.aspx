<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebOther.aspx.cs" Inherits="TravelAgent.Web.admin.basicset.WebOther" %>

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
<script type="text/javascript" src="/admin/js/singleupload.js"></script>
<script type="text/javascript" src="/admin/js/singleupload1.js"></script>
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
    <li><a href="#">网站基础设置</a></li>
    <li><a href="#">网站基本信息</a></li>
    </ul>
    </div>
    
    <div class="formbody">
    <div class="itab">
  	<ul> 
    <li><a href="#" class="selected">微信微博设置</a></li> 
  <%--  <li><a href="WebContactInfo.aspx">网站联系信息</a></li>
    <li><a href="WebServices.aspx">网站客服信息</a></li>
    <li><a href="WebSEO.aspx">网站SEO设置</a></li>
    <li><a href="WebAgreement.aspx">网站合同协议</a></li>
    <li><a href="WebPoints.aspx">网站积分设置</a></li>--%>
  	</ul>
    </div> 
    <%--<div class="formtitle"><span>网站基本信息</span></div>--%>
    <div style="padding-top:5px;">
    <form id="form1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="line-height:50px; width:100%;" class="formtable">
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; width:150px;">微信公众号 ：</td>
                <td><asp:TextBox ID="txtWXName" runat="server" CssClass="dfinput" MaxLength="25" Width="200px"></asp:TextBox>
                        <span>至少1个字符，小于50个字符</span>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5;">微信二维码 ：</td>
                <td style="padding-top:10px;">
                    <asp:TextBox ID="txtImgUrl" runat="server" CssClass="dfinput left required" Width="200px"></asp:TextBox>
                    <a href="javascript:void(0);" class="files"><input type="file" id="FileUpload" name="FileUpload" />浏览上传图片</a>
                    <span class="uploading">正在上传，请稍候...</span>
                    <span>&nbsp;格式仅限JPG|JPEG|PNG|GIF</span></td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5;">新浪微博地址 ：</td><td><asp:TextBox ID="txtXLWBUrl" runat="server" CssClass="dfinput url" Width="300px" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5;">腾讯微博地址 ：</td><td><asp:TextBox ID="txtTXWBUrl" runat="server" CssClass="dfinput url" Width="300px" ></asp:TextBox>
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
