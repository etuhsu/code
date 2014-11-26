// JScript 文件

DeleteRoomTypeInfo=function(row)
{
            var deletesplit="";
            for(var i=0;i<row.length;i++)
            {
                        if(row.length==1)
                        {
                            deletesplit=row[i].data.typeid;
                        }
                        else
                        {
                            
                            if(i<(row.length-1))
                            {
                                deletesplit=row[i].data.typeid+","+deletesplit;
                            }
                            if(i==(row.length-1))
                           {
                                deletesplit=deletesplit+row[i].data.typeid;
                           } 
                        }
             } 
                    
            Ext.Ajax.request({
            url:"URL/RoomType/DelRoomType.aspx",
            method:"POST",
            params:{
                   typeids:deletesplit
            },
            success:function()
            {
                   //Ext.Msg.alert("恭喜您","删除成功了!");
                   //gird.store.reload();
                   RoomTypestore.reload();
            },
            failure:function()
            {
                   Ext.Msg.alert("提 示","删除失败了!");
            }
            });

}
