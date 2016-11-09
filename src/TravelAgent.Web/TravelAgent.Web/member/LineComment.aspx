<%@ Page Title="" Language="C#" MasterPageFile="~/member/Member.Master" AutoEventWireup="true" CodeBehind="LineComment.aspx.cs" Inherits="TravelAgent.Web.member.LineComment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

                                <div class="info_tob">
                                        <div class="info_tob_top">
                                                <ul>
                                                        <li id="new1" class="hover"><a href="/user/comment">待点评(0)</a></li>
                                                        <li id="new2"><a href="/user/comment/type/1">已点评(0)</a></li>
                                                </ul>
                                        </div>
                                        <div class="info_tob_mid">
                                                <div id="aon_new_1" class="hover">
                                                        <div class="order">
                                                                <table cellpadding="0" cellspacing="0" border="0" width="770">
                                                                        <tbody><tr><th width="120">订单编号</th><th class="thleft" width="310">产品信息</th><th width="80">订单金额</th><th width="100">下单时间</th><th width="80">点评奖励</th><th width="80">操作</th></tr>
                                                                                                                                                        <tr><td colspan="4">成功发表体验点评后，会有积分赠送，赶快行动吧。 您有0条记录</td>  </tr>
                                                                </tbody></table>
                                                                <div class="pages"></div>
                                                        </div>
                                                </div>

                                        </div>
                                </div>
                        
</asp:Content>
