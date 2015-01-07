// JScript 文件

  
function MarOnEnterFrame(MarObj){
if(MarObj.scrollTop>=MarObj.height*3){
   MarObj.timer=0;
   MarObj.innerHTML=reDrawContent(MarObj.innerHTML);
   MarObj.scrollTop=MarObj.height;
}else{
   MarObj.scrollTop+=MarObj.height/100;
}
}
function reDrawContent(content){
var items=content.split("<!---->");
var tempitem=items[0];
for(var i=1;i<items.length;i++){
   items[i-1]=items[i];
}
items[items.length-1]=tempitem;
return items.join("<!---->");
}