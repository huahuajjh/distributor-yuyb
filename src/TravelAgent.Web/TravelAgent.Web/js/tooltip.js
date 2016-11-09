/*
 * 鼠标提示
 * By jsonchou Version 1.0
 * 使用方法：
 * $(function(){ 
 *   $("#HoverElementID").ToolTip({ 
 *            xOffset: 15,              //左偏移量
 *            yOffset: 15,              //上偏移量
 *            defaultHtml: null,      //默认html节点
 *            speed: 300,             //显示速度
 *            trigger: 'hover',       //触发事件hover/click
 *            mousemove: false,   //是否触发mousemove事件
 *            arrow: false,            //是否显示箭头 bLeft,bRight
 *            popWinID: "uzTooltip"   //默认弹出的popWinID,避免冲突
 *   }); 
 *  }) 
 */

;
(function($) {
        $.fn.extend({"ToolTip": function(options) {

                        options = $.extend({
                                xOffset: 15, //左偏移量
                                yOffset: 15, //上偏移量
                                defaultHtml: null, //默认html节点
                                speed: 300, //显示速度
                                trigger: 'hover', //触发事件hover/click
                                mousemove: false, //是否触发mousemove事件
                                arrow: false, //是否显示箭头 bLeft,bRight
                                popWinID: "khTooltip"   //默认弹出的popWinID,避免冲突
                        }, options || {});

                        var o = this;
                        var _w = $(window).width(); //窗体宽度
                        var oHTML;



                        //隐藏tip层
                        $(document).click(function(e) {
                                var tg = $(e.target);
                                if (!tg.is(options.popWinID + "," + options.popWinID + " *")) {
                                        $(options.popWinID).remove();
                                }
                        });

                        //单元事件
                        var _tp = function(element) {
                                var _o = element;
                                var oT = _o.attr('tip'); //title标题
                                var oP = _o.attr('pic'); //pic图片src
                                var oH = _o.find(':hidden').eq(0).html(); //hide查找内部display:none的html节点
                                oP = (oP == null) ? null : "<img src='" + oP + "' />";

                                //Hover函数
                                if (options.trigger == 'hover') {

                                        _o.bind('mouseover', function(e) {
                                                _oShowTarget(e);
                                        }).bind('mouseout', function(e) {
                                                $(options.popWinID).remove();
                                        })

                                        if (options.mousemove) {
                                                _o.bind('mousemove', function(e) {
                                                        _oShowTarget(e);
                                                });
                                        }

                                }
                                //Click事件
                                else {
                                        _o.bind('click', function(e) {
                                                _oShowTarget(e);
                                                return false;
                                        });
                                }

                                //显示tip层
                                var _oShowTarget = function(e) {
                                        oHTML = options.defaultHtml || oT || oP || oH; //defaultHtml>tip>pic>hide
                                        $(options.popWinID).remove();
                                        $("body").append("<div id='" + options.popWinID.replace('#', '') + "'>" + oHTML + "<b></b></div>");
                                        var oTooltip = $(options.popWinID);
                                        if (e.pageX < _w / 2) {
                                                oTooltip.css({"left": (e.pageX + options.yOffset) + "px", "right": "auto"}).find('b').addClass('bLeft');
                                        } else {
                                                oTooltip.css({"right": (_w - e.pageX + options.yOffset) + "px", "left": "auto"}).find('b').addClass('bRight');
                                        }
                                        oTooltip.find('b').css({"display": options.arrow ? "block" : "none"}); //是否显示箭头
                                        oTooltip.css({"top": (e.pageY - options.xOffset) + "px"}).fadeIn(options.speed);
                                }
                        }

                        //编历tip
                        return o.each(function(k, v) {
                                _tp($(this));
                        });

                }

        });

})(jQuery);

