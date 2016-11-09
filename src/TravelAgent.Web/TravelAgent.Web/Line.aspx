<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="Line.aspx.cs" Inherits="TravelAgent.Web.Line" %>
<%@ MasterType VirtualPath="~/Common.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/css/style.css" />
                <link rel="stylesheet" type="text/css" href="/css/line.css" />
                <link href="/css/fullcalendar.css" rel="stylesheet" type="text/css" />
                <script src="/js/jquery-1.7.2.min.js" type="text/javascript"></script>
                <script src="/js/tours_page.js" type="text/javascript" ></script>
                <script src="/js/fullcalendar.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--全局背景-->
                <div class="linebg">
                        <!--面包屑导航-->
                        <div class="place" id="divPlace" runat="server"></div>
                        <!--主体 第一屏-->
                        <div class="linebox">                                
                                <!--左边--> 
                                <div class="mainleft">                                        
                                        <!--上半部 图片 价格 等-->
                                        <div class="linetop">
                                                <div class="tit">
                                                        <h1><%=LineModel.LineName%><%=TravelAgent.Tool.CommonOprate.ShowLineState(LineModel.State) %></h1>
                                                        <span>
                                                                <font style="color: #999">
                                                                        编号：L<%=LineModel.Id.ToString().PadLeft(6, '0')%> 
                                                                 </font> <%=LineModel.LineSubName%>
                                                         </span>
                                                </div>
                                                <!--左图片-->
                                                <div class="linepic">
                                                        <img src="<%=LineModel.LinePic %>" alt="<%=LineModel.LineName %>" />
                                                </div>
                                                <!--END-->
                                                <!--右价格 及预订部分-->
                                                <div class="linepre" id="divlineorder">                                                        
                                                        <div class="pre">
                                                                <div class="tp">
                                                                        <span class="a1">参考价</span>
                                                                        <span class="a2"><asp:Literal ID="ltPrice" runat="server"></asp:Literal></span>
                                                                        <span class="a5">起</span>
                                                                </div>
                                                                <div class="bt">建议提前<span style="color:#fff;"><%=LineModel.AheadNumber %></span>天报名<a rel="nofollow" id="show_priceinfo" onmouseover="priceinfo();" telephone="<%=Master.webinfo.WebTel%>" onmouseout="priceinfoclose();" href="javascript:void(0);">起价说明</a></div>
                                                        </div>
                                                        <ul class="xinbox">
                                                                <li>
                                                                        <em>线路类型</em>
                                                                        <p>
                                                                            <asp:Label ID="lblLineType" runat="server" Text=""></asp:Label></p>
                                                                </li>
                                                                <li>
                                                                        <em>出发城市</em>
                                                                        <p>
                                                                            <asp:Label ID="lblCity" runat="server" Text=""></asp:Label></p>
                                                                </li>
                                                                <li>
                                                                        <em>行程天数</em>
                                                                        <p><%=LineModel.DayNumber %>天</p>
                                                                </li>
                                                                <li style="border:0;">
                                                                        <em>往返交通</em>
                                                                        <p>
                                                                            <%=LineModel.TrafficIds.TrimStart(',').TrimEnd(',') %></p>
                                                                </li>
                                                        </ul>
                                                        <!--预订-->
                                                        <div class="yuding">
                                                                           <form method="post" action="" onsubmit="return checkform(this);" >
                                                                                <div class="select" >
                                                                                        <div class="biaoti">出发日期</div>
                                                                                        <div class="searchbar">
                                                                                                <select id="ordertime" name="ordertime">
                                                                                                        <option value="">请选择出发日期</option>
                                                                                                        <%=ShowDate()%>                                                                         
                                                                                                 </select>
                                                                                        </div> 
                                                                                </div>
 
                                                                                <div class="yd_renqun">
                                                                                        <div class="biaoti">出游人群</div>
                                                                                        <div class="renqun">
                                                                                                <input class="yd_rs_1" name="adult"  onclick="this.value = ''" value="1" type="text" /><label>成人</label>
                                                                                                <input class="yd_rs_1"  name="child" onclick="this.value = ''" value="0"  type="text" /><label>儿童</label>
                                                                                        </div>
                                                                                </div> 
 
                                                                                <div class="yd_btn">
                                                                                        <div class="yd_anniu"><input type="submit" class="submit_btn" id="submit_btn" name="submit_btn" value=""  /></div>
                                                                                        <div class="sc_anniu"> <a rel="nofollow"  onclick="addCollection()" class="addCollection"><img src="/images/btn_sc.png" alt="加入收藏" /></a>                                                                                        </div>
                                                                                </div>
                                                                        </form>                                                        
                                                           </div>
                                                        <!--END-->
                                                </div>
                                                <!--END-->
                                        </div>
                                        <!--END-->
                                        <!--下半部分 日历部分-->
                                        <div id="linebot">
                                                <div id="price_calendar_lt"  align="center"></div>
                                                <div id="price_calendar_rt"  align="center"></div>
                                        </div>
                                        <!--日历END-->   
                                </div>
                                <!--左END-->
                                <!--右边栏-->
                                <div class="mainright">
                                        <div class="ald-hd "> <s></s><span>相关产品</span> </div>
                                        <ul class="xgline">
                                              <%=ShowAboutLine(LineModel.Dest,LineModel.DestId,5)%>                          
                                        </ul>
                                </div>
                                <div class="clear"></div>
                        </div>
                        
 
                        <!--第二部分 产品特色-->
                        <div class="linetwo">
                                <!--左-->
                                <div class="linelt">
                                        <!--抬头 page导航-->
                                        <div class="xingcheng">
                                                <div class="pkg-detail-wrap">
                                                        <div class="pkg-detail-tab">
                                                                <div class="pkg-detail-tab-bd">
                                                                        <a rel="nofollow" class="current" href="#cqts">产品特色</a>
                                                                        <a rel="nofollow" href="#xcxq">行程详情</a>
                                                                        <a rel="nofollow" href="#fysm">费用说明</a>
                                                                        <a rel="nofollow" href="#ydxz">预订须知</a>
                                                                        <a rel="nofollow" href="#cytx">出游提醒</a>
                                                                        <a rel="nofollow" href="#zxzx">在线咨询</a>
                                                                        <a id="divzhankuan" rel="nofollow" href="/LinePrint.aspx?id=<%=LineModel.Id %> ">打印行程</a>
                                                                        <a id="divorder" rel="nofollow" href="#divlineorder" class="order">开始预订</a>
                                                                </div>
                                                        </div>  
                                                </div>
                                                
                                        </div>
                                        <!--END-->
                                        <!--内容部分-->
                                        <div class="pkg-detail-box">
                                                <!--产品特色-->
                                                <div class="pkg-detail-infor" id="cqts">
                                                        <div class="cp_ts">
                                                                <h3>产品特色</h3>
                                                                 <%=LineModel.LineFeature %>                                                 
                                                         </div>
                                                </div>	
                                                <!--行程详情-->
                                                <div class="pkg-detail-infor">
                                                        <div id="xcxq" class="maodian">行程详情</div>
                                                        <div class="xc_xq">
                                                                <%=ShowLine(LineModel) %>                                         
                                                                <p style="text-indent: 96px; height: 30px; line-height:30px; color: #777; padding-top: 15px;"><font class="h14">*</font> 以上行程仅供参考，最终行程可能会根据实际情况进行微调，敬请以出团通知为准。</p>
                                                        </div>
                                                </div>
                                                <!--费用说明-->
                                                <div class="pkg-detail-infor">
                                                        <div id="fysm" class="maodian">费用说明</div>
                                                        <div class="fy_sm">
                                                                <%=LineModel.LineCost %>
                                                        </div>							
                                                </div>
                                                <!--预订须知-->
                                                <div class="pkg-detail-infor">
                                                        <div id="ydxz" class="maodian">预订须知</div>
                                                        <div class="yd_xz">
                                                        <%=LineModel.OrderTips %>                                    
                                                         </div>
                                                </div>
                                                <!--出游提醒-->
                                                <div class="pkg-detail-infor">
                                                        <div id="cytx" class="maodian">出游提醒</div>
                                                        <div class="yd_xz">                                    
                                                           <%=LineModel.TravelNotice %>
                                                        </div>
                                                </div>
                                                <!--在线咨询-->
                                                <div class="pkg-detail-infor">
                                                        <div id="zxzx" class="maodian">在线咨询</div>
                                                        <%=ShowConsult() %>
                                                        <div class="tw_zxzx">
                                                                <form action="" id="myForm" method="post" onsubmit="return check_data();">
                                                                        <dl class="box">
                                                                                <dt class="tit">联系方式：</dt>
                                                                                <dd class="con">
                                                                                        <input id="phone" class="shouji" name="phone" type='text'></input>
                                                                                </dd>
                                                                        </dl>
 
                                                                        <dl class="box">
                                                                                <dt class="tit">咨询内容：</dt>
                                                                                <dd class="con">
                                                                                        <textarea id="question" name="question" class="tw_ask"></textarea>
                                                                                </dd>
                                                                        </dl>
 
                                                                        <p><span>问题回复后如需邮件通知您请勾选此处</span><input type='checkbox' name='hava_email'/></p>
 
                                                                        <dl id="email" class="box" style="display: none">
                                                                                <dt class="tit">邮箱地址：</dt>
                                                                                <dd class="con">
                                                                                        <input type='text' class="shouji" name='email'/>
                                                                                </dd>
                                                                        </dl>
 
                                                                        <dl class="box">
                                                                                <dt class="tit">验证码：</dt>
                                                                                <dd class="con">
                                                                                        <input size="5" name="verify" type="text" id="txt_yzm" class="yanzheng" />
                                                                                        <label><img src="/RandomImage.aspx" style="cursor: pointer; margin-right:5px;" title="看不清，换一张?" alt="看不清，换一张" width="80px" height="25" id="img1" border="0" onclick='javascript:this.src = "/RandomImage.aspx?t=" + new Date().toUTCString();' /></label>
                                                                                </dd> 
                                                                        </dl>                                                       
                                                                        <div class="tijiao"><button id="sub_button" class="q_btn" type="button"  onclick="submit_data();">提交问题</button></div>
                                                                </form>
                                                        </div>
 
 
                                                </div>
                                                <!--用户点评-->
                                                <%--<div class="pkg-detail-infor">
                                                        <div id="yhdp" class="maodian"><a href="/comment/3726" target="_blank">用户点评</a></div>
                                                        <div class="dp_mayidu">
                                                                <div class="myd">
                                                                        <em>100%</em>
                                                                        <p>整体满意度</p>
                                                                </div>
                                                                <div class="sm">
                                                                        <p>关于满意度：<span>通过客户点评、客服回访、用户反馈来计算满意度。</span></p>
                                                                        <p>关于点评： <span>只有预订本产品并出游归来的会员才能进行点评。发表点评即可获赠200积分，直抵现金。</span></p>
                                                                        <div class="dp"><a href="#" onclick='return dpClick()' target="_blank">发表点评</a></div>
                                                                </div>
                                                        </div>
                                                </div>--%>
                                        </div>
                                        <!--END-->
                                </div>
                                <!--左END-->
 
                                <!--右-->
                                <div class="linert"></div>
                                <!--右END-->
                                <div class="clear"></div>
                        </div>
                        <div class="clear"></div>
                </div>
                <!--日历上预订-->
                <div class="rlyd" id="hidden_div">
                        <strong class="sClose1"><a rel="nofollow" href="javascript:;"></a></strong>
                        <form method="post" action="" onsubmit="return checkform(this);" >
                                <input name="ordertime" type="hidden" value="" />
                                <div class="rlyd_riqi">出发日期：<span class="J_datetxt"></span></div>
                                <div class="rlyd_renshu">
                                        <label>出游人数：</label>
                                        <input type="text" class="rlyd_renshu1" name="adult" onclick="this.value = '';"  value="1" maxlength="3" /><label> 成人 </label>
                                        <input type="text" class="rlyd_renshu1" name="child" onclick="this.value = '';"  value="0" maxlength="3" /><label> 儿童 </label>
                                </div>
                                <div class="riyd_btn">
                                        <input type="submit" class="riyd_btn2" value=""  />
                                </div>
                        </form>
                </div>
                <!--咨询及点评提示-->
                <div class="zxdp" id="counsel">
                        <div class="zixun">
                                <a rel="nofollow" class="close" href="javascript:;" onclick="counselClose()"></a>
                                <p>您的留言已提交成功，客服将尽快帮您解答，您也可以拨打<span><%=Master.webinfo.WebTel %></span>了解详情。</p>
                        </div>
                </div>
                
                <script type="text/javascript" src="/js/select_meihua.js"></script>
                <script type="text/javascript">
                    /////////////////////////////////////////////////////////
                    $(function() {
                        $("#ordertime").selectbox();
                        $(window).click(function() {
                            $("#hidden_div").hide();
                        });
                        $("#hidden_div").click(function(e) {
                            e.stopPropagation();
                        });
                        $("#hidden_div .sClose1").click(function() {
                            $("#hidden_div").hide();
                        });
                        /////////////////////////////////////

                        $("#linebot").on('click', ".fc-button-prev", function() {
                            $(this).parents("#linebot").find("#price_calendar_rt").fullCalendar("prev");
                        });

                        $("#linebot").on('click', ".fc-button-next", function() {
                            $(this).parents("#linebot").find("#price_calendar_lt").fullCalendar("next");
                        });
                       if ($('#price_calendar_lt').size() > 0) {
                            $('#price_calendar_lt').fullCalendar({
                                aspectRatio: 1.4,
                                events: "/dataDeal/LoadCalendar.aspx?id="+<%=LineModel.Id %>,
                                loading: function(isLoading, view) {
                                    if (isLoading) {
                                        $("#loading").show();
                                    } else {
                                        $("#loading").hide();
                                    }
                                },
                                header: {
                                    left: 'prev',
                                    center: 'title',
                                    right: ''
                                },
                                eventClick: function(calEvent, jsEvent, view) {
                                    if (calEvent.allDay) {
                                            $("#hidden_div").css({ top: jsEvent.pageY + 10, left: jsEvent.pageX - 160 }).show();
                                            $("#hidden_div").find(".J_datetxt").html(calEvent.info);
                                            $("#hidden_div").find("input[name='ordertime']").val($.fullCalendar.formatDate(calEvent.start,"yyyy-MM-dd"));
                                     }
                                     return false;
                                }
                            });
                         }
                        
                        if ($('#price_calendar_rt').size() > 0) {
                            $('#price_calendar_rt').fullCalendar({
                                aspectRatio: 1.4,
                                events: "/dataDeal/LoadCalendar.aspx?id="+<%=LineModel.Id %>,
                                loading: function(isLoading, view) {
                                    if (isLoading) {
                                        $("#loading").show();
                                    } else {
                                        $("#loading").hide();
                                    }
                                },
                                header: {
                                    left: '',
                                    center: 'title',
                                    right: 'next'
                                },
                                eventClick: function(calEvent, jsEvent, view) {
                                    if (calEvent.allDay) {
                                        $("#hidden_div").css({ top: jsEvent.pageY + 10, left: jsEvent.pageX - 160 }).show();
                                        $("#hidden_div").find(".J_datetxt").html(calEvent.info);
                                        $("#hidden_div").find("input[name='ordertime']").val($.fullCalendar.formatDate(calEvent.start,"yyyy-MM-dd"));
                                        //$(this).css('background-color','red');
                                    }
                                    return false;
                                }
                            });
                            $("#price_calendar_rt").fullCalendar('next');
                        }
                        /////////////////////////////////////////////////////////////////////////////////////////                                               

                       
                        //邮件通知按钮
                        var haveEmail = $("input[name='hava_email']").val();
                        var isCheck = $("input[name='hava_email']").attr("checked");
                        if (isCheck == 'checked') {
                            $('#email').show();
                        } else {
                            $('#email').hide();
                        }
                        //checkbox 响应事件
                        $("input[name='hava_email']").click(function() {
                            var isCheck = $(this).attr("checked");
                            if (isCheck == 'checked') {
                                $('#email').show();
                            } else {
                                $('#email').hide();
                            }
                        });
                        //ask_checkLogin();
                        //用户点评



                    }
                 );
                 //检查表单
                    function checkform(form) {
                        var id = <%=LineModel.Id %>;
                        var ordertime, adult, child;
                        if (form.ordertime.value === "") {
                            alert("请选择出发日期！");
                            return false;
                        } else {
                            ordertime = form.ordertime.value;
                        }
                        if (isNaN(parseInt(form.adult.value))) {
                            adult = 0;
                        } else {
                            adult = parseInt(form.adult.value);
                        }
                        if (isNaN(parseInt(form.child.value))) {
                            child = 0;
                        } else {
                            child = parseInt(form.child.value);
                        }
                        if (adult + child < 1) {
                            alert("请选择出游人数！");
                            return false;
                        }
                        //location.href="Order.aspx?ordertime="+ordertime+"&adult="+adult+"&child="+child+"&id="+id;
                        //urlrewrite
                        location.href="/lineorder/"+ordertime.replace('-','').replace('-','')+"/"+adult+"/"+child+"/"+id+".html";
                        return false;
                    }
