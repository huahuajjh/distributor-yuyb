<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarTwo.aspx.cs" Inherits="TravelAgent.Web.admin.car.CarTwo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>无标题文档</title>
<link href="../css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/js/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="/js/jquery.validate.min.js"></script>
<script type="text/javascript" src="/js/validate.js"></script>
<script type="text/javascript" src="/js/jquery.form.js"></script>
<script type="text/javascript" src="../js/select-ui.min.js"></script>
<script type="text/javascript" src="/js/fullcalendar.js" ></script>
<script type="text/javascript" src="/js/calendar.js"  ></script>
<script type="text/javascript">
    $(function() {
        $(".select1").uedSelect({
            width: 150
        });
        $(".select2").uedSelect({
            width: 200
        });
        //表单验证JS
        $("#form1").validate({
            //出错时添加的标签
            errorElement: "span",
            success: function(label) {
                //正确时的样式
                label.text(" ").addClass("success");
            }
        });
        $(".price_delete").unbind();
        $(".price_delete").click(function() {
            var id = $(this).attr("id");
            if (confirm("确认删除该价格体系吗？")) {
                $.ajax({
                    type: "POST",
                    url: "../data/CarPriceData.aspx",
                    cache: false,
                    dataType: "text",
                    data: { tag: "price_delete", priceid: id },
                    success: function(msg) {
                        //提示删除成功消息
                        if (msg.indexOf("true") >= 0) {
                            alert("a");
                            location.href = "CarTwo.aspx?carid="+<%=carid %>;
                            return false;
                        }
                        else {
                            art.dialog.alert("删除失败！");
                            return false;
                        }
                    }
                })
            }
            else {
                return false;
            }

        })
    });
  
</script>
</head>

