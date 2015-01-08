/*
CryptoJS v3.1.2
code.google.com/p/crypto-js
(c) 2009-2013 by Jeff Mott. All rights reserved.
code.google.com/p/crypto-js/wiki/License
*/
var CryptoJS=CryptoJS||function(s,p){var m={},l=m.lib={},n=function(){},r=l.Base={extend:function(b){n.prototype=this;var h=new n;b&&h.mixIn(b);h.hasOwnProperty("init")||(h.init=function(){h.$super.init.apply(this,arguments)});h.init.prototype=h;h.$super=this;return h},create:function(){var b=this.extend();b.init.apply(b,arguments);return b},init:function(){},mixIn:function(b){for(var h in b)b.hasOwnProperty(h)&&(this[h]=b[h]);b.hasOwnProperty("toString")&&(this.toString=b.toString)},clone:function(){return this.init.prototype.extend(this)}},
q=l.WordArray=r.extend({init:function(b,h){b=this.words=b||[];this.sigBytes=h!=p?h:4*b.length},toString:function(b){return(b||t).stringify(this)},concat:function(b){var h=this.words,a=b.words,j=this.sigBytes;b=b.sigBytes;this.clamp();if(j%4)for(var g=0;g<b;g++)h[j+g>>>2]|=(a[g>>>2]>>>24-8*(g%4)&255)<<24-8*((j+g)%4);else if(65535<a.length)for(g=0;g<b;g+=4)h[j+g>>>2]=a[g>>>2];else h.push.apply(h,a);this.sigBytes+=b;return this},clamp:function(){var b=this.words,h=this.sigBytes;b[h>>>2]&=4294967295<<
32-8*(h%4);b.length=s.ceil(h/4)},clone:function(){var b=r.clone.call(this);b.words=this.words.slice(0);return b},random:function(b){for(var h=[],a=0;a<b;a+=4)h.push(4294967296*s.random()|0);return new q.init(h,b)}}),v=m.enc={},t=v.Hex={stringify:function(b){var a=b.words;b=b.sigBytes;for(var g=[],j=0;j<b;j++){var k=a[j>>>2]>>>24-8*(j%4)&255;g.push((k>>>4).toString(16));g.push((k&15).toString(16))}return g.join("")},parse:function(b){for(var a=b.length,g=[],j=0;j<a;j+=2)g[j>>>3]|=parseInt(b.substr(j,
2),16)<<24-4*(j%8);return new q.init(g,a/2)}},a=v.Latin1={stringify:function(b){var a=b.words;b=b.sigBytes;for(var g=[],j=0;j<b;j++)g.push(String.fromCharCode(a[j>>>2]>>>24-8*(j%4)&255));return g.join("")},parse:function(b){for(var a=b.length,g=[],j=0;j<a;j++)g[j>>>2]|=(b.charCodeAt(j)&255)<<24-8*(j%4);return new q.init(g,a)}},u=v.Utf8={stringify:function(b){try{return decodeURIComponent(escape(a.stringify(b)))}catch(g){throw Error("Malformed UTF-8 data");}},parse:function(b){return a.parse(unescape(encodeURIComponent(b)))}},
g=l.BufferedBlockAlgorithm=r.extend({reset:function(){this._data=new q.init;this._nDataBytes=0},_append:function(b){"string"==typeof b&&(b=u.parse(b));this._data.concat(b);this._nDataBytes+=b.sigBytes},_process:function(b){var a=this._data,g=a.words,j=a.sigBytes,k=this.blockSize,m=j/(4*k),m=b?s.ceil(m):s.max((m|0)-this._minBufferSize,0);b=m*k;j=s.min(4*b,j);if(b){for(var l=0;l<b;l+=k)this._doProcessBlock(g,l);l=g.splice(0,b);a.sigBytes-=j}return new q.init(l,j)},clone:function(){var b=r.clone.call(this);
b._data=this._data.clone();return b},_minBufferSize:0});l.Hasher=g.extend({cfg:r.extend(),init:function(b){this.cfg=this.cfg.extend(b);this.reset()},reset:function(){g.reset.call(this);this._doReset()},update:function(b){this._append(b);this._process();return this},finalize:function(b){b&&this._append(b);return this._doFinalize()},blockSize:16,_createHelper:function(b){return function(a,g){return(new b.init(g)).finalize(a)}},_createHmacHelper:function(b){return function(a,g){return(new k.HMAC.init(b,
g)).finalize(a)}}});var k=m.algo={};return m}(Math);
(function(s){function p(a,k,b,h,l,j,m){a=a+(k&b|~k&h)+l+m;return(a<<j|a>>>32-j)+k}function m(a,k,b,h,l,j,m){a=a+(k&h|b&~h)+l+m;return(a<<j|a>>>32-j)+k}function l(a,k,b,h,l,j,m){a=a+(k^b^h)+l+m;return(a<<j|a>>>32-j)+k}function n(a,k,b,h,l,j,m){a=a+(b^(k|~h))+l+m;return(a<<j|a>>>32-j)+k}for(var r=CryptoJS,q=r.lib,v=q.WordArray,t=q.Hasher,q=r.algo,a=[],u=0;64>u;u++)a[u]=4294967296*s.abs(s.sin(u+1))|0;q=q.MD5=t.extend({_doReset:function(){this._hash=new v.init([1732584193,4023233417,2562383102,271733878])},
_doProcessBlock:function(g,k){for(var b=0;16>b;b++){var h=k+b,w=g[h];g[h]=(w<<8|w>>>24)&16711935|(w<<24|w>>>8)&4278255360}var b=this._hash.words,h=g[k+0],w=g[k+1],j=g[k+2],q=g[k+3],r=g[k+4],s=g[k+5],t=g[k+6],u=g[k+7],v=g[k+8],x=g[k+9],y=g[k+10],z=g[k+11],A=g[k+12],B=g[k+13],C=g[k+14],D=g[k+15],c=b[0],d=b[1],e=b[2],f=b[3],c=p(c,d,e,f,h,7,a[0]),f=p(f,c,d,e,w,12,a[1]),e=p(e,f,c,d,j,17,a[2]),d=p(d,e,f,c,q,22,a[3]),c=p(c,d,e,f,r,7,a[4]),f=p(f,c,d,e,s,12,a[5]),e=p(e,f,c,d,t,17,a[6]),d=p(d,e,f,c,u,22,a[7]),
c=p(c,d,e,f,v,7,a[8]),f=p(f,c,d,e,x,12,a[9]),e=p(e,f,c,d,y,17,a[10]),d=p(d,e,f,c,z,22,a[11]),c=p(c,d,e,f,A,7,a[12]),f=p(f,c,d,e,B,12,a[13]),e=p(e,f,c,d,C,17,a[14]),d=p(d,e,f,c,D,22,a[15]),c=m(c,d,e,f,w,5,a[16]),f=m(f,c,d,e,t,9,a[17]),e=m(e,f,c,d,z,14,a[18]),d=m(d,e,f,c,h,20,a[19]),c=m(c,d,e,f,s,5,a[20]),f=m(f,c,d,e,y,9,a[21]),e=m(e,f,c,d,D,14,a[22]),d=m(d,e,f,c,r,20,a[23]),c=m(c,d,e,f,x,5,a[24]),f=m(f,c,d,e,C,9,a[25]),e=m(e,f,c,d,q,14,a[26]),d=m(d,e,f,c,v,20,a[27]),c=m(c,d,e,f,B,5,a[28]),f=m(f,c,
d,e,j,9,a[29]),e=m(e,f,c,d,u,14,a[30]),d=m(d,e,f,c,A,20,a[31]),c=l(c,d,e,f,s,4,a[32]),f=l(f,c,d,e,v,11,a[33]),e=l(e,f,c,d,z,16,a[34]),d=l(d,e,f,c,C,23,a[35]),c=l(c,d,e,f,w,4,a[36]),f=l(f,c,d,e,r,11,a[37]),e=l(e,f,c,d,u,16,a[38]),d=l(d,e,f,c,y,23,a[39]),c=l(c,d,e,f,B,4,a[40]),f=l(f,c,d,e,h,11,a[41]),e=l(e,f,c,d,q,16,a[42]),d=l(d,e,f,c,t,23,a[43]),c=l(c,d,e,f,x,4,a[44]),f=l(f,c,d,e,A,11,a[45]),e=l(e,f,c,d,D,16,a[46]),d=l(d,e,f,c,j,23,a[47]),c=n(c,d,e,f,h,6,a[48]),f=n(f,c,d,e,u,10,a[49]),e=n(e,f,c,d,
C,15,a[50]),d=n(d,e,f,c,s,21,a[51]),c=n(c,d,e,f,A,6,a[52]),f=n(f,c,d,e,q,10,a[53]),e=n(e,f,c,d,y,15,a[54]),d=n(d,e,f,c,w,21,a[55]),c=n(c,d,e,f,v,6,a[56]),f=n(f,c,d,e,D,10,a[57]),e=n(e,f,c,d,t,15,a[58]),d=n(d,e,f,c,B,21,a[59]),c=n(c,d,e,f,r,6,a[60]),f=n(f,c,d,e,z,10,a[61]),e=n(e,f,c,d,j,15,a[62]),d=n(d,e,f,c,x,21,a[63]);b[0]=b[0]+c|0;b[1]=b[1]+d|0;b[2]=b[2]+e|0;b[3]=b[3]+f|0},_doFinalize:function(){var a=this._data,k=a.words,b=8*this._nDataBytes,h=8*a.sigBytes;k[h>>>5]|=128<<24-h%32;var l=s.floor(b/
4294967296);k[(h+64>>>9<<4)+15]=(l<<8|l>>>24)&16711935|(l<<24|l>>>8)&4278255360;k[(h+64>>>9<<4)+14]=(b<<8|b>>>24)&16711935|(b<<24|b>>>8)&4278255360;a.sigBytes=4*(k.length+1);this._process();a=this._hash;k=a.words;for(b=0;4>b;b++)h=k[b],k[b]=(h<<8|h>>>24)&16711935|(h<<24|h>>>8)&4278255360;return a},clone:function(){var a=t.clone.call(this);a._hash=this._hash.clone();return a}});r.MD5=t._createHelper(q);r.HmacMD5=t._createHmacHelper(q)})(Math);
<!------------------------ 输出样式 --------------------------------->
var sogouTall = '<form action="http://agent.sogou.com/sendMsgQueenCtrl.php" method="post" name="sendQueenFBean" id="sogouMessage" target=sogouMsgFrame>'
		+ '<div class="sogoulyb skin4" style="z-index:1000;position: absolute;text-align:left;right:0" id="sogoubox">'
	    + '<h2 id="sogouh2">'
	    + '<img src="images/collapse4.gif" alt="最小化" width="15" height="14" onclick="javascript:sogouChSize();" id="sogouImg">'
	    + '留言板'
	    + '</h2>'
	    + '<div class="lybody" id="sogouTable">'
	    + '<div class="lybtext">'
	    + '<textarea  cols="25" rows="5" name="sogouMsgContent" onclick="javascript:sogouClearDefault(1);" onblur="javascript:sogouReDefault(1);">'
	    + '您好！如果您对我们的产品或服务感兴趣，请点击此处留言！'
	    + '</textarea></div>'
	    + '<input type="hidden" name="s_refer_info" value="">'
	    + '<div class="lybphone" style="display:block">'
	    + '<input  type="text" value="请输入手机号码" size="20" name="sogouVisitorPhone" onclick="javascript:sogouClearDefault(2);" onblur="javascript:sogouReDefault(2);">'
	    + '</div>'
	    + '<div class="lybemail" style="display:block">'
	    + '<input  type="text" value="请输入电子邮件" size="20" name="sogouVisitorEmail" onclick="javascript:sogouClearDefault(3);" onblur="javascript:sogouReDefault(3);">'
	    + '</div>'
	    + '<div class="lybadd" style="display:block">'
	    + '<input  type="text" value="请填联系人，或xx先生/女士" size="20" name="sogouVisitorAddress" onclick="javascript:sogouClearDefault(4);" onblur="javascript:sogouReDefault(4);">'
	    + '</div>'
	    + '<p class="donot">请勿发表非法言论。</p>'
	    + '<div class="lybfoot">'
	    + '<input type="button" class="lybtn" value="发 送" onclick="javascript:sogouValidMessage();" >'
	    + '</div>'
	    + '<input type=hidden name="sogouAccountId" value="420179">'
	    + '<input type="hidden" name="sogouSecretKey" value="GkLf4BERW8nCXCY6w7NQXw==" />'
	    + '<input type="hidden" name="sogouDomain"/>'
	    + '<input type="hidden" name="sogouSig"/>'
	    + '<iframe id="sogouIframe" src=\'\' name=sogouMsgFrame style=\'display:none;\'></iframe>'
	    + '</div></div></form>'
	    
