<%@ Page Title="" Language="C#" MasterPageFile="~/Other.Master" AutoEventWireup="true" CodeBehind="VisaOrder.aspx.cs" Inherits="TravelAgent.Web.visa.VisaOrder" %>
 <%@ MasterType VirtualPath="~/Other.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="/js/Validform.js" type="text/javascript"></script>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/visa.css" rel="stylesheet" type="text/css" />
    <script src="/js/widgetlogin.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript">
    $(function() {
        $("#submitVisaOrder").Validform({
            tiptype: 3,
            callback: function(data) {
                if ($.cookie('uid') != null) {
                    //提交表单
                    submit();
                } else {
                    editWidget("/member/QuickLogin.aspx?actionName=visaOrderSubmit&tel=" + $("#mobile").val());

                }
                return false;
            }
        });
        $("#personcount").keyup(function() {
            $("#totalprice").val(parseInt($("#visa_price").val())*parseInt($(this).val()));
        })
    })
    //提交
    function submit() {
        $.ajax({
            url: "/dataDeal/AddVisaOrder.aspx",
            data: { "visa_id": $("#visa_id").val(), "visa_price": $("#visa_price").val(), "realname": $("#realname").val(), "sex": $("#sex").val(), "mobile": $("#mobile").val(), "email": $("#email").val(), "personcount": $("#personcount").val(), "godate": $("#godate").val(), "remark": $("#remark").val() },
            type: "post",
            success: function(msg) {
                if (msg == "success") {
                    alert("您的签证订单信息已提交，请耐心等待工作人员审核并与您联系！");
                    location.href = location.href + "&date=" + new Date().toUTCString();
                    //$('#submitVisaOrder')[0].reset();
                }
                else {
                    location.href = "/Opr.aspx?t=error&msg=opr";
                }
            },
            error: function() {
                location.href = "/Opr.aspx?t=error&msg=opr";
            }
        });
    }
 </script>
<!--位置导航-->
                <div class="place1">
                        <div class="placeL">   
                                <span>您当前位置：</span>
                                <a href="/">首页</a>>
                                <a href="/visa/Default.aspx">签证办理</a>>
                                <a href="/visa_<%=visa.countryId %>.html"><%=visa.countryName %>签证办理</a>>
                                <i><%=visa.visaName %>预订</i>
                        </div>
                </div>

                <!--预订-->
                <div class="book">
                        <div class="book_title">
                                <div class="book_pic">
                                        <img src="<%=visa.picurl %>" alt="<%=visa.visaName %>预订" />
                                </div>
                                <div class="book_con">
                                        <p><i>签证国家及类别：</i><strong><%=visa.visaName %></strong></p>
                                        <p><span>预计工作日：<%=visa.dealTime %></span><span>服务费：<big><%=visa.price %></big>元/人(包含签证费用)</span></p>
                                </div>
                        </div>
                        <form action="" method="post" id="submitVisaOrder">
                                <input id="visa_id" name="visa_id" type="hidden" value="<%=visa.id %>" />
                                <input id="visa_price" name="visa_price" type="hidden" value="<%=visa.price %>" />
                                <ul class="book_go">

                                        <h2>预订信息（为确保成功办理签证，请填写真实信息)</h2>
                                        <li class="one"><span>姓名：</span><input id="realname" type="text" name="realname" datatype="*" value="<%=club==null?"":club.trueName %>" class="qzleft-cor" /></li>
                                        <li class="two">
                                                <span>性别：</span>
                                                <select id="sex" name="sex" datatype="*" class="qz-width">
                                                        <%--<option selected="selected" value="1">男</option>
                                                        <option value="0">女</option>--%>
                                                        <%=ShowOptionSex()%>
                                                </select>
                                        </li>

                                        <li class="one"><span>手机：</span><input id="mobile" type="text" datatype="m" name="mobile" value="<%=club==null?"":club.clubMobile %>" class="qzleft-cor" maxlength="11" /></li>
                                        <li class="two"><span>邮箱：</span><input id="email" type="text" datatype="e" name="email" value="<%=club==null?"":club.clubEmail %>" class="qzleft-cor" /></li>

                                        <li class="one"><span>人数：</span><input id="personcount" type="text" datatype="*" name="personcount" value="" class="qzleft-cor" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" /></li>
                                        <li class="four"><span>预计出行日期：</span><input id="godate" readonly="readonly" type="text" name="godate" value="" onfocus="WdatePicker({doubleCalendar: true, dateFmt: 'yyyy-MM-dd'})" datatype="*" class="qzleft-cor" /></li>
                                        <li class="one"><span>总金额：</span><input id="totalprice" type="text" name="totalprice" value="" class="qzleft-cor" readonly="readonly" /></li>
                                        <li class="three"><span>备注：</span><textarea id="remark" name="remark" cols="45" rows="5" style="width:542px; height:90px; float: left;"></textarea></li>

                                </ul>

                                <div class="mianze">
                                        <p style="color:#ff6600;  font-size: 14px; ">免责声明：</p>
                                        <p>您所申请的签证能否成功，取决于相关国家使领馆签证官的直接审核结果;若最终发生拒签状况，申请人应自然接受此结果,同时放弃追究本公司任何责任的权利。</p>
                                        <p style="padding:15px 10px 0px 350px">
                                                <span style=" cursor:pointer;">
                                                        <%--<img id="submit_btn" src="/images/order.gif" width="144" height="39" border="0" style="width: 139px; height: 38px;" />--%>
                                                        <input type="submit" value="" style="width:144px;height:39px;border:none;background:url(/images/order.gif) left top no-repeat;" />
                                                </span>
                                        </p>
                                </div>
                        </form>



                </div>
</asp:Content>
