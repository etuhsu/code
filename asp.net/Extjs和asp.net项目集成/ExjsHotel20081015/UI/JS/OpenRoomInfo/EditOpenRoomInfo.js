// JScript 文件
EditOpenRoomInfo=function(row){



var OpenRoomInfofp=new Ext.form.FormPanel({
			width:360,
			height:220,
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
                    name:"roomid",
			        xtype:'textfield',
					fieldLabel:"房间编号",
					readOnly:true,
					baseStyle:'x-plain'
            },
			{  
			        name:"guestmoney",
			        xtype:'numberfield',
					fieldLabel:"预付定金",
					allowBlank:false,
					readOnly:true,
                    blankText:"预付定金不允许为空",
                    emptyText:"定金只能填写数字"
					
			},{
			        name:"remark",
			        xtype:"textarea",
					fieldLabel:"详细备注",
					allowBlank:false,
                    blankText:"详细备注不允许为空",
                    regex:/^[\s\S]{1,50}$/,
                    regexText:"详细备注请不要超过50个字符",
                    emptyText:"如果没有备注请填：暂无备注"
					
			}]});


 var OpenRoomInfoWin=new Ext.Window({
			title:"修改开房信息",
			width:400,
			height:240,
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
            closable:true,
            plain : true,
            //弹出模态窗体
			modal: 'true', 
			buttonAlign:"center",
			bodyStyle:"padding:10px 0 0 15px",
			items:[OpenRoomInfofp],
			listeners:{
			    "show":function()
			    {
			        //当window show事件发生时清空一下表单
			        //OpenRoomInfofp.getForm().reset();
			        OpenRoomInfofp.getForm().loadRecord(row);
			    }
			},
			buttons:[{
					text:"保存信息",
					minWidth:70,
					handler:function()
					{
						if(OpenRoomInfofp.getForm().isValid())
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
                                setTimeout(function(){}, 1000);
                                OpenRoomInfofp.form.submit({
                                    url:"URL/OpenRoomInfo/EditOpenRoomInfo.aspx",
                                    method:"POST",
                                    success:function(form,action)
                                    {
                                        //成功后
                                        var flag=action.result.success;
                                        if(flag=="true")
                                        {
                                            Ext.MessageBox.alert("恭喜","信息保存成功!");
                                            OpenRoomInfoWin.hide();
                                            RoomOpenInfostore.reload();
                                        }
                                    },
                                    failure:function(form,action)
                                    {
                                        Ext.MessageBox.alert("提示!","信息保存失败!");
                                    }
                                });
                           }
					}
			},{
			    text:"重置",
			    minWidth:70,
			    qtip:"重置数据",
			    handler:function()
			    {
			          EditRoomTypeForm.getForm().loadRecord(rows);
			    }
			},{
					text:"取 消",
					minWidth:70,
					handler:function()
					{
					    OpenRoomInfoWin.hide();
					}
			}]
	
	});
	
	OpenRoomInfoWin.show();
};