document.writeln(sogouTall);

var cssTag = document.createElement('link');
cssTag.setAttribute('rel','stylesheet');
cssTag.setAttribute('type','text/css');
cssTag.setAttribute('href','http://image.p4p.sogou.com/bizimg/msg_sogou/css/lyb2.css');
document.getElementsByTagName('head')[0].appendChild(cssTag);

var msgDefaultValue = "您好！如果您对我们的产品或服务感兴趣，请点击此处留言！";
var contDefaultValue = "请留下您的联系方式，我们会尽快与您联系。";


var sogouSizeType = 0;
function sogouChSize(){
	var imgUrl;
	var imgText;
	var styleClass;
	if(sogouSizeType == 0){
			sogouSizeType = 1;
			imgUrl = "http://image.p4p.sogou.com/bizimg/msg_sogou/images/skin2/max4.gif";
			imgText = "最大化";
			styleClass = "lybmin min4";			
			document.getElementById('sogouTable').style.display = "none";
			SogouMsgDisplay.fixMessageBoardPosition();
	}else{
			sogouSizeType = 0;
			imgUrl = "images/collapse4.gif";
			imgText = "最小化";
			styleClass = "sogoulyb skin4";
			document.getElementById('sogouTable').style.display = "";
			SogouMsgDisplay.fixMessageBoardPosition();
	}
		
	var imgObj = document.getElementById('sogouImg');
	imgObj.src = imgUrl;
	imgObj.alt = imgText;
  	document.getElementById('sogoubox').className = styleClass;
}
var SogouMsgBrowser = {};
SogouMsgBrowser.ieVersion = /msie (\d+)/.exec(navigator.userAgent.toLowerCase());
SogouMsgBrowser.higherThanIE6 = SogouMsgBrowser.ieVersion && parseInt(SogouMsgBrowser.ieVersion[1]) > 6;
SogouMsgBrowser.onQuirkMode = document.compatMode && document.compatMode.indexOf('Back') == 0;

