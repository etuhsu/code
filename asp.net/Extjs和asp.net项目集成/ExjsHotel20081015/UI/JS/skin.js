// JScript 文件

 function changecss(name)
    {
       var date=new Date();
       date.setTime(date.getTime()+30*24*3066*1000);
       document.getElementsByTagName("link")[3].href="Ext/resources/css/"+name;
       document.cookie="css="+name+";expires="+date.toGMTString();//设置cookies
    }
  var cookiesArr=document.cookie.split(";");
  var css;
  for(var i=0;i<cookiesArr.length;i++)
  {
       var arr=cookiesArr[i].split("=");
       if(arr[0]=="css")
       {
          css=arr[1];
          break;
       }
  }
  document.getElementsByTagName("link")[3].href="Ext/resources/css/"+css;
  
   var skinID = "0";
            function setSkin(i)
            {
                var pattern = /[0-4]/;
                if(pattern.test(i))
                {
                    
                    for(j=0;j<5;j++)
                    {
                        var imgkin = document.getElementById("imgkin"+j);
                        imgkin.src = "images/skin/c"+j+"_0.gif"; 
                    }
                    var imgkin = document.getElementById("imgkin"+i);
                    imgkin.src = "images/skin/c"+i+"_1.gif";
                     if(i==0)
                    {
                        changecss('');
                    }
                     if(i==1)
                    {
                       changecss('xtheme-olive.css');
                       
                    }
                     if(i==2)
                    {
                       changecss('xtheme-gray.css');
                    }
                    if(i==3)
                    {
                        changecss('xtheme-purple.css');
                    }
                    if(i==4)
                    {      
                        changecss('xtheme-darkgray.css');
                    } 
                     
                    
                }
            }
