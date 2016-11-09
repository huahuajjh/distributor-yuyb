<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminList.aspx.cs" Inherits="TravelAgent.Web.admin.basicset.AdminList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>无标题文档</title>
<link href="../css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/js/jquery-1.7.2.min.js"></script>
<script type="text/javascript" src="/artDialog/artDialog.source.js?skin=blue"></script>
<script type="text/javascript" src="/artDialog/plugins/iframeTools.source.js"></script>
<script type="text/javascript">
    $(function() {
    $(".data_art").unbind();
    $(".data_art").click(function() {
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
        $(".data_delete").unbind();
        $(".data_delete").click(function() {
            var id = $(this).attr("id");
            var name = $(this).attr("name");
            art.dialog.confirm("确认删除用户[ " + name + " ]吗？", function() {
                $.ajax({
                    type: "POST",
                    url: "/admin/data/User.aspx?date=" + new Date().toUTCString(),
                    cache: false,
                    dataType: "text",
                    data: { admin_id: id },
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
    <li><a href="#">操作用户设置</a></li>
    </ul>
    </div>
    
    <div class="rightinfo">
    
    <div class="tools">
    
    	<%--<ul class="toolbar">
        <li class="click"><a href="EditAdmin.aspx" class="data_art" title="添加用户" width="500px" height="350px"><span><img src="../images/t01.png" /></span>添加用户</a></li>
        </ul>--%>
        <%=ShowAdd()%>
        <%--
        <ul class="toolbar1">
        <li><span><img src="../images/t05.png" /></span>设置</li>
        </ul>--%>
    
    </div>
    
    
    <table class="tablelist">
    	<thead>
    	<tr>
        <th style="width:4%">编号</th>
        <th style="width:20%">用户名</th>
        <th style="width:20%">角色</th>
        <th style="width:20%">真实姓名</th>
        <th style="width:20%">是否启用</th>
        <th>操作</th>
        </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptList" runat="server">
                <ItemTemplate>
                    <tr>
                        <td style="text-align:center"><%# Eval("Id")%></td>
                        <td style="text-align:center"><%# Eval("UserName")%></td>
                        <td style="text-align:center"><%# Eval("RoleName")%></td>
                        <td style="text-align:center"><%# Eval("ReadName")%></td>
                        <td style="text-align:center"><%# Eval("IsLock").ToString().Equals("1")?"锁定":"启用"%></td>
                        <td style="text-align:center"><%#ShowEdit(Eval("Id").ToString(),Eval("UserName").ToString())%></td>
                    </tr> 
                </ItemTemplate>
            </asp:Repeater>
           <tr id="divNoRecord" runat="server">
                        <td colspan="6" class="noinfo">暂时没有数据！</td>
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
    
    <script type="text/javascript">
	$('.tablelist tbody tr:odd').addClass('odd');
	</script>

</body>

</html>
