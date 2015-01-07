// JScript 文件

DelPublishInfoFns=function(row)
{
     var deletesplit="";
    for(var i=0;i<row.length;i++)
    {
                if(row.length==1)
                {
                    deletesplit=row[i].data.pubid;
                }
                else
                {
                    
                    if(i<(row.length-1))
                    {
                        deletesplit=row[i].data.pubid+","+deletesplit;
                    }
                    if(i==(row.length-1))
                   {
                        deletesplit=deletesplit+row[i].data.pubid;
                   } 
                }
     } 
      Ext.Ajax.request({
            url:"URL/Publish/DelPublishInfo.aspx",
            method:"POST",
            params:{
                   pubids:deletesplit
            },
            success:function()
            {
                   //Ext.Msg.alert("恭喜您","删除成功了!");
                   PublishInfoStore.reload();
            },
            failure:function()
            {
                   Ext.Msg.alert("提 示","删除失败了!");
            }
            });
}
