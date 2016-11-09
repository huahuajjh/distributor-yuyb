<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckList.aspx.cs" Inherits="TravelAgent.Web.admin.guide.CheckList" %>

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
            //分页参数设置
            $("#Pagination").pagination(<%=pcount %>, {
                callback: pageselectCallback,
                prev_text: "« 上一页",
                next_text: "下一页 »",
                items_per_page:<%=pagesize %>,
	            num_display_entries:3,
	            current_page:<%=page %>,
	            num_edge_entries:2,
	            
           });
           $("#chkSelect").click(function(){
                if($(this).attr("checked"))
                {
                    $(":checkbox[name^='rptNews']").attr("checked",true);
                }
                else
                {
                    $(":checkbox[name^='rptNews']").attr("checked",false);
                }
            })
           $(".link_art").unbind();
           $(".link_art").click(function() {
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
          $(".link_delete").unbind();
          $(".link_delete").click(function() {
                var id = $(this).attr("id");
                var name = $(this).attr("name");
                art.dialog.confirm("确认删除["+name+"]这条链接吗？", function() {
                    $.ajax({
                        type: "POST",
                        url: "../data/Common.aspx",
                        cache: false,
                        dataType: "text",
                        data: { tag: "link_delete", linkid: id },
                        success: function(msg) {
                            //提示删除成功消息
                            if (msg == "true") {
                                location.href = location.href;
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
            $("#lbtnDel").click(function(){
                 if($(":checkbox[name^='rptLinks']:checked").length==0)
                 {
                    art.dialog.alert("请先选择链接！");
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
   <li><a href="#">通用模块</a></li>
    <li><a href="#">友情链接</a></li>
    </ul>
    </div>
    <form id="form1" runat="server">
    <div class="rightinfo">
    
    <div class="tools">
    
    	<ul class="toolbar">
       
        <li><span><img src="../images/t03.png" /></span></li>
        </ul>
       
             <div class="usercity">
            <div class="cityleft" style=" padding-top:7px;">链接名称:</div>
            <div class="cityleft">
                <asp:TextBox ID="txtKeywords" runat="server" CssClass="dfinput" Width="120px"></asp:TextBox></div>
    <div class="cityleft"><asp:Button ID="btnQuery" runat="server" Text="查询" 
            CssClass="scbtn"  />
    </div>
    </div>
    
    </div>
    
    
    <table class="tablelist">
    	<thead>
    	<tr>
    	<th style="width:3%; text-align:center"><input id="chkSelect" name="chkSelect" type="checkbox" value="" /></th>
        <th style="width:4%">编号</th>
        <th  style="">标题</th>
        <th style="width:20%">发布人</th>
        <th style="width:6%">发布时间</th>
        <th style="width:6%">状态</th>
        
        <th style=" width:10%">操作</th>
        </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptClub" runat="server">
            <ItemTemplate>
                 <tr>
                    <td style="text-align:center"><asp:CheckBox ID="cb_id" CssClass="checkall" runat="server" /></td>
                    <td><asp:Label ID="lb_id" runat="server" Text='<%#Eval("Id")%>'></asp:Label></td>
                    <td><a href="" target="_blank" class="tablelink"><%# Eval("title")%></a></td>
                    <td style="text-align:center"><%# Eval("nickname")%></td>
                    <td style="text-align:center"><%# Eval("createtime")%></td>
                    <td style="text-align:center"><%# Eval("ispublish").ToString().Equals("0") ? "未发布" : "已发布" %></td>
                    
                    <td style="text-align:center"><a href='javascript:void(0); publish(<%# Eval("Id")%>);' onclick='' >发布</a>
                    <a href='../../guide/show.aspx?id=<%# Eval("Id") %>' target=_blank>预览</a>
                    <a href='javascript:void(0);deleteit(<%# Eval("Id") %>)' onclick=''>删除</a></td>
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
    
    <div class="tip">
    	<div class="tiptop"><span>提示信息</span><a></a></div>
        
      <div class="tipinfo">
        <span><img src="../images/ticon.png" /></span>
        <div class="tipright">
        <p>是否确认对信息的修改 ？</p>
        <cite>如果是请点击确定按钮 ，否则请点取消。</cite>
        </div>
        </div>
        
        <div class="tipbtn">
        <input name="" type="button"  class="sure" value="确定" />&nbsp;
        <input name="" type="button"  class="cancel" value="取消" />
        </div>
    
    </div>
    
    
    
    
    </div>
    </form>
    <script type="text/javascript">
        $('.tablelist tbody tr:odd').addClass('odd');
	</script>

</body>

</html>

<script>
    function publish(id) {
        var url = "guideback.ashx?cmd=check";
        var query = {
        id:id
    };
    $.ajax({
        type: "post",
        url: url,
        data: query,
        async: false,
        dataType: "JSON",
        success: function (data) {
            window.location.reload();
        }
    });
}
function deleteit(id) {
    var url = "guideback.ashx?cmd=DeleteGuide";
    var query = {
        id: id
    };
    $.ajax({
        type: "post",
        url: url,
        data: query,
        async: false,
        dataType: "JSON",
        success: function (data) {
            window.location.reload();
        }
    });
}
</script>