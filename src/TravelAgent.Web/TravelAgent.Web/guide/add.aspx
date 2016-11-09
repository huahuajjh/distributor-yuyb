<%@ Page Language="C#" MasterPageFile="~/Common.Master"  AutoEventWireup="true" CodeBehind="add.aspx.cs" Inherits="TravelAgent.Web.guide.add" %>
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
   
<link rel="stylesheet" type="text/css" href="./css/css.css" />
<%--<script type="text/javascript" src="./js/lang.js"></script>
<script type="text/javascript" src="./js/js.js"></script>--%>

<link rel="stylesheet" href="./css/jquery-ui.css">
<!-- 日期控件 -->
<script src="./js/datepicker/core.js"></script>
<script src="./js/datepicker/datepicker.js"></script>
<script src="./js/datepicker/widget.js"></script>

<link rel="stylesheet" href="./css/datepicker.css">

<!-- SWFUPLOAD-->
<%--<link rel="stylesheet" href="./css/swf.css">
<script src="./js/swf/swfupload.js"></script>
<script src="./js/swf/handlers.js"></script>
<script src="./js/swf/swfupload.queue.js"></script>
<script src="./js/swf/fileprogress.js"></script>--%>

<link rel="stylesheet" type="text/css" href="./css/bf7ed159deabdd1a409950a1335697cd.css" />
<script type="text/javascript" src="./js/7358f41d9f08ceec0b773c831f6e3a17.js"></script>

<div class="blank13"></div>
<div class="wrap">
	<!--start游记发布容器-->
    <div class="container">
		<!--start入口标题-->
        <div class="guide_title_tip">
            <i></i><label>游记</label><span>分章节写游记，丰富的行程给爱旅游的朋友更多惊喜</span>
         </div>
		 <!--end入口标题-->
		 <div class="blank20"></div>

		 <!--start游记表单-->
		 <div class="write_body">
			<div class="guide_title_box tit_box">
				<label>游记标题</label>
                <input type=hidden id="tourid" runat=server />

                                    <div class="input_item"><input class="input_limit input_data" id="guide_title" data_type="guide_title"  hide_data=""   maxlength="30" max_data="30" type="text" holder="给TA去个标题吧" value="<%=temp1.title %>"/><span >还可以输入<i class="limit_num">30</i>字</span></div>

                        </div>
			<div class="blank10"></div>
                        <div class="blank10"></div>
                        <div class="guide_title_box tit_box">
				<label>出行方式</label>
                <script>

                    function seltour_range(str) {
                        $("a[date_type='tour_range']").removeClass("cur");
                        $("a[date_type='tour_range'][rel='" + str + "']").addClass("cur");
                        $("#tour_range").val(str);
                    }
                    function seltour_type(str) {
                        $("a[date_type='tour_type']").removeClass("cur");
                        $("a[date_type='tour_type'][rel='" + str + "']").addClass("cur");
                        $("#tour_type").val(str);
                    }
                </script>
                                    <div class="btn_checkbox_item">
                                        <a href="javascript:void(0);" class="gn tour_range cur" rel="1" date_type="tour_range" onclick="seltour_range(1);">国内游</a>
                                        <a href="javascript:void(0);" class="cj tour_range " rel="2" date_type="tour_range" onclick="seltour_range(2);">出境游</a>
                                        <a href="javascript:void(0);" class="gt tour_range " rel="3" date_type="tour_range" onclick="seltour_range(3);">周边游</a>
                                        <span class="f_l">&nbsp;&nbsp;>&nbsp;&nbsp;</span>
                                        <a href="javascript:void(0);" class="zz tour_type cur" rel="1" date_type="tour_type" onclick="seltour_type(1);">跟团游</a>
                                        <a href="javascript:void(0);" class="zb tour_type " rel="2" date_type="tour_type" onclick="seltour_type(2);">自助游</a>
                                        <a href="javascript:void(0);" class="zj tour_type " rel="3" date_type="tour_type" onclick="seltour_type(3);">自驾游</a>
                                        <input class="tour_range_v" type="hidden" name="tour_range" id="tour_range" value="<%=temp1.tourrange %>"/>
                                        <input class="tour_type_v" type="hidden" name="tour_type" id="tour_type" value="<%=temp1.tourtype %>"/>
                                    </div>

                        </div>
			<!--start 每天的游记-->
            <div id="show_guide" runat=server>
           


            </div>
