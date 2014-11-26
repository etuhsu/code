/**
 * 用户信息列表
 */
Ext.namespace("EasyJF.Ext");

EasyJF.Ext.CrudPanel=Ext.extend(Ext.Panel,{
	closable: true,
  	autoScroll:true,
  	layout:"fit",
  	gridViewConfig:{},   
  	linkRenderer:function(v)
  	{
  		if(!v)return "";
  		else return String.format("<a href='{0}' target='_blank'>{0}</a>",v);
  	},
	dateRender:function(format)
    {
    	format=format||"Y-m-d h:i";
    	return Ext.util.Format.dateRenderer(format);
    },
    search:function()
    {   
    	this.refresh(); 
    },
    refresh:function()
    {
    	this.store.removeAll();
   		this.store.reload();
    },    
    initWin:function(width,height,title)
    {
    	var win=new Ext.Window({
			width:width,
			height:height,
			buttonAlign:"center",
			title:title,
			modal:true,
			shadow:true,
			closeAction:"hide",
			items:[this.fp],
			buttons:[{text:"保存",
					  handler:this.save,
					  scope:this},
					  {text:"清空",
					   handler:this.reset,
					   scope:this},
					  {text:"取消",
					   handler:this.closeWin,
					   scope:this}
					   	]					  
		});
		return win;
    },
    showWin:function()
	{	
		if(!this.win){
			if(!this.fp){
				this.fp=this.createForm();
			}
		this.win=this.createWin();
		this.win.on("close",function(){this.win=null;this.fp=null;},this);
		}
		this.win.show();
	},
	create:function()
	{
		this.showWin();
		this.reset();
	},
	save:function()
	{
		var id=this.fp.form.findField("Id").getValue();		
		this.fp.form.submit({
				waitMsg:'正在保存。。。',
	            url:this.baseUrl+"?cmd="+(id?"Update":"Save"),
	            method:'POST',
	            success:function(){
	           	this.closeWin();
	           	this.store.reload();          	
	            },
	            scope:this
		});	
	},
	reset:function()
	{
	if(this.win)this.fp.form.reset();
	},
	closeWin:function()
	{
		if(this.win)this.win.close();
		this.win=null;
		this.fp=null;
	},
	edit:function()
	{
		var record=this.grid.getSelectionModel().getSelected();
		if(!record){
			Ext.Msg.alert("提示","请先选择要编辑的行!");
			return;
		}
	    var id=record.get("id");
	    this.showWin();
	    this.fp.form.loadRecord(record); 
	},	
	removeData:function()
	{
			var record=this.grid.getSelectionModel().getSelected();
			if(!record){
				Ext.Msg.alert("提示","请先选择要编辑的行!");
				return;
			}
			var m=Ext.MessageBox.confirm("删除提示","是否真的要删除数据？",function(ret){
			if(ret=="yes"){
			  Ext.Ajax.request({
	            url:this.baseUrl+'?cmd=Remove',
	            params:{
	                'Id':record.get("Id")
	            },
	            method:'POST',
	            success:function(response){
	            var r=Ext.decode(response.responseText);
	            if(!r.success)Ext.Msg.alert("提示信息","数据删除失败，由以下原因所致：<br/>"+(r.errors.msg?r.errors.msg:"未知原因"));
	            else{
	            Ext.Msg.alert("提示信息","成功删除数据!",function(){
	            this.store.reload();	
	            },this);
	            }
	            },
	            scope:this
			  });
			}},this);
	},
    initComponent : function(){   
       this.store=new Ext.data.JsonStore({
		id:"Id",
       	url: this.baseUrl+'?cmd=List',
       	root:"Result",
  		totalProperty:"RowCount",
  		remoteSort:true,  		
  		fields:this.storeMapping});
  		
      	this.store.paramNames.sort="OrderBy";
	 	this.store.paramNames.dir="OrderType";	  
      	this.cm.defaultSortable=true;   	  	
        EasyJF.Ext.CrudPanel.superclass.initComponent.call(this);
        var viewConfig=Ext.apply({forceFit:true},this.gridViewConfig);  
        this.grid=new Ext.grid.GridPanel({
        store: this.store,
        cm: this.cm,
        trackMouseOver:false,    
        loadMask: true,
        viewConfig:viewConfig,
        tbar: ['   ',
       		 {    
                text: '添加',  
                pressed: true,           
                handler: this.create,
                scope:this
            },'   ',
            {    
                text: '修改',  
                pressed: true,            
                handler: this.edit,
                scope:this
            },'   ',
            {    
                text: '删除',  
				pressed: true,           
                handler: this.removeData,
                scope:this
            },'   ',
             {    
                text: '刷新',  
				pressed: true,           
                handler: this.refresh,
                scope:this
            }
            ,new Ext.Toolbar.Fill(),
            'Search: ',
            {    
            	xtype:"textfield",
            	width:100,
                pressed: true, 
                scope:this
            },
			{    
                text: '查询',   
                pressed: true,           
                handler: this.search,
                scope:this
            },'   '
        ],
        bbar: new Ext.PagingToolbar({
            pageSize: 10,
            store: this.store,
            displayInfo: true,
            displayMsg: 'Displaying topics {0} - {1} of {2}',
            emptyMsg: "No topics to display"
        })
   		});   		   		
   		this.grid.on("celldblclick",this.edit,this);       
   		this.add(this.grid);
   		this.store.load();
        }
});

