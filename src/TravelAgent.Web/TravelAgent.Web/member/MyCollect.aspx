<%@ Page Title="" Language="C#" MasterPageFile="~/member/Member.Master" AutoEventWireup="true" CodeBehind="MyCollect.aspx.cs" Inherits="TravelAgent.Web.member.MyCollect" %>
<%@ MasterType VirtualPath="~/member/Member.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="user_title"><b>我的收藏</b></div>
        <div class="order">
                <form method="post">
      <input id="hidIds" name="hidIds" type="hidden" />
          <table cellpadding="0" cellspacing="0" border="0" width="770">
            <tbody>
            <tr>
            <th width="60"><input name="selectAll" class="chkAll" type="checkbox"> 全选</th>
            <th class="thleft" width="350">线路信息</th>
            <th width="70">价格</th>
            <th width="80">收藏时间</th>
            <th width="120">操作</th>
            </tr>
            <%=BindCollectList() %>
            </tbody>
          </table>
           <div class="delete_all"><b><input name="selectAll" class="chkAll" type="checkbox"> 全选</b><button id="btnDel">批量删除</button></div>
       </form></div>
      
       <%=BindPage()%>
       <div class="mybeyoulover">
       		<h3>特价线路</h3>
            <ul>
                    <%=BindTejiaLine()%>    
            </ul>
       </div>
    <script type="text/javascript">
        $(function() {
            $(".chkAll").bind('click', function() {
                var val = $(this).is(':checked');
                CheckAll(val);
            });
            $("input[name='collection_id[]']").click(function() {
                $("#hidIds").val("");
                $("input[name='collection_id[]']").each(function() {
                    if (this.checked) {
                        $("#hidIds").val($("#hidIds").val() + $(this).val() + ",");
                    }
                })
                //alert($("#hidIds").val());
            })
            $("#btnDel").click(function() {
                if ($("#hidIds").val() == "") {
                    alert("请先选择收藏线路！");
                    return false;
                }
                $.ajax({
                    url: "/dataDeal/DelLineCollect.aspx",
                    data: { "hidids": $("#hidIds").val() },
                    type: "post",
                    success: function(msg) {
                        if (msg == "success") {
                            if (location.href.indexOf('?') > -1) {
                                location.href = location.href + "&date=" + new Date().toUTCString();
                            }
                            else {
                                location.href = location.href + "?date=" + new Date().toUTCString();
                            }
                        }
                    },
                    error: function() {
                        alert("系统繁忙，请稍候再试...", "");
                    }
                });
            })
            $(".delcollect").click(function() {
                var id = $(this).attr("id");
                $.ajax({
                    url: "/dataDeal/DelLineCollect.aspx",
                    data: { "collectid": id },
                    type: "post",
                    success: function(msg) {
                        if (msg == "success") {
                            if (location.href.indexOf('?') > -1) {
                                location.href = location.href + "&date=" + new Date().toUTCString();
                            }
                            else {
                                location.href = location.href + "?date=" + new Date().toUTCString();
                            }
                        }
                    },
                    error: function() {
                        alert("系统繁忙，请稍候再试...", "");
                    }
                });
            })
        });
        function CheckAll(val) {
            if (!val) {
                $("#hidIds").val("");
            }
            $("input[name='collection_id[]']").each(function() {
                this.checked = val;
                if (val) {
                    $("#hidIds").val($("#hidIds").val() +$(this).val()+ ",");
                }
            });
            $(".chkAll").attr("checked", val); //设定全选按钮状态
            //alert($("#hidIds").val());
        } 
 </script>
</asp:Content>
