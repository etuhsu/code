///<reference path="../../JS/ext.js" />
var RoomTypestore;
RoomTypeManage=function(node){

   


	//分页每页显示数量	 
	var pageSize = 16;
	//指定列参数
	var fields = ["typeid","typename","typeprice","typeaddbed","addbed","typedesc"];

	
	RoomTypestore = new Ext.data.Store({
		 
		 proxy:new Ext.data.HttpProxy(
           {
                url:"DATA/RoomType/RoomType.aspx",
                method:"POST"
           }),
           reader:new Ext.data.JsonReader(
   		   {
				fields:fields,
                root:"data",
                id:"typeid",
                totalProperty:"totalCount"
           })
	});
	//加载时参数
	 RoomTypestore.load({params:{start:0,limit:pageSize}}); 
    
	
	//--------------------------------------------------列选择模式
	var sm = new Ext.grid.CheckboxSelectionModel({
		dataIndex:"typeid"
	});
	//--------------------------------------------------列头
	var cm = new Ext.grid.ColumnModel([
		sm,{
		header:"类型ID",
		dataIndex:"typeid",
		tooltip:"房间类型ID",
		//列不可操作
		//menuDisabled:true,
		//可以进行排序
        sortable:true
	},{
		header:"房间类型名称",
		tooltip:"房间类型名称",
		dataIndex:"typename",
		//可以进行排序
        sortable:true
	},{
		header:"房间价格",
		tooltip:"房间类型价格",
		dataIndex:"typeprice",
		//可以进行排序
        sortable:true
    
        
	},{
		header:"加床",
		tooltip:"该房间是否可以加床",
		dataIndex:"typeaddbed",
		//可以进行排序
        sortable:true
	},{
		header:"加床价格",
		tooltip:"该房间可加床时的价格",
		dataIndex:"addbed",
		//可以进行排序
        sortable:true
       
	},{
		header:"房间描述",
		tooltip:"房间相关描述内容",
		dataIndex:"typedesc",
		//可以进行排序
        sortable:true
	}]);
	
	//-----------------------------------------------------设置颜色
	
	cm.setRenderer(5,getColor);
	cm.setRenderer(3,getColor);
    function getColor(val)
    {
        if (val != "")
        {
            return '<font color=blue></font><span style="color:red;">' + Ext.util.Format.usMoney(val) + '</span>';
        }
    }
   
    //右键菜单
    var RoomTypeRightClick=new Ext.menu.Menu
        ({
                items:
                [{
                    text: '添加房间类型',
                    iconCls:'addicon',
                    handler:AddRoomTypeFn
                },{
                    text:'编辑房间类型',
                    iconCls:'editicon',
                    handler:EditRoomTypeFn
                },{
                    text:'删除房间类型',
                    iconCls:'deleteicon',
                    handler:DeleteRoomTypeFn
                }]
         });
    //----------------------------------------------------定义grid
	var grid = new Ext.grid.GridPanel({
	    id:"RoomTypeGrid",
		store:RoomTypestore,
		sm:sm,
		cm:cm,
		loadMask:true,
		//自适应宽度 参数为列数
		autoExpandColumn:6,
		//超过长度带自动滚动条
		autoScroll:true,
		border:false,
		viewConfig:{
			columnsText:"显示/隐藏列",
			sortAscText:"正序排列",
			sortDescText:"倒序排列"
		},
		//分页
		bbar:new Ext.PagingToolbar({
			store:RoomTypestore,
			pageSize:pageSize,
			//显示右下角信息
			displayInfo:true,
			displayMsg:'当前记录 {0} -- {1} 条 共 {2} 条记录',
		    emptyMsg:"No results to display",
		    prevText:"上一页",
			nextText:"下一页",
			refreshText:"刷新",
			lastText:"最后页",
			firstText:"第一页",
			beforePageText:"当前页",
			afterPageText:"共{0}页"
		
		}),
		tbar:[
		new Ext.Toolbar.Fill()
		,{
			text:"添加",
			//默认样式为按下
			//pressed:true,
			tooltip:"添加房间类型",
			iconCls:"addicon",
			handler:AddRoomTypeFn
		},"","-","",{
			text:"编辑",
			tooltip:"编辑房间类型",
			iconCls:"editicon",
			handler:EditRoomTypeFn
		},"","-","",{
			text:"删除",
			tooltip:"删除房类型",
			iconCls:"deleteicon",
			handler:DeleteRoomTypeFn
		},"-"],listeners:{
            'contextmenu':function(e)
            {
                e.stopEvent();
            },
            'rowcontextmenu':function(grid,rowIndex,e)
            {
                e.stopEvent();
                RoomTypeRightClick.showAt(e.getXY());
            }
		}
	});
	
	//传入icon样式
	GridMain(node,grid,"roomtypeicon");
};


//---------------------------------------------------------删除选中行房间信息
DeleteRoomTypeFn=function()
{
        //得行单个record对象
        //var row=Ext.getCmp("RoomTypeGrid").getSelectionModel().getSelected();
        //得到多个record对象
        var row=Ext.getCmp("RoomTypeGrid").getSelectionModel().getSelections();
        if(row.length==0)
        {
            Ext.Msg.alert("提示信息","请您至少选择一个!");
        }
        else{  
            Ext.Msg.confirm("提示!","您确定要删除该房间类型信息吗?",function(btn){ 
                if(btn=="yes")
                {
                   DeleteRoomTypeInfo(row);
                }
                else
                {
                   
                }
            })
        }  
}


//-----------------------------------------------------修改选中行房间类型信息
EditRoomTypeFn=function()
{
        var row=Ext.getCmp("RoomTypeGrid").getSelectionModel().getSelections();
        if(row.length==0)
        {
            Ext.Msg.alert("提示信息","您没有选中任何行!");
        }
        else if(row.length>1){  
            Ext.Msg.alert("提示信息","对不起只能选择一个!");
        }else if(row.length==1)
        {
            //调用修改房间类型函数
            //EditRoomTypeInfo(row[0].data.typeid);//传入ID查数据库
            EditRoomTypeInfo(row[0]);//传行一行记录直接加载
        } 
                    
}



//------------------------------------------------------增加房间信息

AddRoomTypeFn=function()
{
    AddRoomTypeInfo();
}
    
