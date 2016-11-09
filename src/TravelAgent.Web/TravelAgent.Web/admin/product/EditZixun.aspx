<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditZixun.aspx.cs" Inherits="TravelAgent.Web.admin.product.EditZixun" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title></title>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript">
        $(function() {
            $("#btnSave").click(function() {
                if ($.trim($("#txtContent").val()) == "") {
                    alert("请输入回复内容！");
                    return false;
                }
                $.ajax({
                    type: "POST",
                    url: "../data/Zixun.aspx",
                    cache: false,
                    dataType: "text",
                    data: { zixun_id: <%=id %>,content:$("#txtContent").val(),isemail:$("#chkIsEmail").attr("checked"),email:$("#hfemail").val(),question:$("#hfquestion").val() },
                    success: function(msg) {
                        //提示删除成功消息
                        if (msg.indexOf("true")>-1) {
                            parent.document.getElementById("btnQuery").click();
                            return false;
                        }
                        else {
                            alert("回复失败！");
                            return false;
                        }
                    }
                })
            })
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="0" cellpadding="0" cellspacing="0" style="width:100%;" class="formtable">
    <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">咨询时间：</td>
                <td>
                    <asp:Label ID="lbldate" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">咨询内容：</td>
                <td>
                    <asp:Label ID="lblZixun" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">回复内容 <span class="red">*</span>：</td>
                <td>
                <textarea id="txtContent" name="txtContent" cols="100" rows="4" style="width:500px; height:100px; border:solid 1px #000" runat="server"></textarea>
                </td>
            </tr>
            <tr>
                 <td style="text-align:right; color:#056dae;background: #F5F5F5; ">发送邮件：</td>
                <td>
                    <asp:CheckBox ID="chkIsEmail" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; width:100px; height:60px;"></td>
                <td><asp:Button ID="btnSave" runat="server" Text="确定保存" CssClass="btn" /></td>
            </tr>
     </table>
    </div>
    <asp:HiddenField ID="hfemail" runat="server" Value="" />
    <asp:HiddenField ID="hfquestion" runat="server" Value="" />
    </form>
</body>
</html>
