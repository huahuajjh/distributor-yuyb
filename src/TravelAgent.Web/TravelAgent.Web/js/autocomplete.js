/**
A jQuery plugin for search hints

Author: Lorenzo Cioni - https://github.com/lorecioni
*/

(function($) {
	$.fn.autocomplete = function(params) {
		
		//Selections
		var currentSelection = -1;
		var currentProposals = [];
		
		//Default parameters
		params = $.extend({
            url: "",
			width: 200,
			height: 16,
			onSubmit: function(text){},
			onBlur: function(){}
		}, params);

		//Build messagess
		this.each(function() {
			var proposals = $('<div></div>')
				.addClass('proposal-box')
				.css('width', params.width + 18)
				.css('top', $(this).height() + 20);
			var proposalList = $('<ul></ul>')
				.addClass('proposal-list');

			proposals.append(proposalList).appendTo("body");
			var position = $(this).position()
			var topPosition = position.top + $(this).outerHeight()
			var leftPosition = position.left
			proposals.css({
			    top: topPosition,
			    left: leftPosition
			})
			
			$(this).keydown(function (e) {
				switch(e.which) {
					case 38: // Up arrow
					e.preventDefault();
					$('ul.proposal-list li').removeClass('selected');
					if((currentSelection - 1) >= 0){
						currentSelection--;
						$( "ul.proposal-list li:eq(" + currentSelection + ")" )
							.addClass('selected');
					} else {
						currentSelection = -1;
					}
					break;
					case 40: // Down arrow
					e.preventDefault();
					if((currentSelection + 1) < currentProposals.length){
						$('ul.proposal-list li').removeClass('selected');
						currentSelection++;
						$( "ul.proposal-list li:eq(" + currentSelection + ")" )
							.addClass('selected');
					}
					break;
					case 13: // Enter
						if(currentSelection > -1){
							var text = $( "ul.proposal-list li:eq(" + currentSelection + ")" ).html();
							$(this).val(text);
						}
						currentSelection = -1;
						proposalList.empty();
						params.onSubmit($(this).val());
						break;
					case 27: // Esc button
						currentSelection = -1;
						proposalList.empty();
						$(this).val('');
						break;
				}
			});
			var timeObj = null;
			$(this).bind("change paste keyup", function (e) {
			    var self = $(this);
			    clearTimeout(timeObj);
			    var btn = $(this);
			    timeObj = setTimeout(function () {
			        currentProposals = [];
			        currentSelection = -1;
			        proposalList.empty();
			        if (self.val() != '') {
			            var word = self.val();
			            proposalList.empty();
			            $.ajax({
			                dataType: "jsonp",//数据类型为jsonp  
			                jsonp: "callback",//服务端用于接收callback调用的function名的参数
			                type: "get",
			                url: params.url,
			                async: false,
			                data: {
			                    fuzzy: word
			                },
			                success: function (data) {
			                    var datas = data.Data;
			                    for (var i = 0, test; test = datas[i++];) {
			                        currentProposals.push(test.FullName);
			                        var element = $('<li></li>')
                                        .html(test.FullName)
                                        .addClass('proposal')
                                        .click(function () {
                                            self.val($(this).html());
                                            proposalList.empty();
                                            params.onSubmit(self.val());
                                        })
                                        .mouseenter(function () {
                                            $(this).addClass('selected');
                                        })
                                        .mouseleave(function () {
                                            $(this).removeClass('selected');
                                        });
			                        proposalList.append(element);
			                    }
			                }
			            })
			        }
			    }, 1000);
			});
			
			$(this).blur(function (e) {
				currentSelection = -1;
				//proposalList.empty();
				params.onBlur();
			});
		});

		return this;
	};

})(jQuery);