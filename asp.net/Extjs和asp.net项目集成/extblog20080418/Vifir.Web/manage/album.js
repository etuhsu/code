var removeAlbumCategory;
var albumCategoryLoader=Global.albumCategoryLoader;
/**
 * 相册目录
 */
AlbumCategoryManage=function()
{
this.storeMapping=["Id","Name","Intro",{name:"op",mapping:"Id"}	];
this.operationRender=function(obj){
	return !obj||obj=="-1"?"":"<a href='javascript:removeAlbumCategory("+obj+")'>删除</a>";
	};
this.store=new Ext.data.JsonStore({		
  		id:"Id",
  		url:"AlbumCategory.aspx?cmd=GetCategory&pageSize=-1",  		
  		root:"Result",
  		totalProperty:"RowCount",
  		remoteSort:true,  		
    	fields:this.storeMapping
  		});
this.cm=new Ext.grid.ColumnModel([
		new Ext.grid.RowNumberer({header:"序号",width:40,sortable:true}),
		{header: "分类名称",width:120,dataIndex:"Name",editor: new Ext.form.TextField({
	               allowBlank: false
	           })},
		{header: "简介",dataIndex:"Intro",editor:new Ext.form.TextField()},	
		{header: "操作", width: 80, dataIndex:"op",renderer:this.operationRender}
		]);	
this.store.paramNames.sort="OrderBy";//改变排序参数名称
this.store.paramNames.dir="OrderType";//改变排序类型参数名称
this.cm.defaultSortable=true;
this.grid=new Ext.grid.EditorGridPanel({		
 			store:this.store,
  			cm:this.cm,
        	loadMask: true,
        	clicksToEdit:1,
        	autoExpandColumn:2,
        	frame:true,
 			region:"center"
		});
this.grid.on("afteredit",this.afterEdit,this);
this.tree=new Ext.tree.TreePanel({title:"相册分类",
 			region:"west",
 			width:150, 			
 			root:new Ext.tree.AsyncTreeNode({
 				id:"root",
   				text:"相册分类",   	
   				expanded:true,
   				loader:albumCategoryLoader	
   				})
 			});
this.tree.on("click",function(node,eventObject){
	var id=(node.id!='root'?node.id:"");
	this.store.baseParams.id=id;
	this.store.removeAll();
	this.store.load();
},this);			
AlbumCategoryManage.superclass.constructor.call(this, {
		id:"albumCategoryManager",
		title:"相册分类管理",
		closable: true,
  		autoScroll:true,
  		layout:"border",
  		tbar: [
				'操作: ',' ',{                 
                   text:"新增分类",
                   handler:this.addCategory,
                   scope:this                 
				}, {                 
                   text:"删除分类",
                   handler:this.removeCategory,
                   scope:this      
				},' ',new Ext.Toolbar.Fill(),"查询"
            ],
 		items:[
 			this.tree,
 			this.grid
 		]           
   	 });
this.store.load();
} 
Ext.extend(AlbumCategoryManage, Ext.Panel,{
	addCategory:function(){
	    var create=Ext.data.Record.create(this.storeMapping);
	  	var obj=new create({Id:'-1',Name:'',Intro:''});
		this.grid.stopEditing();
		this.store.insert(this.store.getCount(),obj);	
		this.grid.startEditing(this.store.getCount()-1, 0);
   	},
    removeCategory:function(id){
    	var tree=this.tree;
    	var store=this.store;
	   	var m=Ext.MessageBox.confirm("删除提示","是否真的要删除数据？",function(ret){
			if(ret=="yes"){
			    Ext.Ajax.request({
	            url:"AlbumCategory.aspx?cmd=Remove",
	            params:{id:id},	           
	            success:function(response){
	                var theId=Ext.decode(response.responseText);
	                store.remove(store.getById(id));	
				    var node=tree.getNodeById(id);
				    var parent=node.parentNode;				
				    parent.removeChild(node);				
				    if(!parent.childNodes){
				    node.parentNode.getUI().removeClass('x-tree-node-expanded');
	                node.parentNode.getUI().addClass('x-tree-node-leaf');
	                }
	            },
	            scope:this
	            });	
			}
		}
		);
   	},
   	afterEdit:function(obj){
	   	var r=obj.record;
		var id=r.get("Id");
		var name=r.get("Name");
		var c=this.record2obj(r);
		var tree=this.tree;
		var node=tree.getSelectionModel().getSelectedNode();	
		if(node && node.id!="root")c.parentId=node.id;
		if(id=="-1" && name!=""){
		     Ext.Ajax.request({
	            url:"AlbumCategory.aspx?cmd=Save",
	            params:c,	           
	            success:function(response){
	            var theId=Ext.decode(response.responseText);
	            if(id)r.set("Id",theId);
				if(!node)node=tree.root;
				node.appendChild(new Ext.tree.TreeNode({
                    id:theId,
                    text:c.Name,
                    leaf:true
                }));
                node.getUI().removeClass('x-tree-node-leaf');
                node.getUI().addClass('x-tree-node-expanded');
                node.expand();
	            },
	            scope:this
	            });				
		}
		else if(name!="")
		{	
		     c.Id=id;
		     Ext.Ajax.request({
	            url:"AlbumCategory.aspx?cmd=Update",
	            params:c,	           
	            success:function(response){
	            var ret=Ext.decode(response.responseText);
	            if(ret)tree.getNodeById(r.get("Id")).setText(c.Name);
	            },
	            scope:this
	            });					
		}
   	},
   	record2obj:function(r)
	{
		return {Name:r.get("Name"),
		Intro:r.get("Intro")		
		};
	}
});

