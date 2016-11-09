<%@ Page Title="" Language="C#" MasterPageFile="~/member/Member.Master" AutoEventWireup="true" CodeBehind="UpdatePassword.aspx.cs" Inherits="TravelAgent.Web.member.UpdatePassword" %>
<%@ MasterType VirtualPath="~/member/Member.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

                                <div class="user_title"><b>修改密码</b></div>
                                
                                <form action="/dataDeal/PassWord.aspx" id="changepassword" method="post" class="fm">
                                        <ul class="validation_tel">
                                                 <p>温馨提示：修改登录密码后，原密码将不能用来登录。</p>   
                                                <li><span><em>*</em>请输入原密码：</span><input name="txtOldPassword" class="yz_input" id="txtOldPassword" type="password"><p style="margin: 0px; padding: 0px; background: none repeat scroll 0% 0% transparent; display: none;" class="prompt_write" id="txtOldPasswordTip"></p></li>
                                                <li><span><em>*</em>请输入新密码：</span><input name="txtPassword" onblur="checkPwdLevel()" onkeyup="checkPwdLevel()" id="txtPassword" type="password"><p style="margin: 0px; padding: 0px; background: none repeat scroll 0% 0% transparent; display: none;" class="prompt_write" id="txtPasswordTip"></p></li>
                                                <li class="password_strong"><span>&nbsp;</span><div class="power_strong" id="pwdLevel"><i class="on1">弱</i><i class="on2">中</i><i class="on3">强</i></div></li>
                                                <li><span><em>*</em>确认新密码：</span><input name="txtRePassword" id="txtRePassword" type="password"><p style="margin: 0px; padding: 0px; background: none repeat scroll 0% 0% transparent; display: none;" class="prompt_write" id="txtRePasswordTip"></p></li>
                                                <li><span>&nbsp;</span><div class="sure"> <button type="submit">确定</button></div></li>
                                        </ul>
                                </form>
                        <script src="/member/js/formValidator-4.1.1.js" type="text/javascript"></script>
                <script src="/member/js/theme.js" type="text/javascript"></script>
                <script src="/member/js/formValidatorRegex.js" type="text/javascript"></script> 
                <script src="/member/js/password.js" type="text/javascript"></script>
</asp:Content>
