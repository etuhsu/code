   Ext.onReady(function(){
       Ext.QuickTips.init();
    var form=new Ext.form.BasicForm('form1');
    Ext.form.Field.prototype.msgTarget = 'side';
    var main_form_width=960;
    var main_form_height=500;
    var lee_data, ote_data ,ate_data ,ads_data;
    function formatDate(value){
        return value ? value.dateFormat('Y-m-d') : '';
    };
    String.prototype.trim = function()
    {
        return this.replace(/(^\s*)|(\s*$)/g, "");
    }
    var isFirstMsg1=0;
    var isFirstMsg2=0;
    Ext.Ajax.request(
    {
        url: '../../ashx/Type/ResInitSvt.ashx',
        method: 'POST',
        params:
        {
           IDstr:'9,10,11,12'
        },
        disableCaching:false,
        success:function (result,request)
        {

              lee_data=Ext.util.JSON.decode(result.responseText).LEE_TYPE;
              ote_data=Ext.util.JSON.decode(result.responseText).OTE_TYPE;
              ate_data=Ext.util.JSON.decode(result.responseText).ATE_TYPE;
              ads_data=Ext.util.JSON.decode(result.responseText).ADS_TYPE;


            
            type_ds.loadData(lee_data);
            ate_ds.loadData(ate_data);
            
            
        },
        failure: function()
        {
        }
    });
   var user_ds=new Ext.data.JsonStore(
   {
        fields:[
        {name: 'USER_CNAME', type: 'string'},
        {name: 'USER_NAME', type: 'int'},
        {name: 'USER_ID', type: 'int'},
        {name: 'USER_DEPARTMENT', type: 'int'},
        {name: 'USER_SHIFT', type: 'string'}
        ]
   });


     var App_Record = Ext.data.Record.create(
     [
     
        {name: 'APP_CAUSE', type: 'string'},
        {name: 'APP_ATE_ID', type: 'int'},
        {name: 'APP_ADS_ID', type: 'int'},
        {name: 'APP_TYPE', type: 'string'},
      //  {name: 'APP_USER_ID', type: 'int'},
        {name: 'APP_DATE', type: 'string'},
        {name: 'APP_FROM_TIME', type: 'string'},           
        {name: 'APP_TO_TIME', type: 'string'},
        {name: 'APP_NUM_TIME', type: 'string'},
        {name:'APPTYPE',type:'string'},
        {name: 'USER_CNAME', type: 'string'},
        {name: 'USER_NAME', type: 'string'},
        {name: 'USER_ID', type: 'string'},
        {name: 'USER_DEPARTMENT', type: 'string'},
        {name: 'USER_SHIFT', type: 'string'}
     ]);
   var ate_ds=new Ext.data.JsonStore(
   {
        fields:[
            {name:'ID',type:'string'},
            {name:'NAME',type:'string'},
            {name:'LEVEL',type:'string'}
        ]
   });  
   var ads_ds=new Ext.data.JsonStore(
   {
        fields:[
            {name:'ID',type:'string'},
            {name:'NAME',type:'string'},
            {name:'LEVEL',type:'string'}
        ]
   });  
   var type_ds=new Ext.data.JsonStore(
   {
        fields:[
            {name:'ID',type:'string'},
            {name:'NAME',type:'string'}
        ]
   });  

   
    var app_ds = new Ext.data.Store({
        url: 'plants.xml',
        reader: new Ext.data.XmlReader({
               record: 'App_Record'
           }, App_Record),

        sortInfo:{field:'', direction:'ASC'}
    });
 var sm=new Ext.grid.RowSelectionModel(
 {  
    singleSelect:true,
    listeners:
    {
      selectionchange:function(txt)
      {
         var row=app_grid.getSelectionModel().getSelected();
         if(row)
         {
             if(row.get('APP_ATE_ID')=="漏刷卡")
             {
                type_ds.removeAll();
                ads_ds.loadData(GetList("003",ads_data));
             }
             else if(row.get('APP_ATE_ID')=="请假")
             {
                  type_ds.removeAll();
                  ads_ds.removeAll();
                  type_ds.loadData(lee_data);
             }
             else if(row.get('APP_ATE_ID')=="加班")
             {
                type_ds.removeAll();
                type_ds.loadData(ote_data);
                ads_ds.loadData(GetList("002",ads_data));
               
             }
         }
      }
    }
 });
 var cm = new Ext.grid.ColumnModel(
    [  
        {header: "申请类型",sortable:true,dataIndex:'APP_ATE_ID',width:25,
        editor:new Ext.form.ComboBox(
        {
           id:'cmb_ate_type',
           name:'cmb_ate_type',
           displayField:'NAME',
           valueField:'NAME',
           readOnly:false,
           hiddenName:'cmb_ate_type_no',
           mode:'local',
           store:ate_ds,
           triggerAction:'all',
           selectOnFocus:true,
           anchor:'100%',
            listeners:
            {
                select : 
                {
                    fn:function(combo, record,index)
                    {  
                        var row=app_grid.getSelectionModel().getSelected();
                        if(row)
                        {
                             
                             if(combo.getValue()=='漏刷卡')
                             {
                                    type_ds.removeAll();
                                    ads_ds.loadData(GetList("003",ads_data));
                                    row.set('APP_ADS_ID','上班漏刷');
                                    row.set('APP_TYPE','-- -- --');
                                    row.set('APPTYPE',0);
                                  if(isNoNull(row.get('APP_FROM_TIME'))&&isNoNull(row.get('APP_TO_TIME')))
                                  {
                                      countTime(row.get('APP_FROM_TIME'),row.get('APP_TO_TIME'),combo.getValue(),row.get('APP_ADS_ID'),row);
                                  }
                             }
                             else if(combo.getValue()=='请假')
                             {
                                  type_ds.removeAll();
                                  ads_ds.removeAll();
                                  row.set('APP_ADS_ID','-- -- --');
                                  row.set('APP_TYPE','年假');
                                  row.set('APPTYPE',1);
                                  type_ds.loadData(lee_data);
                                  if(isNoNull(row.get('APP_FROM_TIME'))&&isNoNull(row.get('APP_TO_TIME')))
                                  {
                                       countTime(row.get('APP_FROM_TIME'),row.get('APP_TO_TIME'),combo.getValue(),row.get('APP_ADS_ID'),row);
                                  }
                                   
                             }
                             else if(combo.getValue()=='加班')
                             {
                                  type_ds.removeAll();
                                  type_ds.loadData(ote_data);
                                  ads_ds.loadData(GetList("002",ads_data));
                                  row.set('APP_ADS_ID','未用餐');
                                  row.set('APP_TYPE','沿时加班');
                                  row.set('APPTYPE',1);
                                  if(isNoNull(row.get('APP_FROM_TIME'))&&isNoNull(row.get('APP_TO_TIME')))
                                  {
                                       countTime(row.get('APP_FROM_TIME'),row.get('APP_TO_TIME'),combo.getValue(),row.get('APP_ADS_ID'),row);
                                  }
    
                             }
                        }
                    }
                 }
            }          
        })},// 用户选择 加班？ 请假 ？ 还是 忘刷卡
        {header: "申请条目", sortable:true,dataIndex:'APP_ADS_ID',width:35,
        editor:new Ext.form.ComboBox(
        {
           id:'cmb_ads_type',
           name:'cmb_ads_type',
           displayField:'NAME',
           valueField:'NAME',
           readOnly:false,
           hiddenName:'cmb_ads_type_no',
           mode:'local',
           store:ads_ds,
           triggerAction:'all',
           selectOnFocus:true,
           anchor:'100%'  ,
           listeners:
           {
                change:
                {
                    fn:function(combo, newV,oldV)
                    { 
                        var row=app_grid.getSelectionModel().getSelected();
                        if(row)
                        {
                           if(row)
                           {
                                if(isNoNull(row.get('APP_FROM_TIME'))&&isNoNull(row.get('APP_TO_TIME')))
                                {
                                     countTime(row.get('APP_FROM_TIME'),row.get('APP_TO_TIME'),row.get('APP_ATE_ID'),newV,row) ;
                                }
                              

                           }
                        }
                    }
                }
           }       
        })},
        {header: "工 号", sortable:true,dataIndex:'USER_ID',width:20,editor: new Ext.form.TextField({allowBlank: false,blankText:'工号必填！',
            listeners:
            {   
                specialkey:function(field,e)
                {
                    if (e.getKey()==Ext.EventObject.ENTER)
                    {  
                       var row=app_grid.getSelectionModel().getSelected();
                       if(row && (field.getValue()!=null || field.getValue()!="" ))
                       { 
                            Ext.Ajax.request(
                            {
                                url: '../../ashx/Application/GetUserByUser_id.ashx',
                                method: 'POST',
                                params:
                                {
                                   USER_ID:field.getValue()
                                },
                                disableCaching:false,
                                success:function (result,request)
                                {  
                                    var user_data= Ext.util.JSON.decode(result.responseText);
                                    if(user_data.USER_CNAME==null||user_data.USER_CNAME=="")
                                    {
                                            Ext.MessageBox.hide();
                                            Ext.MessageBox.show(
                                            {
                                                title:'系统消息',
                                                msg:'您的工号不在资料库中！',
                                                buttons:Ext.Msg.OK,
                                                con:Ext.MessageBox.ERROR
                                            });  
                                    }
                                    row.set("USER_CNAME",user_data.USER_CNAME);
                                    row.set("USER_DEPARTMENT",user_data.USER_DEPARTMENT);
                                    row.set("USER_SHIFT",user_data.USER_SHIFT);
                                },
                                failure: function()
                                {
                                }
                            });
                       }
                       else
                       {
                        
                                Ext.MessageBox.hide();
                                Ext.MessageBox.show(
                                {
                                    title:'系统消息',
                                    msg:'【请输入工号】【选中操作行】',
                                    buttons:Ext.Msg.OK,
                                    con:Ext.MessageBox.ERROR
                                });   
                                return;        
                       }
                    }   
                }//end function
              }   //end listens     
          })},
        {header: "姓 名",sortable:true,dataIndex:'USER_CNAME',width:20},
        {header: "班 别",sortable:true,dataIndex:'USER_SHIFT',width:20},
        {header: "部 门",sortable:true,dataIndex:'USER_DEPARTMENT',width:20},
        {header: "请假/加班类型",sortable:true,dataIndex:'APP_TYPE',width:35,
        editor:new Ext.form.ComboBox(
        {
           id:'cmb_type_type',
           name:'cmb_type_type',
           displayField:'NAME',
           valueField:'NAME',
           readOnly:false,
           typeAhead: true,
           hiddenName:'cmb_type_type_no',
           mode:'local',
           store:type_ds,
           triggerAction:'all',
           selectOnFocus:true,
           anchor:'100%',
           listeners:
           {
              change:function(combo,newV,oldV)
              {
                 var row=app_grid.getSelectionModel().getSelected();
                 row.set('APPTYPE',type_ds.getAt(type_ds.find('NAME',newV)).get('ID'));
              }
           }        
        })},
        {header: "TEST",sortable:true,dataIndex:'APPTYPE',width:35,hidden:true},
         {header: "日 期",sortable:true,dataIndex:'APP_DATE',width:35,renderer: formatDate,
         editor: new Ext.form.DateField({
                format: 'Y-m-d'
            })

         },
        {header: "开始时间",sortable:true,dataIndex:'APP_FROM_TIME',width:30,
         editor:new Ext.form.TimeField(
         {
            increment: 30,
            format:'H:i',
            listeners:
            {   
                change:function(combo,newV,oldV)
                {
                  var row=app_grid.getSelectionModel().getSelected();
                  if(row)
                  {
                        if(row.get('APP_TO_TIME')==null||row.get('APP_TO_TIME')=='')
                        {
                          return ;
                        }
                      countTime(newV,row.get('APP_TO_TIME'),row.get('APP_ATE_ID'),row.get('APP_ADS_ID'),row);
                 }
               }
           } 
         })
         },
        {header: "结束时间",sortable:true,dataIndex:'APP_TO_TIME',width:30,
         editor:new Ext.form.TimeField(
         {
            increment: 30,
            format:'H:i',
            listeners:
            {   
                change:function(combo,newV,oldV)
                { 
                  var row=app_grid.getSelectionModel().getSelected();
                  if(row)
                  {
                        if(row.get('APP_FROM_TIME')==null||row.get('APP_FROM_TIME')=='')
                        {
                          return ;
                        }
                        
                        countTime(row.get('APP_FROM_TIME'),newV,row.get('APP_ATE_ID'),row.get('APP_ADS_ID'),row);
                  }
                }
           }   
         })
         },
        {header: "时 数",sortable:true,dataIndex:'APP_NUM_TIME',width:20},
        {header: "原 因",sortable:true,dataIndex:'APP_CAUSE',width:50,editor:new Ext.form.TextArea({        
        name:'txt_server_spec',            
        id:'txt_server_spec',
        allowBlank: false,
        blankText:'必填！',
        height:75,
        maxLength:100,
        maxLengthText:'最大长度100个字符',
        anchor:'95%'})}
        

     ]);
var app_grid=new Ext.grid.EditorGridPanel(
{
    
    sm:sm,
    cm:cm,
    style:'margin:auto;',
    stripeRows: true,
    frame:true,
    clicksToEdit:1,
    buttonAlign:'center',
    tbar: [
    {
        id:'btnAdd',
        text:'新增',
        tooltip:'新增',
        iconCls:'add-css',
        handler:AddEvent
     }, '-',
     {
        id:'btnDel',
        text:'删除',
        tooltip:'删除',
        iconCls:'remove-css',
        handler:DeleteEvent
    }],
    store:app_ds,
    width:main_form_width,
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
        items: [app_grid],
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
        
        for(var i=0;i<app_ds.getCount();i++)
        {
           if(isNoNull(app_ds.getAt(i).get('USER_ID'))==false||isNoNull(app_ds.getAt(i).get('APP_NUM_TIME'))==false||isNoNull(app_ds.getAt(i).get('APP_DATE'))==false||isNoNull(app_ds.getAt(i).get('APP_CAUSE').toString().trim())==false)
           {
              Ext.Msg.alert('系统消息','信息不完整，拒绝提交！');
              return ;
           }
            var p=new App_Record(
            {
                APP_CAUSE:app_ds.getAt(i).get('APP_CAUSE'),
                APP_ATE_ID:app_ds.getAt(i).get('APP_ATE_ID'),
                APP_ADS_ID:app_ds.getAt(i).get('APP_ADS_ID'),
                APP_TYPE:app_ds.getAt(i).get('APPTYPE'),
                APP_DATE:app_ds.getAt(i).get('APP_DATE'),
                APP_FROM_TIME:app_ds.getAt(i).get('APP_FROM_TIME'),        
                APP_TO_TIME:app_ds.getAt(i).get('APP_TO_TIME'),
                APP_NUM_TIME:app_ds.getAt(i).get('APP_NUM_TIME'),
                USER_ID:app_ds.getAt(i).get('USER_ID')
            });
           lst.push(p);
        }
    
        Ext.Ajax.request(
        {
            url:'../../ashx/Application/AddApplication.ashx',
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

    function countTime(from_dt,to_dt,atype,dts,row)
    {
      // alert('from_dt-'+from_dt+'to_dt-'+to_dt+'atype-'+atype+'dts-'+dts);
     
                 var to_h =0;
                 var from_h=0;
                 if(parseInt(to_dt.toString().substring(0,1)==0))
                 {
                     to_h= parseInt(to_dt.toString().substring(1,2));
                 }
                 else
                 {
                     to_h= parseInt(to_dt.toString().substring(0,2));
                 }
                // alert(from_dt.toString().substring(0,1));
                 if(parseInt(from_dt.toString().substring(0,1))==0)
                 {
                     from_h= parseInt(from_dt.toString().substring(1,2));
                   //  alert('from_h第一个字母为 0'+from_h);
                 }
                 else
                 {
                     from_h= parseInt(from_dt.toString().substring(0,2));
                    // alert('from_h 大于10'+from_h);
                 }
                 var to_m=parseInt(to_dt.toString().substring(3,5));
                 var from_m=parseInt(from_dt.toString().substring(3,5));
                 var ht=0;
                 var mt=":00";
                // alert('to_h-'+to_h+'form_h-'+from_h+'to_m-'+to_m+'from_m-'+from_m);
                   if(from_h>to_h)
                   {
                         row.set('APP_TO_TIME','');
                         row.set('APP_FROM_TIME','');
                         row.set('APP_NUM_TIME','');
                         return ;
                   }
                   else if(from_h==to_h)
                   {
                      if(from_m>to_m)
                      {
                         row.set('APP_TO_TIME','');
                         row.set('APP_FROM_TIME','');
                         row.set('APP_NUM_TIME','');
                         return ;
                      }
                      else if(from_m==to_m)
                      {
                           row.set('APP_NUM_TIME','0:00');
                           return ;
                      }
                      else if(from_m<to_m)
                      {
                         mt=":30";
                      }
                   }
                  else 
                  {
                      ht= to_h-from_h;
                      mt=":00";
                      if(from_m<to_m)
                      {
                         mt=":30";
                      }
                      else if(from_m>to_m)
                      {
                         ht=ht-1;
                         mt=":30";
                      }

                  }
                   if(atype=='加班')
                   {
                                  if(dts=='用餐1次')
                                  {
                                     if(mt==":30")
                                     {
                                        mt=":00";
                                     }
                                     else
                                     {
                                       
                                       ht=ht-1;
                                       mt=":30"
                                     }
                                     if(isFirstMsg1==0)
                                     {
                                        Ext.Msg.alert('系统消息','用餐一次将扣除半小时!');
                                        isFirstMsg1++;
                                     }
                                  }
                                  else if(dts=='用餐2次')
                                  {
                                     ht=ht-1;
                                     if(isFirstMsg2==0)
                                     {
                                        Ext.Msg.alert('系统消息','用餐两次将扣除 1 小时!');
                                        isFirstMsg2++;
                                     }
                                  }
                      
                    }
                    if(ht<0)
                    {
                           row.set('APP_NUM_TIME','0:00');
                           return ;
                    }
                   row.set('APP_NUM_TIME', ht.toString()+mt);
    }
 function AddEvent()
  {
        var rownumber=(app_ds.getCount()+1).toString();
        var p = new App_Record(
        {   
                ORDER_NO:rownumber,
                APP_CAUSE:'',
                APP_ATE_ID:'请假',
                APP_ADS_ID:'-- -- --',
                APP_TYPE:'年假',
                APP_DATE:'',
                APP_FROM_TIME:'',   
                APP_TO_TIME:'',
                APP_NUM_TIME:'',
                APPTYPE:1,
                
                USER_CNAME:'',
                USER_NAME:'',
                USER_ID:'',
                USER_DEPARTMENT:'',
                USER_SHIFT:''
        });
        app_grid.stopEditing();
        app_ds.insert(app_ds.getCount(), p);
        //ads_ds.loadData(GetList("002",ads_data));
        
  }  
  AddEvent();  
 function DeleteEvent()
 {
       var selectedRow = app_grid.getSelectionModel().getSelected();
        if (selectedRow)
        {
            app_ds.remove(selectedRow);
        }
}   

function GetList(val,dsData)
{
  var iList =new  Array();
  for(var i=0;i<dsData.length;i++)
  {
      if(dsData[i].LEVEL==val)
      {
         iList.push(dsData[i]);
      }
  }
  return iList;
}
mainForm.render(document.body); 
String.prototype.Trim = function()
{
        return this.replace(/(^\s*)|(\s*$)/g, "");
}
function isNoNull(val)
{
   
   if(val==null||val==''|| val=='undefind')
   {
      return false;
   }
   else
   {
     return true;
   }
}    
    
});