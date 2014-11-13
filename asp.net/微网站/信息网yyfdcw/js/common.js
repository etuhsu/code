$.extend({
     includePath: '',
     include: function(file) {
        var files = typeof file == "string" ? [file]:file;
        for (var i = 0; i < files.length; i++) {
            var name = files[i].replace(/^\s|\s$/g, "");
            var att = name.split('.');
            var ext = att[att.length - 1].toLowerCase();
            var isCSS = ext == "css";
            var tag = isCSS ? "link" : "script"; 
            var attr = isCSS ? " type='text/css' rel='stylesheet'  media='screen' " : " language='javascript' type='text/javascript' ";
            var link = (isCSS ? "href" : "src") + "='" + $.includePath + name + "'";
            if ($(tag + "[" + link + "]").length == 0) document.write("<" + tag + attr + link + "></" + tag + ">");
        }
   }
});   

//GA统计
var _gaq = _gaq || [];

//使用方法
$.includePath = '../';
$.include(['js/main.js','js/swipe.js','js/showpopup.js','js/jquery-impromptu.js','css/jquery-impromptu.css','css/main.css','css/add2home.css']);  

function getCookie(name) 
{ 
 var arr,reg=new RegExp("(^| )"+name+"=([^;]*)(;|$)");
 
 if(arr=document.cookie.match(reg))
 
  return unescape(arr[2]); 
 else 
  return null; 
}
function setCookie(name,value) 
{ 
 var Days = 1; 
 var exp = new Date(); 
 exp.setTime(exp.getTime() + Days*24*60*60*1000); 
 //exp.setTime(exp.getTime() + 30*1000);
 document.cookie = name + "="+ escape (value) +"; path=/;domain=house365.com;expires=" + exp.toGMTString(); 
}

function ismoblienum(phone){
	if(!(/^1[3|4|5|8][0-9]\d{4,8}$/.test(phone))){ 
		 
		return false;
	 }
	 return true;
}

 
function isrealname(str){
var reg = /^[\u4e00-\u9fa5]*$/i;
   
   if(reg.test(str)){
       return true;
    }
	return false;
}
/**
*保留小数点
*/
function fomatFloat(src,pos){     
   return Math.round(src*Math.pow(10, pos))/Math.pow(10, pos);     
}   
function toDecimal(x) {   
    var f = parseFloat(x);   
    if (isNaN(f)) {   
        return;   
    }   
    f = Math.round(x*100)/100;   
    return f;   
}   
function getDate(s){
	var regexp=/^(\d{1,4})[-]{1}(\d{1,2})[-]{1}(\d{1,2})$/;
	regexp.test(s);
    var date1Year=RegExp.$1;
    var date1Month=RegExp.$2;
    var date1Day=RegExp.$3;
    return new Date(date1Year,date1Month-1,date1Day);

}
function getRangeDate(date1,date2){
   var firstDate=getDate(date1);
   var secondDate=getDate(date2);
   return (secondDate - firstDate) / 86400000;
}
Date.prototype.format = function(format)
{
    var o =
    {
        "M+" : this.getMonth()+1, //month
        "d+" : this.getDate(),    //day
        "h+" : this.getHours(),   //hour
        "m+" : this.getMinutes(), //minute
        "s+" : this.getSeconds(), //second
        "q+" : Math.floor((this.getMonth()+3)/3),  //quarter
        "S" : this.getMilliseconds() //millisecond
    }
    if(/(y+)/.test(format))
    format=format.replace(RegExp.$1,(this.getFullYear()+"").substr(4 - RegExp.$1.length));
    for(var k in o)
    if(new RegExp("("+ k +")").test(format))
    format = format.replace(RegExp.$1,RegExp.$1.length==1 ? o[k] : ("00"+ o[k]).substr((""+ o[k]).length));
    return format;
}
function strToJson(str){ 
	var json = eval('(' + str + ')'); 
	return json; 
} 
 
//检查checkbox 是否有选中
function isCheckbox(cid){
var c = 0;
$("input[name='"+cid+"']:checkbox").each(function(){ 
             if($(this).attr("checked")){
                // str += $(this).val()+","
               	c++;  
             }
         })
       if(c>0){
       	return true;
       }else{
       	return false;
       }
}
//获取checkbox选中值
function getCheckboxVal(cid){
var str = "";
	$("input[name='"+cid+"']:checkbox").each(function(){ 
              if($(this).attr("checked")){
                  str += $(this).val()+","
              }
          })
    return str;
} 
//回顶部
function gotop(){
  window.scrollTo(0, 1);
}

function goback(){
  return window.history.go(-1);
}

function refresh(){
  window.location.reload();
}
function gohome(){
  window.location='?app=index';
}
function gourl(url){
  window.location=url;
}

