<%@ Page Title="" Language="C#" MasterPageFile="~/Other.Master" AutoEventWireup="true" CodeBehind="CarOrder1.aspx.cs" Inherits="TravelAgent.Web.car.CarOrder1" %>
<%@ MasterType VirtualPath="~/Other.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link type="text/css" rel="stylesheet" href="/css/style.css"/>
<link href="/css/order.css" rel="stylesheet" type="text/css" />
<script src="/js/jquery-1.7.2.min.js" type="text/javascript"></script>
<script src="/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                                                                <li>选择产品</li>
                                                                <li class="on">确认订单</li>
                                                                <li>提交审核</li>
                                                                <li>在线付款</li>
                                                                <li>预订成功</li>
                                                        </ul>
                                                </div>
                                                <!--订单步骤 END-->
                                                <form id="one_form" action="" method="post">
                                                        <div class="orderWrap">
                                                                <div class="userInfo">
                                                                        <!--Start-->
                                                                        <h2>租车信息</h2>
                                                                        <div class="checkOrderInfo">
                                                                                <div class="hd">您预订的租车：</div>
                                                                                                                                                                        <div class="bd">
                                                                                                <table width="100%" cellspacing="0" cellpadding="0">
                                                                                                        <tbody>
                                                                                                                <tr>
                                                                                                                        <td class="ct" style="width:100px; font-weight:bold">参考价格：</td>
                                                                                                                        <td class="lt" colspan="2"><span style="color:#a7a8a9">门市价：</span><span style="text-decoration:line-through">¥<%=CarPriceModel.MemshiPrice%></span>，<span style="color:#a7a8a9">优惠价：</span><span style="color:Red">¥<%=CarPriceModel.XiaoshuPrice %></span></td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                        <td class="ct" style="width:100px; font-weight:bold">车辆信息：</td>
                                                                                                                        <td class="lt" colspan="2"><span style="color:#a7a8a9">车辆级别：</span><%=CarModel.ClassName %>，<span style="color:#a7a8a9">所属品牌：</span><%=CarModel.BrandName %>，<span style="color:#a7a8a9">座位数：</span><%=CarModel.Seat%>，<span style="color:#a7a8a9">变速器：</span><%=TravelAgent.Tool.EnumHelper.GetMemberName<TravelAgent.Tool.EnumSummary.CarBSQ>(CarPriceModel.BSQ) %>，<span style="color:#a7a8a9">厢数：</span><%=CarPriceModel.NumName%></td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                        <td class="ct" style="width:100px; font-weight:bold">预订须知：</td>
                                                                                                                        <td class="lt" colspan="2">
                                                                                                                        <%=CarModel.CarOrderTip %>
                                                                                                                        </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                        <td class="ct" style="width:100px; font-weight:bold">用车日期：</td>
                                                                                                                        <td class="lt" style="width:100px">
                                                                                                                            <div class="floatDiv">
                                                                                                                                <input id="txt_Yongche" class="input2 Wdate" maxlength="15" name="txt_Yongche" readonly="readonly" 
                                                                                                                                    value="<%=strYCDate %>" onfocus="WdatePicker({doubleCalendar:true,dateFmt:'yyyy-MM-dd'})" />
                                                                                                                            </div>
                                                                                                                        </td>
                                                                                                                        <td class="lt">
                                                                                                                            <div style="box-shadow: 1px 1px 3px #DDDDDD inset;border: 1px solid #ccc;width: 60px;">
                                                                                                                                <select class="type" name="timedot" id="timedot">
                                                                                                                                       <option value="0">0点</option>
                                                                                                                                        <option value="1">1点</option>
                                                                                                                                        <option value="2">2点</option>
                                                                                                                                        <option value="3">3点</option>
                                                                                                                                        <option value="4">4点</option>
                                                                                                                                        <option value="5">5点</option>
                                                                                                                                        <option value="6">6点</option>
                                                                                                                                        <option value="7">7点</option>
                                                                                                                                        <option value="8">8点</option>
                                                                                                                                        <option value="9">9点</option>
                                                                                                                                        <option value="10">10点</option>
                                                                                                                                        <option value="11">11点</option>
                                                                                                                                        <option value="12">12点</option>
                                                                                                                                        <option value="13">13点</option>
                                                                                                                                        <option value="14">14点</option>
                                                                                                                                        <option value="15">15点</option>
                                                                                                                                        <option value="16">16点</option>
                                                                                                                                        <option value="17">17点</option>
                                                                                                                                        <option value="18">18点</option>
                                                                                                                                        <option value="19">19点</option>
                                                                                                                                        <option value="20">20点</option>
                                                                                                                                        <option value="21">21点</option>
                                                                                                                                        <option value="22">22点</option>
                                                                                                                                        <option value="23">23点</option>
                                                                                                                                </select>
                                                                                                                            </div>
                                                                                                                        </td>
                                                                                                                </tr>
                                                                                                                <tr id="trHuan" runat="server">
                                                                                                                        <td class="ct" style="width:100px; font-weight:bold">还车日期：</td>
                                                                                                                        <td class="lt" style="width:100px">
                                                                                                                            <div class="floatDiv">
                                                                                                                                <input id="txt_Huanche" class="input2 Wdate" maxlength="15" name="txt_Huanche" readonly="readonly"
                                                                                                                                    value="<%=strHCDate %>" onfocus="WdatePicker({doubleCalendar:true,dateFmt:'yyyy-MM-dd'})" />
                                                                                                                            </div>
                                                                                                                        </td>
                                                                                                                        <td class="lt">&nbsp;</td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                        <td class="ct" style="width:100px; font-weight:bold">用车数量（辆）：</td>
                                                                                                                        <td class="lt" colspan="2">
                                                                                                                            <div style="box-shadow: 1px 1px 3px #DDDDDD inset;border: 1px solid #ccc;width: 60px;">
                                                                                                                                <select class="type" name="selYongchecount" id="selYongchecount">
                                                                                                                                        <option value="1">1</option>
                                                                                                                                        <option value="2">2</option>
                                                                                                                                        <option value="3">3</option>
                                                                                                                                        <option value="4">4</option>
                                                                                                                                        <option value="5">5</option>
                                                                                                                                        <option value="6">6</option>
                                                                                                                                        <option value="7">7</option>
                                                                                                                                        <option value="8">8</option>
                                                                                                                                        <option value="9">9</option>
                                                                                                                                </select>
                                                                                                                            </div>
                                                                                                                        </td>
                                                                                                                </tr>
                                                                                                               
                                                                                                        </tbody>
                                                                                                </table>
                                                                                        </div>                                                                        
                         
                                                                                                                                                                </div>
                                                                        <!--线路信息 END-->
                                                                                                                                             
                                                                        <h2>
                                                                                填写联系人信息 <span>请准确填写联系人信息（手机号码、E-mail），以便我们与您联系。</span>
                                                                        </h2>
                                                                        <div class="userType userTypeContact">
                                                                                <div class="bd">
                                                                                        <table width="100%" cellpadding="0" cellspacing="0" class="tb1">
                                                                                                <tbody>
                                                                                                        <tr>
                                                                                                                <td class="td1"><i>*</i> 联系人姓名：</td>
                                                                                                                <td>
                                                                                                                        <div class="floatDiv">
                                                                                                                                <input class="input2" id="txt_name" name="txt_name" maxlength="15" value="<%=CurClub.trueName %>" />
                                                                                                                                <span style="color: Red;"></span>
                                                                                                                        </div>
                                                                                                                </td>
                                                                                                                <td class="td1"><i>*</i> 手机号码：</td>
                                                                                                                <td>
                                                                                                                        <div class="floatDiv">
                                                                                                                                <input class="input1" id="txt_mobile" name="txt_mobile" maxlength="11" value="<%=CurClub.clubMobile %>" />
                                                                                                                                <span style="color: Red;"></span>
                                                                                                                        </div>
                                                                                                                </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                                <td class="td1">电子邮箱：</td>
                                                                                                                <td>
                                                                                                                        <div class="floatDiv">
                                                                                                                                <input class="input2" id="txt_email" maxlength="40" name="txt_email" value="" />
                                                                                                                                <span style="color: Red;"></span>
                                                                                                                        </div>
                                                                                                                </td>
                                                                                                                <td class="td1">固定电话：</td>
                                                                                                                <td>
                                                                                                                        <div class="floatDiv">
                                                                                                                                <input class="input3" id="txt_start_phone" name="txt_start_phone" maxlength="4" />
                                                                                                                                -
                                                                                                                                <input class="input4" id="txt_end_phone" name="txt_end_phone" style="width: 116px;" maxlength="8" />
                                                                                                                                <span style="color: Red;" id="span_phone"></span>
                                                                                                                        </div>
                                                                                                                </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                                <td class="td1">特殊要求：</td>
                                                                                                                <td colspan="3">
                                                                                                                        <input maxlength="200" style="width: 510px; color: #aaa;" name="txt_des" class="input2 J_place" id="txtDes" placeholder="仅限输入200字" />
                                                                                                                </td>
                                                                                                        </tr>
                                                                                                </tbody>
                                                                                        </table>
                                                                                </div>
                                                                        </div>
                                                                </div>
                                                                <div class="orderList">
                                                                        <div class="hd">
                                                                                <span></span>预订清单
                                                                        </div>
                                                                        <div class="bd">
                                                                                <ul id="J_orderDetail">
                                                                                        <li class="li1">
                                                                                                <p class="p1">用车</p>
                                                                                                <p>
                                                                                                     ¥<span id="unitPrice"><%=CarPriceModel.XiaoshuPrice %></span> 天/趟  *  <span id="intervalDay">1</span>天  * <span id="totalTai">1</span>辆                                                                                               
                                                                                                </p>
                                                                                                
                                                                                        </li>
                                                                                </ul>
                                                                                <div class="li4">
                                                                                        <p>
                                                                                                <strong>应付总额：</strong><label>¥<i id="totalPrice"><%=CarPriceModel.XiaoshuPrice %> </i></label>
                                                                                        </p>
                                                                                        <input type="button" id="btn_Next_2" style="background: url(/images/order19.gif); border-width: 0px; cursor: pointer; width: 121px; height: 38px;  margin: 10px 30px 10px 0px; display: inline; background-position: initial initial; background-repeat: no-repeat;" />
                                                                                </div>
                                                                        </div>
                                                                </div>
                                                                <div class="clearfix"></div>
                                                                <div class="userInfoBtn" id="gl_return" style="display: block;">
                                                                        <a href="" style="color:#03a0e2; float: left; margin:15px 0 0 10px;">&lt;&lt; 返回上一步</a>
                                                                        <input type="button" id="btn_Next" style="background: url(/images/order19.gif);border-width: 0px; cursor: pointer; width: 121px; height: 38px; margin-left: -100px;"  />
                                                                </div>
                                                                <div class="clearfix"></div>
                                                        </div>
                                                        <input type="hidden" id="txtHiddenCId" name="txtHiddenCId" value="<%=cid %>" />
                                                        <input type="hidden" id="txtHiddenPId" name="txtHiddenPId" value="<%=pid %>" />
                                                        <input type="hidden" id="txtHiddenOrderPrice" name="txtHiddenOrderPrice" value="<%=CarPriceModel.XiaoshuPrice %>" />
                                                        <input type="hidden" id="txtHiddenYongcheDate" name="txtHiddenYongcheDate" value="<%=strYCDate %>" />
                                                        <input type="hidden" id="txtHiddenHuancheDate" name="txtHiddenHuancheDate" value="<%=strHCDate %>" />
                                            
                                                </form>
                                                <script src="/js/tooltip.js" type="text/javascript"></script>
                                                <script src="/js/jquery.bgiframe.min.js" type="text/javascript"></script>
                                                <script src="/js/jquery.modal.js" type="text/javascript"></script>
                                                <script src="/js/order.js" type="text/javascript"></script>
                                                <script src="/js/widgetlogin.js" type="text/javascript"></script>
                                                <script src="/js/one_proc.js" type="text/javascript"></script>
                                                <script type="text/javascript">
                                                    function sumPrice() {
                                                        var unitcarprice = $("#unitPrice").text();
                                                        var intervalDay = $("#intervalDay").text();
                                                        var totalTai = $("#totalTai").text();
                                                        $("#totalPrice").text(parseFloat(unitcarprice) * parseFloat(intervalDay) * parseFloat(totalTai));
                                                        $("#txtHiddenOrderPrice").text(parseFloat(unitcarprice) * parseFloat(intervalDay) * parseFloat(totalTai));
                                                    }
                                                    function GetDateDiff(startDate, endDate) {
                                                        var startTime = new Date(Date.parse(startDate.replace(/-/g, "/"))).getTime();
                                                        var endTime = new Date(Date.parse(endDate.replace(/-/g, "/"))).getTime();
                                                        var dates = Math.abs((startTime - endTime)) / (1000 * 60 * 60 * 24);
                                                        return dates;
                                                    }
                                                    function caculateIntervalDay() {
                                                        var cartype=<%=CarPriceModel.CarTypeID %>;
                                                        var yongchedate = $("#ctl00_ContentPlaceHolder1_txt_Yongche").val();
                                                        var huanchedate = $("#ctl00_ContentPlaceHolder1_txt_Huanche").val();
                                                        if(parseInt(cartype)==1)
                                                        {
                                                            $("#intervalDay").text("1");
                                                        }
                                                        else
                                                        {
                                                            $("#intervalDay").text(GetDateDiff(yongchedate, huanchedate));
                                                        }
                                                    }
                                                    $(function() {
                                                        $("#selYongchecount").change(function() {
                                                            $("#totalTai").text($(this).val());
                                                            sumPrice();
                                                        })
                                                        $("#txt_Yongche").focusout(function() { 
                                                            caculateIntervalDay();
                                                            sumPrice();
                                                            $("#txtHiddenYongcheDate").val($(this).val());
                                                        })
                                                        $("#txt_Huanche").focusout(function() { 
                                                            caculateIntervalDay();
                                                            sumPrice();
                                                            $("#txtHiddenHuancheDate").val($(this).val());
                                                        })
                                                    })
                                                </script>                        
                                                </div>
                </div>
</asp:Content>
