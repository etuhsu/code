///<reference path="vswd-ext_2.2.js"/>
///<reference path="jquery-1.3.2-vsdoc2.js"/>
//添加酒店客房
function AddRoom() {

    //获得房间类型
    var strType = new Ext.data.Store
     (
        {
            proxy: new Ext.data.HttpProxy
            (
                {
                    url: '/HotelUI/Json/GetAllRoomType.aspx'
                }
            ),
            //读取Json
            reader: new Ext.data.JsonReader
            (
                { root: 'data' },
                [
                    { name: 'TypeId', type: 'string' },
                    { name: 'TypeName', type: 'string' }
                ]
            )
        }
    );
    strType.load();

    //获得房间状态
    var strState = new Ext.data.Store
    (
        {
            proxy: new Ext.data.HttpProxy
            (
                {
                    url: '/HotelUI/Json/GetAllRoomState.aspx'
                }
            ),
            //读取Json
            reader: new Ext.data.JsonReader
            (
                { root: 'data' },
                [
                    { name: 'StateId', type: 'string' },
                    { name: 'StateName', type: 'string' }
                ]
            )
        }
    );
    strState.load();

    Ext.QuickTips.init();
    Ext.form.Field.prototype.msgTarget = 'side';
    var addRoom = new Ext.FormPanel
    (
        {
            labelWidth: 75,
            frame: true,
            title: '请仔细填写表单',
            width: 580,
            waitMsgTarget: true,
            items:
            [
                {
                    layout: 'column',
                    border: false,
                    items:
                    [
                        {
                            columnWidth: .5,
                            layout: 'form',
                            border: false,
                            items:
                            [
                                {
                                    xtype: 'textfield',
                                    fieldLabel: '&nbsp;&nbsp;&nbsp;&nbsp;房间编号',
                                    labelStyle: 'width:100px',
                                    width: 150,
                                    name: 'Number',
                                    allowBlank: false,
                                    blankText: '请输入编号'
                                },
                                {
                                    xtype: 'textfield',
                                    fieldLabel: '&nbsp;&nbsp;&nbsp;&nbsp;房间床位数',
                                    labelStyle: 'width:100px',
                                    width: 80,
                                    name: 'BedNumber',
                                    allowBlank: false,
                                    blankText: '请输入床位数'
                                }
                            ]
                        },
                        {
                            columnWidth: .5,
                            layout: 'form',
                            border: false,
                            items:
                            [
                                new Ext.form.ComboBox
                                (
                                    {
                                        fieldLabel: '&nbsp;&nbsp;&nbsp;&nbsp;选择房间类型',
                                        labelStyle: 'width:100px',
                                        width: 100,
                                        editable: false, //不允许输入
                                        name: 'TypeName',
                                        store: strType,
                                        emptyText: '--请选择--',
                                        allowBlank: false, //不允许为空
                                        blankText: '请选择类型', //错误提示信息
                                        displayField: 'TypeName',
                                        valueField: 'TypeId',
                                        hiddenName: 'TypeId',
                                        mode: 'client',
                                        triggerAction: 'all',
                                        selectOnFocus: true
                                    }
                                ),
                                new Ext.form.ComboBox
                                (
                                    {
                                        fieldLabel: '&nbsp;&nbsp;&nbsp;&nbsp;选择房间状态',
                                        labelStyle: 'width:100px',
                                        width: 100,
                                        editable: false, //不允许输入
                                        name: 'StateName',
                                        store: strState,
                                        emptyText: '--请选择--',
                                        allowBlank: false, //不允许为空
                                        blankText: '请选择状态', //错误提示信息
                                        displayField: 'StateName',
                                        valueField: 'StateId',
                                        hiddenName: 'StateId',
                                        mode: 'client',
                                        triggerAction: 'all',
                                        selectOnFocus: true
                                    }
                                )
                            ]
                        }
                    ]
                },
                                {
                                    xtype: 'textarea',
                                    name: 'remark',
                                    fieldLabel: '&nbsp;&nbsp;&nbsp;&nbsp;备注',
                                    labelStyle: 'width:100px',
                                    height: 120,
                                    width: 380
                                }
            ],
            buttons:
            [
                {
                    id: 'btnOk',
                    text: '确  定',
                    handler: function() {
                        //如果验证合法
                        if (addRoom.form.isValid()) {
                            //弹出效果
                            Ext.MessageBox.show
                            (
                                {
                                    msg: '正在保存，请稍等...',
                                    progressText: 'Saving...',
                                    width: 300,
                                    wait: true,
                                    waitConfig: { interval: 200 },
                                    icon: 'download',
                                    animEl: 'saving'
                                }
                            );
                            setTimeout(function() { }, 10000);
                            //提交到服务器
                            addRoom.form.submit
                            (
                                {
                                    url: '/HotelUI/Form/AddRoom.aspx',  //提交的页面路径
                                    method: 'post', //提交方式为post
                                    //提交成功的回调函数
                                    success: function(form, action) {
                                        var flage = action.result.success;
                                        //如果服务器端传过来的数据为true则表示登录成功
                                        if (flage == true) {
                                            Ext.MessageBox.alert('恭喜', '添加房间成功!');
                                            newWin.hide();
                                        }
                                    },
                                    //提交失败的回调函数
                                    failure: function() {
                                        Ext.Msg.alert('错误', '服务器出现错误请稍后再试！');
                                    }
                                }
                            );
                        }
                    }
                },
                {
                    text: '取  消',
                    handler: function() {
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
            layout: 'fit',
            width: 540,
            height: 300,
            collapsible: true, //允许缩放条
            closeAction: 'hide',
            closable: true,
            plain: true,
            modal: 'true',
            title: '添加酒店房间',
            items: addRoom
        }
    )
    //显示窗体
    newWin.show();
}



