<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditRole.aspx.cs" Inherits="TravelAgent.Web.admin.basicset.EditRole" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="/admin/css/style.css" />
    <script type="text/javascript" src="/js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="/js/jquery.validate.min.js"></script>
    <script type="text/javascript" src="/js/validate.js"></script>
    <style type="text/css">
        .middle{ vertical-align:middle;}
        label{ vertical-align:middle;}
    </style>
    <script type="text/javascript">
        //选择
        function selectAll(obj) {
            if ($(obj).attr("checked")) {
                $("." + obj.value).attr("checked", true);
            }
            else {
                $("." + obj.value).attr("checked", false);
            }
        }
        //获取权限值
        function getAuthValue() {
            var authv = "";
            $("input:checked").each(function() {
                authv = authv + $(this).val() + ",";
            })
            if (authv != "") {
                authv = "," + authv;
            }
            return authv;
        }
        $(function() {
            var aurh = $("#hidauth").val();
            $(":checkbox").each(function() {
                if (aurh.indexOf("," + $(this).val() + ",") > -1) {
                    $(this).attr("checked", true);
                }
            })
            $("#btnSave").click(function() {
                if ($.trim($("#txtRole").val()) == "") {
                    alert("请输入角色名称！");
                    $("#txtRole").focus();
                    return false;
                }
                var auth = getAuthValue();
                $.ajax({
                    type: "POST",
                    url: "../data/Role.aspx?date=" + new Date().toUTCString(),
                    cache: false,
                    dataType: "text",
                    data: { rolename: $.trim($("#txtRole").val()), roleinfo: $("#txtRoleInfo").val(), roleauth: auth, roleid: $("#hidroleid").val() },
                    success: function(msg) {
                        //提示删除成功消息
                        if (msg.indexOf("true") >= 0) {
                            location.href = "RoleList.aspx?date=" + new Date().toUTCString();
                            return false;
                        }
                        else {
                            art.dialog.alert("删除失败！");
                            return false;
                        }
                    }
                })
            })
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
     <div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">系统设置</a></li>
    <li><a href="#">
        角色权限编辑</a></li>
    </ul>
    </div>
    <div style="padding-bottom:10px;">
    <table border="0" cellpadding="0" cellspacing="0" style="width:100%;" class="formtable">
        <tr>
            <th colspan="3" style="text-align:left; color:#056dae;background: #F5F5F5;  padding-left:10px; font-size:16px; line-height:60px;"><asp:Literal ID="ltTag1" runat="server" Text="添加角色"></asp:Literal>（<span class="red">*</span>为必填项）</th>
        </tr>
        <tr>
            <td width="10%" style="text-align:right; color:#056dae;background: #F5F5F5; ">
               角色名称 <span class="red">*</span>：</td>
            <td>
            <asp:TextBox ID="txtRole" runat="server" CssClass="dfinput required" 
            maxlength="250" minlength="3" Width="150px" HintTitle="角色名称" HintInfo="控制在50个字数内，名称文本尽量不要太长。"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align:right; color:#056dae;background: #F5F5F5; ">角色说明：</td>
            <td>
            <textarea name="txtRoleInfo" runat="server" rows="5" cols="100" style=" width:300px; border:solid 1px #787a7b" id="txtRoleInfo" HintTitle="角色说明" maxlength="250" HintInfo="控制在250个字数内，纯文本。"></textarea>
            </td>
        </tr>
        <tr>
            <td style="text-align:right; color:#056dae;background: #F5F5F5; ">角色权限：</td>
            <td>
            <table border="0" cellpadding="0" cellspacing="0" style="width:100%;" class="formtable">
                <tr>
                    <td style="width:12%;text-align:center;background: #F5F5F5;"><input id="Checkbox1" type="checkbox" class="middle sys" value="sys" onclick="selectAll(this)" /><label>系统设置</label></td>
                    <td>
                        <table border="0" cellpadding="0" cellspacing="0" style="width:100%;" class="formtable">
                        <tr>
                            <td style="width:15%; background:#F5F5F5; text-align:center"><input id="Checkbox6" type="checkbox" class="middle sys sysbase" value="sysbase" onclick="selectAll(this)" /><label>网站基本设置</label></td>
                            <td>
                                <input id="Checkbox14" type="checkbox" class="middle sys sysbase sysbase_update" value="sysbase_update" /><label>修改</label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:15%; background:#F5F5F5; text-align:center"><input id="Checkbox7" type="checkbox" class="middle sys sysnav" value="sysnav" onclick="selectAll(this)" /><label>网站导航设置</label></td>
                            <td>
                                 <input id="Checkbox34" type="checkbox" class="middle sys sysnav sysnav_add" value="sysnav_add" /><label>添加</label>
                                 <input id="Checkbox12" type="checkbox" class="middle sys sysnav sysnav_update" value="sysnav_update" /><label>修改</label>
                                 <input id="Checkbox32" type="checkbox" class="middle sys sysnav sysnav_delete" value="sysnav_delete" /><label>删除</label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:15%; background:#F5F5F5; text-align:center"><input id="Checkbox8" type="checkbox" class="middle sys sysbrand" value="sysbrand" onclick="selectAll(this)" /><label>网站品牌设置</label></td>
                            <td>
                                  <input id="Checkbox36" type="checkbox" class="middle sys sysbrand sysbrand_add" value="sysbrand_add" /><label>添加</label>
                                 <input id="Checkbox13" type="checkbox" class="middle sys sysbrand sysbrand_update" value="sysbrand_update" /><label>修改</label>
                                 <input id="Checkbox33" type="checkbox" class="middle sys sysbrand sysbrand_delete" value="sysbrand_delete" /><label>删除</label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:15%; background:#F5F5F5; text-align:center"><input id="Checkbox61" type="checkbox" class="middle sys sysinterface" value="sysinterface" onclick="selectAll(this)" /><label>网站接口设置</label></td>
                            <td>
                                 <input id="Checkbox76" type="checkbox" class="middle sys sysinterface sysinterface_update" value="sysinterface_update" /><label>修改</label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:15%; background:#F5F5F5; text-align:center"><input id="Checkbox94" type="checkbox" class="middle sys sysother" value="sysother" onclick="selectAll(this)" /><label>网站其他设置</label></td>
                            <td>
                                 <input id="Checkbox98" type="checkbox" class="middle sys sysother sysother_update" value="sysother_update" /><label>修改</label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:15%; background:#F5F5F5; text-align:center"><input id="Checkbox9" type="checkbox" class="middle sys sysclub" value="sysclub" onclick="selectAll(this)" /><label>会员系统设置</label></td>
                            <td>
                                 <input id="Checkbox15" type="checkbox" class="middle sys sysclub sysclub_update" value="sysclub_update"  /><label>修改</label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:15%; background:#F5F5F5; text-align:center"><input id="Checkbox10" type="checkbox" class="middle sys sysrole" value="sysrole" onclick="selectAll(this)" /><label>角色权限设置</label></td>
                            <td>
                                <input id="Checkbox41" type="checkbox" class="middle sys sysrole sysrole_add" value="sysrole_add" /><label>添加</label>
                                 <input id="Checkbox46" type="checkbox" class="middle sys sysrole sysrole_update" value="sysrole_update" /><label>修改</label>
                                <input id="Checkbox16" type="checkbox" class="middle sys sysrole sysrole_delete" value="sysrole_delete" /><label>删除</label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:15%; background:#F5F5F5; text-align:center"><input id="Checkbox11" type="checkbox" class="middle sys sysuser" value="sysuser" onclick="selectAll(this)" /><label>操作用户管理</label></td>
                            <td>
                                 <input id="Checkbox17" type="checkbox" class="middle sys sysuser sysuser_add" value="sysuser_add" /><label>添加</label>
                                <input id="Checkbox51" type="checkbox" class="middle sys sysuser sysuser_update" value="sysuser_update" /><label>修改</label>
                                <input id="Checkbox52" type="checkbox" class="middle sys sysuser sysuser_delete" value="sysuser_delete" /><label>删除</label>
                            </td>
                        </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center;background: #F5F5F5;"><input id="Checkbox2" type="checkbox" class="middle pro" value="pro" onclick="selectAll(this)" /><label>产品管理</label></td>
                    <td>
                          <table border="0" cellpadding="0" cellspacing="0" style="width:100%;" class="formtable">
                                <tr>
                                    <td style="width:15%;background:#F5F5F5; text-align:center"><input id="Checkbox18" type="checkbox" class="middle pro proline" value="proline" onclick="selectAll(this)" /><label>线路产品</label></td>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0" style="width:100%;" class="formtable">
                                            <tr>
                                                <td style="width:15%;background:#F5F5F5; text-align:left"><input id="Checkbox20" type="checkbox" class="middle pro proline linelist" value="linelist" onclick="selectAll(this)" /><label>线路列表</label></td>
                                                <td>
                                                <%--<input id="Checkbox34" type="checkbox" class="middle pro proline linelist linelist_view" value="linelist_view" /><label>查看</label>--%>
                                                <input id="Checkbox37" type="checkbox" class="middle pro proline linelist linelist_add" value="linelist_add" /><label>添加</label>
                                                <input id="Checkbox42" type="checkbox" class="middle pro proline linelist linelist_update" value="linelist_update" /><label>修改</label>
                                                <input id="Checkbox47" type="checkbox" class="middle pro proline linelist linelist_delete" value="linelist_delete" /><label>删除</label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width:15%;background:#F5F5F5;text-align:left "><input id="Checkbox21" type="checkbox" class="middle pro proline linesupply" value="linesupply" onclick="selectAll(this)" /><label>线路供应商</label></td>
                                                <td>
                                                <%--<input id="Checkbox52" type="checkbox" class="middle pro proline linesupply linesupply_view" value="linesupply_view" /><label>查看</label>--%>
                                                <input id="Checkbox67" type="checkbox" class="middle pro proline linesupply linesupply_add" value="linesupply_add" /><label>添加</label>
                                                <input id="Checkbox80" type="checkbox" class="middle pro proline linesupply linesupply_update" value="linesupply_update" /><label>修改</label>
                                                <input id="Checkbox81" type="checkbox" class="middle pro proline linesupply linesupply_delete" value="linesupply_delete" /><label>删除</label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width:15%;background:#F5F5F5;text-align:left "><input id="Checkbox22" type="checkbox" class="middle pro proline linedest" value="linedest" onclick="selectAll(this)" /><label>目的地分类</label></td>
                                                <td>
                                                <%--<input id="Checkbox82" type="checkbox" class="middle pro proline linedest linedest_view" value="linedest_view"  /><label>查看</label>--%>
                                                <input id="Checkbox83" type="checkbox" class="middle pro proline linedest linedest_add" value="linedest_add" /><label>添加</label>
                                                <input id="Checkbox84" type="checkbox" class="middle pro proline linedest linedest_update" value="linedest_update" /><label>修改</label>
                                                <input id="Checkbox85" type="checkbox" class="middle pro proline linedest linedest_delete" value="linedest_delete" /><label>删除</label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width:15%;background:#F5F5F5;text-align:left "><input id="Checkbox23" type="checkbox" class="middle pro proline linetheme" value="linetheme" onclick="selectAll(this)" /><label>线路主题</label></td>
                                                <td>
                                                <%--<input id="Checkbox86" type="checkbox" class="middle pro proline linetheme linetheme_view" value="linetheme_view" /><label>查看</label>--%>
                                                <input id="Checkbox87" type="checkbox" class="middle pro proline linetheme linetheme_add" value="linetheme_add" /><label>添加</label>
                                                <input id="Checkbox88" type="checkbox" class="middle pro proline linetheme linetheme_update" value="linetheme_update" /><label>修改</label>
                                                <input id="Checkbox89" type="checkbox" class="middle pro proline linetheme linetheme_delete" value="linetheme_delete" /><label>删除</label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width:15%;background:#F5F5F5;text-align:left "><input id="Checkbox71" type="checkbox" class="middle pro proline lineholiday" value="lineholiday" onclick="selectAll(this)" /><label>节日推荐</label></td>
                                                <td>
                                                <%--<input id="Checkbox86" type="checkbox" class="middle pro proline linetheme linetheme_view" value="linetheme_view" /><label>查看</label>--%>
                                                <input id="Checkbox82" type="checkbox" class="middle pro proline lineholiday lineholiday_add" value="lineholiday_add" /><label>添加</label>
                                                <input id="Checkbox86" type="checkbox" class="middle pro proline lineholiday lineholiday_update" value="lineholiday_update" /><label>修改</label>
                                                <input id="Checkbox90" type="checkbox" class="middle pro proline lineholiday lineholiday_delete" value="lineholiday_delete" /><label>删除</label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width:15%;background:#F5F5F5;text-align:left "><input id="Checkbox24" type="checkbox" class="middle pro proline linecity" value="linecity" onclick="selectAll(this)" /><label>出发城市</label></td>
                                                <td>
                                                <%--<input id="Checkbox90" type="checkbox" class="middle pro proline linecity linecity_view" value="linecity_view" /><label>查看</label>--%>
                                                <input id="Checkbox91" type="checkbox" class="middle pro proline linecity linecity_add"  value="linecity_add" /><label>添加</label>
                                                <input id="Checkbox92" type="checkbox" class="middle pro proline linecity linecity_update"  value="linecity_update" /><label>修改</label>
                                                <input id="Checkbox93" type="checkbox" class="middle pro proline linecity linecity_delete"  value="linecity_delete" /><label>删除</label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width:15%;background:#F5F5F5;text-align:left "><input id="Checkbox25" type="checkbox" class="middle pro proline linejoin" value="linejoin" onclick="selectAll(this)" /><label>参团性质</label></td>
                                                <td>
                                                <%--<input id="Checkbox94" type="checkbox" class="middle pro proline linejoin linejoin_view" value="linejoin_view" /><label>查看</label>--%>
                                                <input id="Checkbox95" type="checkbox" class="middle pro proline linejoin linejoin_add" value="linejoin_add" /><label>添加</label>
                                                <input id="Checkbox96" type="checkbox" class="middle pro proline linejoin linejoin_update" value="linejoin_update" /><label>修改</label>
                                                <input id="Checkbox97" type="checkbox" class="middle pro proline linejoin linejoin_delete" value="linejoin_delete" /><label>删除</label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width:15%;background:#F5F5F5;text-align:left "><input id="Checkbox26" type="checkbox" class="middle pro proline lineinsure" value="lineinsure" onclick="selectAll(this)" /><label>保险列表</label></td>
                                                <td>
                                                <%--<input id="Checkbox98" type="checkbox" class="middle pro proline lineinsure lineinsure_view" value="lineinsure_view" /><label>查看</label>--%>
                                                <input id="Checkbox99" type="checkbox" class="middle pro proline lineinsure lineinsure_add" value="lineinsure_add" /><label>添加</label>
                                                <input id="Checkbox100" type="checkbox" class="middle pro proline lineinsure lineinsure_update" value="lineinsure_update" /><label>修改</label>
                                                <input id="Checkbox101" type="checkbox" class="middle pro proline lineinsure lineinsure_delete" value="lineinsure_delete" /><label>删除</label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width:15%;background:#F5F5F5;text-align:left "><input id="Checkbox54" type="checkbox" class="middle pro proline linezixun" value="linezixun" onclick="selectAll(this)" /><label>线路咨询</label></td>
                                                <td>
                                                <input id="Checkbox66" type="checkbox" class="middle pro proline linezixun linezixun_update" value="linezixun_update" /><label>操作</label>
                                                <input id="Checkbox69" type="checkbox" class="middle pro proline linezixun linezixun_delete" value="linezixun_delete" /><label>删除</label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:15%;background:#F5F5F5;text-align:center "><input id="Checkbox19" type="checkbox" class="middle pro provisa" value="provisa" onclick="selectAll(this)"  /><label>签证产品</label></td>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0" style="width:100%;" class="formtable">
                                            <tr>
                                                <td style="width:15%;background:#F5F5F5; text-align:left"><input id="Checkbox27" type="checkbox" class="middle pro provisa visalist" value="visalist" onclick="selectAll(this)"  /><label>签证列表</label></td>
                                                <td>
                                                <%--<input id="Checkbox102" type="checkbox" class="middle pro provisa visalist visalist_view" value="visalist_view" /><label>查看</label>--%>
                                                <input id="Checkbox103" type="checkbox" class="middle pro provisa visalist visalist_add" value="visalist_add" /><label>添加</label>
                                                <input id="Checkbox104" type="checkbox" class="middle pro provisa visalist visalist_update" value="visalist_update" /><label>修改</label>
                                                <input id="Checkbox105" type="checkbox" class="middle pro provisa visalist visalist_delete" value="visalist_delete" /><label>删除</label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width:15%;background:#F5F5F5;text-align:left "><input id="Checkbox28" type="checkbox" class="middle pro provisa lingqu" value="lingqu" onclick="selectAll(this)"  /><label>领区管理</label></td>
                                                <td>
                                                <%--<input id="Checkbox106" type="checkbox" class="middle pro provisa lingqu lingqu_view" value="lingqu_view" /><label>查看</label>--%>
                                                <input id="Checkbox107" type="checkbox" class="middle pro provisa lingqu lingqu_add" value="lingqu_add" /><label>添加</label>
                                                <input id="Checkbox108" type="checkbox" class="middle pro provisa lingqu lingqu_update" value="lingqu_update" /><label>修改</label>
                                                <input id="Checkbox109" type="checkbox" class="middle pro provisa lingqu lingqu_delete" value="lingqu_delete" /><label>删除</label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width:15%;background:#F5F5F5;text-align:left "><input id="Checkbox29" type="checkbox" class="middle pro provisa area" value="area" onclick="selectAll(this)"  /><label>签证区域</label></td>
                                                <td>
                                                <%--<input id="Checkbox110" type="checkbox" class="middle pro provisa area area_view" value="area_view" /><label>查看</label>--%>
                                                <input id="Checkbox111" type="checkbox" class="middle pro provisa area area_add" value="area_add" /><label>添加</label>
                                                <input id="Checkbox112" type="checkbox" class="middle pro provisa area area_update" value="area_update" /><label>修改</label>
                                                <input id="Checkbox113" type="checkbox" class="middle pro provisa area area_delete" value="area_delete" /><label>删除</label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width:15%;background:#F5F5F5;text-align:left "><input id="Checkbox30" type="checkbox" class="middle pro provisa visatype" value="visatype" onclick="selectAll(this)"  /><label>签证类型</label></td>
                                                <td>
                                                <%--<input id="Checkbox114" type="checkbox" class="middle pro provisa visatype visatype_view" value="visatype_view" /><label>查看</label>--%>
                                                <input id="Checkbox115" type="checkbox" class="middle pro provisa visatype visatype_add" value="visatype_add" /><label>添加</label>
                                                <input id="Checkbox116" type="checkbox" class="middle pro provisa visatype visatype_update" value="visatype_update" /><label>修改</label>
                                                <input id="Checkbox117" type="checkbox" class="middle pro provisa visatype visatype_delete" value="visatype_delete" /><label>删除</label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width:15%;background:#F5F5F5;text-align:left "><input id="Checkbox31" type="checkbox" class="middle pro provisa visaset"  value="visaset" onclick="selectAll(this)"  /><label>签证设置</label></td>
                                                <td>
                                                <%--<input id="Checkbox118" type="checkbox" class="middle pro provisa visaset visaset_view" value="visaset_view" /><label>查看</label>--%>

                                                <input id="Checkbox120" type="checkbox" class="middle pro provisa visaset visaset_update"  value="visaset_update" /><label>修改</label>
                           
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                          </table>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center;background: #F5F5F5;"><input id="Checkbox3" type="checkbox" class="middle order" value="order" onclick="selectAll(this)" /><label>订单管理</label></td>
                    <td>
                        <table border="0" cellpadding="0" cellspacing="0" style="width:100%;" class="formtable">
                        <tr>
                            <td style="width:15%; background:#F5F5F5; text-align:center"><input id="Checkbox35" type="checkbox" class="middle order lineorder" value="lineorder" onclick="selectAll(this)" /><label>线路订单</label></td>
                            <td>
                               <%-- <input id="Checkbox36" type="checkbox" class="middle order lineorder lineorder_view" value="lineorder_view" /><label>查看</label>--%>
                                <input id="Checkbox38" type="checkbox" class="middle order lineorder lineorder_opr" value="lineorder_opr" /><label>操作</label>
                                <input id="Checkbox39" type="checkbox" class="middle order lineorder lineorder_delete" value="lineorder_delete" /><label>删除</label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:15%; background:#F5F5F5; text-align:center"><input id="Checkbox40" type="checkbox" class="middle order visaorder" value="visaorder" onclick="selectAll(this)" /><label>签证订单</label></td>
                            <td>
                               <%-- <input id="Checkbox41" type="checkbox" class="middle order visaorder visaorder_view" value="visaorder_view" /><label>查看</label>--%>
                                <input id="Checkbox43" type="checkbox" class="middle order visaorder visaorder_opr" value="visaorder_opr" /><label>操作</label>
                                <input id="Checkbox44" type="checkbox" class="middle order visaorder visaorder_delete" value="visaorder_delete" /><label>删除</label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:15%; background:#F5F5F5; text-align:center"><input id="Checkbox106" type="checkbox" class="middle order carorder" value="carorder" onclick="selectAll(this)" /><label>租车订单</label></td>
                            <td>
                               <%-- <input id="Checkbox41" type="checkbox" class="middle order visaorder visaorder_view" value="visaorder_view" /><label>查看</label>--%>
                                <input id="Checkbox114" type="checkbox" class="middle order carorder carorder_opr" value="carorder_opr" /><label>操作</label>
                                <input id="Checkbox118" type="checkbox" class="middle order carorder carorder_delete" value="carorder_delete" /><label>删除</label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:15%; background:#F5F5F5; text-align:center"><input id="Checkbox102" type="checkbox" class="middle order customerorder" value="customerorder" onclick="selectAll(this)" /><label>定制列表</label></td>
                            <td>
                                 <input id="Checkbox41" type="checkbox" class="middle order customerorder customerorder_view" value="customerorder_view" /><label>操作</label>
                                <input id="Checkbox110" type="checkbox" class="middle order customerorder customerorder_delete" value="customerorder_delete" /><label>删除</label>
                            </td>
                        </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center;background: #F5F5F5;"><input id="Checkbox4" type="checkbox" class="middle club" value="club" onclick="selectAll(this)" /><label>会员管理</label></td>
                    <td>
                    <table border="0" cellpadding="0" cellspacing="0" style="width:100%;" class="formtable">
                        <tr>
                            <td style="width:15%; background:#F5F5F5; text-align:center"><input id="Checkbox45" type="checkbox" class="middle club clublist" value="clublist" onclick="selectAll(this)" /><label>会员列表</label></td>
                            <td>
                                <%--<input id="Checkbox46" type="checkbox" class="middle club clublist clublist_view" value="clublist_view" /><label>查看</label>--%>
                                <input id="Checkbox48" type="checkbox" class="middle club clublist clublist_update" value="clublist_update" /><label>修改</label>
                                <input id="Checkbox49" type="checkbox" class="middle club clublist clublist_delete" value="clublist_delete" /><label>删除</label>
                                <input id="Checkbox56" type="checkbox" class="middle club clublist clublist_export" value="clublist_export" /><label>导出</label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:15%; background:#F5F5F5; text-align:center"><input id="Checkbox50" type="checkbox" class="middle club sms" value="sms" onclick="selectAll(this)" /><label>短信群发</label></td>
                            <td>
                                <%--<input id="Checkbox51" type="checkbox" class="middle club sms sms_view" value="sms_view" /><label>查看</label>--%>
                                <input id="Checkbox53" type="checkbox" class="middle club sms sms_opr" value="sms_opr" /><label>操作</label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:15%; background:#F5F5F5; text-align:center"><input id="Checkbox65" type="checkbox" class="middle club email" value="email" onclick="selectAll(this)" /><label>邮件群发</label></td>
                            <td>
                               <%-- <input id="Checkbox66" type="checkbox" class="middle club email email_view" value="email_view" /><label>查看</label>--%>
                                <input id="Checkbox68" type="checkbox" class="middle club email email_opr" value="email_opr" /><label>修改</label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:15%; background:#F5F5F5; text-align:center"><input type="checkbox" class="middle club school" value="school" onclick="selectAll(this)" /><label>学校管理</label></td>
<%--                            <td>
                                <input type="checkbox" class="middle club school school_add" value="school_add" /><label>添加</label>
                                <input type="checkbox" class="middle club school school_update" value="school_update" /><label>修改</label>
                                <input type="checkbox" class="middle club school school_del" value="school_del" /><label>删除</label>
                                <input type="checkbox" class="middle club school school_import" value="school_import" /><label>导入</label>
                            </td>--%>
                        </tr>
                        <tr>
                            <td style="width:15%; background:#F5F5F5; text-align:center"><input type="checkbox" class="middle club person" value="person" onclick="selectAll(this)" /><label>推介人管理</label></td>
<%--                            <td>
                                <input type="checkbox" class="middle club person person_add" value="person_add" /><label>添加</label>
                                <input type="checkbox" class="middle club person person_update" value="person_update" /><label>修改</label>
                                <input type="checkbox" class="middle club person person_del" value="person_del" /><label>删除</label>
                                <input type="checkbox" class="middle club person person_import" value="person_import" /><label>导入</label>
                            </td>--%>
                        </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center;background: #F5F5F5;"><input id="Checkbox5" type="checkbox" class="middle common" value="common" onclick="selectAll(this)" /><label>通用模块</label></td>
                    <td>
                    <table border="0" cellpadding="0" cellspacing="0" style="width:100%;" class="formtable">
                        <tr>
                            <td style="width:15%; background:#F5F5F5; text-align:center"><input id="Checkbox55" type="checkbox" class="middle common article" value="article" onclick="selectAll(this)" /><label>内容分类</label></td>
                            <td>
                                <%--<input id="Checkbox56" type="checkbox" class="middle common article article_view" value="article_view" /><label>查看</label>--%>
                                <input id="Checkbox57" type="checkbox" class="middle common article article_add" value="article_add" /><label>添加</label>
                                <input id="Checkbox58" type="checkbox" class="middle common article article_update" value="article_update" /><label>修改</label>
                                <input id="Checkbox59" type="checkbox" class="middle common article article_delete" value="article_delete" /><label>删除</label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:15%; background:#F5F5F5; text-align:center"><input id="Checkbox60" type="checkbox" class="middle common articlelst" value="articlelst" onclick="selectAll(this)" /><label>内容列表</label></td>
                            <td>
                                <%--<input id="Checkbox61" type="checkbox" class="middle common articlelst articlelst_view" value="articlelst_view" /><label>查看</label>--%>
                                <input id="Checkbox62" type="checkbox" class="middle common articlelst articlelst_add" value="articlelst_add" /><label>添加</label>
                                <input id="Checkbox63" type="checkbox" class="middle common articlelst articlelst_update"  value="articlelst_update" /><label>修改</label>
                                <input id="Checkbox64" type="checkbox" class="middle common articlelst articlelst_delete" value="articlelst_delete" /><label>删除</label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:15%; background:#F5F5F5; text-align:center"><input id="Checkbox70" type="checkbox" class="middle common adv" value="adv" onclick="selectAll(this)" /><label>广告列表</label></td>
                            <td>
                                <%--<input id="Checkbox71" type="checkbox" class="middle common adv adv_view" value="adv_view" /><label>查看</label>--%>
                                <input id="Checkbox72" type="checkbox" class="middle common adv adv_add" value="adv_add" /><label>添加</label>
                                <input id="Checkbox73" type="checkbox" class="middle common adv adv_update" value="adv_update" /><label>修改</label>
                                <input id="Checkbox74" type="checkbox" class="middle common adv adv_delete" value="adv_delete" /><label>删除</label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:15%; background:#F5F5F5; text-align:center"><input id="Checkbox75" type="checkbox" class="middle common linkk" value="linkk" onclick="selectAll(this)" /><label>友情链接</label></td>
                            <td>
                                <%--<input id="Checkbox76" type="checkbox" class="middle common linkk linkk_view" value="linkk_view" /><label>查看</label>--%>
                                <input id="Checkbox77" type="checkbox" class="middle common linkk linkk_add" value="linkk_add" /><label>添加</label>
                                <input id="Checkbox78" type="checkbox" class="middle common linkk linkk_update" value="linkk_update" /><label>修改</label>
                                <input id="Checkbox79" type="checkbox" class="middle common linkk linkk_delete" value="linkk_delete" /><label>删除</label>
                            </td>
                        </tr>
                        </table>
                    </td>
                </tr>
            </table>
            </td>
        </tr>
        <tr>
            <td style="text-align:right; color:#056dae;background: #F5F5F5; "></td>
            <td>
                <input id="btnSave" name="btnSave" type="button" value="确认保存" class="btn" runat="server" />
                <%--<asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="btn" />--%> &nbsp;
                <input name="重置" type="reset" class="resetbtn" value="重置" />
            </td>
        </tr>
    </table>
    </div>
    <div style="margin-top:10px;text-align:center;">
 
</div>
    <input id="hidauth" name="hidauth" type="hidden" value="" runat="server" />
    <input id="hidroleid" name="hidroleid" type="hidden" runat="server" value="" />
    </form>
</body>
</html>