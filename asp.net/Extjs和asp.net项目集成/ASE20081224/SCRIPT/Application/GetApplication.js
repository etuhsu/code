// JScript 文件

Ext.onReady(function(){
    Ext.QuickTips.init();
    var form = new Ext.form.BasicForm('form1'); 
    Ext.form.Field.prototype.msgTarget = 'side';
    var screen_width=960;
    var main_form_width=960;
    var Search_data;
function formatDate(value)
{
    return value ? value.dateFormat('Y-m-d') : '';
};
   function GetQueryString(name)
	{
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)","i");
        var r = window.location.search.substr(1).match(reg);
        if (r!=null) return unescape(r[2]); return null;
    }
   var ds=new Ext.data.GroupingStore({
        proxy: new Ext.data.HttpProxy({
            url:'../../ashx/Application/GetApplication.ashx'
        }),
        reader:new Ext.data.JsonReader({
            root: 'LIST'
        },
       [
            {name: 'LEE_OTE_NAME', type: 'string'},
            {name: 'LEE_OTE_CODE', type: 'string'},
            {name: 'APP_ID', type: 'string'},
            {name: 'APP_CAUSE', type: 'string'},
            {name: 'ATE_ID', type: 'int'},
            {name: 'ADS_CODE', type: 'string'},
            {name: 'ADS_NAME', type: 'string'},
            {name: 'APP_DATE', type: 'string'},
            {name: 'APP_FROM_TIME', type: 'string'},           
            {name: 'APP_TO_TIME', type: 'string'},
            {name: 'APP_NUM_TIME', type: 'string'},
            {name: 'USER_CNAME', type: 'string'},
            {name: 'ATE_NAME', type: 'string'},
            {name: 'USER_ID', type: 'string'},
            {name: 'USER_DEPARTMENT', type: 'string'},
            {name: 'USER_SHIFT', type: 'string'},
            {name: 'APP_CREATE_DT', type: 'string'},
            {name: 'APP_DISPOSED', type: 'string'}
       ])
   }); 
  ds.load();
  

  
   var jsonRecord = Ext.data.Record.create(
   [
            {name: 'LEE_OTE_NAME', type: 'string'},
            {name: 'LEE_OTE_CODE', type: 'string'},
            {name: 'APP_ID', type: 'string'},
            {name: 'APP_CAUSE', type: 'string'},
            {name: 'ATE_ID', type: 'int'},
            {name: 'ADS_CODE', type: 'string'},
            {name: 'ADS_NAME', type: 'string'},
            {name: 'APP_DATE', type: 'string'},
            {name: 'APP_FROM_TIME', type: 'string'},           
            {name: 'APP_TO_TIME', type: 'string'},
            {name: 'APP_NUM_TIME', type: 'string'},
            {name: 'USER_CNAME', type: 'string'},
            {name: 'ATE_NAME', type: 'string'},
            {name: 'USER_ID', type: 'string'},
            {name: 'USER_DEPARTMENT', type: 'string'},
            {name: 'USER_SHIFT', type: 'string'},
            {name: 'APP_CREATE_DT', type: 'string'},
            {name: 'APP_DISPOSED', type: 'string'}

   ]);
  
  
    var expander = new Ext.grid.RowExpander({
        tpl : new Ext.Template(　
        '<br>',
            '<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>原　因：</b> {APP_CAUSE}</p>'
        )
    }); 
function dtColor(val)
{
   var dt=new Date();
   if(val.substring(0,val.indexOf(' '))==dt.format('Y-m-d').toString())
   {
     return '<span><font style="color:red;">'+ val+'</font></span>';
   }  
   else
   {
      return '<span><font style="color:green;">'+ val+'</font></span>';
   }
}   
function isDisponse(val)
{
   if(val=='true'|| val==true)
   {
     return '<span><font style="color:green;">已处理</font></span>';
   }  
   else if(val==false|| val=='false')
   {
      return '<span><font style="color:red;">未处理</font></span>';
   }
  
}

   Ext.Ajax.request(
    {
        url:'../../ashx/Application/GetDisposeBtn.ashx',
        method:'POST',
        params:
        {
        },
        disableCaching:false,
        success:function (result,request)
        {
            var json_data = Ext.util.JSON.decode(result.responseText);
            var tbBtn=  List_Grid.getTopToolbar() ;
            if(json_data.data==true)
            {

                  tbBtn.add(
                    { text:'处 理', iconCls:'ok-css',handler:okFunction},'-'
                  );
            } 

        

          
        },
        failure: function(form,action)
        {

        }
    });
var sm=new Ext.grid.RowSelectionModel({singleSelect:false});
var cm = new Ext.grid.ColumnModel(
    [   
         new Ext.grid.RowNumberer(),
        {header: "申请类型",sortable:true,dataIndex:'ATE_NAME',width:25},
        {header: "申请条目", sortable:true,dataIndex:'ADS_NAME',width:35,hidden:true},
        {header: "工 号", sortable:true,dataIndex:'USER_ID',width:20},
        {header: "姓 名",sortable:true,dataIndex:'USER_CNAME',width:20},
        {header: "班 别",sortable:true,dataIndex:'USER_SHIFT',width:20,hidden:true},
        {header: "部 门",sortable:true,dataIndex:'USER_DEPARTMENT',width:20,hidden:true},
        {header: "请假/加班类型",sortable:true,dataIndex:'LEE_OTE_NAME',width:35},
        {header: "日 期",sortable:true,dataIndex:'APP_DATE',width:35},
        {header: "开始时间",sortable:true,dataIndex:'APP_FROM_TIME',width:30},
        {header: "结束时间",sortable:true,dataIndex:'APP_TO_TIME',width:30},
        {header: "时 数",sortable:true,dataIndex:'APP_NUM_TIME',width:20},
        {header: "提交时间",sortable:true,dataIndex:'APP_CREATE_DT',width:30,renderer:dtColor},
        {header: "状 态",sortable:true,dataIndex:'APP_DISPOSED',width:30,renderer:isDisponse},
        expander
     ]);



var List_Grid=new Ext.grid.GridPanel(
{
    cm:cm,
    sm:sm,
    style:'margin:auto;',
    stripeRows: true,
    frame:true,
    store:ds,
    width:main_form_width,
    height:460,
    tbar: ['-',{text:'查 询',iconCls:'search-css',handler:ShowSearchDialog},'-',
           { text:'删 除', iconCls:'remove-css',handler:delFunction},'-'],
    viewConfig:{forceFit:true },
    loadMask: {msg:'正在装载数据...'},
    viewConfig:
       {
           forceFit:true 
       },
    bbar:['-',{
        text:'导出到 EXCEL 文件',
        iconCls:'excel-css',
        handler:function ()
        {
        Ext.MessageBox.confirm("温馨提示","是否导出已处理条目？",function(button,text)
        {  
            if(button=='yes')
            { 
              window.location.href="DownApplication.aspx?flag=true";
            }
            else
            {
               window.location.href="DownApplication.aspx?flag=false";
            }
        });
            
        }
     },'-'],
      plugins: expander,
   trackMouseOver:false
});

//=================================================================================
   var  txt_app_name=new Ext.form.TextField(
   {
        fieldLabel:'姓  名',
        name:'txt_app_name',
        id:'txt_app_name',
        anchor:'95%'
   });
   var  txt_app_type=new Ext.form.TextField(
   {
        fieldLabel:'工  号',
        name:'txt_app_type',
        id:'txt_app_type',
        anchor:'95%'
   });
    var txt_from_dt=new Ext.form.DateField(
    {
       id:'txt_from_dt',
       name:'txt_from_dt',
       fieldLabel:'开始日期',
       format:'Y-m-d',
       anchor:'95%'
    });
   var txt_to_dt=new Ext.form.DateField(
    {
       id:'txt_to_dt',
       name:'txt_to_dt',
       fieldLabel:'结束日期',
       format:'Y-m-d',
       anchor:'95%'
    });
 var is_disponse=new  Ext.form.Checkbox(
 {
   fieldLabel:'已处理',
   id:'is_disponse',
   name:'is_disponse',
   checked:false
  // style:'margin:0px 0px 10px 0px;'
 });
var SearchForm=new Ext.form.FormPanel(
    {
        id:'SearchForm',
        name:'SearchForm',
        labelWidth:80,
        style:'padding:20px,10px,20px,10px',
        labelAlgin:'right',
        autoHeight:true,
        buttonAlign:'center',
        frame:true,
        layout:'form',
        items: [txt_app_name,txt_app_type,txt_from_dt,txt_to_dt,is_disponse]
       
    });
function ShowSearchDialog()
	{
        var win;
        if(!win)
        {
            win = new Ext.Window(
            {
            buttonAlign:'center',
            title: '搜索查询',
            xtype:'window',
            closable:false,
            iconCls:'menu-formgrid-css',
            modal: 'true',
            closeAction:'hide',
            layout:'fit',
            plain: true,
            width:main_form_width*0.55,
            height:260,
            items:[SearchForm],
            buttons: 
            [{
                text: '查 询',
                id:'btn_search',
                handler:function()
                {
                    Ext.Ajax.request(
                    {
                            url: '../../ashx/Application/QueryApplication.ashx',
                            method: 'POST',
                            params:
                            {//
                                NAME_ID:txt_app_name.getValue(),
                                DT_FROM:isNull(txt_from_dt.getValue()) ? txt_from_dt.getValue().format('Y-m-d') : "",
                                DT_TO:isNull(txt_to_dt.getValue()) ? txt_to_dt.getValue().format('Y-m-d') : "",
                                USER_ID:txt_app_type.getValue(),
                                isdisponse:is_disponse.getValue() ? 1:0
                      
                            },
                            disableCaching:false,
                            success:function (result,request)
                            {
                                 ds.removeAll();
                                 var Search_data=Ext.util.JSON.decode(result.responseText).LIST;
                                 for(var i=0;i<Search_data.length;i++)
                                 {
                                    var p=new jsonRecord(
                                    {
                                        LEE_OTE_NAME:Search_data[i].LEE_OTE_NAME,
                                        LEE_OTE_CODE:Search_data[i].LEE_OTE_CODE,
                                        APP_ID:Search_data[i].APP_ID,
                                        APP_CAUSE:Search_data[i].APP_CAUSE,
                                        ATE_ID:Search_data[i].ATE_ID,
                                        ADS_CODE:Search_data[i].ADS_CODE,
                                        ADS_NAME:Search_data[i].ADS_NAME,
                                        APP_DATE:Search_data[i].APP_DATE,
                                        APP_FROM_TIME:Search_data[i].APP_FROM_TIME,
                                        APP_TO_TIME:Search_data[i].APP_TO_TIME,
                                        APP_NUM_TIME:Search_data[i].APP_NUM_TIME,
                                        USER_CNAME:Search_data[i].USER_CNAME,
                                        ATE_NAME:Search_data[i].ATE_NAME,
                                        USER_ID:Search_data[i].USER_ID,
                                        USER_DEPARTMENT:Search_data[i].USER_DEPARTMENT,
                                        USER_SHIFT:Search_data[i].USER_SHIFT,
                                        APP_CREATE_DT:Search_data[i].APP_CREATE_DT,
                                        APP_DISPOSED:Search_data[i].APP_DISPOSED
                                    });
                                    ds.insert(0,p);
                                 }
                                 win.hide();
                            },
                            failure: function()
                            {
                                Ext.MessageBox.hide();
                                Ext.MessageBox.show(
                                {
                                    title:'系统消息',
                                    msg:'查询失败！',
                                    buttons:Ext.Msg.OK,
                                    icon:Ext.MessageBox.ERROR
                                });
                            }
                   });
                },//handler
                scope:this
             },
             {
                    text: ' 重 置 ',
                    handler:function()
                    {
                       SearchForm.getForm().reset();
                    }
             },
             {
                    text: ' 关 闭 ',
                    handler:function()
                    {
                        win.hide();
                    },
                    scope: this
            }]//end  button
      });//end win
    }
    win.show(this);
  }
  //===========================================================
List_Grid.render(document.body); 
function delFunction()
{
   var delArray=new Array();
   var idList=new Array();
    delArray=List_Grid.getSelectionModel().getSelections();
    for(var i=0;i<delArray.length;i++)
    {
         idList.push(delArray[i].get('APP_ID'));
    }
   if(idList.length>0)
   {
        Ext.MessageBox.confirm("温馨提示","删除将不能回撤，确认吗？",function(button,text)
        {  
            if(button=='yes')
            {  
                Ext.Ajax.request(
                {
                        url: '../../ashx/Application/DelApplicationByAPP_ID.ashx',
                        method: 'POST',
                        params:
                        {
                            IDList:idList.toString()
                        },
                        disableCaching:false,
                        success:function (result,request)
                        {
                             var jsonMsg=Ext.util.JSON.decode(result.responseText);
                             
                             Ext.MessageBox.hide();
                             Ext.MessageBox.show(
                             {
                                title:'系统消息',
                                msg:jsonMsg.data,
                                buttons:Ext.Msg.OK,
                                icon:Ext.MessageBox.INFO
                             });   
                             for(var i=0;i<ds.getCount();i++)
                             {
                               for(var j=0;j<delArray.length;j++)
                               {
                                 if(ds.getAt(i).get('APP_ID')==delArray[j].get('APP_ID'))
                                 {
                                     ds.remove(delArray[j]);
                                 }
                               }

                             }
                        },
                        failure: function()
                        {
                                Ext.MessageBox.hide();
                                Ext.MessageBox.show(
                                {
                                    title:'系统消息',
                                    msg:'删除失败，可能是断开了服务器连接！',
                                    buttons:Ext.Msg.OK,
                                    icon:Ext.MessageBox.ERROR
                                });
                        }
                });
            }
      });//end confirm
  }//end if(row)
   
}
 //=================================================
 function okFunction()
{
   var okArray=new Array();
   var idList=new Array();
    okArray=List_Grid.getSelectionModel().getSelections();
    for(var i=0;i<okArray.length;i++)
    {
         idList.push(okArray[i].get('APP_ID'));
    }
   if(idList.length>0)
   {
        Ext.MessageBox.confirm("温馨提示","确定吗？",function(button,text)
        {  
            if(button=='yes')
            {  
                Ext.Ajax.request(
                {
                        url: '../../ashx/Application/DisposeApplication.ashx',
                        method: 'POST',
                        params:
                        {
                            IDList:idList.toString()
                        },
                        disableCaching:false,
                        success:function (result,request)
                        {
                        
                             var jsonMsg=Ext.util.JSON.decode(result.responseText);
                             
                             Ext.MessageBox.hide();
                             Ext.MessageBox.show(
                             {
                                title:'系统消息',
                                msg:jsonMsg.data,
                                buttons:Ext.Msg.OK,
                                icon:Ext.MessageBox.INFO
                             });  
                             ds.reload(); 
                        },
                        failure: function()
                        {
                                Ext.MessageBox.hide();
                                Ext.MessageBox.show(
                                {
                                    title:'系统消息',
                                    msg:'删除失败，可能是断开了服务器连接！',
                                    buttons:Ext.Msg.OK,
                                    icon:Ext.MessageBox.ERROR
                                });
                        }
                });
            }
      });//end confirm
  }//end if(row)
   
} 
function isNull(str)
{
   if(str==null|| str==""|| str=='undefined')
   {
       return false;
   }
   else
   {
      return true;
   }
}
});