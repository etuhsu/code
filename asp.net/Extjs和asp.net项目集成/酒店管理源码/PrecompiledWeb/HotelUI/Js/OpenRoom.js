// 开房
function OpenRoom()
{
     //获得房间类型
     var strType=new Ext.data.Store
     (
        {
            proxy: new Ext.data.HttpProxy
            (
                {
                    url:'/HotelUI/Json/GetAllRoomType.aspx'      
                }
            ),
            //读取Json
            reader: new Ext.data.JsonReader
            (
                {root:'data'},
                [
                    {name:'TypeId',type:'string'},
                    {name:'TypeName',type:'string'}
                ]                
            )
        }
    );
    strType.load();
    
    //获得房间编号
    var strRoomNumber = new Ext.data.Store
    (
        {
            proxy: new Ext.data.HttpProxy
            (
                {
                    url:'/HotelUI/Json/GetRoomByTypeId.aspx'
                }
            ),
            //读取Json
            reader: new Ext.data.JsonReader
            (
                {root:'data'},
                [
                    {name:'RoomId',type:'string'},
                    {name:'Number',type:'string'}
                ]
            )
        }
    );
    strRoomNumber.load();
    
    
    Ext.QuickTips.init();
    Ext.form.Field.prototype.msgTarget = 'side';
    
   
    
    var openForm = new Ext.FormPanel
    (
        {
            labelWidth:75,
            frame : true,
            title : '请仔细填写表单',
            width : 580,
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
                                CmoType = new Ext.form.ComboBox
                                (
                                    {
                                        fieldLabel: '&nbsp;&nbsp;&nbsp;&nbsp;选择房间类型',
                                        labelStyle: 'width:100px',
                                        width:150,
                                        editable: false, //不允许输入
                                        store:strType, //数据源
                                        emptyText:'--请选择--',
                                        allowBlank:false, //不允许为空
                                        blankText:'请选择类型', //错误提示信息
                                        displayField:'TypeName',
                                        valueField: 'TypeId',
                                        mode: 'client', //数据源在本地
                                        triggerAction: 'all',
                                        selectOnFocus:true,
                                        //添加监听事件
                                        listeners:
                                        {
                                            select:function()
                                            {
                                                var tyId = CmoType.getValue(); //获得选中的类型Id
                                                strRoomNumber.reload
                                                (
                                                    {
                                                        params:{typeId:tyId}
                                                    }
                                                )
 
                                            }
                                        }
                                    }
                                ),
                                CmoNumber = new Ext.form.ComboBox
                                (
                                    {
                                        fieldLabel: '&nbsp;&nbsp;&nbsp;&nbsp;选择房间编号',
                                        labelStyle: 'width:100px',
                                        width:150,
                                        editable: false, //不允许输入
                                        name: 'Number',
                                        store:strRoomNumber,
                                        emptyText:'--请选择--',
                                        allowBlank:false, //不允许为空
                                        blankText:'请选择编号', //错误提示信息
                                        displayField:'Number',
                                        valueField: 'RoomId',
                                        hiddenName:'RoomId',
                                        mode: 'client',
                                        triggerAction: 'all',
                                        selectOnFocus:true
                                    }
                                ),
                                    {
                                        xtype:'textfield',
                                        fieldLabel: '&nbsp;&nbsp;&nbsp;&nbsp;预缴金额',
                                        labelStyle: 'width:100px',
                                        width:80,
                                        name: 'money',
                                        allowBlank:false,
                                        blankText: '必须输入押金'
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
                                    xtype:'textfield',
                                    fieldLabel: '&nbsp;&nbsp;&nbsp;&nbsp;登记姓名',
                                    labelStyle: 'width:80px',
                                    width:150,
                                    name: 'guestName',
                                    allowBlank:false,
                                    blankText: '请输入姓名'
                                },
                                {
                                    xtype:'textfield',
                                    fieldLabel: '&nbsp;&nbsp;&nbsp;&nbsp;身份证号',
                                    labelStyle: 'width:80px',
                                    width:150,
                                    name: 'guestNumber',
                                    allowBlank:false,
                                    blankText: '请输入身份证号'
                                }
                            ]
                        }
                    ]
                },
                                {
                                    xtype:'textarea',
                                    name:'remark',
                                    fieldLabel:'&nbsp;&nbsp;&nbsp;&nbsp;备注',
                                    labelStyle: 'width:100px',
                                    height:150,
                                    width:170,
                                    anchor:'90%'
                                }
            ],
            buttons:
            [
                {
                    id:'btnOk',
                    text:'确  定',
                    handler:function()
                    {
                        //如果验证合法
                        if (openForm.form.isValid())
                        {
                            //弹出效果
                            Ext.MessageBox.show
                            (
                                {
                                    msg: '正在保存，请稍等...',
							        progressText: 'Saving...',
							        width:300,
							        wait:true,
							        waitConfig: {interval:200},
							        icon:'download',
							        animEl: 'saving'
                                }
                            );
                            setTimeout(function(){}, 10000);
                            //提交到服务器
                            openForm.form.submit
                            (
                                {
                                    url:'/HotelUI/Form/OpenRoom.aspx',  //提交的页面路径
                                    method:'post',//提交方式为post
                                    //提交成功的回调函数
									success:function(form,action)
									{
									    var flage = action.result.success;
									    //如果服务器端传过来的数据为true则表示登录成功
									    if (flage == true)
									    {
									        Ext.MessageBox.alert('恭喜','开房成功!');
									        storeMain.reload(); //重新加载Grid
									        newWin.hide();
									    }
									},
									//提交失败的回调函数
								    failure:function()
								    {
								        Ext.Msg.alert('错误','服务器出现错误请稍后再试！');
								    }
                                }
                            );
                        }
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
            width : 600,
            height : 350,
            collapsible:true, //允许缩放条
            closeAction : 'hide',
            closable:true,
            plain : true,
            modal: 'true', 
            title : '添加开房记录',
            items : openForm
        }
    )
    //显示窗体
    newWin.show();
}







