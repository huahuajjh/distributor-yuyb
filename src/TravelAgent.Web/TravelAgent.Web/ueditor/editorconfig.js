var editor = new Array();
var editorOptions = null;
//编辑器配置
function editorConfig() {
    if (!editorOptions) {
        editorOptions = {
            focus: false,
            wordCount: false, //关闭字数统计
            elementPathEnabled: false,//关闭路径显示
            toolbars: [
                ['fullscreen', 'source', '|', 'undo', 'redo', '|',
                'bold', 'italic', 'underline', 'fontborder', 'strikethrough', 'superscript', 'subscript', 'removeformat', 'formatmatch', 'autotypeset', 'blockquote', 'pasteplain', '|', 'forecolor', 'backcolor', 'insertorderedlist', 'insertunorderedlist', 'selectall', 'cleardoc', '|',
                'rowspacingtop', 'rowspacingbottom', 'lineheight', '|',
                'customstyle', 'paragraph', 'fontfamily', 'fontsize', '|',
                'directionalityltr', 'directionalityrtl', 'indent', '|',
                'justifyleft', 'justifycenter', 'justifyright', 'justifyjustify', '|', 'touppercase', 'tolowercase', '|',
                'link', 'unlink', 'anchor', '|', 'imagenone', 'imageleft', 'imageright', 'imagecenter', '|',
                'insertimage', 'emotion', 'scrawl', 'insertvideo', 'music', 'attachment', 'map', 'gmap', 'pagebreak','background', '|',
                'horizontal', 'date', 'time', 'spechars', 'snapscreen', 'wordimage', '|',
                'inserttable', 'deletetable', 'insertparagraphbeforetable', 'insertrow', 'deleterow', 'insertcol', 'deletecol', 'mergecells', 'mergeright', 'mergedown', 'splittocells', 'splittorows', 'splittocols', '|',
                , 'help']
            ]
        };
    }
    return editorOptions;
}
//添加编辑器
function CreateEditor(id, tool) {
    var config = editorConfig();
    if (!tool) tool = 'full';
    if (tool == 'simple') {
        config.toolbars[0] = ['source', '|', 'undo', 'redo', '|',
            'bold', 'italic', 'underline', 'fontborder', 'strikethrough', 'superscript', 'subscript', 'removeformat', 'formatmatch', 'autotypeset', 'blockquote', 'pasteplain', '|', 'forecolor', 'backcolor', 'insertorderedlist', 'insertunorderedlist', 'selectall', 'cleardoc', '|',
            'rowspacingtop', 'rowspacingbottom', 'lineheight'];
    } else if (tool == 'wx') {
        config.toolbars[0] = ['source', '|', 'undo', 'redo', '|',
            'bold', 'italic', 'underline', 'fontborder', 'strikethrough', 'superscript', 'subscript', 'removeformat', 'formatmatch', 'autotypeset', 'blockquote', 'pasteplain', '|', 'forecolor', 'backcolor', 'insertorderedlist', 'insertunorderedlist', 'selectall', 'cleardoc', '|',
            'rowspacingtop', 'rowspacingbottom', 'lineheight', '|', 'insertimage'];
    } else if (tool == 'full') {
        config.toolbars[0] = $.map(config.toolbars[0], function(n) {
            return n != 'pagebreak' ? n : null;
        });
    } else if (tool == "empty") {
        config.toolbars[0] = [];
    }
    editor[id] = UE.getEditor(id, config);
}
//清除编辑器
function ClearEditor(id) {
    UE.delEditor(id);
}