<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LineThree.aspx.cs" Inherits="TravelAgent.Web.admin.product.LineThree" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>�ޱ����ĵ�</title>
<link href="../css/style.css" rel="stylesheet" type="text/css" />
<script src="/js/jquery-1.3.2.min.js" type="text/javascript"></script>
<script type="text/javascript" src="/js/jquery.form.js"></script>
<script type="text/javascript" charset="utf-8" src="/ueditor/ueditor.all.js"></script>
    <script type="text/javascript" charset="utf-8" src="/ueditor/ueditor.config.js"></script>
    <%--<script src="/ueditor/lang/zh-cn/zh-cn.js" type="text/javascript"></script>--%>
    <script type="text/javascript" charset="utf-8" src="/ueditor/editorconfig.js"></script>
<script type="text/javascript">
    var count=<%= dayNumber%>;
    var addtraffic = function(i, str) {
        var obj = document.getElementById('txt_BT_D' + i);
        if (document.selection) {
            obj.focus();
            var sel = document.selection.createRange();
            document.selection.empty();
            sel.text = str;
        } else {
            var prefix, main, suffix;
            prefix = obj.value.substring(0, obj.selectionStart);
            main = obj.value.substring(obj.selectionStart, obj.selectionEnd);
            suffix = obj.value.substring(obj.selectionEnd);
            obj.value = prefix + str + suffix;
        }
        obj.focus();
    }
    $(function() {
          $("input[name='rbtnEditModel']").click(function() {
            if ($(this).val() == "0") {
                $("#trDayEdit").show();
                $("#trVisableEdit").hide();
            }
            else {
                $("#trDayEdit").hide();
                $("#trVisableEdit").show();
            }
        });
         //var editorContent = new UE.ui.Editor({});
         //editorContent.render("txtContent");
        for(var i=1;i<=count;i++)
        {
            CreateEditor('txt_Content_D'+i,'full');
        }
        CreateEditor('txtContent', 'full');
        
    })
</script>
</head>

