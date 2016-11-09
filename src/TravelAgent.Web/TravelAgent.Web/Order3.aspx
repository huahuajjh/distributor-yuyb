<%@ Page Title="" Language="C#" MasterPageFile="~/Other.Master" AutoEventWireup="true" CodeBehind="Order3.aspx.cs" Inherits="TravelAgent.Web.Order3" %>
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
                                                        <ul class="step3">
                                                                <li>填写订单</li>
                                                                <li>填写游客信息</li>
                                                                <li class="on">核对订单</li>
                                                                <li>付款</li>
                                                                <li>预订成功</li>
                                                        </ul>
                                                </div>
                                                <!--订单步骤 END-->
                                                <form id="three_form" method="post" action="">
                                                        <div class="orderWrap">
                                                                <div class="checkOrder">
                                                                        <h2>订单信息确认</h2>
                                                                        <!--线路信息 START-->
                                                                        <div class="checkOrderInfo">
                                                                                <div class="hd">线路信息</div>
                                                                                <div class="bd">
                                                                                        <table width="100%" cellpadding="0" cellspacing="0">
                                                                                                <tr>
                                                                                                        <th class="lt" width="10%">线路编号</th>
                                                                                                        <th width="45%">线路名称</th>
                                                                                                        <th width="10%">出发城市</th>
                                                                                                        <th width="10%">出发时间</th>
                                                                                                        <th width="20%">出游人数</th>
                                                                                                        <th width="10%">小计</th>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                        <td class="lt">
                                                                                                                L<%=Line.Id.ToString().PadLeft(6, '0')%>                                                                                                        </td>
                                                                                                        <td class="lt" style="text-align: center;">
                                                                                                                <a class="a1" href="/line/<%=Line.Id %>.html" target="_blank"><%=Line.LineName %></a>
                                                                                                        </td>
                                                                                                        <td><%=ShowCityName(Line.CityId) %></td>
                                                                                                        <td><%=order.TravelDate %></td>
                                                                                                        <td>
                                                                                                                <%=order.adultNumber %>成人 × ¥<%=order.adultPrice %><br />
                                                                                                                <%=order.childNumber %>儿童 × ¥<%=order.childPrice %>                                                                                                        </td>
                                                                                                        <td>
                                                                                                                <b>¥</b><b id="proTotal"><%=order.orderPrice %></b>
                                                                                                        </td>
                                                                                                </tr>
                                                                                        </table>
                                                                                </div>
                                                                                <!--线路信息 END-->
                                                                                <!--航班信息 start -->
                                                                                                                                                                <!--航班信息 end-->
                                                                                <!--酒店信息 start -->
                                                                                                                                                                <!--酒店信息 end-->
                                                                                <!--上车地点信息 START-->
                                                                                                                                                                <!--上车地点信息 End-->
                                                                                <!--附加产品信息 START-->
                                                                                                                                                                <!--附加产品信息 END-->
                                                                                <!--游客及联系人信息 START-->
                                                                                <div class="hd">游客及联系人信息</div>
                                                                                <div class="bd">
                                                                                                                                                                                        <table width="100%" cellpadding="0" cellspacing="0" id="table_client_ch">
                                                                                                        <tr>
                                                                                                                <th class="lt" width="10%">游客类型</th>
                                                                                                                <th width="20%">真实姓名</th>
                                                                                                                <th width="15%">证件类型</th>
                                                                                                                <th width="30%">证件号码</th>
                                                                                                                <th width="5%">性别</th>
                                                                                                                <th width="10%">出生年月</th>
                                                                                                                <th width="10%">手机</th>
                                                                                                        </tr>
                                                                                                       <%=BindTourist(order.Id)%>                                                                               
                                                                                                       </table>                                                                                
                                                                                                      </div>
                                                                                <!--游客及联系人信息 END-->
                                                                                <!--联系人信息 START-->
                                                                                <div class="hd hdTrim1">
                                                                                        联系人信息及配送方式</div>
                                                                                <div class="bd">
                                                                                        <table width="100%" cellpadding="0" cellspacing="0">
                                                                                                <tr>
                                                                                                        <th width="25%">联系人姓名：</th>
                                                                                                        <th width="25%">手机号码：</th>
                                                                                                        <th width="25%">电子邮箱：</th>
                                                                                                        <th width="25%">固定电话：</th>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                        <td><%=order.contactName %></td>
                                                                                                        <td><%=order.contactMobile %></td>
                                                                                                        <td><%=order.contactEmail %></td>
                                                                                                        <td><%=order.contactTelephone %></td>
                                                                                                </tr>
                                                                                        </table>

                                                                                </div>
                                                                                <!--联系人信息 END-->
                                                                        </div>
                                                               <%--         <h2>发票信息<span style="color: #999999; font-weight: lighter; margin-left: 5px;">如需开具发票请准确填写、核对发票信息。<a id="fapiao"></a></span></h2>
                                                                        <div class="checkOrderInfo">
                                                                                <div class="ui_addresstip">
                                                                                        <input type="checkbox" class="J_selYouHomeBtn" id="cbInvoice" />
                                                                                        <span class="ui_send">是否开发票</span>
                                                                                </div>
                                                                                <div class="ui_addressinfo J_selYouHome">
                                                                                        <dl>
                                                                                                <dt class="add_title">发票抬头：</dt>
                                                                                                <dd class="add_taitou">
                                                                                                        <input type="text" class="taitou_txt" id="txtTaitou" maxlength="100" /><span style="color: Red; display: none">必填</span><label class="taitou_label">发票抬头必须为个人姓名或公司名称</label>
                                                                                                </dd>
                                                                                                <dd class="clearfix">
                                                                                                </dd>
                                                                                        </dl>
                                                                                        <dl>
                                                                                                <dt class="add_title">发票内容：</dt>
                                                                                                <dd class="add_info">
                                                                                                        <select id="selectInvoiceContent">
                                                                                                                <option>旅游费</option>
                                                                                                        </select>
                                                                                                        <span style="color: #999999; font-weight: lighter; margin-left: 5px;">发票将于行程结束后一周内以平信的方式寄出</span>
                                                                                                </dd>
                                                                                                <dd class="clearfix">
                                                                                                </dd>
                                                                                        </dl>
                                                                                        <dl>
                                                                                                <dt class="add_title">收件人：</dt>
                                                                                                <dd class="add_change">
                                                                                                        <input type="radio" name="addtype" data_value="1" class="J_changeType" checked="checked" /><label>与联系人相同</label>
                                                                                                        <input type="radio" name="addtype" data_value="2" class="J_changeType" /><label>与联系人不同</label>
                                                                                                </dd>
                                                                                                <dd class="clearfix">
                                                                                                </dd>
                                                                                                <dd style="display: none;" class="add_user J_changeCon">
                                                                                                        <input type="text" placeholder="姓名" class="inputname J_place" id="txtConsigneeName"
                                                                                                               maxlength="10" /><span style="color: Red; display: none">必填</span>
                                                                                                        <input type="text" placeholder="手机号码" class="inputphone J_place" id="txtConsigneeMobile"
                                                                                                               maxlength="11" onkeyup="this.value = this.value.replace(/D/g, '')" /><span style="color: Red;
                                                                                                               display: none">必填</span>
                                                                                                </dd>
                                                                                                <dd class="clearfix">
                                                                                                </dd>
                                                                                        </dl>
                                                                                        <dl>
                                                                                                <dt class="add_title">寄送地址：</dt>
                                                                                                <dd class="add_area">
                                                                                                        <select name="province">
                                                                                                        </select><select name="city"></select><select name="area"></select>

                                                                                                        <input type="text" placeholder="邮编（选填）" class="inputzip J_place" id="txtPostCode"
                                                                                                               maxlength="6" onkeyup="value = value.replace(/D/g, '')" />
                                                                                                </dd>
                                                                                                <dd class="add_detail">
                                                                                                        <input type="text" placeholder="详细街道地址" class="inputadd J_place" id="txtDetailAddress"
                                                                                                               maxlength="70" value="" /><span style="color: Red; display: none">必填</span>
                                                                                                </dd>
                                                                                                <dd class="clearfix"></dd>
                                                                                        </dl>
                                                                                </div>
                                                                        </div>--%>
                                                                        <h2 style="margin-top: 10px;">结算信息确认<span> 请仔细阅读合同范本，具体出游信息以您填写的订单为准，付款完成后您可在"我的订单"下载包含完整订单信息的旅游合同</span></h2>
                                                                        <div id="orderProtocol" class="orderProtocol">
                                                                                <div class="hd">
                                                                                        <ul>
                                                                                                <li class="on"><a href="#">合同范本 </a></li>
                                                                                                <li><a href="#">费用说明 </a></li>
                                                                                                <li><a href="#">预订须知 </a></li>
                                                                                                <li><a href="#">出游提醒 </a></li>
                                                                                        </ul>
                                                                                </div>
                                                                                <div class="bd">
                                                                                        <div class="item" style="display: block;overflow: hidden;">
                                                                                               <%=strAgreeMent%>                                                                                
                                                                                       </div>
                                                                                        <div class="item"><%=Line.LineCost %></div>
                                                                                        <div class="item"><%=Line.OrderTips %></div>
                                                                                        <div class="item"><%=Line.TravelNotice %></div>
                                                                                </div>
                                                                                <div class="clearfix"></div>
                                                                        </div>
                                                                </div>

                                                                <div class="jiesuanInfoSum" style="margin-right: 25px">
                                                                        <p style="margin-bottom: 5px;">旅游产品总价：<b class="b2" style="padding-right: 10px; font-size: 14px;">¥<%=order.orderPrice %></b></p>
                                                                        <p style="margin-bottom: 5px;">附加产品总价：<b class="b2" style="padding-right: 10px; font-size: 14px;">¥<%=order.attachPrice %></b></p>
                                                                        <b class="b1">应付总额</b>：<b class="b2" style="padding-right: 0px;">¥</b><b class="b2" id="b_prepayment"><%=(order.orderPrice+order.attachPrice)%></b>
                                                                </div>
                                                                <div class="checkOrderBtn">
                                                                        <div class="notice_check">
                                                                                <input type="checkbox" id="agree_check" style="vertical-align: middle;margin-right: 5px;" /> <label style='vertical-align: middle;' for="agree_check">我已阅读并接受以上合同条款、补充条款和其他所有内容</label>
                                                                                <div id="commonTip">请仔细阅读合同条款并在下方打勾</div>
                                                                        </div>
                                                             <input type="button" id="btn_Next" style="background: url(/images/newordertijiao.png);border-width: 0px; cursor: pointer; width: 121px; height: 38px;" />                                                                </div>
                                                        </div>

                                                        <input type="hidden" id="txtHiddenPrePayMent" name="txtHiddenPrePayMent" value="" />
                                                        <input type="hidden" id="txtHiddenOrderId" name="txtHiddenOrderId" value='<%=order.ordercode %>' />
                                                        <input type="hidden" id="hiddenInvoice" name="hiddenInvoice" value="" />
                                                        <input type="hidden" id="hiddenUserName" value="" />
                                                        <input type="hidden" id="hiddenMobile" value="" />
                                                        <input type='hidden' id="txtHiddenFlag" name='txtHiddenFlag' value="" />

                                                </form>
                                                <script src="/js/tooltip.js" type="text/javascript"></script>
                                                <script src="/js/order.js" type="text/javascript"></script>
                                                <script src="/js/three_proc.js" type="text/javascript"></script>
                                                <%--<script src="/js/pcasunzip.js" type="text/javascript"></script>
                                                <script type="text/javascript">
                        new PCAS("province", "city", "area", "江苏省", "南京市");
                                                </script>--%>                        </div>
                </div>
</asp:Content>
