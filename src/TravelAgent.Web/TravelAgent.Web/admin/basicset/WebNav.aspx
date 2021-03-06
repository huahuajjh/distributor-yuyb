﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebNav.aspx.cs" Inherits="TravelAgent.Web.admin.basicset.WebNav" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>无标题文档</title>
<link href="../css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/js/jquery-1.7.2.min.js"></script>
<link rel="stylesheet" href="/artDialog/skins/blue.css" />
<script type="text/javascript" src="/artDialog/artDialog.source.js?skin=blue"></script>
<script type="text/javascript" src="/artDialog/plugins/iframeTools.source.js"></script>
<script type="text/javascript">
    var ShowLayer = function(obj, id) {
        if ($(".layer_" + id + "").length != 0) {
            if ($(obj).children().find("span.fuhao").hasClass("nolast")) {
                $(obj).children().find("span.fuhao").removeClass("nolast");
                $(obj).children().find("span.fuhao").addClass("last");

                $(".layer_" + id + "").each(function() {
                    $(this).css("display", "");
                });


            } else {
                $(obj).children().find("span.fuhao").addClass("nolast");
                $(obj).children().find("span.fuhao").removeClass("last");
                $(".layer_" + id + "").each(function() {
                    $(this).css("display", "none");
                });
                $("#AllNav tr").each(function() {
                    if ($(this).css("display") == "none") {
                        $(".layer_" + $(this).attr("id") + "").each(function() {
                            $(this).css("display", "none");
                        });
                    }
                });
            }
        }
        initLayer();
    }
    var initLayer = function() {
        $("#AllNav tr").each(function() {
            if ($(this).css("display") == "none") {
                if ($(".layer_" + $(this).attr("id") + "").length != 0) {
                    if ($(this).children().find("span.fuhao").hasClass("last")) {
                        $(this).children().find("span.fuhao").addClass("nolast");
                        $(this).children().find("span.fuhao").removeClass("last");
                    }
                }
            }
        });
    }
    $(function() {
        $(".nav_art").unbind();
        $(".nav_art").click(function() {
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
        $(".nav_delete").unbind();
        $(".nav_delete").click(function() {
            var id = $(this).attr("id");
            var name = $(this).attr("name");
            art.dialog.confirm("确认删除网站导航[ " + name + " ]及子导航吗？", function() {
                $.ajax({
                    type: "POST",
                    url: "../data/SysInfo.aspx",
                    cache: false,
                    dataType: "text",
                    data: { tag: "nav_delete", navid: id },
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

	<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">系统设置</a></li>
    <li><a href="#">网站导航设置</a></li>
    </ul>
    </div>
    
    <div class="rightinfo">
    
    <div class="tools">
    
    	<%--<ul class="toolbar">
        <li class="click"><a href="EditNav.aspx" class="nav_art" title="添加网站导航" width="700px" height="400px"><span><img src="../images/t01.png" /></span>添加导航</a></li>
        </ul>--%>
        <%= ShowAdd() %>
    
    </div>
        <form id="form1" runat="server">
        <table class="tablelist">
    	        <thead>
    	        <tr>
                <th style="width:4%">编号</th>
                <th style="width:16%">导航名称</th>
                <th>导航链接</th>
                <th style="width:17%">导航状态</th>
                <th style="width:8%">是否显示</th>
                <th style="width:5%">序号</th>
                <th style="width:10%">管理操作</th>
                </tr>
                </thead>
                <tbody id="AllNav">
        <asp:Repeater ID="rptWebNav" runat="server">
        <ItemTemplate>
               <%-- <tr>
                    <td><asp:HiddenField ID="txtClassId" runat="server" Value='<%#Eval("Id") %>' />
                          <asp:HiddenField ID="txtClassLayer" runat="server" Value='<%#Eval("ClassLayer") %>' />
                          <%# Eval("ID") %>
                    </td>
                    <td>
                        <asp:Literal ID="LitFirst" runat="server"></asp:Literal>
                          <%# Eval("Title") %>
                    </td>
                    <td></td>
                    <td></td>
                    <td><%# Eval("Show").ToString() == "1" ? "显示" : "<span style='color:Red'>不显示</span>"%></td>
                    <td><%# Eval("ClassOrder") %></td>
                    <td><a href="#" class="tablelink">添加子栏目</a> <a href="" class="tablelink">修改</a> <a href="" class="tablelink">删除</a></td>
                </tr> --%>
                <%# BindDataTR((System.Data.DataRowView)Container.DataItem)%>
        </ItemTemplate>
        </asp:Repeater>
                        </tbody>
            </table>
        <div id="divNoRecord" runat="server" class="noinfo">暂时没有数据！</div>
      </form>
    </div>
</body>

</html>
