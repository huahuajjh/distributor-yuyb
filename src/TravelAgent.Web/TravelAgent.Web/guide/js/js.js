/* Copyright (c) 2006 Brandon Aaron (http://brandonaaron.net)
 * Dual licensed under the MIT (http://www.opensource.org/licenses/mit-license.php) 
 * and GPL (http://www.opensource.org/licenses/gpl-license.php) licenses.
 *
 * $LastChangedDate: 2007-07-22 01:45:56 +0200 (Son, 22 Jul 2007) $
 * $Rev: 2447 $
 *
 * Version 2.1.1
 */
(function($){$.fn.bgIframe=$.fn.bgiframe=function(s){if($.browser.msie&&/6.0/.test(navigator.userAgent)){s=$.extend({top:'auto',left:'auto',width:'auto',height:'auto',opacity:true,src:'javascript:false;'},s||{});var prop=function(n){return n&&n.constructor==Number?n+'px':n;},html='<iframe class="bgiframe"frameborder="0"tabindex="-1"src="'+s.src+'"'+'style="display:block;position:absolute;z-index:-1;'+(s.opacity!==false?'filter:Alpha(Opacity=\'0\');':'')+'top:'+(s.top=='auto'?'expression(((parseInt(this.parentNode.currentStyle.borderTopWidth)||0)*-1)+\'px\')':prop(s.top))+';'+'left:'+(s.left=='auto'?'expression(((parseInt(this.parentNode.currentStyle.borderLeftWidth)||0)*-1)+\'px\')':prop(s.left))+';'+'width:'+(s.width=='auto'?'expression(this.parentNode.offsetWidth+\'px\')':prop(s.width))+';'+'height:'+(s.height=='auto'?'expression(this.parentNode.offsetHeight+\'px\')':prop(s.height))+';'+'"/>';return this.each(function(){if($('> iframe.bgiframe',this).length==0)this.insertBefore(document.createElement(html),this.firstChild);});}return this;};})(jQuery);
/**
 * weebox.js
 *
 * weebox js
 *
 * @category   javascript
 * @package    jquery
 * @author     Jack <xiejinci@gmail.com>
 * @copyright  Copyright (c) 2006-2008 9wee Com. (http://www.9wee.com)
 * @license    http://www.9wee.com/license/
 * @version    
 */ 
