<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CusomerOrderList.aspx.cs" Inherits="TravelAgent.Web.admin.product.CusomerOrderList" %>

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
                width: 150
            });
            $(".select2").uedSelect({
                width: 117
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
	            link_to:"?page=__id__"
           });
           $("#chkSelect").click(function(){
                if($(this).attr("checked"))
                {
                    $(":checkbox[name^='rptLine']").attr("checked",true);
                }
                else
                {
                    $(":checkbox[name^='rptLine']").attr("checked",false);
                }
            })
            $("#lbtnDel").click(function(){
                if ($(":checkbox[name^='rptLine']:checked").length == 0)
                 {
                    art.dialog.alert("请先选择定制需求！");
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
    <li><a href="#">定制列表</a></li>
    </ul>
    </div>
    <form id="form1" runat="server">
    <div class="rightinfo">
    <div class="tools">
    
    	<ul class="toolbar">
        <li><span><img src="../images/t03.png" /></span><asp:LinkButton 
                ID="lbtnDel" runat="server" Text="批量删除" onclick="lbtnDel_Click"></asp:LinkButton></li>
        </ul>
    </div>
    <div>
    <table class="tablelist">
    	<thead>
    	<tr>
    	<th style="width:3%; text-align:center"><input id="chkSelect" name="chkSelect" type="checkbox" value="" /></th>
        <th style="width:4%">编号</th>
        <th style="width:8%">业务类型</th>
        <th  style="">景点城市</th>
        <%--<th style="width:10%">供应商</th>--%>
        <th style="width:8%">行程天数</th>
        <th style="width:8%">出游人数</th>
        <th style="width:8%">单人预算</th>
        <th style="width:8%">游玩日期</th>
        <th style="width:6%">联系人</th>
        <th style="width:10%">联系电话</th>
        <th style="width:12%">提交时间</th>
        </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptLine" runat="server">
            <ItemTemplate>
                 <tr title="其他需求：<%# Eval("OtherMsg")%>">
                    <td style="text-align:center"><asp:CheckBox ID="cb_id" CssClass="checkall" runat="server" /></td>
                    <td style="text-align:center"><asp:Label ID="lb_id" runat="server" Text='<%#Eval("Id")%>'></asp:Label></td>
                    <td style="text-align:center"><%# TravelAgent.Tool.EnumHelper.GetMemberName<TravelAgent.Tool.EnumSummary.CustomBusinessType>(Eval("CustomType"))%></td>
                    <td style="text-align:left"><%# Eval("Jindians")%></td>
                    <td style="text-align:center"><%# Eval("LineDay")%></td>
                    <td style="text-align:center"><%# Eval("LinePeopleNumber")%></td>
                    <td style="text-align:center"><%# Eval("PeoplePrice")%></td>
                    <td style="text-align:center"><%# Eval("TravelDate")%></td>
                    <td style="text-align:center"><%# Eval("LinkName")%></td>
                    <td style="text-align:center"><%# Eval("LinkTelephone")%></td>
                    <td style="text-align:center"><%# Eval("AddDate")%></td>
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
    </div>
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
