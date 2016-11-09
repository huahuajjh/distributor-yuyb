<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="LineModel.aspx.cs" Inherits="TravelAgent.Web.LineModel" %>
<%@ MasterType VirtualPath="~/Common.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="/css/linemodel.css" rel="stylesheet" type="text/css" />
                <link href="/css/mdd.css" rel="stylesheet" type="text/css" />
                <link rel="stylesheet" type="text/css" href="/css/fullcalendar.css" />
                <script src="/js/jquery-1.7.2.min.js" type="text/javascript"></script>
                <%--<script src="/js/tabnav.js" type="text/javascript"></script>--%>
                <script src="/js/fullcalendar.js" type="text/javascript"></script>
                <script type="text/javascript">
    $(function(){
        $("#chkTuijian").attr("checked",returnChecked(<%=isTuijian %>));
        $("#chkTejia").attr("checked",returnChecked(<%=isTejia %>));
        $("#chkRemai").attr("checked",returnChecked(<%=isRemai %>));
        var paivalue="pai"+<%=renqi %>+"_"+<%=price %>;
        $("ul.pai_con > li").each(function(){
            if($(this).attr("id")==paivalue)
            {
                $(this).addClass("curr");
                $(this).children().find("i").removeClass().addClass("s0");
            }
            else
            {
                $(this).removeClass("curr");
                $(this).children().find("i").removeClass().addClass("s1");
            }
        })
    })
    function returnChecked(value){return value==1;}
    function openUrl() {
        var tuijian = $("#chkTuijian").attr("checked") ? 1 : 0;
        var tejia = $("#chkTejia").attr("checked") ? 1 : 0;
        var remai = $("#chkRemai").attr("checked") ? 1 : 0;
        //location.href="/LineModel.aspx?nav=<%=nav %>&od=<%=od %>&td=<%=td %>&thd=<%=thd %>&c=<%=cityId %>&p=<%=proId %>&d=<%=day %>&Tu=" + tuijian + "&Te=" + tejia + "&Re=" + remai + "&pu=<%=price_up %>&pd=<%=price_down %>&rq=<%=renqi %>&pr=<%=price %>";
        //urlrewrite
        location.href="/line/<%=nav %>/<%=od %>/<%=td %>/<%=thd %>/<%=cityId %>/<%=proId %>/<%=day %>/" + tuijian + "/" + tejia + "/" + remai + "/<%=price_up %>/<%=price_down %>/<%=renqi %>/<%=price %>.html";
    }
    function gotoUrl(rq,pr){
        var tuijian = $("#chkTuijian").attr("checked") ? 1 : 0;
        var tejia = $("#chkTejia").attr("checked") ? 1 : 0;
        var remai = $("#chkRemai").attr("checked") ? 1 : 0;
        //location.href= "/LineModel.aspx?nav=<%=nav %>&od=<%=od %>&td=<%=td %>&thd=<%=thd %>&c=<%=cityId %>&p=<%=proId %>&d=<%=day %>&Tu=" + tuijian + "&Te=" + tejia + "&Re=" + remai + "&pu=<%=price_up %>&pd=<%=price_down %>&rq=" + rq + "&pr=" + pr;
        //urlrewrite
        location.href= "/line/<%=nav %>/<%=od %>/<%=td %>/<%=thd %>/<%=cityId %>/<%=proId %>/<%=day %>/" + tuijian + "/" + tejia + "/" + remai + "/<%=price_up %>/<%=price_down %>/" + rq + "/" + pr+".html";
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="divheadmenu">
                                 
</div>
<div class="place">
                        <span>您当前位置：</span>
                        <a href="<%=Master.webinfo.WebDomain %>">首页</a>&gt;
                        <%=strPlace %>
                </div>
                <div class="main">
                        <!--右部线路-->
                        <div class="content">
                                <div class="toptuijian">
                                        <%=BindTuijian() %>
                                </div>                                
                                <!--推荐线路-->
                                <!--筛选-->
                                <div id="shaixuan" class="shai">
                                        
                                        <!--筛选开始-->
                                        <div class="shai_box">
                                                <dl class="shai_con">
                                                        <dt class="shai_tit">出发城市：</dt>
                                                        <dd class="shai_txt">
                                                                <%=ShowCity()%>
                                                        </dd>
                                                </dl> 
                                                <dl class="shai_con">
                                                        <dt class="shai_tit">线路类型：</dt>
                                                        <dd class="shai_txt">
                                                                <%=ShowJoinPro()%>                                                       
                                                        </dd>
                                                </dl>
                                                <dl class="shai_con borno">
                                                        <dt class="shai_tit">行程天数：</dt>
                                                        <dd class="shai_txt">
                                                                <%=ShowDay(15)%>                                                        
                                                         </dd>
                                                </dl>
                                                
                                        </div>
                                </div>
                                <!--shaiOVER-->
                                <!--排序-->
                                        <div class="pai_tit">
                                                <ul class="pai_con">
                                                        <li id="pai0_0" class="curr"><a rel="nofollow" onclick="gotoUrl(0,0,this)">全部</a></li>                              
                                                                <li id="pai1_0"><a rel="nofollow" onclick="gotoUrl(1,0)"><span>人气</span><i class="s1"></i></a></li> 
                                                                <li id="pai0_1"><a rel="nofollow" onclick="gotoUrl(0,1)"><span>价格</span><i class="s1"></i></a></li>
                                                </ul>
                                                <div class="part">
                                                        <input id="chkTuijian" name="chkTuijian" type="checkbox" value="1" onclick="openUrl();" /><label for="chkTuijian">推荐</label>
                                                        <input id="chkTejia" name="chkTejia" type="checkbox" value="2" onclick="openUrl();"  /><label for="chkTuijian">特价</label>
                                                        <input id="chkRemai" name="chkRemai" type="checkbox" value="3" onclick="openUrl();"  /><label for="chkTuijian">热卖</label>                                
                                                </div>
                                                <div class="pai_jia">
                                                        <form action="/Search.aspx" method="POST" class="range">
                                                                 <input type='hidden' name='c' value="<%=cityId %>" />
                                                                <input type="hidden" name="p" value="<%=proId %>" />
                                                                <input type="hidden" name="d" value="<%=day %>" />
                                                                <input type="hidden" name="rq" value="<%=renqi %>" />
                                                                <input type="hidden" name='pr' value='<%=price %>' />
                                                                <span style="float:left; margin-right:5px;">价格区间</span>
                                                                <input name='pd' type="text" class="priceipt" id="pd" value="<%=price_down %>" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" onclick="this.value = ''" /><i>～</i><input name='pu' type="text" class="priceipt" value="<%=price_up %>" id="pu" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" onclick="this.value = ''" />
                                                                <input type="submit" class="button" value="" />
                                                        </form>
                                                </div>
                                        </div>             
                                        <!--pai OVER-->
                                        <!--线路开始-->
                                        <%=BindlistLine() %>
                                        <!--END-->
                                        <!--分页-->
                       </div>


                        <!--左部边栏-->
                        <div class="sidebar">

                                <!--目的地-->
                                <ul id="rolin" class="rolinList">
                                        <%=BindLeftDest() %>            
                                 </ul>
                                <!--end-->
                                <h4>特价线路</h4>
                                <ul class="th_line">
                                    <%=BindTejia()%>
                                </ul>
                                                                
                         </div>

                        <div class="clear"></div>
                </div>
                <script src="/js/listmdd.js" type="text/javascript"></script>
                <script type="text/javascript">
                    $(function() {

                        $(".case_calendar").on('click', ".fc-button-prev", function() {
                            $(this).parents(".case_calendar").find(".case_calendar_right").fullCalendar("prev");
                        });
                        $(".case_calendar").on('click', ".fc-button-next", function() {
                            $(this).parents(".case_calendar").find(".case_calendar_left").fullCalendar("next");
                        });
                        $(".linebox").on('click', '.zk', function() {
                            var $this = $(this);
                            $(this).removeClass("zk").addClass("sq");

                            $(".case_calendar").each(function() {
                                $(".case_calendar_right", $(this)).fullCalendar("destroy");
                                $(".case_calendar_left", $(this)).fullCalendar("destroy");
                                $(this).hide();
                            });
                            var id = $(this).data('id');
                            $("#case_calendar_" + id).show();
                            $('.case_calendar_left', "#case_calendar_" + id).fullCalendar({
                                aspectRatio: 1.2,
                                events: "/dataDeal/LoadCalendar.aspx?id=" + id,
                                header: {
                                    left: 'prev',
                                    center: 'title',
                                    right: ''
                                },
                                eventClick: function(calEvent, jsEvent, view) {
                                    window.open($this.data('url'));
                                    return false;
                                }

                            });
                            $('.case_calendar_right', "#case_calendar_" + id).fullCalendar({ aspectRatio: 1.2,
                            events: "/dataDeal/LoadCalendar.aspx?id=" + id,
                                header: {
                                    left: '',
                                    center: 'title',
                                    right: 'next'
                                },
                                eventClick: function(calEvent, jsEvent, view) {
                                    window.open($this.data('url'));
                                    return false;
                                }

                            });
                            $(".case_calendar_right", "#case_calendar_" + id).fullCalendar('next');

                        });

                        $(".linebox").on('click', '.sq', function() {
                            var id = $(this).data('id');
                            $('.case_calendar_left', "#case_calendar_" + id).fullCalendar("destroy");
                            $('.case_calendar_right', "#case_calendar_" + id).fullCalendar("destroy");
                            $("#case_calendar_" + id).hide();
                            $(this).removeClass("sq").addClass("zk");
                        });


                    });
                </script>
</asp:Content>
