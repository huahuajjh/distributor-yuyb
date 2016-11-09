;(function ($) {
  // 地址面板数据控制
  var AddressDataPanel = function(setting) {
    var self = this;
    // ----私用方法
    // 请求封装
    function ajax(url, sendData, successFn, errorFn) {
        self.panel.find(".area-panel .msg").remove();
        self.panel.find(".area-panel > div").css("display", "none");
        self.panel.find(".area-panel").append($('<div class="msg">正在初始化数据...</div>'));
        if ($.isFunction(setting.requestBefore)) setting.requestBefore(sendData);

        $.ajax({
            dataType: "jsonp",//数据类型为jsonp  
            jsonp: "callback",//服务端用于接收callback调用的function名的参数
            type: "get",
            async: false,
            url: url,
            data: sendData,
            success: function (data) {
                if (data.Code == 1) {
                    self.panel.find(".area-panel > .msg").remove();
                    if ($.isFunction(setting.requestAfter)) {
                        var rData = setting.requestAfter(data);
                        if (rData) data = rData;
                    }
                    if ($.isFunction(successFn)) successFn(data);
                } else {
                    var a = $("<a href='javascript:void(0);'>刷新</a>")
                    a.on("click", function () {
                        ajax(url, sendData, successFn, errorFn);
                    });
                    self.panel.find(".area-panel > .msg").remove();
                    self.panel.find(".area-panel").append($('<div class="msg">数据格式不正确.</div>').append(a));
                    if ($.isFunction(errorFn)) errorFn();
                }
            },
            error: function () {
                var a = $("<a href='javascript:void(0);'>刷新</a>")
                a.on("click", function () {
                    ajax(url, sendData, successFn, errorFn);
                });
                self.panel.find(".area-panel > .msg").remove();
                self.panel.find(".area-panel").append($('<div class="msg">请求服务器失败.</div>').append(a));
                if ($.isFunction(errorFn)) errorFn();
            }
        })
    }
    // 创建I单个item

    // ----公共属性
    // 数据面板
    self.panel = $('<div class="tq-m-address"><div class="address-win"><div class="address-win-head"><div class="tab"></div><a class="close-btn" href="javascript:;">×</a></div><div class="area-panel"></div><div class="clear-float" /></div></div>');
    // 当前选中的数据
    self.selectData = [];
    // 当前选中的内容
    self.selectVal = "";

    self.panel.find(".close-btn").on("click",function(){
      self.panel.css('display', 'none')
    });

    // ----公共方法
    // 重置数据
    self.reset = function() {
      self.panel.find(".tab").empty();
      self.panel.find(".area-panel").empty();
      self.createTab(null, setting.defaultValue, "address");
    }

    // 创建Tab
    self.createTab = function(name, id, reqType) {
        if (reqType == "address") {
            var sendAddressData = {
                pid: id
            };
            ajax(setting.addressUrl, sendAddressData, function (data) {
                var addressData = data.Data;
                var sendSchoolData = {
                    area_id: id
                };
                ajax(setting.schoolUrl, sendSchoolData, function (data) {
                    self.createTabDom(name, addressData, data.Data, []);
                });
            });
        }
        else if (reqType == "school") {
            var sendPersonData = {
                sid: id
            };
            ajax(setting.personUrl, sendPersonData, function (data) {
                self.createTabDom(name, [], [], data.Data, "选择推介人");
            });
        }
    }

    // 创建标签对象
    self.createTabDom = function(name, addressData, schoolData, studendData, tabName) {
      self.panel.find(".tab > a:last").html(name);
      self.panel.find(".tab > a").removeClass("curr");
      // 渲染标题
      var tabLi = $('<a>' + (tabName || '请选择') + '</a>').appendTo(self.panel.find(".tab")).addClass("curr");
      var areaData = $("<div>").appendTo(self.panel.find(".area-panel"));
      // 渲染列表
      var areaList = $('<ul class="area-list"></ul>').appendTo(areaData);
      // 当前标签的所属位置
      var tabIndex = self.panel.find(".tab > a").size() - 1;
      // 标题点击触发的显示事件
      tabLi.data("areaData", areaData).on("click", function() {
        self.panel.find(".tab > a").removeClass("curr");
        $(this).addClass("curr");
        self.panel.find(".area-panel > div").css("display", "none");
        $(this).data("areaData").css("display", "block");
      });
      // 创建地址列表
      for(var i = 0,d = null;addressData && addressData.length && (d = addressData[i++]);) {
        // 增加标签对象
        var areaListLi = $('<li><a></a></li>').appendTo(areaList);
        // 给标签对象增加事件
        areaListLi.find("a").html(d["Name"]).on("click", { address: d, index: tabIndex, Name: d["Name"] }, function (e) {
          self.panel.find(".tab a:gt(" + e.data.index + ")").each(function() {
            $(this).data("areaData").remove();
            $(this).remove();
          });
          self.createTab(e.data.Name, e.data.address["Id"], "address"); // 点击后传输的数据
          self.selectData[e.data.index] = e.data.address;
          self.selectData.slice(e.data.index);
          var tempArr = [];
          for(var i = 0; i<= e.data.index; i++) {
            tempArr[i] = self.selectData[i];
          }
          self.selectData = tempArr;
          var names = $.map(self.selectData, function (d) { return d["Name"]; });
          //self.selectVal = names.join(" ");
          //if($.isFunction(setting.changeFn)) setting.changeFn($.extend([], self.selectData), self.selectVal);
        });
      }
      // 创建学校列表
      if(schoolData && schoolData.length) {
        var areaSchool = $('<div class="area-school"><div class="school-title">学校</div></div>').appendTo(areaData);
        var areaSchoolList = $('<ul class="area-list"></ul>').appendTo(areaSchool);
        for(var i = 0,d = null;d = schoolData[i++];) {
          // 增加标签对象
          var areaListLi = $('<li><a></a></li>').appendTo(areaSchoolList);
          // 给标签对象增加事件
          areaListLi.find("a").html(d["Name"]).on("click", { address: d, index: tabIndex, Name: d["Name"] }, function (e) {
            self.panel.find(".tab a:gt(" + e.data.index + ")").each(function() {
              $(this).data("areaData").remove();
              $(this).remove();
            });
            self.createTab(e.data.Name, e.data.address["Id"], "school"); // 点击后传输的数据
            self.selectData[e.data.index] = e.data.address;
            self.selectData.slice(e.data.index);
            var tempArr = [];
            for(var i = 0; i<= e.data.index; i++) {
              tempArr[i] = self.selectData[i];
            }
            self.selectData = tempArr;
            var names = $.map(self.selectData, function (d) { return d["Name"]; });
            //self.selectVal = names.join(" ");
            //if($.isFunction(setting.changeFn)) setting.changeFn($.extend([], self.selectData), self.selectVal);
          });
        }
      }
      // 创建学生列表
      for(var i = 0,d = null;studendData && studendData.length && (d = studendData[i++]);) {
        // 增加标签对象
        var areaListLi = $('<li><a></a></li>').appendTo(areaList);
        // 给标签对象增加事件
        areaListLi.find("a").html(d["FullName"]).on("click", { address: d, index: tabIndex, FullName: d["FullName"] }, function (e) {
          self.panel.find(".tab a:gt(" + e.data.index + ")").each(function() {
            $(this).data("areaData").remove();
            $(this).remove();
          });
          self.panel.css('display', 'none')
          self.selectData[e.data.index] = e.data.address;
          self.selectData.slice(e.data.index);
          var tempArr = [];
          for(var i = 0; i<= e.data.index; i++) {
            tempArr[i] = self.selectData[i];
          }
          self.selectData = tempArr;
          var names = $.map(self.selectData, function (d) { return d["FullName"]; });
          self.selectVal = names.join(" ");
          if ($.isFunction(setting.changeFn)) setting.changeFn($.extend([], self.selectData), e.data.FullName);
        });
      }
    }

    self.reset();
  };

  // 公开地址控制对象.
  var Address = function (domObj, config) {
    var dom = $(domObj)
    if (dom.size() <= 0 || dom[0]['___Address']) return
    dom[0]['___Address'] = true;
    config = config || {}
    var setting = {
      addressUrl: '', // Ajax 请求链接
      schoolUrl: '', // Ajax 请求链接
      personUrl: '', // Ajax 请求链接
      defaultValue: '0', // 默认请求的参数值
      type: 'get', // 请求的方式
      dataType: 'json', // 数据类型
      requestBefore: null, // 请求之前执行的方法
      requestAfter: null, // 请求之后执行的方法
      changeFn: null // 数据改变之后触发
    }
    var changeFn = config.changeFn;
    $.extend(setting, config, {
      changeFn: function(selectData, selectVal) {
        dom.val(selectVal);
        if($.isFunction(changeFn)) changeFn(selectData, selectVal);
      }
    });
    var addressDataPanel = new AddressDataPanel(setting);
    // 初始化地址面板
    var addressPanel = addressDataPanel.panel.appendTo('body')
    // 地址操作对象
    var addressAction = {
      // 释放
      release: function () {
        addressPanel.remove()
      },
      // 显示地址面板
      show: function () {
        var position = dom.position()
        var topPosition = position.top + dom.outerHeight()
        var leftPosition = position.left
        addressPanel.css({
          display: 'block'
        })
      },
      // 隐藏地址面板
      hidden: function () {
        addressPanel.css('display', 'none')
      },
      // 获取文本
      getValue: function() {
        return addressDataPanel.selectVal;
      },
      // 获取选中数据
      getDatas: function() {
        return $.extend([], addressDataPanel.selectData);
      }
    }
    dom.attr("readonly",  true);
    // 事件处理
    dom.on('click', function () {
      addressAction.show()
    })

    return addressAction; // 地址操作对象
  }
  $.fn.extend({
    bindAddress: function (config) {
      return Address(this, config)
    }
  })
})(jQuery)
