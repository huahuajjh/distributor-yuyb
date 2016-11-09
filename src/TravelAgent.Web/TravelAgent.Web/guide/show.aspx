<%@ Page Language="C#" MasterPageFile="~/Common.Master"  AutoEventWireup="true" CodeBehind="show.aspx.cs" Inherits="TravelAgent.Web.guide.show" %>
<%@ MasterType VirtualPath="~/Common.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src="../js/jquery-1.10.2.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="/css/style.css" />
<link rel="stylesheet" type="text/css" href="/car/css/car.css" />
<link type="text/css" href="/car/css/jquery-ui.css" rel="stylesheet" />
<script src="/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
<%--<script type="text/javascript" src="/js/default.js"></script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    

    <link href="css/8575557af2e22a645fd8457df2d411b4.css" rel="stylesheet" type="text/css" />

    <form id="form1" runat="server">
   </div><div class="nav_locate">
	 
	  <a href="/">首页</a> &gt <a href="~/guide/default.aspx">游记</a> &gt <a href="javascript:void(0);"><%=tt.title%></a>  
</div>



<div class="notes_head">
	<div class="notes_head_inner">
		<h2><%=gd.title %></h2>
		<a href="add.aspx" class="public">
        <img src="./images/guideimg/public_notes2.png">
        </a>
		<div class="notes_info">
			<span class="portrait">
            <a href="#">
            <img src="../member/images/clubpic.gif" width=52 height=52   >
            </a>
            </span>

			<span class="member_name">
            <a href="#"><%=user.trueName %></a>
            创建于<%=gd.createtime %>
            </span>

			<span class="start_time"><%=begindate %>出发</span>
			<%--<span class="from_to">从浦东到上海</span>--%>
			<span class="sustain_time"><%=gd.tourdays %>天</span>
			<span class="reply_view_num">回复 <em clas="comment_count_num"><%=gd.commentcount %></em> | 浏览 <%=gd.browsecount %></span>
		</div>
		<div class="seal">
			<img src="./images/guideimg/seal1.png">
			<img src="./images/guideimg/seal2.png">
			<img src="./images/guideimg/seal3.png">
		</div>
    </div>	
</div>

<div class="main">
	<div class="notes_main">
            <div class="nav">
            <ul id="J_navbar" class="nav_ul">
			<li class="current"><a href="javascript:void(0);" rel="0">游记详情</a></li>
			<li><a href="javascript:void(0);" rel="1">只看点评</a></li>
		</ul>
                </div>
		<div class="notes_content" id="J_nbox_0" runat=server>
                        <div class="day_box">
                                                        <div class="day_item">
                                <div class="room-title">
                                    <p>第<em>1</em>天</p>
                                    <p class="date">2014-08-02</p>
                                    <p class="cities">
                                                                                    <span></span>&nbsp;&nbsp;<a href="javascript:;" rel="nofollow">浦东</a>
                                             &nbsp;&nbsp;&gt;                                                                                    <span></span>&nbsp;&nbsp;<a href="javascript:;" rel="nofollow">上海</a>
                                                                                     												
                                    </p>
                                </div>

                                <div class="day_content">
                                    <div class="route_title">看看上海不错</div>
                                                                        <div class="day_spot">
                                        <div class="room-city">
                                            <p class="city-name" data-destination="浦东"><span></span>&nbsp;<a href="javascript:;" rel="nofollow">浦东</a></p>
                                        </div>
                                        <div class="spot_gallery_list">
                                            <ul>
                                                                                                <li class="pic_item">
                                                    <a href=""><img src="http://www1.lvyou.com/public/images/web/guide/201408/13/10/6435457f1733f6b5a6e63536d9f5bda012.jpg"/></a>
                                                </li>
                                                                                            </ul>
                                        </div>
                                    </div>
                                                                       <div class="day_spot">
                                        <div class="room-city">
                                            <p class="city-name" data-destination="上海"><span></span>&nbsp;<a href="javascript:;" rel="nofollow">上海</a></p>
                                        </div>
                                        <div class="spot_gallery_list">
                                            <ul>
                                                                                                <li class="pic_item">
                                                    <a href=""><img src="http://www1.lvyou.com/public/images/web/guide/201408/13/10/4d40ffdbbb8cdbf857a33b6d1a0fe9aa56.jpg"/></a>
                                                </li>
                                                                                                <li class="pic_item">
                                                    <a href=""><img src="http://www1.lvyou.com/public/images/web/guide/201408/13/10/ebdebe97aa507a93b8b9214735e41d7e39.jpg"/></a>
                                                </li>
                                                                                                <li class="pic_item">
                                                    <a href=""><img src="http://www1.lvyou.com/public/images/web/guide/201408/13/10/54048c3ed221e4e2502e500c5fa5ee5082.jpg"/></a>
                                                </li>
                                                                                            </ul>
                                        </div>
                                    </div>
                                                                       <div class="day_desc">匙、二是做消费凭证（每张卡可关联自己信用卡，并每卡有三百美元消费额度），所以不能乱放，而且还是上、下船的证件，丢了可上不了船了。上船后就有美女拉你照像，大家跟着照就行了，照不花钱拿照片要钱，一张照片大约20美元，走进船舱就像走进一座豪华酒店，一条皇家大道贯通全船，大道两旁商铺林立，八部全景电梯上下运行，咖啡厅有歌手现场表演，24小时免费提供甜点和饮品，人来人往热闹非凡。大家上船后都先找到自己的房间，行李提前送到房间省了不少力气，我定的是内舱房，原想房间一定窄小，但进去一看还真出乎自己预料，房间不大到格</div>
                                </div>
                            </div>
                                                    </div>
		</div>
            <div  id="J_nbox_1" class="comment_box">
                <div class="comment_box">
