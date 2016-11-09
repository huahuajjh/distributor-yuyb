<%@ Page Title="" Language="C#" MasterPageFile="~/Other.Master" AutoEventWireup="true" CodeBehind="Order2.aspx.cs" Inherits="TravelAgent.Web.Order2" %>
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
                                <!--订单步骤 START-->
                                                <div class="orderStep">
                                                        <ul class="step2">
                                                                <li>填写订单</li>
                                                                <li class="on">填写游客信息</li>
                                                                <li>核对订单</li>
                                                                <li>付款</li>
                                                                <li>预订成功</li>
                                                        </ul>
                                                </div>
                                                <!--订单步骤 END-->
                                                <form id="two_form" action="" method="post">
                                                        <div class="orderWrap">
                                                                <div class="userInfo" style="overflow: visible;">
                                                                        <div class="notice">
                                                                                <b id="closeNotice"></b>
                                                                                1）您的订单需求已经提交，请在1个小时内完善出游人信息，逾期订单将被自动取消，如有不便敬请谅解。<br />
                                                                                2）按照旅游局最新规定，请您配合提供所有出行客人姓名，证件号码，联系电话，感谢您的配合！</div>
                                                                        <h2>
                                                                                填写游客信息 <span>请准确填写游客信息，以免在办理相关手续时发生问题。 </span><a id="userInfo"></a>
                                                                        </h2>
                                                                               <%=BindTouristInfo()%>
                                                                </div>
                                                                <div class="orderList">
                                                                        <div class="hd">
                                                                                <span></span>预订清单
                                                                        </div>
                                                                        <div class="bd">
                                                                                <ul id="J_orderDetail">
                                                                                        <li class="li1">
                                                                                                <p class="p1">旅游团费</p>
                                                                                                <p>
                                                                                                        <b>¥<s id="s_personall"><%=order.adultNumber * order.adultPrice%></s></b><span id="b_personnums"><%=order.adultNumber%></span>成人×¥<%=order.adultPrice%>                                                                                                </p>
                                                                                                <p>
                                                                                                        <b>¥<s id="s_childall"><%=order.childNumber * order.childPrice%></s></b><span id="b_childnums"><%=order.childNumber%></span>儿童×¥<%=order.childPrice%>                                                                                                </p>
                                                                                        </li>
                                                                                        <%--<li class="li2" id="AddPList" style="">
                                                                                                <p class="p1">附加产品</p>
                                                                                                <div class="last"><p>阳光境内旅行意外伤害保险</p><p><b>¥<s>30</s></b>3份×¥10</p></div>
                                                                                         </li>--%>
                                                                                         <%=BindAttach() %>                                                                  
                                                                                </ul>
                                                                                
                                                                                <div class="li4">
                                                                                        <p>
                                                                                                <strong>应付总额：</strong><label>¥<i id="offerPrice"><%=order.orderPrice+order.attachPrice%></i></label>
                                                                                        </p>
                                                                                        <input type="button" id="btn_Next_2" style="background-image: url(/images/order19.gif); float:right; border: none; cursor: pointer; width: 121px; height: 38px; margin: 10px 30px 10px 0px; display: inline; background-position: initial initial; background-repeat: no-repeat no-repeat;" />
                                                                                </div>
                                                                        </div>
                                                                </div>
                                                                <div class="clearfix">
                                                                </div>
                                                                <!-------- 按钮---------->
                                                                <div class="userInfoBtn" id="gl_submit" >
                                                                        <input type="button" id="btn_Next" style="background: url(/images/order19.gif);border-width: 0px; cursor: pointer; width: 121px; height: 38px;" />
                                                                </div>
                                                                <!-------- 按钮END---------->
                                                                <div class="clearfix"></div>
                                                        </div>
                                                        <!--订单ID-->
                                                        <input type="hidden" id="txtHiddenOrderId" name="txtHiddenOrderId" value="<%=order.ordercode %>" />
                                                        <input type="hidden" id="txtHiddenUList" name="txtHiddenUList" value='' />
                                                        <input type="hidden" id="hiddenGodate" name="hiddenGodate" value="<%=order.TravelDate %>" />
                                                        <!--产品类型（出境，国内）-->
                                                        <input type="hidden" id="txtHiddenMType" name="txtHiddenMType" value="<%=Line.DestId %>" />
                                                </form>
                                                <script src="/js/tooltip.js" type="text/javascript"></script>
                                                <script src="/js/order.js" type="text/javascript"></script>
                                                <script src="/js/jquery.maskedinput-1.3.min.js" type="text/javascript"></script>
                                                <script type="text/javascript">
                        $(function() {
                                //默认游客第一个为联系人
                                if ($("#txt_ch_person_RealName_0")) {
                                        $("#txt_ch_person_RealName_0").val("");
                                }
                                if ($("#txt_en_person_RealName_0")) {
                                        $("#txt_en_person_RealName_0").val("");
                                }
                                if ($("#txt_ch_person_Phone_0")) {
                                        $("#txt_ch_person_Phone_0").val("");
                                }
                                if ($("#txt_en_person_Phone_0")) {
                                        $("#txt_en_person_Phone_0").val("");
                                }
                                $('.tip').hover(function() {
                                        $(this).parents('.userType').find('select').hide();
                                }, function() {
                                        $(this).parents('.userType').find('select').show();
                                });
                        });
                                                </script>

                                                <script src="/js/two_proc.js" type="text/javascript"></script>                        </div>
                </div>
</asp:Content>
