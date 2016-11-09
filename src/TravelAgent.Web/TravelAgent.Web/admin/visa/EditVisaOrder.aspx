<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditVisaOrder.aspx.cs" Inherits="TravelAgent.Web.admin.visa.EditVisaOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/admin/js/jquery.js"></script>
    <%--<script type="text/javascript" src="/js/jquery.validate.min.js"></script>--%>
    <%--<script type="text/javascript" src="/js/validate.js"></script>--%>
    <%--<script type="text/javascript" src="/js/jquery.form.js"></script>--%>
    <script type="text/javascript" src="../js/select-ui.min.js"></script>
    <script type="text/javascript">
        function checknum(obj) {
            var re = /^((-)?\d+)?$/;
            //var re = /^-?[1-9]*(.d*)?$|^-?0(.d*)?$/;
            if (!re.test(obj.value)) {
                alert("请输入合法的数字！");
                obj.value = "";
                obj.focus();
                return false;
            }
        }
        $(function() {
            $(".select1").uedSelect({
                width: 150
            });
            $("#txtJiaJian").blur(function() {
                checknum($(this)[0]);
            })
            $("#txtuserPoints").blur(function() {
                checknum($(this)[0]);
            })
            $("#btnSave").click(function() {
                if ($("#ddlState").val() == "0") {
                    alert("请选择订单状态");
                    return false;
                }
                else
                {
                    if($("#ddlState").val() == "5")
                    {
                        if($("#ddlPayType").val()=="0")
                        {
                            alert("请选择支付方式！");
                            return false;
                        }
                    }
                }
                if(confirm("确认操作该订单吗？"))
                {
                    $(this).attr("disabled", "disabled");
                    $(this).val("正在操作中...");
                    $.ajax({
                        type: "POST",
                        url: "/admin/data/Order.aspx",
                        cache: false,
                        dataType: "text",
                        data: { orderid: <%=orderid %>, subprice: $("#txtJiaJian").val(),usepoints:$("#txtuserPoints").val(),donatepoints:$("#hddonate").val(),orderstate:$("#ddlState").val(),oprremark:$("#txtRemark").val(),paytype:$("#ddlPayType").val(),ordercode:$("#hdordercode").val() },
                        success: function(msg) {
                            $("#btnSave").attr("disabled", "");
                            $("#btnSave").removeAttr("disabled");
                            $("#btnSave").val("确定操作");
                            //提示删除成功消息
                            if (msg == "true") {
                                if(parent.document.getElementById("btnQuery")!=null)
                                {
                                    parent.document.getElementById("btnQuery").click();
                                }
                                else
                                {
                                    parent.location.href=parent.location.href;
                                }

                            }
                            else if (msg == "false") {
                                alert("操作失败，请联系管理员！");
                            }
                        }
                    })
                    return true;
                }
                else
                {
                    return false;
                }
            })
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="0" cellpadding="0" cellspacing="0" style="width:100%;" class="formtable">
            <tr>
                <td style="text-align:left; color:#056dae;background: #F5F5F5; font-weight:bold" 
                    colspan="4">订单信息 <span class="red">*</span>：</td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5;  width:15%;">签证名称 ：</td>
                <td colspan="3">
                    <asp:Label ID="lblVisaName" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">订单编号 ：</td>
                <td>
                    <asp:Label ID="lblOrderCode" runat="server" Text=""></asp:Label>
                </td>
                <td style="text-align:right; color:#056dae;background: #F5F5F5;  width:18%;">数量：</td>
                <td>
                    <asp:Label ID="lblPeopleNum" runat="server" Text=""></asp:Label>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">下单时间 ：</td>
                <td>
                    <asp:Label ID="lblOrderDate" runat="server" Text=""></asp:Label>
                </td>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">预计出游日期：</td>
                <td>
                    <asp:Label ID="lblTravelDate" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">订单备注：</td>
                <td colspan="3">
                    <asp:Label ID="lblOrderRemark" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align:left; color:#056dae;background: #F5F5F5;  font-weight:bold" colspan="4">预订信息  <span class="red">*</span>：</td>
            </tr>
            
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">联系人 ：</td>
                <td>
                    <asp:Label ID="lblLinkName" runat="server" Text=""></asp:Label>
                </td>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">会员信息：</td>
                <td>
                    <asp:Label ID="lblClubInfo" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">手机 ：</td>
                <td>
                    <asp:Label ID="lblTel" runat="server" Text=""></asp:Label>
                </td>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">邮件：</td>
                <td>
                    <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                </td>
            </tr>
           <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">性别 ：</td>
                <td>
                    <asp:Label ID="lblSex" runat="server" Text=""></asp:Label>
                </td>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align:left; color:#056dae;background: #F5F5F5;  font-weight:bold" colspan="4">费用信息 <span class="red">*</span>：</td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">订单金额：</td>
                <td>
                    <asp:Label ID="lblOrderTotalPrice" runat="server" Text=""></asp:Label>
                </td>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">
                    加减额：</td>
                <td>
                    <input id="txtJiaJian" name="txtJiaJian" type="text" class="dfinput" style="width:60px" runat="server" /> 元</td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">积分使用：</td>
                <td>
                    <input id="txtuserPoints" name="txtuserPoints" type="text" class="dfinput" runat="server" style=" width:60px;" /> （1分兑换1元）</td>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">
                    应付总金额：</td>
                <td>
                    <asp:Label ID="lblPayCost" runat="server" Text="" Font-Bold="true" ForeColor="Red"></asp:Label>元，(订单金额-积分使用+加减价)
                </td>
            </tr>
            <tr>
                <td style="text-align: left; color:#056dae;background: #F5F5F5; font-weight:bold" colspan="4">
                     支付信息<span class="red"> *</span>：</td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">支付状态：</td>
                <td>
                    <asp:Label ID="lblPayState" runat="server" Text=""></asp:Label>
                </td>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">
                    支付方式：</td>
                <td>
                    <asp:DropDownList ID="ddlPayType" runat="server" CssClass="select1">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="text-align: left; color:#056dae;background: #F5F5F5; font-weight:bold" colspan="4">订单操作<span class="red"> *</span>：</td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">订单状态：</td>
                <td>
                    <asp:DropDownList ID="ddlState" runat="server" CssClass="select1">
                    </asp:DropDownList>
                </td>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">
                    操作备注：</td>
                <td>
                    <textarea id="txtRemark" cols="40" name="txtRemark" rows="4" style=" border:1px solid #000" runat="server"></textarea></td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; width:150px; height:80px;"></td>
                <td colspan="3">
                    <input id="btnSave" type="button" value="确定操作" class="btn" /></td>
            </tr>
     </table>
    </div>
    <asp:HiddenField ID="hddonate" runat="server" />
    <asp:HiddenField ID="hdordercode" runat="server" />
    </form>
</body>
</html>