function go_newhouse_detail_url(id,p,origin){
  if (origin) {
  window.location='?app=newhouse&act=detail&p='+p+'&id='+id+'&origin=weijia';
  } else {
  window.location='?app=newhouse&act=detail&p='+p+'&id='+id;
  }
}
function go_sellhouse_block_url(id){
  window.location='?app=sellhouse&blockid='+id;
}
function go_renthouse_block_url(id){
  window.location='?app=renthouse&blockid='+id;
}

function addFavorite(sURL, sTitle)  //加入收藏
{
  try {
    window.external.addFavorite(sURL, sTitle);
  }
  catch (e) {
    try {
      window.sidebar.addPanel(sTitle, sURL, "");
    }
    catch (e) {
      //alert("加入收藏失败，请使用Ctrl+D进行添加");
    }
  }
}

function showtopnav(){
  $("#topnav_menu").toggle();
}
function hidetopnav(){
  $("#topnav_menu").hide();  
}

function getQueryParamValue(queryString, key) {  
  var result = queryString.match(new RegExp('(?:^|&)' + key + '=(.*?)(?=$|&)'));  
  return result && result[1];  
}
//设置url参数新值
function setQueryParamValue(queryString, key, newValue) {  
  var replaced = false;  
  var newParam = key + '=' + newValue;  
  var result = queryString.replace(new RegExp('(^|&)' + key + '=(.*?)(?=$|&)', 'g'), function (s, p1, p2) {  
    replaced = true;  
    return p1 + newParam;  
  });  
  return replaced && result || queryString && (queryString + '&' + newParam) || newParam;  
}

//得到查询字符串参数集合  
function GetUrlParms() {  
  var args = new Object();  
  var query = location.search.substring(1); //获取查询串     
  var pairs = query.split("&"); //在逗号处断开     
  for (var i = 0; i < pairs.length; i++) {  
	  var pos = pairs[i].indexOf('='); //查找name=value     
	  if (pos == -1) continue; //如果没有找到就跳过     
	  var argname = pairs[i].substring(0, pos); //提取name     
	  var value = pairs[i].substring(pos + 1); //提取value     
	  args[argname] = unescape(value); //存为属性     
  }  
  return args;  
}

  //修改URL参数，parms：参数名，parmsValue：参数值，return：修改后的URL  
  function updateParms(parms, parmsValue) {  
	  var newUrlParms = "";  
	  var newUrlBase = location.href.substring(0, location.href.indexOf("?") + 1); //截取查询字符串前面的url  
	  var query = location.search.substring(1); //获取查询串     
	  var pairs = query.split("&"); //在逗号处断开     
	  for (var i = 0; i < pairs.length; i++) {  
		  var pos = pairs[i].indexOf('='); //查找name=value     
		  if (pos == -1) continue; //如果没有找到就跳过     
		  var argname = pairs[i].substring(0, pos); //提取name     
		  var value = pairs[i].substring(pos + 1); //提取value   
		  //如果找到了要修改的参数  
		  if (findText(argname, parms)) {  
			  newUrlParms = newUrlParms + (argname + "=" + parmsValue + "&");  
		  }  
		  else {  
			  newUrlParms += (argname + "=" + value + "&");  
		  }  
	  }  
	  return newUrlBase + newUrlParms.substring(0, newUrlParms.length - 1);  
  }

   //辅助方法  
  function findText(urlString, keyWord) {  
	  return urlString.toLowerCase().indexOf(keyWord.toLowerCase()) != -1 ? true : false;  
  }  

 //设置URL参数的方法  
function setParmsValue(parms, parmsValue) {  
          var urlstrings = document.URL;  
          var args = GetUrlParms();  
          var values = args[parms];  
          //如果参数不存在，则添加参数         
          if (values == undefined) {  
              var query = location.search.substring(1); //获取查询串   
              //如果Url中已经有参数，则附加参数  
              if (query) {  
                  urlstrings += ("&" + parms + "=" + parmsValue);  
              }  
              else {  
                  urlstrings += ("?" + parms + "=" + parmsValue);  //向Url中添加第一个参数  
              }  
              window.location = urlstrings;  
          }  
          else {  
              window.location = updateParms(parms, parmsValue);  //修改参数  
          }  
}
//替换url参数
function replaceUrlParam(key, newValue) {
var queryString=document.location.href;
var newurl = setQueryParamValue(queryString,key, newValue);
//alert(newurl);
document.location.href=newurl;
}
//删除url参数
function delQueStr(url, ref) {
            var str = "";
            if (url.indexOf('?') != -1) {
                str = url.substr(url.indexOf('?') + 1);
            }
            else {
                return url;
            }
            var arr = "";
            var returnurl = "";
            var setparam = "";
            if (str.indexOf('&') != -1) {
                arr = str.split('&');
                for (i in arr) {
                    if (arr[i].split('=')[0] != ref) {
                        returnurl = returnurl + arr[i].split('=')[0] + "=" + arr[i].split('=')[1] + "&";
                    }
                }
                return url.substr(0, url.indexOf('?')) + "?" + returnurl.substr(0, returnurl.length - 1);
            }
            else {
                arr = str.split('=');
                if (arr[0] == ref) {
                    return url.substr(0, url.indexOf('?'));
                }
                else {
                    return url;
                }
            }
}
function DeleteParam(name) {
   var i = location.href;
   var reg = new RegExp("([&\?]?)" + name + "=[^&]+(&?)", "g")
   var newUrl = i.replace(reg, function (a, b, c) {
    if (c.length == 0) {return '';}
    else {return b;}
   });
   return newUrl;
}
function removeUrlParam(name) {
	var url = location.href;
   var tempurl = delQueStr(url,name);
   document.location.href=tempurl;
}

