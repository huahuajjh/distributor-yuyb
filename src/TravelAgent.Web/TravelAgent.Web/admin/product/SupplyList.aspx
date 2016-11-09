<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplyList.aspx.cs" Inherits="TravelAgent.Web.admin.product.SupplyList" %>

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
        $(".supply_delete").unbind();
        $(".supply_delete").click(function() {
            var id = $(this).attr("id");
            var name = $(this).attr("name");
            art.dialog.confirm("确认删除供应商[ " + name + " ]吗？", function() {
                $.ajax({
                    type: "POST",
                    url: "../data/Product_Line.aspx",
                    cache: false,
                    dataType: "text",
                    data: { tag: "supply_delete", supplyid: id },
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
        });
    })
</script>
</head>

<body>

	<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">产品管理</a></li>
    <li><a href="#">线路产品</a></li>
    <li><a href="#">供应商</a></li>
    </ul>
    </div>
    
    <div class="rightinfo">
    
    <div class="tools">
    
    	<%--<ul class="toolbar">
        <li class="click"><a href="EditSupply.aspx" title="添加供应商"><span><img src="../images/t01.png" /></span>添加供应商</a></li>
        </ul>--%>
    <%=ShowAdd() %>
    </div>
        <form id="form1" runat="server">
        <table class="tablelist">
    	        <thead>
    	        <tr>
                <th style="width:4%">编号</th>
                <th style="width:15%">供应商名称</th>
                <th style="width:12%">联系人</th>
                <th style="width:12%">办公电话</th>
                <th style="width:12%">手机</th>
                <th style="width:12%">电子邮件</th>
                <th>备注</th>
                <th style="width:8%">是否显示</th>
                <th style="width:10%">管理操作</th>
                </tr>
                </thead>
                <tbody id="AllNav">
        <asp:Repeater ID="rptSupply" runat="server">
        <ItemTemplate>
                <tr>
                    <td style="text-align:center"><%#Eval("Id") %>
                    </td>
                    <td>
                          <%# Eval("supplyName")%>
                    </td>
                    <td>
                          <%# Eval("contactName")%>
                    </td>
                    <td>
                          <%# Eval("telephone")%>
                    </td>
                    <td>
                          <%# Eval("mobilephone")%>
                    </td>
                    <td>
                          <%# Eval("email")%>
                    </td>
                    <td>
                          <%# Eval("remark")%>
                    </td>
                    <td style="text-align:center"><%# Eval("isLock").ToString().Equals("0") ? "显示" : "隐藏"%></td>
                    <td style="text-align:center"><%# ShowEdit(Eval("Id").ToString(),Eval("supplyName").ToString()) %></td>
                </tr> 
        </ItemTemplate>
        </asp:Repeater>
                    <tr id="divNoRecord" runat="server">
                        <td colspan="9" class="noinfo">暂时没有数据！</td>
                    </tr>
                        </tbody>
            </table>
      </form>
    </div>
</body>

</html>
