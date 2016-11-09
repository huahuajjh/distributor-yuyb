﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClubList.aspx.cs" Inherits="TravelAgent.Web.admin.club.ClubList" %>

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
                width: 120
            });
            $(".select2").uedSelect({
                width: 60
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
	            link_to:"?<%=CombUrlTxt(this.classid,this.isLock, this.keywords) %>page=__id__"
           });
           $("#chkSelect").click(function(){
                if($(this).attr("checked"))
                {
                    $(":checkbox[name^='rptClub']").attr("checked",true);
                }
                else
                {
                    $(":checkbox[name^='rptClub']").attr("checked",false);
                }
            })
           $(".club_art").unbind();
           $(".club_art").click(function() {
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
          $(".club_delete").unbind();
          $(".club_delete").click(function() {
                var id = $(this).attr("id");
                art.dialog.confirm("确认删除该会员吗？", function() {
                    $.ajax({
                        type: "POST",
                        url: "../data/Club.aspx",
                        cache: false,
                        dataType: "text",
                        data: {clubid: id },
                        success: function(msg) {
                            //提示删除成功消息
                            if (msg.indexOf("true") >= 0) {
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
                 if($(":checkbox[name^='rptClub']:checked").length==0)
                 {
                    art.dialog.alert("请先选择会员！");
                    return false;
                 }
            })
      });
     function pageselectCallback(page_id, jq) {
           //alert(page_id); 回调函数，进一步使用请参阅说明文档
     }
     //订单跳转
     function changeopt(url)
     {
        location.href=url;
     }
     //跳转
     function gotoUrl(url,type)
     {
        
        var chekvalue=""; 
        $("input[name^='rptClub$']").each(function(){
            //debugger;
            if(this.checked)
            {
                if(type=="mobile")
                {
                    chekvalue=chekvalue+$(this).parent().parent().nextAll().eq(2).attr("rel")+",";
                }
                else if(type=="email")
                {
                    chekvalue=chekvalue+$(this).parent().parent().nextAll().eq(3).attr("rel")+";";
                }
            }
        })
        if(chekvalue!="")
        {
            chekvalue=chekvalue.substring(0, chekvalue.length - 1);
            location.href=url+"?va="+chekvalue;
        }
        else
        {
            alert("请先选择会员！");
            return false;
        }
        
     }
</script>


</head>


<body>

	<div class="place">
    <span>位置：</span>
    <ul class="placeul">
   <li><a href="#">产品管理</a></li>
    <li><a href="#">签证产品</a></li>
    <li><a href="#">签证列表</a></li>
    </ul>
    </div>
    <form id="form1" runat="server">
    <div class="rightinfo">
    
    <div class="tools">
    
    	<ul class="toolbar">
        <li><span><img src="../images/t03.png" /></span><asp:LinkButton 
                ID="lbtnDel" runat="server" Text="批量删除" onclick="lbtnDel_Click"></asp:LinkButton></li>
         <%--<li><a href="#" onclick="gotoUrl('GroupSMS.aspx','mobile')"><span><img src="../images/t01.png" /></span>短信群发</a></li>
         <li><a href="#" onclick="gotoUrl('GroupEmail.aspx','email')"><span><img src="../images/email.png" style="width:24px; height:24px" /></span>邮件群发</a></li>--%>
            <%=ShowButton()%>
         <li><span><img src="../images/excel.png" style="width:24px; height:24px" /></span><asp:LinkButton 
                ID="lbtnExport" runat="server" Text="导出Excel" onclick="lbtnExport_Click"></asp:LinkButton></li>
        </ul>
             <div class="usercity">
            <div class="cityleft" style=" padding-top:7px;">会员信息:</div>
            <div class="cityleft">
                <asp:TextBox ID="txtKeywords" runat="server" CssClass="dfinput" Width="120px" Text="用户名/手机/邮箱"></asp:TextBox></div>
    <div class="cityleft">
   <asp:DropDownList ID="ddlClass" runat="server" CssClass="select1">
    </asp:DropDownList>
    </div>
    <div class="cityleft">
   <asp:DropDownList ID="ddlState" runat="server" CssClass="select1">
            <asp:ListItem Value="">选择会员状态</asp:ListItem>
            <asp:ListItem Value="0">正常</asp:ListItem>
            <asp:ListItem Value="1">锁定</asp:ListItem>
    </asp:DropDownList>
    </div>
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
        <th  style="width:12%">会员名</th>
        <th style="width:14%">手机</th>
        <th style="width:18%">邮箱</th>
        <th style="width:8%">会员级别</th>
        <th style="width:6%">积分</th>
        <th style="width:6%">状态</th>
        <th style="width:12%">注册时间</th>
        <th style="width:8%">订单</th>
        <th style="">操作</th>
        </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptClub" runat="server">
            <ItemTemplate>
                 <tr>
                    <td style="text-align:center"><asp:CheckBox ID="cb_id" CssClass="checkall" runat="server" /></td>
                    <td style="text-align:center"><asp:Label ID="lb_id" runat="server" Text='<%#Eval("Id")%>'></asp:Label></td>
                    <td style="text-align:center"><%# Eval("clubName")%></td>
                    <td style="text-align:center" rel="<%# Eval("clubMobile")%>"><%# ShowTelephone(Eval("clubMobile").ToString(), Eval("mobileIsValid").ToString())%></td>
                    <td style="text-align:center" rel="<%# Eval("clubEmail")%>"><%# ShowEmail(Eval("clubEmail").ToString(), Eval("emailIsValid").ToString())%></td>
                    <td style="text-align:center"><%# TravelAgent.Tool.EnumHelper.GetMemberName<TravelAgent.Tool.EnumSummary.ClubClass>(Eval("classid"))%></td>
                    <td style="text-align:center"><%# Eval("currentPoints")%></td>
                    <td style="text-align:center"><%# Eval("isLock").ToString().Equals("0") ? "正常" : "<span style='color:red'>锁定</span>"%></td>
                    <td style="text-align:center"><%# Eval("regDate")%></td>
                    <td style="text-align:center; padding-top:10px;">
                        <select name="select" onchange="changeopt(this.options[this.selectedIndex].value)" class="select2">
                                    <option>类型</option>
                                    <option value="/admin/product/LineOrderList.aspx?clubid=<%# Eval("Id") %>">线路</option>
                                    <option value="/admin/visa/VisaOrderList.aspx?clubid=<%# Eval("Id") %>">签证</option>
                                </select>
                    </td>
                    <td style="text-align:center">
                        <a href="EditClub.aspx?id=<%# Eval("Id") %>" class="tablelink club_art" title="修改会员信息" width="730px" height="350px">修改</a> <a id="<%# Eval("Id")%>" href="#" class="tablelink club_delete">删除</a> 
                    </td>
                </tr> 
            </ItemTemplate>
            </asp:Repeater>
            <tr id="trNoRecord" runat="server">
                 <td colspan="11" class="noinfo">暂时没有数据！</td>
           </tr>
           <tr id="trPagination" runat="server">
                  <td colspan="11">
                        
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
        $(function() {
            $("#txtKeywords").css("color", "#999");
            $("#txtKeywords").click(function() {
                var name = $("#txtKeywords").val();
                if (name === "用户名/手机/邮箱") {
                    $("#txtKeywords").val("");
                    $("#txtKeywords").css("color", "#000");
                }
            });
            $("#txtKeywords").blur(function() {
                var clubname = $.trim($(this).val());
                if (!clubname || clubname === "") {
                    $("#txtKeywords").val("用户名/手机/邮箱").css("color", "#999");
                }
            });
        })
	</script>

</body>

</html>
