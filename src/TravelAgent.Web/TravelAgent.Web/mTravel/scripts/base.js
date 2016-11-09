/**
 * Created by fu.
 * Date: 12-6-5
 * Time: 下午4:25
 */

var HBase = {
    baseUrl:'',
    assetsUrl:'',
    win:$(window),
    doc:$(document),
    winHeight:function () {
        return this.win.height();
    },
    winWidth:function () {
        return this.win.width();
    },
    scrollTop:function(){
        return this.doc.scrollTop();
    },
    /**
     *
     * @param html
     * @param ishide  true nohide
     * @param timeout
     * @param pos
     */
    tip:function (html, ishide, timeout, pos) {
        var pl = 0,
            pt = 0,
            eleWidth = 350,
            timeout = timeout || 1500,
            hide = ishide || false,
            $ele = $('<div></div>').html(html)
                .css({
                    position:'absolute',
                    padding:'5px 10px',
                    boxShadow:'0 2px 3px rgba(0,0,0,.3)',
                    zIndex:1234,borderRadius:'5px',background:'#f9edbe',color:'#333',border:'1px solid #f0c36d',width:'auto'

                }
            );
        pl = (HBase.winWidth() - eleWidth) / 2;
        pt =  HBase.scrollTop()+40 / 2;
        if(typeof pos != 'undefined'){
            if(pos.left != 'auto'){
                pl = pos.left;
            }
            if(pos.top != 'auto'){
                pt = pos.top;
            }

        }

         $ele.css({left:pl, top:pt}).appendTo('body').hide().fadeIn(function () {
            if(!hide){
                setTimeout(function () {
                    $ele.fadeOut(function () {
                        $ele.remove();
                    });
                }, timeout);

            }
        });

        return $ele;
    },
    sprintf:function () {

        var regex = /%%|%(\d+\$)?([-+\'#0 ]*)(\*\d+\$|\*|\d+)?(\.(\*\d+\$|\*|\d+))?([scboxXuidfegEG])/g;
        var a = arguments,
            i = 0,
            format = a[i++];

        // pad()
        var pad = function (str, len, chr, leftJustify) {
            if (!chr) {
                chr = ' ';
            }
            var padding = (str.length >= len) ? '' : Array(1 + len - str.length >>> 0).join(chr);
            return leftJustify ? str + padding : padding + str;
        };

        // justify()
        var justify = function (value, prefix, leftJustify, minWidth, zeroPad, customPadChar) {
            var diff = minWidth - value.length;
            if (diff > 0) {
                if (leftJustify || !zeroPad) {
                    value = pad(value, minWidth, customPadChar, leftJustify);
                } else {
                    value = value.slice(0, prefix.length) + pad('', diff, '0', true) + value.slice(prefix.length);
                }
            }
            return value;
        };

        // formatBaseX()
        var formatBaseX = function (value, base, prefix, leftJustify, minWidth, precision, zeroPad) {
            // Note: casts negative numbers to positive ones
            var number = value >>> 0;
            prefix = prefix && number && {
                '2':'0b',
                '8':'0',
                '16':'0x'
            }[base] || '';
            value = prefix + pad(number.toString(base), precision || 0, '0', false);
            return justify(value, prefix, leftJustify, minWidth, zeroPad);
        };

        // formatString()
        var formatString = function (value, leftJustify, minWidth, precision, zeroPad, customPadChar) {
            if (precision != null) {
                value = value.slice(0, precision);
            }
            return justify(value, '', leftJustify, minWidth, zeroPad, customPadChar);
        };

        // doFormat()
        var doFormat = function (substring, valueIndex, flags, minWidth, _, precision, type) {
            var number;
            var prefix;
            var method;
            var textTransform;
            var value;

            if (substring == '%%') {
                return '%';
            }

            // parse flags
            var leftJustify = false,
                positivePrefix = '',
                zeroPad = false,
                prefixBaseX = false,
                customPadChar = ' ';
            var flagsl = flags.length;
            for (var j = 0; flags && j < flagsl; j++) {
                switch (flags.charAt(j)) {
                    case ' ':
                        positivePrefix = ' ';
                        break;
                    case '+':
                        positivePrefix = '+';
                        break;
                    case '-':
                        leftJustify = true;
                        break;
                    case "'":
                        customPadChar = flags.charAt(j + 1);
                        break;
                    case '0':
                        zeroPad = true;
                        break;
                    case '#':
                        prefixBaseX = true;
                        break;
                }
            }

            // parameters may be null, undefined, empty-string or real valued
            // we want to ignore null, undefined and empty-string values
            if (!minWidth) {
                minWidth = 0;
            } else if (minWidth == '*') {
                minWidth = +a[i++];
            } else if (minWidth.charAt(0) == '*') {
                minWidth = +a[minWidth.slice(1, -1)];
            } else {
                minWidth = +minWidth;
            }

            // Note: undocumented perl feature:
            if (minWidth < 0) {
                minWidth = -minWidth;
                leftJustify = true;
            }

            if (!isFinite(minWidth)) {
                throw new Error('sprintf: (minimum-)width must be finite');
            }

            if (!precision) {
                precision = 'fFeE'.indexOf(type) > -1 ? 6 : (type == 'd') ? 0 : undefined;
            } else if (precision == '*') {
                precision = +a[i++];
            } else if (precision.charAt(0) == '*') {
                precision = +a[precision.slice(1, -1)];
            } else {
                precision = +precision;
            }

            // grab value using valueIndex if required?
            value = valueIndex ? a[valueIndex.slice(0, -1)] : a[i++];

            switch (type) {
                case 's':
                    return formatString(String(value), leftJustify, minWidth, precision, zeroPad, customPadChar);
                case 'c':
                    return formatString(String.fromCharCode(+value), leftJustify, minWidth, precision, zeroPad);
                case 'b':
                    return formatBaseX(value, 2, prefixBaseX, leftJustify, minWidth, precision, zeroPad);
                case 'o':
                    return formatBaseX(value, 8, prefixBaseX, leftJustify, minWidth, precision, zeroPad);
                case 'x':
                    return formatBaseX(value, 16, prefixBaseX, leftJustify, minWidth, precision, zeroPad);
                case 'X':
                    return formatBaseX(value, 16, prefixBaseX, leftJustify, minWidth, precision, zeroPad).toUpperCase();
                case 'u':
                    return formatBaseX(value, 10, prefixBaseX, leftJustify, minWidth, precision, zeroPad);
                case 'i':
                case 'd':
                    number = (+value) | 0;
                    prefix = number < 0 ? '-' : positivePrefix;
                    value = prefix + pad(String(Math.abs(number)), precision, '0', false);
                    return justify(value, prefix, leftJustify, minWidth, zeroPad);
                case 'e':
                case 'E':
                case 'f':
                case 'F':
                case 'g':
                case 'G':
                    number = +value;
                    prefix = number < 0 ? '-' : positivePrefix;
                    method = ['toExponential', 'toFixed', 'toPrecision']['efg'.indexOf(type.toLowerCase())];
                    textTransform = ['toString', 'toUpperCase']['eEfFgG'.indexOf(type) % 2];
                    value = prefix + Math.abs(number)[method](precision);
                    return justify(value, prefix, leftJustify, minWidth, zeroPad)[textTransform]();
                default:
                    return substring;
            }
        };

        return format.replace(regex, doFormat);
    },
    /**
     *
     * @param pid 省ID
     * @param cid 市ID
     * @param did 区ID
     */
    cascade:{
        _cascadeObj : function(){
            this.provincedata = null;
            this.citydata = null;
            this.districtdata = null;
            this.trade_areadata = null;
            this.curpid = 0;
            this.curcid = 0;
            this.curdid = 0;
            this.curaid = 0;
            this.pid = null;
            this.cid = null;
            this.did = null;
            this.aid = null;
            var CascadeObj = arguments.callee;

            CascadeObj.prototype.init = function (datasrc, pid, cid, did,aid) {
                var $pid = $('#' + pid),
                    $cid = $('#' + cid),
                    $did = $('#' + did),
                    $aid = $('#' + aid),
                    _this = this;
                this.pid = $pid;
                this.cid = $cid;
                this.did = $did;
                this.aid = $aid;
                var initdata = {};
                initdata.pid = $pid.val() || 23;
                initdata.cid = $cid.val() || 341;
                initdata.did = $did.val() || 2874;
                initdata.aid = $aid.val() || 1;
                $.getScript(datasrc, function () {
                    _this.provincedata = countryData.province;
                    _this.citydata = countryData.city;
                    _this.districtdata = countryData.district;
                    _this.trade_areadata = countryData.trade_area;
                    $pid.html(_this.getprovincehtml());

                    $cid.html(_this.getcityhtml(_this.curpid));

                    $did.html(_this.getdistricthtml(_this.curcid));
                    $aid.html(_this.gettrade_areahtml(_this.curcid));

                    $pid.bind('change',function(){_this.pclick(); });
                    $cid.bind('change',function(){_this.cclick(); });

                    setTimeout(function(){
                        $pid.val(initdata.pid);
                    },1);
                    $pid.width(65);
                    $cid.width(100);
                    $did.width(100);
                    $aid.width(150);
                    _this.pclick(initdata.pid);

                    setTimeout(function(){
                        $cid.val(initdata.cid);
                    },1);

                    _this.cclick(initdata.cid);

                    setTimeout(function(){
                        $did.val(initdata.did);
                    },1);
                    setTimeout(function(){
                        $aid.val(initdata.aid);
                    },1);

               });

            };
            CascadeObj.prototype.getprovincehtml =function(){
                var provincehtml = '',
                    provincedata = this.provincedata,
                    i = 1;

                 for (var id in provincedata){
                    if( i === 1){ this.curpid = id;}
                    i++;
                    provincehtml += HBase.sprintf('<option value="%d">%s</option>',id,provincedata[id]);
                 }
                return provincehtml;

            };
            CascadeObj.prototype.getcityhtml =function(pid){
                var cityhtml = '',
                    citydata = this.citydata,
                    i = 1;
                for(var id in citydata[pid]){
                    if( i === 1){ this.curcid = id;}
                    i++;
                    cityhtml += HBase.sprintf('<option value="%d">%s</option>',id,citydata[pid][id]);
                }
                return cityhtml;
            };
            CascadeObj.prototype.getdistricthtml =function(cid){
                var districthtml = '',
                    districtdata = this.districtdata,
                    i = 1;
                for(var id in districtdata[cid]){
                    if( i === 1){ this.curdid = id;}
                    i++;
                    districthtml += HBase.sprintf('<option value="%d">%s</option>',id,districtdata[cid][id]);
                }
                return districthtml;
            };
            CascadeObj.prototype.gettrade_areahtml =function(cid){
                var html = '',
                    trade_areadata = this.trade_areadata,
                    i = 1;
                if(trade_areadata && typeof  trade_areadata[cid] != 'undefined'){
                    for(var id in trade_areadata[cid]){
                        if( i === 1){ this.curaid = id;}
                        i++;
                        html += HBase.sprintf('<option value="%d">%s</option>',id,trade_areadata[cid][id]);
                    }

                }
                return html;
            };

            CascadeObj.prototype.pclick =function (val) {
                var v ;
                    v = typeof val === 'undefined' ? this.pid.val() : val;
                this.cid.html(this.getcityhtml(v));
                this.did.html(this.getdistricthtml(this.curcid));
                this.aid.html(this.gettrade_areahtml(this.curcid));
            };
            CascadeObj.prototype.cclick =function (val) {
                var v ;
                v = typeof val === 'undefined' ? this.cid.val() : val;
                this.did.html(this.getdistricthtml(v));
                this.aid.html(this.gettrade_areahtml(v));
            }
        },
        init:function(datasrc, pid, cid, did,aid){

            var obj =  new this._cascadeObj();
                obj.init(datasrc, pid, cid, did,aid);
        }


    },
    shake:function(id){
        var parr=new Array(15,30,15,0,-15,-30,-15,0,15,30,15,0,-15,-30,-15,0,15,30,15,0,-15,-30,-15,0),
            $ele = $('#'+id),
            shakefn = function(p){

                if(typeof p != 'undefined'){
                    $ele.css({left:p*4});
                }else{
                    return;
                }
                setTimeout(function(){
                    shakefn(parr.shift());
                },20);
            };

            shakefn(parr.shift());

    },
    browse:function(){
        var r = {};
            r.userAgent = navigator.userAgent;
            r.screen = screen.width + ' x ' + screen.height;

            return r;
    },
    sentBrowse:function(){
        var url = HBase.baseUrl + '/site/browse';
        $.get(url,HBase.browse());
    },
    sentBrowseWeb:function(){
        var url = HBase.baseUrl + '/site/browseWeb';
        $.get(url,HBase.browse());
    },
    uploadImg : function (name,tipId,fid, fn, url,beforefn, oldfid) {
        var $tipId = $('#' + tipId).html('正在上传...');
        var $oldfile = $('#'+fid);
        var $file = $('<input type="file" />'),
            newid = 'f_file_'+new Date().getTime();
        $file.attr({
            'class' :$oldfile.attr('class'),
            'name' : $oldfile.attr('name'),
            id:newid
        });
        $oldfile.hide();
        if(typeof  oldfid =='undefined'){
            oldfid = fid;
        }

        $file.bind('change',function(){
            HBase.uploadImg(name,tipId,newid,fn,url,beforefn,oldfid);
        });
        $oldfile.before($file);

        if(typeof url == 'undefined')
        {
            url = HBase.baseUrl +'/upload/thumb/name/'+ encodeURI(name);
        }
        if(typeof beforefn == 'function'){
            beforefn();
        }
        $.ajaxFileUpload({
            url:url,
            fileElementId:fid,
            dataType:'json',
            success:function (data, status) {
                setTimeout(function () {
                    if (data.err == 0) {
                        $tipId.html('<img src="' + data.src + '" height="20" /> ' +
                            '<a target="_blank" class="zoomBig" href="' + data.src + '" >点击查看</a> ');
                         $('#yt' + oldfid).val(data.src);

                        if(typeof fn =='function'){
                            fn(data);
                        }
                    }
                    else {
                        HBase.tip(data.msg);
                    }

                }, 1000);

            },
            error:function (data, status, e) {
            }
        });
        $oldfile.remove();

    },
    spliceval:function(arr,val){
        var pos = -1;
        for(var i = 0;i<arr.length;i++){
            if(arr[i] == val){
                pos = i;
                break;
            }
        }
        arr.splice(pos,1);
        return arr;
    },
    array_merge:function(arr1,arr2) {
        var arr = arr1;
        for(var i = 0;i<arr2.length;i++){

            for(var j = 0;j<arr1.length;j++){
                 if(arr1[j] == arr2[i]){
                     break;
                 }
            }
            if(typeof arr1[j] == 'undefined'){
                arr.push(arr2[i]);
            }

        }

        return arr;
    },
    addfavorite:function (sURL,sTitle)
    {
        if(typeof  sURL == undefined){
            sURL = location.href;
        }
        if(typeof  sTitle == undefined){
            sTitle = document.title;
        }

        try {
            window.external.addFavorite(sURL, sTitle);
        }
        catch (e) {
            try {
                window.sidebar.addPanel(sTitle, sURL, "");
            }
            catch (e) {
                alert("加入收藏失败，请使用Ctrl+D进行添加");
            }
        }
    },
    setHome:function ( sURL){
        if (typeof  sURL == undefined) {
            sURL = location.href;
        }
        try {
            document.body.style.behavior = 'url(#default#homepage)';
            document.body.setHomePage(sURL);

        }
        catch (e) {
        }
    },
    post:function($form,params,fn,showtip,pos){

        if(typeof showtip == 'undefined'){
            showtip = true;
        }
        if(typeof params == 'undefined'){
            params = $form.serialize();
        }
        if(showtip){
            var $tip = HBase.tip('数据提交中...',true,1500,pos);

            var timeout = true;
            setTimeout(function(){
               if(timeout){
                   $tip.html('超时.');
                   setTimeout(function(){
                       $tip.remove();
                   },1000);
               }
            },7000);
        }
        $.post($form.attr('action'),params,function(data){
            if(typeof fn == 'function'){
               fn(data);
            }
            if(showtip){
                if(data.status){
                    $tip.html('数据提交成功.');
                }else{
                    $tip.html('数据提交失败.');
                }
                setTimeout(function(){
                    $tip.remove();
                },1000);
            }


        },'json');

    },
    get:function(url,fn,showtip,pos){

        if(typeof showtip == 'undefined'){
            showtip = true;
        }
        if(showtip){
            var $tip = HBase.tip('数据提交中...',true,1500,pos);

            var timeout = true;
            setTimeout(function(){
               if(timeout){
                   $tip.html('超时.');
                   setTimeout(function(){
                       $tip.remove();
                   },1000);
               }
            },7000);
        }
        $.get(url,function(data){
            if(typeof fn == 'function'){
               fn(data);
            }
            if(showtip){
                if(data.status){
                    $tip.html('数据提交成功.');
                }else{
                    $tip.html('数据提交失败.');
                }
                setTimeout(function(){
                    $tip.remove();
                },1000);
            }


        },'json');

    },
    load:function (astr, contstr, ac, loadstr,loadw) {

        if(typeof loadstr == 'undefined'){
            loadstr = '加载中...';
        }

        var loaddata = function($cont_tit_1a,$cont_cont_1){
            $cont_tit_1a.bind('click',function (e) {
                $cont_cont_1.html(loadstr);
                $cont_tit_1a.removeClass(ac);
                $.get($(this).addClass(ac).attr('href'), function (data) {
                    $cont_cont_1.html(data);
                });
                e.preventDefault();
            }).eq(0).click();

        };
        if(typeof loadw == 'undefined'){
            var $cont_tit_1a = $(astr);
            var $cont_cont_1 = $(contstr);
            loaddata($cont_tit_1a,$cont_cont_1);
        }else{
            $(loadw).each(function(){
                var $this = $(this);
                loaddata($this.find(astr),$this.find(contstr));
            });
        }
    },

    addParam: function(key,val,url  )
    {
        if(typeof url == 'undefined' ){
            url = location.href;
        }

        var reg1 = new RegExp(key+'/[^&]*?/');
        var reg2 = new RegExp(key+'=[^&]*');
        if(url.match(reg1)){
         //   url = preg_replace('/'+key+'=[^&]*/',key+'='+val,url);
            url = url.replace(reg1,key+'/'+val+'/',url);
        }else if(url.match(reg2)){
           // url = preg_replace('/'+key+'=[^&]*/',key+'='+val,url);
            url = url.replace(reg2,key+'='+val,url);

        }else if(url.indexOf('?') === -1){
                    url+='?'+key+'='+val;

                }else{
            if(url.indexOf('=') === -1){
                url+=key+'='+val;
            }else{
                url+='&'+key+'='+val;
            }
        }


        return url;
    },
    reloadform:function(form,arr){
        var url;
        for(var i in arr)
        {
            url = this.addParam(arr[i],form[arr[i]].value,url);

        }

         location.href = url;
        return false;
    },
    /**
     *
     * @param params 例 { tab:'',hd:'',bd:'',ac:'',event:'','isclick':false}
     */
    miniTab:function (params) {
        var $tabl = $(params.tab);
        if(typeof params.event == 'undefined'){
            params.event = 'mouseover';
        }
        if(typeof params.isclick == 'undefined'){
            params.isclick = false;
        }

        $tabl.each(function () {
            var $tab = $(this);
            var $hd = $tab.find(params.hd);
            var $bd = $tab.find(params.bd);
            $hd.bind(params.event,function () {
                var $this = $(this);
                var index = $hd.index($this);
                $hd.removeClass(params.ac);
                $this.addClass(params.ac);
                $bd.hide().eq(index).show();
            }).eq(0)[params.event]();
            if(!params.isclick){
                $hd.bind('click',function(e){
                    e.preventDefault();
                })
            }
        });

    },
    setCookie: function (c_name,value,expiretimes,path) {
        if(typeof  path == 'undefined'){
            path = '/';
        }
        var exdate = new Date();
        exdate.setTime(exdate.getTime() + expiretimes);
        document.cookie = c_name + "=" + escape(value) +
            ((expiretimes == null) ? "" : ";expires=" + exdate.toGMTString()) + ';path='+path+';'
    },
    getCookie: function (c_name) {
        if (document.cookie.length > 0) {
            c_start = document.cookie.indexOf(c_name + "=");
            if (c_start != -1) {
                c_start = c_start + c_name.length + 1;
                c_end = document.cookie.indexOf(";", c_start);
                if (c_end == -1) c_end = document.cookie.length;
                return unescape(document.cookie.substring(c_start, c_end));
            }
        }
        return ""
    },
    islogin:false,
    orderPopupUrl:'',
    orderPopupDialog:'',
    orderPopupClose:function(){
        this.orderPopupDialog.close();
        HBase.setCookie('orderPopup','direct',1000 * 60 * 5);

    },
    orderPopup:function(){
        if(!this.islogin && HBase.getCookie('orderPopup') != 'direct'){
            this.orderPopupDialog = $.ZDialog({
                style:{
                    width: 750,
                    height:370
                },
                mask:{
                    enable: true
                }
            });
            this.orderPopupDialog.setTitle('登陆提示').content('<iframe frameborder="0" width="100%" height="100%" src="' +
                ''+HBase.orderPopupUrl+'?orderlink=javascript:parent.HBase.orderPopupClose()'+'"></iframe>').open();

            return false;
        }else{
            return true;
        }
    },
    in_array : function  (needle, haystack, argStrict) {
      // http://kevin.vanzonneveld.net
      // +   original by: Kevin van Zonneveld (http://kevin.vanzonneveld.net)
      // +   improved by: vlado houba
      // +   input by: Billy
      // +   bugfixed by: Brett Zamir (http://brett-zamir.me)
      // *     example 1: in_array('van', ['Kevin', 'van', 'Zonneveld']);
      // *     returns 1: true
      // *     example 2: in_array('vlado', {0: 'Kevin', vlado: 'van', 1: 'Zonneveld'});
      // *     returns 2: false
      // *     example 3: in_array(1, ['1', '2', '3']);
      // *     returns 3: true
      // *     example 3: in_array(1, ['1', '2', '3'], false);
      // *     returns 3: true
      // *     example 4: in_array(1, ['1', '2', '3'], true);
      // *     returns 4: false
      var key = '',
        strict = !! argStrict;

      if (strict) {
        for (key in haystack) {
          if (haystack[key] === needle) {
            return true;
          }
        }
      } else {
        for (key in haystack) {
          if (haystack[key] == needle) {
            return true;
          }
        }
      }

      return false;
    },
    del_array:function(needle, haystack){
        for (var i = 0; i < haystack.length; i++) {
            if(haystack[i] == needle){
                haystack.splice(i,1);
            }
        }
        return haystack;
    },
    flow:function(){
        $.post('/site/flow',{surl:document.referrer,pageurl:location.href});
    },
    fixed:function($ele,postr,zIndex){
        var pos = $ele.offset();
        var $win = $(window);
        if(typeof postr == 'undefined'){
            postr = 'static';
        }
        if(typeof zIndex == 'undefined'){
            zIndex = 123;
        }
        window.onscroll = function(){
            if($win.scrollTop() > pos.top){
                $ele.css({position:'fixed',top:0,zIndex:zIndex});
            }else{
                $ele.css({position:'static'});

            }
        }
    }



};
jQuery(function($){
    HBase.sentBrowseWeb();

});