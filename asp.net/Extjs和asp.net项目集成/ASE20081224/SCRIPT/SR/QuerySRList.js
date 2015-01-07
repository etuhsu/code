Ext.onReady(function() {
    Ext.QuickTips.init();
    var form = new Ext.form.BasicForm('form1');
    Ext.form.Field.prototype.msgTarget = 'side';
    var screen_width = 960;
    var main_form_width = 960;
    var Search_data;
    var sr_code = "";
    var sts_ds = new Ext.data.JsonStore(
   {
       fields: [
            { name: 'ID', type: 'string' },
            { name: 'NAME', type: 'string' }
        ]
   });
    var Sr_Record = Ext.data.Record.create(
     [

        { name: 'SR_ID', type: 'string' },
        { name: 'STS_ID', type: 'string' }
     ]);
    var ds = new Ext.data.GroupingStore({
        proxy: new Ext.data.HttpProxy({
            url: '../../ashx/SR/GetAllSRForModifyByOwner.ashx'
        }),
        reader: new Ext.data.JsonReader({
            root: 'LIST'
        },
        [
            { name: 'SR_ID', type: 'int' },
            { name: 'SR_CODE', type: 'string' },
            { name: 'SR_TITLE', type: 'string' },
            { name: 'SR_PROPOSER', type: 'string' },
            { name: 'SR_CLIENT', type: 'string' },

            { name: 'SR_IT_COST', type: 'string' },
            { name: 'SR_USER_BENEFIT', type: 'string' },
            { name: 'SR_OVERDATE', type: 'string' },
            { name: 'SR_PRO_FLAG', type: 'string' },
            { name: 'SR_SR_FLAG', type: 'string' },

            { name: 'SR_AR_FLAG', type: 'string' },
            { name: 'SR_DEMAND_DESC', type: 'string' },
            { name: 'DET_NAME', type: 'string' },
            { name: 'LEL_NAME', type: 'string' },
            { name: 'RAT_NAME', type: 'string' },

            { name: 'SYE_NAME', type: 'string' },
            { name: 'SR_CREATIONUID', type: 'string' },
            { name: 'SR_CREATE_DT', type: 'string' },
            { name: 'SR_UPDATEUID', type: 'string' },
            { name: 'SR_UPDATE_DT', type: 'string' }

       ])
    });
    ds.load();

    function dtColor(val) {
        return '<span><font style="color:green;">' + val + '</font></span>';
    }
    function typeShow(value, p, record) {
        if (record.get('SR_PRO_FLAG') == "true") {
            return '<span>Project</span>';
        }
        else if (record.get('SR_SR_FLAG') == "true") {
            return '<span> SR</span>';
        }
        else if (record.get('SR_AR_FLAG') == "true") {
            return '<span> AR</span>';
        }

    }


    var sm = new Ext.grid.RowSelectionModel({ singleSelect: true });
    var cm = new Ext.grid.ColumnModel(
    [
         new Ext.grid.RowNumberer(),
        { header: "编   码", sortable: true, dataIndex: 'SR_CODE', width: 50 },
        { header: "SR标题", sortable: true, dataIndex: 'SR_TITLE', width: 120 },
        { header: "申请人", sortable: true, dataIndex: 'SR_PROPOSER', width: 50 },
    // {header: "客  户",sortable:true,dataIndex:'SR_CLIENT',width:50},
        {header: "申请部门", sortable: true, dataIndex: 'DET_NAME', width: 50 },
    //   {header: "SR Level", sortable:true,dataIndex:'LEL_NAME',width:50},
        {header: "SR 分类", sortable: true, dataIndex: 'RAT_NAME', width: 50 },
        { header: "系统类型", sortable: true, dataIndex: 'SYE_NAME', width: 50 },

        { header: "创建人 ", sortable: true, dataIndex: 'SR_CREATIONUID', width: 50 },
        { header: "创建日期", sortable: true, dataIndex: 'SR_CREATE_DT', width: 80, renderer: dtColor },
        { header: "更新人 ", sortable: true, dataIndex: 'SR_UPDATEUID', width: 50 },
        { header: "更新日期", sortable: true, dataIndex: 'SR_UPDATE_DT', width: 80, renderer: dtColor }

     ]);
    var List_Grid = new Ext.grid.EditorGridPanel(
{
    cm: cm,
    sm: sm,
    style: 'margin:auto;',
    stripeRows: true,
    frame: true,
    store: ds,
    width: main_form_width,
    height: 460,
    tbar: ['-', {
        text: '查 询',
        iconCls: 'search-css',
        handler: ShowSearchDialog
    }, '-', { text: '修 改', iconCls: 'modify-css', handler: ModifySearchDialog }, '-'],

    viewConfig: { forceFit: true },
    loadMask: { msg: '正在装载数据...' },
    viewConfig:
       {
           forceFit: true
       },
    trackMouseOver: false
});

    function ModifySearchDialog() {
        var row = List_Grid.getSelectionModel().getSelected();
        if (row) {
            window.open('ModifySRList.aspx?SR_ID=' + row.get('SR_ID'), "_blank");
        }
    }
    var txt_app_name = new Ext.form.TextField(
   {
       fieldLabel: '姓  名',
       name: 'txt_app_name',
       id: 'txt_app_name',
       anchor: '95%'
   });
    var txt_app_type = new Ext.form.TextField(
   {
       fieldLabel: '工  号',
       name: 'txt_app_type',
       id: 'txt_app_type',
       anchor: '95%'
   });
    var txt_from_dt = new Ext.form.DateField(
    {
        id: 'txt_from_dt',
        name: 'txt_from_dt',
        fieldLabel: '开始日期',
        format: 'Y-m-d',
        anchor: '95%'
    });
    var txt_to_dt = new Ext.form.DateField(
    {
        id: 'txt_to_dt',
        name: 'txt_to_dt',
        fieldLabel: '结束日期',
        format: 'Y-m-d',
        anchor: '95%'
    });
    var is_disponse = new Ext.form.Checkbox(
 {
     fieldLabel: '已处理',
     id: 'is_disponse',
     name: 'is_disponse',
     checked: false
     // style:'margin:0px 0px 10px 0px;'
 });
    var SearchForm = new Ext.form.FormPanel(
    {
        id: 'SearchForm',
        name: 'SearchForm',
        labelWidth: 80,
        style: 'padding:20px,10px,20px,10px',
        labelAlgin: 'right',
        autoHeight: true,
        buttonAlign: 'center',
        frame: true,
        layout: 'form',
        items: [txt_app_name, txt_app_type, txt_from_dt, txt_to_dt, is_disponse]

    });
    function ShowSearchDialog() {
        var win;
        if (!win) {
            win = new Ext.Window(
            {
                buttonAlign: 'center',
                title: '搜索查询',
                xtype: 'window',
                closable: false,
                iconCls: 'menu-formgrid-css',
                modal: 'true',
                closeAction: 'hide',
                layout: 'fit',
                plain: true,
                width: main_form_width * 0.55,
                height: 260,
                items: [SearchForm],
                buttons:
            [{
                text: '查 询',
                id: 'btn_search',
                handler: function() {
                    Ext.Ajax.request(
                    {
                        url: '../../ashx/Application/QueryApplication.ashx',
                        method: 'POST',
                        params:
                            {//
                                NAME_ID: txt_app_name.getValue(),
                                DT_FROM: isNull(txt_from_dt.getValue()) ? txt_from_dt.getValue().format('Y-m-d') : "",
                                DT_TO: isNull(txt_to_dt.getValue()) ? txt_to_dt.getValue().format('Y-m-d') : "",
                                USER_ID: txt_app_type.getValue(),
                                isdisponse: is_disponse.getValue() ? 1 : 0

                            },
                        disableCaching: false,
                        success: function(result, request) {
                            ds.removeAll();
                            var Search_data = Ext.util.JSON.decode(result.responseText).LIST;
                            for (var i = 0; i < Search_data.length; i++) {
                                var p = new jsonRecord(
                                    {
                                        LEE_OTE_NAME: Search_data[i].LEE_OTE_NAME,
                                        LEE_OTE_CODE: Search_data[i].LEE_OTE_CODE,
                                        APP_ID: Search_data[i].APP_ID,
                                        APP_CAUSE: Search_data[i].APP_CAUSE,
                                        ATE_ID: Search_data[i].ATE_ID,
                                        ADS_CODE: Search_data[i].ADS_CODE,
                                        ADS_NAME: Search_data[i].ADS_NAME,
                                        APP_DATE: Search_data[i].APP_DATE,
                                        APP_FROM_TIME: Search_data[i].APP_FROM_TIME,
                                        APP_TO_TIME: Search_data[i].APP_TO_TIME,
                                        APP_NUM_TIME: Search_data[i].APP_NUM_TIME,
                                        USER_CNAME: Search_data[i].USER_CNAME,
                                        ATE_NAME: Search_data[i].ATE_NAME,
                                        USER_ID: Search_data[i].USER_ID,
                                        USER_DEPARTMENT: Search_data[i].USER_DEPARTMENT,
                                        USER_SHIFT: Search_data[i].USER_SHIFT,
                                        APP_CREATE_DT: Search_data[i].APP_CREATE_DT,
                                        APP_DISPOSED: Search_data[i].APP_DISPOSED
                                    });
                                ds.insert(0, p);
                            }
                            win.hide();
                        },
                        failure: function() {
                            Ext.MessageBox.hide();
                            Ext.MessageBox.show(
                                {
                                    title: '系统消息',
                                    msg: '查询失败！',
                                    buttons: Ext.Msg.OK,
                                    icon: Ext.MessageBox.ERROR
                                });
                        }
                    });
                }, //handler
                scope: this
            },
             {
                 text: ' 重 置 ',
                 handler: function() {
                     SearchForm.getForm().reset();
                 }
             },
             {
                 text: ' 关 闭 ',
                 handler: function() {
                     win.hide();
                 },
                 scope: this
}]//end  button
            }); //end win
        }
        win.show(this);
    }
    function comfirmFun() {
        Ext.MessageBox.show(
         {
             msg: '正在保存数据,请稍候...',
             progressText: '正在保存...',
             width: 300,
             wait: true,
             waitConfig: { interval: 200 }
         });
        var lst = new Array();

        for (var i = 0; i < ds.getCount(); i++) {
            if (isNoNull(ds.getAt(i).get('LSS_VALUES')) == false) {
                continue;
            }
            var p = new Sr_Record(
            {
                SR_ID: ds.getAt(i).get('SR_ID'),
                STS_ID: ds.getAt(i).get('LSS_VALUES')
            });
            lst.push(p);
        }
        if (isNoNull(lst) == false) {
            return;
        }
        alert(Ext.util.JSON.encode(lst));
        Ext.Ajax.request(
        {
            url: '../../ashx/SR/UpdateSrStatus.ashx',
            method: 'POST',
            params:
            {
                data: Ext.util.JSON.encode(lst)
            },
            disableCaching: false,
            success: function(result, request) {
                var json_msg = Ext.util.JSON.decode(result.responseText);
                Ext.MessageBox.hide();
                Ext.MessageBox.show({
                    title: '系统消息',
                    msg: json_msg.data,
                    buttons: Ext.Msg.OK,
                    icon: Ext.MessageBox.INFO
                });
            },
            failure: function() {
                Ext.MessageBox.hide();
                Ext.MessageBox.show({
                    title: '系统消息',
                    msg: '提交失败！',
                    buttons: Ext.Msg.OK,
                    icon: Ext.MessageBox.ERROR
                });
            }
        });

    }


    List_Grid.render(document.body);


    function isNoNull(str) {
        if (str == null || str == "" || str == 'undefined') {
            return false;
        }
        else {
            return true;
        }
    }
});