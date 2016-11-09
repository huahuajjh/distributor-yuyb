/**
 * imglazyload v1.1 for jQuery
 * Author : chenmnkken@gmail.com
 * Url : http://stylechen.com/imglazyload2.html
 * Date : 2012-03-29
 */

(function ($) {

    $.fn.imglazyload = function (options) {
        var opt = $.extend({}, $.fn.imglazyload.settings, options);
        new imglazyload(opt, this).init();
        return this;
    };
    var imglazyload = function (options, obj) {
        this.o = options;
        this.objs = obj;
        this.imgs = [];
        this.lazyexec = true;
    };
    imglazyload.prototype = {
        init:function(){
            var _this = this;
            this.objs.each(function(i){
                _this.imgs.push(_this.objs.eq(i));
            });
            $(window).scroll(function(){
                _this.lazyexecfn();
            });
            $('body').mouseover(function(){
                _this.lazyexecfn();

            });
            _this.lazyexecfn();


        },
        lazyexecfn:function(){
            var _this = this;
            if(this.imgs.length>0){
                _this.loadimg();

            }

        },
        loadimg:function(){
            var _this = this;
            var scrolltop = $(window).scrollTop();
            var winHeight = $(window).height();
            var showarea = scrolltop + winHeight;
            $.each(this.imgs,function(index,value){
                var $curimg = _this.imgs[index];

                if(typeof $curimg != 'undefined' && typeof $curimg.attr(_this.o.attr) != 'undefined'){
                    if ($curimg.offset().top < showarea) {
                        $curimg.attr('src', $curimg.attr(_this.o.attr));
                        _this.imgs.splice(index,1);
                    }
                }

            });

        }


    };


    $.fn.imglazyload.settings = {
        attr:'data-original'

    };


//
})(jQuery);
