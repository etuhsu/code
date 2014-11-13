// JavaScript Document
function Ajax(method, url, parm, callback, bool) {
    var xmlHttp = false;
    if (window.ActiveXObject) {
        xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
    }
    else if (window.XMLHttpRequest) {
        xmlHttp = new XMLHttpRequest();
    }
    xmlHttp.onreadystatechange = function () {
        if (xmlHttp.readyState == 4) {
            if (xmlHttp.status == 200) {
                callback(xmlHttp);
                xmlHttp = null;
            }
            else {
                document.write(xmlHttp.status + "：" + xmlHttp.responseText);
            }
        }
    }
    xmlHttp.open(method, url, bool);
    xmlHttp.setRequestHeader("Content-Type", "application/x-www-form-urlencoded;charset=gb2312");
    xmlHttp.send(parm);
    if (navigator.userAgent.indexOf("Firefox") > 0)
        callback(xmlHttp);
}

var isAjax = true;
var objPosition;
//Ajax查询对应类别的关键词按照点击量排序
function checkAndShow(obj) {
    if (typeof (isFirstKeyWords) != "undefined") {
        if (isFirstKeyWords == 1) {
            isFirstKeyWords = 0;
            return;
        }
    }
    if (!isAjax) {
        return;
    }
    objPosition = document.getElementById("txtKeyWord");
    var strKey = escape(objPosition.value.replace('<', '').replace('>', ''));
    if (objPosition.value.replace('<', '').replace('>', '') == '请填写关键词或选择职位' || objPosition.value.replace('<', '').replace('>', '') == '请填写关键词或选择职位...') {
        objPosition.value = "";
        return;
    }
    if (strKey.length > 0) {
        Ajax("post", "/personal/js/AjaxGetKeyWords", "key=" + strKey, GenKeyWordDiv, true);
    }
    else {
        $("#tips").hide();
        $("#txtKeyWord").css("font-weight", "normal");
    }
}

//接收Ajax数据，拼接HTML
function GenKeyWordDiv(obj) {
    selectedIndex = -1;
    var data = unescape(obj.responseText);
    var strKeyWord = "";
    var strResaultNumber = "";
    var strAttributeName = "";
    var strAttributeValue = "";
    var strHtml = '<ul>';
    if (data == "") {
        $("#tips").hide();
    }
    else {
        var array = data.split("}*{");
        $("TempKey").value = objPosition.value;
        $("#txtKeyWord").css("font-weight", "bold");
        for (intTmp = 0; intTmp < array.length; intTmp++) {
            var arrKeyAndNumber = array[intTmp].split("]*[");
            addOption(arrKeyAndNumber);
        }
        strHtml += "</ul><div class=\"closeline\"><a class=\"btnclose\" onclick=\"closeTip()\" href=\"javascript:void(0)\">关闭</a></div>";
        $("#tips").html(strHtml);
        $("#tips").width($("#txtKeyWord").width() - $(".submit").width() + 30);
        $("#tips").show();
        //生成弹出层的HTML
        function addOption(arrKeyAndNumber) {
            strKeyWord = arrKeyAndNumber[0];
            var strTempValue = "txtKeyWord";
            strResaultNumber = arrKeyAndNumber[1];
            strHtml += "<li onclick='closeTip()'><div class=\"KeyWordDiv\"";
            //strHtml += " onmouseover=\"this.className='KeywordSelected'\"";
            //strHtml += " onmouseout=\"this.className='KeyWordDiv'\"";
            strHtml += " onmousedown=\"isAjax = false;document.getElementById('" + strTempValue + "').value='" + strKeyWord + "'\">";
            strHtml += "<div style=\"float:left; font-weight:bold; padding-left:3px;display:block;white-space:nowrap;text-overflow:ellipsis;overflow:hidden;width:47%\">" + strKeyWord + "</div>";
            strHtml += "<div style=\"float:right; font-size:12px; padding-right:8px;\">约" + strResaultNumber + "个结果</div>";
            strHtml += "</div></li>";
        }
    }
}

//判断按下的按键
function checkKeyCode(evt, obj) {
    var intTmp;
    evt = evt || window.event;
    var keyCode = window.event ? evt.keyCode : evt.which;
    if (keyCode == 40 || keyCode == 38) {
        isAjax = false;
        //下上
        var isUp = false;
        if (keyCode == 40)
            isUp = true;
        chageSelection(isUp, intTmp);
    }
    else if (keyCode == 13) {
        isAjax = false;
        //回车
        if (selectedIndex != -1)
            outSelection(selectedIndex);
    }
    else {
        isAjax = true;
        if (keyCode == 8)
            checkAndShow();
    }
}

//更改选择项
function chageSelection(isUp, intTmp) {
    if (isUp)
        selectedIndex++;
    else
        selectedIndex--;
    var maxIndex = $("KeysList").childNodes.length;
    if (selectedIndex < 0)
        selectedIndex = maxIndex - 2;
    if (selectedIndex > maxIndex - 2 || selectedIndex == 0)
        selectedIndex = 1;
    for (intTmp = 1; intTmp <= maxIndex - 2; intTmp++) {
        if (intTmp == selectedIndex) {
            //当上下键移动时，将选中的文本写到文本框中
            if (selectedIndex != maxIndex)
                objPosition.value = $("KeysList").childNodes[intTmp].childNodes[0].innerHTML;
            else {
                objPosition.value = $('TempKey').value
            }
            if (selectedIndex != maxIndex)
                $("KeysList").childNodes[intTmp].className = "KeywordSelected";
        }
        else {
            if (intTmp != maxIndex)
                $("KeysList").childNodes[intTmp].className = "";
        }
    }
}

//将选项赋值给输入框
function outSelection(Index) {
    objPosition.value = $("keysList").childNodes[Index].childNodes[0].innerHTML;
} 