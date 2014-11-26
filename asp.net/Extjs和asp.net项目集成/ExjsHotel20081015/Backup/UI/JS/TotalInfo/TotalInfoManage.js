// JScript 文件
var TotalInfoStore;

function getValue(value,meta,record,rowIndex,colIndex,store)
{
    return value==0?"男":"女";
}

TotalInfoManage=function(node)
{
    
    //分页数大小
    var pageSize=10;
	var fields=["totalid","totaltype","totalmoney","totaltime","totalremark"];
    TotalInfoStore=new Ext.data.Store({
               proxy:new Ext.data.HttpProxy(
               {
                    url:"DATA/TotalInfo/TotalInfo.aspx",
                    method:"POST"
               }),
               reader:new Ext.data.JsonReader(
               {
                            fields:fields,
                            root:"data",
                            id:"totalid",
                            totalProperty:"totalCount"   
               })
        });
   TotalInfoStore.load({params:{start:0,limit:pageSize}}); 
   
   
    //-------------------------------------------------------查询
    function SerachTotalInfo(x)
    {
        var starttimes = x.ownerCt.findByType("datefield")[0].value;
        var endtimes =x.ownerCt.findByType("datefield")[1].value;
        pageSize=100000;
        TotalInfoStore.reload
        ({
                params:{start:0,limit:pageSize,starttime:starttimes,endtime:endtimes}
        });
       
    }
    
    function CountTotalInfo(x)
    {
        var starttimes = x.ownerCt.findByType("datefield")[0].value;
        var endtimes =x.ownerCt.findByType("datefield")[1].value;
        Ext.Ajax.request({
                url:'URL/TotalInfo/CountStartEndTimeMoney.aspx',
                method:"POST",
                params:{starttime:starttimes,endtime:endtimes},
                success: function(response, options) {  
                   var responseArray = Ext.util.JSON.decode(response.responseText);                                 
                   if(responseArray.success == false){     
                       Ext.Msg.alert("","<center><br><font color=red>操作错误，请正确选择时间</font> </b></center>");
                   }else
                   {   
                        if(responseArray.success=='false')
                        {
                            Ext.Msg.alert("","<center><br><font color=red>操作错误，请正确选择时间</font> </b></center>");
                        }
                        else{
                            Ext.Msg.alert("","<center><br>(您所选择时间段酒店收入总额)<br><b>人民币： <font color=red>"+responseArray.success+"</font>  元</b></center>");
                        }
                   }  
                },
                failure:function()
                {
                    Ext.Msg.alert("提示!","暂时无法计算请稍后再试.....");
                }
           });
    }
    
   var cm=new Ext.grid.ColumnModel([
           {
                header:"ID",
                dataIndex:"totalid",
                menuDisabled:true,
                width:40,
                //排序
                sortable:true
           },
           {
                header:"消费类型",
                width:50,
                dataIndex:"totaltype",
                sortable:true
           },
           {
                 header:"消费金额",
                 dataIndex:"totalmoney",
                 sortable:true,
                 renderer:function(v)
                 {
                    return "<font color=red>"+Ext.util.Format.usMoney(v)+"</font>";
                 }
           },
           {
                 header:"结帐时间",
                 dataIndex:"totaltime",
                 sortable:true
           },
           {
                header:"结帐描述",
                dataIndex:"totalremark",
                sortable:true
           }
        ]);


    var ftotalinfo=new Ext.form.FieldSet({
        collapsible:true,
        title:"详细信息",
        border:true,
        labelWidth: 35,
        width:193,
        autoHeight:true,
        layout:'form',
        defaults:{autoWidth:true},
        items:[
           {
               xtype:'textfield',
                fieldLabel:'类型',
                name:'totaltype',
                readOnly:true
            },{
                 xtype:'textfield',
                fieldLabel:'金额',
                name:'totalmoney',
                readOnly:true
            },{
                 xtype:'textfield',
                fieldLabel:'时间',
                name:'totaltime',
                readOnly:true
            },{
                xtype:'textarea',
                fieldLabel:'描述',
                name:'totalremark',
                readOnly:true
            }]
    
    });

    
     var ftotalcontrol=new Ext.form.FieldSet({
        collapsible:true,
        title:"查询信息",
        style:'padding:40px 0 0 10',
        border:true,
        labelWidth: 70,
        buttonAlign:"center",
        width:193,
        autoHeight:true,
        layout:'form',
        defaults: {autoWidth:true},
        items:[
        {
            xtype:"datefield",
            format: 'Y-m-d',
            readOnly:true,
            emptyText: '请选择日期',
            fieldLabel: '开始时间',
            name: 'starttime',
            id:'starttime'
        },{
            xtype:"datefield",
            format: 'Y-m-d', 
            readOnly:true, 
            emptyText: '请选择日期',
            fieldLabel: '结束时间',
            name: 'endttime',
            id:'endttime'
        }],
        buttons:[{
            text:'查询记录',
            minWidth:60,
            handler:SerachTotalInfo
        },{
            text:'计算收入',
            minWidth:60,
            handler:CountTotalInfo
        }] 
    
    });



    var TotalInfogridForm = new Ext.FormPanel({
        id: 'TotalInfogridForm',
        frame: true,
        bodyStyle:'padding:5px',
        autoWidth:true,
        aotoHeight:true,
        border:false,
        layout: 'column',
        defaults:{anchor:"95%"},
        items: [{
                columnWidth: 0.6,
                layout: 'fit',
                items:{
	                        xtype: 'grid',
                            height:445,
                            cm:cm,
                            loadMask : true,
                            store:TotalInfoStore,
	                        border:false,
                            viewConfig:{
                                columnsText:"显示/隐藏列",
                                sortAscText:"正序排列",
                                sortDescText:"倒序排列",
                                forceFit: true
                            },
                            sm: new Ext.grid.RowSelectionModel({
	                            singleSelect: true,
	                            listeners: {
	                                "rowselect":function(sm, row, rec) {
	                                    Ext.getCmp("TotalInfogridForm").getForm().loadRecord(rec);
	                                }
	                            }
	                        }),
	                        tbar:[
	                            new Ext.Toolbar.Fill(),
	                            "","-",""
		                        ,{
			                        text:"刷新",
			                        //默认样式为按下
			                        //pressed:true,
			                        tooltip:"刷新当前页面",
			                        iconCls:"refreshicon",
			                        handler:function()
			                        {
			                            TotalInfoStore.reload();
			                        }
		                        },"","-",""
		                    ],
                            bbar:new Ext.PagingToolbar({
                                store:TotalInfoStore,
                                pageSize:pageSize,
                                displayInfo:true,
                                displayMsg:' {0}-{1} 条 共 {2} 条',
                                emptyMsg:"No results to display",
                                prevText:"上一页",
                                nextText:"下一页",
                                refreshText:"刷新",
                                lastText:"最后页",
                                firstText:"第一页",
                                beforePageText:"当前页",
                                afterPageText:"共{0}页"
                            }),
                            listeners:
                            {
                                "render": function(g) {
		        		            g.getSelectionModel().selectRow(0);
		        	            },
		        	            delay: 10 
                            }
                    
        	         }
        },{
        	columnWidth: 0.4,
        	layout:'form',
            autoWidth:true,
            height:445,
            
            bodyStyle: Ext.isIE ? 'padding:0 0 5px 15px;' : 'padding:10px 15px;',
            border: true,
            style: {
                "margin-left": "10px", 
                "margin-right": Ext.isIE6 ? (Ext.isStrict ? "-10px" : "-13px") : "0"  
            },
            items: [ftotalinfo,ftotalcontrol]
        }]
       //renderTo:Ext.getBody()
    });
    
    //--------------------------显示表单
    GridMain(node,TotalInfogridForm,"totalicon");
}
