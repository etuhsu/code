// JScript 文件
//定义房间类型编号

var typeids="";//获得传入ID
var rows="";//获得传入数据

var EditRoomTypeForm=new Ext.form.FormPanel({
			width:375,
			height:280,
			plain:true,
			layout:"form",
			defaultType:"textfield",
			labelWidth:100,
            plain : true, 
            baseCls:"x-plain",
			//锚点布局-
			defaults:{anchor:"95%",msgTarget:"side"},
			buttonAlign:"center",
			bodyStyle:"padding:0 0 0 0",
			items:[   
			{
			        name:"typeid",
					fieldLabel:"房间类型编号",
					readOnly:true
			},{
			        name:"typename",
					fieldLabel:"房间类型名称",
					allowBlank:false,//不允许为空 
                    blankText:"房间类型名称不允许为空"///快速提示框
			},{
			        name:"typeprice",
					fieldLabel:"房间类型价格",
					regex:/^[^.][0-9.]{1,10}$/,
                    regexText:"1到10位数字可有小数点-第一位不允许有小数点"//正则表达报错
					
			},{     
			        
			        name:"typeaddbed",
			        id:"roomtypecombo",
					xtype:"combo",
					fieldLabel:"是否可以加床",
					readOnly:true,
					mode:"local",
					displayField:"typeaddbed",
					valueField:"typeaddbed",
					triggerAction:"all",
					value:"是",
					store:new Ext.data.SimpleStore({
						fields:["typeaddbed"],
						data:[["是"],["否"]]
					}),listeners:{
					    "beforeselect":function(combo,record)
					    {
					        if(record.data.typeaddbed=="是")
					        {
					            //启用该组件
					            combo.ownerCt.findById("addbed").enable();
					        }
					        else if(record.data.typeaddbed=="否")
					        {
					            //禁用该组件
					            combo.ownerCt.findById("addbed").disable();
					            combo.ownerCt.findById("addbed").setValue("0.00");
					        }
					    }
					}
			},{
			       
			        name:"addbed",
			        id:"addbed",
					fieldLabel:"房间加床价格",
					regex:/^[1-9][0-9.]{1,10}$/,
                    regexText:"1到10位数字可有小数点-第一位不允许有小数点"//正则表达报错
					
			},{
			        name:"typedesc",
			        xtype:"textarea",
					fieldLabel:"房间类型描述",
					allowBlank:false,//不允许为空 
                    blankText:"房间类型描述不允许为空",///快速提示框
                    regex:/^[\s\S]{1,50}$/,
                    regexText:"描述请不要超过50个字符"//正则表达报错
					
			}]});


 var EditRoomTypewin=new Ext.Window({
			title:"修改房间类型信息",
			width:410,
			height:300,
			plain:true,
			//layout:"form",
			iconCls:"editicon",
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
			bodyStyle:"padding:8px 0 0 10px",
			items:[EditRoomTypeForm],
			listeners:{
				    
					"show":function()
					{
						    //_window.findById("xxx").getEl().dom.src="../images/icon.jpg";
							//加载表单数据
//							EditRoomTypeForm.form.load(
//                                {
//                                    url:"DATA/RoomType/LoadEditRoomTypeForm.aspx?typeid="+typeids,
//                                    method:"get",
//                                    success:function(form,action)
//                                    {   //加载完成如果combo选择否则不允许加床价格操作
//                                        if(EditRoomTypeForm.findByType("combo")[0].value=="否")
//                                        {
//                                            //禁用该组件
//					                        EditRoomTypeForm.findById("addbed").disable();
//					                        EditRoomTypeForm.findById("addbed").setValue("0.00");
//                                        }
//                                        else
//                                        {
//                                            //否则启动该组件
//                                            EditRoomTypeForm.findById("addbed").enable();
//                                        }
//                                    },
//                                    failure:function(form,action)
//                                    {
//                                        
//                                        Ext.Msg.alert("提示信息","对不起加载数据失败!");
//                                    }
//                                }
//                    );

                        EditRoomTypeForm.getForm().loadRecord(rows);//直接加载一行数据
                        //设置combo状态
                        if(EditRoomTypeForm.findByType("combo")[0].value=="否")
                                        {
                                            //禁用该组件
					                        EditRoomTypeForm.findById("addbed").disable();
					                        EditRoomTypeForm.findById("addbed").setValue("0.00");
                                        }
                                        else
                                        {
                                            //否则启动该组件
                                            EditRoomTypeForm.findById("addbed").enable();
                                        }
					}
			},
			buttons:[{
					text:"保存信息",
					minWidth:80,
					handler:function()
					{
						if(EditRoomTypeForm.getForm().isValid())
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
                                EditRoomTypeForm.getForm().submit({
                                    url:"URL/RoomType/SaveRoomType.aspx",
                                    method:"POST",
                                    success:function(form,action)
                                    {
                                        //成功后
                                        var flag=action.result.success;
                                        if(flag=="true")
                                        {
                                            Ext.MessageBox.alert("恭喜","添加房间类型信息成功!");
                                            //grid.store.reload();
                                            RoomTypestore.reload();
                                            EditRoomTypewin.hide();
                                            
                                        }
                                    },
                                    failure:function(form,action)
                                    {
                                        Ext.MessageBox.alert("提示!","保存房间类型信息失败!");
                                    }
                                });
                           }
					}
			},{
					text:"重置",
					minWidth:80,
					handler:function()
					{
					    EditRoomTypeForm.getForm().loadRecord(rows);//直接加载一行数据
                        //设置combo状态
                        if(EditRoomTypeForm.findByType("combo")[0].value=="否")
                         {
                                  
                            //禁用该组件
	                        EditRoomTypeForm.findById("addbed").disable();
	                        EditRoomTypeForm.findById("addbed").setValue("0.00");
                         }
                        else
                        {
                            //否则启动该组件
                            EditRoomTypeForm.findById("addbed").enable();
                        }
					    
					}
			},{
					text:"取 消",
					minWidth:80,
					handler:function()
					{
					    EditRoomTypewin.hide();
					}
			}]
	
	});
    

EditRoomTypeInfo=function(row)
{  
    //typeids=typeid;
    rows=row;
    EditRoomTypewin.show();
}
    
