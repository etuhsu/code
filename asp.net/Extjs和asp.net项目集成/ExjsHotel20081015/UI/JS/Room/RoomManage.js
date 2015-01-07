// JScript 文件
var Roomstore;


RoomManage=function(node)
{
   //指定房间类型combox动态加载数据
   
   var roomtypefileds = Ext.data.Record.create([      
        {name: 'typeid',mapping:'typeid'},{name: 'typename',mapping:'typename'},{name:'typedesc',mapping:'typedesc'}                     
    ]);    
   var roomtypestore = new Ext.data.Store({      
        proxy: new Ext.data.HttpProxy({      
            url:'DATA/RoomType/OpenRoomGetAllRoomType.aspx'  
        }),      
        reader: new Ext.data.JsonReader({      
            root: 'data',      
            id:'typeid'     
        },
        roomtypefileds 
        )      
    });   
    roomtypestore.load();
 
    //分页每页显示数量	 
	var pageSize = 12;
	//指定列参数
    var Roomfields=["roomid","number","bednumber","guestnumber","typeid","roomstate","roomdesc"];
 
	Roomstore=new Ext.data.GroupingStore({
           proxy:new Ext.data.HttpProxy(
           {
                url:"DATA/Room/GetRoomInfo.aspx",
                method:"POST"
           }),
           reader:new Ext.data.JsonReader(
           {
                        fields:Roomfields,
                        root:"data",
                        id:"roomid",
                        totalProperty:"totalCount"
                       
           }),
           groupField:'roomstate', 
           sortInfo: {field:'number',direction: "ASC"} 
    });
	Roomstore.load({params:{start:0,limit:pageSize}}); 
    
	
	//--------------------------------------------------列选择模式
	var sm = new Ext.grid.CheckboxSelectionModel({
		dataIndex:"roomid"
	});
	//--------------------------------------------------列头
	var cm = new Ext.grid.ColumnModel([
		sm,
	{
		header:"房间ID",
		dataIndex:"roomid",
		tooltip:"房间唯一标识ID",
		width:80,
		//列不可操作
		//menuDisabled:true,
		//可以进行排序
        sortable:true
	},{
		header:"房间号",
		tooltip:"房间号码",
		width:80,
		dataIndex:"number",
        sortable:true,
        renderer:function(val)
        {

         return '<b><font color=blue>'+val+'</font></b>';

        }
       
	},{
		header:"床位数",
		tooltip:"所在房间床位数量",
		dataIndex:"bednumber",
        sortable:true,
        width:80,
        editor:new Ext.form.NumberField({
            style:'text-align:left'
        }),
        renderer:function(value)
        {
            return "<b><font color=red>"+value+"</font></b>&nbsp;张"
        }
	},{
		header:"容纳客人数",
		tooltip:"该房间所住客人数",
		dataIndex:"guestnumber",
        sortable:true,
        editor:new Ext.form.NumberField({
            style: 'text-align:left'
        }),
        renderer:function(value)
        {
            return "<b><font color=red>"+value+"</font></b>&nbsp;人"
        }
	},{
		header:"房间类型",
		tooltip:"房间所属类型",
		dataIndex:"typeid",
        sortable:true,
        renderer:function(value,meta,record,rowIndex,colIndex,store)
        {
            if(value<1)
            {
                return "暂无数据";
            }
            else
            {      
            
             return "<b><font color=#008B8B>"+roomtypestore.getAt(value-1).data.typename+"</font></b>";
            }

        },
        editor:new Ext.form.ComboBox({
            tpl: '<tpl for="."><div ext:qtip="{typename}. {typedesc}" class="x-combo-list-item">{typename}</div></tpl>',
            store:roomtypestore,
            typeAhead: true,
            forceSelection: true,
            triggerAction: 'all',
            selectOnFocus:true,
            width:130,
            value:"typeid",
            editable: false, 
            displayField:'typename',
            valueField: 'typeid',
            mode: 'remote'
            })
	},{
	    header:"房间状态",
	    tooltip:"目前房间状态具体状态",
	    dataIndex:"roomstate",
	    sortable:true,
	    renderer:function(value)
	    {
	        if(value==0)
	        {
	            return "空闲";
	        }else if(value==1)
	        {
	           return "入住";
	        }else if(value==2)
	        {
	           return "维修";
	        }else if(value==3)
	        {
	          return "自用";
	        }else
	        {
	          return "其它";
	        }
	    },
	    editor:new Ext.form.ComboBox({
	        store:new Ext.data.SimpleStore({
	            data:[["空闲","0"],["入住","1"],["维修","2"],["自用","3"],["其它","4"]],
	            fields:["state","value"]
	        }),
	        tpl: '<tpl for="."><div ext:qtip="设置房间状态为--{state}" class="x-combo-list-item">{state}</div></tpl>',
	        displayField:"state",
	        mode:"local",
	        valueField:"value",
	        triggerAction:"all"
	    })
	},{
		header:"房间描述",
		tooltip:"房间具体描述",
		width:200,
		dataIndex:"roomdesc",
        sortable:true,
       editor:new Ext.form.TextField
	}]);
	
    //-----------------------右键菜单
    var RoomRightClick=new Ext.menu.Menu
        ({
                items:
                [{
                    text: '刷新信息',
                    iconCls:'addicon',
                    handler:function()
                    {
                       
                      Roomstore.reload();
                     
                    }
                },{
                    text:'添加房间',
                    iconCls:'editicon',
                    handler:AddRoomInfo
                },{
                    text:'删除房间',
                    iconCls:'deleteicon',
                    handler:DelRoomInfo
                }]
         });
    //----------------------------------------------------定义grid
	var Roomgrid = new Ext.grid.EditorGridPanel({
	    id:"RoomInfoGrid",
		store:Roomstore,
		sm:sm,
		cm:cm,
		loadMask:true,
		stripeRows:true, 
		clicksToEdit:1,
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
            groupTextTpl: '{text} (<b><font color=red>{[values.rs.length]}</font></b> {[values.rs.length > 0 ? "条房间信息" : "暂无房间信息"]})'
        }),
		//分页
		bbar:new Ext.PagingToolbar({
			store:Roomstore,
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
		new Ext.Toolbar.Fill(),
		new Ext.Toolbar.TextItem("<font color=blue>可点击直接编辑</font>")
		,"","-",
		{
			text:"刷新信息",
			//默认样式为按下
			//pressed:true,
			tooltip:"刷新当前页面信息",
			iconCls:"refreshicon",
			handler:function()
			{
			    Roomstore.reload();
			}
		},"","-"
		,{
			text:"添加房间",
			//默认样式为按下
			//pressed:true,
			tooltip:"添加新房间",
			iconCls:"addicon",
			handler:AddRoomInfo
		},"","-","",{
			text:"删除房间",
			tooltip:"删除房间",
			iconCls:"deleteicon",
			handler:DelRoomInfo
		},"-"],listeners:{
            'contextmenu':function(e)
            {
                e.stopEvent();
            },
             "afteredit":function(e)
                 {
                    var g=e.grid;//得到当前grid
                    var r=e.record;//得到当前行所有数据
                    var f=e.field;//得到修改列
                    var v=e.value;//得到修改列修改后值
                    var orgin=e.originalValue;//修改列修改前值
                    var row=e.row;//当前行索引
                    var col=e.column;//当前点击的列索引
                    //alert("ID："+r.data.id+"-field:"+f+"-value:"+v+"-修改前值："+orgin+"-坐标:"+row+","+col);
                    //通过ajax请求修改数据
                    if(r.data.bednumber<r.data.guestnumber)
                    {
                        Roomstore.reload();
                        Ext.Msg.alert("提示","对不起客人数必须小于床位数");
                    }
                    else
                    {
                        Ext.Ajax.request({
                            url:"URL/Room/SaveEditGridRoomInfo.aspx",
                            method:"POST",
                            params:{
                                field:f,
                                value:v,
                                roomid:r.data.roomid
                            },
                            success:function(response,option)
                            {
                                Roomstore.reload();                               
                            },
                            failure:function()
                            {
                                Roomstore.reload();
                                Ext.Msg.alert("不好意思","修改失败了!");
                            }
                        });
                    }
                 },
                 "rowcontextmenu":function(grid,rowIndex,e)
                 {
                    e.stopEvent();
                    RoomRightClick.showAt(e.getXY());
                 }
		}
	});
   
   
    GridMain(node,Roomgrid,"roomicons");
}

///--------------------------添加房间信息
AddRoomInfo=function()
{
     AddRoonInfos();
}

//----------------------删除房间信息
DelRoomInfo=function()
{
        var row=Ext.getCmp("RoomInfoGrid").getSelectionModel().getSelections();
        if(row.length==0)
        {
            Ext.Msg.alert("提示信息","请您至少选择一个!");
        }
        else{  
                Ext.Msg.confirm("提示!","您确定要删除房间信息吗?",function(btn){ 
                if(btn=="yes")
                {
                    
                     DelRoomInfos(row);
                }
                else
                {
                   
                }
            })
        }  
  
}
