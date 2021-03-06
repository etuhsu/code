﻿// JScript 文件

EditGuestInfo=function(row)
{
    
    var EditGuestInfofp=new Ext.form.FormPanel({
			width:380,
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
			        name:"guestid",
					fieldLabel:"<font color=red>客人ID</font>",
					readOnly:true
			},{
			        name:"guestname",
					fieldLabel:"<font color=red>客人姓名</font>",
					allowBlank:false,
                    blankText:"客人姓名不允许为空",
                    regex:/^[\s\S]{1,10}$/,
                    regexText:"客人姓名请不要超过10个字符"
			},{
			        name:"guestcardid",
					fieldLabel:"身份证号",
					allowBlank:false,
                    blankText:"身份证号不允许为空",
					regex:/^[0-9.]{15,18}$/,
                    regexText:"身份证号为15-18位数字组成"
					
			},{     
			        
			        name:"guestsexs",
					xtype:"combo",
					fieldLabel:"客人性别",
					//传入后台真实值value field /value
					hiddenName:"guestsex",
					readOnly:true,
					mode:"local",
					displayField:"show",
					valueField:"value",
					triggerAction:"all",
					value:"0",
					store:new Ext.data.SimpleStore({
						fields:["show","value"],
						data:[["男","0"],["女","1"]]
					})
			},{
			       
			        name:"guestmobile",
					fieldLabel:"电话号码",
					allowBlank:false,
                    blankText:"电话号码不允许为空",
					regex:/^[0-9.]{8,13}$/,
                    regexText:"电话号码为8-13位数字组成"
					
			},{
			        name:"guestaddress",
			        xtype:"textfield",
					fieldLabel:"客人地址",
					allowBlank:false,
                    blankText:"客人地址不允许为空",
                    regex:/^[\s\S]{1,50}$/,
                    regexText:"客人地址请不要超过50个字符"
					
			}]});


        var EditGuestInfoWin=new Ext.Window({
			title:"添加客人信息",
			width:425,
			height:235,
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
			items:[EditGuestInfofp],
			listeners:{
			    "show":function()
			    {
			        //当window show事件发生时清空一下表单
			        EditGuestInfofp.getForm().loadRecord(row);
			    }
			},
			buttons:[{
					text:"保存信息",
					minWidth:70,
					handler:function()
					{
						if(EditGuestInfofp.getForm().isValid())
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
                                setTimeout(function(){Ext.MessageBox.hide();
                                }, 1000);
                                EditGuestInfofp.form.submit({
                                    url:"URL/GuestInfo/EditGuestInfo.aspx",
                                    method:"POST",
                                    success:function(form,action)
                                    {
                                        //成功后
                                        var flag=action.result.success;
                                        if(flag=="true")
                                        {
                                            EditGuestInfoWin.hide();
                                            GuestInfoStore.reload();
                                        }
                                    },
                                    failure:function(form,action)
                                    {
                                        Ext.MessageBox.alert("提示!","保存客人信息失败!");
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
			        EditGuestInfofp.getForm().loadRecord(row);
			    }
			},{
					text:"取 消",
					minWidth:70,
					handler:function()
					{
					    EditGuestInfoWin.hide();
					}
			}]
	
	});

    EditGuestInfoWin.show();
}