<!--end 每天的游记-->
 <script>

     $("#begin_date_1").datepicker({
         format: 'Y-m-d',
         numberOfMonths: 2,  //显示两个月
         maxDate: 0 //从当前日期起可选
     });
    
                   
</script>

                        <div class="blank20"></div>
                        <div class="add_day_btn_box">
                            <a href="javascript:void(0);" class="add_day_btn" onclick="addroute();"></a>
                        </div>
                        <div class="blank10"></div>
                        <div class="guide_save_box">
                            <div class="guide_save_item">
                                <a class="send_guide_btn" href="javascript:void(0)" onclick="save_guide();">发表游记</a>
                                <span style=" display: inline-block; margin: 0 10px; ">或者</span>
                                <a class="save_draft_btn" href="javascript:void(0)" onclick="save_draft();">保存草稿</a>
                            </div>
                        </div>
		 </div>
                 
		 <!--end游记表单-->
    </div>
	<!--end游记发布容器-->
</div>
<div class="blank20">
<input type=hidden id="curr_guideid" />
<input type=hidden id="curr_routeid" />
<input type=hidden id="curr_spotid" />
<input type=hidden id="curr_gallery" />
</div>
<!--start 添加拍摄地点-->
<div class="poi_popup" id="add_address">
    <a href="javascript:void(0);" class="close" onclick="Close_add_spot();">X</a>
    <h3 class="addr_title">添加拍摄地点</h3>
    <div class="poi_address">
    	<div class="addr_list" id="addr_list_curr"></div>
        <div class="add_input">
            <input type="text" name="addr_name" id="addr_name"/><a class="add_address_btn" href="javascript:void(0);" onclick="add_spot();">确认</a>
        </div>
    </div>
    <div class="blank10"></div>
    <div class="address_save_box"><a href="javascript:void(0);" class="save_address_list_btn" onclick="refleshpage();">保存</a></div>
</div>
<!--end 添加拍摄地点-->

<!--start 编辑拍摄地点-->
<div class="poi_popup_edit">
    <a href="javascript:void(0);" class="close">X</a>
    <h3 class="addr_title">编辑拍摄地点</h3>
    <div class="poi_address">
        <div class="edit_input">
            <input type="text" name="edit_addr_name"/>
        </div>
    </div>
    <div class="blank10"><input type="hidden" id="hideaddress"></div>
    <div class="address_edit_box"><a href="javascript:void(0);" class="save_edit_address_btn" onclick="refleshpage();">保存</a></div>
</div>
<!--end 编辑拍摄地点-->

<!--start 添加图片 -->
<div class="add_pic_popup">
    <a href="javascript:void(0);" class="close" onclick="Close_Pic();">X</a>
    <iframe id="forup" src="#" style=" width:100%; height:98%"> </iframe>
   <%--  <form id="form1" action="Ghandler.ashx?cmd=upload" method="post" enctype="multipart/form-data">
        <div class="fieldset flash" id="queue">

        </div>
        <div id="divStatus">0 个文件已上传</div>
        <div>
                
                <input id="file_upload" name="file_upload" type="file" multiple="true">上传图片</input>
                
        </div>
    </form>--%>
</div>
<!-- end 添加图片-->
<div class="photo_html_box">
    <div class="photo_item f_l">
        <div class="img_box"><img src="" /></div>
        <div class="img_action">
            <a href="javascript:void(0)" class="del_img" data_gallery_id="" >删除</a>
        </div>
    </div>
