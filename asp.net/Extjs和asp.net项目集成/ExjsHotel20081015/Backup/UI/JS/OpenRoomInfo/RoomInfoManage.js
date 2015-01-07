///<reference path="../../JS/ext.js" />
var RoomOpenInfostore;

RoomOpenInfoManage=function(node){
	//分页每页显示数量	 
	var pageSize = 12;
	//指定列参数
	var fields = ["openroomid","roomid","guestid","guestmoney","OpenTodayTime","opentime","remark"];
	RoomOpenInfostore=new Ext.data.GroupingStore({
           proxy:new Ext.data.HttpProxy(
           {
                url:"DATA/OpenRoomInfo/RoomOpenInfo.aspx",
                method:"POST"
           }),
           reader:new Ext.data.JsonReader(
           {
                        fields:fields,
                        root:"data",
                        id:"openroomid",
                        totalProperty:"totalCount"
                       
           }),
           groupField:'OpenTodayTime', 
           sortInfo: {field:'OpenTodayTime',direction: "DESC"} 
    });
	RoomOpenInfostore.load({params:{start:0,limit:pageSize}}); 
    
	
	//--------------------------------------------------列选择模式
	var sm = new Ext.grid.CheckboxSelectionModel({
		dataIndex:"openroomid"
	});
	//--------------------------------------------------列头
	var cm = new Ext.grid.ColumnModel([
		sm,{
		header:"开房ID",
		dataIndex:"openroomid",
		tooltip:"开房唯一标识ID",
		//列不可操作
		//menuDisabled:true,
		//可以进行排序
        sortable:true
	},{
		header:"房间号",
		tooltip:"客人所住房间编号",
		dataIndex:"roomid",
        sortable:true,
        renderer:function(value)
        {
            return "<font color='blue'>"+value+"</font>"
        }
	},{
		header:"客人编号",
		tooltip:"客人编号",
		dataIndex:"guestid",
        sortable:true
    
        
	},{
		header:"所付定金",
		tooltip:"客人所付定金",
		dataIndex:"guestmoney",
        sortable:true,
        renderer:function(value)
                {   //将数字转换为整数
                    if (value != null && value!="")
                    {
                        var a,b,c,i
                        a = value.toString();
                        b = a.indexOf('.');
                        c = a.length;
                      
                        if (b!=-1)
                            a = a.substring(0,b);
                        }
                        if (b==-1)
                        {
                            a = a + ".";
                            for (i=1;i<=c;i++)
                            a = a - "0";
                        }
                        else
                        {
                            a = a.substring(0,b+c+1);
                            for (i=c;i<=b+c;i++)
                            {
                             a = a - "0";
                            }
                        }
                        return '<span style="color:red;"><b>'+String.format("<font color=red>￥{0}</font>",a)+'</b>&nbsp;元</span>';
                       
                 }
	},{
	    header:"开房日期",
	    tooltip:"开房具体日期",
	    dataIndex:"OpenTodayTime",
	    sortable:true

	},{
		header:"开房时间",
		tooltip:"开房时间",
		dataIndex:"opentime",
        sortable:true
       
	},{
		header:"相关描述信息",
		tooltip:"相关描述信息",
		dataIndex:"remark",
        sortable:true,
        width:300
	}]);
	
    //----右键菜单
    var OpenRoomrightClick = new Ext.menu.Menu
        ({
                items:
                [{
                    text: '新开房间',
                    iconCls:'addicon',
                    handler:SaveGuestINfoFn
                },{
                    text:'编辑房间',
                    iconCls:'editicon',
                    handler:EditRoomOpenInfoFn
                },{
                    text:'退房',
                    iconCls:'deleteicon',
                    handler:DeleteRoomOpenInfoFn
                }]
         });
        
    //----------------------------------------------------定义grid
	var grid = new Ext.grid.GridPanel({
	    id:"RoomOpenInfoGrid",
		store:RoomOpenInfostore,
		sm:sm,
		cm:cm,
		loadMask:true,
		stripeRows:true, 
		autoExpandColumn:7,
		//超过长度带自动滚动条
		autoScroll:true,
		border:false,
		view: new Ext.grid.GroupingView({
		    //自动填充
            forceFit:true,
            sortAscText :'正序排列',
            sortDescText :'倒序排列',
            columnsText:'列显示/隐藏',
            groupByText:'根据本列分组',
            showGroupsText:'是否采用分组显示',
            groupTextTpl: '{text} (<b><font color=red>{[values.rs.length]}</font> </b>{[values.rs.length > 0 ? "条入住信息" : "暂无入住信息"]})'
        }),
		//分页
		bbar:new Ext.PagingToolbar({
			store:RoomOpenInfostore,
			cls:"RoomOpenInfoGridbbar",
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
			text:"开设新房间",
			//默认样式为按下
			//pressed:true,
			tooltip:"开设房间",
			iconCls:"addicon",
			handler:SaveGuestINfoFn
		},"","-","",{
			text:"编辑开房信息",
			tooltip:"编辑当前房间信息",
			iconCls:"editicon",
			handler:EditRoomOpenInfoFn
		},"","-","",{
			text:"退房结算",
			tooltip:"退房结帐",
			iconCls:"deleteicon",
			handler:DeleteRoomOpenInfoFn
		},"-"],listeners:{
            'contextmenu':function(e)
            {
                e.stopEvent();
            },
            "rowcontextmenu":function(grid,rowIndex,e)
            {
                e.stopEvent();
                OpenRoomrightClick.showAt(e.getXY());
            }
		}
	});
	
	//传入icon样式
	GridMain(node,grid,"openroomiconinfo");
};


//---------------------------------------------------------删除选中行房间信息
DeleteRoomOpenInfoFn=function()
{
        var row=Ext.getCmp("RoomOpenInfoGrid").getSelectionModel().getSelections();
        if(row.length==0)
        {
            Ext.Msg.alert("提示信息","请您至少选择一个!");
        }
        else if(row.length>1)
        {
            Ext.Msg.alert("提示信息","对不起只能选择一个!");
        }
        else if(row.length==1){  
            Ext.Msg.confirm("提 示!","您确定要退房吗?",function(btn){ 
                if(btn=="yes")
                {
                   
                   DelOpenRoomInfo(row[0]);
                }
                else
                {
                   
                }
            })
        }  
}


//-----------------------------------------------------修改选中行开房信息
EditRoomOpenInfoFn=function()
{
        var row=Ext.getCmp("RoomOpenInfoGrid").getSelectionModel().getSelections();
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
            EditOpenRoomInfo(row[0]);//传行一行记录直接加载
         
        } 
                    
}



////------------------------------------------------------增加开房信息

SaveGuestINfoFn=function()
{
    AddGuestInfoFn();
}
    