/**
 * 	树状下拉框
 */
EasyJF.Ext.TreeComboField=Ext.extend(Ext.form.TriggerField,{
	 valueField:"Id",
	 displayField:"Name",
	 haveShow:false,
	 editable:false,
	 onTriggerClick : function(){
	 	if(!this.tree.rendered)
	 	{
	 	this.treeId = Ext.id();
        var panel = document.createElement('div');
       	panel.id = this.treeId;
       	this.getEl().dom.parentNode.appendChild(panel);
	 	this.tree.render(this.treeId);
	 	this.tree.setWidth(this.width);
	 	this.tree.getEl().alignTo(this.getEl(), "tl-bl");	
	 	}	 
	 	this.tree.show();
	 },
	 initComponent : function(){
        EasyJF.Ext.TreeComboField.superclass.initComponent.call(this);
       
	 },
	/* tree:new Ext.tree.TreePanel({
 			root:new Ext.tree.AsyncTreeNode({
 				id:"root",
   				text:"相册分类",   	
   				expanded:true,
   				loader:Global.topicCategoryLoader
   				})
 			}),*/
	 onRender : function(ct, position){
	 	EasyJF.Ext.TreeComboField.superclass.onRender.call(this, ct, position);	 	
 		this.tree.on("click",this.choice,this);
 		//this.tree.on("dblclick",function(){this.tree.hide();},this);
 		if(this.hiddenName){
            this.hiddenField = this.el.insertSibling({tag:'input', type:'hidden', name: this.hiddenName, id: (this.hiddenId||this.hiddenName)},
                    'before', true);
            this.hiddenField.value =
                this.hiddenValue !== undefined ? this.hiddenValue :this.value !== undefined ? this.value : '';
            this.el.dom.removeAttribute('name');
        }
         if(!this.editable){
            this.editable = true;
            this.setEditable(false);
        }
	 },
	 getValue : function(){       
       return typeof this.value != 'undefined' ? this.value : '';        
    },
	clearValue : function(){
        if(this.hiddenField){
            this.hiddenField.value = '';
        }
        this.setRawValue('');
        this.lastSelectionText = '';
        this.applyEmptyText();
    },
    readPropertyValue:function(obj,p)
    {
    	var v=null;
    	for(var o in obj)
    	{
    		if(o==p)v=obj[o];
    	}
    	return v;
    },
    setValue : function(obj){   
    	if(!obj){
    		this.clearValue();
    		return;
    	}
    	var v=obj;	
        var text = v;
        var value=this.valueField||this.displayField;
       if(typeof v=="object" && this.readPropertyValue(obj,value)){
        	text=obj[this.displayField||this.valueField];
        	v=obj[value];      	
        }
       	var node = this.tree.getNodeById(v);      
        if(node){
                text = node.text;
            }else if(this.valueNotFoundText !== undefined){
                text = this.valueNotFoundText;
            }
        this.lastSelectionText = text;
        if(this.hiddenField){
            this.hiddenField.value = v;
        }
       EasyJF.Ext.TreeComboField.superclass.setValue.call(this, text);
       this.value = v;
    },
     setEditable : function(value){
        if(value == this.editable){
            return;
        }
        this.editable = value;
        if(!value){
            this.el.dom.setAttribute('readOnly', true);
            this.el.on('mousedown', this.onTriggerClick,  this);
            this.el.addClass('x-combo-noedit');
        }else{
            this.el.dom.setAttribute('readOnly', false);
            this.el.un('mousedown', this.onTriggerClick,  this);
            this.el.removeClass('x-combo-noedit');
        }
    },
	choice:function(node,eventObject)
	{
	if(node.id!="root")	this.setValue(node.id);
	else this.clearValue();
	this.tree.hide();
	},		
	onDestroy : function(){
    if(this.tree.rendered){
       this.tree.getEl().remove();
      }
    EasyJF.Ext.TreeComboField.superclass.onDestroy.call(this);
    }
});
Ext.reg('treecombo', EasyJF.Ext.TreeComboField);
//友情链接管理
LinkPanel=Ext.extend(EasyJF.Ext.CrudPanel,{
	id:"linkPanel",
	title:"友情链接管理",
	baseUrl:"Link.aspx",
	createForm:function(){
	var formPanel=new Ext.form.FormPanel({
		frame:true,
		labelWidth:50,
		labelAlign:'right',
		defaults:{width:340,xtype:"textfield"},
		items:[{xtype:"hidden",name:"Id"},
			{fieldLabel:'标题',name:'Title'},
			{fieldLabel:'URL',name:'Url'},
			{fieldLabel:'RSS',name:'Rss'},
			{xtype:"textarea",fieldLabel:'简介',name:'Intro'}
            ]
	});
	return formPanel;
    },
    createWin:function()
    {
    	return this.initWin(438,220,"友情链接管理");
    },
    storeMapping:["Id","Title","Url","Rss","Intro"],   
	initComponent : function(){
		this.cm=new Ext.grid.ColumnModel([
		{header: "标题", sortable:true,width: 300, dataIndex:"Title"},
		{header: "URL", sortable:true,width: 300, dataIndex:"Url",renderer:this.linkRenderer},
		{header: "RSS", sortable:true,width: 300, dataIndex:"Rss",renderer:this.linkRenderer},
		{header: "简介", sortable:true,width: 300, dataIndex:"Intro"}
        ])
       LinkPanel.superclass.initComponent.call(this); 	
	}	
});


