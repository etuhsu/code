// JScript 文件

DelRoleInfoFns=function(row)
{
      var deletesplit="";
            for(var i=0;i<row.length;i++)
            {
                        if(row.length==1)
                        {
                            deletesplit=row[i].data.roleid;
                        }
                        else
                        {
                            
                            if(i<(row.length-1))
                            {
                                deletesplit=row[i].data.roleid+","+deletesplit;
                            }
                            if(i==(row.length-1))
                           {
                                deletesplit=deletesplit+row[i].data.roleid;
                           } 
                        }
             } 
            Ext.Ajax.request({
            url:"URL/RoleInfo/DelRoleInfo.aspx",
            method:"POST",
            params:{
                   roleinfo:deletesplit
            },
            success:function()
            {
                   RoleInfoStore.reload();
            },
            failure:function()
            {
                   Ext.Msg.alert("提 示","删除失败了!");
            }
            });
}
