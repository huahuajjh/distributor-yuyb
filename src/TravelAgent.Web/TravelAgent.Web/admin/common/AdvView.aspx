<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdvView.aspx.cs" Inherits="TravelAgent.Web.admin.common.AdvView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript">
        $(function() {
            $("#btnCopy").bind("click", function() {
                window.clipboardData.setData("Text", $("#txtCopyUrl").val());
                alert("已将代码复制至剪切板，请将其贴粘到指定位置即可。");
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="0" cellspacing="0" style="width:100%;" class="formtable">
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; width:10%;">调用说明：</td>
                <td>
                    <div style="color:#060;">
                          1、暂停、过期的广告不会在网站上显示；<br />
                          2、请确保该站点下的广告所需的/images/Player.swf（FLV插放器插件）、/images/Player.swf（幻灯片插件）的存在；<br />
                          3、除广告类型为幻灯片、视频、代码外，如该广告位下存在多条广告时，均以&ltul&gt;&ltli&gt;...&lt/li&gt;&lt/ul&gt;包括进行输出；<br />
                          4、广告以JS形式输出，可使用CSS进行控制其样式，前提是您熟悉HTML、DIV、CSS的知识；<br />
                          5、了解上述，请将复制下列的代码粘贴于对应的广告位中。
                    </div>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">复制代码：</td>
                <td>
                    <textarea id="txtCopyUrl" class="textarea" style="width:450px;height:45px;vertical-align:middle;border:solid 1px #787a7b"><script type="text/javascript" src="/Tools/Advert_js.ashx?id=<%=model.Id%>"></script></textarea>&nbsp; <input id="btnCopy" type="button" value="复制代码" class="btn" style="vertical-align:middle;" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
