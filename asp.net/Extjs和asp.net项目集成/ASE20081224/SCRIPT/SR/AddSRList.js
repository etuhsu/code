Ext.onReady(function(){
    Ext.QuickTips.init();
    var form=new Ext.form.BasicForm('form1');
    Ext.form.Field.prototype.msgTarget = 'side';
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
           IDstr:'13,14,15,16,17'
        },
        disableCaching:false,
        success:function (result,request)
        {

            var  sys_data=Ext.util.JSON.decode(result.responseText).SYS_TYPE;
            var  det_data=Ext.util.JSON.decode(result.responseText).DET_TYPE;
            var  rat_data=Ext.util.JSON.decode(result.responseText).RAT_TYPE;
            var  lel_data=Ext.util.JSON.decode(result.responseText).LEL_TYPE;
           var  grp_data=Ext.util.JSON.decode(result.responseText).GRP_TYPE;
              sys_ds.loadData(sys_data);
              det_ds.loadData(det_data);
              rat_ds.loadData(rat_data);
              lel_ds.loadData(lel_data);
             grp_ds.loadData(grp_data);
            
        },
        failure: function()
        {
        }
    });
   var sys_ds=new Ext.data.JsonStore(
   {
        fields:[
            {name:'ID',type:'string'},
            {name:'NAME',type:'string'}
        ]
   });
   var det_ds=new Ext.data.JsonStore(
   {
        fields:[
            {name:'ID',type:'string'},
            {name:'NAME',type:'string'}
        ]
   });
   var rat_ds=new Ext.data.JsonStore(
   {
        fields:[
            {name:'ID',type:'string'},
            {name:'NAME',type:'string'}
        ]
        
   });
   var lel_ds=new Ext.data.JsonStore(
   {
        fields:[
            {name:'ID',type:'string'},
            {name:'NAME',type:'string'}
        ]
   });
      var grp_ds=new Ext.data.JsonStore(
   {
        fields:[
            {name:'ID',type:'string'},
            {name:'NAME',type:'string'}
        ]
   });
   var txt_sr_title=new Ext.form.TextField(
   {
        fieldLabel:'SR  标题',
        name:'txt_sr_title',            
        id:'txt_sr_title',
        maxLength:120,
        maxLengthText:'最大长度120个字符',
        anchor:'97%'
   });
   var  txt_sr_client=new Ext.form.TextField(
   {
        fieldLabel:'客  户',
        name:'txt_sr_client',
        id:'txt_sr_client',
        maxLength:50,
        maxLengthText:'最大长度50个字符',
        blankText:'',
        anchor:'95%'
   });
     /*SR_TITLE VARCHAR(200),
  SR_PROPOSER VARCHAR(20),
  SR_CLIENT VARCHAR(20),
  SR_IT_COSt VARCHAR(20),
  SR_USER_BENEFIT VARCHAR(200),
  SR_DET_ID INT  ,
  SR_LEL_ID INT ,
  SR_RAT_ID INT  ,
  SR_SYE_ID INT ,
  SR_OVERDATE DATETIME,
  SR_SR_FLAG BIT,
  SR_AR_FLAG BIT,
  SR_DEMAND_DESC TEXT,
  SR_CREATIONUID VARCHAR(5),
  SR_CREATE_DT DATETIME,
  SR_UPDATEUID VARCHAR(5),
  SR_UPDATE_DT DATETIME,
  SR_standby1 varchar(100),
  SR_standby2  varchar(100),
  SR_standby3  INT,*/
   var  txt_application=new Ext.form.TextField(
   {
        fieldLabel:'申请人',
        name:'txt_application',
        id:'txt_application',
        maxLength:10,
        maxLengthText:'最大长度10个字符',
        blankText:'',
        anchor:'95%'
   });
   var txt_IT_cost=new Ext.form.TextField(  
   {
        fieldLabel:'IT成本（H）',
        name:'txt_IT_cost',
        id:'txt_IT_cost',
        maxLength:120,
        maxLengthText:'最大长度120个字符',
        blankText:'',
        anchor:'95%'
   });
   var txt_user_benefit=new Ext.form.TextArea(
   {
        fieldLabel:'User效益',
        name:'txt_user_benefit',            
        id:'txt_user_benefit',
        height:50,
        maxLength:500,
        maxLengthText:'最大长度500个字符',
        anchor:'95%'
   });
   
    var cmb_apply=new Ext.form.ComboBox(
    {
        fieldLabel:'申请部门',
        name:'cmb_apply',
        id:'cmb_apply',
        hiddenName:'cmb_apply_no',
        mode:'local',
        triggerAction:'all',
        store:det_ds,
        emptyText:'--请选择--',
        //editable:true,
        selectOnFocus:true,
        displayField:'NAME',
        valueField:'ID',
        readOnly:true,
        valueNotFoundText:'--请选择--',
        anchor:'95%'
    });
    
   var cmb_sys_type=new Ext.form.ComboBox(
    {
        fieldLabel:'系统类型',
        name:'cmb_sys_type',
        id:'cmb_sys_type',
        hiddenName:'cmb_sys_type_no',
        mode:'local',
        triggerAction:'all',
        store:sys_ds,
        emptyText:'--请选择--',
        //editable:true,
        selectOnFocus:true,
        displayField:'NAME',
        valueField:'ID',
        readOnly:true,
        valueNotFoundText:'--请选择--',
        anchor:'95%'
    });
    var cmb_sr_sort=new Ext.form.ComboBox(
    {
        fieldLabel:'SR分類',
        name:'cmb_sr_sort',
        id:'cmb_sr_sort',
        hiddenName:'cmb_sr_sort_no',
        mode:'local',
        triggerAction:'all',
        store:rat_ds,
        emptyText:'--请选择--',
        //editable:true,
        selectOnFocus:true,
        displayField:'NAME',
        valueField:'ID',
        readOnly:true,
        valueNotFoundText:'--请选择--',
        anchor:'95%'
    });
     var cmb_sr_level=new Ext.form.ComboBox(
    {
        fieldLabel:'SR Level',
        name:'cmb_sr_level',
        id:'cmb_sr_level',
        hiddenName:'cmb_sr_level_no',
        mode:'local',
        triggerAction:'all',
        store:lel_ds,
        emptyText:'--请选择--',
        //editable:true,
        selectOnFocus:true,
        displayField:'NAME',
        valueField:'ID',
        readOnly:true,
        valueNotFoundText:'--请选择--',
        anchor:'95%'
    });
     var cmb_sr_group=new Ext.form.ComboBox(
    {
        fieldLabel:'IT 组别',
        name:'cmb_sr_group',
        id:'cmb_sr_group',
        hiddenName:'cmb_sr_group_no',
        mode:'local',
        triggerAction:'all',
        store:grp_ds,
        emptyText:'--请选择--',
        //editable:true,
        selectOnFocus:true,
        displayField:'NAME',
        valueField:'ID',
        readOnly:true,
        valueNotFoundText:'--请选择--',
        anchor:'95%'
    }); 
   var txt_IT_owner=new Ext.form.TextField(  
   {
        fieldLabel:'IT Owner',
        name:'txt_IT_owner',
        id:'txt_IT_owner',
        maxLength:20,
        maxLengthText:'最大长度20个字符',
        blankText:'',
        anchor:'95%'
   });
    var txt_sod_expect_dt=new Ext.form.DateField(
    {
       id:'txt_sod_expect_dt',
       name:'txt_sod_expect_dt',
       fieldLabel:'SOD (预计)',
       value:new Date(),
       format:'Y-m-d',
       allowBlank:false,
       blandText:'',
       anchor:'95%'
    });
    var txt_sod_update=new Ext.form.DateField(
    {
       id:'txt_sod_update',
       name:'txt_sod_update',
       fieldLabel:'RSOD (更新)',
       value:new Date(),
       format:'Y-m-d',
       allowBlank:false,
       blandText:'',
       anchor:'95%'
    });
    var txt_over_dt=new Ext.form.DateField(
    {
       id:'txt_over_dt',
       name:'txt_over_dt',
       fieldLabel:'期望完成日期',
       value:new Date(),
       format:'Y-m-d',
       allowBlank:false,
       blandText:'',
       anchor:'95%'
    });
     var chk_project=new Ext.form.Radio(
     {
         boxLabel: 'Project',
         id:'chk_project',
         name: 'ar_chk'
     }); 
     var chk_sr=new Ext.form.Radio(
     {
         boxLabel: 'SR',
         id:'chk_sr',
         name: 'ar_chk',
         checked:true
     });    
     var chk_ar=new Ext.form.Radio(
     {
         boxLabel: 'AR',
         id:'chk_ar',
         name: 'ar_chk'
     });  
