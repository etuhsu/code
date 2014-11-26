//主界面的Grid
//获得输入的字符串
//var message = ""; 
var storeMain=new Ext.data.Store
(
    {
        //表示从哪里获得数据
        proxy:new Ext.data.HttpProxy 
        (
            {
                url:'/HotelUI/Json/MainGrid.aspx'  
            }
        ),
        
        //解析Json
        reader: new Ext.data.JsonReader
        (
            {
                root:'data',
                id: 'OpenRoomId',
                fields:
                [
                    'OpenRoomId','Number','TypeName','TypePrice','OpenTime','GuestMoney','GuestNumber','GuestName','Remark'
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
                {header:"房间号",width:60,dataIndex:'Number'},   
                {header:"房间类型",width:80,dataIndex:'TypeName'},
                {header:"开房时间",width:110,dataIndex:'OpenTime'},
                {header:"预缴金额",width:80,renderer:getColor,dataIndex:'GuestMoney'},
                {header:"登记身份证",width:120,dataIndex:'GuestNumber'},
                {header:"客人姓名",width:85,dataIndex:'GuestName'},
                {header:"备注",width:120,dataIndex:'Remark'}
            ]
        );
        //设置金额颜色
        function getColor(val)
        {
            if (val != "")
            {
                return '<span style="color:red;">'+ '$' + val + '</span>';
            }
        }
        
        var grid = new Ext.grid.GridPanel
        (
            {
                renderTo:'grid',
                height:500,
                width:665,
                cm:colModel, //行列
                store:storeMain, //数据源
                trackMouseOver:true, //鼠标特效
                loadMask: true,
                autoShow : true,
                autoScroll: true,
                //头部
                tbar:
                [
                    '房间查询',
                    {xtype:'textfield',width:170,id:'title',name:'title'},
                    {text:'搜索',iconCls:'search',handler:SerachGrid},{xtype:'tbseparator'}
                ]
            }
        )
        //为右键菜单添加事件监听器
        grid.addListener('rowcontextmenu',rightClickFn);
        var rightClick = new Ext.menu.Menu
        (
            {
                id : 'rightClickCont',
                items:
                [
                    {
                        id: 'rMenu1',
                        handler: OpenRoom,//点击后触发的事件
                        text: '新开房间'
                    },
                    {
                        id:'rMenu2',
                        text:'退房',
                        handler: function()
                        {
                            var row = grid.getSelections();
                            if (row.length > 0)
                            {
                                var OpenRoomId = row[0].get('OpenRoomId');
                                var RoomNumber = row[0].get('Number');
                                var TypeName = row[0].get('TypeName');
                                var TypePrice = row[0].get('TypePrice');
                                var OpenTime = row[0].get('OpenTime');
                                var GuestMoney = row[0].get('GuestMoney');
                                var GuestNumber = row[0].get('GuestNumber');
                                var GuestName = row[0].get('GuestName');
                                var Remark = row[0].get('Remark');
                                //调用退房的方法
                                CloseRoom(OpenRoomId,RoomNumber,TypeName,TypePrice,OpenTime,GuestMoney,GuestNumber,GuestName,Remark); 
                            }
                            else
                            {
                                Ext.MessageBox.alert('警告','请选择退房的房间!');
                            }
                        }
                    }
                ]
            }
        );
        
        function rightClickFn(grid,rowIndex,e)
        {
            e.preventDefault();
            rightClick.showAt(e.getXY());
        }
        //加载数据
        storeMain.load();
    }
);

function SerachGrid()
{
    var message = Ext.get('title').dom.value;
    storeMain.reload
    (
        {
            params:{msg:message}
        }
    )
}