//评论管理
CommentPanel=Ext.extend(EasyJF.Ext.CrudPanel,{
	id:"commentPanel",
	title:"评论管理",
	baseUrl:"Comment.aspx",
	gridViewConfig:{
		enableRowBody:true,
        getRowClass : function(record, rowIndex, p, store){
                    p.body = '<p>[<b>评论内容</b>]：'+record.data.Content+'</p><br/>';
                    return 'x-grid3-row-expanded';               
       	}},
    save:function()
    {
    	Ext.Msg.alert("友情提示","不能在后台直接添加或修改评论！");
    },
    edit:function()
    {
    	CommentPanel.superclass.edit.call(this);
    	var record=this.grid.getSelectionModel().getSelected();
		if(record){
			var r=record.get("topic")?record.get("Topic"):record.get("Album");
			var target=(!r)?"[未知主题]":r.Title;
			var user=record.User?record.User.Name:"匿名用户";
			this.fp.form.setValues({commentUser:user,commentTarget:target}); 
		}
    },
	createForm:function(){
	var formPanel=new Ext.form.FormPanel({
		frame:true,
		labelWidth:60,
		labelAlign:'right',
		items:[{
			xtype:'fieldset',
			title:'基本信息',
			autoHeight:true,
			defaults:{xtype:"textfield",width:300},
			items:[
			{xtype:"hidden",name:"id"},
			{fieldLabel:'评论人',name:'commentUser'},
			{fieldLabel:'评论对象',name:'commentTarget'},
			{fieldLabel:'评论时间',name:'InputTime'},
			{fieldLabel:'ip',name:'Ip'}
			]
		},{
			xtype:'fieldset',
			title:'评论内容',
			items:{xtype:"textarea",fieldLabel:'评论内容',name:'Content',width:370,hideLabel:true,height:80}
		}]
	});

		return formPanel;
    },
    createWin:function()
    {
    	return this.initWin(438,340,"评论管理");
    },
    storeMapping:["Id","Content","InputTime","User","Topic","Album","Ip"],
	initComponent : function(){
    this.cm=new Ext.grid.ColumnModel([
    	{header: "评论人", sortable:true,width: 300, dataIndex:"User",renderer:this.showUser},
		{header: "评论时间", sortable:true,width: 300, dataIndex:"InputTime"},		
		{header: "评论对象", sortable:true,width: 300, dataIndex:"Id",renderer:this.showTarget},
		{header: "IP地址", sortable:true,width: 300, dataIndex:"Ip"}
        ]);   
	CommentPanel.superclass.initComponent.call(this);
	},
	showUser:function(value,metadata,record)
	{
		if(!value)return "匿名用户";
		else return value.Name;
	},
	showTarget:function(value,metadata,record)
	{
		var r=record.get("Topic")?record.get("Topic"):record.get("Album");
		if(!r)return "[未知主题]";
		else return r.Title;
	}  
});



