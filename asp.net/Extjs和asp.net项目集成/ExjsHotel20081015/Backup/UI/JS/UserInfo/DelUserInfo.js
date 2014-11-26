// JScript 文件

DeleteUserInfoFn=function(row)
{
            var deletesplit="";
            for(var i=0;i<row.length;i++)
            {
                        if(row.length==1)
                        {
                            deletesplit=row[i].data.id;
                        }
                        else
                        {
                            
                            if(i<(row.length-1))
                            {
                                deletesplit=row[i].data.id+","+deletesplit;
                            }
                            if(i==(row.length-1))
                           {
                                deletesplit=deletesplit+row[i].data.id;
                           } 
                        }
             } 
            Ext.Ajax.request({
            url:"URL/UserInfo/DelUserInfo.aspx",
            method:"POST",
            params:{
                   userinfo:deletesplit
            },
            success:function()
            {
                   UserInfoStore.reload();
            },
            failure:function()
            {
                   Ext.Msg.alert("提 示","删除失败了!");
            }
            });
}