//设置排序url参数
function setOrderParam(key, newValue) {
var queryString=document.location.href;
var ordered = getQueryParamValue(queryString, key);
//alert(ordered);
var temporder=newValue;
if(newValue<4){
	if(ordered==2){
		temporder=3;
		//$("#order_price").removeClass();
		 
	}else if(ordered==3){
		temporder=2; 
		 
	}
}else{
if(ordered==4){
	temporder=5;
	 
}else if(ordered==5){
	temporder=4;
	 
}else if(ordered!=newValue){
	temporder=newValue;
}
}
//alert(temporder);
replaceUrlParam(key, temporder);
}

//设置排序的样式
function initOrderParam(){
var queryString=document.location.href;
var ordered = getQueryParamValue(queryString, "ordered");
if(ordered==2){ 
	$("#order_price").addClass("selected");
	$("#order_price i").addClass("icon-up");
	$("#order_time").removeClass();
}else if(ordered==3){ 
	$("#order_price").addClass("selected");
	$("#order_price i").addClass("icon-down");
	$("#order_time").removeClass();
}else if(ordered==4){ 
	$("#order_price").removeClass();
	$("#order_time").addClass("selected");
	$("#order_time i").addClass("icon-up");
}else if(ordered==5){ 
	$("#order_price").removeClass();
	$("#order_time").addClass("selected");
	$("#order_time i").addClass("icon-down");
}else{

	$("#order_price").removeClass();
	$("#order_time").removeClass();
	$("#order_price i").addClass("icon-up");
	$("#order_time i").addClass("icon-up");

}

}



/*
 * MAP对象，实现MAP功能
 *
 * 接口：
 * size()     获取MAP元素个数
 * isEmpty()    判断MAP是否为空
 * clear()     删除MAP所有元素
 * put(key, value)   向MAP中增加元素（key, value) 
 * remove(key)    删除指定KEY的元素，成功返回True，失败返回False
 * get(key)    获取指定KEY的元素值VALUE，失败返回NULL
 * element(index)   获取指定索引的元素（使用element.key，element.value获取KEY和VALUE），失败返回NULL
 * containsKey(key)  判断MAP中是否含有指定KEY的元素
 * containsValue(value) 判断MAP中是否含有指定VALUE的元素
 * values()    获取MAP中所有VALUE的数组（ARRAY）
 * keys()     获取MAP中所有KEY的数组（ARRAY）
 *
 * 例子：
 * var map = new Map();
 *
 * map.put("key", "value");
 * var val = map.get("key")
 * ……
 *
 */
