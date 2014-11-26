//查看酒店客房
var strSerachRoom;
function SerachRoom()
{  

    Ext.QuickTips.init();
    Ext.form.Field.prototype.msgTarget = 'side'; 
    var bd = Ext.getBody();
    
    //获得数据
    strSerachRoom = new Ext.data.Store
     (
        {
            proxy: new Ext.data.HttpProxy
            (
                {
                    url:'/HotelUI/Json/GetAllRoom.aspx'      
                }
            ),
            //解析Json
            reader: new Ext.data.JsonReader
            (
                {
                    root:'data',
                    id: 'Number',
                    fields:
                    [
                        'Number','BedNumber','TypeName','StateName','Remark'
                    ]   
                }
            ),
            remoteSort:true
        }
    );
    //加载数据
    strSerachRoom.load();
    
    var colModel = new Ext.grid.ColumnModel
    (
        [  
            {header:"房间编号",width:90,align:'center',dataIndex:'Number'},
            {header:"床位数",width:90,align:'center',dataIndex:'BedNumber'},
            {header:"房间类型",width:80,align:'center',dataIndex:'TypeName'},
            {header:"房间状态",width:80,align:'center',renderer:getType,dataIndex:'StateName'},
            {header:"备注",width:150,align:'center',dataIndex:'Remark'}
        ]
    );
    //设置房间状态颜色
    function getType(val)
    {
        if (val == "入住")
        {
            return '<span style="color:red;">' + val + '</span>';
        }
        else
        {
            return '<span style="color:blue;">' + val + '</span>';
        }
        
    }
     //该源码首发自www.51aspx.com(５１ａsｐｘ．ｃｏｍ)

    var AllRoom = new Ext.FormPanel
    (
        {              
            id: 'company-all',          
            frame: true,
            labelAlign: 'left',
            bodyStyle:'padding:5px',
            width: 350,
            layout: 'column',
            items:
            [
                {

                    layout: 'fit',
                    items:
                    {
                        xtype: 'grid',
                        cm:colModel,
                        store:strSerachRoom,
	                    height: 220,
	                    width:280, //这个不设置就没得滚动条
	                    title:'酒店房间信息',
                        monitorWindowResize: false,
                        autoSizeColumns: true,
	                    trackMouseOver:true, //鼠标特效
	                    //头部
                        tbar:
                        [
                            '客房搜索',
                            {xtype:'textfield',width:170,id:'roomSerach',name:'roomSerach'},
                            {text:'搜索',iconCls:'search',handler:SerachGridRoom},{xtype:'tbseparator'}
                        ]
                    }
                }
            ],
        renderTo: bd
        }
    );
    //定义窗体
    newWin = new Ext.Window
    (
        {
            layout : 'fit',
            width : 550,
            height : 300,
            closeAction : 'hide',
            collapsible:true, //允许缩放条
            closable:true,
            plain : true,
            modal: true, 
            title : '查看房间信息',
            items : AllRoom
        }
    )
    //显示窗体
    newWin.show();
}
//搜索客房的方法
function SerachGridRoom()
{
    //获得搜索内容
    var message = Ext.get('roomSerach').dom.value;
    //重新加载
    strSerachRoom.reload
    (
        {
            params:{msg:message}
        }
    )
}