//用户管理
UserPanel=Ext.extend(EasyJF.Ext.CrudPanel,{
	id:"userPanel",
	title:"用户管理",
	baseUrl:"User.aspx",
	createForm:function(){
	var formPanel=new Ext.form.FormPanel({
		frame:true,
		labelWidth:70,
		labelAlign:'right',
		items:[{
			xtype:'fieldset',
			title:'基本信息',
			autoHeight:true,
			items:[{
				layout:'column',
                border:false,
                defaults:{border:false},
                items:[{
                    	columnWidth:.5,
                        layout:'form',
                        defaultType:'textfield',
                        defaults:{width:120},
                        items:[{xtype:"hidden",name:"Id"},
						{fieldLabel:'用户名',name:'Name',width:120}
						]},{
                    	columnWidth:.5,
                        layout:'form',
                        defaultType:'textfield',
                        defaults:{width:104},
                        items:[{
                        	inputType:'password',
                        	fieldLabel:'密&nbsp;&nbsp;码',
                        	name:'Password'
                        }]
                    }]
			},{
				layout:'form',
	            defaultType:'textfield',
				items:[{
	                	width:300,
	                 	name:"Email",
	                 	fieldLabel:'电子邮箱'
	      	  	}]
		}]
		},{
			xtype:'fieldset',
			title:'备注信息',
			autoHeight:true,
			items:[{
                	xtype:"textarea",
                	width:380,
                	height:80,
                 	name:"Remark",
                 	hideLabel:true
      	  	}]
		}]
	});	
	return formPanel;
    },
    createWin:function()
    {
    	return this.initWin(438,300,"用户管理");
    },
    storeMapping:["Id","Name","Password","LastLoginTime","LoginTimes","Email","Remark"],
    initComponent : function(){    	
    this.cm=new Ext.grid.ColumnModel([
	{header: "用户名", sortable:true,width: 300, dataIndex:"Name"},
	{header: "密码", sortable:true,width: 300, dataIndex:"Password",renderer:function(){return "******";}},
	{header: "电子邮箱", sortable:true,width: 300, dataIndex:"Email"},
	{header: "上次登录时间", sortable:true,width: 300, dataIndex:"LastLoginTime"},
	{header: "登录次数", sortable:true,width: 300, dataIndex:"LoginTimes"},
	{header: "备注", sortable:true,width: 300, dataIndex:"Remark"}
        ]);
    UserPanel.superclass.initComponent.call(this);   
    }
	});


BlogProperties=Ext.extend(Ext.Panel,{
	id:"blogPropertiesPanel",
	title:"Blog属性设置",
	closable: true,
  	autoScroll:true,
  	layout:"fit", 
  	fp:null,
	saveProperty:function()
	{
		this.fp.form.submit({
				waitTitle:"请稍候",
				waitMsg:'正在保存。。。',
	            url:"Blog.aspx?cmd=Update",
	            method:'POST',
	            success:function(){
	           		Ext.Msg.alert("保存成功！","已经成功保存！");
	            }
		});
	},	
	initComponent : function(){
	BlogProperties.superclass.initComponent.call(this);
	this.fp=new Ext.form.FormPanel({
		labelWidth:100,		
        labelAlign:'right',
		defaultType:"textarea",	
		bodyStyle:'padding:25px',
		defaults:{width:600},
		trackResetOnLoad:true,
		items:[		
		{xtype:"textfield",fieldLabel:'标题',name:'Title'},
		{xtype:"textfield",fieldLabel:'联系邮箱',name:'Email'},		
		{xtype:"textfield",fieldLabel:'域名',name:'Domain'},
		{fieldLabel:'简介',name:'Intro'},	
		{fieldLabel:'公告',name:'Announce'},
		{fieldLabel:'页首自定义',name:'Header'},
		{fieldLabel:'页脚自定义',name:'Footer'},
		{fieldLabel:'关键字',name:'Keywords'},
		{xtype:"combo",fieldLabel:'使用皮肤',name:'Skin'}],          
  		buttons:[
  				  {text:"保存",
  				  handler:this.saveProperty,
  				  scope:this},
  				  {text:"重置",
  				   handler:function(){this.fp.form.reset();},
  				   scope:this  				   
  				  }]
   	 });	
	this.add(this.fp);
	this.fp.load({
		url:"Blog.aspx?cmd=Read"
	});
	}
});
