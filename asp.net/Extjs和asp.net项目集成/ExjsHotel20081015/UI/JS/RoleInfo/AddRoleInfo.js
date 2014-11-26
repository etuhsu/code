// JScript 文件

AddRoleInfoFn=function()
{
    var AddRoleInfoForm=new Ext.form.FormPanel({
			width:315,
			height:100,
			plain:true,
			layout:"form",
			defaultType:"textfield",
			labelWidth:70,
            baseCls:"x-plain",
			defaults:{anchor:"95%",msgTarget:"side"},
			buttonAlign:"center",
			bodyStyle:"padding:0 0 0 0",
			items:[{
			        name:"rolename",
					fieldLabel:"角色名称",
					allowBlank:false,
                    blankText:"角色名称允许为空"
			},{
			        name:"roledesc",
					fieldLabel:"角色描述",
					allowBlank:false,
                    blankText:"角色描述不能为空"
			}
			]});


 var AddRoleInfoWin=new Ext.Window({
			title:"添加新用户",
			width:350,
			height:135,
			plain:true,
			layout:"form",
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
			items:[AddRoleInfoForm],
			listeners:{
			    "show":function()
			    {
			        AddRoleInfoForm.getForm().reset();
			    }
			},
			buttons:[{
					text:"保存信息",
					minWidth:70,
					handler:function()
					{
						if(AddRoleInfoForm.getForm().isValid())
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
                                AddRoleInfoForm.form.submit({
                                    url:"URL/RoleInfo/AddRoleInfo.aspx",
                                    method:"POST",
                                    success:function(form,action)
                                    {
                                        //成功后
                                        var flag=action.result.success;
                                        if(flag=="true")
                                        {
                                            Ext.MessageBox.alert("恭喜","添加新用户成功!");
                                            RoleInfoStore.reload();
                                            AddRoleInfoWin.hide();  
                                        }
                                    },
                                    failure:function(form,action)
                                    {
                                        Ext.MessageBox.alert("提示!","添加新用户失败!");
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
			        AddRoleInfoForm.getForm().reset();
			    }
			},{
					text:"取 消",
					minWidth:70,
					handler:function()
					{
					    AddRoleInfoWin.hide();
					}
			}]
	
	});
	AddRoleInfoWin.show();
}
