<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BarList.aspx.cs" Inherits="TravelAgent.Web.admin.common.BarList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>广告内容管理</title>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/jquery-1.3.2.min.js"></script>
    <link rel="stylesheet" href="/artDialog/skins/blue.css" />
    <script type="text/javascript" src="/artDialog/artDialog.source.js?skin=blue"></script>
    <script type="text/javascript" src="/artDialog/plugins/iframeTools.source.js"></script>
    <script type="text/javascript">
        $(function() {
            $(".bar_art").unbind();
            $(".bar_art").click(function() {
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
            $(".bar_delete").unbind();
            $(".bar_delete").click(function() {
                var id = $(this).attr("id");
                var name = $(this).attr("name");
                art.dialog.confirm("确认删除广告[ " + name + " ]吗？", function() {
                    $.ajax({
                        type: "POST",
                        url: "../data/Common.aspx",
                        cache: false,
                        dataType: "text",
                        data: { tag: "bar_delete", barid: id },
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
        })
    </script>
</head>
<body>
<form id="form1" runat="server">
    <div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">系统设置</a></li>
    <li><a href="#">广告列表</a></li>
    <li><a href="#">广告内容管理</a></li>
    </ul>
    </div>
    <div class="rightinfo">
    <div class="tools">
    	<ul class="toolbar">
        <li class="click"><a class="bar_art" href="BarEdit.aspx?aid=<%=aid %>"  title="添加广告" width="700px" height="500px"><span><img src="../images/t01.png" /></span>添加广告</a></li>
        <li class="click"><a href="AdvList.aspx"  title="返回列表"><span><img src="../images/t06.png" /></span>返回列表</a></li>
        </ul>
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="tablelist">
        <thead>
      <tr>
        <th width="6%">编号</th>
        <th width="28%">广告名称【广告位：<asp:Label ID="lblAdvName" runat="server" Text="" ForeColor="Red"></asp:Label>】</th>
        <th width="12%">开始时间</th>
        <th width="12%">到期时间</th>
        <th width="12%">链接</th>
        <th width="6%">状态</th>
        <th width="12%">发布时间</th>
        <th width="">管理操作</th>
      </tr>
      </thead>
      <tbody id="AllNav">
    <asp:Repeater ID="rptList" runat="server" >
      <ItemTemplate>
      <tr>
       <td align="center"><%#Eval("ID")%></td>
        <td><a title="查看广告" target="_blank" href="<%#Eval("AdUrl") %>"><%#Eval("Title")%></a></td>
        <td align="center"><%#string.Format("{0:yyyy-MM-dd}", Eval("StartTime"))%></td>
        <td align="center"><%#string.Format("{0:yyyy-MM-dd}", Eval("EndTime"))%></td>
        <td align="center"><a target="_blank" href="<%#Eval("LinkUrl") %>">广告链接</a></td>
        <td align="center"><%#GetAdState(Eval("IsLock").ToString(), Eval("EndTime").ToString())%></td>
        <td align="center"><%#string.Format("{0:g}",Eval("AddTime"))%></td>
        <td align="center"><span><a class="tablelink bar_art" href="BarEdit.aspx?id=<%#Eval("ID") %>&aid=<%#Eval("Aid") %>" width="700px" height="500px">编辑</a> <a class="tablelink bar_delete" id="<%#Eval("Id")%>" name="<%#Eval("Title")%>" href="#">删除</a></span></td>
      </tr>
      </ItemTemplate>
      </asp:Repeater>
      <tr id="trNoRecord" runat="server">
                        <td colspan="8" class="noinfo">暂时没有数据！</td>
                    </tr>
           </tbody>
      </table>
	</div>
</form>
</body>
</html>
