<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LinePrint.aspx.cs" Inherits="TravelAgent.Web.LinePrint" %>

<html>
    
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=GBK">
        <meta http-equiv="x-ua-compatible" content="ie=7" />
        <meta name="robots" content="noindex,nofollow" />
        <title>
            打印：<%=LineModel.LineName %>_<%=webinfo.WebName %>
        </title>
        <style type="text/css">body,h1,h2,h3,p,form,li,dt,dl,dd,label {
	margin:0;
	padding:0;
}
ul {
	margin:0;
	padding:0;
	list-style:none;
}
li {
	margin:0;
	padding:0;
}
body {
	font-family:arial,sans-serif;
	font-size:12px;
	line-height:150%;
	text-align:center;
	background:#EEE;
}
#printBtn a:link,#printBtn a:visited {
	color:#FFFFFF;
	text-decoration:none;
}
#printBtn a:hover {
	color:#FFFFFF;
	text-decoration:underline;
}
a:link,a:visited {
	color:#0000FF;
	text-decoration:underline;
}
a:hover {
	color:#FF0000;
	text-decoration:NONE;
}
.clearfix:after {
	display:block;
	visibility:hidden;
	clear:both;
	height:0;
	content:".";
}
.clearfix {
	display:inline-block
}
/* Hides from IE-mac \*/* html .clearfix {
	height:1%;
}
.clearfix {
	display:block;
}
/* End hide from IE-mac */ .mt12 {
	margin-top:12px;
}
#printBtn {
	background:#00b100;
	border-bottom:1px solid #000;
	padding:3px 0;
	color:#FFFFFF;
	margin:0 auto;
	height:26px;
	line-height:23px;
}
#wrapper {
	width:587px;
	margin:0 auto;
	text-align:left;
	background:#fff;
	padding:30px;
	color:#555;
	border-top:1px solid #b8b8b8;
	border-left:1px solid #b8b8b8;
	border-right:3px solid #999;
	border-bottom:3px solid #999;
}
.lxs {
	width:587px;
	line-height:21px;
	color:#888;
}
.lxs span {
	font-size:14px;
	font-weight:bold;
	line-height:24px;
}
.lxs p span {
	width:84px;
	float:left;
	font-size:12px;
	height:24px;
	font-weight:normal;
	margin-right:30px;
	overflow:hidden;
}
.logo {
	position:absolute;
	margin-left:480px;
}
.logo a img {
	border:0;
	width:100px;
	height:40px;
}
.tab {
	width:587px;
}
.tab th {
	background:#F1F1F1;
	color:#555;
	border-color:#E1E1E1;
	font-weight:normal;
}
.tab td {
	padding:4px 3px;
	line-height:18px;
	border-color:#E1E1E1;
}
h2 {
	font-size:10pt;
}
h3 {
	clear:both;
	display:block;
	width:587px;
	font-size:14px;
	line-height:24px;
	padding-top:6px;
	color:#F73;
}
h3 span {
	font-size:18px;
	font-weight:normal;
	padding:0 6px;
}
h4 {
	font-size:12px;
	display:block;
	float:left;
	line-height:24px;
	margin-bottom:6px;
	color:#999999;
}
h4 span {
	font-weight:normal;
	color:#000000;
}
p {
	clear:both;
}
.w595 {
	width:585px;
	clear:both;
	float:left;
	overflow:hidden;
}
.route_view_module {
	margin:5px 5px 5px 5px;
	float:left;
	text-align:center;
	height:110px;
}
.route_view_module img {
	padding:2px;
	margin-bottom:3px;
	border:solid 1px #999;
}
.route_view_module .placename {
	text-align:center;
}
table {
	table-layout:fixed;
	border-collapse:collapse;
}
td {
	border:1px solid #999;
	padding:1mm;
	font-size:9pt;
}
th {
	background:#CCC;
	font-weight:bold;
	border:1px solid #999;
	padding:1mm;
	font-size:9pt;
}
.list {
	clear:both;
	width:587px;
	margin:0 auto;
}
.list ul {
	width:587px;
}
.list li {
	float:left;
}
.b {
	font-weight:bold;
}
.right {
	text-align:right;
	width:150px;
}
.beizhu h5 {
	margin:0;
}
h1 {
	width:587px;
	font-family:"黑体";
	font-size:18px;
	line-height:30px;
	color:#000;
	padding-top:20px;
	font-weight:normal;
}
/*行程安排*//*#scheduling table,#scheduling img {
	margin:0 auto;
	max-width:532px;
	width:expression( this.width > 532 ? "532px":(this.width+"px") );
}
*/
.tese 
{
	width:563px;
	float:left;
	border:2px solid #f60;
	background:#ffd;
	padding:10px;
	margin:12px 0;
	color:#555;
}
.tese strong {
	color:#f60;
	line-height:24px;
	font-size:14px;
}
#scheduling {
	clear:both;
	width:587px;
	margin:0 auto;
	font-size:12px;
	padding:0 0 12px 0;
	color:#333333;
	overflow:hidden;
}
#scheduling ul {
	margin-left:40px;
}
#scheduling ol {
	margin-left:40px;
}
#scheduling p {
	margin-bottom:20px;
	font-size:14px;
}
#scheduling table {
	width:auto;
	height:auto;
}
#scheduling table td {
	width:auto;
	height:auto;
}
#scheduling .day {
	}#scheduling .day .title {
	height:24px;
	line-height:26px;
	margin-top:12px;
	font-weight:bold;
	color:#555;
	background:#efd;
	overflow:hidden;
}
#scheduling .day .title h5 {
	width:50px;
	float:left;
	font-size:12px;
	text-align:center;
	margin:0 6px 0 0;
	padding:0;
	line-height:24px;
	color:#FFF;
	font-weight:normal;
	background:#7bbb3c;
}
#scheduling .day .nr {
	line-height:21px;
	color:#555;
	padding:6px;
}
#scheduling .day .eat,#scheduling .day .house {
	color:#f73;
	padding-left:6px;
}
.tip2 {
	width:587px;
	font-size:12px;
	text-align:right;
	margin-bottom:12px;
}
.jiage {
	_width:587px;
	line-height:30px;
	margin-bottom:12px;
	padding:0 12px;
	color:#555;
	border:2px solid #f60;
	background:#ffd;
	overflow:hidden;
}
.jiage .box {
	clear:both;
}
.jiage h3 {
	font-size:14px;
	line-height:24px;
	height:24px;
}
.jiage h4 {
	color:#555;
	padding:0;
	margin:0;
	line-height:18px;
}
.jiage em {
	font-size:22px;
	font-style:normal;
	color:#f73;
	font-family:Verdana;
	line-height:25px;
}
.contt {
	width:587px;
	float:left;
	margin-bottom:12px;
}
.beizhu {
	width:587px;
	padding:12px 0;
}
.beizhu h4 {
	width:80px;
	float:left;
	text-align:right;
	height:20px;
	color:#333;
	margin:0;
	padding:0 6px 0 0;
}
.beizhu .cont {
	display:inline-block;
	width:500px;
	line-height:21px;
}
.tip {
	width:647px;
	margin:0 auto;
	text-align:right;
	line-height:24px;
	font-size:12px;
}
.tip1 {
	width:647px;
	margin:0 auto;
	text-align:center;
	line-height:24px;
	font-weight:bold;
	color:#555;
	font-size:12px;
}
@media print {
	.cont {
	margin-top:-10px;
}
}</style>
    </head>
    
    <body>
        <div id="printBtn">
            <div class="list">
                <ul>
                    <li>
                        <%=webinfo.WebName %>
                    </li>
                    <li class="right">
                        <img src="/images/print.gif" align="absmiddle">
                        <a href="#" onClick="javascript:window.print();return false;">
                            [打印本页]
                        </a>
                    </li>
                    <li>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <a href="/line/<%=LineModel.Id %>.html">
                            返回上一页
                        </a>
                    </li>
                    <li class="right">
                        <a href="#" onClick="javascript:window.close();">
                            [关闭窗口]
                        </a>
                    </li>
                </ul>
            </div>
        </div>
        <div id="wrapper" style="margin-top:10px;">
            <div class="logo">
                <a href="<%=webinfo.WebDomain %>" title="<%=webinfo.WebName %>" target="_blank">
                    <img src="<%=webinfo.WebLogo %>">
                </a>
            </div>
            <div class="lxs">
                <span>
                    <%=webinfo.WebCompanyName %>
                </span>
                <p>
                    联系电话：<%=webinfo.WebTel %>，邮箱：<%=webinfo.WebEmail %>
                </p>
                <p>
                    联系地址：<%=webinfo.WebAddress %>
                </p>
            </div>
            <h1>
                <%=LineModel.LineName %>
            </h1>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="tab">
                <tr>
                    <th width="15%">
                        出发城市
                    </th>
                    <td width="35%">
                        <%=ShowCityName(LineModel.CityId)%>
                    </td>
                    <th width="15%">
                        往返交通
                    </th>
                    <td width="35%">
                        <%=LineModel.TrafficIds.TrimStart(',').TrimEnd(',') %>
                    </td>
                </tr>
                <tr>
                <th>
                    行程天数
                </th>
                <td>
                    <%=LineModel.DayNumber %> 天
                </td>
                <th>
                    线路类型
                </th>
                <td>
                    <%=ShowLineTypeName(Convert.ToInt32(LineModel.ProIds)) %>
                </td>
                </tr>
            </table>
            <div class="tese">
                <strong>
                    线路特色
                </strong>
                <br />
                <%=LineModel.LineFeature %>
                <br/>
                <br/>
            </div>
            <br />
            <h3>
                参考行程
            </h3>
            <div id="scheduling">
                <%=ShowLine() %>
            </div>
            <br />
            <br />
            <div class="tip2">
                *以上行程和交通仅供参考，最终确认以所签协议为准。*
            </div>
            <div class="jiage">
                <h3>
                    费用说明
                </h3>
                <div class="box">
                    <span>
                        优惠价:
                        <em class="price">
                            <%=(LineModel.PriceCommon.ToString().Equals("0") || LineModel.PriceCommon.ToString().Equals(""))?"电询":LineModel.PriceCommon.ToString()%>
                        </em>
                        元起
                    </span>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <span>
                       具体日期价格会有所变化，详情请咨询客服
                    </span>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                </div>
                <div class="contt">
                    <%=LineModel.LineCost %>
                </div>
            </div>
            <h3>
                预订指南
            </h3>
            <div class="beizhu">
                <%=LineModel.OrderTips %>
            </div>
            <br />
            <h3>
                温馨提示
            </h3>
            <div class="beizhu">
                <%=LineModel.TravelNotice %>
            </div>
        </div>
        <div class="tip1">
            了解更多旅游线路信息，请访问
            <span style=" color:#008600">
                <%=webinfo.WebName %> <%=webinfo.WebDomain %>
            </span>
        </div>
    </body>

</html>