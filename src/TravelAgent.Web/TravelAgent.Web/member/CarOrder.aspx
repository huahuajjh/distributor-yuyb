<%@ Page Title="" Language="C#" MasterPageFile="~/member/Member.Master" AutoEventWireup="true" CodeBehind="CarOrder.aspx.cs" Inherits="TravelAgent.Web.member.CarOrder" %>
<%@ MasterType VirtualPath="~/member/Member.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="info_tob">
                                        <div class="info_tob_top">
                                                <ul>
                                                        <li class="hover"><a href="javascript:;">租车订单</a></li>
                                                </ul>
                                        </div>
                                        <div class="info_tob_mid">
                                                <div class="hover" id="aon_new_1">
                                                        <div class="order">
                                                                <table width="770" border="0" cellspacing="0" cellpadding="0">
                                                                         <tbody>
                                                                         <tr>
                                                                         <th width="150">订单编号</th>
                                                                         <th width="180" class="thleft">产品信息</th>
                                                                         <th width="100">取车时间</th>
                                                                         <th width="80">订单金额</th>
                                                                         <th width="60">订单状态</th>
                                                                         <th width="100">下单时间</th>
                                                                         <th width="100">操作</th>
                                                                         </tr>
                                                                         <%=ShowOrder()%>                       
                                                                         </tbody>
                                                                   </table>
                                                                
                                                        </div>
                                                </div>
                                        </div>
                                </div>
</asp:Content>
