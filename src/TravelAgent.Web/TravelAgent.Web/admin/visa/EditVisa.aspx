<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditVisa.aspx.cs" Inherits="TravelAgent.Web.admin.visa.EditVisa" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>发布内容</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <script type="text/javascript" src="/js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="/js/jquery.validate.min.js"></script>
    <script type="text/javascript" src="/js/validate.js"></script>
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
             CreateEditor('txtTips', 'full');
             CreateEditor('txtMaterial', 'full');
             $("#chkState").click(function() {
                 var valuelist = ""; //保存checkbox选中值        
                 //遍历name以listTest开头的checkbox
                 $("input[name^='chkState']").each(function() {
                     if (this.checked) {
                         //$(this):当前checkbox对象;               
                         //$(this).parent("span"):checkbox父级span对象                
                         valuelist += $(this).parent("span").attr("alt") + ",";
                     }
                 });
                 if (valuelist.length > 0) {
                     //得到选中的checkbox值序列,结果为400,398
                     valuelist = ","+valuelist;
                 }
                 $("#hidState").val(valuelist);
             })
             //表单验证JS
             $("#form1").validate({
                 //出错时添加的标签
                 errorElement: "span",
                 success: function(label) {
                     //正确时的样式
                     label.text(" ").addClass("success");
                 }
             });
         })
    </script>
