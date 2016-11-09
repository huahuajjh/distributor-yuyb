<%@ Page Title="" Language="C#" MasterPageFile="~/member/Member.Master" AutoEventWireup="true" CodeBehind="MyInfo.aspx.cs" Inherits="TravelAgent.Web.member.MyInfo" %>
<%@ MasterType VirtualPath="~/member/Member.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="/My97DatePicker/WdatePicker.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

                                <div class="info_tob">
                                        <div class="info_tob_top">
                                                <ul>
                                                        <li id="new1" onclick="setTab('new', 1, 2);" class="hover"><a href="#">基本信息</a></li>
                                                </ul>
                                        </div>
                                        <div class="info_tob_mid">
                                                <div id="aon_new_1" class="hover">
                                                        <form id="formUserInfo" method="post" action="/dataDeal/ChangeUserInfo.aspx">
                                                                <ul class="my_info">
                                                                        <li><span>用户名：</span><asp:Literal ID="ltMemberName" runat="server"></asp:Literal>可作为登录名使用 <a href="/member/UpdateMemberName.aspx" title="修改">修改</a></li>
                                                                        <li><span><em>*</em>姓名：</span>     <input class="yz_input" value="<%=club.trueName %>" id="realName" name="realname" type="text"><p class="prompt_write" id="realNameTip"></p></li>
                                                                        <li><span><em>*</em>性别：</span><%=ShowSexChecked()%></li>
                                                                                                <li><span><em>*</em>生日：</span><input class="yz_input" id="birthday" name="birthday" value="<%=club.clubBirthday %>" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" type="text"><p class="prompt_write" id="birthdayTip"></p></li>
                                                                                                </ul>
                                                                                                
                                                                                                <p class="wish"><button id="personalSubmit" type="submit">保存</button></p>
                                                                                                </form>
                                                                                                </div>                                                                                                
                                                                                                </div>
                                                                                                </div>        
                                                                                                
</asp:Content>