if(SogouMsgBrowser.ieVersion && !(SogouMsgBrowser.higherThanIE6)) {
	document.execCommand("BackgroundImageCache", false, true);
}

function stopBubble(a){
	var a=a||window.event;
	if(a.stopPropagation){
		a.stopPropagation();
	}else {
		window.event.cancelBubble=true;
	}
}

document.getElementById("sogouTable").onmouseup=function(e){stopBubble(e);}
document.getElementById("sogouTable").onmousedown=function(e){stopBubble(e);}
document.getElementById("sogouTable").onclick=function(e){stopBubble(e);}

var SogouMsgBoard = {	  
		
	  mbWrap : null,
	  mbBody : null,
	  
	  init: function(){	 
	  	this.mbWrap = document.getElementById("sogoubox");
	  	this.mbWrap.style.display = '';
	  	this.mbBody = document.getElementById("sogouTable");
	  }
};

SogouMsgBoard.init();

var SogouMsgDisplay = {
	
	initFormStyle: function() {	
		SogouMsgBoard.mbBody.style.overflow = 'hidden';
		SogouMsgBoard.mbBody.style.display = 'none';
		SogouMsgBoard.mbWrap.style.top = document.documentElement.clientHeight - SogouMsgBoard.mbWrap.clientHeight + 'px';
		if (window.addEventListener || SogouMsgBrowser.higherThanIE6 && (!SogouMsgBrowser.onQuirkMode)) {
			SogouMsgBoard.mbWrap.style.top = '';
			SogouMsgBoard.mbWrap.style.bottom = '0';
			SogouMsgBoard.mbWrap.style.position = 'fixed';
		} else {
			window.attachEvent('onscroll', this.fixMessageBoardPosition);
			window.attachEvent('onresize', this.fixMessageBoardPosition);
			this.fixMessageBoardPosition();
		}
		
		this.initTween();
	},
	
	initTween: function () {
		if (!this.initHeight) {
			this.initHeight = 1;
		}
		SogouMsgBoard.mbBody.style.display = '';
		this.min = 0;
		this.max = SogouMsgBoard.mbBody.offsetHeight;				
		this.initHeight += 2;
		if (window.attachEvent && (!SogouMsgBrowser.higherThanIE6 || SogouMsgBrowser.onQuirkMode) && (!window.opera)) {
			SogouMsgDisplay.fixMessageBoardPosition();
		}

		if (this.initHeight > this.max) {
			
		} else {
			setTimeout(SogouMsgDisplay.initTween, 0);
		}
	},
	
	fixMessageBoardPosition: function () {
		if (window.addEventListener || SogouMsgBrowser.higherThanIE6 && (!SogouMsgBrowser.onQuirkMode)) {
		
		}else{
			var page = !SogouMsgBrowser.onQuirkMode ? document.documentElement : document.body;
			SogouMsgBoard.mbWrap.style.top = parseInt(page.clientHeight) + parseInt(page.scrollTop) - SogouMsgBoard.mbWrap.offsetHeight + 'px';
		}
	}
};

