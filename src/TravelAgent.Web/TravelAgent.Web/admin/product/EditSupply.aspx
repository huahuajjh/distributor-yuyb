<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditSupply.aspx.cs" Inherits="TravelAgent.Web.admin.product.EditSupply" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="/js/jquery.validate.min.js"></script>
    <script type="text/javascript" src="/js/validate.js"></script>
    <script type="text/javascript" src="/js/jquery.form.js"></script>
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
    <form id="form1" runat="server">
    <div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">产品管理</a></li>
    <li><a href="#">线路产品</a></li>
    <li><a href="#">供应商</a></li>
    <li><a href="#">编辑供应商</a></li>
    </ul>
    </div>
    <div>
    <table border="0" cellpadding="0" cellspacing="0" style="width:100%;" class="formtable">
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">供应商名称 <span class="red">*</span>：</td>
                <td><asp:TextBox ID="txtSupplyName" runat="server" CssClass="dfinput required" MaxLength="25" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">联系人 ：</td>
                <td><asp:TextBox ID="txtContactName" runat="server" CssClass="dfinput" MaxLength="25" Width="100px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">电话 ：</td>
                <td><asp:TextBox ID="txtTelephone" runat="server" CssClass="dfinput" MaxLength="25" Width="300px"></asp:TextBox>
                        <span>电话之间以英文逗号,间隔。</span>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">手机号码 ：</td>
                <td><asp:TextBox ID="txtMobilephone" runat="server" CssClass="dfinput" MaxLength="25" Width="300px"></asp:TextBox>
                        <span>手机号码之间以英文逗号,间隔。</span>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">电子邮件 ：</td>
                <td><asp:TextBox ID="txtEmail" runat="server" CssClass="dfinput" MaxLength="25" Width="300px"></asp:TextBox>
                        <span>电子邮件之间以英文逗号,间隔。</span>
                </td>
            </tr>
            
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">备注 ：</td>
                <td><asp:TextBox ID="txtRemark" runat="server" CssClass="dfinput" MaxLength="25" Width="300px" Height="100px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">是否隐藏：</td>
                <td>
                    <asp:CheckBox ID="chkIsLock" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; width:150px; height:80px;"></td>
                <td><asp:Button ID="btnSave" runat="server" Text="确定保存" CssClass="btn" 
                        onclick="btnSave_Click" /></td>
            </tr>
     </table>
    </div>
    <input id="hidId" name="hidId" type="hidden" runat="server" value="0" />
    <input id="hidState" name="hidState" type="hidden" value="" />
    </form>
</body>
</html>
