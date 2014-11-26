//删除酒店客房
//该源码首发自www.51aspx.com(５１ａｓpｘ．ｃｏｍ)

function DelRoom()
{
     //获得所有的客房Id(正在使用的除外)
     var strRoom =new Ext.data.Store
     (
        {
            proxy: new Ext.data.HttpProxy
            (
                {
                    url:'/HotelUI/Json/GetRoom.aspx'      
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
    strRoom.load();
    
    
    Ext.QuickTips.init();
    Ext.form.Field.prototype.msgTarget = 'side';
    var delRoom = new Ext.FormPanel
    (
        {
            labelWidth : 75,
            frame : true,
            title : '请仔细填写表单',
            width : 300,
            waitMsgTarget : true,
            items:
            [
                 new Ext.form.ComboBox
                 (
                    {
                        fieldLabel: '&nbsp;&nbsp;&nbsp;&nbsp;请选择客房',
                        labelStyle: 'width:100px',
                        width:150,
                        editable: false, //不允许输入
                        name: 'Number',
                        store:strRoom,
                        emptyText:'--请选择--',
                        allowBlank:false, //不允许为空
                        blankText:'请选择客房', //错误提示信息
                        displayField:'Number',
                        valueField: 'Number',
                        hiddenName:'Number', //提交到后台的input的name   
                        mode: 'client', //数据是在本地
                        triggerAction: 'all',
                        selectOnFocus:true
                    }
                 )
           ],
           buttons:
            [
                {
                    id:'btnOk',
                    text:'确  定',
                    handler:function()
                    {
                        //如果验证合法
                        if (delRoom.form.isValid())
                        {
                            //弹出效果
                            Ext.MessageBox.show
                            (
                                {
                                    msg: '正在删除资料，请稍等...',
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
                            delRoom.form.submit
                            (
                                {
                                    url:'/HotelUI/Form/DelRoom.aspx',  //提交的页面路径
                                    method:'post', //提交方式为post
                                    //提交成功的回调函数
                                    success:function(form,action)
                                    {
                                        var flage = action.result.success;
                                        //如果服务器端传过来的数据为true则表示删除成功
                                        if (flage == true)
                                        {
                                            Ext.MessageBox.alert('恭喜','删除客房成功!');
                                            newWin.hide();
                                        }
                                    },
                                    //提交失败的回调函数
                                    failure:function()
                                    {
                                        Ext.MessageBox.alert('错误','服务器出现错误请稍后再试！');
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
            width : 320,
            height : 150,
            collapsible:true, //允许缩放条
            closeAction : 'hide',
            closable:true,
            plain : true,
            modal: 'true', 
            title : '删除客房信息',
            items : delRoom
        }
    );
    newWin.show();
}