</div>
   
   <script>
       function save_guide() {
           if (!confirm("确定发表么")) {
               
               return;
           }
           
           $(".guide_day_item").each(function () {
               var routeid = $(this).attr("data_route_id");
               var date = $("#begin_date_" + routeid).val();
               var title = $("#route_title_" + routeid).val();
               var content = $("#route_content_" + routeid).val();
               var url = "Ghandler.ashx?cmd=saveroute";
               var query = {
                   id: routeid,
                   date: date,
                   title: title,
                   content: content
               };
               $.ajax({
                   type: "post",
                   url: url,
                   data: query,
                   async: false,
                   dataType: "JSON",
                   success: function (result) {

                   }
               });
           });
           var tourid = "<%=tourid.ClientID %>";
           tourid = $("#" + tourid).val();
           var guide_title = $("#guide_title").val();
           var tour_range = $("#tour_range").val();
           var tour_type = $("#tour_type").val();
           var url = "Ghandler.ashx?cmd=save_guide";
           var query = {
               id: tourid,
               title: guide_title,
               tourrange: tour_range,
               tourtype: tour_type
           };
           $.ajax({
               type: "post",
               url: url,
               data: query,
               async: false,
               dataType: "JSON",
               success: function (result) {

               }
           });
       }
       function save_draft() {
           var tourid = "<%=tourid.ClientID %>";
           tourid = $("#" + tourid).val();
           var guide_title = $("#guide_title").val();
           var tour_range=$("#tour_range").val();
           var tour_type=$("#tour_type").val();
           var url = "Ghandler.ashx?cmd=savetemp";

           var query = {
               id: tourid,
               title:guide_title,
               tourrange: tour_range,
               tourtype: tour_type
           };
           $.ajax({
                type: "post",
                url: url,
                data:query,
                async:false, 
                dataType: "JSON",
                success: function (result) {
                
                }
            });
           $(".guide_day_item").each(function () {
               var routeid = $(this).attr("data_route_id");
               var date = $("#begin_date_" + routeid).val();
               var title = $("#route_title_" + routeid).val();
               var content = $("#route_content_" + routeid).val();
               var url = "Ghandler.ashx?cmd=saveroute";
           var query = {
               id: routeid,
               date:date,
               title:title,
               content:content
           };
           $.ajax({
                type: "post",
                url: url,
                data:query,
                async:false, 
                dataType: "JSON",
                success: function (result) {
                
                }
            });
           });
       }

    var hidearray = new Array();
    function refleshpage() {
        window.location.reload();
    }
function addroute(){
    var tourid = "<%=tourid.ClientID %>";
    var tid = $("#" + tourid).val();
    
     var url = "Ghandler.ashx?cmd=AddRoute&gid=" + tid;
    $.ajax({
        type: "get",
        url: url,
        dataType: "JSON",
        success: function (result) {
            window.location.reload();
        }
    });
}
function deleteroute(sid) {
    var url = "Ghandler.ashx?cmd=DelRoute&rid=" + sid;
    $.ajax({
        type: "get",
        url: url,
        dataType: "JSON",
        success: function (result) {
            window.location.reload();
        }
    });
}

