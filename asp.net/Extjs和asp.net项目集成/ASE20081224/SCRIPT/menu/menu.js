Ext.onReady(function(){
    Ext.QuickTips.init();
    var main_menu_width=960;
    //    var menuItem = new Ext.menu.Item({ text: 'New Item!' });

    function GetQueryString(name)
	{
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)","i");
        var r = window.location.search.substr(1).match(reg);
        if (r!=null) return unescape(r[2]); return null;
    }
  //  var usrID=GetQueryString('user');
    var server_menu = new Ext.menu.Menu(
    {
        id: 'server_menu'
    });
     var app_menu = new Ext.menu.Menu(
    {
        id: 'app_menu',
        items:
        [
            { text: '添加考勤申请', iconCls:'menu-option-css', handler:AddAppEvent},
            { text: '查看历史记录', iconCls:'menu-option-css', handler:ShowAppEvent}
        ]
    });
     var sr_menu = new Ext.menu.Menu(
    {
        id: 'sr_menu',
        items:
        [
            { text: '添加 SR', iconCls:'menu-option-css', handler:AddSREvent},
            { text: 'SR 分配', iconCls:'menu-option-css', handler:SRAllotEvent},
            { text: '查询修改', iconCls:'menu-option-css', handler:SRQueryModifyEvent},
            { text: '状态更新', iconCls:'menu-option-css', handler:SRUpdateStatusEvent}
        ]
    });
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
            if(json_data.POP_LIST_ADD==true)
            {
            
                         var item = server_menu.add(
                                { text: '新增服务器', iconCls:'menu-option-css', handler:AddServerEvent }
                            );
            }
            if( json_data.POP_LIST_QUERY==true)
            {
                            var item = server_menu.add(
                                { text: '服务器查询修改', iconCls:'menu-option-css', handler:ListServerEvent }
                            );
            }
            if(json_data.POP_UPLOAD_ADD==true)
            {
                            var item = server_menu.add(
                                { text: '服务器清单上传', iconCls:'menu-option-css', handler:UploadServerListEvent }
                            );
            }
            if(json_data.POP_LIST_DOWNLOAD==true)
            {
                            var item = server_menu.add(
                                { text: '服务器清单下载', iconCls:'menu-option-css', handler:DownServerEvent }
                            );
            }


        },
        failure: function(form,action)
        {
             Ext.MessageBox.hide();
             Ext.MessageBox.show({
             title:'错误',
             msg: '菜单初始化失败！',
             buttons: Ext.Msg.OK,
             icon: Ext.MessageBox.ERROR});
        }
    });
    var tb = new Ext.Toolbar(
	{
		width:main_menu_width,
		style:'margin:auto'
		
	});

    tb.render('menulist');

   function AddSREvent(item)
    {
        window.location.href="../../page/SR/AddSRList.aspx";
    }
  function SRQueryModifyEvent(item)
    {
        window.location.href="../../page/SR/QuerySRList.aspx";
    }
   function SRUpdateStatusEvent(item)
    {
        window.location.href="../../page/SR/UpdateSrStatus.aspx";
    }
   function SRAllotEvent(item)
    {
        window.location.href="../../page/SR/ListSrInfo.aspx";
    }
   function AddServerEvent(item)
    {
        window.location.href="../../page/Server/AddListServer.aspx";
    }
    function ListServerEvent(item)
    {
        window.location.href="../../page/Server/ListServerInfo.aspx";
    }
    function DownServerEvent(item)
    {
        window.location.href="../../page/Server/DownLoadToExcel.aspx";
    }
    function UploadServerListEvent(item)
    {
         window.location.href="../../page/Server/UploadServerList.aspx";
    }
    function AddAppEvent(item)
    {
        window.location.href="../../page/Application/AddApplication.aspx";
    }
    function ShowAppEvent(item)
    {
         window.location.href="../../page/Application/GetApplication.aspx";
    }
   tb.add({text:'服务器管理',iconCls:'menu-master-css',menu:server_menu});
   tb.add({text:'考勤管理',iconCls:'menu-master-css',menu:app_menu});  
   tb.add({text:'服务申请',iconCls:'menu-master-css',menu:sr_menu});  

});