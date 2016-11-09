<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forupload.aspx.cs" Inherits="TravelAgent.Web.guide.forupload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script src="../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="uploadify/jquery.uploadify.min.js" type="text/javascript"></script>
    <link href="uploadify/uploadify.css" rel="stylesheet" type="text/css" />
   
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <div id="file_upload"></div>
    </div>
    <div id="uploadfileQueue"></div>
    </form>
</body>
</html>
<script>
    $(function () {
        var url = "upload.ashx" + '<%=para %>';
        $("#file_upload").uploadify({
            //开启调试  
            'debug': false,
            //是否自动上传  
            'auto': true,
            'buttonText': '选择照片',
            //flash  
            'swf': "uploadify/uploadify.swf",
            //文件选择后的容器ID  
            'queueID': 'uploadfileQueue',
            'uploader': url,
            'width': '75',
            'height': '24',
            'multi': false,
            'fileTypeDesc': '支持的格式：',
            'fileTypeExts': '*.jpg;*.jpge;*.gif;*.png',
            'fileSizeLimit': '10MB',
            'removeTimeout': 1,

            //返回一个错误，选择文件的时候触发  
            'onSelectError': function (file, errorCode, errorMsg) {
                switch (errorCode) {
                    case -100:
                        alert("上传的文件数量已经超出系统限制的" + $('#file_upload').uploadify('settings', 'queueSizeLimit') + "个文件！");
                        break;
                    case -110:
                        alert("文件 [" + file.name + "] 大小超出系统限制的" + $('#file_upload').uploadify('settings', 'fileSizeLimit') + "大小！");
                        break;
                    case -120:
                        alert("文件 [" + file.name + "] 大小异常！");
                        break;
                    case -130:
                        alert("文件 [" + file.name + "] 类型不正确！");
                        break;
                }
            },
            //检测FLASH失败调用  
            'onFallback': function () {
                alert("您未安装FLASH控件，无法上传图片！请安装FLASH控件后再试。");
            },
            //上传到服务器，服务器返回相应信息到data里  
            'onUploadSuccess': function (file, data, response) {
                window.parent.location.reload();
            }
        });
    });

    function doUplaod() {
        $('#file_upload').uploadify('upload', '*');
    }

    function closeLoad() {
        $('#file_upload').uploadify('cancel', '*');
    }  
  
    </script>
