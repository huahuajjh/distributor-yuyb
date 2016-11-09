<%@ Page Title="" Language="C#" MasterPageFile="~/member/Member.Master" AutoEventWireup="true" CodeBehind="GuestInfo.aspx.cs" Inherits="TravelAgent.Web.member.GuestInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

                                <div class="info_tob">
                                        <div class="info_tob_top">
                                                <ul>
                                                        <li id="new1" onclick="setTab('new', 1, 2);" class="hover"><a href="#">国内（<span>0</span>）</a></li>
                                                        <li id="new2" onclick="setTab('new', 2, 2);"><a href="#">出境（<span>0</span>）</a></li>
                                                </ul>
                                        </div>
                                        <div class="info_tob_mid">
                                                <div id="aon_new_1" class="hover">
                                                        <div class="add_user"><a href="#" class="J_addTourist">新增游客信息</a><em>*</em>最多增加12条国内常用游客信息</div>

                                                        <div class="user_box">
                                                                                                                        </div>

                                                </div>
                                                <div id="aon_new_2" style="display:none">
                                                        <div class="add_user"><a href="#" class="J_OutTourist">新增游客信息</a><em>*</em>最多增加12条出境常用游客信息</div>
                                                        <div class="user_box">
                                                                                                                        </div>
                                                </div>
                                        </div>
                                </div>        
                        
</asp:Content>
