// JScript 文件
//退房

DelOpenRoomInfo=function(row)
{
    //首先删除开房信息
    Ext.Ajax.request({
            url:"URL/OpenRoomInfo/DelOpenRoomInfo.aspx",
            method:"POST",
            params:{
                   openroomid:row.data.openroomid
            },
            success:function()
            {  
                   DelOpenRoomInfoWin.show();
            },
            failure:function()
            {
                   Ext.Msg.alert("提 示","删除开房信息失败!");
            }
            });
    
    var DelOpenRoomInfofp=new Ext.form.FormPanel({
			width:305,
			height:210,
			plain:true,
			layout:"form",
			defaultType:"textfield",
			labelWidth:75,
            baseCls:"x-plain",
			//锚点布局-
			defaults:{anchor:"95%",msgTarget:"side"},
			buttonAlign:"center",
			bodyStyle:"padding:0 0 0 0",
			items:[ 
			{  
			        name:"guestmoney",
			        xtype:'textfield',
					fieldLabel:"预付定金",
					readOnly:true,
					value:row.data.guestmoney,
					renderer:function(value)
					{
					    return value+"元";
					}
			},{
			        name:"roommoney",
			        xtype:"textfield",
					fieldLabel:"房费总额",
					readOnly:true
			},{
			        name:"totalremark",
			        xtype:"textarea",
					fieldLabel:"备注",
					allowBlank:false,
                    blankText:"详细备注不允许为空",
                    regex:/^[\s\S]{1,25}$/,
                    regexText:"详细备注请不要超过25个字符",
                    emptyText:"如果没有备注请填：暂无备注"
			}]
			
			});


 var DelOpenRoomInfoWin=new Ext.Window({
			title:"退房结帐",
			width:340,
			height:230,
			plain:true,
			iconCls:"addicon",
			//不可以随意改变大小
			resizable:false,
			//是否可以拖动
			//draggable:false,
			defaultType:"textfield",
			labelWidth:100,
			collapsible:true, //允许缩放条
            closeAction : 'hide',
            closable:false,
            plain : true,
            //弹出模态窗体
			modal: 'true', 
			buttonAlign:"center",
			bodyStyle:"padding:10px 0 0 15px",
			items:[DelOpenRoomInfofp],
			listeners:{
			    "show":function()
			    { 
			        
                     DelOpenRoomInfofp.form.load(
                                {
                                    url:"DATA/OpenRoomRecordInfo/DelRoomOpenInfo.aspx?roomid="+row.data.roomid,
                                    method:"get",
                                    success:function(form,action)
                                    {  
                                        
                                    },
                                    failure:function(form,action)
                                    {
                                        
                                        Ext.Msg.alert("提示信息","对不起加载数据失败!");
                                    }
                                }
                     ); 
			    }
			},
			buttons:[{
					text:"确认结帐",
					minWidth:70,
					handler:function()
					{
						if(DelOpenRoomInfofp.getForm().isValid())
                            {
                                //弹出效果
                                Ext.MessageBox.show
                                (
                                    {
                                        msg: '正在结帐，请稍等...',
							            progressText: 'Saving...',
							            width:300,
							            wait:true,
							            waitConfig: {interval:200},
							            icon:'download',
							            animEl: 'saving'
                                    }
                                );
                                setTimeout(function(){}, 1000);
                                DelOpenRoomInfofp.form.submit({
                                    url:"URL/TotalInfo/SaveRoomMoneyInfo.aspx",
                                    method:"POST",
                                    success:function(form,action)
                                    {
                                        //成功后
                                        var flag=action.result.success;
                                        if(flag=="true")
                                        {
                                            Ext.MessageBox.alert("提 示！","结帐成功!");
                                            DelOpenRoomInfoWin.hide();
                                            RoomOpenInfostore.reload();
                                        }
                                    },
                                    failure:function(form,action)
                                    {
                                        Ext.MessageBox.alert("提示!","结帐失败!");
                                    }
                                });
                           }
					}
			}]
	
	});
    
}
