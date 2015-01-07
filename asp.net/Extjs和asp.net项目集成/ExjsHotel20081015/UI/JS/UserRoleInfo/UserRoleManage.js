// JScript 文件
var RoleInfoStore;
var UserInfoStore;


UserRoleInfoManage=function(node)
{
    
    //分页数大小
    var pageSize=4;
	var roleInfofields=["roleid","rolename","roledesc"];
    RoleInfoStore=new Ext.data.Store({
               proxy:new Ext.data.HttpProxy(
               {
                    url:"DATA/RoleInfo/RoleInfo.aspx",
                    method:"POST"
               }),
               reader:new Ext.data.JsonReader(
               {
                            fields:roleInfofields,
                            root:"data",
                            id:"roleid",
                            totalProperty:"totalCount"   
               })
        });
   RoleInfoStore.load({params:{start:0,limit:pageSize}}); 
   
   
   var userInfofields=["id","userid","username","userpwd","userstate","roleid"];
   UserInfoStore=new Ext.data.Store({
               proxy:new Ext.data.HttpProxy(
               {
                    url:"DATA/UserInfo/UserInfo.aspx",
                    method:"POST"
               }),
               reader:new Ext.data.JsonReader(
               {
                            fields:userInfofields,
                            root:"data",
                            id:"id",
                            totalProperty:"totalCount"   
               })
        });
   UserInfoStore.load({params:{start:0,limit:pageSize}});
   
   
   var rolesm = new Ext.grid.CheckboxSelectionModel({
		dataIndex:"roleid"
	});
    var usersm = new Ext.grid.CheckboxSelectionModel({
		dataIndex:"id"
	});
	
	//--------------------------------------------------列头
	var rolecm = new Ext.grid.ColumnModel([
		rolesm,{
		header:"角色ID",
		dataIndex:"roleid",
		tooltip:"角色类型ID",
		//列不可操作
		//menuDisabled:true,
        sortable:true
	},{
		header:"角色名称",
		tooltip:"角色名称",
		dataIndex:"rolename",
        sortable:true
	},{
		header:"角色描述",
		tooltip:"角色相关描述",
		dataIndex:"roledesc",
        sortable:true    
	}
	]);
    
    var usercm = new Ext.grid.ColumnModel([
		usersm,{
		header:"ID",
		dataIndex:"id",
		tooltip:"用户唯一标识",
        sortable:true
	},{
		header:"用户帐号",
		dataIndex:"userid",
		tooltip:"用户帐号信息",
        sortable:true
	},{
		header:"用户称谓",
		tooltip:"用户称谓",
		dataIndex:"username",
        sortable:true
	},{
		header:"用户密码",
		tooltip:"用户密码信息",
		dataIndex:"userpwd",
        sortable:true,
        renderer:function()
        {
            return "* * * * * *";
        }
    
        
	},{
		header:"用户状态",
		tooltip:"用户状态信息",
		dataIndex:"userstate",
        sortable:true,
        renderer:function(value)
        {
            return value==0?"<font color=blue>正常</font>":"<font color=red>禁用</font>";
        }
	},{
		header:"角色ID",
		tooltip:"用户角色ID",
		dataIndex:"roleid",
        sortable:true
       
	}
	]);
    
    var rolegrid = new Ext.grid.GridPanel({
        id:'rolegrid',
		store:RoleInfoStore,
		sm:rolesm,
		cm:rolecm,
		
		//width:600,
		autoWidth:true,
		loadMask:true,
		height:170,
		//超过长度带自动滚动条
		autoScroll:true,
		border:false,
		viewConfig:{
			columnsText:"显示/隐藏列",
			sortAscText:"正序排列",
			sortDescText:"倒序排列",
			forceFit:true
		},
		bbar:[new Ext.PagingToolbar({
			store:RoleInfoStore,
			pageSize:pageSize,
			//显示右下角信息
		    emptyMsg:"No results to display",
		    prevText:"上一页",
			nextText:"下一页",
			refreshText:"刷新",
			lastText:"最后页",
			firstText:"第一页",
			beforePageText:"当前页",
			afterPageText:"共{0}页"
		}),new Ext.Toolbar.Fill()],
		tbar:[{
			text:"添加",
			tooltip:"添加角色信息",
			iconCls:"addicon",
			handler:AddRoleInfoFn
		},"","-","",{
			text:"编辑",
			tooltip:"编辑角色信息",
			iconCls:"editicon",
			handler:EditRoleInfoFn
		},"","-","",{
			text:"删除",
			tooltip:"删除角色信息",
			iconCls:"deleteicon",
			handler:DelRoleInfoFn
		},"-",new Ext.Toolbar.Fill()],listeners:{
            'contextmenu':function(e)
            {
                e.stopEvent();
            },
            'rowcontextmenu':function(grid,rowIndex,e)
            {
                e.stopEvent();
            }
		}
	});
	
  
    var usergrid = new Ext.grid.GridPanel({
	    id:"usergrid",
		store:UserInfoStore,
		sm:usersm,
		cm:usercm,
		loadMask:true,
		//width:600,
		//超过长度带自动滚动条
		autoScroll:true,
		autoExpandColumn:4,
		autoWidth:true,
		border:false,
		height:180,
		viewConfig:{
			columnsText:"显示/隐藏列",
			sortAscText:"正序排列",
			sortDescText:"倒序排列",
			forceFit:true
		},
		//分页
		bbar:[new Ext.PagingToolbar({
			store:UserInfoStore,
			pageSize:pageSize,
		    emptyMsg:"No results to display",
		    prevText:"上一页",
			nextText:"下一页",
			refreshText:"刷新",
			lastText:"最后页",
			firstText:"第一页",
			beforePageText:"当前页",
			afterPageText:"共{0}页"
		}),new Ext.Toolbar.Fill()],
		tbar:[{
			text:"添加",
			tooltip:"添加用户信息",
			iconCls:"addicon",
			handler:AddUserInfoFn
		},"","-","",{
			text:"编辑",
			tooltip:"编辑用户信息",
			iconCls:"editicon",
			handler:EditUserInfoFn
		},"","-","",{
			text:"删除",
			tooltip:"删除用户信息",
			iconCls:"deleteicon",
			handler:DelUserInfoFn
			
		},"-",new Ext.Toolbar.Fill()],listeners:{
            'contextmenu':function(e)
            {
                e.stopEvent();
            },
            'rowcontextmenu':function(grid,rowIndex,e)
            {
                e.stopEvent();
            }
		}
	});
	
	
    
    var roleinfofs=new Ext.form.FieldSet({
        collapsible:true,
        title:"<font color=red>角色信息管理</font>",
        border:true,
        autoWidth:true,
        autoHeight:true,
        items:[rolegrid]
    });
    
    var userinfofs=new Ext.form.FieldSet({
        collapsible:true,
        title:"<font color=red>用户信息管理</font>",
        border:true,
        autoWidth:true,
        style: Ext.isIE ? 'padding:30px 0 0 0;' : 'padding:20px 0 0 0;',
        autoHeight:true,
        items:[usergrid]
    });



    var UserRoleInfoForm = new Ext.FormPanel({
        id: 'UserRoleInfoForm',
        frame: true,
        bodyStyle:'padding:5px',
        autoWidth:true,
        aotoHeight:true,
        border:false,
        layout: 'column',
        defaults:{anchor:"95%"},
        items: [roleinfofs,userinfofs]
    });
    
    //--------------------------显示表单
    GridMain(node,UserRoleInfoForm,"usericon");
}

