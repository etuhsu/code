// JScript 文件
EditUserInfos=function(row)
{
    //------用户类型
     
   var EditUserRoleFields = Ext.data.Record.create([      
        {name: 'roleid',mapping:'roleid'},{name: 'rolename',mapping:'rolename'},{name:'roledesc',mapping:'roledesc'}                     
    ]);    
    
   var  EditUserRoleStore = new Ext.data.Store({      
        proxy: new Ext.data.HttpProxy({      
            url:'DATA/RoleInfo/GetRoleInfo.aspx'  
        }),      
        reader: new Ext.data.JsonReader({      
            root: 'data',      
            id: 'roleid'     
        },
        EditUserRoleFields 
        )      
    });   
    EditUserRoleStore.load();

    var EditUserInfoForm=new Ext.form.FormPanel({
			width:315,
			height:270,
			plain:true,
			layout:"form",
			defaultType:"textfield",
			labelWidth:45,
            baseCls:"x-plain",
			defaults:{anchor:"95%",msgTarget:"side"},
			buttonAlign:"center",
			bodyStyle:"padding:0 0 0 0",
			items:[   
			{
			        name:"userid",
					fieldLabel:"帐号",
					allowBlank:false,
                    blankText:"帐号不允许为空"
			},{
			        name:"userpwd",
					fieldLabel:"密码",
					allowBlank:false,
                    blankText:"密码不能为空",
                    inputType:"password"
			},{
			        name:"username",
					fieldLabel:"称谓",
					allowBlank:false,
                    blankText:"称呼不能为空",
					regex:/^[\s\S]{1,10}$/,
                    regexText:"昵称请不要超过10个字符"
			},{     
			        
			        name:"userstate",
					xtype:"combo",
					fieldLabel:"状态",
				    editable: false,
				    typeAhead: true,
					//传入后台真实值value field /value
					hiddenName:"userstate",
					mode:"local",
					displayField:"show",
					valueField:"value",
					triggerAction:"all",
					value:"0",
					store:new Ext.data.SimpleStore({
						fields:["show","value"],
						data:[["正常","0"],["禁用","1"]]
					})
			},{
			       
			        xtype:"combo",
			        tpl: '<tpl for="."><div ext:qtip="{rolename}. {roledesc}" class="x-combo-list-item">{rolename}</div></tpl>',
                    store: EditUserRoleStore,
                    typeAhead: true,
                    fieldLabel:'角色',
                    hiddenName:'roleids',
                    name:'roleids',
                    forceSelection: true,
                    triggerAction: 'all',
                    emptyText:'选择角色类型',
                    selectOnFocus:true,
                    width:130,
                    editable: false, 
                    allowBlank:false, 
                    blankText:'请选择角色类型', 
                    displayField:'rolename',
                    valueField: 'roleid',
                    mode: 'remote'
			}
			]});


 var EditUserInfoWin=new Ext.Window({
			title:"编辑用户信息",
			width:350,
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
			items:[EditUserInfoForm],
			listeners:{
			    "show":function()
			    {
			        EditUserInfoForm.getForm().loadRecord(row);
			    }
			},
			buttons:[{
					text:"保存信息",
					minWidth:70,
					handler:function()
					{
						if(EditUserInfoForm.getForm().isValid())
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
                                EditUserInfoForm.form.submit({
                                    url:"URL/UserInfo/EditUserInfo.aspx",
                                    method:"POST",
                                    success:function(form,action)
                                    {
                                        //成功后
                                        var flag=action.result.success;
                                        if(flag=="true")
                                        {
                                            Ext.MessageBox.alert("恭喜","保存用户信息成功!");
                                            UserInfoStore.reload();
                                            EditUserInfoWin.hide();  
                                        }
                                    },
                                    failure:function(form,action)
                                    {
                                        Ext.MessageBox.alert("提示!","保存用户信息失败!");
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
			        EditUserInfoForm.getForm().loadRecord(row);
			    }
			},{
					text:"取 消",
					minWidth:70,
					handler:function()
					{
					    EditUserInfoWin.hide();
					}
			}]
	
	});
	EditUserInfoWin.show();
}
