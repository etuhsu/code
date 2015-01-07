//1.我们首先创建一个全局变量
    //2.我们在创建一个XmlHttpRequest对象
    var xmlHttp;
    
    function createXmlHttpRequest()
    {
        if(window.XMLHttpRequest)
        {
            xmlHttp=new XMLHttpRequest();
        
            if(xmlHttp.overrideMimeType)
                {
                    xmlHttp.overrideMimeType("text/xml");
                }
        }
        else if(window.ActiveXObject)
        {
            try
            {
                xmlHttp=new ActiveXObject("Msxml2.XMLHTTP");   
            }
            catch(e)
            {
                xmlHttp=new ActiveXObject("Microsoft.XMLHTTP");   
            }
        }
        if(!xmlHttp)
        {
            window.alert("你的浏览器不支持创建XMLhttpRequest对象");
        }
        return xmlHttp;
    }
    

    function ReBtn()
    {

        window.location.reload();
    }
    
    function ValidateCode()
    {
        createXmlHttpRequest();
       
        var url="URL/ValidateCode.aspx?Code="+document.getElementById("TxtCode").value;
       
        xmlHttp.open("GET",url,true);
        
        xmlHttp.onreadystatechange=ValidateResult;
        
        xmlHttp.send(null);
    }
    
    function ValidateResult()
    {
        if(xmlHttp.readyState==4)
        {
            if(xmlHttp.status==200)
            { 
                if(xmlHttp.responseText=="YES")
                {
                   check();           
                }
                else
                {
                    window.alert("验证码输入错误");
                    window.location.reload();
                }
            }
        }
    }
    
    function check()
    {
        var userName=document.getElementById("TxtName").value;
        var userPwd=document.getElementById("TxtPwd").value;
        if(Login.isRight(userName+"",userPwd+"").value>0)
        {
            //判断用户状态是否可用
            if(Login.userState(userName+"").value==0)
            {
                 //得到用户权限类型
                Login.UserType(userName+"");
                //写入Session
                Login.WriteSession(userName+"");
                window.location.href='Index.aspx';
            }
            else
            {
                alert("对不起您的帐号己禁用");
            }          
        }
        else
        {
            alert("用户名或密码不正确!");  
        }
        
      }