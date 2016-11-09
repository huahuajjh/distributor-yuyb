<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GroupSMS.aspx.cs" Inherits="TravelAgent.Web.admin.club.GroupSMS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="/js/jquery.validate.min.js"></script>
    <script type="text/javascript" src="/js/validate.js"></script>
    <script type="text/javascript" src="/js/jquery.form.js"></script>
    <script type="text/javascript" src="../js/select-ui.min.js"></script>
    <script type="text/javascript" src="/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        $(function() {
            $(".select1").uedSelect({
                width: 100
            });

            $("#ddlRule").change(function() {
                $("tr[class='trfanwei'][rel='" + $(this).val() + "']").show();
                $("tr[class='trfanwei'][rel!='" + $(this).val() + "']").hide();
            })
            $("input[name^='chkClubClass']").click(function() {
                var valuelist = ""; //保存checkbox选中值
                $("input[name^='chkClubClass']").each(function() {
                    if (this.checked) {
                        valuelist += $(this).parent().attr("alt") + ",";
                    }
                })
                if (valuelist.length > 0) {
                    //得到选中的checkbox值序列,结果为400,398
                    valuelist = valuelist.substring(0, valuelist.length - 1);
                }
                $("#hidClubClass").val(valuelist);
            })
            $("#btnSave").click(function() {
                var rule = $("#ddlRule").val();
                if (rule == "1") {
                    if ($.trim($("#txtMobiles").val()) == "") {
                        alert("请输入手机号码！");
                        return false;
                    }
                }
                else if (rule == "2") {
                    if ($.trim($("#txtStartDate").val()) == "" && $.trim($("#txtEndDate").val()) == "") {
                        alert("请输入日期范围！");
                        return false;
                    }
                }
                else if (rule == "3") {
                    if ($("#hidClubClass").val() == "") {
                        alert("请选择级别范围！");
                        return false;
                    }
                }
                if ($.trim($("#txtSMSContent").val()) == "") {
                    alert("请输入短信内容！");
                    return false;
                }
//                $("#__VIEWSTATE").remove(); //这两句最重要
//                $("#__EVENTVALIDATION").remove();
//                $(this).attr("disabled", "disabled");
//                $(this).val("正在发送中...");
//                var options = {
//                    url: "../data/SMS.aspx?date=" + new Date().toUTCString(),
//                    type: 'POST',
//                    //beforeSubmit: Validate,
//                    success: function(responseText, statusText) {
//                        $("#btnSave").attr("disabled", "");
//                        $("#btnSave").removeAttr("disabled");
//                        $("#btnSave").val("确定提交");
//                        if (responseText.indexOf("true") >= 0) {
//                            parent.jsprint("确定提交！", "", "Success");
//                            return false;
//                        }
//                        else {
//                            parent.jsprint("提交失败！", "", "Error");
//                        }
//                    },
//                    error: function(data) {
//                        parent.jsprint("提交失败！", "", "Error");
//                    }
//                };
//                $("#form1").ajaxSubmit(options);
//                return false;
            })
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">会员管理</a></li>
    <li><a href="#">短信群发</a></li>
    </ul>
    </div>
    <div>
    <table border="0" cellpadding="0" cellspacing="0" style="width:100%;" class="formtable">
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5;width:15%; ">选择类别 ：</td>
                <td style=" padding-top:10px;">
                    <asp:DropDownList ID="ddlRule" runat="server" CssClass="select1">
                        <asp:ListItem Value="1">指定会员</asp:ListItem>
                        <asp:ListItem Value="2">注册日期</asp:ListItem>
                        <asp:ListItem Value="3">所有会员</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr class="trfanwei" rel="1">
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">手机号码 ：</td>
                <td><asp:TextBox ID="txtMobiles" runat="server" CssClass="dfinput" MaxLength="25" Width="400px"></asp:TextBox><span> 号码之间用英文逗号,间隔</span>
                </td>
            </tr>
            <tr style="display:none" class="trfanwei"  rel="2">
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">时间范围 ：</td>
                <td>
                    <asp:TextBox ID="txtStartDate" runat="server" CssClass="dfinput" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox> 至 <asp:TextBox ID="txtEndDate" runat="server" CssClass="dfinput" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox><span>仅限正常会员</span>
                </td>
            </tr>
            <tr style="display:none" class="trfanwei"  rel="3">
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">级别范围 ：</td>
                <td style=" line-height:30px;">
                    <asp:CheckBoxList ID="chkClubClass" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">短信内容 ：</td>
                <td>
                        <textarea name="txtSMSContent" runat="server" rows="7" cols="100" style=" width:400px; border:solid 1px #787a7b" id="txtSMSContent"></textarea>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; height:80px;"></td>
                <td><asp:Button ID="btnSave" runat="server" Text="确定提交" CssClass="btn" 
                        onclick="btnSave_Click" /></td>
            </tr>
     </table>
    </div>
    <input id="hidClubClass" name="hidClubClass" type="hidden" value="" runat="server" />
    </form>
</body>
</html>
