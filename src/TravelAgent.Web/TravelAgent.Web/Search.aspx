<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="TravelAgent.Web.Search" %>
<%@ MasterType VirtualPath="~/Common.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/css/style.css" />
<link rel="stylesheet" type="text/css" href="/css/search.css" />
<link rel="stylesheet" type="text/css" href="/css/fullcalendar.css" />
<script src="/js/jquery-1.7.2.min.js" type="text/javascript"></script>
<script src="/js/fullcalendar.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function(){
        $("#chkTuijian").attr("checked",returnChecked(<%=isTuijian %>));
        $("#chkTejia").attr("checked",returnChecked(<%=isTejia %>));
        $("#chkRemai").attr("checked",returnChecked(<%=isRemai %>));
    })
    function returnChecked(value){return value==1;}
    function openUrl() {
        var tuijian = $("#chkTuijian").attr("checked") ? 1 : 0;
        var tejia = $("#chkTejia").attr("checked") ? 1 : 0;
        var remai = $("#chkRemai").attr("checked") ? 1 : 0;
        //location.href="/Search.aspx?k="+escape('<%=keyword %>')+"&c=" + <%=cityId %> + "&p=" + <%=proId %> + "&d=" + <%=day %> + "&Tu=" + tuijian + "&Te=" + tejia + "&Re=" + remai + "&pu=<%=price_up %>&pd=<%=price_down %>&rq=" + <%=renqi %> + "&pr=" + <%=price %>;
        ////urlrewrite
        location.href="/search/"+escape('<%=keyword %>')+"/" + <%=cityId %> + "/" + <%=proId %> + "/" + <%=day %> + "/" + tuijian + "/" + tejia + "/" + remai + "/<%=price_up %>/<%=price_down %>/" + <%=renqi %> + "/" + <%=price %>+".html";
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <div id="divheadmenu">    
                </div>
<%--<div class="allbg">--%>                      
                 <!--主体部分-->
                 <div class="main">
                                <!--产品部分-->
                                <div class="content">
                                        <!--筛选-->
                                        <div class="shai">
                                                <table width="980" border="0" cellspacing="1" cellpadding="0">
                                                        <tr>
                                                                <td class="hed" colspan="2">
                                                                        <div class="lt">
                                                                                <a href="<%=Master.webinfo.WebDomain%>">首页</a>&gt;
                                                                                <em>"<span style="color:Red"><%=keyword.Equals("no")?"":keyword %></span>"的搜索结果</em>
                                                                        </div>
                                                                        <div class="rt">
                                                                                没搜到？打电话问客服：<span><%=Master.webinfo.WebTel%></span>
                                                                        </div>
                                                                </td>
                                                        </tr>
                                                        <tr>
                                                                <td class="tit">出发城市：</td>
                                                                <td class="con">
                                                                        <%=ShowCity()%>                                                              
                                                                </td>                                               
                                                        </tr>
                                                        <tr>
                                                                <td class="tit">线路类型：</td>
                                                                <td class="con">
                                                                        <%=ShowJoinPro()%>                                                                
                                                                </td>                                              
                                                        </tr>
                                                        <tr>
                                                                <td class="tit">行程天数：</td>
                                                                <td class="con">
                                                                        <%=ShowDay(15)%>
                                                               </td>                                               
                                                        </tr>
                                                                                                                                              
                                                </table>
                                        </div>
                                        <!--筛over-->
 
 
 
                                        <!--线路部分 抬头-->
                                        <div class="shai_tit">
                                                <ul class="shai_con">
                                                        <%=ShowOther()%>
                                                </ul>
                                                <div class="part">
                                                        <input id="chkTuijian" name="chkTuijian" type="checkbox" value="1" onclick="openUrl();" /><label for="chkTuijian">推荐</label>
                                                        <input id="chkTejia" name="chkTejia" type="checkbox" value="2" onclick="openUrl();"  /><label for="chkTuijian">特价</label>
                                                        <input id="chkRemai" name="chkRemai" type="checkbox" value="3" onclick="openUrl();"  /><label for="chkTuijian">热卖</label>                                
                                                </div>
                                                <div class="shai_jia">
                                                        <form class="range" method="POST" action="/Search.aspx">
                                                                <input type='hidden' name='c' value="<%=cityId %>" />
                                                                <input type="hidden" name="p" value="<%=proId %>" />
                                                                <input type="hidden" name="k" value="<%=keyword %>" />
                                                                <input type="hidden" name="d" value="<%=day %>" />
                                                                <input type="hidden" name="rq" value="<%=renqi %>" />
                                                                <input type="hidden" name='pr' value='<%=price %>' />
                                                                <span style="float:left; margin-right:5px;">价格区间</span>
                                                                <input name='pd' type="text" class="priceipt" id="pd" value="<%=price_down %>" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" onclick="this.value = ''" /><i>～</i><input name='pu' type="text" class="priceipt" value="<%=price_up %>" id="pu" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" onclick="this.value = ''" />
                                                                <input type="submit" class="button" value="" />
                                                        </form>
                                                </div>
                                                
                                        </div>
                                        <%=BindlistLine()%>
                                </div>
                                <!--右边栏-->
                                <div class="sidebar">
                                        <h3>特价线路</h3>
                                        <ul class="th_line">
                                                <%=BindTejiaLine(Convert.ToInt32(TravelAgent.Tool.EnumSummary.State.特价), 10)%>   
                                           </ul>
                                </div>
                        </div>
               <%-- </div>--%>
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
                                        $('.case_calendar_right', "#case_calendar_" + id).fullCalendar({
                                                aspectRatio: 1.2,
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
 
                        $(document).ready(function() {
 
                                $("div.lc-day-detail div.doc-line-list2").each(function() {
                                        $(this).children("dl:gt(3)").hide()
                                });
                                $("div.doc-more").on("click", "a", function() {
                                        var _rel = $(this).attr("rel");
                                        var $parentPrev = $(this).parent().prev();
                                        //var length = $parentPrev.find("dl").size();
 
                                        if ("1" === _rel) {
                                                $(this).attr("rel", "");
                                                //$parentPrev.css("height","120px");
                                                $parentPrev.children("dl:gt(3)").hide();
                                                $(this).find("span").removeClass("icon-fode").addClass("icon-hide");
                                        }
                                        else {
                                                $(this).attr("rel", "1");
                                                //if(length > 4) {
                                                //    $parentPrev.css("height","auto");
                                                //}
                                                $parentPrev.children("dl:gt(3)").show();
                                                $(this).find("span").removeClass("icon-hide").addClass("icon-fode");
                                        }
                                });
                        });
 
 
                </script>
</asp:Content>
