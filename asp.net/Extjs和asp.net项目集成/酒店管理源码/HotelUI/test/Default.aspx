<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="test_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/HotelUI/Css/main.css" rel="stylesheet" type="text/css" />
    <link href="/HotelUI/Ext/resources/css/ext-all.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/HotelUI/Ext/adapter/ext/ext-base.js"></script>

    <script type="text/javascript" src="/HotelUI/Ext/ext-all.js"></script>

    <script type="text/javascript" src="/HotelUI/Ext/ext-lang-zh_CN.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div id='grid'>
    </div>

    <script type="text/javascript">
        ///<reference path="vswd-ext_2.2.js"/>
        ///<reference path="jquery-1.3.2-vsdoc2.js"/>

        var storeMain = new Ext.data.Store
(
    {
        //表示从哪里获得数据
        proxy: new Ext.data.HttpProxy
        (
            {
                url: '/HotelUI/Json/MainGrid.aspx'
            }
        ),

        //解析Json
        reader: new Ext.data.JsonReader
        (
            {
                root: 'data',
                id: 'OpenRoomId',
                fields:
                [
                    'OpenRoomId', 'Number', 'TypeName', 'TypePrice', 'OpenTime', 'GuestMoney', 'GuestNumber', 'GuestName', 'Remark'
                ]
            }
        ),
        remoteSort: true
    }
);


function SerachGrid() {
    var message = Ext.get('title').dom.value;
    storeMain.reload
    (
        {
            params: { msg: message }
        }
    )
    }
        Ext.onReady(
            function() {
                var colmod = new Ext.grid.ColumnModel
                 (
                     [
                     { header: "房间号", width: 60, dataIndex: 'Number' },
                        { header: "备注", width: 120, dataIndex: 'Remark' }
                     ]
                 )

                var grid = new Ext.grid.GridPanel
                    (
                        {
                            renderTo: 'grid',
                            height: 500,
                            width: 665,
                            cm: colmod,
                            store: storeMain,
                            trackMouseOver: true,
                            loadMask: true,
                            autoShow: true,
                            autoScroll: true,
                            //头部
                            tbar:
                        [
                            '房间查询',
                            { xtype: 'textfield', width: 170, id: 'title', name: 'title' },
                            { text: '搜索', iconCls: 'search', handler: SerachGrid },
                            { xtype: 'tbseparator' }
                        ]
                        }
                    )

            }

    );

    </script>

    </form>
</body>
</html>
