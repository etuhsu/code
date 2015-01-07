// JScript 文件

DelGuestInfo=function(row)
{
            var deletesplit="";
            for(var i=0;i<row.length;i++)
            {
                        if(row.length==1)
                        {
                            deletesplit=row[i].data.guestid;
                        }
                        else
                        {
                            
                            if(i<(row.length-1))
                            {
                                deletesplit=row[i].data.guestid+","+deletesplit;
                            }
                            if(i==(row.length-1))
                           {
                                deletesplit=deletesplit+row[i].data.guestid;
                           } 
                        }
             } 
            Ext.Ajax.request({
            url:"URL/GuestInfo/DelGuestInfo.aspx",
            method:"POST",
            params:{
                   guestids:deletesplit
            },
            success:function()
            {
                   GuestInfoStore.reload();
            },
            failure:function()
            {
                   Ext.Msg.alert("提 示","删除失败了!");
            }
            });
}
