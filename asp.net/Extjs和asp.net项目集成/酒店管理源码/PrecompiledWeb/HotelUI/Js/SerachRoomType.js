//查看房间类型
var strSearchType;
function SerachRoomType()
{  
    Ext.QuickTips.init();
    Ext.form.Field.prototype.msgTarget = 'side'; 
    
    var bd = Ext.getBody();
    
    //获得数据
    strSearchType = new Ext.data.Store
    (
        {
            proxy: new Ext.data.HttpProxy
            (
                {
                    url:'/HotelUI/Json/GetAllRoomType.aspx'      
                }
            ),
            //解析Json
            reader: new Ext.data.JsonReader
            (
                {
                    root:'data',
                    id: 'TypeId',
                    fields:
                    [
                        'TypeId','TypeName','TypePrice','IsTv','IsKongTiao','Remark'
                    ]   
                }
            ),
            remoteSort:true
        }
    );
    //加载数据
    strSearchType.load();
    
    var colModel = new Ext.grid.ColumnModel
    (
        [  
            {header:"房间类型",width:90,align:'center',dataIndex:'TypeName'},
            {header:"房间价格",width:90,align:'center',renderer:getPrice,dataIndex:'TypePrice'},
            {header:"是否有电视",width:80,align:'center',dataIndex:'IsTv'},
            {header:"是否有空调",width:80,align:'center',dataIndex:'IsKongTiao'},
            {header:"备注",width:150,dataIndex:'Remark'}
        ]
    );
    
    //设置价格颜色及样式
    function getPrice(val)
    {
        if (val != "")
        {
            return '<span style="color:red;">'+ '$' + val + '</span>';
        }        
    }
    
    var AllRoomType = new Ext.FormPanel
    (
        {             
            id: 'company-form',           
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
                        store:strSearchType,
	                    height: 220,
	                    width:280,
	                    title:'酒店房间类型信息',
	                    monitorWindowResize: false,
                        autoSizeColumns: true,
	                    trackMouseOver:true, //鼠标特效
	                    //头部
                        tbar:
                        [
                            '房间类型搜索',
                            {xtype:'textfield',width:170,id:'searchType',name:'searchType'},
                            {text:'搜索',iconCls:'search',handler:SerachGridRoomType},{xtype:'tbseparator'}
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
            title : '查看房间类型',
            items : AllRoomType
        }
    )
    //显示窗体
    newWin.show();
}

//搜索房间类型的方法
function SerachGridRoomType()
{
    //获得搜索内容
    var message = Ext.get('searchType').dom.value;
    //重新加载
    strSearchType.reload
    (
        {
            params:{msg:message}
        }
    )
}



