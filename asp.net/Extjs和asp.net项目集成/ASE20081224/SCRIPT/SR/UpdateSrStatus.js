// JScript 文件

// JScript 文件

Ext.onReady(function(){
    Ext.QuickTips.init();
    var form = new Ext.form.BasicForm('form1'); 
    Ext.form.Field.prototype.msgTarget = 'side';
    var screen_width=960;
    var main_form_width=960;
    var Search_data;
    var sr_code="";
    Ext.Ajax.request(
    {
        url: '../../ashx/Type/ResInitSvt.ashx',
        method: 'POST',
        params:
        {
           IDstr:'18'
        },
        disableCaching:false,
        success:function (result,request)
        {
            sts_data=Ext.util.JSON.decode(result.responseText).STS_TYPE;
            sts_ds.loadData(sts_data);
        },
        failure: function()
        {
        }
    });
   var sts_ds=new Ext.data.JsonStore(
   {
        fields:[
            {name:'ID',type:'string'},
            {name:'NAME',type:'string'}
        ]
   });  
     var Sr_Record = Ext.data.Record.create(
     [
     
        {name: 'SR_ID', type: 'string'},
        {name: 'STS_ID', type: 'string'}
     ]);
   var ds=new Ext.data.GroupingStore({
        proxy: new Ext.data.HttpProxy({
            url:'../../ashx/SR/GetSrStatusByUSER_ID.ashx'
        }),
        reader:new Ext.data.JsonReader({
            root: 'LIST'
        },
        [
            {name: 'SR_ID', type: 'int'},
            {name: 'SR_CODE', type: 'string'},
            {name: 'SR_TITLE', type: 'string'},
            {name: 'SR_PROPOSER', type: 'string'},
            {name: 'SR_SR_FLAG', type: 'string'},
            
            {name: 'SR_AR_FLAG', type: 'string'},
            {name: 'SR_PRO_FLAG', type: 'string'},
            {name: 'SR_CREATIONUID', type: 'string'},
            {name: 'SR_CREATE_DT', type: 'string'},           
            {name: 'SR_UPDATEUID', type: 'string'},
            
            {name: 'SR_UPDATE_DT', type: 'string'},
            {name: 'STS_NAME', type: 'string'},
            {name: 'LSS_VALUES', type: 'string'}
            
       ])
   }); 
  ds.load();

function dtColor(val)
{
      return '<span><font style="color:green;">'+ val+'</font></span>';
}   
 function typeShow(value,p,record)
 {
   if(record.get('SR_PRO_FLAG')=="true")
   {
     return '<span>Project</span>';
   }
   else if(record.get('SR_SR_FLAG')=="true")
   {
     return '<span> SR</span>';
   }
   else if(record.get('SR_AR_FLAG')=="true")
   {
     return '<span> AR</span>';
   }

 } 


var sm=new Ext.grid.RowSelectionModel({singleSelect:true});
var cm = new Ext.grid.ColumnModel(
    [   
         new Ext.grid.RowNumberer(),
        {header: "编   码",sortable:true,dataIndex:'SR_CODE',width:50},
        {header: "SR标题", sortable:true,dataIndex:'SR_TITLE',width:120},
        {header: "申请人", sortable:true,dataIndex:'SR_PROPOSER',width:50},
        {header: "类   型", sortable:true,dataIndex:'TYPE',width:50,renderer:typeShow},
        {header: "状   态", sortable:true,dataIndex:'STS_NAME',width:60,
        editor:new Ext.form.ComboBox(
        {
           id:'cmb_status',
           name:'cmb_status',
           displayField:'NAME',
           valueField:'NAME',
           readOnly:false,
           hiddenName:'cmb_status_no',
           mode:'local',
           store:sts_ds,
           triggerAction:'all',
           selectOnFocus:true,
           anchor:'100%'  ,
           listeners:
           {
                change:
                {
                    fn:function(combo, newV,oldV)
                    { 
                         var row=List_Grid.getSelectionModel().getSelected();
                         if(row)
                         {
                           row.set('LSS_VALUES',sts_ds.getAt(sts_ds.find('NAME',newV)).get('ID'));
                         }
                    }
                }
           }       
        })},
        {header: "VALUE",sortable:true,dataIndex:'LSS_VALUES',hidden:true},
        {header: "创建日期",sortable:true,dataIndex:'SR_CREATE_DT',width:60,renderer:dtColor},
        {header: "创建人",sortable:true,dataIndex:'SR_CREATIONUID',width:30},
        {header: "更新日期",sortable:true,dataIndex:'SR_UPDATE_DT',width:60,renderer:dtColor},
        {header: "更新人",sortable:true,dataIndex:'SR_UPDATEUID',width:30}
        
     ]);
var List_Grid=new Ext.grid.EditorGridPanel(
{
    cm:cm,
    sm:sm,
    style:'margin:auto;',
    stripeRows: true,
    frame:true,
    store:ds,
    width:main_form_width,
    height:460,
   // tbar: ['-',{text:'分 配',iconCls:'check-css',handler:ShowSearchDialog},'-'],
           
    viewConfig:{forceFit:true },
    loadMask: {msg:'正在装载数据...'},
    viewConfig:
       {
           forceFit:true 
       },
   trackMouseOver:false
});
    var mainForm=new Ext.form.FormPanel(
    {
        width:main_form_width,
        height:450,
        style:'margin:auto; ',
        frame:true,
        buttonAlign:'center',
        layout:'fit',
        items: [List_Grid],
        buttons:[
        {
            text: ' 确 定 ',
            id:'btn_comfire',
            iconCls:'ok-css',
            handler:comfirmFun
       }]
   });
   
   function comfirmFun()
   {
         Ext.MessageBox.show(
         {
            msg:'正在保存数据,请稍候...',
            progressText:'正在保存...',
            width:300,
            wait:true,
            waitConfig:{interval:200}
        });
        var lst=new Array();
        
        for(var i=0;i<ds.getCount();i++)
        {
            if(isNoNull(ds.getAt(i).get('LSS_VALUES'))==false)
            {
                 continue;
            }
            var p=new Sr_Record(
            {
                SR_ID:ds.getAt(i).get('SR_ID'),
                STS_ID:ds.getAt(i).get('LSS_VALUES')
            });
           lst.push(p);
        }
        if(isNoNull(lst)==false)
        {
             return ;
        }

        Ext.Ajax.request(
        {
            url:'../../ashx/SR/UpdateSrStatus.ashx',
            method: 'POST',
            params:
            {
                data:Ext.util.JSON.encode(lst)
            },
            disableCaching:false,
            success:function (result,request)
            {   
                      var json_msg=Ext.util.JSON.decode(result.responseText);
                        Ext.MessageBox.hide();
                        Ext.MessageBox.show({
                            title:'系统消息',
                            msg:json_msg.data,
                            buttons:Ext.Msg.OK,
                            icon:Ext.MessageBox.INFO
                        });    
            },
            failure: function()
            {
                        Ext.MessageBox.hide();
                        Ext.MessageBox.show({
                            title:'系统消息',
                            msg:'提交失败！',
                            buttons:Ext.Msg.OK,
                            icon:Ext.MessageBox.ERROR
                        });
            }
        });

    }

 
mainForm.render(document.body); 

 
function isNoNull(str)
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