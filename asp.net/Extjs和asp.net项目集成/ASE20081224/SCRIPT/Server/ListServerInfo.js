// JScript 文件

Ext.onReady(function(){
    Ext.QuickTips.init();
    var form = new Ext.form.BasicForm('form1'); 
    Ext.form.Field.prototype.msgTarget = 'side';
    //*************相关宽度设置********************BEGIN
    var screen_width=960;
    var main_form_width=960;
    var Search_data;
    //var tb=new  Ext.Toolbar({text:'查 询',iconCls:'search-css', handler:ShowSearchDialog });;
   // var List_Grid;
    //*************相关宽度设置********************END
   function GetQueryString(name)
	{
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)","i");
        var r = window.location.search.substr(1).match(reg);
        if (r!=null) return unescape(r[2]); return null;
    }
    var cpu_ds,mey_ds ,aty_ds, os_ds,smo_ds, had_ds;
   Ext.Ajax.request(
    {
        url: '../../ashx/Type/ResInitSvt.ashx',
        method: 'POST',
        params:
        {
           IDstr:'1,2,3,4,5,6,7,8'
        },
        disableCaching:false,
        success:function (result,request)
        {

          var  cpu_data=Ext.util.JSON.decode(result.responseText).CPU_TYPE;
          var   mey_data=Ext.util.JSON.decode(result.responseText).MEY_TYPE;
          var   aty_data=Ext.util.JSON.decode(result.responseText).ATY_TYPE;
          var  os_data=Ext.util.JSON.decode(result.responseText).OS_TYPE;
          var   smo_data=Ext.util.JSON.decode(result.responseText).SMO_TYPE;
          var   had_data=Ext.util.JSON.decode(result.responseText).HAD_TYPE;
          var    str_data=Ext.util.JSON.decode(result.responseText).STR_TYPE;
          var    team_data=Ext.util.JSON.decode(result.responseText).TEP_TYPE;
            
            cpu_ds.loadData(cpu_data);
            mey_ds.loadData(mey_data);
            aty_ds.loadData(aty_data);
            os_ds.loadData(os_data);
            smo_ds.loadData(smo_data);
            had_ds.loadData(had_data);
            str_ds.loadData(str_data);
            team_ds.loadData(team_data);
          //  getToolbar();
         
            
        },
        failure: function()
        {
        }
    });
   var str_ds=new Ext.data.JsonStore(
   {
        fields:[
            {name:'ID',type:'string'},
            {name:'NAME',type:'string'}
        ]
   });  
   var team_ds=new Ext.data.JsonStore(
   {
        fields:[
            {name:'ID',type:'string'},
            {name:'NAME',type:'string'}
        ]
   });
    cpu_ds=new Ext.data.JsonStore(
   {
        fields:[
            {name:'ID',type:'string'},
            {name:'NAME',type:'string'}
        ]
   });
    mey_ds=new Ext.data.JsonStore(
   {
        fields:[
            {name:'ID',type:'string'},
            {name:'NAME',type:'string'}
        ]
   });   
    aty_ds=new Ext.data.JsonStore(
   {
        fields:[
            {name:'ID',type:'string'},
            {name:'NAME',type:'string'}
        ]
   });  
     os_ds=new Ext.data.JsonStore(
   {
        fields:[
            {name:'ID',type:'string'},
            {name:'NAME',type:'string'}
        ]
   });   
    smo_ds=new Ext.data.JsonStore(
   {
        fields:[
            {name:'ID',type:'string'},
            {name:'NAME',type:'string'}
        ]
   });  
     had_ds=new Ext.data.JsonStore(
   {
        fields:[
            {name:'ID',type:'string'},
            {name:'NAME',type:'string'}
        ]
   });
   var expander = new Ext.grid.RowExpander({
        tpl : new Ext.Template(
             '<br>',
            '<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>PO NO.：</b> {SER_PO_NO} &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Storage：</b>{STR_NAME}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<B> Arrive Date：</B>{SER_COME_DT}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b> Owner：</b> {SER_OWNER}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>IT Team：</b>{TEP_NAME}</p><br>',
           '<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>AP List：</b>{SER_AP_LIST}</p>'
        )
    });
   var jsonRecord = Ext.data.Record.create(
   [
            {name:'SVS_NAME',type:'string'},
            {name:'SVS_ID',type:'int'},
            {name:'SVS_SHORTDESC',type:'string'},
            {name:'SVS_IPADDRESS',type:'string'},
            {name:'SMO_NAME',type:'string'},
            {name:'ATY_NAME',type:'string'},
            {name:'CPU_NAME',type:'string'},
            {name:'MEY_NAME',type:'string'},
            {name:'HAD_NAME',type:'string'},
            {name:'OS_NAME',type:'string'},
            {name:'SVS_SN',type:'string'},
            
            {name:'SER_COME_DT',type:'string'},
            {name:'SER_PO_NO',type:'string'},
            {name:'TEP_NAME',type:'string'},
            {name:'STR_NAME',type:'string'},
            {name:'SER_AP_LIST',type:'string'},
            {name:'SER_OWNER',type:'string'}

   ]);
   var List_ds=new Ext.data.GroupingStore({
        proxy: new Ext.data.HttpProxy({
            url:'../../ashx/Server/ListServer.ashx'
        }),
        reader:new Ext.data.JsonReader({
            root: 'LIST',
            id: 'SVS_ID',
            totalProperty: 'TOTALCOUNT'//总纪录数量
        },
       [
            {name:'SVS_NAME',type:'string'},
            {name:'SVS_ID',type:'int'},
            {name:'SVS_SHORTDESC',type:'string'},
            {name:'SVS_IPADDRESS',type:'string'},
            {name:'SMO_NAME',type:'string'},
            {name:'ATY_NAME',type:'string'},
            {name:'CPU_NAME',type:'string'},
            {name:'MEY_NAME',type:'string'},
            {name:'HAD_NAME',type:'string'},
            {name:'OS_NAME',type:'string'},
            {name:'SVS_SN',type:'string'},
     //,SER_OWNER ,SER_COME_DT , SER_PO_NO,TEP_NAME ,STR_NAME ,SER_AP_LIST       
            {name:'SER_COME_DT',type:'string'},
            {name:'SER_PO_NO',type:'string'},
            {name:'TEP_NAME',type:'string'},
            {name:'STR_NAME',type:'string'},
            {name:'SER_AP_LIST',type:'string'},
            {name:'SER_OWNER',type:'string'}
       ])
   }); 
  List_ds.load(
  {
        params:
        {
            start:0,
            limit:20
        }
 });

var sm=new Ext.grid.RowSelectionModel({singleSelect:false});
   var cm=new Ext.grid.ColumnModel([
          new Ext.grid.RowNumberer(),
          
            {header:'Server Name',dataIndex:'SVS_NAME',sortable:true},
            {header:'Function Description',dataIndex:'SVS_SHORTDESC',sortable:true},
            {header:'IP Address',dataIndex:'SVS_IPADDRESS',sortable:true},
            {header:'Model',dataIndex:'SMO_NAME',sortable:true},
            {header:'CPU',dataIndex:'CPU_NAME',sortable:true},
            {header:'Memory',dataIndex:'MEY_NAME',sortable:true},
            {header:'Hard Disk',dataIndex:'HAD_NAME',sortable:true},
            {header:'Array Type',dataIndex:'ATY_NAME',sortable:true},
            {header:'OS',dataIndex:'OS_NAME',sortable:true},
            {header:'SN',dataIndex:'SVS_SN',sortable:true},
            expander
    ]);

   Ext.Ajax.request(
    {
        url:'../../ashx/Server/GetMainMenu.ashx',
        method:'POST',
        params:
        {
           USER:GetQueryString('user')
        },
        disableCaching:false,
        success:function (result,request)
        {
            var json_data = Ext.util.JSON.decode(result.responseText);
            var tbBtn=  List_Grid.getTopToolbar() ;
            if(json_data.POP_LIST_DEL==true)
            {
                  tbBtn.add(
                    { text:'删 除', iconCls:'remove-css',  handler:DelSearchDialog },'-'
                  );
            } 
            if(json_data.POP_LIST_MODIFY==true)
            {
                         tbBtn.add(
                                  { text:'修 改', iconCls:'modify-css',handler:ModifySearchDialog },'-'
                            );
            }
          
        },
        failure: function(form,action)
        {
             Ext.MessageBox.hide();
             Ext.MessageBox.show({
             title:'错误',
             msg: '工具栏初始化失败！',
             buttons: Ext.Msg.OK,
             icon: Ext.MessageBox.ERROR});
        }
    });

 var List_Grid=new Ext.grid.GridPanel(
{
    cm:cm,
    sm:sm,
    style:'margin:auto;',
    stripeRows: true,
    frame:true,
    tbar:
    [{
        text:'查 询',
        iconCls:'search-css',
        handler:ShowSearchDialog
   }],
     plugins: expander,
    store:List_ds,
    width:main_form_width,
    height:540,
    viewConfig:{forceFit:true },
    loadMask: {msg:'正在装载数据...'},
    viewConfig:
       {
           forceFit:true 
       },
   bbar: new Ext.PagingToolbar(
        {
            id:'SVS_ID',
            pageSize:20,
            store: List_ds,
            displayInfo: true,
            displayMsg:'显示第 {0} 条到 {1} 条记录，一共 {2} 条',
            emptyMsg:"没有记录"
        }),
          trackMouseOver:false
});
List_Grid.render(document.body); 
   var txt_server_name=new Ext.form.TextField(
   {
        fieldLabel:'服务器名',
        name:'txt_server_name',
        id:'txt_server_name',
        anchor:'95%'
   });
   var  txt_sn_name=new Ext.form.TextField(
   {
        fieldLabel:'系列号',
        name:'txt_sn_name',
        id:'txt_sn_name',
        anchor:'95%'
   });
   var txt_server_spec=new Ext.form.TextField(
   {
        fieldLabel:'描  述',
        name:'txt_server_spec',            
        id:'txt_server_spec',
        anchor:'95%'
   });
   var  txt_ip_address=new Ext.form.TextField(
   {
        fieldLabel:'IP',
        name:'txt_ip_address',       
        id:'txt_ip_address',
        anchor:'95%'
   });
var  txt_aty_type=new Ext.form.TextField(
{
    fieldLabel:'',
    name:'txt_aty_type',       
    id:'txt_aty_type',
    anchor:'100%'
});

 var txt_had_type=new Ext.form.TextField(
{
    fieldLabel:'',
    name:'txt_had_type',       
    id:'txt_had_type',
    anchor:'100%'
});

 var txt_mey_type=new Ext.form.TextField(
{
    fieldLabel:'',
    name:'txt_mey_type',       
    id:'txt_mey_type',
    anchor:'100%'
});
 var txt_cpu_type=new Ext.form.TextField(
{
    fieldLabel:'',
    name:'txt_cpu_type',       
    id:'txt_cpu_type',
    anchor:'100%'
});

 var txt_os_type=new Ext.form.TextField(
{
    fieldLabel:'',
    name:'txt_os_type',       
    id:'txt_os_type',
    anchor:'100%'
});

  var txt_smo_type=new Ext.form.TextField(
{
    fieldLabel:'',
    name:'txt_smo_type',       
    id:'txt_smo_type',
    anchor:'100%'
});
   var cmb_smo_type=new Ext.form.ComboBox(
    {
        fieldLabel:'型  号',
        name:'cmb_smo_type',
        id:'cmb_smo_type',
        hiddenName:'cmb_smo_type_no',
        mode:'local',
        triggerAction:'all',
        store:smo_ds,
        emptyText:'--请选择--',
        editable:false,
        selectOnFocus:true,
        displayField:'NAME',
        valueField:'ID',
        valueNotFoundText:'--请选择--',
        anchor:'95%'
    });
    var cmb_os_type=new Ext.form.ComboBox(
    {
        fieldLabel:'操作系统',
        name:'cmb_os_type',
        id:'cmb_os_type',
        hiddenName:'cmb_os_type_no',
        mode:'local',
        triggerAction:'all',
        store:os_ds,
        emptyText:'--请选择--',
        editable:false,
        selectOnFocus:true,
        displayField:'NAME',
        valueField:'ID',
      //  readOnly:true,
        valueNotFoundText:'--请选择--',
        anchor:'95%'
    });
        var cmb_cpu_type=new Ext.form.ComboBox(
    {
        fieldLabel:'CPU',
        name:'cmb_cpu_type',
        id:'cmb_cpu_type',
        hiddenName:'cmb_cpu_type_no',
        mode:'local',
        triggerAction:'all',
        store:cpu_ds,
        editable:false,
        emptyText:'--请选择--',
        selectOnFocus:true,
        displayField:'NAME',
        valueField:'ID',
        valueNotFoundText:'--请选择--',
        anchor:'95%'
    });
     var cmb_mey_type=new Ext.form.ComboBox(
    {
        fieldLabel:'内  存',
        name:'cmb_mey_type',
        id:'cmb_mey_type',
        hiddenName:'cmb_mey_type_no',
        mode:'local',
        triggerAction:'all',
        store:mey_ds,
        editable:false,
        emptyText:'--请选择--',
        selectOnFocus:true,
        displayField:'NAME',
        valueField:'ID',
        valueNotFoundText:'--请选择--',
        anchor:'95%'
    });//
    var cmb_had_type=new Ext.form.ComboBox(
    {
        fieldLabel:'硬  盘',
        name:'cmb_had_type',
        id:'cmb_had_type',
        hiddenName:'cmb_had_type_no',
        mode:'local',
        triggerAction:'all',
        store:had_ds,
        emptyText:'--请选择--',
        editable:false,
        selectOnFocus:true,
        displayField:'NAME',
        valueField:'ID',
        valueNotFoundText:'--请选择--',
        anchor:'95%'
    });
    var cmb_aty_type=new Ext.form.ComboBox(
    {
        fieldLabel:'磁盘阵列',
        name:'cmb_aty_type',
        id:'cmb_aty_type',
        hiddenName:'cmb_aty_type_no',
        mode:'local',
        triggerAction:'all',
        editable:false,
        store:aty_ds,
        emptyText:'--请选择--',
        selectOnFocus:true,
        displayField:'NAME',
        valueField:'ID',
        valueNotFoundText:'--请选择--',
        anchor:'95%'
    });
    var cmb_team_type=new Ext.form.ComboBox(
    {
        fieldLabel:'IT Item',
        name:'cmb_team_type',
        id:'cmb_team_type',
        hiddenName:'cmb_team_type_no',
        mode:'local',
        triggerAction:'all',
        store:team_ds,
  
        emptyText:'--请选择--',
        selectOnFocus:true,
        displayField:'NAME',
        valueField:'ID',
        valueNotFoundText:'--请选择--',
        anchor:'95%'
    });
    var cmb_str_type=new Ext.form.ComboBox(
    {
        fieldLabel:'Storage',
        name:'cmb_str_type',
        id:'cmb_str_type',
        hiddenName:'cmb_str_type_no',
        mode:'local',
        triggerAction:'all',
        store:str_ds,
        emptyText:'--请选择--',
        selectOnFocus:true,
        displayField:'NAME',
        valueField:'ID',
        valueNotFoundText:'--请选择--',
        anchor:'95%'
    });
    var txt_owner=new Ext.form.TextField(
    {
       id:'txt_owner',
       name:'txt_owner',
       fieldLabel:'Owner',
       anchor:'95%'
    });
    var txt_comefrom_dt=new Ext.form.DateField(
    {
       id:'txt_comefrom_dt',
       name:'txt_comefrom_dt',
       fieldLabel:'Arrive Date from',
       value:new Date(),
       format:'Y-m-d',
       anchor:'95%'
    });
    var txt_cometo_dt=new Ext.form.DateField(
    {
       id:'txt_cometo_dt',
       name:'txt_cometo_dt',
       fieldLabel:'to',
       value:new Date(),
       format:'Y-m-d',
       anchor:'95%'
    });
    var txt_po_no=new Ext.form.TextField(
    {
       id:'txt_po_no',
       name:'txt_po_no',
       fieldLabel:'PO NO.',
        anchor:'95%'
    });
        var Searchset=new Ext.form.FieldSet(
    {
        xtype:'fieldset',
        id:'Searchset',
        name:'Searchset',
        collapsed: false,
        labelWidth:80,
        autoHeight:true,
        checkboxToggle:true,
        frame:false,
        buttonAlign:'right',
        layout:'form',
        items:[ {
                    layout:'column',
                    items:
                    [{
                       layout:'form',
                       columnWidth:.5, 
                       items: [txt_server_name, txt_sn_name,txt_ip_address,txt_server_spec,cmb_smo_type]
                    },
                    {
                          layout:'form',
                          columnWidth:.5,
                          items:[cmb_cpu_type,cmb_mey_type, cmb_had_type,cmb_os_type,cmb_aty_type]
                    }]
       }]
    });
    var OtherSearch=new Ext.form.FieldSet(
    {
        xtype:'fieldset',
        id:'OtherSearch',
        name:'OtherSearch',
        collapsed: false,
        labelWidth:80,
        autoHeight:true,
        checkboxToggle:true,
        frame:false,
        buttonAlign:'right',
        layout:'form',
        items:[ 
        {
                 layout:'column',items:[
                 {
                        layout:'form',
                        columnWidth:.5,
                        items:[ txt_owner,txt_po_no,txt_comefrom_dt]
                  },
                  {
                       layout:'form',
                        columnWidth:.5,
                        items:[cmb_str_type,cmb_team_type,txt_cometo_dt]
                  }]
      }]
   });
     var SearchForm=new Ext.form.FormPanel(
    {
        id:'SearchForm',
        name:'SearchForm',
        labelWidth:80,
        labelAlgin:'right',
        autoHeight:true,
        buttonAlign:'center',
        frame:true,
        layout:'form',
        items: [
        Searchset,{layout:'fit',items:[OtherSearch]}]
       
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
            width:main_form_width*0.7,
            height:400,
            items:[SearchForm],
            buttons: 
            [{
                text: '查询',
                id:'btn_search',
                handler:function()
                {
                    Ext.Ajax.request(
                    {
                            url: '../../ashx/Server/QueryServerList.ashx',
                            method: 'POST',
                            params:
                            {
                                SVS_NAME:txt_server_name.getValue(),
                                SVS_IPADDRESS:txt_ip_address.getValue(),
                                SVS_SHORTDESC:txt_server_spec.getValue(),
                                SVS_SN:txt_sn_name.getValue(),
                                SMO_ID:cmb_smo_type.getValue(),
                                CPU_ID:cmb_cpu_type.getValue(),
                                MEY_ID:cmb_mey_type.getValue(),
                                HAD_ID:cmb_had_type.getValue(),
                                ATY_ID:cmb_aty_type.getValue(),
                                OS_ID:cmb_os_type.getValue(),
                                
                                DT_FROM:isNull(txt_comefrom_dt.getValue()) ? txt_comefrom_dt.getValue().format('Y-m-d') : "",
                                DT_TO:isNull(txt_cometo_dt.getValue()) ?txt_cometo_dt.getValue().format('Y-m-d')  : "",
                                OWNER:txt_owner.getValue(),
                                PO_NO:txt_po_no.getValue(),
                                STR_ID:cmb_str_type.getValue(),
                                TEP_ID:cmb_team_type.getValue(),
                                start:0,
                                limit:20
                      
                            },
                            disableCaching:false,
                            success:function (result,request)
                            {
                                 List_ds.removeAll();
                                  Search_data=Ext.util.JSON.decode(result.responseText).LIST;
                                 for(var i=0;i<Search_data.length;i++)
                                 {
                                    var p=new jsonRecord(
                                    {
                                        SVS_NAME:Search_data[i].SVS_NAME,
                                        SVS_ID:Search_data[i].SVS_ID,
                                        SVS_SHORTDESC:Search_data[i].SVS_SHORTDESC,
                                        SVS_IPADDRESS:Search_data[i].SVS_IPADDRESS,
                                        SMO_NAME:Search_data[i].SMO_NAME,
                                        ATY_NAME:Search_data[i].ATY_NAME,
                                        CPU_NAME:Search_data[i].CPU_NAME,
                                        MEY_NAME:Search_data[i].MEY_NAME,
                                        HAD_NAME:Search_data[i].HAD_NAME,
                                        OS_NAME:Search_data[i].OS_NAME,
                                        SVS_SN:Search_data[i].SVS_SN,
                                        
                                        SER_COME_DT:Search_data[i].SER_COME_DT,
                                        SER_OWNER:Search_data[i].SER_OWNER,
                                        SER_PO_NO:Search_data[i].SER_PO_NO,
                                        TEP_NAME:Search_data[i].TEP_NAME,
                                        STR_NAME:Search_data[i].STR_NAME,
                                        SER_AP_LIST:Search_data[i].SER_AP_LIST
                                        
                                        

                                    });
                                    List_ds.insert(0,p);
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
   function ModifySearchDialog()
   {
        var row=List_Grid.getSelectionModel().getSelected();
        if(row)
        {
            window.open('ModifyServerList.aspx?SVS_ID='+row.get('SVS_ID'),"_blank");
        }
   }

function DelSearchDialog()
{
   var delArray=new Array();
   var idList=new Array();
    delArray=List_Grid.getSelectionModel().getSelections();
    for(var i=0;i<delArray.length;i++)
    {
         idList.push(delArray[i].get('SVS_ID'));
    }
   if(idList.length>0)
   {
        Ext.MessageBox.confirm("温馨提示","删除将不能回撤，确认吗？",function(button,text)
        {  
            if(button=='yes')
            {  
                Ext.Ajax.request(
                {
                        url: '../../ashx/Server/DelServerListBySVS_ID.ashx',
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
                             for(var i=0;i<List_ds.getCount();i++)
                             {
                               for(var j=0;j<delArray.length;j++)
                               {
                                 if(List_ds.getAt(i).get('SVS_ID')==delArray[j].get('SVS_ID'))
                                 {
                                     List_ds.remove(delArray[j]);
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