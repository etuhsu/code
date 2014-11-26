// JScript 文件

EditUserPwdInfo=function(loginid)
{
    var EditUserInfoPwdForm=new Ext.form.FormPanel({
			width:260,
			height:150,
			plain:true,
			layout:"form",
			defaultType:"textfield",
			labelWidth:55,
            baseCls:"x-plain",
			defaults:{anchor:"95%",msgTarget:"side"},
			buttonAlign:"center",
			bodyStyle:"padding:0 0 0 0",
			items:[{
			        name:"userid",
					fieldLabel:"<font color=red>用户名</font>",
                    readOnly:true
			},{
			        name:"userpwd2",
					fieldLabel:"新密码",
					allowBlank:false,
                    blankText:"新密码不能为空",
                    inputType:'password'
			},{
			        name:"userpwd3",
					fieldLabel:"确认",
					allowBlank:false,
                    blankText:"新密码不能为空",
                    invalidText:'两次密码不一致！',
                    inputType:'password',
                    validator:function(){
                        if(Ext.get('userpwd2').dom.value == Ext.get('userpwd3').dom.value)
                        {
                            return true;
                        }else{
                            return false;
                        }
                  }
			}
			]});


 var EditUserInfoPwdWin=new Ext.Window({
			title:"修改密码",
			width:295,
			height:180,
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
			items:[EditUserInfoPwdForm],
			listeners:{
			    "show":function()
			    {
			        //加载表单数据
					EditUserInfoPwdForm.form.load(
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
						if(EditUserInfoPwdForm.getForm().isValid())
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
                                EditUserInfoPwdForm.form.submit({
                                    url:"URL/UserInfo/SavePwdUserInfo.aspx",
                                    method:"POST",
                                    success:function(form,action)
                                    {
                                        //成功后
                                        var flag=action.result.success;
                                        if(flag=="true")
                                        {
                                            Ext.MessageBox.alert("恭喜","修改密码成功!");
                                            EditUserInfoPwdWin.hide();  
                                        }
                                    },
                                    failure:function(form,action)
                                    {
                                        Ext.MessageBox.alert("提示!","修改密码失败!");
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
			         //加载表单数据
			        EditUserInfoPwdForm.getForm().reset();
					EditUserInfoPwdForm.form.load(
                                {
                                    url:"DATA/UserInfo/LoadUserInfo.aspx?loginid="+loginid,
                                    method:"get",
                                    success:function(form,action)
                                    {   
                                    },
                                    failure:function(form,action)
                                    {
                                        //Ext.Msg.alert("提示信息","对不起加载数据失败!请联系管理员");
                                    }
                                }
                    );
			    }
			},{
					text:"取 消",
					minWidth:70,
					handler:function()
					{
					    EditUserInfoPwdWin.hide();
					}
			}]
	
	});
	EditUserInfoPwdWin.show();
}
