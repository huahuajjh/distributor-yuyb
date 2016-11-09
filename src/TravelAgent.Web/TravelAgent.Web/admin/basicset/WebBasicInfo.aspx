<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebBasicInfo.aspx.cs" Inherits="TravelAgent.Web.admin.basicset.WebBasicInfo" ValidateRequest="false" %>

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
    <li><a href="#">网站基础设置</a></li>
    <li><a href="#">网站基本信息</a></li>
    </ul>
    </div>
    
    <div class="formbody">
    <div class="itab">
  	<ul> 
    <li><a href="#" class="selected">网站基本信息</a></li> 
    <li><a href="WebContactInfo.aspx">网站联系信息</a></li>
    <li><a href="WebServices.aspx">网站客服信息</a></li>
    <li><a href="WebSEO.aspx">网站SEO设置</a></li>
    <li><a href="WebAgreement.aspx">网站合同协议</a></li>
    <li><a href="WebPoints.aspx">网站积分设置</a></li>
  	</ul>
    </div> 
    <%--<div class="formtitle"><span>网站基本信息</span></div>--%>
    <div style="padding-top:5px;">
    <form id="form1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="line-height:50px; width:100%;" class="formtable">
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; width:150px;">网站名称 <span class="red">*</span>：</td>
                <td><asp:TextBox ID="txtWebName" runat="server" CssClass="dfinput required" MaxLength="25" Width="300px" HintTitle="网站名称" HintInfo="请填写网站名称，至少1个字符，小于25个字符。"></asp:TextBox>
                        <span>至少1个字符，小于50个字符</span>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5;">网站域名 <span class="red">*</span>：</td>
                <td><asp:TextBox ID="txtWebDomain" runat="server" CssClass="dfinput required url" Width="300px" HintTitle="网站域名" HintInfo="请填写网站域名，如http://www.travelcms.com。"></asp:TextBox>
                        <span>以http://开头，如http://www.travelcms.com</span>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5;">网站Logo <span class="red">*</span>：</td>
                <td style="padding-top:10px;">
                    <asp:TextBox ID="txtImgUrl" runat="server" CssClass="dfinput left required" Width="200px" HintTitle="网站Logo" HintInfo="请上传网站logo。"></asp:TextBox>
                    <a href="javascript:void(0);" class="files"><input type="file" id="FileUpload" name="FileUpload" />浏览上传图片</a>
                    <span class="uploading">正在上传，请稍候...</span>
                    <span>&nbsp;格式仅限JPG|JPEG|PNG|GIF，推荐像素250*70</span>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5;">网站ICP备案 <span class="red">*</span>：</td><td><asp:TextBox ID="txtWebICP" runat="server" CssClass="dfinput required" Width="200px" HintTitle="网站ICP备案" HintInfo="请填写网站ICP备案，如鄂ICP备8888888号"></asp:TextBox><span> 如鄂ICP备8888888号</span>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5;">固定满意度 <span class="red">*</span>：</td><td><asp:TextBox ID="txtMYD" runat="server" CssClass="dfinput required digits" Width="50px" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" Text="98"></asp:TextBox>%
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5;">网站搜索关键字 <span class="red">*</span>：</td><td><asp:TextBox ID="txtSearchKey" runat="server" CssClass="dfinput required" Width="300px" HintTitle="网站搜索关键字" HintInfo="请填写网站搜索关键字，如广州长隆,木兰天池"></asp:TextBox><span> 多个关键字之间用英文逗号,间隔</span>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5;">网站开启状态：</td><td>
                    <%--<span id="WebLockProperties" class="vertical">
                    <input id="WebLock_0" type="radio" name="WebLock" value="0"  /><label for="WebLock_0">关闭</label>
                    <input id="WebLock_1" type="radio" name="WebLock" value="0" checked="checked" /><label for="WebLock_1">开启</label>
                    </span>--%>
                    <asp:RadioButtonList ID="rbtnWebLock" runat="server" 
            RepeatDirection="Horizontal" RepeatLayout="Flow">
            <asp:ListItem Value="1">开启</asp:ListItem>
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