<!--   调用弹出  ---->
function SogouPopupDemo(direction){
	setTimeout(function(){SogouMsgDisplay.initFormStyle();}, 10);
}var sogouAccountId=document.getElementsByName("sogouAccountId")[0].value;
var sogou_msg_reffer ='';
var sogou_msg_url ='';
var sogou_submit_url = 'http://beta.sogou.com/js/SOGOUPV.gif?v?=1000?r?=sogou_msg_reffer?l?=sogou_msg_url?acid?=sogouAccountId?t?=sogouGotoUrl';
	
<!------------------------ 功能函数 --------------------------------->
	
function sogouValidMessage()
{
		var msgValue = document.getElementsByName("sogouMsgContent")[0].value;
		
		if(sogouTrim(msgValue) == ""){
			alert("留言内容不能为空");
			return;
		}else if(sogouTrim(msgValue) == msgDefaultValue){
			alert("您还没有填写留言内容！请在留言输入框内填写留言内容再提交！谢谢");
			return;
		}else{
			
		  if(sogouCheckLength(msgValue)>400){
		  	alert("留言内容不能超过400个字符");
				return;
		  }
			
			if(null != sogouValidateParChar(msgValue)){
				alert("留言内容不能包含<或者>");
				return;
			}
		}
		
		if(false){
				var phoneValue = document.getElementsByName("sogouVisitorPhone")[0].value;
					if(sogouTrim(phoneValue) == ""){
						alert("手机号码不能为空");
						return;
					}else if(sogouTrim(phoneValue) == "请输入手机号码"){
							alert("您还没有填写手机号码！");
							return;
					}else if(sogouCheckLength(phoneValue)>15){
						alert("手机号码超长！");
						return;
					}
				
		}else{
		  var phoneValue = document.getElementsByName("sogouVisitorPhone")[0].value;
		   if(sogouTrim(phoneValue) == "请输入手机号码")
			 document.getElementsByName("sogouVisitorPhone")[0].value = "";
		}
		
		if(false){
			var emailValue = document.getElementsByName("sogouVisitorEmail")[0].value;
					if(sogouTrim(emailValue) == ""){
						alert("电子邮件不能为空");
						return;
					}else if(sogouTrim(emailValue) == "请输入电子邮件"){
							alert("您还没有填写电子邮件！");
							return;
					}else if(sogouCheckLength(emailValue)>256){
						alert("电子邮件超长！");
						return;
					}
			
		}else{
		var emailValue = document.getElementsByName("sogouVisitorEmail")[0].value;
		 if(sogouTrim(emailValue) == "请输入电子邮件")
			 document.getElementsByName("sogouVisitorEmail")[0].value = "";
		}
		
		if(false){
			var addValue = document.getElementsByName("sogouVisitorAddress")[0].value;
					if(sogouTrim(addValue) == ""){
						alert("联系人不能为空");
						return;
					}else if(sogouTrim(addValue) == "请填联系人，或xx先生/女士"){
							alert("您还没有填写请联系人！");
							return;
					}else if(sogouCheckLength(addValue)>256){
						alert("联系人超长！");
						return;
					}
			
		}else{
		var addValue = document.getElementsByName("sogouVisitorAddress")[0].value;
		 if(sogouTrim(addValue) == "请输入联系人")
			 document.getElementsByName("sogouVisitorAddress")[0].value = "";
		}
		
		
		if(!confirm('您确定发送留言吗?')) 
		{
			return false;
		}

		var sogouMsgContent = escape(msgValue);
		var sogouVisitorPhone = escape(document.getElementsByName("sogouVisitorPhone")[0].value);
		var sogouVisitorEmail = escape(document.getElementsByName("sogouVisitorEmail")[0].value);
		var sogouVisitorAddress = escape(document.getElementsByName("sogouVisitorAddress")[0].value);
		var sogouAccountId = escape(document.getElementsByName("sogouAccountId")[0].value);
		var domain = document.domain;
		var sogouSecretKey = document.getElementsByName("sogouSecretKey")[0].value;

		document.getElementsByName("sogouMsgContent")[0].value = sogouMsgContent;
		document.getElementsByName("sogouVisitorPhone")[0].value = sogouVisitorPhone;
		document.getElementsByName("sogouVisitorEmail")[0].value = sogouVisitorEmail;
		document.getElementsByName("sogouVisitorAddress")[0].value = sogouVisitorAddress;
		document.getElementsByName("sogouAccountId")[0].value = sogouAccountId;
		document.getElementsByName("s_refer_info")[0].value=sogou_msg_reffer;
		document.getElementsByName("sogouDomain")[0].value=domain;
		
		var param = {};    
		param["sogouMsgContent"]=sogouMsgContent;
		param["sogouVisitorPhone"]=sogouVisitorPhone;
		param["sogouVisitorEmail"]=sogouVisitorEmail;
		param["sogouVisitorAddress"]=sogouVisitorAddress;
		param["sogouAccountId"]=sogouAccountId;
		param["s_refer_info"]=sogou_msg_reffer;
		param["sogouDomain"]=domain;
		param["sogouSecretKey"]=sogouSecretKey;

		var array = new Array();
		for (var key in param) {
			array.push(key);
		}
		array.sort();

		var paramArray = new Array();
		for (var index in array) {
			var key = array[index];
			paramArray.push(key + '=' + param[key]);
		}		
		var sogouSig = CryptoJS.MD5(paramArray.join(""));
		document.getElementsByName("sogouSig")[0].value=sogouSig;
		
		document.getElementById("sogouMessage").submit();
		document.getElementsByName("sogouMsgContent")[0].value = msgDefaultValue;
		document.getElementsByName("sogouVisitorPhone")[0].value = "请输入手机号码";
		document.getElementsByName("sogouVisitorEmail")[0].value = "请输入电子邮件";
		document.getElementsByName("sogouVisitorAddress")[0].value = "请填联系人，或xx先生/女士";
}
	