function Show_Datepicker(day_num) {
    $("#begin_date_" + day_num).datepicker("show");
}
function add_spots(tpid, routeid) {
    hideaddress = new Array();
    $("#add_address").css("display", "block");
    $("#curr_guideid").val(tpid);
    $("#curr_routeid").val(routeid);
}
function add_spot() {
    var url = "Ghandler.ashx";
    var gid = $("#curr_guideid").val();
    var rid = $("#curr_routeid").val();
    var areaname = $("#addr_name").val();
    //alert(areaname);
    var query = {
        cmd:"AddSpot",
        gid:gid,
        rid:rid,
        areaname:areaname
    };
    $.ajax({
        type: "post",
        data: query,
        url: url,
        dataType: "text",
        success: function (datas) {
            var json = jQuery.parseJSON(datas);
            var html =  $("#addr_list_curr").html();

            html += "<div class=\"poi\"><span>" + json.areaname + "</span><a class=\"addr_tag\" href=\"javascript:void(0);\" onclick=\"delete_spot(" + json.id + ");\" >x</a></div>";
            //var hideaddress = $("#hideaddress").val();
            var mjson = { "id": json.id, "name": json.areaname };
            hidearray.push(mjson);
            $("#addr_list_curr").html(html);
        }
    });
}
//小框，删除spot
function delete_spot(spotid) {
    var url = "Ghandler.ashx?cmd=DelSpot&rid=" + spotid;
    $.ajax({
        type: "get",
        url: url,
        dataType: "JSON",
        success: function (result) {
            SpliceItem(spotid);
            var html = "";
            for (var i = 0; i < hidearray.length; i++) {
                html += "<div class=\"poi\"><span>" + json.areaname + "</span><a class=\"addr_tag\" href=\"javascript:void(0);\" onclick=\"delete_spot(" + json.id + ");\" >x</a></div>";
            }
            $("#addr_list_curr").html(html);
            window.location.reload();
        }
    });
}
//外部，删除spot
function delete_spots(spotid) {
    var url = "Ghandler.ashx?cmd=DelSpot&rid=" + spotid;
    $.ajax({
        type: "get",
        url: url,
        dataType: "JSON",
        success: function (result) {
            
            
        }
    });
    window.location.reload();
}
function SpliceItem(id) {
    for (var i = 0; i < hidearray.length; i++) {
        if (hidearray[i].id == id) {
            hidearray.splice(i, 1);
        }
    }
}
function thismouseover(sid) {

    $(".poi_dot_spot_" + sid).find(".spot_gallery_num").css("display", "none");
    $(".poi_dot_spot_" + sid).find(".spot_action").css("display", "block");
    //alert(11111);
    //$("#p_data_spot_id_" + sid).css("display","block");
}
function thismouseout(sid) {
    $(".poi_dot_spot_" + sid).find(".spot_action").css("display", "none");
    $(".poi_dot_spot_" + sid).find(".spot_gallery_num").css("display", "block");
    //alert(22222);
    //$("#p_data_spot_id_" + sid).css("display", "none");
}
//点击spot
function clickspot(spotid, routuid) {
    $(".poi_dot_route_"+routuid).removeClass("on");
    $(".poi_dot_spot_" + spotid).addClass("on"); //alert("#poi_dot_spot_" + sid); return;
    var url = "Ghandler.ashx?cmd=GetGallery&spotid=" + spotid;
    $.ajax({
        type: "get",
        url: url,
        dataType: "JSON",
        success: function (data) {
            //            alert(data.length);
            //            var json = jQuery.parseJSON(data);
            //            alert(json.length);
            var html = "";
            if (data.length > 0) {
                for (var i = 0; i < data.length; i++) {
                    html += "<div class=\"photo_item f_l\" >";
                    html += "<div class=\"img_box\"><img src=\"../" + data[i].image + "\" data=\"#\"></div>";
                    html += "<div class=\"img_action\">";
                    html += "<a href=\"javascript:void(0)\" class=\"del_img\" data_route_id=\"" + routuid + "\" data_spot_id=\"" + spotid + "\" data_gallery_id=\"79\">删除</a>";
                    html += "</div>";
                    html += "</div>";
                }
            } else {
                html += "<div class=\"photo_null f_l\" style=\"\"><i></i><span>这一天没有照片，请</span></div>";
            }
            html += "<div class=\"photo_null f_l\" style=\"\"><a class=\"add_pic_btn\" href=\"javascript:void(0);\" onclick=\" Add_Pic(" + spotid + "," + routuid + ")\">添加照片</a></span></div>";
            //alert(html);
            $(".photo_content_box_route_" + routuid).html(html);

        }
    });
}
function Add_Pic(spotid,routeid) {
    $(".add_pic_popup").css("display", "block");
    $("#curr_spotid").val(spotid);
    $("#curr_routeid").val(routeid);
    $("#forup").attr("src", "forupload.aspx?rid=" + routeid+"&sid="+spotid);
}
function Close_Pic() {
    $(".add_pic_popup").css("display", "none");
}
function Close_add_spot() {
    $("#add_address").css("display", "none");
}

        


</script>



</asp:Content>


