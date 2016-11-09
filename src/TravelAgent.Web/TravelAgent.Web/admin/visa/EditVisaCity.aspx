<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditVisaCity.aspx.cs" Inherits="TravelAgent.Web.admin.visa.EditVisaCity" %>

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
        //����Ŀ�ĵ�
        var EditNav = function() {
            $("#__VIEWSTATE").remove(); //����������Ҫ
            $("#__EVENTVALIDATION").remove();
            $(this).attr("disabled", "disabled");
            $(this).val("���ڱ�����...");
            var options = {
                url: "../data/Visa.aspx?tag=city_save&date=" + new Date().toUTCString(),
                type: 'POST',
                //beforeSubmit: Validate,
                success: function(responseText, statusText) {
                    $("#btnSave").attr("disabled", "");
                    $("#btnSave").removeAttr("disabled");
                    $("#btnSave").val("ȷ������");
                    if (responseText.indexOf("true") >= 0) {
                        // �����ҳ�����ػ��߹ر����ӶԻ���ȫ����ر�
                        parent.location.reload();
                        return false;
                    }
                    else {
                        parent.art.dialog.alert("����ʧ�ܣ�");
                    }
                }
            };
            $("#form1").ajaxSubmit(options);
        }
        $(function() {
            //����֤JS
            $("#form1").validate({
                //����ʱ��ӵı�ǩ
                errorElement: "span",
                submitHandler: function() {
                    EditNav();
                    return false;
                },
                success: function(label) {
                    //��ȷʱ����ʽ
                    label.text(" ").addClass("success");
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="0" cellpadding="0" cellspacing="0" style="width:100%;" class="formtable">
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">�������� <span class="red">*</span>��</td>
                <td><asp:TextBox ID="txtCityName" runat="server" CssClass="dfinput required" MaxLength="25" Width="180px"></asp:TextBox>
                        <span>����1���ַ���С��25���ַ���</span>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">������ʾ <span class="red">*</span>��</td>
                <td style=""><textarea name="txtTips" runat="server" rows="7" cols="100" style=" width:90%; border:solid 1px #787a7b" id="txtTips" class="required"></textarea>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">��� <span class="red">*</span>��</td>
                <td><asp:TextBox ID="txtSort" runat="server" CssClass="dfinput required digits" MaxLength="25" Width="80px" Text="0" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);"></asp:TextBox>
                        <span>�������������֡�</span>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">��ʾ״̬��</td>
                <td style="padding-left:10px;">
                    <asp:CheckBox ID="chkState" runat="server" Text="����" />
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; width:150px; height:80px;"></td>
                <td><asp:Button ID="btnSave" runat="server" Text="ȷ������" CssClass="btn" /></td>
            </tr>
     </table>
    </div>
    <input id="hidId" name="hidId" type="hidden" runat="server" value="0" />
    <input id="hidState" name="hidState" type="hidden" value="" />
    </form>
</body>
</html>
