// JScript 文件

var GuestInfoStore;
RoomGuestInfoManage=function(node){

	//分页每页显示数量	 
	var pageSize = 12;
	//指定列参数
	var fields = ["guestid","guestcardid","guestname","guestsex","guestmobile","guestaddress"];
	
	GuestInfoStore = new Ext.data.Store({
		 
		 proxy:new Ext.data.HttpProxy(
           {
                url:"DATA/GuestInfo/GuestInfo.aspx",
                method:"POST"
           }),
           reader:new Ext.data.JsonReader(
   		   {
				fields:fields,
                root:"data",
                id:"guestid",
                totalProperty:"totalCount"
           })
	});
	//加载时参数
	 GuestInfoStore.load({params:{start:0,limit:pageSize}}); 
    
	
	//--------------------------------------------------列选择模式
	var sm = new Ext.grid.CheckboxSelectionModel({
		dataIndex:"guestid"
	});
	//--------------------------------------------------列头
	var cm = new Ext.grid.ColumnModel([
		sm,{
		header:"客人ID",
		dataIndex:"guestid",
		tooltip:"客人唯一标识",
		//可以进行排序
        sortable:true
	},{
		header:"身份证号",
		tooltip:"客人身份证号",
		width:130,
		dataIndex:"guestcardid",
        sortable:true,
        renderer:function(value)
        {
            return "<b>"+value+"</b>";
        }
	},{
		header:"客人姓名",
		tooltip:"入住酒店客人姓名",
		dataIndex:"guestname",
        sortable:true,
        renderer:function(value)
        {
            return "<font color=#EE9572>"+value+"</font>";
        }
	},{
		header:"性别",
		width:80,
		tooltip:"客人性别",
		dataIndex:"guestsex",
        sortable:true,
        renderer:function(value)
        {   
            return value==0?"<font color=red>男</font>":"<font color=blue>女</font>";
        }
	},{
		header:"电话号码",
		tooltip:"客人电话号码",
		dataIndex:"guestmobile",
        sortable:true,
        renderer:function(value)
        {
            return "<b>"+value+"</b>";
        }
       
	},{
		header:"居住地址",
		width:220,
		tooltip:"客人现居住地址",
		dataIndex:"guestaddress",
		//可以进行排序
        sortable:true
	}]);
	
   
    //----------------------------------------------------定义grid
	var GuestInfogrid = new Ext.grid.GridPanel({
	    id:"GuestInfogrid",
		store:GuestInfoStore,
		sm:sm,
		cm:cm,
		loadMask:true,
		//超过长度带自动滚动条
		autoScroll:true,
		border:false,
		viewConfig:{
			columnsText:"显示/隐藏列",
			sortAscText:"正序排列",
			sortDescText:"倒序排列",
			forceFit:true
		},
		//分页
		bbar:new Ext.PagingToolbar({
			store:GuestInfoStore,
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
		,"","-","",{
			text:"编辑",
			tooltip:"编辑客人信息",
			iconCls:"editicon",
			handler:EditGuestInfoFn
		},"","-","",{
			text:"删除",
			tooltip:"删除客人信息",
			iconCls:"deleteicon",
			handler:DelGuestInfoFn
		},"-"],listeners:{
            'contextmenu':function(e)
            {
                e.stopEvent();
            }
		}
	});
	
	//传入icon样式
	GridMain(node,GuestInfogrid,"guesticon");
}

function EditGuestInfoFn ()
{
        var row=Ext.getCmp("GuestInfogrid").getSelectionModel().getSelections();
        if(row.length==0)
        {
            Ext.Msg.alert("提示信息","您没有选中任何行!");
        }
        else if(row.length>1){  
            Ext.Msg.alert("提示信息","对不起只能选择一个!");
        }else if(row.length==1)
        {
            EditGuestInfo(row[0]);//传行一行记录直接加载
        } 
    
}

function DelGuestInfoFn()
{
    var row=Ext.getCmp("GuestInfogrid").getSelectionModel().getSelections();
    if(row.length==0)
    {
        Ext.Msg.alert("提示信息","请您至少选择一个!");
    }
    else{  
            Ext.Msg.confirm("提示!","您确定要删除该客人信息吗?",function(btn){ 
            if(btn=="yes")
            {
               DelGuestInfo(row);
            }
            else
            {
               
            }
        })
    }  

}
