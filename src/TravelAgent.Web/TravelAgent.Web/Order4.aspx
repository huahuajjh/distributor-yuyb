<%@ Page Title="" Language="C#" MasterPageFile="~/Other.Master" AutoEventWireup="true" CodeBehind="Order4.aspx.cs" Inherits="TravelAgent.Web.Order4" %>
<%@ MasterType VirtualPath="~/Other.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" rel="stylesheet" href="/css/style.css"/>
<link href="/css/order.css" rel="stylesheet" type="text/css" />
<script src="/js/jquery-1.7.2.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--预订部分开始-->
                <div id="page">
                        <div id="xs2" class="xs" style="text-align: center; display: none;">
                                <img src="/images/loading.gif" />
                                <br />
                                正在提交，请稍后。。。
                        </div>
                        <div class="order">
                                <div id="page">
                                                        <form id="formpay" method="post" action="/PayApi/Submit.aspx" target="_blank">
                                                                <div class="order">
                                                                        <!--订单步骤 START-->
                                                                        <div class="orderStep">
                                                                                <ul class="step4">
                                                                                        <li>填写订单</li>
                                                                                        <li>填写游客信息</li>
                                                                                        <li>核对订单</li>
                                                                                        <li class="on">付款</li>
                                                                                        <li>预订成功</li>
                                                                                </ul>
                                                                        </div>
                                                                        <!--订单步骤 END-->
                                                                        <div class="orderWrap">
                                                                                <div class="orderPay">
                                                                                        <div class="orderPayInfo">
                                                                                                <div class="hd">订单信息</div>
                                                                                                <div class="bd">
                                                                                                        <table width="100%" id="tbLine">
                                                                                                                <tr>
                                                                                                                        <td>订单号：<%=strOrdercode%></td>
                                                                                                                        <td>订单名称：<%=strOrderName %></td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                        <td>下单时间：<%=orderdate%></td>
                                                                                                                        <td>应付总额：<i>¥</i><b id="bprice"><%=intTotalPrice %></b></td>
                                                                                                                </tr>
                                                                                                        </table>
                                                                                                </div>
                                                                                        </div>

                                                                                </div>
                                                                                <div class="orderPayBank">
                                                                                        <div class="zffs_sll">
                                                                                                <div class="zffsmain_sll">
                                                                                                        <div class="zffsmaintitle_sll">
                                                                                                                <div class="titleft_sll">
                                                                                                                        <ul id="tags">
                                                                                                                                <li class="nowa_sll"><a href="javascript:void(0);" onclick="selectTag('tagContent0', this)">
                                                                                                                                                在线支付</a></li>
                                                                                                                                <li><a href="javascript:void(0);" onclick="selectTag('tagContent1', this)">银行汇款</a></li>
                                                                                                                                <li><a href="javascript:void(0);" onclick="selectTag('tagContent2', this)">现金付款</a></li>
                                                                                                                        </ul>
                                                                                                                </div>
                                                                                                        </div>
                                                                                                        <div id="tagContent0" class="zfffcontent_sll" style="display: block;">
                                                                                                                <!--付款部分开始-->

                                                                                                                <div class="zftable_sll">

                                                                                                                        <div class="quickBank">
                                                                                                                                <%--<p class="quickBankHd">支付平台 </p>--%>
                                                                                                                                <%--<p id="sptip" class="colorhe_sll">支持信用卡和储蓄卡在线支付</p>--%>
                                                                                                                                <div class="quickBankBd">
                                                                                                                                        <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                                                                                                                                <tbody>
                                                                                                                                                        <tr>
                                                                                                                                                                <%=ShowPay()%>
                                                                                                                                                                <td class="padleft5_sll"></td>
                                                                                                                                                                <td></td>
                                                                                                                                                                <td class="padleft5_sll"></td>
                                                                                                                                                                <td></td>
                                                                                                                                                        </tr>
                                                                                                                                                </tbody>
                                                                                                                                        </table>
                                                                                                                                </div>
                                                                                                                        </div>
                                                                                                                </div>
                                                                                                                <!--付款部分结束-->
                                                                                                                <div class="zfbut_sll">
                                                                                                                        <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                                                                                                                 <tr>
                                                                                                                                        <td colspan="2">
                                                                                                                                            <input id="chkUsePoints" name="chkUsePoints" type="checkbox" /> 是否使用积分充抵（当前订单最高可使用<span class="cdyellow" id="spanMaxPoints"> <%=Line.UsePoints %> </span>分，您当前可使用的积分余额为<span class="cdyellow" id="spanCurrentPoints"> <%=club.currentPoints %> </span>分）</td>
                                                                                                                                </tr>
                                                                                                                                <tr id="trPoints" style="display:none">
                                                                                                                                        <td style=" width:40px">本次充抵积分：</td>
                                                                                                                                        <td><input type="text" id="txt_points" name="txt_points"  class="num_input orange_border" value="" onkeyup="this.value=this.value.replace(/\D/g,'');"  /> 分，可以充抵<span class="cdyellow" id="spanPointCost"></span>元</td>
                                                                                                                                </tr>
                                                                                                                                <tr>
                                                                                                                                        <td style=" width:40px">本次支付金额：</td>
                                                                                                                                        <td>
                                                                                                                                                <input type="text" id="channel_amount" name="channel_amount"  class="num_input orange_border" value="<%=intTotalPrice %>" readonly="readonly" /> 元
                                                                                                                                        </td>
                                                                                                                                </tr>
                                                                                                                                <tr>
                                                                                                                                        <td></td>
                                                                                                                                        <td>
                                                                                                                                            <%--<input id="btnSubmit" type="submit" value="" style="background:url('/images/order6.gif') no-repeat; width:121px; height:38px;border:none;" />--%>
                                                                                                                                            <%=ShowPayButton() %>
                                                                                                                                        </td>
                                                                                                                                </tr>
                                                                                                                        </table>
                                                                                                                </div>
                                                                                                                <div class="orderPayTip orderPayTipTrim1">
                                                                                                                        <div class="d1">
                                                                                                                                <p class="pT">
                                                                                                                                        温馨提示</p>
                                                                                                                                <p class="p2">
                                                                                                                                        请尽快完成付款，付款完成后。相关客服会尽快联系您确定出游事宜；<br />
                                                                                                                                        付款页面没有打开，请设置您的浏览器为允许弹出；<br />
                                                                                                                                        如您的银行卡或账户已被扣款，订单状态仍为"待付款"，请联系网站客服为您确认付款。

                                                                                                                                </p>
                                                                                                                                <p class="p3">
                                                                                                                                        客服电话：<b><%=Master.webinfo.WebTel %></b>
                                                                                                                                </p>
                                                                                                                        </div>
                                                                                                                        <div class="clearfix">
                                                                                                                        </div>
                                                                                                                </div>
                                                                                                        </div>
                                                                                                        <!--对公汇款-->
                                                                                                        <div id="tagContent1" class="zfffcontent_sll" style="display: none;">
                                                                                                                <p class="colorhe_sll">请选择汇款银行后及时汇款，并保留汇款成功后的汇款底单，以便查询</p>
                                                                                                                <div class="zhxx_sll zhxx_sllTrim1">
                                                                                                                        
                                                                                                                </div>
                                                                                                        </div>
                                                                                                        <div id="tagContent2" class="zfffcontent_sll" style="display: none;">
                                                                                                                <p class="colorhe_sll">门市签约付款</p>
                                                                                                                <div class="zhxx_sll zhxx_sllTrim1">
                                                                                                                        
                                                                                                                </div>
                                                                                                        </div>
                                                                                                </div>
                                                                                        </div>
                                                                                </div>
                                                                        </div>
                                                                </div>
                                                                <input type="hidden" id="ordername" name="ordername" value="<%=strOrderName %>"  />
                                                                <input type="hidden" id="ordercode" name="ordercode" value="<%=strOrdercode %>"  />
                                                                <input type="hidden" id="order_id" name="order_id" value="<%=oid %>"  />
                                                                <input type="hidden" id="hdPayType" name="hdPayType" value="" />
                                                                <input type="hidden" id="hdTag" name="hdTag" value="<%=strTag %>" />
                                                                <input type="hidden" id="hddonatePoints" name="hddonatePoints" value="<%=donatePoints %>" />   
                                                        </form>
                                                        <!---弹出付款提示 START--->
                                                        <div class="OrderStatusPop jqmWindow" id="OrderStatusPop">
                                                                <div class="close jqmClose" id="closeNote"></div>
                                                                <div class="hd">付款确认</div>
                                                                <div class="bd">
                                                                        <p class="p1">完成付款后请根据您的情况点击下面按钮</p>
                                                                        <p class="p2">
                                                                                <%--<a href="javascript:GetPayStatus('Y', 'B9261467746290')"
                                                                                   class="a1">已完成付款</a><a href="javascript:GetPayStatus('N', 'B9261467746290')"
                                                                                   class="a2" style="cursor: pointer;">付款不成功，重新支付</a>--%>
                                                                                   <a href="javascript:GetPayGoto('Y', '<%=strTag %>','<%=oid %>')"
                                                                                   class="a1">已完成付款</a><a href="javascript:GetPayGoto('N', '<%=strTag %>','<%=oid %>')"
                                                                                   class="a2" style="cursor: pointer;">付款不成功，重新支付</a>
                                                                        </p>
                                                                </div>
                                                        </div>
                                                        <!---弹出付款提示 END--->
                                                        <script src="/js/jqModal.js" type="text/javascript"></script>
                                                        <script src="/js/tooltip.js" type="text/javascript"></script>
                                                        <script src="/js/order.js" type="text/javascript"></script>
                                                        <script src="/js/four_proc.js" type="text/javascript"></script>
                                                </div>                        </div>
                </div>
                <script type="text/javascript">
                    
                </script>
</asp:Content>
