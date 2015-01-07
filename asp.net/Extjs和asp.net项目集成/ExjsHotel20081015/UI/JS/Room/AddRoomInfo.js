// JScript 文件
AddRoonInfos=function()
{
    //验证房间号是否存在
   var isok=false;
   CheckRoomID=function()
   {
        var number=Ext.get('number').dom.value;
        Ext.Ajax.request({
                url:'URL/Room/RoomIDIsOK.aspx',
                method:"POST",
                params:{roomid:number},
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
              isok = b;//给变量赋值
            }
            return isok;
   }
    
   var roomtypefileds = Ext.data.Record.create([      
        {name: 'typeid',mapping:'typeid'},{name: 'typename',mapping:'typename'},{name:'typedesc',mapping:'typedesc'}                     
    ]);    
   var  roomtypestore = new Ext.data.Store({      
        proxy: new Ext.data.HttpProxy({      
            url:'DATA/RoomType/OpenRoomGetAllRoomType.aspx'  
        }),      
        reader: new Ext.data.JsonReader({      
            root: 'data',      
            id: 'typeid'     
        },
        roomtypefileds 
        )      
    });   
    roomtypestore.load();
    var AddRoomForm=new Ext.form.FormPanel({
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
			        name:"number",
					fieldLabel:"<font color=red>房间号码</font>",
					allowBlank:false,
                    blankText:"房间号码不允许为空",
                    validator:CheckRoomID,//指定验证器
                    invalidText:'该房间号己在存在'
			},{
			        name:"bednumber",
					fieldLabel:"床位数量",
					allowBlank:false,
                    blankText:"床位数量不允许为空",
					regex:/^[0-9]{1,2}$/,
                    regexText:"1-2位数"
					
			},{
			       
			        name:"guestnumber",
					fieldLabel:"容纳人数",
					allowBlank:false,
                    blankText:"容纳人数不允许为空",
					regex:/^[0-9]{1,2}$/,
                    regexText:"1-2位数"
					
			},{
			    xtype:"combo",
			    tpl: '<tpl for="."><div ext:qtip="{typename}. {typedesc}" class="x-combo-list-item">{typename}</div></tpl>',
                store: roomtypestore,
                typeAhead: true,
                fieldLabel:'房间类型',
                hiddenName:'typeid',
                name:'typeids',
                forceSelection: true,
                triggerAction: 'all',
                emptyText:'请选择房间类型',
                selectOnFocus:true,
                width:130,
                editable: false, 
                allowBlank:false, 
                blankText:'请选择类型', 
                displayField:'typename',
                valueField: 'typeid',
                mode: 'remote'
            },{
                xtype:"combo",
                name:'roomstates',
                fieldLabel:'初始状态',
                emptyText:'请设定房间初始状态',
                allowBlank:false, 
                blankText:'请选择房间初始状态',
                editable: false, 
                hiddenName:'roomstate',
                store:new Ext.data.SimpleStore({
	            data:[["空闲","0"],["入住","1"],["维修","2"],["自用","3"],["其它","4"]],
	            fields:["state","value"]
	            }),
	            tpl: '<tpl for="."><div ext:qtip="设置房间状态为--{state}" class="x-combo-list-item">{state}</div></tpl>',
	            displayField:"state",
	            mode:"local",
	            valueField:"value",
	            triggerAction:"all"
            },{
			        name:"roomdesc",
			        xtype:"textarea",
					fieldLabel:"房间描述",
					allowBlank:false,
                    blankText:"房间描述不允许为空",
                    regex:/^[\s\S]{1,25}$/,
                    regexText:"房间描述请不要超过25个字符"
					
			}]});


 var AddRoomwin=new Ext.Window({
			title:"增加房间信息",
			width:410,
			height:285,
			plain:true,
			//layout:"form",
			iconCls:"openroomicon",
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
			items:[AddRoomForm],
			listeners:{
			    "show":function()
			    {
			        //当window show事件发生时清空一下表单
			        AddRoomForm.getForm().reset();
			    }
			},
			buttons:[{
					text:"保存信息",
					minWidth:70,
					handler:function()
					{
						if(AddRoomForm.getForm().isValid())
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
                                AddRoomForm.form.submit({
                                    url:"URL/Room/AddRoomInfo.aspx",
                                    method:"POST",
                                    success:function(form,action)
                                    {
                                        //成功后
                                        var flag=action.result.success;
                                        if(flag=="true")
                                        {
                                            Ext.MessageBox.alert("恭喜","添加房间信息成功!");
                                          
                                            Roomstore.reload();
                                            AddRoomwin.hide();
                                            
                                        }
                                    },
                                    failure:function(form,action)
                                    {
                                        Roomstore.reload();
                                        Ext.MessageBox.alert("提示!","保存房间信息失败!");
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
			        AddRoomForm.getForm().reset();
			    }
			},{
					text:"取 消",
					minWidth:70,
					handler:function()
					{
					    AddRoomwin.hide();
					}
			}]
	
	});
    
    AddRoomwin.show();
}
