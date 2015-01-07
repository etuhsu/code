 
 var ToDayTypePricefields=["typename","typeprice"];
 
var ToDayTypePricestore=new Ext.data.Store({
           autoLoad:true,
           proxy:new Ext.data.HttpProxy(
           {
                url:"DATA/ToDayTypePrice.aspx"
           }),
           reader:new Ext.data.JsonReader(
           {
                        fields:ToDayTypePricefields,
                        root:"data",
                        id:"typename",
                        totalProperty:"totalCount"
                       
           })
    });      
            
     
   var ToDayTypePricecm=new Ext.grid.ColumnModel([
           {
                header:"房间类型",
                dataIndex:"typename",
                tooltip:"房间类型名称",
                sortable:true,
                width:80,
                renderer:function(val)
                {
                    if (val != ""&& val!=null)
                    {
                        return '<b><span style="color:blue;">' + val + '</span></b>';
                    }
                    else if(val==null)
                    {
                        return '暂无数据';
                    }
                }
           },
           {
                header:"今天价格",
                dataIndex:"typeprice",
                tooltip:"房间类型今日价格",
                width:120,
                sortable:true,
                editor: new Ext.form.NumberField({
                    //allowBlank: false,
                    //blankText:"价格不允许为空"
                    style: 'text-align:left'
                }),
                renderer:function(value)
                {   //将数字转换为整数
                    if (value != null && value!="")
                    {
                        var a,b,c,i
                        a = value.toString();
                        b = a.indexOf('.');
                        c = a.length;
                      
                        if (b!=-1)
                            a = a.substring(0,b);
                        }
                        if (b==-1)
                        {
                            a = a + ".";
                            for (i=1;i<=c;i++)
                            a = a - "0";
                        }
                        else
                        {
                            a = a.substring(0,b+c+1);
                            for (i=c;i<=b+c;i++)
                            {
                             a = a - "0";
                            }
                        }
                        return '<font color=red><b>'+String.format("<font color=red><img src='images/money.png' width=12 height=12>{0}</font>",a)+'</b>&nbsp;元</font>';
                       
                 }
            }
        ]);
   
 
            
          
   var ToDayTypePricegrid=new Ext.grid.EditorGridPanel({
            width:200,
            border:false,
            autoHeight:true,
             //点击几次修改
            clicksToEdit:2,
            //autoExpandColumn:1,
            cm:ToDayTypePricecm,
            store:ToDayTypePricestore,
            loadMask:true,
            viewConfig:{
                columnsText:"显示/隐藏列",
                sortAscText:"正序排列",
                sortDescText:"倒序排列"
            },
            listeners:{
             "afteredit":function(e)
                 {   
                    var r=e.record;//得到当前行所有数据
                    var f=e.field;//得到修改列
                    var v=e.value;//得到修改列修改后值
                   if(r.data.typename!=null)
                   {
                        //通过ajax请求修改数据
                        Ext.Ajax.request({
                            url:"URL/RoomType/EditTodayRoomTypePrice.aspx",
                            method:"POST",
                            params:{
                                typename:r.data.typename,
                                typeprice:v
                            },
                            success:function()
                            {
                               
                                ToDayTypePricestore.reload();
                                
                            },
                            failure:function()
                            {
                                Ext.Msg.alert("不好意思","修改失败了!");
                                ToDayTypePricestore.reload();
                            }
                        });
                   }
                   
                 }
            }
   });
