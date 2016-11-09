<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarOne.aspx.cs" Inherits="TravelAgent.Web.admin.car.CarOne" %>

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
        CreateEditor('txtCarContent', 'full');
        CreateEditor('txtOrderTip', 'simple');
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
    <li><a href="#" class="selected">第一步：租车信息</a></li> 
    <li><a href="CarTwo.aspx?carid=<%= carid %>" style="color:#bdbdbd;" class="liNav">第二步：价格计划</a></li>
  	</ul>
    </div> 
    <div style="padding-top:5px;">
    <form id="form1" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" style="width:100%;" class="formtable">
            <tr>
                <td style="width:15%;background: #F5F5F5; text-align:right ">名称<span class="red">*</span>：</td>
                <td colspan="5" style="">
                    <asp:TextBox ID="txtCarName" runat="server" CssClass="dfinput required" 
            maxlength="30" minlength="3" Width="300px" HintTitle="线路标题" HintInfo="控制在30个字数内，标题文本尽量不要太长。可参考方式：城市+景点之一+交通方式+时间"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td style="width:15%;background: #F5F5F5; text-align:right ">缩略图<span class="red">*</span>：</td>
                <td colspan="5" style="">
                    <asp:TextBox ID="txtImgUrl" runat="server" CssClass="dfinput left" Width="200px"></asp:TextBox>
                    <a href="javascript:void(0);" class="files"><input type="file" id="FileUpload" name="FileUpload" />浏览上传图片</a>
                    <span class="uploading">正在上传，请稍候...</span>推荐像素380 * 320
                </td>
            </tr>
            <tr>
                <td style="width:15%;background: #F5F5F5; text-align:right ">品牌<span class="red">*</span>：</td>
                <td style="padding-right:10px;">
                    <asp:DropDownList ID="ddlBrand" runat="server" CssClass="select1 required">
                    </asp:DropDownList>
                </td>
                <td style="width:15%;background: #F5F5F5; text-align:right " colspan="2">级别<span class="red">*</span>：</td>
                <td style="padding-right:5px; width:30%" colspan="2">
                    <asp:DropDownList ID="ddlClass" runat="server" CssClass="select1 required">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width:15%;background: #F5F5F5; text-align:right ">座位<span class="red">*</span>：</td>
                <td colspan="5" style="">
                     <asp:TextBox ID="txtSeat" runat="server" CssClass="dfinput required" Width="100px" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width:15%;background: #F5F5F5; text-align:right ">租车介绍<span class="red">*</span>：</td>
                <td colspan="5" >
                    <textarea id="txtCarContent" name="txtCarContent" cols="100" rows="4" style="width:800px; height:400px;" runat="server"></textarea></td>
            </tr>
            <tr>
                <td style="width:15%;background: #F5F5F5; text-align:right ">预订须知<span class="red">*</span>：</td>
                <td colspan="5" >
                    <textarea id="txtOrderTip" name="txtOrderTip" cols="100" rows="4" style="width:800px; height:400px;" runat="server"></textarea></td>
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
                <td colspan="2" style="background: #F5F5F5; text-align:right"></td>
                <td colspan="2" style=" padding-left:15px; padding-right:15px">
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
