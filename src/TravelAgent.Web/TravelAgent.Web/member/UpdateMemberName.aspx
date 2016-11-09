<%@ Page Title="" Language="C#" MasterPageFile="~/member/Member.Master" AutoEventWireup="true" CodeBehind="UpdateMemberName.aspx.cs" Inherits="TravelAgent.Web.member.UpdateMemberName" %>
<%@ MasterType VirtualPath="~/member/Member.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
                        $(function() {
                                $("#userName").blur(function() {
                                        var username = $(this).val();
                                        $.ajax({
                                                "url": "/dataDeal/CheckUserName.aspx?name=" + username,
                                                "success": function(data) {
                                                        if (data.indexOf("has")>-1) {
                                                                $('#userNameTip').html('用户名已经存在!');
                                                        } else {
                                                                $('#userNameTip').html('');
                                                        }
                                                }
                                        });
                                });

                        });
                        function checkSubmit() {
                                var username = $("#userName").val();
                                if (username == '' || username == null) {
                                        $('#userNameTip').html('用户名不能为空!');
                                        return false;
                                }
                                var userNametip = $('#userNameTip').html();
                                if (userNametip != '' && userNametip != null) {
                                        return false;
                                }
                                return true;
                        }
                </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

                                <div class="user_title"><b>更改用户名</b></div>
                                <div class="steps_img"><img src="/member/images/user_steps_1.gif"></div>
                                <ul class="validation_tel">
                                        <form method="post" action="/dataDeal/ChangeUserName.aspx" onsubmit="return checkSubmit();">  
                                                <li><span>用户名：</span><asp:Literal ID="ltMemberName" runat="server"></asp:Literal></li>
                                                <li><span><em>*</em>更改为：</span><input name="username" id="userName" type="text"><p class="prompt_write" id="userNameTip" style="color: red;"></p></li>
                                                <li><span>&nbsp;</span><div class="sure"><button type="submit">确定</button></div></li>       
                                        </form>
                                </ul>
                        
</asp:Content>
