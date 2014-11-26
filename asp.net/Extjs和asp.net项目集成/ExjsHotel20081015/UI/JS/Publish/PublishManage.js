// JScript 文件
var PublishInfoStore;
PublishManage=function(node)
{//分页每页显示数量	 
	var pageSize = 12;
	//指定列参数
    var PublishFields=["pubid","pubperson","pubtitle","pubdate","pubcontent"];
 
	PublishInfoStore=new Ext.data.GroupingStore({
           proxy:new Ext.data.HttpProxy(
           {
                url:"DATA/Publish/GetPublishInfoaspx.aspx",
                method:"POST"
           }),
           reader:new Ext.data.JsonReader(
           {
                        fields:PublishFields,
                        root:"data",
                        id:"pubid",
                        totalProperty:"totalCount"
                       
           }),
           groupField:'pubdate', 
           sortInfo: {field:'pubdate',direction: "DESC"} 
    });
	PublishInfoStore.load({params:{start:0,limit:pageSize}}); 
    
	
	//--------------------------------------------------列选择模式
	var sm = new Ext.grid.CheckboxSelectionModel({
		dataIndex:"pubid"
	});
	//--------------------------------------------------列头
	var cm = new Ext.grid.ColumnModel([
		sm,
	{
		header:"公告ID",
		dataIndex:"pubid",
		tooltip:"公告唯一标识ID",
		width:50,
        sortable:true
	},{
		header:"发布人",
		tooltip:"公告发布人",
		width:55,
		dataIndex:"pubperson",
        sortable:true,
        renderer:function(v)
        {
            return "<font color=red>"+v+"</font>";
        }
       
	},{
		header:"标题",
		tooltip:"公告标题",
		width:60,
		dataIndex:"pubtitle",
        sortable:true
	},{
		header:"发布时间",
		width:60,
		tooltip:"公告发布时间",
		dataIndex:"pubdate",
        sortable:true
	},{
		header:"公告内容",
		tooltip:"公告内容",
		dataIndex:"pubcontent",
        sortable:true
	}]);
	
   
	var Publishgrid = new Ext.grid.GridPanel({
	    id:"PublishInfoGrid",
		store:PublishInfoStore,
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
            groupTextTpl: '{text} (<font color=red><b>{[values.rs.length]}</b></font> {[values.rs.length > 0 ? "条公告信息" : "暂无公告信息"]})'
        }),
		//分页
		bbar:new Ext.PagingToolbar({
			store:PublishInfoStore,
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
		,"","-",
		{
			text:"刷新信息",
			//默认样式为按下
			//pressed:true,
			tooltip:"刷新当前页面信息",
			iconCls:"refreshicon",
			handler:function()
			{
			    PublishInfoStore.reload();
			}
		},"","-"
		,{
			text:"添加",
			//默认样式为按下
			//pressed:true,
			tooltip:"添加新公告",
			iconCls:"addicon",
			handler:AddPublishInFn
		},"","-",{
			text:"编辑",
			//默认样式为按下
			//pressed:true,
			tooltip:"编辑公告信息",
			iconCls:"editicon",
			handler:EditPublishInfoFn
		},"","-","",{
			text:"删除",
			tooltip:"删除房间",
			iconCls:"deleteicon",
			handler:DelPublishInfoFn
		},"-"],listeners:{
            'contextmenu':function(e)
            {
                e.stopEvent();
            }
		}
	});
   
   
    GridMain(node,Publishgrid,"publishicon");
}


function DelPublishInfoFn()
{
    var row=Ext.getCmp("PublishInfoGrid").getSelectionModel().getSelections();
    if(row.length==0)
    {
        Ext.Msg.alert("提示信息","请您至少选择一个!");
    }
    else{  
            Ext.Msg.confirm("提示!","您确定要删除该公告信息吗?",function(btn){ 
            if(btn=="yes")
            {
               DelPublishInfoFns(row);
            }
            else
            {
               
            }
        })
    }  
}


function EditPublishInfoFn()
{
        var row=Ext.getCmp("PublishInfoGrid").getSelectionModel().getSelections();
        if(row.length==0)
        {
            Ext.Msg.alert("提示信息","您没有选中任何行!");
        }
        else if(row.length>1){  
        
            Ext.Msg.alert("提示信息","对不起只能选择一个!");
        }else if(row.length==1)
        {
             EditPublishInfoFns(row[0]);//传行一行记录直接加载
        }    
}