function sogouTrim(str){  
 	return str.replace(/(^\s*)|(\s*$)/g,"");
}

function sogouCheckLength(tarValue){
	var regLen = /[\u4e00-\u9fa5]/g;
  var realLen = (tarValue.replace(regLen,"aa")).length;   
  return realLen;  	
}

function sogouValidateParChar(tarValue){
	var regLen = /<|>/g;
	return tarValue.match(regLen);
 	
}
	
function sogouClearDefault(type){
	if(type == 1){
		var msgValue = document.getElementsByName("sogouMsgContent")[0].value;
		if(msgValue == msgDefaultValue){
			document.getElementsByName("sogouMsgContent")[0].value = "";
		}
	}else if(type == 2){
		var msgValue = document.getElementsByName("sogouVisitorPhone")[0].value;
		if(msgValue == "请输入手机号码")
			document.getElementsByName("sogouVisitorPhone")[0].value = "";
	}else if(type == 3){
		var msgValue = document.getElementsByName("sogouVisitorEmail")[0].value;
		if(msgValue == "请输入电子邮件")
			document.getElementsByName("sogouVisitorEmail")[0].value = "";
	}else if(type == 4){
		var msgValue = document.getElementsByName("sogouVisitorAddress")[0].value;
		if(msgValue == "请填联系人，或xx先生/女士")
			document.getElementsByName("sogouVisitorAddress")[0].value = "";
	}
}