<div class="blank"></div>
		<div class="commented_num">
			已有<span class="comment_total"><%=gd.commentcount %></span>条网友的热情评论
		</div>
<div class="comment_list" id="show_comment" runat="server">
		


    </div>
<div class="blank15"></div>
<div class="pager_box" style="text-align: center;">
    
    
</div>
<div class="blank15"></div>
<input type="hidden" class="comment_list_ajax_url" name="comment_list_ajax_url" value="http://www1.lvyou.com/index.php?ctl=comment&act=init_comment&comment_type=1&comment_rel_id=36"/>
<div class="comment_form_box">
		<div class="form_head">
                    回复
		</div>
		
                <div class="comment_editor">
                        <textarea id="comment_content" name="comment_content" class="input_limit input_data" data_type="comment_content" date_route="23" hide_data="" maxlength="300" placeholder="回复游记评论(300字以内)"></textarea>
                </div>
                <input type="hidden" name="comment_user_id" value=""/>
                <input type="hidden" name="comment_type" value="1"/>
                <input type="hidden" name="comment_rel_id" value="<%=gd.Id %>"/>
                <input type="hidden" name="ajax_url" value="Ghandler.ashx?cmd=comment"/>
                <button type="button" class="reply_submit" onclick="pubcomment();">发布</button>
                <script>
                    function pubcomment() {
                        var ajax_url = "Ghandler.ashx?cmd=comment";
                        var contents = $("#comment_content").val();
                        var comment_type = 1;
                        var comment_rel_id = "<%=gd.Id %>";
                        
                        var query = {
                            contents: contents,
                            comment_type: comment_type,
                            comment_rel_id: comment_rel_id
                        };
                        $.ajax({
                            type: "post",
                            url: ajax_url,
                            data: query,
                            async: false,
                            dataType: "JSON",
                            success: function (data) {
                                if (data.result == "true") {
                                    window.location.reload();
                                } else if (data.reason == "needlogin") {
                                    window.location.href = "../member/login.aspx";
                                }
                            }
                        });
                    }
                </script>
    </div>
<div class="blank"></div>
</div>
 
          </div>
		
    </div>
	
	<div class="notes_banner">
            <!-- 点赞功能未开放
		<div class="notes_praise_num">
				<a href="#"><img src="#"></a>
				<span>已有356人点赞</span>
		</div>
            -->
		<div class="notes_comment_num">
		        <a href="#"><img src="images/guideimg/notes_detai_comment.png"></a>
                        <span>已有<em class="comment_count_num"><%=gd.commentcount %></em>人评论</span>
		</div>
		<div class="adver1">
                    <%--<a href='#' ><img src='http://www1.lvyou.com/public/adv/img/201408/15/00/20140815002309_37295.jpg'  width=208 height=130 /></a>--%>
		</div>
		<div class="adver2">
			<%--<a href='#' ><img src='http://www1.lvyou.com/public/adv/img/201408/15/00/20140815002413_46307.jpg'  width=208 height=130 /></a>--%>
		</div>
    </div>
</div>

    </form>
</asp:Content>
