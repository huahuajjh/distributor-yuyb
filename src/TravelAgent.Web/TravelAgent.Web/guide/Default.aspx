<%@ Page Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TravelAgent.Web.guide.Default" %>
<%@ MasterType VirtualPath="~/Common.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="../js/jquery-1.7.2.min.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="/css/style.css" />
<link rel="stylesheet" type="text/css" href="/car/css/car.css" />
<link type="text/css" href="/car/css/jquery-ui.css" rel="stylesheet" />
<%--<script src="/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
<script type="text/javascript" src="/js/default.js"></script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<link rel="stylesheet" type="text/css" href="./css/css.css" />
<%--<script type="text/javascript" src="./js/lang.js"></script>
<script type="text/javascript" src="./js/js.js"></script>--%>
<div class="big_pic">
   <img src="./image/nav.png">
	
</div>

<div class="recommend_issue">
	<div class="recommend">
		<span>版主推荐</span>
		<ul>
                    <li><a href="javascript:void(0)" onclick="$.param_waterfull(this)" data_type="order_by_type" data_value="is_hot">热门</a></li>
			<li><a href="javascript:void(0)" onclick="$.param_waterfull(this)" data_type="order_by_type" data_value="">最新发表</a></li>
			<li><a href="javascript:void(0)" onclick="$.param_waterfull(this)" data_type="order_by_type" data_value="is_recommend">优质精华</a></li>
		</ul>
		<span>推荐景点</span>
		<ul>
                                            <li><a href="javascript:void(0)" onclick="$.param_waterfull(this)" data_type="area_name" data_value="泰山">泰山</a></li>
                                            <li><a href="javascript:void(0)" onclick="$.param_waterfull(this)" data_type="area_name" data_value="蒙山">蒙山</a></li>
                                            <li><a href="javascript:void(0)" onclick="$.param_waterfull(this)" data_type="area_name" data_value="崂山">崂山</a></li>
                                            <li><a href="javascript:void(0)" onclick="$.param_waterfull(this)" data_type="area_name" data_value="黄山">黄山</a></li>
                                            <li><a href="javascript:void(0)" onclick="$.param_waterfull(this)" data_type="area_name" data_value="青岛海底世界">青岛海底世界</a></li>
                                            <li><a href="javascript:void(0)" onclick="$.param_waterfull(this)" data_type="area_name" data_value="地下大峡谷">地下大峡谷</a></li>
                                            <li><a href="javascript:void(0)" onclick="$.param_waterfull(this)" data_type="area_name" data_value="天上王城">天上王城</a></li>
                                            <li><a href="javascript:void(0)" onclick="$.param_waterfull(this)" data_type="area_name" data_value="竹泉村">竹泉村</a></li>
                                            <li><a href="javascript:void(0)" onclick="$.param_waterfull(this)" data_type="area_name" data_value="台儿庄">台儿庄</a></li>
                                            <li><a href="javascript:void(0)" onclick="$.param_waterfull(this)" data_type="area_name" data_value="智圣汤泉">智圣汤泉</a></li>
                                            <li><a href="javascript:void(0)" onclick="$.param_waterfull(this)" data_type="area_name" data_value="太阳部落">太阳部落</a></li>
                                            <li><a href="javascript:void(0)" onclick="$.param_waterfull(this)" data_type="area_name" data_value="窑湾古镇">窑湾古镇</a></li>
                    			
		</ul>
		<span>行程天数</span>
		<ul class="date_num">
                    <li><a href="javascript:void(0);" data_type="tour_days" data_value="1" onclick="$.param_waterfull(this)"><em>1</em>天</a></li>
			<li><a href="javascript:void(0);" data_type="tour_days" data_value="2" onclick="$.param_waterfull(this)"><em>2</em>天</a></li>
			<li><a href="javascript:void(0);" data_type="tour_days" data_value="3" onclick="$.param_waterfull(this)"><em>3</em>天</a></li>
			<li><a href="javascript:void(0);" data_type="tour_days" data_value="4" onclick="$.param_waterfull(this)"><em>4</em>天</a></li>
			<li class="noborder"><a href="javascript:void(0);" data_type="tour_days" data_value="5" onclick="$.param_waterfull(this)"><em>5</em>天</a></li>
			<li><a hhref="javascript:void(0);" data_type="tour_days" data_value="6" onclick="$.param_waterfull(this)"><em>6</em>天</a></li>
			<li class="noborder"><a href="javascript:void(0);" data_type="tour_days" data_value="0" onclick="$.param_waterfull(this)"><em class="hide">0</em>更多</a></li>
		</ul>
	
    </div>
	<div class="issue">
	    
		<div class="public_notes"><a href="add.aspx"><img src="./image/public_notes.png"></a></div>
		<div class="notes_total">
			<div class="notes_num"><span>6</span> 篇游记攻略</div>
			<div class="notes_bourn"><span>8</span> 个目的地</div>
		</div>
    </div>
	
</div>

<div class="main">
    <!--固定4列瀑布流-->
    <div class="col_container" id="pubu1">
    
    </div>
    <div class="col_container" id="pubu2">
   
    </div>
    <div class="col_container" id=pubu3>
    
    </div>
    <div class="col_container" id="pubu4">
   
    </div>
    <!--分页盒子-->
    <div class="blank15"></div>
    <div class="pager_box" style="text-align: center;"></div>
    <div class="blank15"><input type="hidden" id="datalists" runat="server"></div>
</div>
<script>
    $(document).ready(function () {
        var datalists = $("#<%=datalists.ClientID %>").val(); //alert(datalists);
        var strarr = datalists.split("|"); //alert(strarr);
        for (var i = 0; i < strarr.length; i++) {
            var url = "Ghandler.ashx?cmd=guidelist";
            var query = {
                id: strarr[i]
            };
            var html = "";
            $.ajax({
                type: "post",
                url: url,
                data: query,
                async: false,
                dataType: "JSON",
                success: function (data) {
                    //alert(data.Id); //alert(strarr[i]);
                    html = "";
                    html += '<div class="item">';
                    html += '<div class="notes_title">';
                    html += '<a href="show.aspx?id=' + data.Id + '" class="title_pic"><img src="../' + data.image + '"></a>        <a href="show.aspx?id=' + data.Id + '" class="title_content">' + data.title + '</a>';
                    html += '</div>';
                    html += '<div class="notes_count">';
                    html += '<!--点赞功能占未开放<span class="praise">0</span>-->';
                    html += '<span class="reply_count">' + data.commentcount + '</span>';
                    html += '<span class="view_count">' + data.browsecount + '</span>';
                    html += '</div>';
                    html += '<div class="notes_info">';
                    html += '<a href="show.aspx?id=' + data.Id + '"><img class="GUID" uid="1" src="../member/images/clubpic.gif"></a>';
                    html += '<span><a href="#">'+data.nickname+'</a></span>';
                    html += '<div><a href="show.aspx?id=' + data.Id + '" class="notes_info_content">' + data.routecontent + '</a></div>';
                    html += '</div>';
                    html += '</div>';
                    html += '';
                    if ((i + 1) % 4 == 1) {
                        $("#pubu1").append(html);
                    }
                    if ((i + 1) % 4 == 2) {
                        $("#pubu2").append(html);
                    }
                    if ((i + 1) % 4 == 3) {
                        $("#pubu3").append(html);
                    }
                    if ((i + 1) % 4 == 0) {
                        $("#pubu4").append(html);
                    }

                }
            });
        }
    });
</script>
</asp:Content>
