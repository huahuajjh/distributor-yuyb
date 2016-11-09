<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LineOrderList.aspx.cs" Inherits="TravelAgent.Web.admin.product.LineOrderList" %>

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
<script type="text/javascript" src="/My97DatePicker/WdatePicker.js"></script>

<script type="text/javascript">
    $(function() {
            $(".select1").uedSelect({
                width: 120
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
	            link_to:"?<%=CombUrlTxt(this.strordercode, this.strordername, this.strorderstartdate, this.strorderenddate, this.strstartdate, this.strenddate, this.orderstate, this.clubid) %>page=__id__"
           });

           $("#chkSelect").click(function(){
                if($(this).attr("checked"))
                {
                    $(":checkbox[name^='rptList']").attr("checked",true);
                }
                else
                {
                    $(":checkbox[name^='rptList']").attr("checked",false);
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
                art.dialog.confirm("确认删除该订单吗？", function() {
                    $.ajax({
                        type: "POST",
                        url: "../data/Order.aspx",
                        cache: false,
                        dataType: "text",
                        data: {lineorderid: id },
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
                 if($(":checkbox[name^='rptList']:checked").length==0)
                 {
                    art.dialog.alert("请先选择订单！");
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
   <li><a href="#">订单管理</a></li>
    <li><a href="#">线路订单</a></li>
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
            <div class="cityleft" style=" padding-top:7px;">订单号:</div>
            <div class="cityleft">
                <asp:TextBox ID="txtOrderCode" runat="server" CssClass="dfinput" Width="120px" Text=""></asp:TextBox></div>
                <div class="cityleft" style=" padding-top:7px;">线路名称:</div>
            <div class="cityleft">
                <asp:TextBox ID="txtOrderName" runat="server" CssClass="dfinput" Width="120px" Text=""></asp:TextBox></div>
                <div class="cityleft" style=" padding-top:7px;">下单时间:</div>
            <div class="cityleft">
                <asp:TextBox ID="txtOrderStartDate" runat="server" CssClass="dfinput" Width="90px" Text="" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>至<asp:TextBox
                    ID="txtOrderEndDate" runat="server" CssClass="dfinput" Width="90px" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox></div>
    <div class="cityleft">
   <asp:DropDownList ID="ddlState" runat="server" CssClass="select1">
            <asp:ListItem Value="">订单状态</asp:ListItem>
            <asp:ListItem Value="0">正常</asp:ListItem>
            <asp:ListItem Value="1">锁定</asp:ListItem>
    </asp:DropDownList>
    </div>
    <div class="cityleft"><asp:Button ID="btnQuery" runat="server" Text="查询" 
            CssClass="scbtn" onclick="btnQuery_Click" />
    </div>
    </div>
    
    </div>
    <div class="tools" style=" background-color:#f9f0a8; padding-top:15px; padding-left:20px;">
        快捷查询：<asp:HyperLink ID="hljrorder" runat="server">今日下单</asp:HyperLink>  
            <asp:HyperLink ID="hlbzorder" runat="server">本周下单</asp:HyperLink>  
            <asp:HyperLink ID="hlbyorder" runat="server">本月下单</asp:HyperLink> |<asp:HyperLink ID="hljrstart" runat="server" CssClass="ml20">今日发团</asp:HyperLink>
            <asp:HyperLink ID="hlbzstart" runat="server">本周发团</asp:HyperLink>
            <asp:HyperLink ID="hlbystart" runat="server">本月发团</asp:HyperLink>
            <ul class="toolbar" style="float:right; ">
            <li><span><img src="../images/excel.png" style="width:24px; height:24px" /></span><asp:LinkButton 
                ID="lbtnExport" runat="server" Text="导出Excel" onclick="lbtnExport_Click"></asp:LinkButton></li>
            </ul>
    </div>
    
    <table class="tablelist">
    	<thead>
    	<tr>
    	<th style="width:3%; text-align:center"><input id="chkSelect" name="chkSelect" type="checkbox" value="" /></th>
        <th style="width:4%">编号</th>
        <th  style="width:14%">订单号</th>
        <th style="width:14%">下单时间</th>
        <th style="width:8%">出发日期</th>
        <th style="width:8%">人数[成/儿]</th>
        <th style="width:22%">线路名称</th>
        <th style="width:5%">应支付</th>
        <th style="width:6%">状态</th>
        <%--<th style="width:11%">会员信息</th>--%>
        <th style="width:9%">联系人信息</th>
        <th style="">操作</th>
        </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptList" runat="server">
            <ItemTemplate>
                 <tr>
                    <td style="text-align:center"><asp:CheckBox ID="cb_id" CssClass="checkall" runat="server" /></td>
                    <td style="text-align:center"><asp:Label ID="lb_id" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "[0]")%>'></asp:Label></td>
                    <td><%# Eval("ordercode")%></td>
                    <td><%# Eval("orderDate")%> <%# Eval("sourceType").ToString().Equals(Convert.ToInt32(TravelAgent.Tool.EnumSummary.SourceType.PC网页).ToString()) ? "" : "<img src='../images/mobile.png' />"%></td>
                    <td><%# Eval("TravelDate")%></td>
                    <td style="text-align:center"><%# Eval("peopleNumber")%>[<%# Eval("adultNumber")%>/<%# Eval("childNumber")%>]</td>
                    <td><a href="/Line.aspx?id=<%# Eval("lineId")%>" target="_blank" class="tablelink"><%# Eval("lineName")%></a></td>
                    <td style="text-align:center"><%# ShowTotal(Convert.ToInt32(Eval("orderPrice")), Convert.ToInt32(Eval("attachPrice")), Convert.ToInt32(Eval("subPrice")))%></td>
                    <td style="text-align:center"><%# TravelAgent.Tool.EnumHelper.GetMemberName<TravelAgent.Tool.EnumSummary.OrderState>(Eval("orderState"))%></td>
                    <%--<td>club13888888888</td>--%>
                    <td><%# Eval("contactName")%><br /><%# Eval("contactMobile")%><br /><%# Eval("contactEmail")%><br /><%# Eval("contactTelephone").Equals("-") ? "" : Eval("contactTelephone")%></td>
                    <td style="text-align:center"><%# ShowEdit(DataBinder.Eval(Container.DataItem, "[0]").ToString())%></td>
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
