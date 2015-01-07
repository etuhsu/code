// JScript 文件

EditPublishInfoFns=function(row)
{
    var EditPublishForm=new Ext.form.FormPanel({
			width:375,
			height:200,
			plain:true,
			layout:"form",
			defaultType:"textfield",
			labelWidth:75,
            baseCls:"x-plain",
			//锚点布局-
			defaults:{anchor:"95%",msgTarget:"side"},
			buttonAlign:"center",
			bodyStyle:"padding:0 0 0 0",
			items:[ {
			        name:"pubid",
					fieldLabel:"<font color=red>公告ID</font>",
					allowBlank:false,
					readOnly:true
			},{
			        name:"pubtitle",
					fieldLabel:"公告标题",
					allowBlank:false,
                    blankText:"公告标题不允许为空",
					regex:/^[\s\S]{1,25}$/,
                    regexText:"公告标题请不要超过25个字符"
					
			},{
			        xtype:'textarea',
			        name:"pubcontent",
					fieldLabel:"公告内容",
					allowBlank:false,
                    blankText:"公告内容不允许为空",
					regex:/^[\s\S]{1,100}$/,
                    regexText:"公告内容请不要超过100个字符"
					
			}
			]});


 var EditPublishwin=new Ext.Window({
			title:"修改公告信息",
			width:410,
			height:220,
			plain:true,
			//layout:"form",
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
            //弹出模态窗体
			modal: 'true', 
			buttonAlign:"center",
			bodyStyle:"padding:10px 0 0 15px",
			items:[EditPublishForm],
			listeners:{
			    "show":function()
			    {
			        //当window show事件发生时清空一下表单
			        EditPublishForm.getForm().reset();
			         //加载表单数据
					EditPublishForm.getForm().loadRecord(row);
			    }
			},
			buttons:[{
					text:"保存信息",
					minWidth:70,
					handler:function()
					{
						if(EditPublishForm.getForm().isValid())
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
                                EditPublishForm.form.submit({
                                    url:"URL/Publish/EditPublishInfo.aspx",
                                    method:"POST",
                                    success:function(form,action)
                                    {
                                        //成功后
                                        var flag=action.result.success;
                                        if(flag=="true")
                                        {
                                            Ext.MessageBox.alert("恭喜","修改公告信息成功!");
                                            PublishInfoStore.reload();
                                            EditPublishwin.hide();
                                        }
                                    },
                                    failure:function(form,action)
                                    {
                                        PublishInfoStore.reload();
                                        Ext.MessageBox.alert("提示!","修改公告信息失败!");
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
			      
			        EditPublishForm.getForm().reset();
			         //加载表单数据
					EditPublishForm.getForm().loadRecord(row);
			    }
			},{
					text:"取 消",
					minWidth:70,
					handler:function()
					{
					    EditPublishwin.hide();
					}
			}]
	
	});
    
    EditPublishwin.show();
}
