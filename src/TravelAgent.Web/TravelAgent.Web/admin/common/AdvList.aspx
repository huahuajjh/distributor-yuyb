<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdvList.aspx.cs" Inherits="TravelAgent.Web.admin.common.AdvList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>广告位管理</title>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/jquery-1.3.2.min.js"></script>
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
                        $(this).css("display", "block");
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
            $(".adv_art").unbind();
            $(".adv_art").click(function() {
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
            $(".adv_delete").unbind();
            $(".adv_delete").click(function() {
                var id = $(this).attr("id");
                var name = $(this).attr("name");
                art.dialog.confirm("确认删除广告位[ " + name + " ]以及广告内容吗？", function() {
                    $.ajax({
                        type: "POST",
                        url: "../data/Common.aspx",
                        cache: false,
                        dataType: "text",
                        data: { tag: "adv_delete", advid: id },
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
    </ul>
    </div>
    <div class="rightinfo">
    <div class="tools">
    	<%--<ul class="toolbar">
        <li class="click"><a class="adv_art" href="AdvEdit.aspx"  title="添加广告位" width="700px" height="460px"><span><img src="../images/t01.png" /></span>添加广告位</a></li>
        </ul>--%>
        <%=ShowAdd() %>
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="tablelist">
        <thead>
      <tr>
        <th width="6%">编号</th>
        <th width="25%">广告位名称</th>
        <th width="15%">备注信息</th>
        <th width="8%">类型</th>
        <th width="8%">数量</th>
        <th width="10%">尺寸</th>
        <th width="10%">链接目标</th>
        <th width="">管理操作</th>
      </tr>
      </thead>
      <tbody id="AllNav">
    <asp:Repeater ID="rptList" runat="server" >
      <ItemTemplate>
      <%--<tr>
        <td style="text-align:center"><%# Eval("Id")%></td>
        <td><a title="管理该广告位下的广告列表" href="BarList.aspx?Pid=<%#Eval("ID") %>"><%#Eval("Title")%></a></td>
        <td align="center"><%#Eval("AdRemark").ToString()%></td>
        <td align="center">
        <%#GetTypeName(Eval("AdType").ToString())%>
        </td>
        <td align="center"><%#Eval("AdNum").ToString()%></td>
        <td align="center"><%#Eval("AdWidth").ToString()%>×<%#Eval("AdHeight").ToString()%></td>
        <td align="center"><%#Eval("AdTarget")%></td>
        <td align="center"><span><a class="tablelink" href="BarList.aspx?Pid=<%#Eval("ID") %>">内容管理</a>&nbsp;<a class="tablelink" href="AdvView.aspx?id=<%#Eval("ID") %>">调用</a>&nbsp;<a class="tablelink" href="AdvEdit.aspx?id=<%#Eval("ID") %>">编辑</a></span></td>
      </tr>--%>
      <%# BindDataTR((System.Data.DataRowView)Container.DataItem)%>
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