(function($) {
	/*if(typeof($.fn.bgIframe) == 'undefined') {
		$.ajax({
			type: "GET",
		  	url: '/js/jquery/bgiframe.js',//路径不好处理
		  	success: function(js){eval(js);},
		  	async: false				  	
		});
	}*/
	var weebox = function(content, options) {
		var self = this;
		this._dragging = false;
		this._content = content;
		this._options = options;
		this.dh = null;
		this.mh = null;
		this.dt = null;
		this.dc = null;
		this.bo = null;
		this.bc = null;
		this.selector = null;	
		this.ajaxurl = null;
		this.options = null;
		this.defaults = {
			boxid: null,
			boxclass: null,
			type: 'dialog',
			title: '',
			width: 0,
			height: 0,
			timeout: 0, 
			draggable: true,
			modal: true,
			focus: null,
			position: 'center',
			overlay: 50,
			showTitle: true,
			showButton: true,
			showCancel: true, 
			showOk: true,
			okBtnName: '确定',
			cancelBtnName: '取消',
			contentType: 'text',
			contentChange: false,
			clickClose: false,
			zIndex: 999,
			animate: false,
			trigger: null,
			onclose: null,
			onopen: null,
			onok: null		
		};
		this.types = new Array(
			"dialog", 
			"error", 
			"warning", 
			"success", 
			"prompt",
			"box"
		);
		this.titles = {
			"error": 	"!! Error !!",
			"warning": 	"Warning!",
			"success": 	"Success",
			"prompt": 	"Please Choose",
			"dialog": 	"Dialog",
			"box":		""
		};
		
		this.initOptions = function() {	
			if (typeof(self._options) == "undefined") {
				self._options = {};
			}
			if (typeof(self._options.type) == "undefined") {
				self._options.type = 'dialog';
			}
			if(!$.inArray(self._options.type, self.types)) {
				self._options.type = self.types[0];
			}
			if (typeof(self._options.boxclass) == "undefined") {
				self._options.boxclass = self._options.type+"box";
			}
			if (typeof(self._options.title) == "undefined") {
				self._options.title = self.titles[self._options.type];
			}
			if (content.substr(0, 1) == "#") {
				self._options.contentType = 'selector';
				self.selector = content; 
			}
			self.options = $.extend({}, self.defaults, self._options);
		};
		
		this.initBox = function() {
			var html = '';	
			if (self.options.type == 'wee') {
				html =  '<div class="weedialog">' +
				'	<div class="dialog-top">' +
				'		<div class="dialog-tl"></div>' +
				'		<div class="dialog-tc"></div>' +
				'		<div class="dialog-tr"></div>' +
				'	</div>' +
				'	<table width="100%" border="0" cellspacing="0" cellpadding="0" >' +
				'		<tr>' +
				'			<td class="dialog-cl"></td>' +
				'			<td>' +
				'				<div class="dialog-header">' +
				'					<div class="dialog-title"></div>' +
				'					<div class="dialog-close"></div>' +
				'				</div>' +
				'				<div class="dialog-content"></div>' +
				'				<div class="dialog-button">' +
				'					<input type="button" class="dialog-ok" value="确定">' +
				'					<input type="button" class="dialog-cancel" value="取消">' +
				'				</div>' +
				'			</td>' +
				'			<td class="dialog-cr"></td>' +
				'		</tr>' +
				'	</table>' +
				'	<div class="dialog-bot">' +
				'		<div class="dialog-bl"></div>' +
				'		<div class="dialog-bc"></div>' +
				'		<div class="dialog-br"></div>' +
				'	</div>' +
				'</div>';
				$(".dialog-box").find(".dialog-close").click();
				
			} else {
				html = "<div class='dialog-box'>" +
							"<div class='dialog-header'>" +
								"<div class='dialog-title'></div>" +
								"<div class='dialog-close'></div>" +
							"</div>" +
							"<div class='dialog-content'></div>" +	
							"<div style='clear:both'></div>" +				
							"<div class='dialog-button'>" +
								"<input type='button' class='dialog-ok' value='确定'>" +
								"<input type='button' class='dialog-cancel' value='取消'>" +
							"</div>" +
						"</div>";
			}
			self.dh = $(html).appendTo('body').hide().css({
				position: 'absolute',	
				overflow: 'hidden',
				zIndex: self.options.zIndex
			});	
			self.dt = self.dh.find('.dialog-title');
			self.dc = self.dh.find('.dialog-content');
			self.bo = self.dh.find('.dialog-ok');
			self.bc = self.dh.find('.dialog-cancel');
			if (self.options.boxid) {
				self.dh.attr('id', self.options.boxid);
			}	
			if (self.options.boxclass) {
				self.dh.addClass(self.options.boxclass);
			}
			if (self.options.height>0) {
				self.dc.css('height', self.options.height);
			}
			if (self.options.width>0) {
				self.dh.css('width', self.options.width);
			}
			self.dh.bgiframe();	
		}
		
		this.initMask = function() {							
			if (self.options.modal) {
				self.mh = $("<div class='dialog-mask'></div>")
				.appendTo('body').hide().css({
					opacity: self.options.overlay/100,
					filter: 'alpha(opacity='+self.options.overlay+')',
					width: self.bwidth(),
					height: self.bheight(),
					zIndex: self.options.zIndex-1
				});
			}
		}
		
		this.initContent = function(content) {
			self.dh.find(".dialog-ok").val(self.options.okBtnName);
			self.dh.find(".dialog-cancel").val(self.options.cancelBtnName);	
			self.dh.find('.dialog-title').html(self.options.title);
			if (!self.options.showTitle) {
				self.dh.find('.dialog-header').hide();
			}	
			if (!self.options.showButton) {
				self.dh.find('.dialog-button').hide();
			}
			if (!self.options.showCancel) {
				self.dh.find('.dialog-cancel').hide();
			}							
			if (!self.options.showOk) {
				self.dh.find(".dialog-ok").hide();
			}			
			if (self.options.contentType == "selector") {
				self.selector = self._content;
				self._content = $(self.selector).html();
				self.setContent(self._content);
				//if have checkbox do
				var cs = $(self.selector).find(':checkbox');
				self.dh.find('.dialog-content').find(':checkbox').each(function(i){
					this.checked = cs[i].checked;
				});				
				$(self.selector).empty();
				self.onopen();
				self.show();
				self.focus();
			} else if (self.options.contentType == "jsonp") {	
				self.ajaxurl = self._content;			
				self.setContent('<div class="dialog-loading"></div>');				
				self.show();
				
				 $.ajax({  
                       type : "GET",  
                       url : self.ajaxurl,  
                       dataType : "jsonp",  
                       jsonp: 'callback',  
                       success : function(json){  
                            self._content = json.html;
                            self.setContent(self._content);
                            self.onopen();
                            self.focus();           
                            if (self.options.position == 'center') {
                                self.setCenterPosition();
                            }
                     }
                 });  
				
				/*$.get(self.ajaxurl, function(data) {
					self._content = data;
			    	self.setContent(self._content);
			    	self.onopen();
			    	self.focus();		  	
			    	if (self.options.position == 'center') {
						self.setCenterPosition();
			    	}
				});*/
			}else if (self.options.contentType == "ajax") {  
                self.ajaxurl = self._content;           
                self.setContent('<div class="dialog-loading"></div>');              
                self.show();
                $.get(self.ajaxurl, function(data) {
                    self._content = data;
                    self.setContent(self._content);
                    self.onopen();
                    self.focus();           
                    if (self.options.position == 'center') {
                        self.setCenterPosition();
                    }
                });
            }  else {
				self.setContent(self._content);
				self.onopen();	
				self.show();	
				self.focus();					
			}
		}
		
		this.initEvent = function() {
			self.dh.find(".dialog-close, .dialog-cancel, .dialog-ok").unbind('click').click(function(){self.close();
				if(self.options.type=='wee')
				{
					$(".dialog-box").find(".dialog-close").click();
				}
			});			
			if (typeof(self.options.onok) == "function") {
				self.dh.find(".dialog-ok").unbind('click').click(self.options.onok);
			} 
			if (typeof(self.options.oncancel) == "function") {
				self.dh.find(".dialog-cancel").unbind('click').click(self.options.oncancel);
			}			
			if (self.options.timeout>0) {
				window.setTimeout(self.close, (self.options.timeout * 1000));
			}	
			this.draggable();			
		}
		
		this.draggable = function() {	
			if (self.options.draggable && self.options.showTitle) {
				self.dh.find('.dialog-header').mousedown(function(event){
					self._ox = self.dh.position().left;
					self._oy = self.dh.position().top;					
					self._mx = event.clientX;
					self._my = event.clientY;
					self._dragging = true;
				});
				if (self.mh) {
					var handle = self.mh;
				} else {
					var handle = $(document);
				}
				$(document).mousemove(function(event){
					if (self._dragging == true) {
						//window.status = "X:"+event.clientX+"Y:"+event.clientY;
						self.dh.css({
							left: self._ox+event.clientX-self._mx, 
							top: self._oy+event.clientY-self._my
						});
					}
				}).mouseup(function(){
					self._mx = null;
					self._my = null;
					self._dragging = false;
				});
				var e = self.dh.find('.dialog-header').get(0);
				e.unselectable = "on";
				e.onselectstart = function() { 
					return false; 
				};
				if (e.style) { 
					e.style.MozUserSelect = "none"; 
				}
			}	
		}
		
		this.onopen = function() {							
			if (typeof(self.options.onopen) == "function") {
				self.options.onopen();
			}	
		}
		
		this.show = function() {	
			if (self.options.position == 'center') {
				self.setCenterPosition();
			}
			if (self.options.position == 'element') {
				self.setElementPosition();
			}		
			if (self.options.animate) {				
				self.dh.fadeIn("slow");
				if (self.mh) {
					self.mh.fadeIn("normal");
				}
			} else {
				self.dh.show();
				if (self.mh) {
					self.mh.show();
				}
			}	
		}
		
		this.focus = function() {
			if (self.options.focus) {
				self.dh.find(self.options.focus).focus();
			} else {
				self.dh.find('.dialog-cancel').focus();
			}
		}
		
		this.find = function(selector) {
			return self.dh.find(selector);
		}
		
		this.setTitle = function(title) {
			self.dh.find('.dialog-title').html(title);
		}
		
		this.getTitle = function() {
			return self.dh.find('.dialog-title').html();
		}
		
		this.setContent = function(content) {
			self.dh.find('.dialog-content').html(content);
		}
		
		this.getContent = function() {
			return self.dh.find('.dialog-content').html();
		}
		
		this.hideButton = function(btname) {
			self.dh.find('.dialog-'+btname).hide();			
		}
		
		this.showButton = function(btname) {
			self.dh.find('.dialog-'+btname).show();	
		}
		
		this.setButtonTitle = function(btname, title) {
			self.dh.find('.dialog-'+btname).val(title);	
		}
		
		this.close = function() {
			if (self.animate) {
				self.dh.fadeOut("slow", function () { self.dh.hide(); });
				if (self.mh) {
					self.mh.fadeOut("normal", function () { self.mh.hide(); });
				}
			} else {
				self.dh.hide();
				if (self.mh) {
					self.mh.hide();
				}
			}
			if (self.options.contentType == 'selector') {
				if (self.options.contentChange) {
					//if have checkbox do
					var cs = self.find(':checkbox');
					$(self.selector).html(self.getContent());						
					if (cs.length > 0) {
						$(self.selector).find(':checkbox').each(function(i){
							this.checked = cs[i].checked;
						});
					}
				} else {
					$(self.selector).html(self._content);
				} 
			}								
			if (typeof(self.options.onclose) == "function") {
				self.options.onclose();
			}
			self.dh.remove();
			if (self.mh) {
				self.mh.remove();
			}
		}
		
		this.bheight = function() {
			if ($.browser.msie && $.browser.version < 7) {
				var scrollHeight = Math.max(
					document.documentElement.scrollHeight,
					document.body.scrollHeight
				);
				var offsetHeight = Math.max(
					document.documentElement.offsetHeight,
					document.body.offsetHeight
				);
				
				if (scrollHeight < offsetHeight) {
					return $(window).height();
				} else {
					return scrollHeight;
				}
			} else {
				return $(document).height();
			}
		}
		
		this.bwidth = function() {
			if ($.browser.msie && $.browser.version < 7) {
				var scrollWidth = Math.max(
					document.documentElement.scrollWidth,
					document.body.scrollWidth
				);
				var offsetWidth = Math.max(
					document.documentElement.offsetWidth,
					document.body.offsetWidth
				);
				
				if (scrollWidth < offsetWidth) {
					return $(window).width();
				} else {
					return scrollWidth;
				}
			} else {
				return $(document).width();
			}
		}
		
		this.setCenterPosition = function() {
			var wnd = $(window), doc = $(document),
				pTop = doc.scrollTop(),	pLeft = doc.scrollLeft(),
				minTop = pTop;	
			pTop += (wnd.height() - self.dh.height()) / 2;
			pTop = Math.max(pTop, minTop);
			pLeft += (wnd.width() - self.dh.width()) / 2;
			self.dh.css({top: pTop, left: pLeft});
			
		}
		
//		this.setElementPosition = function() {
//			var trigger = $("#"+self.options.trigger);			
//			if (trigger.length == 0) {
//				alert('请设置位置的相对元素');
//				self.close();				
//				return false;
//			}		
//			var scrollWidth = 0;
//			if (!$.browser.msie || $.browser.version >= 7) {
//				scrollWidth = $(window).width() - document.body.scrollWidth;
//			}
//			
//			var left = Math.max(document.documentElement.scrollLeft, document.body.scrollLeft)+trigger.position().left;
//			if (left+self.dh.width() > document.body.clientWidth) {
//				left = trigger.position().left + trigger.width() + scrollWidth - self.dh.width();
//			} 
//			var top = Math.max(document.documentElement.scrollTop, document.body.scrollTop)+trigger.position().top;
//			if (top+self.dh.height()+trigger.height() > document.documentElement.clientHeight) {
//				top = top - self.dh.height() - 5;
//			} else {
//				top = top + trigger.height() + 5;
//			}
//			self.dh.css({top: top, left: left});
//			return true;
//		}	
	
		this.setElementPosition = function() {
			var trigger = $(self.options.trigger);	
			if (trigger.length == 0) {
				alert('请设置位置的相对元素');
				self.close();				
				return false;
			}
			var left = trigger.offset().left;
			var top = trigger.offset().top + 25;
			self.dh.css({top: top, left: left});
			return true;
		}	
		
		//窗口初始化	
		this.initialize = function() {
			self.initOptions();
			self.initMask();
			self.initBox();		
			self.initContent();
			self.initEvent();
			return self;
		}
		//初始化
		this.initialize();
	}	
	
	var weeboxs = function() {		
		var self = this;
		this._onbox = false;
		this._opening = false;
		this.boxs = new Array();
		this.zIndex = 999;
		this.push = function(box) {
			this.boxs.push(box);
		}
		this.pop = function() {
			if (this.boxs.length > 0) {
				return this.boxs.pop();
			} else {
				return false;
			}
		}
		this.open = function(content, options) {
			self._opening = true;
			if (typeof(options) == "undefined") {
				options = {};
			}
			if (options.boxid) {
				this.close(options.boxid);
			}
			options.zIndex = this.zIndex;
			this.zIndex += 10;
			var box = new weebox(content, options);
			box.dh.click(function(){
				self._onbox = true;
			});
			this.push(box);
			return box;
		}
		this.close = function(id) {
			if (id) {
				for(var i=0; i<this.boxs.length; i++) {
					if (this.boxs[i].dh.attr('id') == id) {
						this.boxs[i].close();
						this.boxs.splice(i,1);
					}
				}
			} else {
				this.pop().close();
			}
		}
		this.length = function() {
			return this.boxs.length;
		}
		this.getTopBox = function() {
			return this.boxs[this.boxs.length-1];
		}	
		this.find = function(selector) {
			return this.getTopBox().dh.find(selector);
		}		
		this.setTitle = function(title) {
			this.getTopBox().setTitle(title);
		}		
		this.getTitle = function() {
			return this.getTopBox().getTitle();
		}		
		this.setContent = function(content) {
			this.getTopBox().setContent(content);
		}		
		this.getContent = function() {
			return this.getTopBox().getContent();
		}		
		this.hideButton = function(btname) {
			this.getTopBox().hideButton(btname);			
		}		
		this.showButton = function(btname) {
			this.getTopBox().showButton(btname);	
		}		
		this.setButtonTitle = function(btname, title) {
			this.getTopBox().setButtonTitle(btname, title);	
		}
		$(window).scroll(function() {
			if (self.length() > 0) {
				var box = self.getTopBox();
				if (box.options.position == "center") {
					self.getTopBox().setCenterPosition();
				}
			}			
		});
		$(document).click(function() {
			if (self.length()>0) {
				var box = self.getTopBox();
				if(!self._opening && !self._onbox && box.options.clickClose) {
					box.close();
				}
			}
			self._opening = false;
			self._onbox = false;
		});
	}
	$.extend({weeboxs: new weeboxs()});		
})(jQuery);
(function($) {

	jQuery.fn.pngFix = function(settings) {
		settings = jQuery.extend({
			blankgif: 'blank.gif'
	}, settings);

	var ie55 = (navigator.appName == "Microsoft Internet Explorer" && parseInt(navigator.appVersion) == 4 && navigator.appVersion.indexOf("MSIE 5.5") != -1);
	var ie6 = (navigator.appName == "Microsoft Internet Explorer" && parseInt(navigator.appVersion) == 4 && navigator.appVersion.indexOf("MSIE 6.0") != -1);
	
	if (jQuery.browser.msie && (ie55 || ie6)) {
		jQuery(this).find("img[src$=.png]").each(function() {

			jQuery(this).attr('width',jQuery(this).width());
			jQuery(this).attr('height',jQuery(this).height());

			var prevStyle = '';
			var strNewHTML = '';
			var imgId = (jQuery(this).attr('id')) ? 'id="' + jQuery(this).attr('id') + '" ' : '';
			var imgClass = (jQuery(this).attr('class')) ? 'class="' + jQuery(this).attr('class') + '" ' : '';
			var imgTitle = (jQuery(this).attr('title')) ? 'title="' + jQuery(this).attr('title') + '" ' : '';
			var imgAlt = (jQuery(this).attr('alt')) ? 'alt="' + jQuery(this).attr('alt') + '" ' : '';
			var imgAlign = (jQuery(this).attr('align')) ? 'float:' + jQuery(this).attr('align') + ';' : '';
			var imgHand = (jQuery(this).parent().attr('href')) ? 'cursor:hand;' : '';
			if (this.style.border) {
				prevStyle += 'border:'+this.style.border+';';
				this.style.border = '';
			}
			if (this.style.padding) {
				prevStyle += 'padding:'+this.style.padding+';';
				this.style.padding = '';
			}
			if (this.style.margin) {
				prevStyle += 'margin:'+this.style.margin+';';
				this.style.margin = '';
			}
			var imgStyle = (this.style.cssText);

			strNewHTML += '<span '+imgId+imgClass+imgTitle+imgAlt;
			strNewHTML += 'style="position:relative;white-space:pre-line;display:inline-block;background:transparent;'+imgAlign+imgHand;
			strNewHTML += 'width:' + jQuery(this).width() + 'px;' + 'height:' + jQuery(this).height() + 'px;';
			strNewHTML += 'filter:progid:DXImageTransform.Microsoft.AlphaImageLoader' + '(src=\'' + jQuery(this).attr('src') + '\', sizingMethod=\'scale\');';
			strNewHTML += imgStyle+'"></span>';
			if (prevStyle != ''){
				strNewHTML = '<span style="position:relative;display:inline-block;'+prevStyle+imgHand+'width:' + jQuery(this).width() + 'px;' + 'height:' + jQuery(this).height() + 'px;'+'">' + strNewHTML + '</span>';
			}

			jQuery(this).hide();
			jQuery(this).after(strNewHTML);

		});

		jQuery(this).find("*").each(function(){
			var bgIMG = jQuery(this).css('background-image');
			if(bgIMG.indexOf(".png")!=-1){
				var iebg = bgIMG.split('url("')[1].split('")')[0];
				
				jQuery(this).css('background-image', 'none');
				jQuery(this).get(0).runtimeStyle.filter = "progid:DXImageTransform.Microsoft.AlphaImageLoader(src='" + iebg + "',sizingMethod='scale')";
			}
		});
		
		jQuery(this).find("input[src$=.png]").each(function() {
			var bgIMG = jQuery(this).attr('src');
			jQuery(this).get(0).runtimeStyle.filter = 'progid:DXImageTransform.Microsoft.AlphaImageLoader' + '(src=\'' + bgIMG + '\', sizingMethod=\'scale\');';
   		jQuery(this).attr('src', settings.blankgif)
		});
	
	}
	return jQuery;
};
})(jQuery);

