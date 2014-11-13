
(function(l,f){function m(){var a=e.elements;return"string"==typeof a?a.split(" "):a}function i(a){var b=n[a[o]];b||(b={},h++,a[o]=h,n[h]=b);return b}function p(a,b,c){b||(b=f);if(g)return b.createElement(a);c||(c=i(b));b=c.cache[a]?c.cache[a].cloneNode():r.test(a)?(c.cache[a]=c.createElem(a)).cloneNode():c.createElem(a);return b.canHaveChildren&&!s.test(a)?c.frag.appendChild(b):b}function t(a,b){if(!b.cache)b.cache={},b.createElem=a.createElement,b.createFrag=a.createDocumentFragment,b.frag=b.createFrag();a.createElement=function(c){return!e.shivMethods?b.createElem(c):p(c,a,b)};a.createDocumentFragment=Function("h,f","return function(){var n=f.cloneNode(),c=n.createElement;h.shivMethods&&("+m().join().replace(/[\w\-]+/g,function(a){b.createElem(a);b.frag.createElement(a);return'c("'+a+'")'})+");return n}")(e,b.frag)}function q(a){a||(a=f);var b=i(a);if(e.shivCSS&&!j&&!b.hasCSS){var c,d=a;c=d.createElement("p");d=d.getElementsByTagName("head")[0]||d.documentElement;c.innerHTML="x<style>article,aside,dialog,figcaption,figure,footer,header,hgroup,main,nav,section{display:block}mark{background:#FF0;color:#000}template{display:none}</style>";c=d.insertBefore(c.lastChild,d.firstChild);b.hasCSS=!!c}g||t(a,b);return a}var k=l.html5||{},s=/^<|^(?:button|map|select|textarea|object|iframe|option|optgroup)$/i,r=/^(?:a|b|code|div|fieldset|h1|h2|h3|h4|h5|h6|i|label|li|ol|p|q|span|strong|style|table|tbody|td|th|tr|ul)$/i,j,o="_html5shiv",h=0,n={},g;(function(){try{var a=f.createElement("a");a.innerHTML="<xyz></xyz>";j="hidden"in a;var b;if(!(b=1==a.childNodes.length)){f.createElement("a");var c=f.createDocumentFragment();b="undefined"==typeof c.cloneNode||"undefined"==typeof c.createDocumentFragment||"undefined"==typeof c.createElement}g=b}catch(d){g=j=!0}})();var e={elements:k.elements||"abbr article aside audio bdi canvas data datalist details dialog figcaption figure footer header hgroup main mark meter nav output progress section summary template time video",version:"3.7.0",shivCSS:!1!==k.shivCSS,supportsUnknownElements:g,shivMethods:!1!==k.shivMethods,type:"default",shivDocument:q,createElement:p,createDocumentFragment:function(a,b){a||(a=f);if(g)return a.createDocumentFragment();for(var b=b||i(a),c=b.frag.cloneNode(),d=0,e=m(),h=e.length;d<h;d++)c.createElement(e[d]);return c}};l.html5=e;q(f)})(this,document);function _(name){return document.getElementById(name);}
(function(){var device=navigator.userAgent.toLocaleLowerCase();D={isPC:checkDevice(device,'windows'),isWebkit:checkDevice(device,'webkit'),isTrident:checkDevice(device,'trident'),isGecko:checkDevice(device,'gecko'),isPresto:checkDevice(device,'presto'),isIphone:checkDevice(device,'iphone'),isTouch:checkDevice(device,'ipod')};D.isGecko=((D.isWebkit==0)&&(D.isGecko!=0))?1:0;D.isMobile=D.isPC==0?1:0;})();function checkDevice(device,v){return device.indexOf(v)+1;}
function addEvent(ele,type,fn){if(D.isMobile){var mapping={mousedown:'touchstart',mousemove:'touchmove',mouseup:'touchend'}
type=mapping[type]||type;}else if(D.isPC){var mapping={touchstart:'mousedown',touchmove:'mousemove',touchend:'mouseup'}
type=mapping[type]||type;}
if(ele.addEventListener){ele.addEventListener(type,fn,false);}
else{ele.attachEvent('on'+type,fn);}}
function setTransform(str){var str="translate("+str+")";return{"-webkit-transform":str,"-moz-transform":str,"-o-transform":str,"-ms-transform":str};}
function setTransition(str){if(!str){return{"-webkit-transition":'',"-moz-transition":'',"-o-transition":'',"-ms-transition":''};}else{return{"-webkit-transition":'-webkit-transform '+str,"-moz-transition":'-moz-transform '+str,"-o-transition":'-o-transform '+str,"-ms-transition":'-ms-transform '+str};}}
function getLR(o){return parseInt(getTransform(o)[4]);}
function getTB(o){return parseInt(getTransform(o)[5]);}
function getTransform(o){var v=o.css('-webkit-transform');return v.split(',');}
$(function(){(function(){aEmail=['qq.com','sina.com','sina.cn','sohu.com','139.com','189.cn','163.com','126.com','hotmail.com','wo.com.cn','chinaren.com'];slide_pv='';deviceHeight=$(window).height();bindFun();})();window.addEventListener("orientationchange",function(){set_nav();$('#shadow').height($(document).height());deviceHeight=window.screen.height;},false);});$(function(){$('.arrow_icon,#menu_icon').click(function(){show_nav();});if($("#scrollTop")){$("#scrollTop").css("right",($(document).width()-$("#bk").width())/2+"px");window.onresize=function(){$("#scrollTop").css("right",($(document).width()-$("#bk").width())/2+"px");};$(window).scroll(function(){if($(window).scrollTop()>0){$("#scrollTop").fadeIn(100);}
else{$("#scrollTop").fadeOut(100);}});}});function show_nav(){set_nav();var $o=$('nav');var $arrow=$('.arrow_icon')
var st=getLR($o);var width=$(window).width();var mLeft=(width-$(".content").width())/2;if(st!=0){$o.show();$o.css(setTransform('0px,0px'));$arrow.show();$o.css("left",mLeft);$arrow.css("top",$(window).height()/2);$arrow.css("left",mLeft+170);$o.css("z-index",100);addMenuShadow();}else{window.scrollTo(0,0);$o.hide();$o.css(setTransform('-'+(mLeft+170)+'px,0px'));$arrow.hide();$arrow.css(setTransform('-'+(mLeft+154)+'px,0px'));removeMenuShadow();}}
function addMenuShadow(){if(_('menushadow'))
return;$('#wrapper').height($(document).height());var htm="<div id='menushadow' style='height:"+$(document).height()+"px' onclick='show_nav()' /></div>";$('#wrapper').append(htm);}
function removeMenuShadow(){$('#menushadow').remove();}
function bindFun(){$('nav .l a,.but_lt,.butt,.h_email span').bind('touchstart',function(){$(this).addClass('hover');}).bind('touchmove',function(){$(this).removeClass('hover');}).bind('touchend',function(){$(this).removeClass('hover');});$('.check_img,.check_text').bind('click',function(){var $o=$(this).parent().find('.check_img');if($o.hasClass('checked')){$o.removeClass('checked');$('input[name="autologin"]').val(0);}else{$o.addClass('checked');$('input[name="autologin"]').val(1);}});$('textarea,.txt').bind('focus',function(){if($(this).hasClass('default')){if($(this).val()==$(this).next("input[type='hidden']").val()){$(this).val('');}
$(this).removeClass('default');}}).bind('blur',function(){if($.trim($(this).val())==''){var val=$(this).next("input[type='hidden']").val();$(this).addClass('default').val(val);}});$('.show_list aside').bind('click',function(){if(!$(this).next().hasClass('t_list')){return false;}
if($(this).hasClass('has_list')){$(this).removeClass('has_list').next().hide();}else{$(this).siblings('aside').removeClass('has_list');$(this).siblings("[class*='t_list']").hide();$(this).addClass('has_list').next().show();}});$(".spText").bind('click',function(e){e.stopPropagation();if($(this).hasClass('has_list')){$(this).removeClass('has_list').next().slideUp();}else{$(this).addClass('has_list').next().slideDown();}});$('nav b').bind('click',function(){if(!$(this).next().hasClass('nav2')){return false;}
if($(this).hasClass('has_nav2')){$(this).removeClass('has_nav2').next().hide();}else{$(this).siblings('b').removeClass('has_nav2');$(this).siblings("[class*='nav2']").hide();$(this).addClass('has_nav2').next().show();}
set_nav();});$('.cvview .title').bind('click',function(){if($(this).next().hasClass('title')){return false;}
if($(this).children('div').hasClass('has_list')){$(this).children('div').removeClass('has_list').parent().next().hide();}else{$(this).siblings('.box').removeClass('has_list');$(this).children('div').addClass('has_list').parent().next().show();}});$('.OrderInfo .title').bind('click',function(){if($(this).next().hasClass('title')){return false;}
if($(this).children('div').hasClass('has_list')){$(this).children('div').removeClass('has_list').parent().next().hide();}else{$(this).siblings('.box').removeClass('has_list');$(this).children('div').addClass('has_list').parent().next().show();}});$('.show_list p').bind('click',function(){if(!$(this).next().hasClass('t_list')){return false;}
if($(this).hasClass('has_list')){$(this).removeClass('has_list').next().hide();}else{$(this).siblings('aside').removeClass('has_list');$(this).siblings("[class*='t_list']").hide();$(this).addClass('has_list').next().show();}});$('.slet select').bind('change',function(){var v=$(this).find('option:selected').html();var $o=$(this).prev();if($o[0]){$o.removeClass('default').html(v);}else{$(this).parent().prepend("<font>"+v+"</font>");}
if($(this).find('option:selected').attr('name')=='empty'){$(this).prev().addClass('default');}});$('.bottom .top').bind('click',function(){$('body,html').animate({scrollTop:0},100);});$('header .back').bind('click',function(e){if(!$(this).hasClass('tp')){window.history.go(-1);return 0;}
e.preventDefault();if($(this).hasClass('prev')){var n=$('.slide_box').length;n--;$(this).parents().find(".slide_box:eq("+n+")").css(setTransform('100%,0px'));setTimeout(function(){$('.slide_box').remove()},500);}else{$('#wrapper').show();window.scrollTo(0,Gtop);$('.slide_box').css('padding-top',Gtop);$('.slide_box').css(setTransform('100%,0px'));setTimeout(function(){$('.slide_box').remove()},500);}});$('.aEmail').bind('focus',function(){var htm="<div class='h_email'></div>";$('body').append(htm);var $o1=$(this).parent();var $o2=$(this).parents('div').eq(0);var p=parseInt($o1.css('padding-left'));var w=$o2.width()+parseInt($o2.css('padding-right'))-p;var l=$o2.offset().left+p;var t=$o2.offset().top+$o2.height()+parseInt($o2.css('padding-top'))+parseInt($o2.css('padding-bottom'));$('.h_email').css({width:w,left:l,top:t});}).bind('keyup',function(e){var v=$('.aEmail').val();v=v.replace(/</g,'');v=v.replace(/>/g,'');var htm='';var bk=vali_email(v);switch(bk[0]){case(1):case(2):for(var k in aEmail){htm+='<span>'+bk[1]+'@'+aEmail[k]+'</span>';}
break;case(3):var temp='';for(var k in aEmail){if(aEmail[k].indexOf(bk[1])===0){htm+='<span>'+bk[2]+'@'+aEmail[k]+'</span>';}
temp+='<span>'+bk[2]+'@'+aEmail[k]+'</span>';}
if(!htm){htm=temp;}
break;case(4):var temp='';for(var k in aEmail){if(aEmail[k].indexOf(bk[1])===0){htm+='<span>@'+aEmail[k]+'</span>';}
temp+='<span>@'+aEmail[k]+'</span>';}
if(!htm){htm=temp;}
break;}
if(htm){$('.h_email').show();$('.h_email').html(htm);$('.h_email span').bind('click',function(){var v=$(this).html();$('.aEmail').val(v);$('.h_email').hide();$('.aEmail').focus();$('.aEmail').blur();});}}).bind('blur',function(){setTimeout(function(){$('.h_email').hide()},500)});}
var pLink={page:function(){var that=$(arguments[0]);var url=arguments[1];var fun=arguments[2]==undefined?'':arguments[2];$('.show_list aside').unbind('click');$.ajax(url,{success:function(data,textStatus,jqXHR){var htm="<div class='slide_box'>"+data+"</div>";Gtop=$(document).scrollTop();var height=document.documentElement.clientHeight;$('body').css('min-height',$(document).height()).append(htm);$('.slide_box').css({paddingTop:Gtop,minHeight:height,width:'100%',top:0,position:'absolute'});$('.slide_box').css(setTransform('0px,0px'));$('.slide_box').css(setTransition('0.2s linear'));setTimeout(function(){$('.slide_box').css(setTransform('-100%,0px'))},1);setTimeout(function(){$('#wrapper').hide();$('.slide_box').css('padding-top',0);window.scrollTo(0,0);bindFun();if(fun){fun();}},200);var className=that.attr('name');slide_pv=className;if(!$("input[name='"+className+"']")[0]){$('body').append("<input type='hidden' name='"+className+"' />");}},error:function(jqXHR,textStatus,errorThrown){if(textStatus=='timeout'){alert('加载超时！');}else{alert('加载失败！');}}});},val:function(){var v1=$(arguments[0]).attr('name');var v2=$(arguments[0]).html();var str="$('#"+slide_pv+"').removeClass('default').text('"+v2+"')";var fun=arguments[1]==undefined?'':arguments[1];var flag=arguments[2]==undefined?'':arguments[2];eval(str)
if(flag=='area'){$('nav .ct p').html(v2);$('.jobarea').html(v2).attr('value',v1);storage.json_set('location',{'areacode':v1,'areaname':v2});}
$('.isTouch:visible').find('header .back').trigger("click");setTimeout(function(){$("input[id='iddc"+slide_pv+"ID']").val(v1);if(fun){fun();}},500);},valSearchSel:function(){var _SpanName=$(arguments[0]).attr('name');var arrTmp=_SpanName.split(',');var _thisName=arrTmp[0];var v2=arrTmp[1];for(k=0;k<20;k++){try{if(k<10){$("#chk"+_thisName+"0"+k).addClass('ck_no').removeClass('ck_yes');}
else{$("#chk"+_thisName+k).addClass('ck_no').removeClass('ck_yes');}}
catch(e){}}
var temp=_thisName.substring(0,_thisName.length-2);$("#chk"+temp).addClass('ck_no').removeClass('ck_yes');var str=""
var fun=arguments[1]==undefined?'':arguments[1];var flag=arguments[2]==undefined?'':arguments[2];eval(str)
var saveAddData='';var saveAddDataName='';if(flag=='area'){$('nav .ct p').html(v2);$('.jobarea').html(v2).attr('value',_thisName);storage.json_set('location',{'areacode':_thisName,'areaname':v2});}
var selID=$("#iddcID").val();var selName=$("#iddcName").val();var arr=selID.split(' ');var arrName=selName.split(' ');if(arr.length>0){for(var i=0;i<arr.length;i++){if(_thisName==arr[i]){return true;}
else{if(!(_thisName.indexOf(arr[i])==0||arr[i].indexOf(_thisName)==0)||slide_pv.indexOf("Industry")>-1){if(_thisName.length==4&&arr[i]==jsJobTypeL1ID[2]){continue;}else if(_thisName.length==2){var arrjt=jsJobTypeL2ID[1];var isEqual=0;for(var j=0;j<arrjt.length;j++){if(arrjt[j]==arr[i]){isEqual=1;break;}}
if(isEqual==1){continue;}}
if(saveAddData.length==0){saveAddData=arr[i];saveAddDataName=arrName[i];}
else{saveAddData+=' '+arr[i];saveAddDataName+=' '+arrName[i];}}}}
if(saveAddData.length==0){saveAddData=_thisName;saveAddDataName=v2;if(arr.length>0){$("#chk"+arr[0]).addClass('ck_no').removeClass('ck_yes');}}
else{saveAddData+=' '+_thisName;saveAddDataName+=' '+v2;}
arr=saveAddData.split(' ');arrName=saveAddDataName.split(' ');var num=5;if(arr.length>num){if(slide_pv.toLowerCase().indexOf('jobtype')>-1){}
$("obj").addClass('ck_no').removeClass('ck_yes');$("#chk"+_thisName).addClass('ck_no').removeClass('ck_yes');popbox.error('您选择的数据已经超过5个，请先删除再选择！');return false;}
_("iddcID").value=saveAddData;_("iddcName").value=saveAddDataName;}
else{saveAddData=_thisName;saveAddDataName=v2;_("iddcID").value=saveAddData;_("iddcName").value=saveAddDataName;_("divSelected").innerHTML='<span class="pickedPlace" name='+_thisName+'>'+v2+'<span class="delPlace" name='+_thisName+','+v2+' onclick="pLink.valSearchNoSel(this)"></span></span>';}
if(_("iddcID").value.length==0){_("divSelected").innerHTML='';_("iddcName").value='';_("divSelected").innerHTML='';}
else{_("divSelected").innerHTML='';for(i=0;i<arr.length;i++){_("divSelected").innerHTML=_("divSelected").innerHTML+'<span class="pickedPlace" name='+arr[i]+'>'+arrName[i]+'<span class="delPlace" name='+arr[i]+','+arrName[i]+' onclick="pLink.valSearchNoSel(this)"></span></span>';}}
setTimeout(function(){if(fun){fun();}},500);},valSearchNoSel:function(){var _SpanName=$(arguments[0]).attr('name');var arrTmp=_SpanName.split(',');var removeId=arrTmp[0];var removeName=arrTmp[1];for(k=0;k<20;k++){try{if(k<10){$("#chk"+removeId+"0"+k).addClass('ck_no').removeClass('ck_yes');}
else{$("#chk"+removeId+k).addClass('ck_no').removeClass('ck_yes');}}
catch(e){}}
var str="";var fun=arguments[1]==undefined?'':arguments[1];var flag=arguments[2]==undefined?'':arguments[2];eval(str)
var saveAddData='';if(flag=='area'){$('nav .ct p').html(removeName);$('.jobarea').html(removeName).attr('value',removeId);storage.json_set('location',{'areacode':removeId,'areaname':removeName});}
var removeDataID=$("#iddcID").val();var removeDataName=$("#iddcName").val();removeDataID=" "+removeDataID;removeDataName=" "+removeDataName;removeDataID=removeDataID.replace(' '+removeId,'');removeDataName=removeDataName.replace(' '+removeName,'');if(removeDataID==removeId){removeDataID='';removeDataName='';}
if(removeDataID.substring(0,1)==" "){removeDataID=removeDataID.substring(1);removeDataName=removeDataName.substring(1);}
var arr=removeDataID.split(' ');var arrName=removeDataName.split(' ');var i=0,has=0;for(i=0;i<arr.length;i++){if(arr[i].substring(0,2)==removeId.substring(0,2)){has=1;break;}}
_("iddcID").value=removeDataID;_("iddcName").value=removeDataName;if(removeDataID.length==0){$("#chk"+removeId).addClass('ck_no').removeClass('ck_yes');_("divSelected").innerHTML='';return;}
else{$("#chk"+removeId).addClass('ck_no').removeClass('ck_yes');_("divSelected").innerHTML='';for(i=0;i<arr.length;i++){_("divSelected").innerHTML=_("divSelected").innerHTML+'<span class="pickedPlace" name='+arr[i]+'>'+arrName[i]+'<span class="delPlace"  name='+arr[i]+','+arrName[i]+' onclick="pLink.valSearchNoSel(this)"></span></span>';}}},valRegion:function(){var v1=$(arguments[0]).attr('name');var v2=$(arguments[0]).html().replace("全部","");var str="$('#"+slide_pv+"').removeClass('default').text('"+v2+"')";var fun=arguments[1]==undefined?'':arguments[1];var flag=arguments[2]==undefined?'':arguments[2];eval(str)
if(flag=='area'){$('nav .ct p').html(v2);$('.jobarea').html(v2).attr('value',v1);storage.json_set('location',{'areacode':v1,'areaname':v2});}
$('.isTouch:visible').find('header .back').trigger("click");setTimeout(function(){$("input[id='iddc"+slide_pv+"ID']").val(v1);if(fun){fun();}
GetSchool();_("bk").innerHTML="";_("txtPlaceId").innerHTML="全部学校";_("idSchoolID").value="0";AjaxGetCampusList(1,_("iddcRegionID").value,_("idSchoolID").value);},500);},valRecuritment:function(){var v1=$(arguments[0]).attr('name');var v2=$(arguments[0]).html();var str="$('#"+slide_pv+"').removeClass('default').text('"+v2+"')";var fun=arguments[1]==undefined?'':arguments[1];var flag=arguments[2]==undefined?'':arguments[2];eval(str)
if(flag=='area'){$('nav .ct p').html(v2);$('.jobarea').html(v2).attr('value',v1);storage.json_set('location',{'areacode':v1,'areaname':v2});}
$('.isTouch:visible').find('header .back').trigger("click");setTimeout(function(){$("input[id='iddc"+slide_pv+"ID']").val(v1);if(fun){fun();}
GetPlace();_("bk").innerHTML="";_("txtPlaceId").innerHTML="全部场馆";_("idPlaceID").value="0";AjaxGetRecruitmentList(1,_("idDate").value,_("iddcRegionID").value,_("idPlaceID").value);},500);},valPlace:function(){var v1=$(arguments[0]).attr('name');var v2=$(arguments[0]).html();var str="$('#"+slide_pv+"').removeClass('default').text('"+v2+"')";var fun=arguments[1]==undefined?'':arguments[1];var flag=arguments[2]==undefined?'':arguments[2];eval(str)
if(flag=='area'){$('nav .ct p').html(v2);$('.jobarea').html(v2).attr('value',v1);storage.json_set('location',{'areacode':v1,'areaname':v2});}
$('.isTouch:visible').find('header .back').trigger("click");setTimeout(function(){$("input[id='iddc"+slide_pv+"ID']").val(v1);if(fun){fun();}
submitForm();},500);}}
function el_choice(obj,event,type){event.stopPropagation();var $o=$(obj);if($o.hasClass('ck_yes')){$o.addClass('ck_no').removeClass('ck_yes');}else{$o.addClass('ck_yes').removeClass('ck_no');}
if(type==1){$('.ck_yes').addClass('ck_no').removeClass('ck_yes');if($o.hasClass('ck_yes')){$o.addClass('ck_no').removeClass('ck_yes');}else{$o.addClass('ck_yes').removeClass('ck_no');}}
else{if(!$('.ck_no')[0]){$('#choose_all').html('全取消');}
else{$('#choose_all').html('全选');}}
stopBubble(event);}
function el_SearchChoice(obj,event,type){event.stopPropagation();var $o=$(obj);if($o.hasClass('ck_yes')){$o.addClass('ck_no').removeClass('ck_yes');}else{$o.addClass('ck_yes').removeClass('ck_no');}
if(type==1){$('.ck_yes').addClass('ck_no').removeClass('ck_yes');if($o.hasClass('ck_yes')){$o.addClass('ck_no').removeClass('ck_yes');}else{$o.addClass('ck_yes').removeClass('ck_no');}}
else{if(!$('.ck_no')[0]){$('#choose_all').html('全取消');}
else{$('#choose_all').html('全选');}}
stopBubble(event);if($o.hasClass('ck_yes')){pLink.valSearchSel(obj);}
else{pLink.valSearchNoSel(obj);}}
function elTx_SearchChoice(obj,event,type){event.stopPropagation();var $o=$(obj).prev();if($o.hasClass('ck_yes')){$o.addClass('ck_no').removeClass('ck_yes');}else{$o.addClass('ck_yes').removeClass('ck_no');}
if(type==1){$('.ck_yes').addClass('ck_no').removeClass('ck_yes');if($o.hasClass('ck_yes')){$o.addClass('ck_no').removeClass('ck_yes');}else{$o.addClass('ck_yes').removeClass('ck_no');}}
else{if(!$('.ck_no')[0]){$('#choose_all').html('全取消');}
else{$('#choose_all').html('全选');}}
stopBubble(event);if($o.hasClass('ck_yes')){pLink.valSearchSel($o);}
else{pLink.valSearchNoSel($o);}}
function elLi_SearchChoice(obj,event,type){event.stopPropagation();var $o=$(obj).find("span");if($o.hasClass('ck_yes')){$o.addClass('ck_no').removeClass('ck_yes');}else{$o.addClass('ck_yes').removeClass('ck_no');}
if(type==1){$('.ck_yes').addClass('ck_no').removeClass('ck_yes');if($o.hasClass('ck_yes')){$o.addClass('ck_no').removeClass('ck_yes');}else{$o.addClass('ck_yes').removeClass('ck_no');}}
else{if(!$('.ck_no')[0]){$('#choose_all').html('全取消');}
else{$('#choose_all').html('全选');}}
stopBubble(event);if($o.hasClass('ck_yes')){pLink.valSearchSel($o);}
else{pLink.valSearchNoSel($o);}}
function stopBubble(e){if(window.event){window.event.returnValue=false;}else{e.preventDefault();}}
function set_nav(){$('nav').height($(document).height());$('.navRB').height($(document).height());if($('#wrapper').height()<$('.isTouch').height()+80)
$('#wrapper').height($('.isTouch').height()+80);}
function show_search(){$('header,.imt,.top_AD').hide(function(){$('.search').addClass('t2');$('.s_tab,.s_con').show();});}
function close_search(){if(document.cookie){var ck=document.cookie;var str=/[\s]*ad=0[\s]*/;var mk=0;ck=ck.split(";");for(var i=0;i<ck.length;i++){if(str.test(ck[i])){mk++;}}
if(!mk){$('.top_AD').show();}}else{$('.top_AD').show();}
$('.s_tab,.s_con').hide(function(){$('.search').removeClass('t2');$('header,.imt').show();});}
function vali_email(v){var re=/([^@]{1,30})*(@)?(.*)/i;var o=re.exec(v);if(o[1]){if(o[2]){if(o[3]){return[3,o[3],o[1]];}
return[2,o[1]];}
return[1,o[1]];}else{if(o[3]){return[4,o[3]];}
return[4,''];}}
function set_rate(o){var w=$('.rte').width();var l=(o[3]-o[2])*w/(o[1]-o[0]);var r=(o[2]-o[0])*100/(o[1]-o[0]);var htm="<font class='m1'>￥"+o[0]+"</font><font class='x1'>￥"+o[1]+"</font>";htm+="<div style='width:"+l+"px;margin-left:"+r+"%' class='kd'>";htm+="<font class='m2'>￥"+o[2]+"</font><font class='x2'>￥"+o[3]+"</font>";htm+="<span style='width:"+l+"px'></span></div>";$('.rte').append(htm);$('.rte .m2').css('margin-left',-($('.rte .m2').width()+5)).show();$('.rte .x2').css({'margin-right':-($('.rte .x2').width()+5),right:0}).show();}
function show_guide(){var h=$(document).height();var w=$(document).width();w=(w-109)/2;var htm="<div id='guideBlock'><span class='g1'></span><span class='g2'></span><p><span class='g3'></span></p></div>";$('body').append(htm);addShadow();document.addEventListener('touchend',close_guide,false);if(D.isPC){document.addEventListener('click',close_guide,false);}}
function close_guide(){$('#guideBlock').remove();removeShadow();document.removeEventListener('touchend',close_guide,false);if(D.isPC){document.removeEventListener('click',close_guide,false);}
var date=new Date();date.setTime(date.getTime()+360*24*3600*1000);document.cookie="guide=0;expires="+date.toGMTString();}
function addLoading(){$('.whiteboard ').css('min-height','467px');var htm = "<div id='Loading' style='position:fixed; top:0; left:0;width:100%; height:100%;text-align:center;'><div class='page-loading-logo'><div class='page-loading-anim'></div></div></div>";$('#wrapper').append(htm);}
function removeLoading(){$('#Loading').remove();$('.whiteboard ').css('min-height','0');}
function addShadow(){if(_('shadow'))
return;$('#wrapper').height($(document).height());var htm="<div id='shadow' style='height:"+$(document).height()+"px' /></div>";$('#wrapper').append(htm);}
function removeShadow(){$('#shadow').remove();}
$(function(){$('.ismore').each(function(){ismore($(this));});$('#turnpage select').change(function(){pageno=$(this).val();url=$('#turnpage').attr('action');if(url.indexOf('?')>-1){location.href=$('#turnpage').attr('action')+'&pageno='+pageno}
else{location.href=$('#turnpage').attr('action')+'?pageno='+pageno}});$('a[rel="area"]').click(function(){loc=storage.json_get('location');if(!(loc.areacode==''||loc.areacode==undefined)){$(this).attr('href',$(this).attr('href')+'&jobarea='+loc.areacode);}});});function ismore(obj){var h1=obj.height();var h2=obj.find('.ct').height();if(h2>h1){obj.after("<p class='sh_m' onclick=\"this.previousSibling.style.maxHeight=\'none\';this.style.display=\'none\'\">显示全部</p>");}}
var validate={Vname:function(){var v=$('.Vname').val();if(v==''){popbox.error('用户名不能为空！');return false;}
return true;},Vemail:function(){var v=$('.Vemail').val();var myRegExp=/[a-z0-9-]{1,30}@[a-z0-9-]{1,65}.[a-z]{2,}/i;if(myRegExp.test(v)){return true;}
popbox.error('Email书写不正确！');return false;},Vpwd1:function(){var v=$('.Vpwd1').val();if(v.length>=4&&v.length<=16){return true;}
popbox.error('密码长度为4-16个字符！');return false;},Vpwd2:function(){var v1=$('.Vpwd1').val();var v2=$('.Vpwd2').val();if(v1===v2){return true;}
popbox.error('2次密码不相同！');return false;},check:function(){var bk=true;for(var k in arguments){if(!eval('validate.'+arguments[k]+'()')){bk=false;break;}}
return bk;}};var List={edit:function(){$(".lst aside").removeClass("arrow").find("a:first").attr("onclick","return false");$("header .right").html("完成").attr("onclick","List.finish()");$(".lst .info img").bind("click",function(){List.del(this)});},del:function(obj){var $o=$(obj).parents("aside");if(List.delToDo($o.attr("name"))){$o.remove();}else{popbox.error("删除失败！");}},finish:function(){$(".lst aside").addClass("arrow").find("a:first").removeAttr("onclick");$("header .right").html("编辑").attr("onclick","List.edit()");$(".lst .info img").unbind("click");}};var popbox={f1:'',f2:'',correct:function(msg,o){popbox.pop(msg,o,'correct');},error:function(msg,o){popbox.pop(msg,o,'error');},msg:function(msg,o){popbox.pop(msg,o,'msg');},wrong:function(msg,o){popbox.pop(msg,o,'wrong');},pop:function(msg,o,type){if($('section').hasClass('pop'))
popbox.close();var htm="<section class='pop "+type+"'><p>"+msg+"</p></section>";popbox.show(htm);$("#shadow,.pop").bind('click',popbox.close);if(type=="error"){setTimeout('popclose()',3000);}},alert:function(msg,o,but,callback){but=(but==undefined||but=='')?'确 认':but;popbox.f1=callback;var htm="<section class='pop alert'><p>"+msg+"<button class='butt but_lt min' onclick='popbox.clicked()'><span class='con'>"+but+"</span></button></p></section>";popbox.show(htm);},confirm:function(msg,o,but1,but2,callback1,callback2){but1=(but1==undefined||but1=='')?'是':but1;but2=(but2==undefined||but2=='')?'否':but2;popbox.f1=callback1;popbox.f2=callback2;var htm="<section class='pop confirm'><p>"+msg+"<br /><span class='button_green' onclick='popbox.clicked(1)'>"+but1+"</span><span class='button_blue' onclick='popbox.clicked(2)'>"+but2+"</span></p></section>";popbox.show(htm);},show:function(htm,type){$('.pop').show();$('body').append(htm);var h=($(window).height()-$('.pop').height())/2-30+$(window).scrollTop();h=(h<=0)?0:h;$('.pop').css('top',h).fadeIn(800);addShadow();if(!type)
$("#shadow,.pop").bind('click',popbox.hide);},hide:function(){$('.pop').fadeOut(800,function(){$('.pop').remove()});$('#shadow').fadeOut(800,function(){$('#shadow').remove()});},close:function(){$('.pop').remove();removeShadow();},clicked:function(n){popbox.close();if(n=='2'){if(typeof popbox.f2=='function'){popbox.f2();}}else{if(typeof popbox.f1=='function'){popbox.f1();}}}}
var popbox2={f1:'function',f2:'',correct:function(msg,o){popbox2.pop(msg,o,'correct');},error:function(msg,o){popbox2.pop(msg,o,'error');},msg:function(msg,o){popbox2.pop(msg,o,'msg');},wrong:function(msg,o){popbox2.pop(msg,o,'wrong');},pop:function(msg,o,type){if($('section').hasClass('pop'))
popbox2.close();var htm="<section class='popWin "+type+"'><p>"+msg+"</p></section>";popbox2.show(htm);$("#shadow,.popWin").bind('click',popbox2.close);},alert:function(msg,o,but,callback){but=(but==undefined||but=='')?'确 认':but;popbox2.f1=callback;var htm="<section class='popWin alert'><p>"+msg+"<button class='butt but_lt min' onclick='popbox.clicked()'><span class='con'>"+but+"</span></button></p></section>";popbox2.show(htm);},confirm:function(msg,o,but1,but2,callback1,callback2){but1=(but1==undefined||but1=='')?'是':but1;but2=(but2==undefined||but2=='')?'否':but2;popbox2.f1=callback1;popbox2.f2=callback2;var htm="<section class='popWin confirm' style='text-align:center;padding-bottom:10px'><div class='btnClose'  onClick='popbox2.close()'></div><div style='width:100%;border-bottom:1px solid #ff9327'><span style='margin-bottom:8px;display:block;color:#ff5a26;font-size:18px;font-weight:bold'>提示</span></div><p><span style='display:block;margin-bottom:8px;color:black;margin-top:8px;width:94%;padding-left:3%'>"+msg+"</span><span class='bt1' onclick='"+callback1+"' style='display:inline-block;text-align:center;'>"+but1+"</span><span class='bt2' onclick='popbox.clicked(2)' style='display:inline-block;text-align:center;margin-left:10px'>"+but2+"</span></p></section>";popbox2.show(htm);},show:function(htm,type){$('.popWin').show();$('body').append(htm);var h=($(window).height()-$('.popWin').height())/2-30+$(window).scrollTop();h=(h<=0)?0:h;$('.popWin').css('top',h).fadeIn(800);addShadow();if(!type)
$("#shadow,.popWin").bind('click',popbox2.hide);},show1:function(htm,type){$('.popWin1').show();$('body').append(htm);var h=($(window).height()-$('.popWin').height())/2-30+$(window).scrollTop();h=(h<=0)?0:h;$('.popWin1').css('top',h).fadeIn(800);addShadow();if(!type)
$("#shadow,.popWin1").bind('click',popbox2.hide);},show2:function(htm,type){$('.popWin').show();$('body').append(htm);var h=($(window).height()-$('.popWin').height())/3+$(window).scrollTop();h=(h<=0)?0:h;$('.popWin').css('top',h).fadeIn(800);addShadow();if(!type)
$("#shadow,.popWin").bind('click',popbox2.hide);},hide:function(){$('.popWin').fadeOut(800,function(){$('.popWin').remove()});$('#shadow').fadeOut(800,function(){$('#shadow').remove()});},close:function(){$('.popWin').remove();removeShadow();},close1:function(){$('.popWin1').remove();removeShadow();},clicked:function(n){popbox2.close();if(n=='2'){if(typeof popbox2.f2=='function'){popbox2.f2();}}else{if(typeof popbox2.f1=='function'){popbox2.f1();}}}}
var storage={isLocalStorage:(window.localStorage?true:false),set:function(item,value){if(this.isLocalStorage){localStorage[item]=value;}},get:function(item){if(this.isLocalStorage){return localStorage[item];}},del:function(item){if(this.isLocalStorage){localStorage.removeItem(item);}},clear:function(){if(this.isLocalStorage){localStorage.clear();}},json_set:function(item,value){if(this.isLocalStorage){localStorage[item]=JSON.stringify(value);}},json_get:function(item){if(this.isLocalStorage){var data=localStorage[item]?JSON.parse(localStorage[item]):'';return data;}},display:function(){if(this.isLocalStorage){var data='';for(var i=0;i<localStorage.length;i++){key=localStorage.key(i);value=localStorage.getItem(key);data+="\nkey:"+key+" value:"+value;}
return data;}}}
function popclose(){popbox.close();}
function GetArrayValue(arrname,idval){if(!idval)return"请选择";if(idval.indexOf(" ")<0&&idval.indexOf(",")<0){var strRegionPre="";var strRegionNo="";if(arrname=="Region"||arrname=="LivePlace"||arrname=="AccountPlace"||arrname=="GrowPlace"){if(idval.length>2){strRegionNo=idval.substring(0,2);strRegionPre=GetArrayValueOne(arrname,strRegionNo);}
if(idval.length>4){strRegionNo=idval.substring(0,4);strRegionPre+=GetArrayValueOne(arrname,strRegionNo);}}
return strRegionPre+GetArrayValueOne(arrname,idval);}
else{var idarr;if(idval.indexOf(" ")>0)idarr=idval.split(" ");if(idval.indexOf(",")>0)idarr=idval.split(",");var result='';for(var i=0;i<idarr.length;i++){if(result.length==0)result+=GetArrayValueOne(arrname,idarr[i]);else result+=" "+GetArrayValueOne(arrname,idarr[i]);}
return result;}}
function GetArrayValueOne(arrname,idval){if(arrname=="JobType"){var arrid=eval("jsJobTypeL2ID")
var arrCode=eval("jsJobTypeL2")
for(var i=0;i<arrid.length;i++)
for(var j=0;j<arrid[i].length;j++)
if(arrid[i][j]==idval)return arrCode[i][j];arrid=eval("jsJobTypeL1ID")
arrCode=eval("jsJobTypeL1")
for(i=0;i<arrid.length;i++)
if(arrid[i]==idval)return arrCode[i];}
else if(arrname=="Region"||arrname=="LivePlace"||arrname=="AccountPlace"||arrname=="GrowPlace"){var arrid=[];var arrCode=[];if(idval.length==2){arrid=region1ID;arrCode=region1;for(var i=0;i<arrid.length;i++)
if(arrid[i]==idval)return arrCode[i];}
if(idval.length==4){arrid=region2ID;arrCode=region2;}
if(idval.length==6){idval=idval.substring(0,6);arrid=region3ID;arrCode=region3;}
for(var i=0;i<arrid.length;i++)
if(arrid[i]!=null)
for(var j=0;j<arrid[i].length;j++)
if(arrid[i][j]==idval)return arrCode[i][j];}
else{var arrid=eval("js"+arrname+"ID");var arrCode=eval("js"+arrname);for(var i=0;i<arrid.length;i++)
if(arrid[i]==idval)return arrCode[i];}}
function change_all(){var that=$(arguments[0]);if(that.html()=='全选'){$('.ck_no').removeClass('ck_no').addClass('ck_yes');that.html('全取消');}
else if(that.html()=='全取消'){$('.ck_yes').removeClass('ck_yes').addClass('ck_no');that.html('全选');}}
function changeEndTime(endTime,jobID,jobName){$('.joblist').hide(function(){$('.PoupDate').show()});$('.inputdate').val(endTime);$('#JobName').val(jobName);$('#JobID').val(jobID);}
function closePoupDate(){$('.PoupDate').hide(function(){$('.joblist').show()});}
function JobIssue_click(){var type=0;var url=escape(document.location.toString());var IssueEnd
if($('#IssueDate').hasClass('ck_yes')){type=1;IssueEnd=$('.inputdate').val();if(!IssueEnd){alert("请选择截止日期！");return false;}}
else{var url=escape(document.location.toString());window.location.href="/Job/JobStop?JobID="+_("JobID").value+"&url="+url;return false;}
window.location.href="/Job/JobIssueProc?Type="+type+"&JobID="+$('#JobID').val()+"&IssueEnd="+IssueEnd+"&url="+url;return false;}
function checkSubmit(){if(_("UserName").value==""){popbox.error('请输入用户名或Email');_("UserName").focus();_("UserName").style.color='#000';return false;}
if(_("Password").value==""){popbox.error('请输入密码');_("Password").focus();return false;}
_("UserName").value=escape(_("UserName").value);_("Password").value=escape(_("Password").value);return true;}
function AjaxGetCpJobList(Cpmainid,Type){addLoading();Ajax("post","/Personal/js/ajaxGetCpJobList","CpMainID="+Cpmainid+"&Type="+Type,ShowAjaxList,true);}
function AjaxGetApplyJobList(PageNo,id){addLoading();location.hash="pageno"+PageNo;Ajax("post","/Personal/jm/AjaxGetApplyJobList","PageNo="+PageNo+"&&cv="+id,ShowAjaxList,true);var pageTmp=PageNo-1;if(PageNo!=1){var pageTmp=PageNo-1;onTopClick("#lst"+pageTmp);}}
function AjaxGetFavorateJobList(PageNo){addLoading();Ajax("post","/Personal/jm/AjaxGetFavorateJobList","PageNo="+PageNo,ShowAjaxList,true);}
function AjaxGetJobScanList(PageNo){addLoading();Ajax("post","/Personal/jm/AjaxGetJobScanList","PageNo="+PageNo,ShowAjaxList,true);}
function AjaxGetRecommendJobList(PageNo,CvID){addLoading();Ajax("post","/Personal/js/AjaxGetRecommendJobList","PageNo="+PageNo+"&cvid="+CvID,ShowAjaxList,true);}
function AjaxGetInterViewList(PageNo){addLoading();Ajax("post","/Personal/jm/AjaxGetInterViewList","PageNo="+PageNo,ShowAjaxList,true);}
function AjaxGetCvIntentionList(PageNo){addLoading();Ajax("post","/Personal/jm/AjaxGetCvIntentionList","PageNo="+PageNo,ShowAjaxList,true);}
function AjaxGetAttentionList(PageNo,id){addLoading();location.hash="pageno"+PageNo;Ajax("post","/Personal/jm/AjaxGetAttentionList","PageNo="+PageNo+"&&cv="+id,ShowAjaxList,true);var pageTmp=PageNo-1;if(PageNo!=1){var pageTmp=PageNo-1;onTopClick("#lst"+pageTmp);}}
function AjaxGetCvList(PageNo){addLoading();location.hash="pageno1";Ajax("post","/Personal/cvm/AjaxCvList","PageNo="+PageNo,ShowAjaxList,true);}
function AjaxGetEducationList(CvID){addLoading();location.hash="pageno1";Ajax("post","/Personal/cvm/AjaxEducationList?cvid="+CvID,"PageNo=1",ShowAjaxList,true);}
function AjaxGetExperienceList(CvID){addLoading();location.hash="pageno1";Ajax("post","/Personal/cvm/AjaxExperienceList?cvid="+CvID,"PageNo=1",ShowAjaxList,true);}
function URL_Request(strHref,strName){var intPos=strHref.indexOf("?");var strRight=strHref.substr(intPos+1);var arrTmp=strRight.split("&");for(var i=0;i<arrTmp.length;i++){var dIntPos=arrTmp[i].indexOf("=");var paraName=arrTmp[i].substr(0,dIntPos);var paraData=arrTmp[i].substr(dIntPos+1);if(paraName.toUpperCase()==strName.toUpperCase())
return paraData;}
return"";}
function AjaxGetRecruitmentList(PageNo,date,regionid,palaceid){addLoading();location.hash="pageno"+PageNo;Ajax("post","/personal/Recruitment/AjaxGetRecruitmentList","PageNo="+PageNo+"&&idPlaceId="+palaceid
+"&&idDate="+date+"&&idHomeRegion="+regionid,ShowAjaxList,true);var pageTmp=PageNo-1;onTopClick("#lst"+pageTmp);}
function AjaxGetGovNewsList(PageNo,typeid){addLoading();location.hash="pageno"+PageNo;Ajax("post","/personal/News/AjaxGetGovNewsList","PageNo="+PageNo,ShowAjaxList,true);var pageTmp=PageNo-1;onTopClick("#lst"+pageTmp);}
function AjaxGetJobNewsList(PageNo){addLoading();location.hash="pageno"+PageNo;Ajax("post","/personal/News/AjaxGetJobNewsList","PageNo="+PageNo,ShowAjaxList,true);if(PageNo!=1){var pageTmp=PageNo-1;onTopClick("#lst"+pageTmp);}}
function AjaxGetJobNews(PageNo,TypeNo){addLoading();location.hash="pageno"+PageNo+"&typeno"+TypeNo;Ajax("post","/personal/News/AjaxGetJobNews","PageNo="+PageNo+"&TypeNo="+TypeNo,ShowAjaxList,true);if(PageNo!=1){var pageTmp=PageNo-1;onTopClick("#lst"+pageTmp);}}
function AjaxGetSchoolList(PageNo){addLoading();location.hash="pageno"+PageNo;Ajax("post","/personal/News/AjaxGetSchoolList","PageNo="+PageNo,ShowAjaxList,true);var pageTmp=PageNo-1;onTopClick("#lst"+pageTmp);}
function AjaxGetCampusList(PageNo,regionID,schoolID){addLoading();Ajax("post","/personal/News/AjaxGetCampusList","pageno="+PageNo+"&&dcRegionID="+regionID+"&&idSchoolID="+schoolID,ShowAjaxList,true);var pageTmp=PageNo-1;onTopClick("#lst"+pageTmp);}
function onTopClick(divurl){$('html, body, .content').animate({scrollTop:$(divurl).offset().top-56},300);}
function AjaxGetCampusContent(PageNo,companyid,id){addLoading();location.hash="pageno"+PageNo+"&&companyid="+companyid+"&&id="+id;Ajax("post","/personal/News/AjaxGetCampusContent","PageNo="+PageNo+"&&companyid="+companyid+"&&id="+id,ShowAjaxList,true);var pageTmp=PageNo-1;if(PageNo!=1){var pageTmp=PageNo-1;onTopClick("#lst"+pageTmp);}}
function AjaxGetRecruitmentPersonList(PageNo,id){addLoading();location.hash="pageno"+PageNo;Ajax("post","/personal/Recruitment/AjaxGetRecruitmentPersonList","PageNo="+PageNo+"&&id="+id,ShowAjaxList,true);if(PageNo!=1){var pageTmp=PageNo-1;onTopClick("#lst"+pageTmp);}}
function AjaxGetRecruitmentCompanyList(PageNo,id){addLoading();location.hash="pageno"+PageNo;Ajax("post","/personal/Recruitment/AjaxGetRecruitmentCompanyList","PageNo="+PageNo+"&&id="+id,ShowAjaxList,true);if(PageNo!=1){var pageTmp=PageNo-1;onTopClick("#lst"+pageTmp);}}
function AjaxGetMyBespeak(PageNo){addLoading();location.hash="pageno"+PageNo;Ajax("post","/personal/parm/AjaxGetMyBespeak","PageNo="+PageNo,ShowAjaxList,true);var pageTmp=PageNo-1;if(PageNo!=1){var pageTmp=PageNo-1;onTopClick("#lst"+pageTmp);}}
function AjaxReceivedInvitation(PageNo){addLoading();location.hash="pageno"+PageNo;Ajax("post","/personal/parm/AjaxReceivedInvitation","PageNo="+PageNo,ShowAjaxList,true);var pageTmp=PageNo-1;if(PageNo!=1){var pageTmp=PageNo-1;onTopClick("#lst"+pageTmp);}}
function AjaxInviteCpLog(PageNo,id){addLoading();location.hash="pageno"+PageNo;Ajax("post","/personal/PaRm/AjaxInviteCpLog","PageNo="+PageNo+"&&id="+id,ShowAjaxList,true);if(PageNo!=1){var pageTmp=PageNo-1;onTopClick("#lst"+pageTmp);}}
function AjaxInviteApplyCp(PageNo,id){addLoading();location.hash="pageno"+PageNo;Ajax("post","/personal/parm/AjaxInviteApplyCp","PageNo="+PageNo+"&&cv="+id,ShowAjaxList,true);var pageTmp=PageNo-1;if(PageNo!=1){var pageTmp=PageNo-1;onTopClick("#lst"+pageTmp);}}
function AjaxInviteFavoriteCp(PageNo){addLoading();location.hash="pageno"+PageNo;Ajax("post","/personal/parm/AjaxInviteFavoriteCp","PageNo="+PageNo,ShowAjaxList,true);var pageTmp=PageNo-1;if(PageNo!=1){var pageTmp=PageNo-1;onTopClick("#lst"+pageTmp);}}
function AjaxGetChatOnlineList(PageNo){addLoading();location.hash="pageno"+PageNo;Ajax("post","/personal/chat/AjaxGetChatOnlineList","PageNo="+PageNo,ShowAjaxList,true);var pageTmp=PageNo-1;onTopClick("#lst"+pageTmp);}
function ShowAjaxList(obj){var data=unescape(obj.responseText);if(_("bk")){_("bk").innerHTML=_("bk").innerHTML.replace("拖至底部加载更多...","");_("bk").innerHTML=_("bk").innerHTML.replace("pagemore","");_("bk").innerHTML+=data;}
else
_("ApplyCv").innerHTML=data;document.body.style.minHeight="";removeLoading();}
function CheckForm(iType){if(!_("txtcvMainID").value){if(!(_("iddcJobTypeID").value||_("iddcJobTypeOldID").value||_("txtKeyWord").value)){popbox.error("期望职位、现从事职位、关键词必须至少选择一项");return false}
if(!(_("iddcRegionID").value||_("iddcLivePlace").value)){popbox.error("期望工作地点、当前所在地必须至少选择一项");return false}}
return true;}
function ShowMessage(){var html="<section class='pop '><p>"+obj.responseText+"</p></section>";popbox.show("")}
function checkKeyword(){if(document.getElementById("keyWord").value==""){popbox.error("请输入关键字");return false;}}
function ShowMsg(obj){document.getElementById("msgPop").innerHTML=obj.responseText;}
function CertificationResume(){var htm="<section class='pop' id='msgPop'><p style='height:200px'><div id='Loading' style='position:fixed; top:0; left:0;width:100%; height:100%' /> </div></p></section>";popbox.show(htm,1);Ajax("post","/personal/Cvm/ifmCertificationResume","",ShowMsg,true)}
function registerOneMinute2(email){var htm="<section class='popWin' id='msgPop'><p style='height:200px'><div id='Loading' style='position:fixed; top:0; left:0;width:100%; height:100%' /> </div></p></section>";popbox2.show(htm,0);Ajax("post","/personal/sys/frmOneMinute","email="+email,ShowMsg,true)}
function registerOneMinute(txtName,Gender,birth,iddcRegionID,txtMobile,Salary,iddcJobTypeID,cbIsNegotiable,txtSchool,iddcMajorID,txtMajorName,Degree,txtEmail){var htm="<section class='popWin' id='msgPop'><p style='height:200px'><div id='Loading' style='position:fixed; top:0; left:0;width:100%; height:100%' /> </div></p></section>";popbox2.show(htm,1);var param="a="+txtName+"&&b="+Gender+"&&c="+birth+"&&d="+iddcRegionID+"&&e="+txtMobile+"&&f="+Salary+"&&g="+iddcJobTypeID+"&&h="+cbIsNegotiable+"&&i="+txtSchool+"&&j="+iddcMajorID+"&&k="+txtMajorName+"&&l="+Degree+"&&m="+txtEmail;Ajax("post","/personal/sys/frmOneMinute",param,ShowMsg,true)}
function showInviteCpBatch(stype,rmid){var cpids="";var intRmID=0;if(rmid)
intRmID=rmid;$('.ck_yes').each(function(){if(typeof($(this).attr('cpid'))!="undefined"){cpids+=$(this).attr('cpid')+",";}});if(cpids){if(cpids.length>0){cpids=cpids.substr(0,cpids.length-1);}
location.href="/personal/parm/showInviteCpBatch?rmid="+intRmID+"&&cpid="+cpids+"&&stype="+stype;}
else{popbox.error("请选择企业");}}
function showInviteCp(rmid,cpid,cpname){location.href="/personal/parm/ShowInviteCp?rmid="+rmid+"&cpid="+cpid+"&cpname="+escape(cpname);}
function DeleteApllyJob(){var cpids="";$('.ck_yes').each(function(){cpids+=$(this).attr('cpid')+",";});if(cpids){if(cpids.length>0){cpids=cpids.substr(0,cpids.length-1);if(confirm("您确定要删除选中的申请的职位吗？"))
window.location.href="/personal/jm/JobApplyDelete?id="+cpids;}
else{popbox.error("请选择您要删除的职位！");}}
else{popbox.error("请选择您要删除的职位！");}}
function ChatOnlineCv(id){var cvid="";cvid=document.getElementById("jobSelect").value;_("cvid").value=cvid;_("caid").value=id;document.frmChat.submit();}
function ChatOnlineCvTow(id,cvid){_("cvid").value=cvid;_("caid").value=id;document.frmChat.submit();}