//                    function ask_checkLogin() {
//                        if ($.cookie('uid') > 0) {
//                            $(".tishi").css('display', 'none');
//                        }
//                    }
                    /**问答数据验证*/
                    function check_data() {
                        var phone = $('input[name="phone"]').val();
                        var content = $("#question").val();
                        var vertify = $("#txt_yzm").val();
                        if (content.length < 5) {
                            alert('问题内容不能小于5个字符!');
                            return false;
                        }
                        if (!(/^1[3|5|4|8][0-9]\d{4,8}$/.test(phone))) {
                            alert("不是完整的11位手机号或者不正确的手机号");
                            return false;
                        }
                        if (vertify == null || vertify == '') {
                            alert('验证码不能为空!');
                            return false;
                        }
                        if(vertify!=$.cookie('yzm'))
                        {
                            alert('验证码输入错误!');
                            return false;
                        }
                        
                        return true;
                    }
                    function counselClose() {
                        $("#counsel").hide();
                    }
                    function submit_data() {

                        var phone = $("input[name='phone']").val();
                        var email = $("input[name='email']").val();
                        var content = $("#question").val();
                        var verify = $("#txt_yzm").val();
                        var line_id = <%=LineModel.Id %>;
                        if (check_data()) {
                            var data = { content: content, verify: verify, line_id: line_id };
                            if (phone.length > 0 && phone.length == 11) {
                                data.phone = phone;
                            }
                            //验证邮箱是否合法
                            if (email.length > 0) {
                                var pattern = /^[a-zA-Z0-9_\-]{1,}@[a-zA-Z0-9_\-]{1,}\.[a-zA-Z0-9_\-.]{1,}$/;
                                if (email != "") {
                                    if (!pattern.exec(email)) {
                                        alert('请输入正确的邮箱地址');
                                        return false;
                                    }
                                }
                                data.email = email;
                            }
                            $.ajax({
                                type: "POST",
                                url: "/dataDeal/LineZixun.aspx",
                                data: data,
                                dataType: "text",
                                success: function(data) {
                                    if (data== 'true') {
                                        $("#question").val('');
                                        $("input[name='phone']").val('');
                                        $("input[name='email']").val('');
                                        $("#txt_yzm").val('');
                                        var top = $(window).scrollTop() + $(window).height() / 2 - 100;
                                        var width = $(document).width() / 2 - 200;
                                        $("#counsel").css({ top: top, left: width }).show();
                                    } else {
                                        alert("很抱歉，提交失败，网站发送错误！");
                                    }
                                }
                            });
                        }
                    }
                    /** 加入收藏  */
                    function addCollection() {
                        var user_id = $.cookie('uid');
                        var line_id = <%=LineModel.Id %>;
                        if ((user_id == null) || (user_id == '')) {
                            alert('请先登录,登录后才能进行此操作!');
                            return;
                        }
                        var data = { uid: user_id, line_id: line_id };
                        $.ajax({
                            type: "POST",
                            url: "/dataDeal/LineCollect.aspx",
                            data: data,
                            dataType: "text",
                            success: function(data) {
                                if (data== "success") {
                                    //$('.addCollection').html(data.message);
                                    alert("恭喜您，收藏成功！");
                                } else if(data=="has") {
                                    alert("您已经收藏了！");
                                }
                            }
                        });
                    }
                  
                </script>
</asp:Content>