<body>
	<div class="place">
    <span>λ�ã�</span>
    <ul class="placeul">
    <li><a href="#">��Ʒ����</a></li>
    <li><a href="#">��·��Ʒ</a></li>
    <li><a href="#">�༭��·</a></li>
    </ul>
    </div>
    
    <div class="formbody">
    <div class="itab">
  	<ul> 
    <li><a href="LineOne.aspx?id=<%= lineid %>&tag=<%=tag %>">��һ������·����</a></li> 
    <li><a href="LineTwo.aspx?id=<%= lineid %>&tag=<%=tag %>">�ڶ������۸�ƻ�</a></li>
    <li><a href="#" class="selected">���������г̰���</a></li>
    <li><a href="LineFour.aspx?id=<%= lineid %>&tag=<%=tag %>">���Ĳ�����·����</a></li>
  	</ul>
    </div> 
    <%--<div class="formtitle"><span>��վ������Ϣ</span></div>--%>
    <div style="padding-top:5px;">
    <form id="form1" runat="server" method="post">
    <table border="0" cellpadding="0" cellspacing="0" style="width:100%;" class="formtable">
        <tr>
            <td style="width:10%;background: #F5F5F5; text-align:right ">�༭ģʽ��</td>
            <td>
                <asp:RadioButtonList ID="rbtnEditModel" runat="server" 
            RepeatDirection="Horizontal" RepeatLayout="Flow">
            <asp:ListItem Value="0" Selected="True">����༭</asp:ListItem>
            <asp:ListItem Value="1">���ӻ��༭</asp:ListItem>
        </asp:RadioButtonList>
            </td>
        </tr>
        <tr id="trDayEdit" runat="server" style="display:">
            <td style="background: #F5F5F5; text-align:right; vertical-align:top;">�г����ݣ�</td>
            <td>
                    <%--<table border="0" cellpadding="0" cellspacing="0" style="width:100%" class="formtable">
                        <tr>
                            <td style="width:6%; text-align:center">��1��</td>
                            <td>
                                <table border="0" cellpadding="0" cellspacing="0" style="width:100%" class="formtable">
                                    <tr>
                                        <td style=" width:55px; text-align:right">���⣺</td>
                                        <td>
                                            <table border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style=" border:0"><input id="txt_BT_D1" name="txt_BT_D1" type="text" class="dfinput w200" /></td>
                                                    <td style=" border:0">
                                                        <a href="javascript:;" onclick="addtraffic('1','[�ɻ�]');"><img src="/images/air.gif" alt="�ɻ�" title="�ɻ�"></a> 
                                                        <a href="javascript:;" onclick="addtraffic('1','[��]');"><img src="/images/ship.gif" alt="��" title="��"></a>
                                                        <a href="javascript:;" onclick="addtraffic('1','[��]');"><img src="/images/train.gif" alt="��" title="��"></a>
                                                        <a href="javascript:;" onclick="addtraffic('1','[����]');"><img src="/images/vehicle.gif" alt="����" title="����"></a>  
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align:right">�òͣ�</td>
                                        <td>
                                            <table border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style=" border:0">��</td>
                                                    <td style=" border:0">
                                                        <input id="chk_morn_D1" name="chk_morn_D1" type="checkbox" /></td>
                                                    <td style=" border:0">��</td>
                                                    <td style=" border:0">
                                                        <input id="chk_noon_D1" name="chk_noon_D1" type="checkbox" /></td>
                                                    <td style=" border:0">��</td>
                                                    <td style=" border:0">
                                                        <input id="chk_night_D1" name="chk_night_D1" type="checkbox" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align:right">ס�ޣ�</td>
                                        <td><input id="txt_D1_ZS" name="txt_D1_ZS" type="text" class="dfinput w150" /></td>
                                    </tr>
                                    <tr>
                                        <td style="text-align:right">���ݣ�</td>
                                        <td><textarea id="txt_D1_Content" name="txt_D1_Content" cols="100" rows="4" style="width:100%; height:180px;" runat="server"></textarea></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>--%>
                    <div id="divContent" runat="server"></div>
            </td>
        </tr>
        <tr id="trVisableEdit" runat="server" style="display:none">
            <td style="background: #F5F5F5; text-align:right; vertical-align:top;">�г����ݣ�</td>
            <td>
                <textarea id="txtContent" name="txtContent" cols="100" rows="4" style="width:100%; height:400px;" runat="server"></textarea>
                 <%--<script language="javascript" type="text/javascript">
                     var editorContent = new UE.ui.Editor({});
                     editorContent.render("txtContent");
                     editorContent.addListener("contentChange", function() {
                         window.setTimeout(function() {
                            $("#txtContent").val(editorContent.getContent());
                         }, 1000);
                     }) 
                </script>--%>
                <input id="hidContent" name="hidContent" type="hidden" />
            </td>
        </tr>
        <tr>
            <td style="background: #F5F5F5; text-align:right "></td>
            <td>
                     <input id="btnSave" type="submit" value="ȷ������" class="btn" />
                     <%--<asp:Button ID="btnSave" runat="server" Text="ȷ������" CssClass="btn" />--%>
            </td>
        </tr>
    </table>
    
    <input id="hidlineid" name="hidlineid" type="hidden" runat="server" />
     </form>
    </div>
    </div>
<script type="text/javascript">
    $(function() {
        $("#btnSave").click(function() {
            //alert(editor['txtContent'].getContent());
            $("#__VIEWSTATE").remove(); //����������Ҫ
            $("#__EVENTVALIDATION").remove();
            $(this).attr("disabled", "disabled");
            $(this).val("���ڱ�����...");
            var options = {
                url: "../data/Product_Line1.aspx?daycount=" + count + "&date=" + new Date().toUTCString(),
                type: 'POST',
                //beforeSubmit: Validate,
                success: function(responseText, statusText) {
                    $("#btnSave").attr("disabled", "");
                    $("#btnSave").removeAttr("disabled");
                    $("#btnSave").val("ȷ������");
                    if (responseText.indexOf("true") >= 0) {
                        parent.jsprint("����ɹ���", "", "Success");
                        return false;
                    }
                    else {
                        parent.jsprint("����ʧ�ܣ�", "", "Error");
                    }
                },
                error: function(data) {
                    debugger;
                    alert(data);
                    parent.jsprint("����ʧ�ܣ�", "", "Error");
                }
            };
            $("#form1").ajaxSubmit(options);
            return false;
        })
    })
</script>

</body>

</html>