function Map() {
	this.elements = new Array();

	//获取MAP元素个数
	this.size = function() {
		return this.elements.length;
	}

	//判断MAP是否为空
	this.isEmpty = function() {
		return (this.elements.length < 1);
	}

	//删除MAP所有元素
	this.clear = function() {
		this.elements = new Array();
	}

	//向MAP中增加元素（key, value) 
	this.put = function(_key, _value) {
		this.elements.push( {
			key : _key,
			value : _value
		});
	}

	//删除指定KEY的元素，成功返回True，失败返回False
	this.remove = function(_key) {
		var bln = false;
		try {
			for (i = 0; i < this.elements.length; i++) {
				if (this.elements[i].key == _key) {
					this.elements.splice(i, 1);
					return true;
				}
			}
		} catch (e) {
			bln = false;
		}
		return bln;
	}

	//获取指定KEY的元素值VALUE，失败返回NULL
	this.get = function(_key) {
		try {
			for (i = 0; i < this.elements.length; i++) {
				if (this.elements[i].key == _key) {
					return this.elements[i].value;
				}
			}
		} catch (e) {
			return null;
		}
	}

	//获取指定索引的元素（使用element.key，element.value获取KEY和VALUE），失败返回NULL
	this.element = function(_index) {
		if (_index < 0 || _index >= this.elements.length) {
			return null;
		}
		return this.elements[_index];
	}

	//判断MAP中是否含有指定KEY的元素
	this.containsKey = function(_key) {
		var bln = false;
		try {
			for (i = 0; i < this.elements.length; i++) {
				if (this.elements[i].key == _key) {
					bln = true;
				}
			}
		} catch (e) {
			bln = false;
		}
		return bln;
	}

	//判断MAP中是否含有指定VALUE的元素
	this.containsValue = function(_value) {
		var bln = false;
		try {
			for (i = 0; i < this.elements.length; i++) {
				if (this.elements[i].value == _value) {
					bln = true;
				}
			}
		} catch (e) {
			bln = false;
		}
		return bln;
	}

	//获取MAP中所有VALUE的数组（ARRAY）
	this.values = function() {
		var arr = new Array();
		for (i = 0; i < this.elements.length; i++) {
			arr.push(this.elements[i].value);
		}
		return arr;
	}

	//获取MAP中所有KEY的数组（ARRAY）
	this.keys = function() {
		var arr = new Array();
		for (i = 0; i < this.elements.length; i++) {
			arr.push(this.elements[i].key);
		}
		return arr;
	}
}


 $.fn.extend({
    goTop: function () {
       var $this = this;
        $this.bind("click", function () {
            $("body,html").animate({ scrollTop: 0 }, 150);
        });

        $("body")
        .add($(window))
        .bind("scroll", function () {
            var st = $(document).scrollTop();
            (st > 100) ? $this.fadeIn(500) : $this.fadeOut(500);
        });
    }

    
});


//自定义的js alert弹窗

function sAlert(str){ 
  var msgw,msgh,bordercolor; 
  msgw=400;//Width
  msgh=100;//Height 
  titleheight=25 //title Height
  bordercolor="#336699";//boder color
  titlecolor="#99CCFF";//title color
 
  var sWidth,sHeight; 
  sWidth=document.body.offsetWidth; 
  sHeight=screen.height; 
  var bgObj=document.createElement("div"); 
  bgObj.setAttribute('id','bgDiv'); 
  bgObj.style.position="absolute"; 
  bgObj.style.top="0"; 
  bgObj.style.background="#777"; 
  bgObj.style.filter="progid:DXImageTransform.Microsoft.Alpha(style=3,opacity=25,finishOpacity=75"; 
  bgObj.style.opacity="0.6"; 
  bgObj.style.left="0"; 
  bgObj.style.width=sWidth + "px"; 
  bgObj.style.height=sHeight + "px"; 
  bgObj.style.zIndex = "10000"; 
  document.body.appendChild(bgObj); 
   
  var msgObj=document.createElement("div") 
  msgObj.setAttribute("id","msgDiv"); 
  msgObj.setAttribute("align","center"); 
  msgObj.style.background="white"; 
  msgObj.style.border="1px solid " + bordercolor; 
  msgObj.style.position = "fixed"; 
  msgObj.style.left = "50%"; 
  msgObj.style.top = "50%"; 
  msgObj.style.font="12px/1.6em Verdana, Geneva, Arial, Helvetica, sans-serif"; 
  msgObj.style.marginLeft = "-225px" ; 
  msgObj.style.marginTop = -75+document.documentElement.scrollTop+"px"; 
  msgObj.style.width = msgw + "px"; 
  msgObj.style.height =msgh + "px"; 
  msgObj.style.textAlign = "center"; 
  msgObj.style.lineHeight ="25px"; 
  msgObj.style.zIndex = "10001"; 
   
  var title=document.createElement("h4"); 
  title.setAttribute("id","msgTitle"); 
  title.setAttribute("align","right"); 
  title.style.margin="0"; 
  title.style.padding="3px"; 
  title.style.background=bordercolor; 
  title.style.filter="progid:DXImageTransform.Microsoft.Alpha(startX=20, startY=20, finishX=100, finishY=100,style=1,opacity=75,finishOpacity=100);"; 
  title.style.opacity="0.75"; 
  title.style.border="1px solid " + bordercolor; 
  title.style.height="18px"; 
  title.style.font="12px Verdana, Geneva, Arial, Helvetica, sans-serif"; 
  title.style.color="white"; 
  title.style.cursor="pointer"; 
  title.innerHTML="关闭"; 
  title.onclick=function(){ 
	 document.body.removeChild(bgObj); 
	 document.getElementById("msgDiv").removeChild(title); 
	 document.body.removeChild(msgObj); 
   } 
  document.body.appendChild(msgObj); 
  document.getElementById("msgDiv").appendChild(title); 
  var txt=document.createElement("p"); 
  txt.style.margin="1em 0" 
  txt.setAttribute("id","msgTxt"); 
  txt.innerHTML=str; 
  document.getElementById("msgDiv").appendChild(txt); 
} 