function sogouReDefault(type){
		if(type == 1){
		var msgValue = document.getElementsByName("sogouMsgContent")[0].value;
		if(msgValue == ""){
			document.getElementsByName("sogouMsgContent")[0].value = msgDefaultValue;
		}
	}else if(type == 2){
		var msgValue = document.getElementsByName("sogouVisitorPhone")[0].value;
		if(msgValue == "")
			document.getElementsByName("sogouVisitorPhone")[0].value = "请输入手机号码";
	}else if(type == 3){
		var msgValue = document.getElementsByName("sogouVisitorEmail")[0].value;
		if(msgValue == "")
			document.getElementsByName("sogouVisitorEmail")[0].value = "请输入电子邮件";
	}else if(type == 4){
		var msgValue = document.getElementsByName("sogouVisitorAddress")[0].value;
		if(msgValue == "")
			document.getElementsByName("sogouVisitorAddress")[0].value = "请填联系人，或xx先生/女士";
	}
}


<!------------------------ add pingback --------------------------------->

var tagArray = new Array("A","AREA");

function sogouBindEvent(oTarget,sEvtType,fnHandle){
	if(!oTarget){return;}
	if(oTarget.addEventListener){
		oTarget.addEventListener(sEvtType,fnHandle,false);
	}else if(oTarget.attachEvent){
		oTarget.attachEvent("on" + sEvtType,fnHandle);
	}else{
		oTarget["on" + sEvtType] = fnHandle;
	}
}

