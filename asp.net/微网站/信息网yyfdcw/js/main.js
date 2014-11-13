 
//内容介绍更多
$(document).ready(function(){
 
	//参数折叠
	var project_info_show=true;
	$("#info_box_project_info .info_content").css("height","75px");
   $("#info_box_project_info_btn").click(function(){
   	 project_info_show =!project_info_show;
   	if(project_info_show){
   	$("#info_box_project_info_btn").html('<i class="icon_down"></i>展开');
 	$("#info_box_project_info .info_content").css("height","75px");
 }else{
	$("#info_box_project_info_btn").html('<i class="icon_up"></i>收起');
 	$("#info_box_project_info .info_content").css("height","auto");
 }
   });
   //内容折叠
   var project_show=true;
$("#info_box_project_intro .info_content").css("height","25px");
 $("#info_box_project_intro_btn").click(function(){
   	 project_show =!project_show;
   	if(project_show){
   	$("#info_box_project_intro_btn").html('<i class="icon_down"></i>展开');
 	$("#info_box_project_intro .info_content").css("height","25px");
 }else{
	$("#info_box_project_intro_btn").html('<i class="icon_up"></i>收起');
 	$("#info_box_project_intro .info_content").css("height","auto");
 }
 
   });


/*
$("body").add($(window)).bind("scroll", function () {
            var st = $(document).scrollTop();
            (st > 50) ?  $("#call_bar").fadeIn(500) :  $("#call_bar").fadeOut(500);
        });
*/
 $("#btn_back").click(function(){
 	goback();
 });


 $("#app_down_close").click(function(){
 	$("#app_down_fullad").hide();

	//如果iOS 打开
	if (navigator.userAgent.match(/(iPhone|iPod|iPad);?/i)) {
		//$("#app-open-bar").show();
	}else{
		//$("#app-download-bar").show();
		//$("#app-open-bar").hide();
	}
 });

$("#app_oepn_btn").click(function(){
  gourl('http://app.house365.com/taofang/?channel=cptfxz');
});
 $("#bbs_app_open_btn").click(function(){
 	//$("#app_down_fullad").hide();

	//如果iOS 打开
	if (navigator.userAgent.match(/(iPhone|iPod|iPad);?/i)) {
		//$("#app-open-bar").show();
	}else{
		//$("#app-download-bar").show();
		//$("#app-open-bar").hide();
	}
 });
 $("#bbs_app_close_btn").click(function(){
 	$("#app_down_fullad").hide();
 });
  $("#bbs_app_down_btn").click(function(){
 	 window.location="http://app.house365.com/chafang/?channel=cptfxz";
 });
  $("#bbs_app_open_btn").click(function(){
 	open_bbs_app();
 });

$("#btn_gotop").goTop();


  $("#closetip").click(function(){
      $("#app-download-bar").hide();
      setCookie('closetip',true);
 });

 $("#openapp").click(function(){
     open_app();
 });
 $("#app_download_btn").click(function(){
     download_app();
 });
 $("#app_open_close").click(function(){
     $("#app-open-bar").hide();
	 setCookie('app-open-close',true);
 });

 $("#choose_title").click(function(){
     $("#choose_opts").show(); 
 });
 
 $("#app-popup_close").click(function(){
	 $("#app-popup-wrap").hide();
 });
 $("#app-popup_btn").click(function(){
     open_app();
 });
 

if(navigator.cookieEnabled && getCookie('app-open-close')==null){
   //$("#app-download-bar").show();
	//$("#app-open-bar").show(); 
}else{
	//$("#app-open-bar").show();
   //$("#app-download-bar").show();
}


//全屏广告
$("#app_down_fullad").show();



});

function download_app(){
 window.location.href="http://app.house365.com/taofang/?channel=cptfxz";
}

function open_app(){
	var ios_url="taofang://";
	var android_url="taofang://house365.app";
	if (navigator.userAgent.match(/(iPhone|iPod|iPad);?/i)) {
		//打开
		//alert(ios_url);
		window.location.href=ios_url;
	}else if(navigator.userAgent.match(/android/i)){
		//alert(navigator.userAgent); 
		/**/
		var state = null;
		 try {
			 state = window.open(android_url, '_blank');
		}catch(e) {
		}
			if(state){
				window.close();
			} else {
				download_app();
			}
		
		setTimeout(download_app,500);
		//window.location.href=android_url; 
	}
}
function open_bbs_app(){
	var ios_url="bbschafang://";
	var android_url="bbschafang://house365.app";
	if (navigator.userAgent.match(/(iPhone|iPod|iPad);?/i)) {
		//打开
		//alert(ios_url);
		window.location=ios_url;
	}else if(navigator.userAgent.match(/android/i)){
		//alert(navigator.userAgent);
		//alert(android_url);
		 window.location=android_url;
	}
}