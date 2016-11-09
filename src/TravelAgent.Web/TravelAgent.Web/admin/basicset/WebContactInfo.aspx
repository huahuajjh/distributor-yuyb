<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebContactInfo.aspx.cs" Inherits="TravelAgent.Web.admin.basicset.WebContactInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>无标题文档</title>
<link href="../css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/js/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="/js/jquery.validate.min.js"></script>
<script type="text/javascript" src="/js/validate.js"></script>
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

	<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">系统设置</a></li>
    <li><a href="#">网站基础设置</a></li>
    <li><a href="#">网站联系信息</a></li>
    </ul>
    </div>
    
    <div class="formbody">
    
    <div class="itab">
  	<ul> 
    <li><a href="WebBasicInfo.aspx" >网站基本信息</a></li> 
    <li><a href="#" class="selected">网站联系信息</a></li>
    <li><a href="WebServices.aspx">网站客服信息</a></li>
    <li><a href="WebSEO.aspx">网站SEO设置</a></li> 
    <li><a href="WebAgreement.aspx">网站合同协议</a></li>
    <li><a href="WebPoints.aspx">网站积分设置</a></li>
  	</ul>
    </div> 
    
    <div style="padding-top:5px;">
    <form id="form1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="line-height:50px; width:100%;" class="formtable">
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; width:150px;">企业名称 <span class="red">*</span>：</td>
                <td><asp:TextBox ID="txtCompanyName" runat="server" CssClass="dfinput required" MaxLength="25" Width="300px" HintTitle="企业名称" HintInfo="请填写企业名称，至少1个字符，小于25个字符。"></asp:TextBox>
                        <span>至少1个字符，小于50个字符</span>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5;">经营许可证 <span class="red">*</span>：</td>
                <td><asp:TextBox ID="txtWebLicence" runat="server" CssClass="dfinput required" Width="200px" HintTitle="经营许可证" HintInfo="请填写经营许可证，如X-XX-XXXXX"></asp:TextBox>
                        <span>如X-XX-XXXXX</span>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5;">邮件地址 <span class="red">*</span>：</td>
                <td><asp:TextBox ID="txtWebEmail" runat="server" CssClass="dfinput required email" Width="200px" HintTitle="邮件地址" HintInfo="请填写网站邮件地址，如***@163.com"></asp:TextBox>
                <span>如***@163.com</span>
                </td>
            </tr>
           <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5;">联系电话 <span class="red">*</span>：</td>
                <td><asp:TextBox ID="txtWebTel" runat="server" CssClass="dfinput required" Width="200px" HintTitle="联系电话" HintInfo="请填写网站联系电话，手机或者带区号的座机号均可"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5;">联系QQ <span class="red">*</span>：</td>
                <td><asp:TextBox ID="txtWebQQ" runat="server" CssClass="dfinput required" Width="200px" HintTitle="联系QQ" HintInfo="请填写网站联系QQ"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5;">联系地址 <span class="red">*</span>：</td>
                <td><asp:TextBox ID="txtWebAddress" runat="server" CssClass="dfinput required" Width="400px" HintTitle="联系地址" HintInfo="请填写网站联系地址"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5;">工作时间 <span class="red">*</span>：</td>
                <td><asp:TextBox ID="txtWorkTime" runat="server" CssClass="dfinput required" Width="200px" HintTitle="工作时间" HintInfo="请填写工作时间,如9:00-18:00"></asp:TextBox>
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
