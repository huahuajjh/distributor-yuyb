<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayInterface.aspx.cs" Inherits="TravelAgent.Web.admin.basicset.PayInterface" %>

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
        $("input[name='rbtnPayType']").click(function() {
            //            if ($(this).val() == "1") {
            //                $(".tralipay").show();
            //                $(".trchinapay").hide();
            //            }
            //            else {
            //                $(".tralipay").hide();
            //                $(".trchinapay").show();
            //            }
            $("tr[class='" + $(this).val() + "']").show();
            $("tr[class!='" + $(this).val() + "'][class!='']").hide();
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
    <li><a href="#">支付接口设置</a></li>
    </ul>
    </div>
    
    <div class="formbody">
    <div class="itab">
  	<ul> 
    <li><a href="#" class="selected">支付接口设置</a></li> 
    <li><a href="EmailInterface.aspx">邮件接口设置</a></li>
    <li><a href="SmsInterface.aspx">短信接口设置</a></li>
  	</ul>
    </div> 
    <%--<div class="formtitle"><span>网站基本信息</span></div>--%>
    <div style="padding-top:5px;">
    <form id="form1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="line-height:50px; width:100%;" class="formtable">
            <tr>
                <td style="text-align:left; color:#056dae;background: #F5F5F5; " colspan="2">
                    <asp:RadioButtonList ID="rbtnPayType" runat="server" 
            RepeatDirection="Horizontal" RepeatLayout="Flow">
            <asp:ListItem Value="tralipay" Selected="True">支付宝</asp:ListItem>
             <asp:ListItem Value="trwxpay">微信支付</asp:ListItem>
            <asp:ListItem Value="trchinapay">网银在线</asp:ListItem>
        </asp:RadioButtonList>
                </td>
            </tr>
            <tr class="tralipay">
                <td style="text-align:right; color:#056dae;background: #F5F5F5;width:18%">支付宝账号 ：</td>
                <td><asp:TextBox ID="txtAlipayAccount" runat="server" CssClass="dfinput" MaxLength="25" Width="200px" ></asp:TextBox>
                        &nbsp;</td>
            </tr>
            <tr class="tralipay">
                <td style="text-align:right; color:#056dae;background: #F5F5F5;">合作者PID ：</td>
                <td><asp:TextBox ID="txtAlipayID" runat="server" CssClass="dfinput" Width="200px" ></asp:TextBox>
                </td>
            </tr>
            <tr class="tralipay">
                <td style="text-align:right; color:#056dae;background: #F5F5F5;">安全校验码KEY ：</td>
                <td><asp:TextBox ID="txtAlipayKEY" runat="server" CssClass="dfinput" Width="200px" ></asp:TextBox>&nbsp;</td>
            </tr>
            <tr class="tralipay">
                <td style="text-align:right; color:#056dae;background: #F5F5F5;">商户的私钥 ：</td>
                <td><asp:TextBox ID="txtSiYue" runat="server" CssClass="dfinput" Width="500px"></asp:TextBox>&nbsp;手机网站支付时使用
                </td>
            </tr>
            <tr class="tralipay">
                <td style="text-align:right; color:#056dae;background: #F5F5F5;">支付宝公约 ：</td>
                <td><asp:TextBox ID="txtGongyue" runat="server" CssClass="dfinput" Width="500px"></asp:TextBox>&nbsp;手机网站支付时使用</td>
            </tr>
             <tr class="tralipay">
                <td style="text-align:right; color:#056dae;background: #F5F5F5;">开启状态：</td><td>
                    <asp:RadioButtonList ID="rbtnAlipayLock" runat="server" 
            RepeatDirection="Horizontal" RepeatLayout="Flow">
            <asp:ListItem Value="1" Selected="True">开启</asp:ListItem>
            <asp:ListItem Value="0">关闭</asp:ListItem>
        </asp:RadioButtonList>
                </td>
            </tr>
            <tr class="tralipay">
                <td style="text-align:right; color:#056dae;background: #F5F5F5; height:60px;"></td>
                <td>
                    <asp:Button ID="btnSave1" runat="server" Text="确定保存" CssClass="btn" 
                        onclick="btnSave1_Click" />
                </td>
            </tr>
            <tr class="trwxpay" style="display:none;">
                <td style="text-align:right; color:#056dae;background: #F5F5F5; height:60px;width:18%">公众号ID(appId)：</td>
                <td>
                    <asp:TextBox ID="txtAppId" runat="server" CssClass="dfinput" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr class="trwxpay" style="display:none">
                <td style="text-align:right; color:#056dae;background: #F5F5F5; height:60px;">公众号密钥(appSecret)：</td>
                <td>
                    <asp:TextBox ID="txtappSecret" runat="server" CssClass="dfinput" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr class="trwxpay" style="display:none">
                <td style="text-align:right; color:#056dae;background: #F5F5F5; height:60px;">
                    微信支付商户号(mchid)：</td>
                <td>
                    <asp:TextBox ID="txtmchid" runat="server" CssClass="dfinput" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr class="trwxpay" style="display:none">
                <td style="text-align:right; color:#056dae;background: #F5F5F5; height:60px;">
                    商户密钥(API密钥)：</td>
                <td>
                    <asp:TextBox ID="txtapiKey" runat="server" CssClass="dfinput" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr class="trwxpay" style="display:none">
                <td style="text-align:right; color:#056dae;background: #F5F5F5; height:60px;">开启状态：</td>
                <td>
                <asp:RadioButtonList ID="rbtnwxPayLock" runat="server" 
            RepeatDirection="Horizontal" RepeatLayout="Flow">
            <asp:ListItem Value="1" Selected="True">开启</asp:ListItem>
            <asp:ListItem Value="0">关闭</asp:ListItem>
        </asp:RadioButtonList>
                </td>
            </tr>
            <tr class="trwxpay" style="display:none">
                <td style="text-align:right; color:#056dae;background: #F5F5F5; height:60px; width:18%;"></td>
                <td><asp:Button ID="btnSave2" runat="server" Text="确定保存" CssClass="btn" 
                        onclick="btnSave2_Click"  /></td>
            </tr>
            <tr class="trchinapay" style="display:none;width:18%">
                <td style="text-align:right; color:#056dae;background: #F5F5F5; width:12%">客户号 ：</td>
                <td><asp:TextBox ID="txtChinabankAccount" runat="server" CssClass="dfinput" MaxLength="25" Width="200px" ></asp:TextBox>
                        &nbsp;</td>
            </tr>
            <tr class="trchinapay" style="display:none">
                <td style="text-align:right; color:#056dae;background: #F5F5F5;">私钥 ：</td>
                <td><asp:TextBox ID="txtChinabankKey" runat="server" CssClass="dfinput" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr class="trchinapay" style="display:none">
                <td style="text-align:right; color:#056dae;background: #F5F5F5;">开启状态：</td><td>
                    <asp:RadioButtonList ID="rbtnChinabankLock" runat="server" 
            RepeatDirection="Horizontal" RepeatLayout="Flow">
            <asp:ListItem Value="1" Selected="True">开启</asp:ListItem>
            <asp:ListItem Value="0">关闭</asp:ListItem>
        </asp:RadioButtonList>
                </td>
            </tr>
            <tr class="trchinapay" style="display:none">
                <td style="text-align:right; color:#056dae;background: #F5F5F5; height:60px;"></td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="确定保存" CssClass="btn" 
                        onclick="btnSave_Click"  />
                </td>
            </tr>
     </table>
     </form>
    </div>
    </div>


</body>

</html>
