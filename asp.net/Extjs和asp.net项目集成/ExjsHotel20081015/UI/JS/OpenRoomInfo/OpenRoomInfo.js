// JScript 文件

   
   var fileds = Ext.data.Record.create([      
        {name: 'typeid',mapping:'typeid'},{name: 'typename',mapping:'typename'},{name:'typedesc',mapping:'typedesc'}                     
    ]);    
   var store = new Ext.data.Store({      
        proxy: new Ext.data.HttpProxy({      
            url:'DATA/RoomType/OpenRoomGetAllRoomType.aspx'  
        }),      
        reader: new Ext.data.JsonReader({      
            root: 'data',      
            id: 'typeid'     
        },
        fileds 
        )      
    });   
    store.load();
    ///-----------------------------------------------------------------------
    var filedsRoomid=Ext.data.Record.create([
        {name:'roomid',mapping:'roomid'},
        {name:'number',mapping:'number'},
        {name:'roomdesc',mappding:'roomdesc'}
    ]);
    
    var storeroom=new Ext.data.Store({
        proxy:new Ext.data.HttpProxy({
            url:'DATA/Room/OpenRoomGetRoomInfoByTypeID.aspx?typeid=0',
            method:'GET'
        }),
        reader:new Ext.data.JsonReader({
            root:'data',
            id:'roomid'
        },filedsRoomid)
    });
    storeroom.load();
    
    
    
    ///房间信息
    var RoomCombox=new Ext.form.ComboBox({ 
            tpl: '<tpl for="."><div ext:qtip="{number}. {roomdesc}" class="x-combo-list-item">{number}</div></tpl>',
            store:storeroom, 
            typeAhead: true,
            name:'roomid',
            fieldLabel:'房间编号',
            forceSelection: true,
            triggerAction: 'all',
            emptyText:'请选择房间编号',
            selectOnFocus:true,
            width:130,
            editable: false, //不允许输入
            allowBlank:false, //不允许为空
            blankText:'请您选择房间编号', //错误提示信息
            displayField:'number',
            valueField: 'roomid',
            mode: 'local', //数据源在本地
            listeners:{
                "select":function(combo)
                {
                    if(combo.getValue()=="" || combo.getValue() ==null)
                    {
                        Ext.Msg.alert("警告","请您先正确选择房间类型");
                    }
                }
            }
    }); 
    
    //房间类型信息
    var RoomTypeCombox=new Ext.form.ComboBox({
            tpl: '<tpl for="."><div ext:qtip="{typename}. {typedesc}" class="x-combo-list-item">{typename}</div></tpl>',
            store: store,
            typeAhead: true,
            fieldLabel:'房间类型',
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
            mode: 'remote',
            listeners:{
                'select':function(combo, record, index) { 
                    RoomCombox.reset(); 
                    storeroom.proxy= new Ext.data.HttpProxy({url: 'DATA/Room/OpenRoomGetRoomInfoByTypeID.aspx?typeid=' + combo.getValue()}); 
                    storeroom.load(); 
                }
            }
    });

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
			RoomTypeCombox,
			RoomCombox,
			{  
			        name:"guestmoney",
			        xtype:'numberfield',
					fieldLabel:"预付定金",
					allowBlank:false,
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
			title:"填写开房信息",
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
			        OpenRoomInfofp.getForm().reset();
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
                                    url:"URL/OpenRoomInfo/SaveOpenRoomInfo.aspx",
                                    method:"POST",
                                    success:function(form,action)
                                    {
                                        //成功后
                                        var flag=action.result.success;
                                        if(flag=="true")
                                        {
                                            Ext.MessageBox.alert("恭喜","开房信息保存成功!");
                                            OpenRoomInfoWin.hide();
                                            RoomOpenInfostore.reload();
                                        }
                                    },
                                    failure:function(form,action)
                                    {
                                        Ext.MessageBox.alert("提示!","开房信息保存失败!");
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
			        OpenRoomInfofp.getForm().reset();
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
