//查账
function SerachMoney()
{
    
    Ext.QuickTips.init();
    Ext.form.Field.prototype.msgTarget = 'side';
    
     //获得数据
     var strSearchMoney = new Ext.data.Store
     (
        {
            proxy: new Ext.data.HttpProxy
            (
                {
                    url:'/HotelUI/Json/SerachMoney.aspx'      
                }
            ),
            //解析Json
            reader: new Ext.data.JsonReader
            (
                {
                    root:'data',
                    id: 'MoneyInfoId',
                    fields:
                    [
                        'MoneyInfoId','OpenTime','RoomNumber','GuestNumber','GuestName','MoneyDate','DetailsMoney'
                    ]   
                }
            ),
            remoteSort:true
        }
    );
    //加载数据
    strSearchMoney.load();
    
    var colModel = new Ext.grid.ColumnModel
    (
        [  
            {header:"开房时间",width:110,dataIndex:'OpenTime'},
            {header:"房间号",width:60,align:'center',dataIndex:'RoomNumber'},
            {header:"登记身份证",width:120,dataIndex:'GuestNumber'},
            {header:"登记姓名",width:85,align:'center',dataIndex:'GuestName'},
            {header:"退房时间",width:110,dataIndex:'MoneyDate'},
            {header:"金额",width:80,align:'center',renderer:getColor,dataIndex:'DetailsMoney'}
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
    
    var searchMoney = new Ext.FormPanel
    (
        {
            labelWidth:75,
            frame : true,
            width : 630,
            waitMsgTarget : true,
            items:
            [
                {
                    layout:'column',
                    border:false,
                    items:
                    [
                        {
                            columnWidth:.5,
                            layout: 'form',
                            border:false,
                            items:
                            [
                                {
                                    fieldLabel: '&nbsp;&nbsp;&nbsp;&nbsp;开始日期',
                                    id:'beginTime',
                                    xtype:'datefield',
                                    width: 120,   
                                    format: 'Y-m-d',  
                                    emptyText: '请选择日期 ...'    
                                }
                            ]
                        },
                        {
                            columnWidth:.5,
                            layout: 'form',
                            border:false,
                            items:
                            [
                                {
                                    fieldLabel: '&nbsp;&nbsp;&nbsp;&nbsp;截止日期',
                                    id:'endTime',
                                    xtype:'datefield',
                                    width: 120,   
                                    format: 'Y-m-d',      
                                    emptyText: '请选择日期 ...'    
                                    
                                }                 
                            ]
                        }
                    ]
                },
                                {
                                    xtype:'grid',
                                    cm:colModel,
                                    store:strSearchMoney,
                                    height:230,
                                    width:585, //这个不设置就没得滚动条
                                    title:'查询账目明细',
                                    monitorWindowResize: false,
                                    autoSizeColumns: true,
	                                trackMouseOver:true //鼠标特效
                                }
            ],
            buttons:
            [
                {
                    id:'btnOk',
                    text:'搜  索',
                    handler:function()
                    {
                        //获得开始日期和截止日期
                        var beginTime = Ext.get('beginTime').dom.value;
                        var endTime = Ext.get('endTime').dom.value;
                        //重新加载
                        strSearchMoney.reload
                        (
                            {
                                //把开始时间和截止时间当参数传递
                                params:{be:beginTime,en:endTime}
                            }
                        )
                    }
                },
                {
                    text:'取  消',
                    handler:function()
                            {
                                newWin.hide();
                            }
                }
            ]
        }
    );
    //定义窗体
    newWin = new Ext.Window
    (
        {
            layout : 'fit',
            width : 620,
            height : 350,
            collapsible:true, //允许缩放条
            closeAction : 'hide',
            closable:true,
            plain : true,
            modal: 'true', 
            title : '您的账目信息如下',
            items : searchMoney
        }
    )
    //显示窗体
    newWin.show();
}