<body>
	<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">产品管理</a></li>
    <li><a href="#">租车产品</a></li>
    <li><a href="#">编辑租车</a></li>
    </ul>
    </div>
    
    <div class="formbody">
    <div class="itab">
  	<ul> 
    <li><a href="CarOne.aspx?carid=<%= carid %>&tag=edit" class="liNav" >第一步：租车信息</a></li> 
    <li><a href="#" class="selected">第二步：价格计划</a></li>
  	</ul>
    </div> 
    <div class="rightinfo">
    
    <div class="tools">
    
    	<ul class="toolbar">
        <li class="click"><a href="CarTwo.aspx?carid=<%=carid %>" class="city_art" title="添加价格体系" width="600px" height="250px"><span><img src="../images/t01.png" /></span>添加价格体系</a></li>
        </ul>
    </div>
        <form id="form1" runat="server">
        <table class="tablelist">
    	        <thead>
    	        <tr>
                <th style="width:4%">编号</th>
                <th>价格体系</th>
                <th style="width:10%">门市价</th>
                <th style="width:10%">销售价</th>
                <th style="width:10%">结算价</th>
                <%--<th style="width:10%">指定日期价格</th>--%>
                <th style="width:10%">显示</th>
                <th style="width:10%">操作</th>
                </tr>
                </thead>
                <tbody id="AllNav">
        <asp:Repeater ID="rptPrice" runat="server">
        <ItemTemplate>
                <tr>
                    <td style="text-align:center"><%#Eval("Id")%></td>
                    <td style="text-align:left"><%#Eval("PriceName")%></td>
                    <td style="text-align:center"><%#Eval("MemshiPrice")%></td>
                    <td style="text-align:center"><%#Eval("XiaoshuPrice")%></td>
                    <td style="text-align:center"><%#Eval("JiesuanPrice")%></td>
                    <%--<td style="text-align:center"></td>--%>
                    <td style="text-align:center"><%#Eval("IsLock").ToString().Equals("1")?"隐藏":"显示"%></td>
                    <td style="text-align:center"><a href="CarTwo.aspx?carid=<%=carid %>&priceid=<%#Eval("Id") %>" class="tablelink">修改</a> | <a id="<%#Eval("Id") %>" href="#" class="tablelink price_delete">删除</a></td>
                </tr> 
        </ItemTemplate>
        </asp:Repeater>
         <tr id="trNoRecord" runat="server">
                        <td colspan="7" class="noinfo">暂时没有数据！</td>
                    </tr>
                        </tbody>
            </table>
            <table border="0" cellpadding="0" cellspacing="0" style="width:100%; margin-top:10px;" class="formtable">
            <tr>
                <td colspan="4">
                    <div style=" font-size:20px; font-weight:bold; margin:10px">添加<asp:Label ID="lblPriceName" runat="server" Text="" ForeColor="Red" Font-Size="20px"></asp:Label>价格体系</div>
                </td>
            </tr>
            <tr>
                <td style="width:15%;background: #F5F5F5; text-align:right ">价格体系<span class="red">*</span>：</td>
                <td colspan="3" style="">
                    <asp:TextBox ID="txtPriceName" runat="server" CssClass="dfinput required" 
            maxlength="30" minlength="3" Width="300px" HintTitle="价格体系" HintInfo="如北京到丰台"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width:15%;background: #F5F5F5; text-align:right ">单位<span class="red">*</span>：</td>
                <td colspan="3" style="">
                     <asp:TextBox ID="txtUnit" runat="server" CssClass="dfinput required" Width="100px"></asp:TextBox>&nbsp;如：一趟、一天
                </td>
            </tr>
            <tr>
                <td style="width:15%;background: #F5F5F5; text-align:right ">租车类型<span class="red">*</span>：</td>
                <td colspan="3" style="">
                     <asp:RadioButtonList ID="rbtnCarType" runat="server" 
            RepeatDirection="Horizontal" RepeatLayout="Flow">
            <asp:ListItem Value="1" Selected="True">旅游租车</asp:ListItem>
            <asp:ListItem Value="2">自驾租车</asp:ListItem>
        </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="width:15%;background: #F5F5F5; text-align:right ">租车城市<span class="red">*</span>：</td>
                <td colspan="3" style="">
                    <asp:DropDownList ID="ddlCarCity" runat="server" CssClass="select1 required">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width:15%;background: #F5F5F5; text-align:right ">厢数<span class="red">*</span>：</td>
                <td colspan="3" style="">
                      <asp:DropDownList ID="ddlCarNumber" runat="server" CssClass="select1 required">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width:15%;background: #F5F5F5; text-align:right ">变速器<span class="red">*</span>：</td>
                <td colspan="3" style="">
                     
                    <asp:DropDownList ID="ddlBSQ" runat="server" CssClass="select1 required">
                        <asp:ListItem Value="0">手动档</asp:ListItem>
                        <asp:ListItem Value="1">自动档</asp:ListItem>
                        <asp:ListItem Value="2">混合档</asp:ListItem>
                    </asp:DropDownList>
                     
                </td>
            </tr>
             <tr>
                <td style="width:15%;background: #F5F5F5; text-align:right ">日期限制<span class="red">*</span>：</td>
                <td colspan="3" style="">
                    <table style="border:0">
                        <tr>
                            <td><asp:TextBox ID="txtStartDate" runat="server" CssClass="dfinput required" Width="100px" onclick="return Calendar('txtStartDate');"></asp:TextBox>
                </td>
                            <td>至</td>
                            <td><asp:TextBox ID="txtEndDate" runat="server" CssClass="dfinput required" Width="100px" onclick="return Calendar('txtEndDate');"></asp:TextBox>
                </td>
                        </tr>
                    </table>
                </td>
            </tr>
             <tr>
                <td style="width:15%;background: #F5F5F5; text-align:right ">门市价<span class="red">*</span>：</td>
                <td colspan="3" style="">
                     <table>
                        <tr>
                            <td>
                     <asp:TextBox ID="txtMenshi" runat="server" CssClass="dfinput required" Width="100px" 
                                    onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);"></asp:TextBox>
                            </td>
                             <td>销售价<span class="red">*</span>：</td>
                              <td>
                     <asp:TextBox ID="txtXiaoshou" runat="server" CssClass="dfinput required" Width="100px" 
                                      onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);"></asp:TextBox>
                            </td>
                               <td>结算价<span class="red">*</span>：</td>
                                <td>
                     <asp:TextBox ID="txtJiesuan" runat="server" CssClass="dfinput required" Width="100px" 
                                        onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);"></asp:TextBox>
                            </td>
                        </tr>
                     </table>
                </td>
            </tr>
             <tr>
                <td style="width:15%;background: #F5F5F5; text-align:right ">使用积分<span class="red">*</span>：</td>
                <td colspan="3" style="">
                     <table>
                        <tr>
                            <td>
                     <asp:TextBox ID="txtUsePoint" runat="server" CssClass="dfinput required" Width="100px" 
                                    onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);"></asp:TextBox>
                            </td>
                            <td>赠送积分<span class="red">*</span>：</td>
                            <td>
                     <asp:TextBox ID="txtDonatePoint" runat="server" CssClass="dfinput required" Width="100px" 
                                    onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);"></asp:TextBox>
                            </td>
                        </tr>
                     </table>
                </td>
            </tr>
           
          <tr>
                <td style="width:15%;background: #F5F5F5; text-align:right ">处理方式<span class="red">*</span>：</td>
                <td colspan="3" style="">
                     
                    <asp:RadioButtonList ID="rbtnDealType0" runat="server" 
                        RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Selected="True" Value="0">人工处理</asp:ListItem>
                        <asp:ListItem Value="1">自动处理</asp:ListItem>
                    </asp:RadioButtonList>
                     
                </td>
            </tr>
            <tr>
                <td style="width:15%;background: #F5F5F5; text-align:right ">是否隐藏：</td>
                <td style="">
                    <asp:CheckBox ID="chkIsLock" runat="server" />
                </td>
                <td style="background: #F5F5F5; text-align:right">排序<span class="red">*</span>：</td>
                <td style=" padding:15px"><asp:TextBox ID="txtSort" runat="server" CssClass="dfinput required" 
            maxlength="50" Width="100px"  onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" Text="0"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width:15%;background: #F5F5F5; text-align:right "></td>
                <td colspan="3">
                    <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn" 
                        onclick="btnSave_Click" />
                </td>
            </tr>
            
        </table>
      </form>
    </div>
    </div>


</body>

</html>
