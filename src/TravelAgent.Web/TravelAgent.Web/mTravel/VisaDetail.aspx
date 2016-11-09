<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisaDetail.aspx.cs" Inherits="TravelAgent.Web.mTravel.VisaDetail" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" id="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <link rel="stylesheet" href="css/base.css">
    <%--<link rel="stylesheet" type="text/css" href="css/mobile_xnxw.css" />--%>
<link rel="stylesheet" type="text/css" href="css/index.css" />
<link rel="stylesheet" type="text/css" href="css/header.css" />
<link rel="stylesheet" type="text/css" href="css/global.css" />
<script type="text/javascript" src="scripts/jquery.js"></script>
<title><%=Visa.visaName %>-<%=webinfo.WebName %></title>
    <script type="text/javascript" src="scripts/base.js"></script>
    <script type="text/javascript" src="scripts/jquery.placeholder.js"></script>
    <script type="text/javascript" src="scripts/imglazyload.js"></script>

</head>
<body>
<header class="header">
		<a href="javascript:window.history.go(-1);" class="ic_back"></a>
		<h2><%=Visa.visaName %></h2>
		<a href="javascript:;" class="navbtn"><span></span><span></span><span></span></a>
</header>
<div class="wraper">
    <div class="wrap">
        
        <div id="content" class="hl_bd">
                           
                           <section class="main-line">
         <div class="line-img"><span class="line-s-m"><img alt="<%=Visa.visaName %>" src="<%=Visa.picurl%>" width="300px" height="200px"></span></div>
            <%--<h1 class="line-tit"><em class="c-0"></em>英国个人旅游签证</h1>--%>
            <div class="line-txt plr10">
                <div class="line-basic-info clearfix">
                    <div class="bi_1">
                        <div class="bis"><p>签证服务费</p><p style="font-weight:bold; color:Red; font-size:14px;">￥<%=Visa.price%> /人</p></div>
                        <div class="bis"><p>签证类型</p><p style="font-weight:bold"><%=ShowTypeName(Convert.ToInt32(Visa.typeId))%></p></div>
                        <div class="bis"><p>停留天数</p><p style="font-weight:bold"><%=Visa.stayTime%>天</p></div>
                    </div>
                    <div class="bi_2"><span>受理时间：</span><i><em><%=Visa.dealTime%>。</em></i></div>
                </div>
            </div>

            <div class="line-block">
                <h1 class="line-tit"><em class="c-0"></em>签证办理所需材料</h1>
                <div class="select_2">
                    <ul>
                        <%--<li class="line-i-w"><a href="javascript:;" class="left"><i class="link-img c1"></i><span class="name">所需材料</span></a></li>--%>
                        <li>
                            <div class="line-i-c">
                                 <div class="line-i-c-h">
                                 <%=Visa.needMaterial %>
                                 </div>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>

    <div class="line-block">
        <h1 class="line-tit"><em class="c-0"></em>友情提示</h1>
        <div class="select_2">
            <ul>
                <%--<li class="line-i-w"><a href="javascript:;" class="left"><i class="link-img c1"></i><span class="name">预定须知</span></a></li>--%>
                <li>
                    <div class="line-i-c">
                         <div class="line-i-c-h">
                         <%=Visa.tips %>
                         </div>
                    </div>
                </li>
            </ul>
        </div>
    </div>
            <!--在线预订-->
                      </section>        </div>
        <footer class="copyright">
	<p>
		<%=BindBottonNav(3,3)%>
	</p>
	<p>Copyright &copy; 2015-<%=DateTime.Now.Year %></p>
	<p>技术支持：约游约呗</p>
</footer>
    </div>
</div>
 <!--预订按钮-->
        <div class="yuding_btn">
                <a href="tel:<%=webinfo.WebTel %>" class="yuding_tel">电话咨询</a>
                <a href="LineOrder.aspx?id=<%=Visa.id %>&ot=2&name=<%=Visa.visaName %>" class="yuding_onclik">在线预订</a>
        </div>
</body>
</html>