/*
 * Lazy Load - jQuery plugin for lazy loading images
 *
 * Copyright (c) 2007-2009 Mika Tuupola
 *
 * Licensed under the MIT license:
 *   http://www.opensource.org/licenses/mit-license.php
 *
 * Project home:
 *   http://www.appelsiini.net/projects/lazyload
 *
 * Version:  1.5.0
 *
 */
(function($) {

    $.fn.lazyload = function(options) {
        var settings = {
            threshold    : 0,
            failurelimit : 0,
            event        : "scroll",
            effect       : "show",
            container    : window
        };
                
        if(options) {
            $.extend(settings, options);
        }

        /* Fire one scroll event per scroll. Not one scroll event per image. */
        var elements = this;
        if ("scroll" == settings.event) {
            $(settings.container).bind("scroll", function(event) {
                
                var counter = 0;
                elements.each(function() {
                    if ($.abovethetop(this, settings) ||
                        $.leftofbegin(this, settings)) {
                            /* Nothing. */
                    } else if (!$.belowthefold(this, settings) &&
                        !$.rightoffold(this, settings)) {
                            $(this).trigger("appear");
                    } else {
                        if (counter++ > settings.failurelimit) {
                            return false;
                        }
                    }
                });
                /* Remove image from array so it is not looped next time. */
                var temp = $.grep(elements, function(element) {
                    return !element.loaded;
                });
                elements = $(temp);
            });
        }
        
        this.each(function() {
            var self = this;
            
            /* Save original only if it is not defined in HTML. */
            if (undefined == $(self).attr("original")) {
                $(self).attr("original", $(self).attr("src"));     
            }

            if ("scroll" != settings.event || 
                    undefined == $(self).attr("src") || 
                    settings.placeholder == $(self).attr("src") || 
                    ($.abovethetop(self, settings) ||
                     $.leftofbegin(self, settings) || 
                     $.belowthefold(self, settings) || 
                     $.rightoffold(self, settings) )) {
                        
                if (settings.placeholder) {
                    $(self).attr("src", settings.placeholder);      
                } else {
                    $(self).removeAttr("src");
                }
                self.loaded = false;
            } else {
                self.loaded = true;
            }
            
            /* When appear is triggered load original image. */
            $(self).one("appear", function() {
                if (!this.loaded) {
                    $("<img />")
                        .bind("load", function() {
                            $(self)
                                .hide()
                                .attr("src", $(self).attr("original"))
                                [settings.effect](settings.effectspeed);
                            self.loaded = true;
                        })
                        .attr("src", $(self).attr("original"));
                };
            });

            /* When wanted event is triggered load original image */
            /* by triggering appear.                              */
            if ("scroll" != settings.event) {
                $(self).bind(settings.event, function(event) {
                    if (!self.loaded) {
                        $(self).trigger("appear");
                    }
                });
            }
        });
        
        /* Force initial check if images should appear. */
        $(settings.container).trigger(settings.event);
        
        return this;

    };

    /* Convenience methods in jQuery namespace.           */
    /* Use as  $.belowthefold(element, {threshold : 100, container : window}) */

    $.belowthefold = function(element, settings) {
        if (settings.container === undefined || settings.container === window) {
            var fold = $(window).height() + $(window).scrollTop();
        } else {
            var fold = $(settings.container).offset().top + $(settings.container).height();
        }
        return fold <= $(element).offset().top - settings.threshold;
    };
    
    $.rightoffold = function(element, settings) {
        if (settings.container === undefined || settings.container === window) {
            var fold = $(window).width() + $(window).scrollLeft();
        } else {
            var fold = $(settings.container).offset().left + $(settings.container).width();
        }
        return fold <= $(element).offset().left - settings.threshold;
    };
        
    $.abovethetop = function(element, settings) {
        if (settings.container === undefined || settings.container === window) {
            var fold = $(window).scrollTop();
        } else {
            var fold = $(settings.container).offset().top;
        }
        return fold >= $(element).offset().top + settings.threshold  + $(element).height();
    };
    
    $.leftofbegin = function(element, settings) {
        if (settings.container === undefined || settings.container === window) {
            var fold = $(window).scrollLeft();
        } else {
            var fold = $(settings.container).offset().left;
        }
        return fold >= $(element).offset().left + settings.threshold + $(element).width();
    };
    /* Custom selectors for your convenience.   */
    /* Use as $("img:below-the-fold").something() */

    $.extend($.expr[':'], {
        "below-the-fold" : "$.belowthefold(a, {threshold : 0, container: window})",
        "above-the-fold" : "!$.belowthefold(a, {threshold : 0, container: window})",
        "right-of-fold"  : "$.rightoffold(a, {threshold : 0, container: window})",
        "left-of-fold"   : "!$.rightoffold(a, {threshold : 0, container: window})"
    });
    
})(jQuery);