var tList=new Ext.form.FieldSet(
    {
        xtype:'fieldset',
        id:'tList',
        name:'tList',
        collapsed: false,
        bodyStyle:'margin:10px,0px,0px,0px',
        width:main_form_width*0.985,
        autoHeight:true,
        checkboxToggle:false,
        frame:false,
        layout:'form',
        items:[txt_sr_title,
        {
                layout:'column',
                style:'margin:0px,0px,0px,740px',
                items:[chk_project,{width:20},chk_sr,{width:20},chk_ar]
        }]
   
    });    
      
var BaseList=new Ext.form.FieldSet(
    {
        id:'BaseList',
        name:'BaseList',
        collapsed: false,
        title:'Base information',
        width:main_form_width*0.985,
        autoHeight:true,
        labelAlign:'left',
        checkboxToggle:true,
        frame:true,
        layout:'form',
        items:[{
                    layout:'column',
                    items:
                    [{
                       layout:'form',
                       columnWidth:.5,
                       items: [txt_application,txt_IT_cost,txt_user_benefit //{layout:'column',items:[{layout:'form',columnWidth:.57,items:[]},{layout:'form',columnWidth:.43,labelWidth:35,items:[]}]}
                   ]},
                    {
                          layout:'form',
                          columnWidth:.5,
                          items:[txt_sr_client,cmb_apply,cmb_sys_type,txt_over_dt]
                       
                    }]
            }]
    });
    var StatusList=new Ext.form.FieldSet(
    {
        id:'StatusList',
        name:'StatusList',
        collapsed: false,
        title:'SR Status information',
        width:main_form_width*0.985,
        autoHeight:true,
        labelAlign:'left',
        checkboxToggle:true,
        frame:true,
        layout:'form',
        items:[{
                    layout:'column',
                    items:
                    [{
                       layout:'form',
                       columnWidth:.5,
                       items: [txt_IT_owner,txt_sod_expect_dt,txt_sod_update]
                    },
                    {
                          layout:'form',
                          columnWidth:.5,
                          items:[cmb_sr_sort,cmb_sr_group,cmb_sr_level]
                       
                    }]
            }]
    });
          
    var mainForm=new Ext.form.FormPanel(
    {
        title:'添加SR',
        width:main_form_width,
        style:'margin:auto; ',
        frame:true,
        buttonAlign:'center',
        layout:'form',
        items: [tList,BaseList,StatusList,
         {
           layout:'fit',
           items:[new Ext.Panel(
                 {
                        width: main_form_width*0.9,
                        height: 220,
                        frame: true,
                        layout: 'fit',
                        items: 
                        {
                            xtype: 'htmleditor',
                            id:'txt_requirement',
                            name:'txt_requirement',
                            enableColors: true,
                            enableAlignments: true
                        }
                  })] }],       
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
       if(mainForm.form.isValid())
       {
                mainForm.form.doAction('submit',{
                url:'../../ashx/SR/AddSRList.ashx',
                method:'post',
                params:
                {
                  sr_flag: isNoNull(chk_sr.getValue()) ? 1 : 0,
                  ar_flag: isNoNull(chk_ar.getValue()) ? 1 : 0,
                  pro_flag: isNoNull(chk_project.getValue()) ? 1 : 0
                 
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
    mainForm.render(document.body);
});