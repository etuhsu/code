     
     var PublishpageSize=3;
    
     var publishfields=["pubid","pubperson","pubtitle","pubdate","pubcontent"];

     var publishstore=new Ext.data.Store({
           proxy:new Ext.data.HttpProxy(
           {
                url:"DATA/Publish/GetPublishInfoaspx.aspx",
                method:"POST"
           }),
           reader:new Ext.data.JsonReader(
           {
                        fields:publishfields,
                        root:"data",
                        id:"pubid",
                        totalProperty:"totalCount"
                       
           })
    });
    publishstore.setDefaultSort('pubid','desc');
    publishstore.load({params:{start:0,limit:PublishpageSize}}); 

    //--------------------------------------------------列选择模式
	var publishsm = new Ext.grid.RowSelectionModel({
	});
	//--------------------------------------------------列头
	var publishcm = new Ext.grid.ColumnModel([
       ]);
	
   
	var publishinfosgrid = new Ext.grid.GridPanel({
		store:publishstore,
		sm:publishsm,
		cm:publishcm,
		autoHeight:true,
		//height:410,
		width:225,
		loadMask:true,
		stripeRows:true, 
		//trackMouseOver:false,
		//autoExpandColumn:7,
		//超过长度带自动滚动条
		autoScroll:true,
		border:false,
		viewConfig: {
            forceFit:true,
            enableRowBody:true,
            showPreview:true,
            getRowClass :function(record, rowIndex, p,store){
                if(this.showPreview){
                    p.body = String.format('<br><li><b><font color=#436EEE>{0}</font></b></li><br><br><b>Author：</b><font color=red>{1}</font>&nbsp;&nbsp;<b>Date：</b><font color=#B03060>{2}</font><br><br>&nbsp;&nbsp;&nbsp;&nbsp;{3}<br><br><hr style="border : 1px dotted buttonface;width:90%" align="left">',
                             record.data.pubtitle, record.data.pubperson,record.data.pubdate,record.data.pubcontent);
                   return 'x-grid3-row-expanded';
                }
                return 'x-grid3-row-collapsed';
            }
        },
		//分页
		bbar:new Ext.PagingToolbar({
			store:publishstore,
			pageSize:PublishpageSize,
		    emptyMsg:"No results to display",
		    prevText:"上一页",
			nextText:"下一页",
			refreshText:"刷新",
			lastText:"最后页",
			firstText:"第一页",
			beforePageText:"当前",
			afterPageText:"共{0}页"
		}),listeners:{
            'contextmenu':function(e)
            {
                e.stopEvent();
            }
		}
	});
	
