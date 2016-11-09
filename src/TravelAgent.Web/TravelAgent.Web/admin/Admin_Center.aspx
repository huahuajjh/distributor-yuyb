<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Center.aspx.cs" Inherits="TravelAgent.Web.admin.Admin_Center" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>无标题文档</title>
<link href="css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/jquery.js"></script>
<script type="text/javascript" src="/artDialog/artDialog.source.js?skin=blue"></script>
<script type="text/javascript" src="/artDialog/plugins/iframeTools.source.js"></script>
<script type="text/javascript">
    $(function() {
        $(".order_art").unbind();
        $(".order_art").click(function() {
            var url = $(this)[0].href;
            var title = $(this).attr("title") == undefined ? $(this).attr("ajaxtitle") : $(this).attr("title");
            var width = $(this).attr("width") == undefined ? "800px" : $(this).attr("width");
            var height = $(this).attr("height") == undefined ? "400px" : $(this).attr("height");
            if (title == "" || title == null) {
                title = "　";
            }
            var json = { width: width, height: height, title: title, lock: true };
            art.dialog.open(url, json);
            return false;
        })
    })
</script>
</head>


<body>

	<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">系统首页</a></li>
    </ul>
    </div>
    
    
    <div class="mainbox">
    
    <div class="mainleft">
    
    
    <div class="leftinfo">
    <div class="listtitle">最新订单</div>
        <table class="tablelist" style="margin:5px; width:99%">
    	<thead>
    	<tr>
        <th style="width:18%">下单时间</th>
        <th  style="width:6%">类型</th>
        <th style="width:27%">订单名称</th>
        <th style="width:10%">订单状态</th>
        <th style="width:12%">订单金额</th>
        <th style="width:8%">联系人</th>
        <th style="width:12%">联系电话</th>
        <th style="">操作</th>
        </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptList" runat="server">
            <ItemTemplate>
                 <tr title=" <%# Eval("sourceType").ToString().Equals(Convert.ToInt32(TravelAgent.Tool.EnumSummary.SourceType.PC网页).ToString())?"来自PC端":"来自移动端" %>">
                    <td style="text-align:center"><%# Eval("orderDate")%> <%# Eval("sourceType").ToString().Equals(Convert.ToInt32(TravelAgent.Tool.EnumSummary.SourceType.PC网页).ToString()) ? "" : "<img src='images/mobile.png' />"%></td>
                    <td style="text-align:center"><%# TravelAgent.Tool.EnumHelper.GetMemberName<TravelAgent.Tool.EnumSummary.OrderType>(Eval("orderType"))%></td>
                    <td style="text-align:left"><%# getOrderName(Convert.ToInt32(Eval("lineId")),Convert.ToInt32(Eval("orderType")))%></td>
                    <td style="text-align:center"><%# TravelAgent.Tool.EnumHelper.GetMemberName<TravelAgent.Tool.EnumSummary.OrderState>(Eval("orderState"))%></td>
                    <td style="text-align:center">￥<%# Convert.ToInt32(Eval("orderPrice")) + Convert.ToInt32(Eval("attachPrice"))%></td>
                    <td style="text-align:center"><%# Eval("contactName")%></td>
                    <td style="text-align:center"><%# Eval("contactMobile")%></td>
                    <td style="text-align:center"><a href="<%# showEditUrl(Convert.ToInt32(Eval("Id")),Convert.ToInt32(Eval("orderType")))%>" class="tablelink order_art" title="操作订单" width="730px" height="550px">操作</a></td>
                </tr> 
            </ItemTemplate>
            </asp:Repeater>
            <tr id="trNoRecord" runat="server">
                 <td colspan="8" class="noinfo">暂时没有订单！</td>
           </tr>
        </tbody>
    </table>
    
    
    </div>
    <!--leftinfo end-->

    </div>
    <!--mainleft end-->
    
    
    <div class="mainright">
    
    
    <div class="dflist">
    <div class="listtitle">最新会员</div>    
    <ul class="newlist">
        <asp:Repeater ID="rptClubList" runat="server">
            <ItemTemplate>
                <li><a href="/admin/club/EditClub.aspx?id=<%# Eval("Id")%>" class="tablelink order_art" title="修改会员信息" width="730px" height="350px"><%# Eval("clubName")%></a></li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>        
    </div>
     <div class="dflist1">
    <div class="listtitle">信息统计</div>    
    <ul class="newlist">
    <li><i>会员数：</i><a href="/admin/club/ClubList.aspx" class="tablelink"><asp:Literal ID="ltClubNumber" runat="server" Text=""></asp:Literal></a> 个</li>
    <li><i>线路产品：</i><a href="/admin/product/LineList.aspx" class="tablelink"><asp:Literal ID="ltLineNumber" runat="server" Text=""></asp:Literal></a> 个</li>
    <li><i>签证产品：</i><a href="/admin/visa/VisaList.aspx" class="tablelink"><asp:Literal ID="ltVisaNumber" runat="server" Text=""></asp:Literal></a> 个</li>    
    <li><i>线路订单：</i><a href="/admin/product/LineOrderList.aspx" class="tablelink"><asp:Literal ID="ltLineOrderNumber" runat="server" Text=""></asp:Literal></a> 个</li>
    <li><i>签证订单：</i><a href="/admin/visa/VisaOrderList.aspx" class="tablelink"><asp:Literal ID="ltVisaOrderNumber" runat="server" Text=""></asp:Literal></a> 个</li>
    <li><i>内容数：</i><a href="/admin/common/NewList.aspx" class="tablelink"><asp:Literal ID="ltArtilceNumber" runat="server" Text=""></asp:Literal></a> 个</li>
    </ul>        
    </div>

    </div>
    <!--mainright end-->
    
    
    </div>



</body>
<script type="text/javascript">
	setWidth();
	$(window).resize(function(){
		setWidth();	
	});
	function setWidth(){
		var width = ($('.leftinfos').width()-12)/2;
		$('.infoleft,.inforight').width(width);
	}
</script>
</html>
