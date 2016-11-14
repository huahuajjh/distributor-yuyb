<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TravelAgent.Web.Default" %>
<%@ MasterType VirtualPath="~/Master.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/css/default.css" />
  <script type="text/javascript" src="/js/default.js"></script>
  <script type="text/javascript" src="/js/isMobile.js"></script>
  <script type="text/javascript" src="/js/jquery.lazyload.js"></script>
  <script type="text/javascript">
      function lazyloadForPart(container) { container.find('img').each(function() { var original = $(this).attr("original"); if (original) { $(this).attr('src', original).removeAttr('original'); } }); }
      function setContentTab(name, curr, n) {
          for (i = 1; i <= n; i++) {
              var menu = document.getElementById(name + i);
              menu.className = i == curr ? "current" : "";
          }
      }
      function setContentTab1(name, curr, n) {
          for (i = 1; i <= n; i++) {
              var menu = document.getElementById(name + i);
              var cont = document.getElementById("con_" + name + "_" + i);
              var nav = document.getElementById("navsqm_" + i);
              menu.className = i == curr ? "current" : "";
              if (i == curr) {
                  cont.style.display = "block";
                  nav.style.display = "block";
                  lazyloadForPart($(cont));
              } else {
                cont.style.display = "none";
                nav.style.display = "none";
              }
          }
      }
      $(function() {
        $("img").lazyload({ threshold: 200 }); 
      })
  </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divheadmenu">
                
    </div>

    <!--主体部分-->
    <div class="main">
                <!--产品-->
                <div id="chanpin_nav" class="chanpin_nav">
                        <dl>
                                <%=BindDest() %>
                        </dl>					  	
                </div>
                <!--over-->
                <!--中部-->
                <div class="inbox">
                        <!--热卖产品-->
                        <div class="inbox_zhiding">
                                <%=BindHotLine(Convert.ToInt32(TravelAgent.Tool.EnumSummary.State.热卖),3)%>               
                        </div>
                        <!--焦点图-->
                        <div class="focusPic">
                                <%--<ul class="focusPic2">--%>
                                        <script type="text/javascript" src="/Tools/Advert_js.ashx?id=22&class=focusPic2"></script>                                       
                                <%--</ul>--%>
                                <a class="prev" href="javascript:void(0)"></a>
                                <a class="next" href="javascript:void(0)"></a>
                                <div class="num"><ul></ul></div>
                        </div>
                </div>
 
                <!--右部-->
                <div class='main_rt'>
                        <div class="Btn">
						    <a rel="logBtn" id="logins" href="/member/login.aspx">会员登录</a>
						    <a class="regBtn" target="_blank" href="/member/Register.aspx">免费注册</a>
					    </div>
					            
                        <div class="hyd" style="margin-top:10px; height:165px">
                                <ul class="tit">
                                        <li id="tet1" onmousemove="setTab2('tet', 1, 2)" class="hover">活动公告</li>
                                        <li id="tet2" onmousemove="setTab2('tet', 2, 2)">旅游资讯</li>
                                </ul>
                                <ul class="con">
                                        <div id="tab_tet_1">
                                                <%=BindNews(1,4)%>                                             
                                        </div> 
                                        <div id="tab_tet_2">
                                                <%=BindNews(2,4)%>
                                            </div>                  
                                </ul>                                
                        </div>
                                
                        <div class="whr">
                            <h5>特价线路</h5>
           	                    <%--<ul>
              	                    <%=BindBrand(0,3) %>
                                </ul>--%>
                                <div class="tejialine">
                                    <%=BindTejiaLine(1)%>
                                </div>
                        </div>
                </div>
 
                <div class="clear"></div>

        </div>
               
    <!--1楼特惠-->
    <div class="titbox">
		<b>1F</b>
		<h2><%=holiday==null?"当季推荐":holiday.holidayName %></h2>  
		<ul class="tabnav">
			<li class="current" onmouseover="setContentTab1('one', 1, 3)" id="one1"><a href="javascript:void(0)" rel="nofollow">出境线路</a></li>
			<li class="" onmouseover="setContentTab1('one', 2, 3)" id="one2"><a href="javascript:void(0)" rel="nofollow">国内线路</a></li>
			<li class="" onmouseover="setContentTab1('one', 3, 3)" id="one3"><a href="javascript:void(0)" rel="nofollow">周边短线</a></li>
		</ul>
		<a class="mor tbg1" title="推荐线路"></a>
	</div>
    <div class="holiday" style="background: url(<%=holidaybg %>) no-repeat center center;">
		<div class="sqmdd" id="navsqm_1" style="display: block;">
			<ul>
				<%=BindHolidayDest(Convert.ToInt32(TravelAgent.Tool.EnumSummary.State.推荐), 8, 3,1)%>
			</ul>
		</div>
		<div class="sqmdd" id="navsqm_2" style="display: none;">
			<ul>
				<%=BindHolidayDest(Convert.ToInt32(TravelAgent.Tool.EnumSummary.State.推荐), 8, 3,2)%>
			</ul>
		</div>
		<div class="sqmdd" id="navsqm_3" style="display: none;">
			<ul>
				<%=BindHolidayDest(Convert.ToInt32(TravelAgent.Tool.EnumSummary.State.推荐), 8, 3,3)%>
			</ul>
		</div>
		<ul id="tab_conbox1" class="sqline">
			<li id="con_one_1" style="display: block;">
					<%=BindHolidayLine(8,1)%>		
			</li>
			<li id="con_one_2" class="disno" style="display: none;">
				<%=BindHolidayLine(8,2)%>	
			</li>
			<li id="con_one_3" class="disno" style="display: none;">
				<%=BindHolidayLine(8,3)%>		
			</li>
		</ul>
	</div>    
                
    <!--2楼出境-->
    <div class="main2">
            <div class="title">
                    <b>2F</b>
                    <h2><a href="/model/3_1.html" target="_blank">出境旅游</a></h2>
                    <%--<span>出国度假，天天享特价！</span>--%>
                    <ul class="tabnav">
				        <%=BindNavDest(Convert.ToInt32(TravelAgent.Tool.EnumSummary.State.推荐),10,1,3)%>
			        </ul>
                    <a href="/model/3_1.html" target="_blank" class="mor tbg2" title="出境游"></a>
            </div> 
            <div class="xianlu">
                    <!--左-->
                    <div class="xl_lt"><script type="text/javascript" src="/Tools/Advert_js.ashx?id=27"></script></div>
                    <!--中-->
                    <div class="xl_in">
                            <%=BindLine(6,1)%>
                        </div>

                    <!--右-->
                    <div class="xl_rt">
                            <%--<h3 class="htit">当季推荐</h3>--%>
                            <%--<div class="fxb">
                                    <%=BindDest(Convert.ToInt32(TravelAgent.Tool.EnumSummary.State.推荐),12,1,3)%>
                            </div>--%>
                            <ul class="conltmdd">
                            <%=BindDest(null,18,1,3)%>
                            </ul>

                            <!--右小图-->
                            <script type="text/javascript" src="/Tools/Advert_js.ashx?id=24&class=rpic"></script>
                    </div>
            </div>
    </div>
                
    <!--3楼国内-->
    <div class="main2">
            <div class="title">
                    <b>3F</b>
                    <h2><a href="/model/2_2.html" target="_blank">国内旅游</a></h2>
                    <%--<span>国内长线，深度体验！</span>--%>
                    <ul class="tabnav">
                    <%=BindNavDest(Convert.ToInt32(TravelAgent.Tool.EnumSummary.State.推荐),10,2,2)%>
                    </ul>
                    <a href="/model/2_2.html" target="_blank" class="mor tbg3" title="国内游"></a>
            </div> 
            <div class="xianlu">
                    <!--左-->
                    <div class="xl_lt"><script type="text/javascript" src="/Tools/Advert_js.ashx?id=28"></script></div>
                    <!--中-->
                    <div class="xl_in">
                            <%=BindLine(6,2)%>                 
                        </div>

                    <!--右-->
                    <div class="xl_rt">
                            <%--<h3 class="htit">当季推荐</h3>--%>
                            <%-- <div class="fxb">
                                    <%=BindDest(Convert.ToInt32(TravelAgent.Tool.EnumSummary.State.推荐),12,2,2)%>
                            </div>--%>
                            <ul class="conltmdd">
                            <%=BindDest(null,18,2,2)%>
                            </ul>
                            <!--右小图-->
                            <script type="text/javascript" src="/Tools/Advert_js.ashx?id=25&class=rpic"></script>
                    </div>
            </div>

    </div>
                
    <!--4楼周边-->
    <div class="main2">
            <div class="title">
                    <b>4F</b>
                    <h2><a href="/model/4_3.html" target="_blank">周边旅游</a></h2>
                    <%-- <span>南京周边游，说走就走！</span>--%>
                    <ul class="tabnav">
                    <%=BindNavDest(Convert.ToInt32(TravelAgent.Tool.EnumSummary.State.推荐),10,3,4)%>
                    </ul>
                    <a href="/model/4_3.html" target="_blank" class="mor tbg4" title="周边游"></a>
            </div> 
            <div class="xianlu">
                    <!--左-->
                    <div class="xl_lt"><script type="text/javascript" src="/Tools/Advert_js.ashx?id=29"></script></div>
                    <!--中-->
                    <div class="xl_in">
                            <%=BindLine(6,3)%>             
                        </div>
                    <!--右-->
                    <div class="xl_rt">
                            <%--<h3 class="htit">当季推荐</h3>
                            <div class="fxb">
                                    <%=BindDest(Convert.ToInt32(TravelAgent.Tool.EnumSummary.State.推荐),12,3,4)%>
                            </div>--%>
                            <ul class="conltmdd">
                            <%=BindDest(null,18,3,4)%>
                            </ul>
                            <!--右小图-->
                            <script type="text/javascript" src="/Tools/Advert_js.ashx?id=26&class=rpic"></script>
                    </div>
            </div>

    </div>
                
    <!--通栏广告-->
    <div class="zhutiyou">
            <script type="text/javascript" src="/Tools/Advert_js.ashx?id=30"></script>
    </div>
                
    <!--5楼自由行签证-->
    <div class="main2">
            <div class="title">
                    <b>5F</b>
                    <h2>签证自由行</h2>
                    <span>享自由，放飞心情！</span>
                    <a href="javascript:void(0)" class="mor tbg5" title="自由行"></a>
            </div>

            <div class="xianlu">
                    <!--左广告图-->
                    <div class="zyx_lt">
                            <div class="zyx_lt_pic1"><script type="text/javascript" src="/Tools/Advert_js.ashx?id=31"></script></div>
                            <div class="zyx_lt_pic2">
                                    <a href="/visa/15_.html" target="_blank">全球签证</a>
                            </div>
                    </div>
                    <!--线路部分-->
                    <div class="zyx_in">
                            <div class="zyx_in_line">
                                    <%=BindZYXLine(null,4)%>                    
                            </div>
                            <div class="zyx_in_visa">
                                    <%=BindVisaList(Convert.ToInt32(TravelAgent.Tool.EnumSummary.State.推荐),8)%>                              
                                    </div>

                    </div>                
                    <!--右部-->
                    <div class="zyx_rt">
                            <h3 class="hTit"><a href="/newlist/49.html">旅游攻略</a></h3>
                            <ul class="gonglue">
                                    <%=BindNews(49,10)%>                                         
                                </ul>
                    </div>
            </div>
    </div>
</asp:Content>
