<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebServices.aspx.cs" Inherits="TravelAgent.Web.admin.basicset.WebServices" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>无标题文档</title>
<link href="../css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/js/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="/js/jquery.form.js"></script>
<script type="text/javascript" src="/js/genneral.js"></script>
<script type="text/javascript">
    //添加客服组
    function AddQQService() {
        var count = $("#tblQQServices").find("tr.trChild").length;
        var html = "<tr class=\"trChild\"><td style=\" text-align:left;\"><input id=\"txtQQServiceName_{0}\" name=\"txtQQServiceName_{0}\" type=\"text\" class=\"dfinput\" style=\" width:96%\" maxlength=\"4\" /></td>";
        html += "<td style=\" text-align:left;\"><input id=\"txtQQServiceList_{0}\" name=\"txtQQServiceList_{0}\" type=\"text\" class=\"dfinput\" style=\" width:98%\" /></td>";
        html += "<td style=\"text-align:center\"><a href=\"javascript:void(0);\" onclick=\"DeleteQQService(this);\">[删除]</a></td></tr>";
        html = html.replace(/\{0\}/g, (Number(count) + 1));
        $("#tblQQServices").append(html);
        $("#hidQQServiceCount").val(Number(count) + 1);
    }
    //删除客服组
    function DeleteQQService(o) {
        var $deltr = $(o).parent("td").parent("tr");
        $deltr.remove();
        var count = $("#hidQQServiceCount").val();
        $("#hidQQServiceCount").val(Number(count) - 1);
    }
    $(function() {
        $("#btnSave").click(function() {
            $("#__VIEWSTATE").remove(); //这两句最重要
            $("#__EVENTVALIDATION").remove();
            $(this).attr("disabled", "disabled");
            $(this).val("正在保存中...");
            var options = {
                url: "../data/SysInfo.aspx?tag=qqservice&date=" + new Date().toUTCString(),
                type: 'POST',
                //beforeSubmit: Validate,
                success: function(responseText, statusText) {
                    $("#btnSave").attr("disabled", "");
                    $("#btnSave").removeAttr("disabled");
                    $("#btnSave").val("确定保存");
                    if (responseText == "true") {
                        jsprint('保存成功！', '', 'Success');
                    }
                    else {
                        jsprint('保存失败！', '', 'Error');
                    }
                }
            };
            $("#form1").ajaxSubmit(options);
        })
    })
</script>
</head>

<body>

	<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">系统设置</a></li>
    <li><a href="#">网站基础设置</a></li>
    <li><a href="#">网站客服信息</a></li>
    </ul>
    </div>
    
    <div class="formbody">
    <div class="itab">
  	<ul> 
    <li><a href="WebBasicInfo.aspx">网站基本信息</a></li> 
    <li><a href="WebContactInfo.aspx">网站联系信息</a></li>
    <li><a href="#" class="selected">网站客服信息</a></li>
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
                <td style="text-align:right; color:#056dae;background: #F5F5F5; width:150px;">QQ客服显示方式 ：</td>
                <td>
                    <%--<span id="QQServicesProperties" class="vertical">
                    <input id="QQServicesState_0" type="radio" name="QQServicesState" value="0" checked="checked"  /><label for="QQServicesState_0">不显示</label>
                    <input id="QQServicesState_1" type="radio" name="QQServicesState" value="1" /><label for="QQServicesState_1">左边显示</label>
                    <input id="QQServicesState_2" type="radio" name="QQServicesState" value="2" /><label for="QQServicesState_2">右边显示</label>
                    </span>--%>
                    <asp:RadioButtonList ID="rbtnQQServices" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="0">不显示</asp:ListItem>
                        <asp:ListItem Value="1">显示</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5;">QQ客服组管理 ：</td>
                <td>
                      <span style=" font-weight:bold">开启QQ在线咨询，请先确保QQ开启网站在线状态</span>  <span><a href="http://jingyan.baidu.com/article/ae97a646a825acbbfd461d13.html" target="_blank" style="color:Red; font-weight:bold">经验参考</a> | <a href="http://wp.qq.com/index.html" target="_blank" style="color:Red; font-weight:bold">点击这里开启</a></span><br />
                      <%--<table style="text-align:right; color:#056dae;width:99%;" id="tblQQServices">
                       <tr style="background: #F5F5F5; ">
                            <td style="text-align:center; width:20%">组名</td>
                            <td style="text-align:center; width:70%">客服QQ[多个QQ用,号分开]</td>
                            <td style="text-align:center"><a href="javascript:void(0);" onclick="AddQQService()">[增加]</a></td>
                       </tr>
                       <tr class="trChild">
                        <td style=" text-align:left;"><input id="txtQQServiceName_1" name="txtQQServiceName_1" type="text" class="dfinput" style=" width:96%" maxlength="4" /></td>
                        <td style=" text-align:left;"><input id="txtQQServiceList_1" name="txtQQServiceList_1" type="text" class="dfinput" style=" width:98%" /></td>
                        <td style="text-align:center"><a href="javascript:void(0);" onclick="DeleteQQService(this);">[删除]</a></td>
                       </tr>
                      </table>--%>
                      <div id="divQQServices" runat="server"></div>
                      <input id="hidQQServiceCount" name="hidQQServiceCount" type="hidden" value="1" runat="server" />
                </td>
            </tr>
            
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; height:60px;"></td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="确定保存" CssClass="btn" />
                </td>
            </tr>
     </table>
     </form>
    </div>
    
    
    </div>


</body>

</html>