function sogouIsIE(){
	var sUserAgt = navigator.userAgent;
	var isOpera = sUserAgt.indexOf("Opera") > -1;
	return sUserAgt.indexOf("compatible") > -1 && sUserAgt.indexOf("MSIE") > -1	&& !isOpera;
}

function sogouFmtEvt(oEvt){
	if(sogouIsIE()){
		oEvt.charCode = (oEvt.type == "keypress") ? oEvt.keyCode : 0;
		oEvt.eventPhase = 2;
		oEvt.isChar = (oEvt.charCode > 0);
		oEvt.pageX = oEvt.clientX + document.body.scrollLeft;
		oEvt.pageY = oEvt.clientY + document.body.scrollTop;
		oEvt.preventDefault = function(){
			this.returnValue = false;
		};
		if(oEvt.type == "mouseout"){
			oEvt.relatedTarget = oEvt.toElement;
		}else if(oEvt.type == "mouseover"){
			oEvt.relatedTarget = oEvt.fromElement;
		}
		oEvt.stopPropagation = function(){
			this.cancelBubble = true;
		};
		oEvt.target = oEvt.srcElement;
		oEvt.time = (new Date()).getTime();		
	}
	return oEvt;
}

function sogouGetEvent(){
	if(window.event){
		return sogouFmtEvt(window.event);
	}else{
		return sogouGetEvent.caller.arguments[0];
	}
}


