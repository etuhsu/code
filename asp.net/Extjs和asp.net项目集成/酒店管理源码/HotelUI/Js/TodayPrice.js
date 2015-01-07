//今日房价
var storeToday = new Ext.data.Store //设置为全局变量
(
    {
        //表示从哪里获得数据
        proxy:new Ext.data.HttpProxy 
        (
            {
                url:'/HotelUI/Json/PriceGrid.aspx' //数据源路径
            }
        ),
        
        //解析Json
        reader: new Ext.data.JsonReader
        (
            {
                root:'data',
                id: 'GetTodayPrice',
                fields:
                [
                    'TypeName','TypePrice'
                ]   
            }
        ),
        remoteSort:true
    }
);


Ext.onReady
(
    function()
    {
        var colModel = new Ext.grid.ColumnModel
        (
            [  
                {header:"房间类型",width:80,align:'center',dataIndex:'TypeName'},
                {header:"房间价格",width:70,align:'center',renderer:getColor,dataIndex:'TypePrice'}
            ]
        );
        
        //设置金额颜色
        function getColor(val)
        {
            return '<span style="color:blue;">'+ '$' + val + '</span>';
        }
        
        var grid = new Ext.grid.GridPanel
        (
            {
                renderTo:'moneyGrid',
                height:500,
                width:180,
                cm:colModel,
                store:storeToday,
                trackMouseOver:true, //鼠标特效
                loadMask: true,
                autoShow : true
            }
        )
        //加载数据
        storeToday.load();
    }
);

