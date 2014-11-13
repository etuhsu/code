var instance;
var curnumber = 0;
document.addEventListener('DOMContentLoaded', function(){
  var bua = navigator.userAgent.toLowerCase();
  if(bua.indexOf('iphone') >= 0 || bua.indexOf('ipod') >= 0){
    $('body').css("height",window.innerHeight+100);  
    window.scrollTo(0, 1);
    $("body").css("height",window.innerHeight);
  }
  var myPhotoSwipe = Code.PhotoSwipe.attach( window.document.querySelectorAll('#Gallery a'), {allowUserZoom:false,preventHide:true,captionAndToolbarHide:true,loop:false} );
  myPhotoSwipe.show(curnumber);
  for(var i=0;i<6;i++){
    $('#item_'+i).click(function(){
      var ing_num = $(this).attr('num').split("_"); 
      var shownum = parseInt(ing_num[0]);
      myPhotoSwipe.slideCarousel(shownum);
      $('#curnumber').html(shownum+1);
      $('#imgdetail').html($('#img_'+shownum+' a').attr('alt'));
      for(var j=0;j<6;j++){
        $('#item_'+j).attr('class','awhite');
      }
      $(this).attr('class','ablue');
    })
  }
}, false);

function loaded() {
  myScroll = new iScroll('wrapper', {zoom:true,hScrollbar:false,vScrollbar:false});
}
document.addEventListener('touchmove', function (e) { e.preventDefault();}, false);
document.addEventListener('DOMContentLoaded', loaded, false);

