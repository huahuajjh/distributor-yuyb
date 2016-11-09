//获得系统时间和日期
function ShowCurTime(objName) {
    var weekArray = ["星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六"];
    var curDate = new Date();
    var curDay = curDate.getDay();
    var obj = document.getElementById(objName);
    var dateInfo=curDate.getYear() + "年" + (curDate.getMonth() + 1) + "月" + curDate.getDate() + "日 " + weekArray[curDay];
    if (obj != null) {
        obj.innerHTML = dateInfo;
    }
    else {
        document.write(dateInfo);
    }
}