</head>
<body>
    <form id="form1" runat="server">
     <div class="place">
    <span>位置：</span>
    <ul class="placeul">
   <li><a href="#">产品管理</a></li>
    <li><a href="#">签证产品</a></li>
    <li><a href="#">编辑签证</a></li>
    </ul>
    </div>
    <div style="padding-bottom:10px;">
    <table border="0" cellpadding="0" cellspacing="0" style="width:100%;" class="formtable">
        <tr>
            <td style="text-align:left; color:#056dae;background: #F5F5F5;  padding-left:10px; font-size:16px; line-height:60px;" 
                colspan="4"><asp:Literal ID="ltTag1" runat="server" Text="添加签证"></asp:Literal>（<span class="red">*</span>为必填项）</td>
        </tr>
        <tr>
            <td style="width:15%;background: #F5F5F5; text-align:right ">签证标题<span class="red">*</span>：</td>
            <td style="width:35%">
            <asp:TextBox ID="txtTitle" runat="server" CssClass="dfinput required" 
            maxlength="50" minlength="3" Width="300px" HintTitle="签证标题" HintInfo="控制在50个字数内，标题文本尽量不要太长。"></asp:TextBox>
            </td>
            <td style="width:15%;background: #F5F5F5;text-align:right ">签证类型<span class="red">*</span>：</td>
            <td style="width:35%; padding-left:15px;">
            <asp:DropDownList ID="ddlType" runat="server" CssClass="select1 required">
                    </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width:15%;background: #F5F5F5;text-align:right ">国家<span class="red">*</span>：</td>
            <td style="width:35%;padding-left:15px;">
                <asp:DropDownList ID="ddlCountry" runat="server" CssClass="select1 required">
                    </asp:DropDownList>
            </td>
            <td style="width:15%;background: #F5F5F5;text-align:right ">所属领区<span class="red">*</span>：</td>
            <td style="width:35%;padding-left:15px;">
                <asp:DropDownList ID="ddlSign" runat="server" CssClass="select1 required">
                    </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width:15%;background: #F5F5F5;text-align:right ">销售价<span class="red">*</span>：</td>
            <td style="width:35%">
                <asp:TextBox ID="txtPrice" runat="server" CssClass="dfinput required" 
            maxlength="50" Width="100px"  onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);"></asp:TextBox>元（填0表示需要面议）
            </td>
            <td style="width:15%;background: #F5F5F5;text-align:right ">使用积分<span class="red">*</span>：</td>
            <td style="width:35%">
                <asp:TextBox ID="txtUsePoints" runat="server" CssClass="dfinput required" 
            maxlength="50" Width="100px"  onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);"></asp:TextBox>分
            </td>
        </tr>
        <tr>
            <td style="width:15%;background: #F5F5F5;text-align:right ">赠送积分<span class="red">*</span>：</td>
            <td style="width:35%">
                <asp:TextBox ID="txtDonatePoints" runat="server" CssClass="dfinput required" 
            maxlength="50" Width="100px"  onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);"></asp:TextBox>分
            </td>
            <td style="width:15%;background: #F5F5F5;text-align:right ">办理期限<span class="red">*</span>：</td>
            <td style="width:35%">
                <asp:TextBox ID="txtDealTime" runat="server" CssClass="dfinput required" 
            maxlength="50" Width="300px" HintTitle="办理期限" HintInfo="控制在50个字数内，如3个工作日"  Text="3个工作日"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width:15%;background: #F5F5F5;text-align:right ">停留期限<span class="red">*</span>：</td>
            <td style="width:35%">
                <asp:TextBox ID="txtStayTime" runat="server" CssClass="dfinput required" 
            maxlength="50" Width="300px"  Text="10日" HintTitle="停留期限" HintInfo="控制在50个字数内，如10日"></asp:TextBox>
            </td>
            <td style="width:15%;background: #F5F5F5;text-align:right ">入境次数<span class="red">*</span>：</td>
            <td style="width:35%">
                <asp:TextBox ID="txtEnterNumber" runat="server" CssClass="dfinput required" 
            maxlength="50" Width="300px"  Text="多次" HintTitle="入境次数" HintInfo="控制在50个字数内，如多次"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width:15%;background: #F5F5F5; text-align:right">是否面试<span class="red">*</span>：</td>
            <td style="width:35%">
                <asp:TextBox ID="txtInterview" runat="server" CssClass="dfinput required" 
            maxlength="50" minlength="3" Width="300px"  Text="不需要" HintTitle="是否面试" HintInfo="控制在50个字数内，如不需要"></asp:TextBox>
            </td>
            <td style="width:15%;background: #F5F5F5; text-align:right">有效期<span class="red">*</span>：</td>
            <td style="width:35%">
                 <asp:TextBox ID="txtExpiryDate" runat="server" CssClass="dfinput required" 
            maxlength="50" minlength="3" Width="300px"  Text="20个月" HintTitle="有效期" HintInfo="控制在50个字数内，如20个月"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width:15%;background: #F5F5F5; text-align:right">签证状态<span class="red">*</span>：</td>
            <td style="width:35%">
                <asp:CheckBoxList ID="chkState" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
        </asp:CheckBoxList>
            </td>
            <td style="width:15%;background: #F5F5F5; text-align:right">排序<span class="red">*</span>：</td>
            <td style="width:35%">
                <asp:TextBox ID="txtSort" runat="server" CssClass="dfinput required" 
            maxlength="50" Width="100px"  onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" Text="0"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width:15%;background: #F5F5F5; text-align:right">处理方式<span class="red">*</span>：</td>
            <td colspan="3">
                
        <asp:RadioButtonList ID="rbtnDealType" runat="server" 
            RepeatDirection="Horizontal" RepeatLayout="Flow">
            <asp:ListItem Value="0" Selected="True">人工处理</asp:ListItem>
            <asp:ListItem Value="1">自动处理</asp:ListItem>
        </asp:RadioButtonList>&nbsp;&nbsp;注："人工处理"订单提交后需经后台审核方可在线支付,"自动处理"订单提交后可直接支付，无需后台审核设置
            </td>
        </tr>
        <tr>
            <td style="width:15%;background: #F5F5F5; text-align:right">友情提示<span class="red">*</span>：</td>
            <td colspan="3"><textarea id="txtTips" name="txtTips" cols="100" rows="4" style="width:800px; height:200px;" runat="server"></textarea></td>
        </tr>
        <tr>
            <td style="width:15%;background: #F5F5F5; text-align:right">签证办理所需材料<span class="red">*</span>：</td>
            <td colspan="3"><textarea id="txtMaterial" name="txtMaterial" cols="100" rows="4" style="width:800px; height:200px;" runat="server"></textarea></td>
        </tr>
        <tr>
            <td style="width:15%;background: #F5F5F5; text-align:right">是否隐藏：</td>
            <td colspan="3">
                <asp:CheckBox ID="chkIsLock" runat="server" /></td>
        </tr>
        <tr>
            <td style="text-align:right; color:#056dae;background: #F5F5F5; "></td>
            <td colspan="3" style=" padding-left:15px">
                <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="btn" 
                    onclick="btnSave_Click" /> &nbsp;
                <input name="重置" type="reset" class="resetbtn" value="重置" />
            </td>
        </tr>
    </table>
    </div>
    <div style="margin-top:10px;text-align:center;">
 
</div>
   <input id="hidState" name="hidState" type="hidden" value="" runat="server" />
    </form>
</body>
</html>
