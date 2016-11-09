<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebSEO.aspx.cs" Inherits="TravelAgent.Web.admin.basicset.WebSEO" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>无标题文档</title>
<link href="../css/style.css" rel="stylesheet" type="text/css" />
</head>

<body>

	<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">系统设置</a></li>
    <li><a href="#">网站基础设置</a></li>
    <li><a href="#">网站SEO设置</a></li>
    </ul>
    </div>
    
    <div class="formbody">
    <div class="itab">
  	<ul> 
    <li><a href="WebBasicInfo.aspx">网站基本信息</a></li> 
    <li><a href="WebContactInfo.aspx">网站联系信息</a></li>
    <li><a href="WebServices.aspx">网站客服信息</a></li>
    <li><a href="#" class="selected">网站SEO设置</a></li>
    <li><a href="WebAgreement.aspx">网站合同协议</a></li>
    <li><a href="WebPoints.aspx">网站积分设置</a></li>
  	</ul>
    </div> 
    <%--<div class="formtitle"><span>网站基本信息</span></div>--%>
    <div style="padding-top:5px;">
    <form id="form1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="width:100%; padding-top:5px; padding-bottom:5px;" class="formtable">
            <tr style="background: #F5F5F5; ">
                <td colspan="3">全局SEO关键字设置，提升网站在搜索引擎中关键词的排名。</td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; width:20%">Meta Title(标题)：</td>
                <td style=" width:420px;"><textarea runat="server" name="SEOTitle" rows="3" cols="100"   id="SEOTitle"  style=" width:95%; border:solid 1px #787a7b">旅游线路_酒店预订_景点门票_演出票务_租车服务_旅游度假</textarea></td>
                <td>一般不超过80个字符</td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5;">Meta Keywords(关键字)：</td>
                <td><textarea name="SEOKeywords" runat="server" rows="3" cols="100" style=" width:95%; border:solid 1px #787a7b" id="SEOKeywords" >旅游,旅游线路,旅游网站,旅行社网站</textarea></td>
                <td>一般不超过100个字符，关键字中间用半角逗号隔开</td>
            </tr>
            
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5;">Meta Description(描述)：</td>
                <td><textarea name="SEODescription" runat="server" rows="5" cols="100" style=" width:95%; border:solid 1px #787a7b" id="SEODescription">中国最专业全面的旅游线路、签证等一站式旅游服务提供商,客户满意度96%;提供周边旅游,国内旅游,出境旅游,签证服务。实时发团日期,报价,行程,全程优质的服务保障</textarea></td>
                <td>一般不超过200个字符</td>
            </tr>
           
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; height:60px;"></td>
                <td colspan="2">
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
