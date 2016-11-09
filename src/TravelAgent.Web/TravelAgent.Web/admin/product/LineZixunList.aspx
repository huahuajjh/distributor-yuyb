﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LineZixunList.aspx.cs" Inherits="TravelAgent.Web.admin.product.LineZixunList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>无标题文档</title>
<link href="../css/style.css" rel="stylesheet" type="text/css" />
<link href="/css/pagination.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" href="/artDialog/skins/blue.css" />
<script type="text/javascript" src="/js/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="../js/select-ui.min.js"></script>
<script type="text/javascript" src="/js/jquery.pagination.js"></script>
<script type="text/javascript" src="/artDialog/artDialog.source.js?skin=blue"></script>
<script type="text/javascript" src="/artDialog/plugins/iframeTools.source.js"></script>
<script type="text/javascript">
    $(function() {
            $(".select1").uedSelect({
                width: 150
            });
            //分页参数设置
            $("#Pagination").pagination(<%=pcount %>, {
                callback: pageselectCallback,
                prev_text: "« 上一页",
                next_text: "下一页 »",
                items_per_page:<%=pagesize %>,
	            num_display_entries:3,
	            current_page:<%=page %>,
	            num_edge_entries:2,
	            link_to:"?<%=CombUrlTxt(this.linename,this.linecontent) %>page=__id__"
           });
           $("#chkSelect").click(function(){
                if($(this).attr("checked"))
                {
                    $(":checkbox[name^='rptVisa']").attr("checked",true);
                }
                else
                {
                    $(":checkbox[name^='rptVisa']").attr("checked",false);
                }
            })
           $(".zixun_art").unbind();
           $(".zixun_art").click(function() {
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
          $(".linelist_delete").unbind();
          $(".linelist_delete").click(function() {
                var id = $(this).attr("id");
                art.dialog.confirm("确认删除该条咨询吗？", function() {
                    $.ajax({
                        type: "POST",
                        url: "../data/Zixun.aspx",
                        cache: false,
                        dataType: "text",
                        data: {zixunid: id },
                        success: function(msg) {
                            //提示删除成功消息
                            if (msg == "true") {
                                document.getElementById("btnQuery").click();
                                return false;
                            }
                            else {
                                art.dialog.alert("删除失败！");
                                return false;
                            }
                        }
                    })
                }, function() {
                    art.dialog.close();
                });
                return false;
            })
//          $(".zixun_art").unbind();
//          $(".zixun_art").click(function() {
//                var id = $(this).attr("id");
//                art.dialog.confirm("确认已回复该条咨询了吗？", function() {
//                    $.ajax({
//                        type: "POST",
//                        url: "../data/Zixun.aspx",
//                        cache: false,
//                        dataType: "text",
//                        data: {zixun_id: id },
//                        success: function(msg) {
//                            //提示删除成功消息
//                            if (msg == "true") {
//                                document.getElementById("btnQuery").click();
//                                return false;
//                            }
//                            else {
//                                art.dialog.alert("确认失败！");
//                                return false;
//                            }
//                        }
//                    })
//                }, function() {
//                    art.dialog.close();
//                });
//                return false;
//            })
            $("#lbtnDel").click(function(){
                 if($(":checkbox[name^='rptList']:checked").length==0)
                 {
                    art.dialog.alert("请先选择咨询问题！");
                    return false;
                 }
            })
      });
     function pageselectCallback(page_id, jq) {
           //alert(page_id); 回调函数，进一步使用请参阅说明文档
     }
     
</script>


</head>


<body>

	<div class="place">
    <span>位置：</span>
    <ul class="placeul">
   <li><a href="#">产品管理</a></li>
    <li><a href="#">线路产品</a></li>
    <li><a href="#">咨询列表</a></li>
    </ul>
    </div>
    <form id="form1" runat="server">
    <div class="rightinfo">
    
    <div class="tools">
    
    	<ul class="toolbar">
        <li><span><img src="../images/t03.png" /></span><asp:LinkButton 
                ID="lbtnDel" runat="server" Text="批量删除" onclick="lbtnDel_Click"></asp:LinkButton></li>
        </ul>
       
             <div class="usercity">
            <div class="cityleft" style=" padding-top:7px;">产品名称:</div>
            <div class="cityleft">
                <asp:TextBox ID="txtLineName" runat="server" CssClass="dfinput" Width="120px"></asp:TextBox></div>
                <div class="cityleft" style=" padding-top:7px;">问题:</div>
            <div class="cityleft">
                <asp:TextBox ID="txtLineZixun" runat="server" CssClass="dfinput" Width="120px"></asp:TextBox></div>
    <div class="cityleft"><asp:Button ID="btnQuery" runat="server" Text="查询" 
            CssClass="scbtn" onclick="btnQuery_Click" />
    </div>
    </div>
    
    </div>
    
    
    <table class="tablelist">
    	<thead>
    	<tr>
    	<th style="width:3%; text-align:center"><input id="chkSelect" name="chkSelect" type="checkbox" value="" /></th>
        <th style="width:4%">编号</th>
        <th style="width:18%">名称</th>
        <th style="width:30%">问题</th>
        <th style="width:12%">联系方式</th>
        <th style="width:13%">电子邮件</th>
        <th style="width:10%">状态</th>
        <th style=" width:10%">操作</th>
        </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptList" runat="server">
            <ItemTemplate>
                 <tr>
                    <td style="text-align:center"><asp:CheckBox ID="cb_id" CssClass="checkall" runat="server" /></td>
                    <td style="text-align:center"><asp:Label ID="lb_id" runat="server" Text='<%#Eval("Id")%>'></asp:Label></td>
                    <td style="line-height:20px;"><a href="/Line.aspx?id=<%# Eval("LineId") %>" target="_blank" class="tablelink"><%# Eval("lineName") %></a></td>
                    <td style="text-align:left; line-height:20px;"><%# Eval("ConsultContent")%></td>
                    <td style="text-align:left"><%# Eval("LinkTel")%></td>
                    <td style="text-align:left"><%# Eval("LinkEmail")%></td>
                    <td style="text-align:center"><%# Eval("IsReply").ToString().Equals("0") ? "<font color='red'>未回复</font>" : "已回复"%></td>
                    <td style="text-align:center"><%# ShowEdit(DataBinder.Eval(Container.DataItem, "[0]").ToString(),Convert.ToInt32(Eval("IsReply")))%></td>
                </tr> 
            </ItemTemplate>
            </asp:Repeater>
            <tr id="trNoRecord" runat="server">
                 <td colspan="8" class="noinfo">暂时没有数据！</td>
           </tr>
           <tr id="trPagination" runat="server">
                  <td colspan="8">
                        <div id="Pagination" class="right flickr"></div>
                        <div id="divTotalCount" class="right" style=" margin-right:20px; padding-top:10px;">总共有 <span style="color:Red"><%=pcount %></span> 条记录</div>
                  </td>
           </tr>
        </tbody>
    </table>
  
    </div>
    </form>
    <script type="text/javascript">
        $('.tablelist tbody tr:odd').addClass('odd');
	</script>

</body>

</html>
