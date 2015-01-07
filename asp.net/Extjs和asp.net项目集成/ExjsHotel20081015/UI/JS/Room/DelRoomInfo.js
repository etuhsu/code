// JScript 文件

DelRoomInfos=function(row)
{
     var deletesplit="";
    for(var i=0;i<row.length;i++)
    {
                if(row.length==1)
                {
                    deletesplit=row[i].data.roomid;
                }
                else
                {
                    
                    if(i<(row.length-1))
                    {
                        deletesplit=row[i].data.roomid+","+deletesplit;
                    }
                    if(i==(row.length-1))
                   {
                        deletesplit=deletesplit+row[i].data.roomid;
                   } 
                }
     } 
      Ext.Ajax.request({
            url:"URL/Room/DelRoomInfo.aspx",
            method:"POST",
            params:{
                   roomid:deletesplit
            },
            success:function()
            {
                   //Ext.Msg.alert("恭喜您","删除成功了!");
                   Roomstore.reload();
            },
            failure:function()
            {
                   Ext.Msg.alert("提 示","删除失败了!");
            }
            });
     
}
