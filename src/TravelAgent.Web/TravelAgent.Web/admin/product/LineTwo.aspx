<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LineTwo.aspx.cs" Inherits="TravelAgent.Web.admin.product.LineTwo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
<title>无标题文档</title>
<link href="../css/style.css" rel="stylesheet" type="text/css" />
<link href="/css/line.css" rel="Stylesheet" type="text/css" />
<link href="/css/fullcalendar.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/js/jquery-1.3.2.min.js" ></script>
<script type="text/javascript" src="/js/jquery.validate.min.js"></script>
<script type="text/javascript" src="/js/validate.js"></script>
<script type="text/javascript" src="/js/jquery.form.js"></script>
<script type="text/javascript" src="/js/fullcalendar.js" ></script>
<script type="text/javascript" src="/js/calendar.js"  ></script>
<script type="text/javascript">
    var EdiPrice = function() {
               $("#__VIEWSTATE").remove(); //这两句最重要
               $("#__EVENTVALIDATION").remove();
               $(this).attr("disabled", "disabled");
               $(this).val("正在保存中...");
                var options = {
                    url: "../data/Product_Line2.aspx?lineid=" + <%=lineid %> + "&date=" + new Date().toUTCString(),
                    type: 'POST',
                    //beforeSubmit: Validate,
                    success: function(responseText, statusText) {
                        $("#btnSave").attr("disabled", "");
                        $("#btnSave").removeAttr("disabled");
                        $("#btnSave").val("确定保存");
                        if (responseText.indexOf("true") >= 0) {
                            // 如果父页面重载或者关闭其子对话框全部会关闭
                           //parent.location.reload();
                            parent.jsprint("保存成功！","","Success");
                            $('#calendar_price').fullCalendar('refetchEvents');
                            return false;
                        }
                        else {
                            //parent.art.dialog.alert("保存失败！");
                            parent.jsprint("保存失败！","","Error");
                        }
                    }
                };
                $("#form1").ajaxSubmit(options);
    }
    $(function() {
        $("input[name='rbtnPlanType']").click(function() {
            if ($(this).val() == "0") {
                $("#trWeek").hide();
                $("#trDay").hide();
            }
            else if ($(this).val() == "1") {
                $("#trWeek").show();
                $("#trDay").hide();
            }
            else if ($(this).val() == "2") {
                $("#trWeek").hide();
                $("#trDay").show();
            }
        });
        //表单验证JS
        $("#form1").validate({
            //出错时添加的标签
            errorElement: "span",
            submitHandler: function() {
               EdiPrice();                 
               return false;   
            },   
            success: function(label) {
                //正确时的样式
                label.text(" ").addClass("success");
            }
        });
        $("#chkWeekList").click(function() {
                var valuelist = ""; //保存checkbox选中值        
                //遍历name以listTest开头的checkbox
                $("input[name^='chkWeekList']").each(function() {
                    if (this.checked) {         
                        valuelist += $(this).parent("span").attr("tag") + ",";
                    }
                });
                if (valuelist.length > 0) {
                    //得到选中的checkbox值序列,结果为400,398
                    valuelist = valuelist.substring(0, valuelist.length - 1);
                }
                $("#hidweek").val(valuelist);
        })
        $("#chkDayList").click(function() {
                var valuelist = ""; //保存checkbox选中值        
                //遍历name以listTest开头的checkbox
                $("input[name^='chkDayList']").each(function() {
                    if (this.checked) {         
                        valuelist += $(this).next().text() + ",";
                    }
                });
                if (valuelist.length > 0) {
                    //得到选中的checkbox值序列,结果为400,398
                    valuelist = valuelist.substring(0, valuelist.length - 1);
                }
                $("#hidday").val(valuelist);
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
    <li><a href="#">编辑线路</a></li>
    </ul>
    </div>
    
    <div class="formbody">
    <div class="itab">
  	<ul> 
    <li><a href="LineOne.aspx?id=<%= lineid %>&tag=<%=tag %>">第一步：线路描述</a></li> 
    <li><a href="#" class="selected">第二步：价格计划</a></li>
    <li><a href="LineThree.aspx?id=<%= lineid %>&tag=<%=tag %>">第三步：行程安排</a></li>
    <li><a href="LineFour.aspx?id=<%= lineid %>&tag=<%=tag %>">第四步：线路内容</a></li>
  	</ul>
    </div> 
     <div style=" display:block; margin-top:5px;">
    
        <div style="float:left; width:64%;">
        <div id="calendar_price"  align="center"></div>
                            <div style="padding:10px">
                            注：特殊日期价格双击日历上日期进行修改、删除。
                            </div>
                            <div class="rlyd1" id="hidden_div">
                                <strong class="sClose1"><a rel="nofollow" href="javascript:;"></a></strong>
                                <form id="form2" method="post" action="" onsubmit="return checkform(this);" >
                                        <input name="ordertime" type="hidden" value="" />
                                        <div class="rlyd_riqi"><span class="spanCurrentDate"></span>的报价(<span style="color:Red">*</span>为必填项)</div>
                                        <div class="rlyd_renshu">
                                                <table border="0" cellpadding="0" cellspacing="0" style="text-align:center; line-height:40px;">
                                            <tr>
                                                <td style="width:30%"></td>
                                                <td>成人</td>
                                                <td>儿童</td>
                                            </tr>
                                            <tr>
                                                <td>市场价<span style="color:Red">*</span></td>
                                                <td>
                                                    <input id="menshi_adult" name="menshi_adult" type="text" class="dfinput w50" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" /></td>
                                                <td>
                                                    <input id="menshi_child" name="menshi_child" type="text" class="dfinput w50" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" /></td>
                                            </tr>
                                            <tr>
                                                <td>同行价<span style="color:Red">*</span></td>
                                                <td>
                                                    <input id="price_adult" name="price_adult" type="text" class="dfinput w50"  onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" /></td>
                                                <td>
                                                    <input id="price_child" name="price_child" type="text" class="dfinput w50"  onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" /></td>
                                            </tr>
                                            <tr>
                                                <td>使用积分</td>
                                                <td>
                                                    <input id="points_use_adult" name="points_use_adult" type="text" class="dfinput w50" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" value="0" /></td>
                                                <td>
                                                    <input id="points_use_child" name="points_use_child" type="text" class="dfinput w50" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" value="0" /></td>
                                            </tr>
                                            <tr>
                                                <td>赠送积分</td>
                                                <td>
                                                    <input id="points_do_adult" name="points_do_adult" type="text" class="dfinput w50" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" value="0" /></td>
                                                <td>
                                                    <input id="points_do_child" name="points_do_child" type="text" class="dfinput w50" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" value="0"  /></td>
                                            </tr>
                                            <tr>
                                                <td>结算价<span style="color:Red">*</span></td>
                                                <td>
                                                    <input id="jsprice_adult" name="jsprice_adult" type="text" class="dfinput w50" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" /></td>
                                                <td>
                                                    <input id="jsprice_child" name="jsprice_child" type="text" class="dfinput w50" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" /></td>
                                            </tr>
                                            <tr>
                                                <td>单房差</td>
                                                <td colspan="2">
                                                    <input id="dfc" name="dfc" type="text" class="dfinput w50" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" value="0"  /></td>
                                            </tr>
                                            <tr>
                                                <td>数量<span style="color:Red">*</span></td>
                                                <td colspan="2">
                                                    <input id="num" name="num" type="text" class="dfinput w50" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" /></td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" style="text-align:center;">
                                                    <%--<input type="submit" value="保存" class="btn"  />--%>
                                                    <input id="btnPriceSave" type="button" value="保存" class="sure"  /><input id="btnPriceDelete" type="button" value="删除" class="cancel"/>
                                                </td>
                                            </tr>
                                        </table>
                                        </div>
                                <input id="hidPrice" name="hidPrice" type="hidden" />
                                <input id="hidDate" name="hidDate" type="hidden" />
                                </form>                
                        </div>
    </div>
        <form id="form1" runat="server">
        <div style=" width:34%; float:right;">
        <table border="0" cellpadding="0" cellspacing="0" style="width:100%;" class="formtable">
                                <tr>
                                    <td><span style="font-weight:bold">批量设置日期价格</span>(<span style="color:Red">*</span>为必填项)</td>
                                </tr>
                                <tr>
                                    <td>第一步：指定价格的有效日期段(<span style="color:Red">*</span>)</td>
                                </tr>
                                <tr>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="border:0">
                                                    <input id="txtStartDate" runat="server" name="txtStartDate" type="text" class="dfinput w80 required" onclick="return Calendar('txtStartDate');" /></td>
                                                <td style="border:0">至</td>
                                                <td style="border:0; padding-right:5px;"><input id="txtEndDate" runat="server" name="txtEndDate" type="text" class="dfinput w80 required" onclick="return Calendar('txtEndDate');" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>第二步：选择设置</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:RadioButtonList ID="rbtnPlanType" runat="server" 
            RepeatDirection="Horizontal" RepeatLayout="Flow">
            <asp:ListItem Value="0" Selected="True">天天发团</asp:ListItem>
            <asp:ListItem Value="1">按周</asp:ListItem>
            <asp:ListItem Value="2">按号</asp:ListItem>
        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr id="trWeek" runat="server" style="display:none">
                                    <td>
                                        <asp:CheckBoxList ID="chkWeekList" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            <asp:ListItem Value="1" tag="1">周一</asp:ListItem>
                                            <asp:ListItem Value="2" tag="2">周二</asp:ListItem>
                                            <asp:ListItem Value="3" tag="3">周三</asp:ListItem>
                                            <asp:ListItem Value="4" tag="4">周四</asp:ListItem>
                                            <asp:ListItem Value="5" tag="5">周五</asp:ListItem>
                                            <asp:ListItem Value="6" tag="6">周六</asp:ListItem>
                                            <asp:ListItem Value="0" tag="0">周日</asp:ListItem>
                                        </asp:CheckBoxList>
                                    </td>
                                </tr>
                                <tr id="trDay" runat="server" style="display:none">
                                    <td>
                                         <asp:CheckBoxList ID="chkDayList" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" RepeatColumns="5">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="6">6</asp:ListItem>
                                            <asp:ListItem Value="7">7</asp:ListItem>
                                             <asp:ListItem Value="8">8</asp:ListItem>
                                             <asp:ListItem Value="9">9</asp:ListItem>
                                             <asp:ListItem Value="10">10</asp:ListItem>
                                             <asp:ListItem Value="11">11</asp:ListItem>
                                             <asp:ListItem Value="12">12</asp:ListItem>
                                             <asp:ListItem Value="13">13</asp:ListItem>
                                             <asp:ListItem Value="14">14</asp:ListItem>
                                              <asp:ListItem Value="15">15</asp:ListItem>
                                             <asp:ListItem Value="16">16</asp:ListItem>
                                             <asp:ListItem Value="17">17</asp:ListItem>
                                             <asp:ListItem Value="18">18</asp:ListItem>
                                             <asp:ListItem Value="19">19</asp:ListItem>
                                             <asp:ListItem Value="20">20</asp:ListItem>
                                             <asp:ListItem Value="21">21</asp:ListItem>
                                              <asp:ListItem Value="22">22</asp:ListItem>
                                             <asp:ListItem Value="23">23</asp:ListItem>
                                             <asp:ListItem Value="24">24</asp:ListItem>
                                             <asp:ListItem Value="25">25</asp:ListItem>
                                             <asp:ListItem Value="26">26</asp:ListItem>
                                             <asp:ListItem Value="27">27</asp:ListItem>
                                             <asp:ListItem Value="28">28</asp:ListItem>
                                             <asp:ListItem Value="29">29</asp:ListItem>
                                             <asp:ListItem Value="30">30</asp:ListItem>
                                             <asp:ListItem Value="31">31</asp:ListItem>
                                        </asp:CheckBoxList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0" style=" width:100%; text-align:center" class="formtable">
                                            <tr>
                                                <td style="width:30%"></td>
                                                <td>成人</td>
                                                <td>儿童</td>
                                            </tr>
                                            <tr>
                                                <td>市场价<span style="color:Red">*</span></td>
                                                <td>
                                                    <input id="txtMenshi_adult" name="txtMenshi_adult" type="text" runat="server" class="dfinput w50 required" min="1" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" /></td>
                                                <td>
                                                    <input id="txtMenshi_child" name="txtMenshi_child" type="text" runat="server" class="dfinput w50 required" min="1" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" /></td>
                                            </tr>
                                            <tr>
                                                <td>同行价<span style="color:Red">*</span></td>
                                                <td>
                                                    <input id="txtPrice_adult" name="txtPrice_adult" type="text" runat="server" class="dfinput w50 required" min="1" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" /></td>
                                                <td>
                                                    <input id="txtPrice_child" name="txtPrice_child" type="text" runat="server" class="dfinput w50 required" min="1" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" /></td>
                                            </tr>
                                            <tr>
                                                <td>使用积分</td>
                                                <td>
                                                    <input id="txtUsePoints_adult" name="txtUsePoints_adult" type="text" runat="server" class="dfinput w50" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" value="0" /></td>
                                                <td>
                                                    <input id="txtUsePoints_child" name="txtUsePoints_child" type="text" runat="server" class="dfinput w50" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" value="0" /></td>
                                            </tr>
                                            <tr>
                                                <td>赠送积分</td>
                                                <td>
                                                    <input id="txtDoPoints_adult" name="txtDoPoints_adult" type="text" runat="server" class="dfinput w50" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" value="0" /></td>
                                                <td>
                                                    <input id="txtDoPoints_child" name="txtDoPoints_child" type="text" runat="server" class="dfinput w50" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" value="0" /></td>
                                            </tr>
                                            <tr>
                                                <td>结算价<span style="color:Red">*</span></td>
                                                <td>
                                                    <input id="txtCheng_adult" name="txtCheng_adult" type="text" runat="server" class="dfinput w50 required" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" /></td>
                                                <td>
                                                    <input id="txtCheng_child" name="txtCheng_child" type="text" runat="server" class="dfinput w50 required" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" /></td>
                                            </tr>
                                            <tr>
                                                <td>单房差</td>
                                                <td colspan="2">
                                                    <input id="txtDFC" name="txtDFC" type="text" runat="server" class="dfinput w50" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" value="0" /></td>
                                            </tr>
                                            <tr>
                                                <td>剩余数量<span style="color:Red">*</span></td>
                                                <td colspan="2">
                                                    <input id="txtNumber" name="txtNumber" type="text" runat="server" class="dfinput w50 required" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="chkClearPrice" runat="server" Text="清除特殊日期价格" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:RadioButtonList ID="rbtnDealType" runat="server" 
            RepeatDirection="Horizontal" RepeatLayout="Flow">
            <asp:ListItem Value="0" Selected="True">人工处理</asp:ListItem>
            <asp:ListItem Value="1">自动处理</asp:ListItem>
        </asp:RadioButtonList>&nbsp;&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnSave" runat="server" Text="确定保存" CssClass="btn" /></td>
                                </tr>
                            </table>
    </div><div style="clear:both"></div>
        <script type="text/javascript">
            $(function() {
                $("#hidden_div .sClose1").click(function() {
                     $("#hidden_div").hide();
                });
                if ($('#calendar_price').size() > 0) {
                    $('#calendar_price').fullCalendar({
                        height:550,
                        aspectRatio: 0.6,
                        events: "../data/Product_Line_Calendar.aspx?id="+<%=lineid %>,
                        loading: function(isLoading, view) {
                            if (isLoading) {
                                $("#loading").show();
                            } else {
                                $("#loading").hide();
                            }
                        },
                        header: {
                            left: 'prev',
                            center: 'title',
                            right: 'next'
                        },                        
                        eventClick: function(calEvent, jsEvent, view) { //日期控件day的单击事件
                            $("#hidden_div").css({ top: jsEvent.pageY + 10, left: jsEvent.pageX - 160 }).show();
                            $("#hidden_div").find(".spanCurrentDate").html($.fullCalendar.formatDate(calEvent.start,"yyyy-MM-dd"));
                            $("#btnPriceDelete").removeAttr("disabled");
                            var price=calEvent.price.split(',');
                            console.log(price);
                            $("#menshi_adult").val(price[0]);
                            $("#menshi_child").val(price[1]);
                            $("#price_adult").val(price[2]);
                            $("#price_child").val(price[3]);
                            $("#points_use_adult").val(price[4]);
                            $("#points_use_child").val(price[5]);
                            $("#points_do_adult").val(price[6]);
                            $("#points_do_child").val(price[7]);
                            $("#jsprice_adult").val(price[8]);
                            $("#jsprice_child").val(price[9]);
                            $("#dfc").val(price[10]);
                            $("#num").val(price[11]);
                            $("#hidPrice").val(calEvent.price);
                            $("#hidDate").val($.fullCalendar.formatDate(calEvent.start,"yyyy-MM-dd"));
                            return false;
                        },
                        dayClick: function(date, allDay, jsEvent, view) {
                            if(date>new Date())
                            {
                               $("#hidden_div").css({ top: jsEvent.pageY + 10, left: jsEvent.pageX - 160 }).show();
                               $("#hidden_div").find(".spanCurrentDate").html($.fullCalendar.formatDate(date,"yyyy-MM-dd"));
                               $("#btnPriceDelete").attr("disabled","disabled");
                               $("#menshi_adult").val("");
                               $("#menshi_child").val("");
                               $("#price_adult").val("");
                               $("#price_child").val("");
                               $("#points_use_adult").val("0");
                               $("#points_use_child").val("0");
                               $("#points_do_adult").val("0");
                               $("#points_do_child").val("0");
                               $("#jsprice_adult").val("");
                               $("#jsprice_child").val("");
                               $("#dfc").val("0");
                               $("#num").val("");
                               $("#hidPrice").val("");
                               $("#hidDate").val($.fullCalendar.formatDate(date,"yyyy-MM-dd"));
                               return false;
                            }
                        }
                    });
                }
                $("#btnPriceSave").click(function(){
                    if($("#price_adult").val()=="")
                    {
                        alert("请输入成人销售价！");
                        return false;
                    }
                    else
                    {
                        if(parseInt($("#price_adult").val())==0)
                        {
                            alert("请输入大于0的价格！");
                            return false;
                        }
                    }
                    if($("#price_child").val()=="")
                    {
                        alert("请输入成人销售价！");
                        return false;
                    }
                    else
                    {
                        if(parseInt($("#price_child").val())==0)
                        {
                            alert("请输入大于0的价格！");
                            return false;
                        }
                    }
                   $("#__VIEWSTATE").remove(); //这两句最重要
                   $("#__EVENTVALIDATION").remove();
                   $(this).attr("disabled", "disabled");
                   $(this).val("正在保存中...");
                    var options = {
                        url: "../data/Product_Line2.aspx?line_id=" + <%=lineid %> + "&date=" + new Date().toUTCString(),
                        type: 'POST',
                        //beforeSubmit: Validate,
                        success: function(responseText, statusText) {
                            $("#btnPriceSave").attr("disabled", "");
                            $("#btnPriceSave").removeAttr("disabled");
                            $("#btnPriceSave").val("保存");
                            if (responseText.indexOf("true") >= 0) {
                                // 如果父页面重载或者关闭其子对话框全部会关闭
                               //parent.location.reload();
                                //parent.jsprint("保存成功！","","Success");
                                $("#hidden_div").hide();
                                $('#calendar_price').fullCalendar('refetchEvents');
                                return false;
                            }
                            else {
                                //parent.art.dialog.alert("保存失败！");
                                parent.jsprint("保存失败！","","Error");
                            }
                        }
                    };
                    $("#form2").ajaxSubmit(options);
                })
                $("#btnPriceDelete").click(function(){
                    $.ajax({
                        type: "POST",
                        url: "../data/Product_Line2.aspx",
                        cache: false,
                        dataType: "text",
                        data: { line_id_delete: <%=lineid %>, line_date:$("#hidDate").val()},
                        success: function(msg) {
                            //提示删除成功消息
                            if (msg.indexOf("true") >= 0) {
                                $("#hidden_div").hide();
                                $('#calendar_price').fullCalendar('refetchEvents');
                                return false;
                            }
                            else {
                                parent.jsprint("删除失败！","","Error");
                                return false;
                            }
                        }
                    })
                })
            })
        </script>
        <input id="hidweek" name="hidweek"  type="hidden" runat="server" value="" />
        <input id="hidday" name="hidday" type="hidden" runat="server" value="" />
        <input id="hidlineid" name="hidlineid" type="hidden" runat="server" />
     </form>
       </div>
    </div>

</body>

</html>
