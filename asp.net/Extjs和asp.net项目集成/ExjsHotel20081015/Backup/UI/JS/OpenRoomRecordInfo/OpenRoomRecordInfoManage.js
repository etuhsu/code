// JScript 文件

var OpenRoomRecordStore;

OpenRoomRecordManage=function(node)
{
   
   
   
   
   //分页每页显示数量	 
	var pageSize = 12;
	//指定列参数
    var OpenRoomRecordfields=["recordid","roomid","guestid","guestmoney","opentodaytime","opentime","endtodaytime","endtime","remark"];

	OpenRoomRecordStore=new Ext.data.GroupingStore({
           proxy:new Ext.data.HttpProxy(
           {
                url:"DATA/OpenRoomRecordInfo/OpenRoomRecordInfo.aspx",
                method:"POST"
           }),
           reader:new Ext.data.JsonReader(
           {
                        fields:OpenRoomRecordfields,
                        root:"data",
                        id:"recordid",
                        totalProperty:"totalCount"
                       
           }),
           groupField:'endtodaytime', 
           sortInfo: {field:'roomid',direction: "ASC"}
          
    });
	OpenRoomRecordStore.load({params:{start:0,limit:pageSize}}); 
    
    //-------------------------------------------------------搜索
    function SerachOpenRoomRecord()
    {
        var message = Ext.get('message').dom.value;
        
        OpenRoomRecordStore.reload
        ({
                params:{start:0,limit:pageSize,msg:message}
        });
    }
	
	//--------------------------------------------------列选择模式
	var sm = new Ext.grid.CheckboxSelectionModel({
		dataIndex:"opentodaytime"
	});
	//--------------------------------------------------列头

	var cm = new Ext.grid.ColumnModel([
		sm,
	{
		header:"ID",
		dataIndex:"recordid",
		tooltip:"记录唯一标识ID",
		width:50,
		//列不可操作
		//menuDisabled:true,
		//可以进行排序
        sortable:true
	},{
		header:"房间号",
		tooltip:"房间号码",
		width:70,
		dataIndex:"roomid",
        sortable:true
       
	},{
		header:"客人姓名",
		tooltip:"房间所住客人姓名",
		dataIndex:"guestid",
        sortable:true
	},{
		header:"定金",
		tooltip:"客人开房时所付的定金",
		dataIndex:"guestmoney",
        sortable:true,
        renderer:function(val)
        {
            if (val != "")
            {
                return '<font color=blue></font><span style="color:red;">' + Ext.util.Format.usMoney(val) + '</span>';
            }
        }
	},{
		header:"开房日期",
		tooltip:"客人开房时的日期",
		dataIndex:"opentodaytime",
        sortable:true
	},{
	    header:"开房时间",
	    tooltip:"客人开房时的具体时间",
	    dataIndex:"opentime",
	    sortable:true
	},{
		header:"退房日期",
		tooltip:"客人具体退房日期",
		dataIndex:"endtodaytime",
        sortable:true
	},{
		header:"退房时间",
		tooltip:"客人退房的具体时间",
		dataIndex:"endtime",
        sortable:true
	},{
		header:"相关描述",
		tooltip:"相关描述",
		dataIndex:"remark",
        sortable:true,
        width:180
	}]);
	
       
    //----------------------------------------------------定义grid
	var OpenRoomRecordGrid = new Ext.grid.GridPanel({
	    id:"OpenRoomRecordInfoGrid",
		store:OpenRoomRecordStore,
		sm:sm,
		cm:cm,
		loadMask:true,
		stripeRows:true, 
		//autoExpandColumn:7,
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
            groupTextTpl: '{text} (<font color=red><b>{[values.rs.length]}</b></font> {[values.rs.length > 0 ? "条记录" : "暂无记录"]})'
        }),
		//分页
		bbar:new Ext.PagingToolbar({
			store:OpenRoomRecordStore,
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
		 '','','<b>Search:</b> ', ' ',
		{
		    xtype:'textfield',
		    width:220,
		    id:'message',
		    name:'message',
		    emptyText:"开房/退房（日期/时间）/备注信息"
		},'','-','',{
            text:'搜 索',
            pressed:true,
            tooltip:"关键字：开房/退房（日期/时间）/备注信息",
            iconCls:'serchopenroomrecord',
            handler:SerachOpenRoomRecord
        },'',
		new Ext.Toolbar.Fill()
		,"","-",
		new Ext.Toolbar.TextItem("<font color=blue>修改数据联系：DB管理员</font>"),
		"","-",
		{
			text:"刷新",
			//默认样式为按下
			//pressed:true,
			tooltip:"刷新当前页面信息",
			iconCls:"refreshicon",
			handler:function()
			{
			    //OpenRoomRecordStore.reload();
			    OpenRoomRecordStore.load({params:{start:0,limit:pageSize}}); 
			}
		}],
		listeners:{
            'contextmenu':function(e)
            {
                e.stopEvent();
            } 
		}
	});
    
   GridMain(node,OpenRoomRecordGrid,"roolrecordicon");
}
