// JScript 文件
//定义房间类型编号
    //添加房间类型时判断该类型名称是否存在
    var RoomTypeisOK=false;
    
    CheckRoomTypeIsOk=function()
    {
           
            var roomtypename=Ext.get('typename').dom.value;
            Ext.Ajax.request({
                    url:'URL/RoomType/RoomTypeNameIsOk.aspx',
                    method:"POST",
                    params:{typename:roomtypename},
                    success: function(response, options) {  
                       var responseArray = Ext.util.JSON.decode(response.responseText); 
                                                         
                       if(responseArray.success == true){ //房间号已经存在       
                           SetValue(false);
                       }else{//房间号可以使用               
                           SetValue(true);
                       }  
                    }  
                });
            function SetValue(b){
                  RoomTypeisOK = b;//给变量赋值
            }
           return RoomTypeisOK;
     }

var AddRoomTypeForm=new Ext.form.FormPanel({
			width:375,
			height:270,
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
			        name:"typename",
			        id:'typename',
					fieldLabel:"<font color=red>类型名称</font>",
					allowBlank:false,
                    blankText:"房间类型名称不允许为空",
                    validator:CheckRoomTypeIsOk,//指定验证器
                    invalidText:'该房间类型己在存在'
			},{
			        name:"typeprice",
					fieldLabel:"类型价格",
					allowBlank:false,
                    blankText:"类型价格不允许为空",
					regex:/^[1-9][0-9.]{1,10}$/,
                    regexText:"2到10位数字可有小数点-第一位不允许有小数点"
					
			},{     
			        
			        name:"typeaddbed",
					xtype:"combo",
					fieldLabel:"是否加床",
					//传入后台真实值value field /value
					//hiddenName:"abcd",
					readOnly:true,
					mode:"local",
					displayField:"addroomtypeSimpleStore",
					valueField:"addroomtypeSimpleStore",
					triggerAction:"all",
					value:"是",
					store:new Ext.data.SimpleStore({
						fields:["addroomtypeSimpleStore"],
						data:[["是"],["否"]]
					}),listeners:{
					    "beforeselect":function(combo,record)
					    {
					        
					        if(record.data.addroomtypeSimpleStore=="是")
					        {
					            //启用该组件
					            combo.ownerCt.findById("addRoomTypeaddbed").enable();
					        }
					        else if(record.data.addroomtypeSimpleStore=="否")
					        {
					            //禁用该组件
					            combo.ownerCt.findById("addRoomTypeaddbed").disable();
					            combo.ownerCt.findById("addRoomTypeaddbed").setValue("0.00");
					        }
					    }
					}
			},{
			       
			        name:"addbed",
			        id:"addRoomTypeaddbed",
					fieldLabel:"加床价格",
					allowBlank:false,
                    blankText:"加床价格不允许为空",
					regex:/^[1-9][0-9.]{1,10}$/,
                    regexText:"2到10位数字可有小数点-第一位不允许有小数点"
					
			},{
			        name:"typedesc",
			        xtype:"textarea",
					fieldLabel:"类型描述",
					allowBlank:false,
                    blankText:"房间类型描述不允许为空",
                    regex:/^[\s\S]{1,50}$/,
                    regexText:"描述请不要超过50个字符"
					
			}]});


 var AddRoomTypewin=new Ext.Window({
			title:"添加房间类型信息",
			width:410,
			height:285,
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
			items:[AddRoomTypeForm],
			listeners:{
			    "show":function()
			    {
			        //当window show事件发生时清空一下表单
			        AddRoomTypeForm.getForm().reset();
			    }
			},
			buttons:[{
					text:"保存信息",
					minWidth:70,
					handler:function()
					{
						if(AddRoomTypeForm.getForm().isValid())
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
                                AddRoomTypeForm.form.submit({
                                    url:"URL/RoomType/AddRoomType.aspx",
                                    method:"POST",
                                    success:function(form,action)
                                    {
                                        //成功后
                                        var flag=action.result.success;
                                        if(flag=="true")
                                        {
                                            Ext.MessageBox.alert("恭喜","添加房间类型信息成功!");
                                          
                                            RoomTypestore.reload();
                                            AddRoomTypewin.hide();
                                            
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
			    minWidth:70,
			    qtip:"重置数据",
			    handler:function()
			    {
			        AddRoomTypeForm.getForm().reset();
			    }
			},{
					text:"取 消",
					minWidth:70,
					handler:function()
					{
					    AddRoomTypewin.hide();
					}
			}]
	
	});
    

AddRoomTypeInfo=function()
{  
    AddRoomTypewin.show();
}
    
