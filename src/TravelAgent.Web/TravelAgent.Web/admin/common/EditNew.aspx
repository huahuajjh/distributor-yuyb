<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditNew.aspx.cs" Inherits="TravelAgent.Web.admin.common.EditNew" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>发布内容</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <script type="text/javascript" src="/js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="/js/jquery.validate.min.js"></script>
    <script type="text/javascript" src="/js/validate.js"></script>
    <script type="text/javascript" src="/js/jquery.form.js"></script>
    <script type="text/javascript" src="../js/singleupload.js"></script>
    <script type="text/javascript" src="../js/select-ui.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="/ueditor/ueditor.all.js"></script>
    <script type="text/javascript" charset="utf-8" src="/ueditor/ueditor.config.js"></script>
    <script src="/ueditor/lang/zh-cn/zh-cn.js" type="text/javascript"></script>
    <script type="text/javascript" src="/ueditor/editorconfig.js"></script>
    <script type="text/javascript">
        $(function() {
            $("#ddlCategory").uedSelect({
                width: 150
            });
            $("#ddlDestType").uedSelect({
                width: 150
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

            $("#upordowndest").toggle(function() {
                $(this).text("关闭目的地");
                $(this).removeClass();
                $(this).addClass("expand");
                $(".upordowndest").show();
            }, function() {
                $(this).text("显示目的地");
                $(this).removeClass();
                $(this).addClass("shrink");
                $(".upordowndest").hide();
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
                    valuelist = "," + valuelist;
                }
                $("#hidDest").val(valuelist);
            })
            //创建编辑器
            CreateEditor('txtContent', 'full');
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
    <form id="form1" runat="server">
     <div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">通用模块</a></li>
    <li><a href="#">
        编辑内容</a></li>
    </ul>
    </div>
    <div style="padding-bottom:10px;">
    <table border="0" cellpadding="0" cellspacing="0" style="width:100%;" class="formtable">
        <tr>
            <th colspan="3" style="text-align:left; color:#056dae;background: #F5F5F5;  padding-left:10px; font-size:16px; line-height:60px;"><asp:Literal ID="ltTag1" runat="server" Text="添加内容"></asp:Literal>（<span class="red">*</span>为必填项）</th>
        </tr>
        <tr>
            <td width="15%" style="text-align:right; color:#056dae;background: #F5F5F5; ">标题<span class="red">*</span>：</td>
            <td width="85%" colspan="2">
            <asp:TextBox ID="txtTitle" runat="server" CssClass="dfinput required" 
            maxlength="250" minlength="3" Width="300px" HintTitle="内容标题" HintInfo="控制在100个字数内，标题文本尽量不要太长。"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align:right; color:#056dae;background: #F5F5F5; ">来源<span class="red">*</span>：</td>
            <td>
            <asp:TextBox ID="txtForm" runat="server" CssClass="dfinput required" 
            maxlength="100" Width="100px" HintTitle="内容来源" HintInfo="控制在50个字数内，如“本站”。">本站</asp:TextBox>
            </td>
            <td style=" padding-right:10px;"><span id="upordown" class="shrink">显示SEO选项</span></td>
        </tr>
        <tr class="upordown noshow">
            <td style="text-align:right; color:#056dae;background: #F5F5F5; ">Meta Title(标题):</td>
            <td colspan="2" style="">
            <textarea runat="server" name="SEOTitle" rows="3" cols="100"   id="SEOTitle"  style=" width:65%; border:solid 1px #787a7b" HintTitle="Meta关键字" HintInfo="用于搜索引擎，如有多个关健字请用英文的,号分隔，不填写将自动提取标题。"></textarea>
            </td>
        </tr>
        <tr class="upordown noshow">
            <td style="text-align:right; color:#056dae;background: #F5F5F5; ">Keywords(关键字)：</td>
            <td colspan="2" style="">
            <textarea name="SEOKeywords" runat="server" rows="3" cols="100" style=" width:65%; border:solid 1px #787a7b" id="SEOKeywords" HintTitle="Meta描述"  HintInfo="用于搜索引擎，控制在250个字数内，不填写将自动提取。"></textarea>
            </td>
        </tr>
        <tr class="upordown noshow">
            <td style="text-align:right; color:#056dae;background: #F5F5F5; ">Description(描述)：</td>
            <td colspan="2" style="">
            <textarea name="SEODescription" runat="server" rows="5" cols="100" style=" width:65%; border:solid 1px #787a7b" id="SEODescription" HintTitle="文章导读属性" maxlength="250" HintInfo="控制在250个字数内，纯文本，不填写将自动提取。"></textarea>
            </td>
        </tr>
        <tr>
            <td style="text-align:right; color:#056dae;background: #F5F5F5; ">URL跳转：</td>
            <td colspan="2">
                <asp:TextBox ID="txtUrl" runat="server" CssClass="dfinput url"  Width="300px" HintTitle="URL跳转" HintInfo="请输入合法的URL地址，以http://开头。"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align:right; color:#056dae;background: #F5F5F5; ">所属分类<span class="red">*</span>：</td>
            <td style="padding-top:10px;">
                    <asp:DropDownList ID="ddlCategory" runat="server" CssClass="required"></asp:DropDownList>
             </td>
             <td style=" padding-right:10px;"><span id="upordowndest" class="shrink">显示目的地</span></td>
        </tr>
        <tr class="upordowndest noshow">
                <td style="background: #F5F5F5; text-align:right;color:#056dae;">目的地类型：</td>
                <td colspan="2" style="">
                     <asp:DropDownList ID="ddlDestType" runat="server" CssClass="select1" onchange="getSubDestList();">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr class="upordowndest noshow">
                <td style="background: #F5F5F5; text-align:right;color:#056dae;">目的地：</td>
                <td colspan="2" style="padding-right:15px">
                    <div id="divDest" runat="server">
                    
                    </div>
                    <input id="hidDest" name="hidDest" type="hidden" runat="server" />
                </td>
            </tr>
        <tr>
            <td style="text-align:right; color:#056dae;background: #F5F5F5; ">缩略图：</td>
            <td colspan="2" style="">
                <asp:TextBox ID="txtImgUrl" runat="server" CssClass="dfinput left" Width="200px"></asp:TextBox>
                <a href="javascript:void(0);" class="files"><input type="file" id="FileUpload" name="FileUpload" /></a>
                <span class="uploading">正在上传，请稍候...</span>
            </td>
        </tr>
        <tr>
            <td style="text-align:right; color:#056dae;background: #F5F5F5; " valign="top">内容：</td>
            <td colspan="2">
           <textarea id="txtContent" name="txtContent" cols="100" rows="8" style="width:100%; height:400px;" runat="server"></textarea>
            </td>
        </tr>
        <tr>
            <td style="text-align:right; color:#056dae;background: #F5F5F5; ">是否显示：</td>
            <td colspan="2" style=" padding-left:10px">
               <%--<asp:CheckBoxList ID="chkState" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
        </asp:CheckBoxList>--%>
                <asp:CheckBox ID="checkHidden" runat="server" Text="隐藏" />
            </td>
        </tr>
        <tr>
            <td style="text-align:right; color:#056dae;background: #F5F5F5; ">序号 <span class="red">*</span>：</td>
            <td colspan="2">
            <asp:TextBox ID="txtClick" runat="server" CssClass="dfinput required digits" size="10" 
            maxlength="10" Width="100px" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);">0</asp:TextBox>
            </td>
        </tr>
        
        <tr>
            <td style="text-align:right; color:#056dae;background: #F5F5F5; "></td>
            <td colspan="2" style=" padding-left:15px">
                <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="btn" 
                    onclick="btnSave_Click" /> &nbsp;
                <input name="重置" type="reset" class="resetbtn" value="重置" />
            </td>
        </tr>
    </table>
    </div>
    <div style="margin-top:10px;text-align:center;">
 
</div>
    </form>
</body>
</html>
