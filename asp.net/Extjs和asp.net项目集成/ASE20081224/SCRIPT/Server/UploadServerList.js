 Ext.onReady(function(){
    Ext.BLANK_IMAGE_URL='../../img/s.gif';
    Ext.QuickTips.init();
    var form=new Ext.form.BasicForm('form1');
    Ext.form.Field.prototype.msgTarget = 'side';
    var screen_width=960;
    var screen_heigth=500;
    var main_form_width=960;
    var main_form_height=500;
    
    var  upload_file=new Ext.form.TextField(
   {
        fieldLabel:'',
        name:'upload_file',
        id:'upload_file',
        height:24,
        allowBlank:true,
        inputType:'file',
        anchor:'65%'
   });

    var upDateFieldExcel=new Ext.form.FieldSet(
    {
        xtype:'fieldset',
        id:'upDateFieldExcel',
        name:'upDateFieldExcel',
        title: '批量导入',
       // style:'margin:20px 20px 10px 20px ;',
        collapsed: false,
        width:main_form_width*0.95,
        height:130,
        frame:true,
        buttonAlign:'right',
        labelWidth:60,
        layout:'form',
        items: [upload_file],
        buttons: [
        {
                    text: '上 传',
                    id:'btn_comfire',
                    iconCls:'upload-option-css',
                    handler:uploadExcelFun
        }]
    });
    
    var mainForm=new Ext.FormPanel(
    {
        width:main_form_width,
        fileUpload:true,
        style:'margin:auto; ',
        height:120,
        frame:true,
        layout:'fit',
        items:[upDateFieldExcel ]
    });
       //======================================    上传处理   =============================
   function uploadExcelFun()
   {
        
         Ext.MessageBox.show(
         {
            msg:'正在执行操作,请稍候...',
            progressText:'正在上传...',
            width:300,
            wait:true,
            waitConfig:{interval:200}
        });
       if(mainForm.form.isValid())
       {
            mainForm.form.doAction('submit',
            {
                url:'../../ASHX/Server/Upload_ServerList.ashx',
                method:'post',
                success:function(form,action)
                {
                    Ext.MessageBox.hide();
                    Ext.MessageBox.show(
                    {
                        title:'系统消息',
                        msg:action.result.data,//"批量导入成功！",
                        buttons:Ext.Msg.OK,
                        icon:Ext.MessageBox.INFO
                    });
                },
                failure:function(form,action)
                {
                    Ext.MessageBox.hide();
                    Ext.MessageBox.show(
                    {
                        title:'系统消息',
                        msg:action.result.data,//"批量导入失败！",
                        buttons:Ext.Msg.OK,
                        icon:Ext.MessageBox.ERROR
                    });
                }
            });
       } 
       else
       {
             Ext.MessageBox.hide();
             Ext.MessageBox.show({
                title:'系统消息',
                msg:'连接服务器尚未成功，请联系技术人员!',
                buttons:Ext.Msg.OK,
                icon:Ext.MessageBox.ERROR
             });   
       } 
   }
 mainForm.render(document.body); 
});