/*
var share_link = _Link.replace("&share=help","");
var share_content="{$card_content}";
var share_title="{$card_title}";
var share_img="{$card_background}";

var dataForWeixin={
	appId:	"",
	img:	share_img,  
	url:	share_link,
	title:	share_title,
	desc:	share_content,
	fakeid:	"",
};
*/
function addFirend(){
  
WeixinJSBridge.invoke("addContact", {webtype: "1",username: 'w3UxKTrED2dwrX5K9yDR'}, function(e) {
            WeixinJSBridge.log(e.err_msg);
            //e.err_msg:add_contact:added 已经添加
            //e.err_msg:add_contact:cancel 取消添加
            //e.err_msg:add_contact:ok 添加成功
            if(e.err_msg == 'add_contact:added' || e.err_msg == 'add_contact:ok'){
                //关注成功，或者已经关注过
            }
        })
}

(function(){
	var onBridgeReady=function(){
		// 发送给好友;
		WeixinJSBridge.on('menu:share:appmessage', function(argv){
			WeixinJSBridge.invoke('sendAppMessage',{
				"appid":		dataForWeixin.appId,
				"img_url":		dataForWeixin.img,
				"img_width":	"120",
				"img_height":	"120",
				"link":				dataForWeixin.url,
				"desc":				dataForWeixin.desc,
				"title":			dataForWeixin.title
			}, function(res){});
		});
		// 分享到朋友圈;
		WeixinJSBridge.on('menu:share:timeline', function(argv){
			WeixinJSBridge.invoke('shareTimeline',{
			"img_url":dataForWeixin.img,
			"img_width":"120",
			"img_height":"120",
			"link":dataForWeixin.url,
			"desc":dataForWeixin.desc,
			"title":dataForWeixin.title
			}, function(res){});
		});
		// 分享到微博;
		WeixinJSBridge.on('menu:share:weibo', function(argv){
			WeixinJSBridge.invoke('shareWeibo',{
			"content":dataForWeixin.title+' '+dataForWeixin.url,
			"url":dataForWeixin.url
			}, function(res){});
		});
		// 分享到Facebook
		WeixinJSBridge.on('menu:share:facebook', function(argv){
			WeixinJSBridge.invoke('shareFB',{
			"img_url":dataForWeixin.img,
			"img_width":"120",
			"img_height":"120",
			"link":dataForWeixin.url,
			"desc":dataForWeixin.desc,
			"title":dataForWeixin.title
			}, function(res){});
		});
	};
	if(document.addEventListener){
		document.addEventListener('WeixinJSBridgeReady', onBridgeReady, false);
	}else if(document.attachEvent){
		document.attachEvent('WeixinJSBridgeReady'   , onBridgeReady);
		document.attachEvent('onWeixinJSBridgeReady' , onBridgeReady);
	}
})();