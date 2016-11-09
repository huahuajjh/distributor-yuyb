<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LineOne.aspx.cs" Inherits="TravelAgent.Web.admin.product.LineOne" ValidateRequest="false" %>

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
<script type="text/javascript" src="../js/singleupload.js"></script>
<script type="text/javascript" src="../js/select-ui.min.js"></script>
<script type="text/javascript" charset="utf-8" src="/ueditor/ueditor.all.js"></script>
    <script type="text/javascript" charset="utf-8" src="/ueditor/ueditor.config.js"></script>
    <%--<script src="/ueditor/lang/zh-cn/zh-cn.js" type="text/javascript"></script>--%>
    <script type="text/javascript" src="/ueditor/editorconfig.js"></script>
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
        //显示关闭高级选项
        $("#upordown").toggle(function() {
            $(this).text("关闭高级选项");
            $(this).removeClass();
            $(this).addClass("expand");
            $(".upordown").show();
        }, function() {
            $(this).text("显示高级选项");
            $(this).removeClass();
            $(this).addClass("shrink");
            $(".upordown").hide();
        });
        $("input[name='dest']").click(function() {
            var valuelist = ""; //保存checkbox选中值
            $("input[name='dest']").each(function() {
                if (this.checked) {
                    valuelist += $(this).val() + ",";
                }
            })
            if (valuelist.length > 0) {
                //得到选中的checkbox值序列,结果为400,398
                //valuelist = valuelist.substring(0, valuelist.length - 1);
                valuelist = ","+valuelist;
            }
            $("#hidDest").val(valuelist);
        })
        var tag = $.getUrlParam('tag');
        if (tag == "add") {
            $(".liNav").attr("href", "javascript:void(0)");
        }
        else if (tag == "edit") {
            $(".liNav").removeAttr("style");
        }
        CreateEditor('txtFeature', 'simple');
    });
    var getSubDestList = function() {
        $(".lineDest").each(function() {
            $(this).css("display", "none");
        });
        var val = $("#ddlDestType").val();
        $("#DestContainer_" + val).css("display", "");
    }
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
    <li><a href="#" class="selected">第一步：线路描述</a></li> 
    <li><a href="LineTwo.aspx?id=<%= lineid %>&tag=<%=tag %>" style="color:#bdbdbd;" class="liNav">第二步：价格计划</a></li>
    <li><a href="LineThree.aspx?id=<%= lineid %>&tag=<%=tag %>" style="color:#bdbdbd;" class="liNav">第三步：行程安排</a></li>
    <li><a href="LineFour.aspx?id=<%= lineid %>&tag=<%=tag %>" style="color:#bdbdbd;" class="liNav">第四步：线路内容</a></li>
  	</ul>
    </div> 
    <%--<div class="formtitle"><span>网站基本信息</span></div>--%>
    <div style="padding-top:5px;">
    <form id="form1" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" style="width:100%;" class="formtable">
            <tr>
                <td style="width:15%;background: #F5F5F5; text-align:right ">供应商<span class="red">*</span>：</td>
                <td style="">
                    <asp:DropDownList ID="ddlSupply" runat="server" CssClass="select1 required">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width:15%;background: #F5F5F5; text-align:right ">线路标题<span class="red">*</span>：</td>
                <td colspan="5" style="">
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="dfinput required" 
            maxlength="30" minlength="3" Width="300px" HintTitle="线路标题" HintInfo="控制在30个字数内，标题文本尽量不要太长。可参考方式：城市+景点之一+交通方式+时间"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width:15%;background: #F5F5F5; text-align:right ">副标题<span class="red">*</span>：</td>
                <td colspan="2" style="">
                    <asp:TextBox ID="txtSubTitle" runat="server" CssClass="dfinput required" 
            maxlength="50" minlength="3" Width="500px" HintTitle="副标题" HintInfo="控制在50个字数内。"></asp:TextBox>
                </td>
                <td colspan="3" style="padding-right:5px"><span id="upordown" class="shrink">显示SEO选项</span></td>
            </tr>
            <tr>
                <td style="width:15%;background: #F5F5F5; text-align:right ">缩略图<span class="red">*</span>：</td>
                <td colspan="5" style="">
                    <asp:TextBox ID="txtImgUrl" runat="server" CssClass="dfinput left" Width="200px"></asp:TextBox>
                    <a href="javascript:void(0);" class="files"><input type="file" id="FileUpload" name="FileUpload" />浏览上传图片</a>
                    <span class="uploading">正在上传，请稍候...</span>推荐像素380 * 320
                </td>
            </tr>
            <tr class="upordown noshow">
            <td style="text-align:right; background: #F5F5F5; ">Meta Title(标题):</td>
            <td colspan="5" style="">
            <textarea runat="server" name="SEOTitle" rows="3" cols="100"   id="SEOTitle"  style=" width:65%; border:solid 1px #787a7b" HintTitle="Meta关键字" HintInfo="用于搜索引擎，如有多个关健字请用英文的,号分隔，不填写将自动提取标题。"></textarea>
            </td>
        </tr>
        <tr class="upordown noshow">
            <td style="text-align:right; background: #F5F5F5; ">Keywords(关键字)：</td>
            <td colspan="5" style="">
            <textarea name="SEOKeywords" runat="server" rows="3" cols="100" style=" width:65%; border:solid 1px #787a7b" id="SEOKeywords" HintTitle="Meta描述"  HintInfo="用于搜索引擎，控制在250个字数内，不填写将自动提取。"></textarea>
            </td>
        </tr>
        <tr class="upordown noshow">
            <td style="text-align:right; background: #F5F5F5; ">Description(描述)：</td>
            <td colspan="5" style="">
            <textarea name="SEODescription" runat="server" rows="5" cols="100" style=" width:65%; border:solid 1px #787a7b" id="SEODescription" HintTitle="文章导读属性" maxlength="250" HintInfo="控制在250个字数内，纯文本，不填写将自动提取。"></textarea>
            </td>
        </tr>
            <tr>
                <td style="width:15%;background: #F5F5F5; text-align:right ">出发城市<span class="red">*</span>：</td>
                <td style="padding-right:10px;">
                    <asp:DropDownList ID="ddlCity" runat="server" CssClass="select1 required">
                    </asp:DropDownList>
                </td>
                <td style="width:15%;background: #F5F5F5; text-align:right " colspan="2">行程天数<span class="red">*</span>：</td>
                <td style="padding-right:5px; width:30%" colspan="2">
                    <asp:DropDownList ID="ddlDayNumber" runat="server" CssClass="select1 required">
                        <asp:ListItem Value="">选择天数</asp:ListItem>
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
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width:15%;background: #F5F5F5; text-align:right ">目的地类型<span class="red">*</span>：</td>
                <td colspan="5" style="">
                     <asp:DropDownList ID="ddlDestType" runat="server" CssClass="select1 required" onchange="getSubDestList();">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width:15%;background: #F5F5F5; text-align:right ">目的地<span class="red">*</span>：</td>
                <td colspan="5" style="padding-right:15px">
                    <div id="divDest" runat="server">
                    
                    </div>
                    <input id="hidDest" name="hidDest" type="hidden" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width:15%;background: #F5F5F5; text-align:right ">参团性质<span class="red">*</span>：</td>
                <td colspan="5" style="">
                   <%-- <asp:CheckBoxList ID="chkJoinProperty" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
        </asp:CheckBoxList>--%>
                    <asp:DropDownList ID="ddlJoinPropery" runat="server" CssClass="select1 required">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width:15%;background: #F5F5F5; text-align:right ">线路主题<span class="red">*</span>：</td>
                <td colspan="5" style="">
                    <asp:CheckBoxList ID="chkTheme" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
        </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td style="width:15%;background: #F5F5F5; text-align:right ">线路特色<span class="red">*</span>：</td>
                <td colspan="5" >
                    <textarea id="txtFeature" name="txtFeature" cols="100" rows="4" style="width:800px; height:200px;" runat="server"></textarea>
                </td>
            </tr>
            <tr>
                <td style="width:15%;background: #F5F5F5; text-align:right ">往返交通<span class="red">*</span>：</td>
                <td colspan="5" style="">
                    <asp:CheckBoxList ID="chkTraffic" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="汽车">汽车</asp:ListItem>
                        <asp:ListItem Value="火车">火车</asp:ListItem>
                        <asp:ListItem Value="飞机">飞机</asp:ListItem>
                        <asp:ListItem Value="游轮">游轮</asp:ListItem>
                      <%--  <asp:ListItem Value="动车">动车</asp:ListItem>
                        <asp:ListItem Value="高铁">高铁</asp:ListItem>--%>
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td style="width:15%;background: #F5F5F5; text-align:right ">建议提前<span class="red">*</span>：</td>
                <td style=""><asp:TextBox ID="txtAheadNumber" runat="server" CssClass="dfinput required" 
            maxlength="50" Width="100px"  onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" Text=""></asp:TextBox>
                    天报名</td>
                 <td style="background: #F5F5F5; text-align:right" colspan="2">购买保险<span class="red">*</span>：</td>
                 <td colspan="2" style="">
                     <asp:DropDownList ID="ddlInsurance" runat="server" CssClass="select2 required">
                     </asp:DropDownList>
                 </td>
            </tr>
            <tr>
                <td style="width:15%;background: #F5F5F5; text-align:right ">状态属性：</td>
                <td style=""><asp:CheckBoxList ID="chkState" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
        </asp:CheckBoxList></td>
                <td style="background: #F5F5F5; text-align:right" colspan="2">排序<span class="red">*</span>：</td>
                <td colspan="2" style=" padding:15px"><asp:TextBox ID="txtSort" runat="server" CssClass="dfinput required" 
            maxlength="50" Width="100px"  onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" Text="0"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width:15%;background: #F5F5F5; text-align:right ">是否隐藏：</td>
                <td  style="padding-right:15px">
                    <asp:CheckBox ID="chkIsLock" runat="server" />
                </td>
                <td colspan="2" style="background: #F5F5F5; text-align:right">
                    关注度：</td>
                <td colspan="2" style=" padding-left:15px; padding-right:15px">
                    <asp:TextBox ID="txtGZD" runat="server" CssClass="dfinput required" 
            maxlength="50" Width="100px"  onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" Text="0"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width:15%;background: #F5F5F5; text-align:right ">节日特惠：</td>
                <td colspan="5" style="">
                    <asp:CheckBoxList ID="chkHoliday" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td style="width:15%;background: #F5F5F5; text-align:right "></td>
                <td colspan="5">
                    <asp:Button ID="btnSave" runat="server" Text="保存进入下一步" CssClass="btn" 
                    onclick="btnSave_Click" />&nbsp;
                    <asp:Button ID="btnSave1" runat="server" Text="保存返回列表" CssClass="btn" 
                        onclick="btnSave1_Click" /> &nbsp;
                </td>
            </tr>
            
        </table>
     </form>
    </div>
    </div>


</body>

</html>