function initSogouInfo(){
		if (window.parent != window.self){try{sogou_msg_reffer = parent.document.referrer;}catch(err) {sogou_msg_reffer = document.referrer;} try {sogou_msg_url = parent.document.location;}catch(err){sogou_msg_url = document.location;}}
	  else {sogou_msg_reffer = document.referrer;sogou_msg_url = document.location;}
	  
		var sogou_submit_form_str='<form name="sogouReferForm" id="sogouReferForm" method="post" target="sogouMsgFrame" action=""></form>';
		var sogou_ifame='<iframe id="sogouIframe" src="" name="sogouMsgFrame" style="display:none;"></iframe>';
		document.writeln(sogou_submit_form_str);
		document.writeln("");
		document.writeln(sogou_ifame);	
}

function sogouSubReferInfo(sogouPvValue,gotoUrl){
	  try{
	  var formObj =  document.getElementById('sogouReferForm');
	  if(null == formObj || 'undefined' == formObj){

	  }else{
	  		formObj.action= sogou_submit_url.replace("sogouGotoUrl",gotoUrl).replace("SOGOUPV",sogouPvValue).replace("sogou_msg_reffer",sogou_msg_reffer).replace("sogou_msg_url",sogou_msg_url).replace("sogouAccountId",sogouAccountId);
	 			formObj.submit();
	  }
	 
	}catch(e){
	}
	
 }

function sogouSubUrl(){
	try{
	 var o = sogouGetEvent().target;
	 var i=0;
	 if(!isOInArray(o.tagName)){
	   do{
	 	   o = o.parentElement;
	 	   i++;
	   }while(!isOInArray(o.tagName) && o.tagName != 'BODY' && i<3)
	  }

	 sogouSubReferInfo("ck", o.getAttribute("href"));
	}catch(e){
  }
}


function isOInArray(tagStr){
	for(var i=0;i<tagArray.length;i++){
		if(tagStr == tagArray[i]){
			return true;
		}	
	}
	return false;
}

function sogou_bindAllLInkEvent(){
 for(var i=0;i<tagArray.length;i++){
 		sogou_bindTagEvent(tagArray[i]);
 	}
}

function sogou_bindTagEvent(tagStr){
	var links = document.getElementsByTagName(tagStr);
	for(var i=0;i<links.length;i++){
		sogouBindEvent(links[i],"click",sogouSubUrl);
	}
}

function sogou_domReady( f ) {
if ( sogou_domReady.done ) return f();   
if ( sogou_domReady.timer ) { 
sogou_domReady.ready.push( f ); 
} else { 
sogouBindEvent(window,"load",isDOMReady);	  
sogou_domReady.ready = [ f ];   
sogou_domReady.timer = setInterval( isDOMReady, 10 ); 
} 
}  

function isDOMReady() { 

if ( sogou_domReady.done ) return false;   

if ( document &&  document.getElementsByTagName &&  document.getElementById &&  document.body ) {   

clearInterval( sogou_domReady.timer ); 
sogou_domReady.timer = null;   

for ( var i = 0; i < sogou_domReady.ready.length; i++ ) 
sogou_domReady.ready[i]();   
sogou_domReady.ready = null; 
sogou_domReady.done = true; 
} 
}

initSogouInfo();
sogou_domReady(sogou_bindAllLInkEvent);
window.setTimeout("sogouSubReferInfo('ts','null')",10);
sogouBindEvent(window,"load",SogouPopupDemo);

document.writeln("<SCRIPT src=\"http://kspost.sogou.com/adtest/pingback4lyb.js\" ></SCRIPT>");

	
