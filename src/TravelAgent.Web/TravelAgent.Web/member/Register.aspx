<%@ Page Title="" Language="C#" MasterPageFile="~/Other.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TravelAgent.Web.member.Register" %>
<%@ MasterType VirtualPath="~/Other.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" type="text/css" href="/css/style.css" />
 <link rel="stylesheet" type="text/css" href="/member/css/user.css" />
 <script src="/js/jquery-1.7.2.min.js" type="text/javascript"></script>
 <script src="/member/js/formValidator-4.1.1.js" type="text/javascript"></script>
 <script src="/member/js/formValidatorRegex.js" type="text/javascript"></script>
 <script src="/member/js/checkPwdLevel.js" type="text/javascript"></script>
 <script src="/member/js/theme.js" type="text/javascript"></script>
 <script src="/member/js/reg2.js" type="text/javascript"></script>
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="content">
                        <div class="register">
                                <div class="register_title"><b>会员注册</b><span>当前为<em id="current_id">手机注册</em>，您也可以使用<a href="" id="email_register">邮箱注册</a><a href="" style="display:none;"id="phone_register" >手机注册</a></span>

                                </div>
                                <form name="register" id="register" class="fm" method="post" action="/member/Register.aspx">
                                        <ul class="validation_tel">
                                                <input id="type" name="type" type="hidden" value="mobile" />
                                                <li id="phone_input"><span>手机号：</span><input name="mobile" type="text" id="mobile"/><p class="prompt_write" id="mobileTip"></p></li>
                                                <li style=" display:none;" id="email_input"><span>邮箱账号：</span><input name="email" type="text" id="email"/><p class="prompt_write" id="emailTip"></p></li>
                                                <li><span>设置密码：</span><input name="password" id="txtPwd" type="password" /><p class="prompt_write" id="txtPwdTip"></p></li>
                                                <li><span>确认密码：</span><input name="repassword" type="password" id="txtRePwd"/><p class="prompt_write" id="txtRePwdTip"></p></li>
                                                <li class="validation_code"><span>校验码：</span><input id="verify" name="verify" type="text"/><img src="/RandomImage.aspx" style="cursor: pointer; margin-right:5px;" title="看不清，换一张?" alt="看不清，换一张" width="80px" height="25" id="img1" border="0" onclick='javascript:this.src = "/RandomImage.aspx?t=" + new Date().toUTCString();' /><p class="prompt_write" id="verifyTip">请输入正确的验证码</p></li>
                                        </ul>
                                        <div class="register_button"><input id="btnSubmit"  type="submit" value="同意服务条款，立即注册" /></div>

                                        <div class="service_terms"><input checked="checked" type="checkbox"  id="checkXieYi"/><a href="#" class="aYieYi">《<%=Master.webinfo.WebName %>会员服务条款》 ▼</a></div>
                                </form>
                                
                        </div>
                        <div id="xieyi" class="xieyi">
                                <%=strMemberAgreement %>       
                        </div>
                </div>
</asp:Content>
