<%@ Page Title="" Language="C#" MasterPageFile="~/Other.Master" AutoEventWireup="true" CodeBehind="GetPasswordByPhone.aspx.cs" Inherits="TravelAgent.Web.member.GetPasswordByPhone" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" type="text/css" href="/css/style.css" />
<link rel="stylesheet" type="text/css" href="/member/css/user.css" />
<script type="text/javascript" src="/js/jquery-1.7.2.min.js"></script>
<script type="text/javascript">
    $(function() {
        $("#btnSubmit").click(function() {
            if ($.trim($("#txtValidator").val()) == "") {
                $("#txtValidatorTip").html("<font style='color:red'>请输入短信验证码</font>");
                return false;
            }
            $("#form1").submit();
        })
    })
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="content">
<div class="password_title"><b>找回密码</b></div>
	<ul class="password_steps password_steps_2">
      <li>选择找回密码方式</li>
      <li class="cur">输入注册手机</li>
      <li>重新设置密码</li>
    </ul>
    <ul class="change_password">
            <form id="form1" action="/member/SettingPwd.aspx" method="post" name="form1">
            <li><span><em>*</em>您注册时用的手机号码：</span>  <input id="mobile" type="text" name="mobile" value="" /><p class="prompt_write" id="mobileTip"></p></li>
            <li class="password_code"><span>&nbsp;</span> <input type="text" maxlength="4" id="verify" name="verify" />  <img src="/RandomImage.aspx" style="cursor: pointer; margin-right:5px;" title="看不清，换一张?" alt="看不清，换一张" width="80px" height="25" id="img1" border="0" onclick='javascript:this.src = "/RandomImage.aspx?t=" + new Date().toUTCString();' /><p class="prompt_write" id="verifyTip"></p></li>
            <li><span>&nbsp;</span><a href="#" class="distortion" id="codeSend" >发送手机验证码</a> 
            </li>
            <li style="display:block;" >
              <p class="sended" id="sended" style="margin: auto;display: none;"><em>验证码已成功发送到您的手机</em>,您如果没有收到验证码短信<i id="showTime"></i><a class="distortion" id="reSend" style="float: right;">重新发送验证码</a></p>
              <p style="color:Red;display:none;" id="sendedThree" >您今天申请发送验证码的次数已经满3次，请联系客服找回或者次日再来申请发送。</p>
            </li>
            <li><span>输入短信验证码：</span><input id="txtValidator" name="txtValidator" type="text" maxlength="4" /><p class="prompt_write" id="txtValidatorTip"></p></li>
      <li><span>&nbsp;</span><div class="sure"><button type="button" id="btnSubmit">提交</button></div></li>
      </form>
            <p>温馨提示：请确保您的手机在身边，以便及时收取我们的验证码。验证码在30分钟内有效。</p>            
    </ul>
</div>
  <script src="/member/js/formValidator-4.1.1.js" type="text/javascript"></script>
<script src="/member/js/theme.js" type="text/javascript"></script>
<script src="/member/js/formValidatorRegex.js" type="text/javascript"></script> 
<script src="/member/js/findPwd.js" type="text/javascript"></script>
</asp:Content>