/**
 * 相册菜单
 */
AlbumMenuPanel=function()
{	
	AlbumMenuPanel.superclass.constructor.call(this, {
        autoScroll:true,
        animate:true,
        border:false,
        rootVisible:false,
        root:new Ext.tree.TreeNode({
        text: '相册管理菜单',
        draggable:false,
       	expanded:true
   	 })        
    });   
   this.root.appendChild(new Ext.tree.TreeNode({
   		text:"上传照片",
   		listeners:{'click':function(){
   			var panel=Ext.getCmp("writeAlbumPanel");
   			if(!panel){
   				panel=new WriteAlbumPanel();
   			}
   			main.openTab(panel);
   			}}	
   		}));  
   this.root.appendChild(new Ext.tree.TreeNode({
   		text:"分类管理",
   		listeners:{'click':function(){
   			var panel=Ext.getCmp("albumCategoryManager");
   			if(!panel){
   				panel=new AlbumCategoryManage();
   				removeAlbumCategory=function(id){panel.removeCategory(id);};
   			}
   			main.openTab(panel);
   			}
   		}	
   		}));
    var categoryNode=new Ext.tree.AsyncTreeNode({
   		id:"root",
   		text:"照片管理",   	
   		loader:albumCategoryLoader  		
   		});
   this.root.appendChild(categoryNode);
   this.on("click",function(node,eventObject)
   {
   	if(node==categoryNode||categoryNode.contains(node)){
   		var panel=Ext.getCmp("albumListPanel");
   		if(!panel){
   				panel=new AlbumListManage();
   				removeAlbum=function(id){
   					panel.grid.getSelectionModel().selectRecords([panel.store.getById(id)]);
   					panel.removeData();};
   				editAlbum=function(id){
   					panel.grid.getSelectionModel().selectRecords([panel.store.getById(id)]);
   					panel.edit();
   					};
   			}
   		main.openTab(panel);
   		panel.store.baseParams.categoryId=(node.id!='root'?node.id:"");
   		panel.store.removeAll();
   		panel.store.reload();
   	}
   });
}
Ext.extend(AlbumMenuPanel, Ext.tree.TreePanel);


/**
 * 书写新日志或添加日志
 */
WriteAlbumPanel=Ext.extend(Ext.Panel,{
	id:"writeAlbumPanel",
	title:"上传照片",
	closable: true,
  	autoScroll:true,
  	layout:"fit",  			
	saveAlbum:function()
	{	
		this.fp.form.submit({
				waitMsg:'正在保存。。。',
	            url:"Album.aspx",
	            method:'POST',
	            success:function(){
	            var main=Ext.getCmp("main");
	            Ext.Msg.alert("提示信息","数据保存成功!",function(){
	           	main.closeTab(this);
	           	var panel=Ext.getCmp("albumListPanel");
	           	if(!panel)panel=new AlbumListManage();
	           	main.openTab(panel);
	           	panel.refresh();},this);
	            },
	            scope:this
		});
	},
	createFormPanel:function(){
		return  new Ext.form.FormPanel({		
		buttonAlign:"center",
		labelAlign:"right",
		bodyStyle:'padding:25px',
		defaults:{width:650},
		frame:false,
		fileUpload:true,
		bodyBorder:false,
		border:true,
		labelWidth:60,
		items:[	
			{xtype:"hidden",name:"cmd",value:"Save"},	   
			{xtype:"hidden",name:"Id"},	   
		    {xtype:"textfield",
			 name:"Title",			
			 fieldLabel:"主题"},
			{xtype:"treecombo",
			 fieldLabel:"所属栏目",
			 name:"CategoryId",
			 hiddenName:"CategoryId",
			 tree:new Ext.tree.TreePanel({
 				root:new Ext.tree.AsyncTreeNode({
 				id:"root",
   				text:"相册分类",   	
   				expanded:true,
   				loader:Global.albumCategoryLoader
   				})
 			})},
		  	{
		  	xtype:"textarea",
		  	name:"Intro",
		  	fieldLabel:"摘要"},		  	
  			{
  			xtype:"textfield",	  			
	  		name:"Path",
	  		fieldLabel:"图片",	
	  		readOnly:true
	  		},
  			{
  			xtype:"field",	  			
	  		name:"PathFile",
	  		height:25,
	  		fieldLabel:"选择图片",
	  		inputType:"file"
	  		},
			{		
	  			title:"照片预览",
	  			id:'albumPreview',
	  			autoScroll:true,
	  			width:720,
	  			height:250			
	  		}
	  		],
  		buttons:[{text:"提交",
  				  handler:this.saveAlbum,
  				  scope:this},
  				  {text:"清空",
  				   handler:function(){this.fp.form.reset();},
  				   scope:this  				   
  				  },
  				  {text:"取消",
  				   handler:function(){Ext.getCmp("main").closeTab(this);},
  				   scope:this  				   
  				  }]
   	 });
   	 },
	initComponent : function(){
	WriteAlbumPanel.superclass.initComponent.call(this);
	this.fp=this.createFormPanel();
	this.add(this.fp);
	}
});

