//退房方法
function CloseRoom(OpenRoomId,RoomNumber,TypeName,TypePrice,OpenTime,GuestMoney,GuestNumber,GuestName,Remark)
{   
    //计算余额
    var balance = GuestMoney - TypePrice;
    Ext.QuickTips.init();
    Ext.form.Field.prototype.msgTarget = 'side';
    var closeRoom = new Ext.FormPanel
    (
        {
            labelWidth:75,
            frame : true,
            title : '退房清单',
            width : 260,
            waitMsgTarget : true,
            items:
            [
                new Ext.form.TextField
                (
                    {
                        fieldLabel: '房间号',
                        name: 'RoomNumber',
                        allowBlank:false,
                        value: RoomNumber
                    }
                ),
                new Ext.form.TextField
                (
                    {
                        fieldLabel: '房间类型',
                        name: 'RoomType',
                        allowBlank:false,
                        value: TypeName
                    }
                ),
                new Ext.form.TextField
                (
                    {
                        fieldLabel: '登记姓名',
                        name: 'GuestName',
                        allowBlank:false,
                        value: GuestName
                    }
                ),
                new Ext.form.TextField
                (
                    {
                        fieldLabel: '登记身份证',
                        name: 'GuestNumber',
                        allowBlank:false,
                        value: GuestNumber
                    }
                ),
                new Ext.form.TextField
                (
                    {
                        fieldLabel: '开房时间',
                        name: 'OpenTime',
                        allowBlank:false,
                        value: OpenTime
                    }
                ),
                new Ext.form.TextField
                (
                    {
                        fieldLabel: '预交金额',
                        name: 'BefarePrice',
                        allowBlank:false,
                        value: GuestMoney
                    }
                ),
                new Ext.form.TextField
                (
                    {
                        fieldLabel: '找补金额',
                        name: 'ZhaoPrice',
                        allowBlank:false,
                        value: balance
                    }
                )
            ],
            buttons:
            [
                {
                    id:'btnOk',
                    text:'退  房',
                    handler:function()
                    {
                        //如果验证合法
                        if (closeRoom.form.isValid())
                        {
                            //弹出效果
                            Ext.MessageBox.show
                            (
                                {
                                    msg: '正在执行退房，请稍等...',
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
                            closeRoom.form.submit
                            (
                                {
                                    url:'/HotelUI/Form/CloseRoom.aspx',  //提交的页面路径
                                    method:'post',//提交方式为post
                                    //提交成功的回调函数
					                success:function(form,action)
					                {
					                    var flage = action.result.success;
					                    //如果服务器端传过来的数据为true则表示登录成功
					                    if (flage == true)
					                    {
					                        Ext.MessageBox.alert('恭喜','退房成功!');
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
            layout:'fit',
            width:260,
            height:300,
            collapsible:true, //允许缩放条
            closeAction : 'hide',
            plain : true,
            modal: 'true', 
            items : closeRoom
        }
    );
    //显示窗体
    newWin.show();    
    
}