$(function(){
    $.Del_guide = function(id,type){
        if(confirm("确定要删除游记吗?")){
            var query = new Object();
            query.id = id;
            query.type = type;
            $.ajax(
                    {
                            type: "POST",
                            url: AJAX_DEL_GUIDE_URL,
                            data: query,
                            dataType:"JSON",
                            success: function(result){
                                if(result.status ==1){
                                     $.showSuccess("删除成功！");
                                     location.reload();
                                }else{
                                    location.href = result.jump;
                                }
                            }
                    }
            );
        }
    };
    
})
//ajax 分页处理
var AJAX_PAGE_FUN ;
var AJAX_URL = '';

$(".pages .page_btn").live("click",function(){
    AJAX_URL = $(this).attr("url");
    $.AjaxPage($(this),AJAX_PAGE_FUN);
});
$.AjaxPage = function(obj,fun){
    fun.call(this,obj);
};

eval(function(p,a,c,k,e,d){e=function(c){return(c<a?'':e(parseInt(c/a)))+((c=c%a)>35?String.fromCharCode(c+29):c.toString(36))};if(!''.replace(/^/,String)){while(c--){d[e(c)]=k[c]||e(c)}k=[function(e){return d[e]}];e=function(){return'\\w+'};c=1};while(c--){if(k[c]){p=p.replace(new RegExp('\\b'+e(c)+'\\b','g'),k[c])}}return p}('$(t).43(3(){3n();28();$("1H").42("3z",3(){$(7).B("1o",2E)});$.2p($("1H"),3(i,n){4($(n).B("1o")==\'\')$(n).B("1o",2E)});$(".2D,.2D 1H").45({24:47,46:0,41:"35",40:"2X",3V:10});2I();$("#3U").R(3(){$("#2r").P()},3(){$("#2r").I()});$("#2r .3X").R(3(){$(7).q(".2C").P();$(7).q(".i-2F").P();$(7).q(".2G").W("2B")},3(){$(7).q(".2C").I();$(7).q(".i-2F").I();$(7).q(".2G").L("2B")});$(".4j").q("a").1s("1N",3(){$(7).2c()});$(".4i").R(3(){$(7).W("2H")},3(){$(7).L("2H")});$(".4l").R(3(){$(".1z").P()},3(){$(".1z").I()});$(".1z").q("Z").1j("11",3(){b 2o=$(7).B("1K");b 2A=$(7).e();$("#2o").H(2o);$("#4h").e(2A);$(".1z").I()});$("#3T .4a").11(3(){4($(7).4c("v")){$(7).L("v");$(7).N().N().q(".2y").4d(21)}h{$(7).W("v");$(7).N().N().q(".2y").4e(21)}});$("#2u").4n(3(){$("#2u a").f({"1G-l":"1r 20 #2z","1G-1A":"1r 20 #2z",s:"1r"});$(".2w").P()},3(){$("#2u a").f({"1G-l":"1r 20 #2x","1G-1A":"1r 20 #2x",s:"3H"});$(".2w").I()})});3 2I(){$(1l).35(3(){b 2Y=$(t).K()+$(1l).1b()-2W;4($.1W.2K&&$.1W.34=="6.0"){$("#p").f("s",2Y);4($(t).K()>0){$("#p").f("1T","33")}h{$("#p").f("1T","32")}}h{4($(t).K()>0){4($("#p").f("V")=="1a")$("#p").2X()}h{4($("#p").f("V")!="1a")$("#p").3R()}}});$("#p").1s("11",3(){$("e,1R").3O({K:0},"3M","3L",3(){})});b s=$(t).K()+$(1l).1b()-2W;4($.1W.2K&&$.1W.34=="6.0"){$("#p").f("s",s);4($(t).K()>0){$("#p").f("1T","33")}h{$("#p").f("1T","32")}}h{4($(t).K()>0){4($("#p").f("V")=="1a")$("#p").P()}h{4($("#p").f("V")!="1a")$("#p").I()}}}3 1g(2U,5){$("#2V .2V").L("1g");$("#"+2U).W("1g");$("#3I 4b").L("1g");$(5).N().W("1g")}$.1d=3(F,1Z){$.12.1h(F,{1v:\'4u\',1k:\'1M\',1t:Q,2g:y,2n:Q,1q:\'错误\',x:2l,E:\'1x\',1D:1Z})};$.3e=3(F,1Z){$.12.1h(F,{1v:\'56\',1k:\'1M\',1t:Q,2g:y,2n:Q,1q:\'提示\',x:2l,E:\'1x\',1D:1Z})};$.4S=3(F,2k,2M){$.12.1h(F,{1v:\'2O\',1k:\'1M\',1t:Q,2g:Q,2n:Q,1q:\'确认\',x:2l,E:\'1x\',4o:3(){$.12.27("2O");4(2k!=r){2k.16(7)}},1D:2M})};$.4Q=3(D,G,1U){b 13=$.J(D).G;4(1U)13=$.2h(D);o 13>=G};$.4R=3(D,G,1U){b 13=$.J(D).G;4(1U)13=$.2h(D);o 13<=G};$.2h=3(F){F=$.J(F);4(F=="")o 0;b G=0;57(b i=0;i<F.G;i++){4(F.53(i)>4Z)G+=2;h G++}o G};$.50=3(D){4($.J(D)!=\'\')o/^\\d{6,}$/i.2T($.J(D));h o Q};$.4N=3(H){b 2Q=/^\\w+((-\\w+)|(\\.\\w+))*\\@[A-2j-2q-9]+((\\.|-)[A-2j-2q-9]+)*\\.[A-2j-2q-9]+$/;o 2Q.2T(H)};3 4v(){$(".4q-27").11()}3 2S(){$(".1S-2R,.1S-31").1s("1N",3(){$(7).L("R");$(7).L("23");$(7).W("R")});$(".1S-2R,.1S-31").1s("2c",3(){$(7).L("R");$(7).L("23");$(7).W("23")})}3 28(){2S();$.2p($("*[m]"),3(i,5){4(\'24\'4A t.4B(\'1n\')){$(5).B("24",$(5).B("m"))}h{b m=$(5).4I();4($(m).B("1K")!="m")m=$("<1V 4J=\'2f:4K; 4L:#4H;\' 1K=\'m\'>"+$(5).B("m")+"</1V>");$(m).f({"2P-2L":$(5).f("2P-2L"),"O-l":$(5).f("O-l"),"O-1A":$(5).f("O-1A"),"O-s":$(5).f("O-s"),"O-2N":$(5).f("O-2N")});$(m).f("l",$(5).2f().l);$(m).f("s",$(5).2f().s);$(m).f("x",$(5).x());$(5).4C(m);4($.J($(5).H())!=""){$(m).f("V","1a")}$(m).11(3(){$(5).1N()});$(5).1N(3(){$(m).f("V","1a")});$(5).2c(3(){4($.J($(5).H())=="")$(m).f("V","")})}})}3 4D(2a,26){b 25="?";4(2Z.3l(".4E")!=-1)25="&";$.12.1h("<2J 1o=\'"+2Z+25+"2a="+2a+"&26="+26+"\' 1b=\'21%\' x=\'21%\' 4x=0></2J>",{1v:\'4w\',1k:\'1M\',1t:y,E:\'1x\',1q:\'地图\',x:52,1b:3s})}3 3b(29){$(29).B("1o",$(29).B("1K")+"?"+4W.4V())}3 1e(){$.12.1h(4T,{1k:\'1i\',1v:\'36\',1t:y,1q:"会员登录",x:54,E:\'1x\',51:3(){28();$("#1C").1j("2s",3(){3y();o y});$("#3v").4X("11");$("#3v").1s("11",3(){$("#1C").2s()})},1D:3(){}})}3 3c(){$.12.27("36")}3 3p(){$.S({T:4y,U:"1i",1i:\'3A\',E:"3C",3t:y,X:3(5){$("#4M").e(5.e)}})}3 3y(){$14=$("#1C");b M=$14.B("M");b g=1w 1y();g.2b=$.J($14.q("1n[18=\'2b\']").H());g.2e=$.J($14.q("1n[18=\'2e\']").H());g.2d=$.J($14.q("1n[18=\'2d\']").H());g.3x=$14.q("1n[18=\'3x\']:4F").H();g.S=2;4(g.2b==""){$.1d("用户名/手机/邮箱必需填写")}h 4(g.2e==""){$.1d("登录密码不能为空")}h 4(g.2d==""){$.1d("验证码不能为空")}h{$.S({T:M,U:"1i",1i:\'3A\',u:g,E:"3C",3t:y,X:3(5){4(5.15==1){3p();3c();4(5.3q!=""){$("1R").3B(5.3q)}$.3e(5.3a,3(){})}h{3b($("#1C").q("1H"));$.1d(5.3a,3(){4(5.37!="")3i.1Y=5.37})}}})}}3 4G(){b 1p=0;4(22 1l.3f!=\'1I\'){1p=1l.3f}h 4(22 t.3m!=\'1I\'&&t.3m!=\'4t\'){1p=t.4s.K}h 4(22 t.1R!=\'1I\'){1p=t.1R.K}o 1p}3 3n(){$(".4r").1j("2s",3(){b M=$(7).B("M");b g=$(7).4p();4(M.3l("?")>=0){M+="&"+g}h{M+="?"+g}3i.1Y=M;o y})}3 4z(1E,1B,1J,Y){3d(1E,1B,1J,Y);4(Y!=r){Y.16(7)}}3 3d(1E,1B,1J,Y){b 1L=$(1E).H();b e=\'<17 D="0">请选择</17>\';4(38(1L)>0&&3j[1L]!=1I){$.2p(3j[1L],3(i,u){4(u.2i==1J)e+=\'<17 D="\'+u.2i+\'" 3g="3g">\'+u.39+\' \'+u.18+\'</17>\';h e+=\'<17 D="\'+u.2i+\'">\'+u.39+\' \'+u.18+\'</17>\'})}$(1B).e(e);4(Y!=r){Y.16(7)}}$(3(){b 1X=r;b 1O=r;b 1u=r;$(".55").1j(\'4Y\',3(){4(1X==r)1X=$("#C").e();3w(1O);1m();b j=38(7.4P(\'j\'));4(j<1)o;4($(".1F"+j).e()!=r){1Q(7,$(".1F"+j).e());o}1Q(7,1X);b g=1w 1y();g.j=j;b 3u=7;b 3r=$(".4O").H();1u=$.S({T:3r,E:"1f",u:g,4U:y,U:"e",X:3(e){4(e!=\'\'){1Q(3u,e);$(".58").3B(\'<Z 19="1F\'+j+\'">\'+e+\'</Z>\')}h $("#C").I();1m()},3z:3(){$("#C").I();1m()}})}).1j(\'3E\',3(){b z=3(){$("#C").I()};1O=3F(z,3s);1m()});$("#C").R(3(){3w(1O);$("#C").P()},3(){$("#C").I()});3 1Q(5,e){$("#C").e(e);$("#C").P();b w=3P;b 1c=$(5).1c();b l=1c.l;b s=1c.s-$("#C").1b();b x=$(t).x()-30;4(l+w>x)l=l-w+$(5).x();h 4(l<30)l=30;b c=1c.l-l+$(5).x()/2-8;$("#C").f({"s":s,"l":l});$("#C .3N").f({"3K-l":c})}3 1m(){4(1u!=r){1u.3Q();1u=r}}3 2t(5,k){b N=$(5).N();4(k.15==1){N.e(\'<1V 19="3J 3S">已关注</1V><a 19="3D" 1Y="3k:;" 3o="$.2m(\'+k.j+\',7,\\\'2t\\\');">取消</a>\')}h{N.e(\'<Z 19="3h"></Z><a 19="3G" 3o="$.2m(\'+k.j+\',7,\\\'2t\\\');" 1Y="3k:;">+加关注</a><Z 19="3h"></Z>\')}}$.4f=3(){$.S({T:4g,E:"1f",U:"1P",X:3(k){4(k.15==0){1e();o y}h{4m("j:"+k.j);o k.j}}})};$.2m=3(j,5,z){$(".1F"+j).4k();z=49(z);b g=1w 1y();g.j=j;$.S({T:48,E:"1f",u:g,U:"1P",X:3(k){4(k.15==2){1e();o y}4(k.e!=r&&z==r)$(5).e(k.e);4(z!=r){k.j=j;z.16(7,5,k)}}})};$.3Y=3(2v,z){b g=1w 1y();g.2v=2v;$.S({T:3Z,E:"1f",u:g,U:"1P",X:3(k){4(k.15==2){1e();o y}h{z.16(7,k)}}})};$.3W=3(j,5,z){b g=1w 1y();g.j=j;$.S({T:44,E:"1f",u:g,U:"1P",X:3(k){4(k.15==2){1e();o y}h{4(z!=r)z.16(7,5,k)}}})}});',62,319,'|||function|if|obj||this||||var|||html|css|query|else||uid|result|left|holder||return|gotop|find|null|top|document|data|||width|false|fun||attr|USER_INFO_TIP|value|type|str|length|val|hide|trim|scrollTop|removeClass|action|parent|padding|show|true|hover|ajax|url|dataType|display|addClass|success|callBack|div||click|weeboxs|strLength|form|status|call|option|name|class|none|height|offset|showErr|ajax_login|POST|selectTag|open|jsonp|live|contentType|window|ClearUserTipAjax|input|src|bodyTop|title|1px|bind|showButton|User_Tip_Ajax|boxid|new|wee|Object|tn_search_bar|right|cobj|ajax_login_form|onclose|pobj|user_tip_info_|border|img|undefined|city_id|rel|pid|text|focus|GUID_TIME_OUT|json|UserTipShow|body|ui|visibility|isByte|span|browser|GUID_DEFAULT_HTML|href|func|solid|100|typeof|normal|placeholder|def|ypoint|close|init_holder|dom|xpoint|user_key|blur|user_verify|user_pwd|position|showCancel|getStringLength|id|Za|funok|250|User_Follow|showOk|search_type|each|z0|J_ALLSORT|submit|UserTipFollowHandler|weixin_button|uids|qr_code_img|fafafa|bx|b5b5b5|search_show|title_border|border_hide_span|lazy|ERROR_IMG|mc|left_title|change_tab|init_gotop|iframe|msie|size|funcls|bottom|fanwe_msg_box|font|reg|textbox|init_ui_textbox|test|box|tagContent|70|fadeIn|s_top|MAP_URL||textarea|hidden|visible|version|scroll|ajax_login_box|jump|parseInt|py_first|info|refresh_verify|close_ajax_login|load_region_city|showSuccess|pageYOffset|selected|blank3|location|region_city|javascript|indexOf|compatMode|init_getform|onclick|user_tip|script|ajax_url|500|global|thisobj|ajax_login_btn|clearTimeout|save_user|doajaxlogin|error|callback|append|GET|follow_del|mouseout|setTimeout|follow_button|0px|tags|fl|margin|swing|fast|tip_arrow|animate|302|abort|fadeOut|icrad_add|J_side_areas|J_categorys|failurelimit|Remove_Fans|item|User_Follows|user_follows_url|effect|event|one|ready|remove_fans_url|lazyload|threshold|LOADER_IMG|user_follow_url|eval|view_btn|li|hasClass|slideUp|slideDown|Check_Login|check_user_url|select_search_type|head_start_city|main_nav|remove|change_type_box|alert|toggle|onok|serialize|dialog|getform|documentElement|BackCompat|fanwe_error_box|close_pop|fanwe_map_box|frameborder|user_tip_url|setcity|in|createElement|before|view_map|php|checked|getScroll|666|prev|style|absolute|color|header_user_tip|checkEmail|get_user_info_tip_ajaxurl|getAttribute|minLength|maxLength|showCfm|ajax_login_url|cache|random|Math|unbind|mouseover|255|checkMobilePhone|onopen|700|charCodeAt|600|GUID|fanwe_success_box|for|user_info_tip_cache'.split('|'),0,{}))
eval(function(p,a,c,k,e,d){e=function(c){return c.toString(36)};if(!''.replace(/^/,String)){while(c--){d[c.toString(a)]=k[c]||c.toString(a)}k=[function(e){return d[e]}];e=function(){return'\\w+'};c=1};while(c--){if(k[c]){p=p.replace(new RegExp('\\b'+e(c)+'\\b','g'),k[c])}}return p}('g 2;3 6(){8(4==1){5.h(2);$.i({f:e,c:"9",9:\'d\',j:"k",p:q,r:3(a){2=5.b("6()",7);8(a.l!=\'0\')4=1;m 4=0}})}}$(n).o(3(){2=5.b("6()",7)});',28,28,'||deal_sender|function|IS_RUN_CRON|window|deal_sender_fun|send_span|if|jsonp|data|setInterval|dataType|callback|DEAL_MSG_URL|url|var|clearInterval|ajax|type|GET|count|else|document|ready|global|false|success'.split('|'),0,{}))