/**
 * 相册列表
 */
AlbumListManage=Ext.extend(EasyJF.Ext.CrudPanel,{
	id:"albumListPanel",
	title:"相册内容管理",
	baseUrl:"Album.aspx",
	gridViewConfig: {
            forceFit:true,
            enableRowBody:true,
            showPreview:true,
            getRowClass : function(record, rowIndex, p, store){
                if(this.showPreview){
                    p.body = "<p>摘要："+record.data.Intro+"</p><br/><div align=center><img src='../upload/"+record.data.Path+"'/></div>";
                    return 'x-grid3-row-expanded';
                }
                return 'x-grid3-row-collapsed';
            }
        },
    create:function()
	{
		var main=Ext.getCmp("main");
		var panel=Ext.getCmp("writeAlbumPanel");
   			if(!panel){
   				panel=new WriteAlbumPanel();
   			}
   		main.openTab(panel);
	},
	edit:function()
	{
		var record=this.grid.getSelectionModel().getSelected();
		if(!record){
			Ext.Msg.alert("提示","请先选择要编辑的行!");
			return;
		}
	    var id=record.get("Id");
	   	var main=Ext.getCmp("main");
	   	var panelId="writeAlbumPanel"+id;
	  	var writePanel=Ext.getCmp(panelId);
	   	if(!writePanel)writePanel=new WriteAlbumPanel({id:panelId,title:"编辑相册:"+record.data.Title});
	   	main.openTab(writePanel);
		record.data.CategoryId=record.data.Category;
	   	writePanel.fp.form.loadRecord(record);
	   	writePanel.fp.form.setValues({cmd:"Update"});	
		var preview=writePanel.fp.getComponent("albumPreview");
	   	preview.body.update("<img src='../upload/"+(record.data.Path?record.data.Path:"")+"'/>");
	   	//var preview=Ext.get("albumPreview");	   	
	   	//preview.dom.src=record.data.path?record.data.Path:"";
	},
	titleRender:function(value, p, record){    
    	return String.format('<b><a href="portal.ejf?cmd=albumShow&id={0}" target="_blank">{1}</a></b><br/>',record.data.Id,value)
    },    
    operationRender:function(obj){
	return !obj||obj=="-1"?"":"<a href='javascript:editAlbum("+obj+")'>编辑</a>　<a href='javascript:removeAlbum("+obj+")'>删除</a>";
	}, 
	categoryRender:function(value,p,record)
	{
		if(!value)return "";
		else return value.Name;
	},
	commentsRender:function(value, p, record){    
    	return value?value.length:0;
    },   
	storeMapping:["Id","Title","Intro","Path","Category","ReadTimes","InputTime","Comments","Content",{name:"op",mapping:"Id"}
	],	
    toggleDetails:function(btn, pressed){
        var view = this.grid.getView();
        view.showPreview = pressed;
        view.refresh();
    },
    initComponent : function(){
  	this.cm=new Ext.grid.ColumnModel([{        
           header: "主题",
           dataIndex: 'Title',
           width: 200,
           renderer:this.titleRender
        },
        {        
           header: "分类",
           dataIndex: 'Category',
           width: 200,
           renderer:this.categoryRender
        },
		{
           header: "点击数",
           dataIndex: 'ReadTimes',
           width: 70,
           align: 'center'
        },{
           header: "评论数",
           dataIndex: 'Comments',
           width: 70   ,
           renderer:this.commentsRender            
        },{          
           header: "发表时间",
           dataIndex: 'InputTime',
           width: 150
        },
        {header: "操作", sortable:false,width: 80, dataIndex:"op",renderer:this.operationRender}]);  
		AlbumListManage.superclass.initComponent.call(this);
	}
});
