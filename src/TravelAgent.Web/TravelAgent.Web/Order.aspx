<%@ Page Title="" Language="C#" MasterPageFile="~/Other.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="TravelAgent.Web.Order" %>
<%@ MasterType VirtualPath="~/Other.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" rel="stylesheet" href="/css/style.css" />
    <link href="/css/order.css" rel="stylesheet" type="text/css" />
    <link href="/css/jquery.address.css" rel="stylesheet" type="text/css" />
    <link href="/css/autocomplete.css" rel="stylesheet" type="text/css" />
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
                <ul class="step1">
                    <li class="on">填写订单</li>
                    <li>填写游客信息</li>
                    <li>核对订单</li>
                    <li>付款</li>
                    <li>预订成功</li>
                </ul>
            </div>
            <!--订单步骤 END-->
            <form id="one_form" action="" method="post">
                <div class="orderWrap">
                    <div class="userInfo">
                        <!--线路信息 Start-->
                        <h2>线路信息</h2>
                        <div class="checkOrderInfo">
                            <div class="hd">线路信息</div>
                            <div class="bd">
                                <table width="100%" cellspacing="0" cellpadding="0">
                                    <tbody>
                                        <tr>
                                            <th width="10%" class="lt">线路编号</th>
                                            <th width="30%">线路名称</th>
                                            <th width="15%">出发城市</th>
                                            <th width="15%">出发时间</th>
                                            <th width="15%">出游人数</th>
                                            <th width="15%">小计</th>
                                        </tr>
                                        <tr>
                                            <td class="lt">L<%=LineModel.Id.ToString().PadLeft(6,'0') %></td>
                                            <td class="lt">
                                                <a class="a1" href="/line/<%=id %>.html" target="_blank"><%=LineModel.LineName %></a>
                                            </td>
                                            <td><%=ShowCityName(LineModel.CityId) %></td>
                                            <td><%=ordertime %></td>
                                            <td>
                                                <input class="input3" id="txtPersonNums" style="width: 40px; height: 17px; margin-bottom: 5px;" name="txtPersonNums" maxlength="2" value="<%=adult %>" />成人
                                                                                                                                <input class="input3" id="txtChildNums" style="width: 40px; height: 17px;" name="txtChildNums" maxlength="2" value="<%=child %>" />儿童                                                           
                                            </td>
                                            <td>
                                                <b>¥</b><b id="proTotal"><%=totalprice %></b>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>

                        </div>
                        <!--线路信息 END-->
                        <h2>附加产品<%=strAttach %></h2>

                        <div class="checkOrderInfo attach" id="divattach" runat="server">
                            <!--附加产品 START-->

                            <div class="hd">
                                保险产品
                                                                                        <span style="color: #FF6600; font-weight: lighter;">*每位出游人限购买一份保险&nbsp;&nbsp;</span>
                            </div>
                            <div class="bd" id="dd_travel_0">
                                <table width="100%" cellspacing="0" cellpadding="0" id="table_0">
                                    <tbody>
                                        <tr>
                                            <th class="lt" width="*">名称</th>
                                            <th width="15%">价格</th>
                                            <th width="15%">单位</th>
                                            <th width="15%">份数</th>
                                            <th width="15%">小计</th>
                                        </tr>
                                        <%-- <tr id="tr_0">
                                                                                                                        <td class="lt">
                                                                                                                                <a href="javascript:void(0);" style="line-height: 17px;" id="atoggle_0">
                                                                                                                                        <span class="arrowFlag">▼</span><span id="a_0">阳光境内旅行意外伤害保险</span>
                                                                                                                                </a>
                                                                                                                        </td>
                                                                                                                        <td>
                                                                                                                                <b>¥</b><b id="td_price_0">10</b>
                                                                                                                        </td>
                                                                                                                        <td>
                                                                                                                                <input type="hidden" id="hdunits_0" value="元/人" />元/人
                                                                                                                        </td>
                                                                                                                        <td>
                                                                                                                                <input id="txtHiddenDefaultNums_0" type="hidden" />
                                                                                                                                <input id="txtHiddenAddProductTypeId_0" type="hidden" value="3" />
                                                                                                                                <select id="ddl_nums_0" name="insure" style="min-width: 34px;"></select>
                                                                                                                        </td>
                                                                                                                        <td>
                                                                                                                                <b>¥</b><b id="td_total_0">0</b>
                                                                                                                        </td>
                                                                                                                </tr>
                                                                                                                <tr class="trhide">
                                                                                                                        <td colspan="6" style="text-align: left; color: #666; line-height: 22px;">
                                                                                                                                <p>
                                                                                                                                        1. 意外伤害事故、残疾：8万<br />
                                                                                                                                        2. 意外伤害医疗：2万<br />
                                                                                                                                        3. 未成年人均为5万<br />
                                                                                                                                        4. 意外伤害保险医疗费金额未满100元的，保险公司不予受理。超过100元以上的，按规定正常理赔（无免赔额）。<br />
                                                                                                                                        5. 对发生旅游意外伤害治疗的，其医药费用报销一律在职工医保标准范围内。
                                                                                                                                </p>
                                                                                                                        </td>
                                                                                                                </tr>--%>
                                        <%=BindAttach()%>
                                    </tbody>
                                </table>
                            </div>

                        </div>
                        <h2>填写联系人信息 <span>请准确填写联系人信息（手机号码、E-mail），以便我们与您联系。</span>
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
                                        <tr>
                                            <td class="td1"><i>*</i>推荐人：</td>
                                            <td colspan="3">
                                                <input autocomplete="off" maxlength="200" style="width: 510px; color: #aaa;" name="txt_tuijianren" class="input2 J_place" id="txt_tuijianren" placeholder="请输入本校名称或者推荐人姓名即可查找推荐人信息，无推荐人输入学校名称即可" alt="请填写本校名称即可查找推荐人信息" />
                                                <span style="color: Red;" id="span_tuijianren"></span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="td1"></td>
                                            <td colspan="3">说明：推荐人请填写本校校园经理或代理姓名，或学校名称
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
                                    <p class="p1">旅游团费</p>
                                    <p>
                                        <b>¥<span id="s_personall"><%=adult * adultprice%></span></b><span id="b_personnums"><%=adult %></span>成人×¥<span id='b_adult'><%=adultprice %></span>
                                    </p>
                                    <p>
                                        <b>¥<span id="s_childall"><%=child * childprice%></span></b><span id="b_childnums"><%=child %></span>儿童×¥<span id='b_child'><%=childprice %></span>
                                    </p>
                                </li>
                                <li class="li2" id="AddPList"></li>
                            </ul>
                            <div class="li4">
                                <p>
                                    <strong>应付总额：</strong><label>¥<i id="offerPrice"><%=totalprice %></i></label>
                                </p>
                                <input type="button" id="btn_Next_2" style="background: url(/images/order19.gif); border-width: 0px; cursor: pointer; width: 121px; height: 38px; margin: 10px 30px 10px 0px; display: inline; background-position: initial initial; background-repeat: no-repeat;" />
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <div class="userInfoBtn" id="gl_return" style="display: block;">
                        <a href="/line/<%=id %>.html" style="color: #03a0e2; float: left; margin: 15px 0 0 10px;">&lt;&lt; 返回上一步</a>
                        <input type="button" id="btn_Next" style="background: url(/images/order19.gif); border-width: 0px; cursor: pointer; width: 121px; height: 38px; margin-left: -100px;" />
                    </div>
                    <div class="clearfix"></div>
                </div>
                <input type="hidden" id="txtHiddenPId" name="txtHiddenPId" value="<%=id %>" />
                <input type="hidden" id="txtHiddenMType" name="txtHiddenMType" value="<%=LineModel.DestId %>" />
                <input type="hidden" id="txtHiddenGoDate" name="txtHiddenGoDate" value="<%=ordertime %>" />
                <input type="hidden" id="txtHiddenAdultPrice" name="txtHiddenAdultPrice" value="<%=adultprice %>" />
                <input type="hidden" id="txtHiddenChildPrice" name="txtHiddenChildPrice" value="<%=childprice %>" />
                <input type="hidden" id="txtHiddenPersonNum" name="txtHiddenPersonNum" value="<%=adult %>" />
                <input type="hidden" id="txtHiddenChildNum" name="txtHiddenChildNum" value="<%=child %>" />
                <input type='hidden' id='txtHiddenNums' name='txtHiddenNums' value="<%=(adult+child) %>" />
                <input type='hidden' id='txtHiddenAttachPrice' name='txtHiddenAttachPrice' value="" />
                <input type='hidden' name='txtHiddenHotel' value='N;' />
                <input type='hidden' name='txtHiddenFlight' value='a:0:{}' />
                <input type="hidden" id="hiddenPrepayMent" name="hiddenPrepayMent" value="0" /><!--应付款额-->
                <input type="hidden" id='txtHiddenLinker' name='txtHiddenLinker' value="" />
                <input type="hidden" id='txtHiddenPayType' name='txtHiddenPayType' value="0" />
                <input type="hidden" id='txtHiddenSite' name='txtHiddenSite' value="1" />
                <input type="hidden" id='txtHiddentuijianren' name='txtHiddentuijianren' value="1" />

            </form>
            <script type="text/javascript" src="/js/url.js"></script>
            <script src="/js/tooltip.js" type="text/javascript"></script>
            <script src="/js/jquery.bgiframe.min.js" type="text/javascript"></script>
            <script src="/js/jquery.modal.js" type="text/javascript"></script>
            <script src="/js/order.js" type="text/javascript"></script>
            <script src="/js/widgetlogin.js" type="text/javascript"></script>
            <script src="/js/one_proc.js" type="text/javascript"></script>
            <script src="/js/jquery.address.js" type="text/javascript"></script>
            <script src="/js/autocomplete.js" type="text/javascript"></script>
            <script type="text/javascript">
                $("#txt_tuijianren").bindAddress({
                    addressUrl: apiURL.AreaGet,
                    schoolUrl: apiURL.SchoolGet,
                    personUrl: apiURL.ReferencesSchoolGetBySchId
                });
                $('#txt_tuijianren').autocomplete({
                    url: apiURL.ReferencesSchoolGetByFuzzy,
                    width: 300,
                    height: 30,
                });

            </script>
        </div>
    </div>

</asp:Content>