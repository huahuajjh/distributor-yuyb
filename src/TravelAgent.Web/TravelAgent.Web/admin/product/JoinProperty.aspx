﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JoinProperty.aspx.cs" Inherits="TravelAgent.Web.admin.product.JoinProperty" %>

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
    $(function() {
    $(".city_art").unbind();
        $(".city_art").click(function() {
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
        $(".pro_delete").unbind();
        $(".pro_delete").click(function() {
            var id = $(this).attr("id");
            var name = $(this).attr("name");
            art.dialog.confirm("确认删除参团性质[ " + name + " ]吗？", function() {
                $.ajax({
                    type: "POST",
                    url: "../data/Product_Line.aspx",
                    cache: false,
                    dataType: "text",
                    data: { tag: "property_delete", proid: id },
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
    <li><a href="#">产品管理</a></li>
    <li><a href="#">线路产品</a></li>
    <li><a href="#">参团性质</a></li>
    </ul>
    </div>
    
    <div class="rightinfo">
    
    <div class="tools">
    
    	<%--<ul class="toolbar">
        <li class="click"><a href="EditProperty.aspx" class="pro_art" title="添加参团性质" width="600px" height="250px"><span><img src="../images/t01.png" /></span>添加参团性质</a></li>
        </ul>--%>
        <%=ShowAdd() %>
    </div>
        <form id="form1" runat="server">
        <table class="tablelist">
    	        <thead>
    	        <tr>
                <th style="width:4%">编号</th>
                <th>参团性质名称</th>
                <th style="width:8%">是否显示</th>
                <th style="width:5%">序号</th>
                <th style="width:10%">管理操作</th>
                </tr>
                </thead>
                <tbody id="AllNav">
        <asp:Repeater ID="rptProperty" runat="server">
        <ItemTemplate>
                <tr>
                    <td style="text-align:center"><%#Eval("Id") %>
                    </td>
                    <td>
                          <%# Eval("joinName")%>
                    </td>
                    <td style="text-align:center"><%# Eval("isLock").ToString().Equals("0")?"显示":"隐藏"%></td>
                    <td style="text-align:center"><%# Eval("joinSort")%></td>
                    <td style="text-align:center"><%# ShowEdit(Eval("Id").ToString(), Eval("joinName").ToString())%></td>
                </tr> 
        </ItemTemplate>
        </asp:Repeater>
         <tr id="divNoRecord" runat="server">
                        <td colspan="5" class="noinfo">暂时没有数据！</td>
                    </tr>
                        </tbody>
            </table>
      </form>
    </div>
</body>

</html>
