Ext.onReady(function(){
    Ext.BLANK_IMAGE_URL='../../img/s.gif';
    Ext.QuickTips.init();
    var form=new Ext.form.BasicForm('form1');
    Ext.form.Field.prototype.msgTarget = 'side';
    var screen_width=960;
    var screen_heigth=500;
    var main_form_width=960;
    var main_form_height=500;
    ////获取参数
    function GetQueryString(name)
	{
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)","i");
        var r = window.location.search.substr(1).match(reg);
        if (r!=null) return unescape(r[2]); return null;
    }
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
            
        },
        failure: function()
        {
        }
    });
   var cpu_ds=new Ext.data.JsonStore(
   {
        fields:[
            {name:'ID',type:'string'},
            {name:'NAME',type:'string'}
        ]
   });
   var mey_ds=new Ext.data.JsonStore(
   {
        fields:[
            {name:'ID',type:'string'},
            {name:'NAME',type:'string'}
        ]
   });   
   var aty_ds=new Ext.data.JsonStore(
   {
        fields:[
            {name:'ID',type:'string'},
            {name:'NAME',type:'string'}
        ]
   });  
    var os_ds=new Ext.data.JsonStore(
   {
        fields:[
            {name:'ID',type:'string'},
            {name:'NAME',type:'string'}
        ]
   });   
   var smo_ds=new Ext.data.JsonStore(
   {
        fields:[
            {name:'ID',type:'string'},
            {name:'NAME',type:'string'}
        ]
   });  
    var had_ds=new Ext.data.JsonStore(
   {
        fields:[
            {name:'ID',type:'string'},
            {name:'NAME',type:'string'}
        ]
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
     var jsonRecord = Ext.data.Record.create(
      [
            {name:'OS',type:'string'},
            {name:'ATY',type:'string'},
            {name:'SMO',type:'string'},
            {name:'HAD',type:'string'},
            {name:'MEY',type:'string'},
            {name:'CPU',type:'string'},
            {name:'STR',type:'string'},
            {name:'TEAM',type:'string'}


        ]);
   var txt_server_name=new Ext.form.TextField(
   {
        fieldLabel:'Server Name',
        name:'txt_server_name',
        id:'txt_server_name',
        maxLength:50,
        maxLengthText:'最大长度50个字符',
        blankText:'服务器名不能为空',
        anchor:'95%'
   });
   var  txt_sn_name=new Ext.form.TextField(
   {
        fieldLabel:'SN',
        name:'txt_sn_name',
        id:'txt_sn_name',
        maxLength:50,
        maxLengthText:'最大长度50个字符',
        blankText:'系列号不能为空',
        anchor:'95%'
   });
   var txt_server_spec=new Ext.form.TextArea(
   {
        fieldLabel:'Function Description',
        name:'txt_server_spec',            
        id:'txt_server_spec',
        height:75,
        maxLength:100,
        maxLengthText:'最大长度100个字符',
        anchor:'95%'
   });
   var  txt_ip_address=new Ext.form.TextField(
   {
        fieldLabel:'IP',
        name:'txt_ip_address',       
        id:'txt_ip_address',
         maxLength:15,
        maxLengthText:'最大长度15个字符',
        anchor:'95%'
   });

 var ckb_1=new  Ext.form.Checkbox(
 {
   hideLabel:true,
   id:'ckb_1',
   name:'ckb_1',
   checked:true,
   style:'margin:0px 0px 10px 0px;',
   listeners:
   {
      check : function(chk,flag )
      {
         if(!flag)
         {
             txt_aty_type.setDisabled(false);
             cmb_aty_type.setDisabled(true);
         }
         else
         {
             txt_aty_type.setDisabled(true);
             cmb_aty_type.setDisabled(false);
         }
      }
   }
 });
var  txt_aty_type=new Ext.form.TextField(
{
    fieldLabel:'',
    name:'txt_aty_type',       
    id:'txt_aty_type',
    hidden:false,
    maxLength:20,
    disabled:true,
    maxLengthText:'最大长度20个字符',
    blankText:'该项不能为空',
    anchor:'100%'
});
  var ckb_2=new  Ext.form.Checkbox(
 {
   hideLabel:true,
   id:'ckb_2',
   name:'ckb_2',
    checked:true,
    style:'margin:0px 0px 10px 0px;',
   listeners:
   {
      check : function(chk,flag )
      {
         if(!flag)
         {
             txt_had_type.setDisabled(false);
              cmb_had_type.setDisabled(true);
         }
         else
         {
             txt_had_type.setDisabled(true);
              cmb_had_type.setDisabled(false);
         }
      }
   }
 });
 var txt_had_type=new Ext.form.TextField(
{
    fieldLabel:'',
    name:'txt_had_type',       
    id:'txt_had_type',
    hidden:false,
    maxLength:30,
    disabled:true,
    maxLengthText:'最大长度30个字符',
    blankText:'该项不能为空',
    anchor:'100%'
});


  var ckb_3=new  Ext.form.Checkbox(
 {
   hideLabel:true,
   id:'ckb_3',
   name:'ckb_3',
    checked:true,
    style:'margin:0px 0px 10px 0px;',
   listeners:
   {
      check : function(chk,flag )
      {
         if(!flag)
         {
             txt_mey_type.setDisabled(false);
              cmb_mey_type.setDisabled(true);
         }
         else
         {
             txt_mey_type.setDisabled(true);
              cmb_mey_type.setDisabled(false);
         }
      }
   }
 });
 
 var txt_mey_type=new Ext.form.TextField(
{
    fieldLabel:'',
    name:'txt_mey_type',       
    id:'txt_mey_type',
    hidden:false,
    maxLength:30,
    disabled:true,
    maxLengthText:'最大长度30个字符',
    blankText:'该项不能为空',
    anchor:'100%'
});
  var ckb_4=new  Ext.form.Checkbox(
 {
   hideLabel:true,
   id:'ckb_4',
   name:'ckb_4',
    checked:true,
    style:'margin:0px 0px 10px 0px;',
   listeners:
   {
      check : function(chk,flag )
      {
         if(!flag)
         {
             txt_cpu_type.setDisabled(false);
              cmb_cpu_type.setDisabled(true);
         }
         else
         {
             txt_cpu_type.setDisabled(true);
              cmb_cpu_type.setDisabled(false);
         }
      }
   }
 });
 var txt_cpu_type=new Ext.form.TextField(
{
    fieldLabel:'',
    name:'txt_cpu_type',       
    id:'txt_cpu_type',
    hidden:false,
    maxLength:100,
     disabled:true,
    maxLengthText:'最大长度100个字符',
    blankText:'该项不能为空',
    anchor:'100%'
});
  var ckb_5=new  Ext.form.Checkbox(
 {
   hideLabel:true,
   id:'ckb_5',
   name:'ckb_5',
    checked:true,
    style:'margin:0px 0px 10px 0px;',
   listeners:
   {
      check : function(chk,flag )
      {
         if(!flag)
         {
             txt_os_type.setDisabled(false);
             cmb_os_type.setDisabled(true);
         }
         else
         {
             txt_os_type.setDisabled(true);
             cmb_os_type.setDisabled(false);
         }
      }
   }
 });
 var txt_os_type=new Ext.form.TextField(
{
    fieldLabel:'',
    name:'txt_os_type',       
    id:'txt_os_type',
    maxLength:50,
  disabled:true,
    maxLengthText:'最大长度50个字符',
    blankText:'该项不能为空',
    anchor:'100%'
});
  var ckb_6=new  Ext.form.Checkbox(
 {
   hideLabel:true,
   id:'ckb_6',
   name:'ckb_6',
    checked:true,
    style:'margin:0px 0px 10px 0px;',
   listeners:
   {
      check : function(chk,flag )
      {
         if(!flag)
         {
             txt_smo_type.setDisabled(false);
              cmb_smo_type.setDisabled(true);
         }
         else
         {
             txt_smo_type.setDisabled(true);
              cmb_smo_type.setDisabled(false);
         }
      }
   }
 });
  var txt_smo_type=new Ext.form.TextField(
{
    fieldLabel:'',
    name:'txt_smo_type',       
    id:'txt_smo_type',
    hidden:false,
    disabled:true,
    maxLength:50,
    maxLengthText:'最大长度50个字符',
    blankText:'该项不能为空',
    anchor:'100%'
});
    var cmb_smo_type=new Ext.form.ComboBox(
    {
        fieldLabel:'Brand/Model',
        name:'cmb_smo_type',
        id:'cmb_smo_type',
        hiddenName:'cmb_smo_type_no',
        mode:'local',
        triggerAction:'all',
        store:smo_ds,
        emptyText:'--请选择--',
        selectOnFocus:true,
        displayField:'NAME',
        valueField:'ID',
        valueNotFoundText:'--请选择--',
        anchor:'95%'
    });
    var cmb_os_type=new Ext.form.ComboBox(
    {
        fieldLabel:'OS',
        name:'cmb_os_type',
        id:'cmb_os_type',
        hiddenName:'cmb_os_type_no',
        mode:'local',
        triggerAction:'all',
        store:os_ds,
        emptyText:'--请选择--',
        //editable:true,
        selectOnFocus:true,
        displayField:'NAME',
        valueField:'ID',
        readOnly:true,
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
        emptyText:'--请选择--',
        selectOnFocus:true,
        displayField:'NAME',
        valueField:'ID',
        valueNotFoundText:'--请选择--',
        anchor:'95%'
    });
     var cmb_mey_type=new Ext.form.ComboBox(
    {
        fieldLabel:'Memory',
        name:'cmb_mey_type',
        id:'cmb_mey_type',
        hiddenName:'cmb_mey_type_no',
  
        mode:'local',
        triggerAction:'all',
        store:mey_ds,
        emptyText:'--请选择--',
        selectOnFocus:true,
        displayField:'NAME',
        valueField:'ID',
        valueNotFoundText:'--请选择--',
        anchor:'95%'
    });
    var cmb_had_type=new Ext.form.ComboBox(
    {
        fieldLabel:'Hard Disk',
        name:'cmb_had_type',
        id:'cmb_had_type',
        hiddenName:'cmb_had_type_no',
        mode:'local',
        triggerAction:'all',
        store:had_ds,
  
        emptyText:'--请选择--',
        selectOnFocus:true,
        displayField:'NAME',
        valueField:'ID',
        valueNotFoundText:'--请选择--',
        anchor:'95%'
    });
    var cmb_aty_type=new Ext.form.ComboBox(
    {
        fieldLabel:'Array Type',
        name:'cmb_aty_type',
        id:'cmb_aty_type',
        hiddenName:'cmb_aty_type_no',
        mode:'local',
        triggerAction:'all',
  
        store:aty_ds,
        emptyText:'--请选择--',
        selectOnFocus:true,
        displayField:'NAME',
        valueField:'ID',
        valueNotFoundText:'--请选择--',
        anchor:'95%'
    });
    var txt_come_dt=new Ext.form.DateField(
    {
       id:'txt_come_dt',
       name:'txt_come_dt',
       fieldLabel:'Date',
       value:new Date(),
       format:'Y-m-d',
       allowBlank:false,
       blandText:'到货日期不能为空！',
       anchor:'90%'
    });
    var txt_po_no=new Ext.form.TextField(
    {
       id:'txt_po_no',
       name:'txt_po_no',
       fieldLabel:'PO NO.',
       maxLength:50,
       maxLengthText:'最大长度50个字符！',
       allowBlank:false,
       blandText:'PO NO.不能为空！',
        anchor:'95%'
    });
    var txt_owner=new Ext.form.TextField(
    {
       id:'txt_owner',
       name:'txt_owner',
       fieldLabel:'Owner',
       maxLength:50,
       maxLengthText:'最大长度50个字符！',
       allowBlank:false,
       blandText:'Owner不能为空！',
       anchor:'100%'
    });
    var txt_ap_list=new Ext.form.HtmlEditor(
    {
       id:'txt_ap_list',
       name:'txt_ap_list',
       fieldLabel:'AP List',
       height:200,
       hidden:false,
       width:main_form_width*0.95

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
var txt_str_type=new Ext.form.TextField(
{
    fieldLabel:'',
    name:'txt_str_type',       
    id:'txt_str_type',
    hidden:false,
    maxLength:20,
    disabled:true,
    maxLengthText:'最大长度20个字符',
    blankText:'该项不能为空',
    anchor:'100%'
});
 var ckb_7=new  Ext.form.Checkbox(
 {
   hideLabel:true,
   id:'ckb_7',
   name:'ckb_7',
   checked:true,
   style:'margin:0px 0px 10px 0px;',
   listeners:
   {
      check : function(chk,flag )
      {
         if(!flag)
         {
             txt_str_type.setDisabled(false);
              cmb_str_type.setDisabled(true);
         }
         else
         {
             txt_str_type.setDisabled(true);
             cmb_str_type.setDisabled(false);
         }
      }
   }
 });
   var cmb_team_type=new Ext.form.ComboBox(
    {
        fieldLabel:'IT Team',
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
var txt_team_type=new Ext.form.TextField(
{
    fieldLabel:'',
    name:'txt_team_type',       
    id:'txt_team_type',
    hidden:false,
    disabled:true,
    maxLength:100,
    maxLengthText:'最大长度100个字符',
    blankText:'该项不能为空',
    anchor:'100%'
});
 var ckb_8=new  Ext.form.Checkbox(
 {
   hideLabel:true,
   id:'ckb_8',
   name:'ckb_8',
   checked:true,
   style:'margin:0px 0px 10px 0px;',
   listeners:
   {
      check : function(chk,flag )
      {
         if(!flag)
         {
             txt_team_type.setDisabled(false);
              cmb_team_type.setDisabled(true);
         }
         else
         {
             txt_team_type.setDisabled(true);
             cmb_team_type.setDisabled(false);
         }
      }
   }
 });
var AddComeList=new Ext.form.FieldSet(
    {
        xtype:'fieldset',
        id:'AddComeList',
        name:'AddComeList',
        collapsed: false,
        bodyStyle:'margin:10px,0px,0px,0px',
        width:main_form_width*0.985,
        autoHeight:true,
        checkboxToggle:false,
        frame:false,
        buttonAlign:'right',
        layout:'form',
        items:[  
         {
                    layout:'column',
                    items:
                    [{
                       layout:'form',
                       columnWidth:.45,
                       items: [txt_po_no,{layout:'column',items:[{layout:'form',columnWidth:.55,items:[txt_owner]},{layout:'form',columnWidth:.45,labelWidth:40,items:[txt_come_dt]}]}]
                            
                    },
                    {
                          layout:'form',
                          columnWidth:.30,
                          items:[cmb_str_type,cmb_team_type]
                       
                    },
                    {
                          layout:'form',
                          columnWidth:.25,
                          items:[
                          {layout:'column',items:[{layout:'form',columnWidth:.1,items:[ckb_7]},{layout:'form',   labelWidth:1,columnWidth:.9,items:[txt_str_type]}]},
                          {layout:'column',items:[{layout:'form',columnWidth:.1,items:[ckb_8]},{layout:'form',   labelWidth:1,columnWidth:.9,items:[txt_team_type]}]}]
                          
                    }]
      
       }]
    });
var AddBaseList=new Ext.form.FieldSet(
    {
        xtype:'fieldset',
        id:'AddBaseList',
        name:'AddBaseList',
        collapsed: false,
        title:'Configuration information',
        width:main_form_width*0.985,
        autoHeight:true,
        checkboxToggle:true,
        frame:true,
        buttonAlign:'right',
        layout:'form',
        items:[  
        {
                    layout:'column',
                    items:
                    [{
                       layout:'form',
                       columnWidth:.45,
                       items: [txt_server_name, txt_sn_name,txt_ip_address,txt_server_spec]
                            
                    },
                    {
                          layout:'form',
                          columnWidth:.30,
                          items:[cmb_aty_type, cmb_had_type, cmb_mey_type ,cmb_cpu_type,cmb_os_type, cmb_smo_type ]
                       
                    },
                    {
                          layout:'form',
                          columnWidth:.25,
                          items:[
                          {layout:'column',items:[{layout:'form',columnWidth:.1,items:[ckb_1]},{layout:'form',   labelWidth:1,columnWidth:.9,items:[txt_aty_type]}]},
                          {layout:'column',items:[{layout:'form',columnWidth:.1,items:[ckb_2]},{layout:'form',   labelWidth:1,columnWidth:.9,items:[txt_had_type]}]},
                          {layout:'column',items:[{layout:'form',columnWidth:.1,items:[ckb_3]},{layout:'form',   labelWidth:1,columnWidth:.9,items:[txt_mey_type]}]},
                          {layout:'column',items:[{layout:'form',columnWidth:.1,items:[ckb_4]},{layout:'form',   labelWidth:1,columnWidth:.9,items:[txt_cpu_type]}]},
                          {layout:'column',items:[{layout:'form',columnWidth:.1,items:[ckb_5]},{layout:'form',   labelWidth:1,columnWidth:.9,items:[txt_os_type]}]},
                          {layout:'column',items:[{layout:'form',columnWidth:.1,items:[ckb_6]},{layout:'form',   labelWidth:1,columnWidth:.9,items:[txt_smo_type]}]}]
                          
                    }]
            }]
    });
    var mainForm=new Ext.form.FormPanel(
    {
        title:'新增服务器',
        width:main_form_width,
        style:'margin:auto; ',
        frame:true,
        buttonAlign:'center',
        layout:'form',
        items: [AddComeList,AddBaseList,
         {
           layout:'fit',
           items:[new Ext.Panel(
                 {
                        width: main_form_width*0.9,
                        height: 180,
                        frame: true,
                        layout: 'fit',
                        items: 
                        {
                            xtype: 'htmleditor',
                            id:'txt_ap_list',
                            name:'txt_ap_list',
                            enableColors: false,
                            enableAlignments: false
                        }
                  })] }],      //txt_ap_list  
         buttons: [
        {
                    text: ' 确 定 ',
                    id:'btn_comfire',
                    iconCls:'ok-css',
                    handler:comfirmFun
        } ,
        {
                    text: ' 重 置 ',
                    iconCls:'remove-css',
                    handler:abolishFun
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
         if(isIP(txt_ip_address.getValue())==false)
         {
                     Ext.MessageBox.show({
                        title:'系统消息',
                        msg:'请正确输入 IP 地址！',
                        buttons:Ext.Msg.OK,
                        icon:Ext.MessageBox.INFO
                    });
                    return;
         } 
        var AddEntryJson=new jsonRecord(
        {
             OS:txt_os_type.getValue(),
             ATY:txt_aty_type.getValue(),
             SMO:txt_smo_type.getValue(),
             HAD:txt_had_type.getValue(),
             MEY:txt_mey_type.getValue(),
             CPU:txt_cpu_type.getValue(),
             STR:txt_str_type.getValue(),
             TEAM:txt_team_type.getValue()
        });
    var lst=new Array();
    lst.push(AddEntryJson);
       if(mainForm.form.isValid())
       {
                mainForm.form.doAction('submit',{
                url:'../../ashx/Server/AddListServer.ashx',
                method:'post',
                params:
                {
                   data:Ext.util.JSON.encode(lst)
                },
                success:function(form,action)
                {
                    Ext.MessageBox.hide();
                    Ext.MessageBox.show({
                        title:'系统消息',
                        msg:action.result.data,
                        buttons:Ext.Msg.OK,
                        icon:Ext.MessageBox.INFO
                    });
                },//--sucess
                failure:function(form,action)
                {
                    Ext.MessageBox.hide();
                    Ext.MessageBox.show({
                        title:'系统消息',
                        msg:action.result.data,
                        buttons:Ext.Msg.OK,
                        icon:Ext.MessageBox.ERROR
                    });
                }  //--end failure
            })//--doAction
       } //end--if
       else
       {
             Ext.MessageBox.hide();
             Ext.MessageBox.show({
                title:'系统消息',
                msg:'未能与服务器完成通讯，请联系技术人员!',
                buttons:Ext.Msg.OK,
                icon:Ext.MessageBox.ERROR
             });   
       } //end--else
    }
function abolishFun()
{
     
   mainForm.getForm().reset();
}
 function isIP (val)
{

        var reSpaceCheck = /^(\d+)\.(\d+)\.(\d+)\.(\d+)$/;

        if (reSpaceCheck.test(val))
        {
       
                val.match(reSpaceCheck);
                if (RegExp.$1 <= 255 && RegExp.$1 >= 0
                 && RegExp.$2 <= 255 && RegExp.$2 >= 0
                 && RegExp.$3 <= 255 && RegExp.$3 >= 0
                 && RegExp.$4 <= 255 && RegExp.$4 >= 0)
                {
                        return true;    
                }
                else
                {
                        return false;
                }
        }
        else
        {
                return false;
        }
  
}
    mainForm.render(document.body);
});