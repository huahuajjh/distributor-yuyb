<%@ Page Title="" Language="C#" MasterPageFile="~/member/Member.Master" AutoEventWireup="true" CodeBehind="MyPoints.aspx.cs" Inherits="TravelAgent.Web.member.MyPoints" %>
<%@ MasterType VirtualPath="~/member/Member.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="credits_box"><span>当前可用积分：<b><%=club.currentPoints %> </b></span><span>累计积分：<b><%=totalgetPoints%> </b></span><span>已使用：<b><%=totalusePoints%> </b></span><!--<span>已过期：<em class="f00">0</em></span><span>即将过期：<em class="orange">0</em></span>-->
    <span class="showmore"><a href="#">什么是积分 积分又有何用？</a></span>
    <div style="display: none;" class="showmore_box"><span>积分实际上是抵用券，1个积分相当于1元抵用券。在网站产品订单中，您可以用积分来抵用产品限定的金额。比如您有60个积分且预订线路允许抵用20元/人，则每个出行人可以抵用20元现金。 </span></div>
     </div>
    <div class="info_tob">
    <div class="info_tob_top">
    <b><em></em>积分交易记录</b>
      <%--<ul>
        <li id="new1"><a href="/user/credits/type/1">收入</a></li>
        <li id="new2"><a href="/user/credits/type/2">支出</a></li>
        <li id="new3" class="hover"><a href="/user/credits/">全部</a></li>
      </ul>--%>
     </div>
    <div class="info_tob_mid">
            <div id="aon_new_1" class="hover">
           	  <div class="order">
                <table cellpadding="0" cellspacing="0" border="0" width="770" style="text-align:center">
                 <tbody>
                 <tr>
                     <th width="150">时间</th>
                     <th width="80">积分</th>
                     <th width="120">交易类型</th>
                     <th width="190">交易内容</th>
                 </tr>
                 <%=BindPointsList() %>                
                 </tbody>
                 </table>
               <%=BindPage()%>
            </div>
          </div>
      </div>
    </div>
  <script type="text/javascript">
    function setTab(name,cursel,n){
	    for(i=1;i<=n;i++){
		    var menu=document.getElementById(name+i);
		    var con=document.getElementById("aon_"+name+"_"+i);
		    menu.className=i==cursel?"hover":"";
		    con.style.display=i==cursel?"block":"none";
	    }
    }
    $(function() {
			var $catray = $('.showmore_box');
			$catray.hide();
			var $toggbtn = $('span.showmore > a');

			$toggbtn.toggle(function() {
				var $this = $(this), 
					el = $this.parent().next();
				el.show();
				$this.find('span').text(" ");
				return false;
			}, function() {
				var $this = $(this), 
					el = $this.parent().next();
				el.hide();
				$this.find('span').text(" ");
				return false;
			});
		})
</script>
</asp:Content>
