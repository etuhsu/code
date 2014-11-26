// JScript 文件

AddPublishInFn=function()
{
    var AddPublishForm=new Ext.form.FormPanel({
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
			items:[   
			{
			        name:"userid",
					fieldLabel:"<font color=red>发布人</font>",
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


 var AddPublishwin=new Ext.Window({
			title:"发布公告信息",
			width:410,
			height:230,
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
			items:[AddPublishForm],
			listeners:{
			    "show":function()
			    {
			        //当window show事件发生时清空一下表单
			        AddPublishForm.getForm().reset();
			         //加载表单数据
					AddPublishForm.form.load(
                                {
                                    url:"DATA/UserInfo/LoadUserInfo.aspx?loginid="+loginid,
                                    method:"get",
                                    success:function(form,action)
                                    {   
                                    },
                                    failure:function(form,action)
                                    {
                                        Ext.Msg.alert("提示信息","对不起加载数据失败!请联系管理员");
                                    }
                                }
                    );
			    }
			},
			buttons:[{
					text:"保存信息",
					minWidth:70,
					handler:function()
					{
						if(AddPublishForm.getForm().isValid())
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
                                AddPublishForm.form.submit({
                                    url:"URL/Publish/AddPublishInfo.aspx",
                                    method:"POST",
                                    success:function(form,action)
                                    {
                                        //成功后
                                        var flag=action.result.success;
                                        if(flag=="true")
                                        {
                                            Ext.MessageBox.alert("恭喜","公告信息发布成功!");
                                            PublishInfoStore.reload();
                                            AddPublishwin.hide();
                                        }
                                    },
                                    failure:function(form,action)
                                    {
                                        PublishInfoStore.reload();
                                        Ext.MessageBox.alert("提示!","公告信息发布失败!");
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
			       //当window show事件发生时清空一下表单
			        AddPublishForm.getForm().reset();
			         //加载表单数据
					AddPublishForm.form.load(
                                {
                                    url:"DATA/UserInfo/LoadUserInfo.aspx?loginid="+loginid,
                                    method:"get",
                                    success:function(form,action)
                                    {   
                                    },
                                    failure:function(form,action)
                                    {
                                        Ext.Msg.alert("提示信息","对不起加载数据失败!请联系管理员");
                                    }
                                }
                    );
			    }
			},{
					text:"取 消",
					minWidth:70,
					handler:function()
					{
					    AddPublishwin.hide();
					}
			}]
	
	});
    
    AddPublishwin.show();
}