function EditUserInfoFn()
{
        var row=Ext.getCmp("usergrid").getSelectionModel().getSelections();
        if(row.length==0)
        {
            Ext.Msg.alert("提示信息","您没有选中任何行!");
        }
        else if(row.length>1){  
        
            Ext.Msg.alert("提示信息","对不起只能选择一个!");
        }else if(row.length==1)
        {
             
             EditUserInfos(row[0]);//传行一行记录直接加载
        }    
}

function DelUserInfoFn()
{
    var row=Ext.getCmp("usergrid").getSelectionModel().getSelections();
    if(row.length==0)
    {
        Ext.Msg.alert("提示信息","请您至少选择一个!");
    }
    else{  
            Ext.Msg.confirm("提示!","您确定要删除该客人信息吗?",function(btn){ 
            if(btn=="yes")
            {
               DeleteUserInfoFn(row);
            }
            else
            {
               
            }
        })
    }  
}


function EditRoleInfoFn()
{
        var row=Ext.getCmp("rolegrid").getSelectionModel().getSelections();
        if(row.length==0)
        {
            Ext.Msg.alert("提示信息","您没有选中任何行!");
        }
        else if(row.length>1){  
        
            Ext.Msg.alert("提示信息","对不起只能选择一个!");
        }else if(row.length==1)
        {
             EditRoleInfoFns(row[0]);//传行一行记录直接加载
        }    
}

function DelRoleInfoFn()
{
    var row=Ext.getCmp("rolegrid").getSelectionModel().getSelections();
    if(row.length==0)
    {
        Ext.Msg.alert("提示信息","请您至少选择一个!");
    }
    else{  
            Ext.Msg.confirm("提示!","您确定要删除该客人信息吗?",function(btn){ 
            if(btn=="yes")
            {
               DelRoleInfoFns(row);
            }
            else
            {
               
            }
        })
    }  
}
