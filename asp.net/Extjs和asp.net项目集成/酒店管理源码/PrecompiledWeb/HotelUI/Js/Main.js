//创建Tree
Ext.onReady
(
    function()
    {
        //实例化布局对象
        var view = new Ext.Viewport
        (
            {
                layout:'border', //声明为border布局
                items:
                [
                    //头部
                    new Ext.BoxComponent
                    (
                        {
                            region:'north',
                            el: 'north', //填充指定id的区域内容到north区域
                            height:65
                        }
                    ),
                    //底部
                    new Ext.BoxComponent
                    (
                        {
                            region:'south',
                            el: 'south', //填充指定id的区域内容到south区域
                            height:20
                        }
                    ),
                    //中间
                    {
                            region:'center',
                            el:'center',
                            height:405,
                            width:613,
                            title:'酒店开房详细信息',
                            html:"<div id='grid'></div>"
                    },
                    //左边
                    {
                            region:'west',
                            split:true,
                            margins:'0 0 0 0',
		                    layout:'accordion',
                            width:190,
                            el:'west', //填充指定id的区域内容到west区域
                            collapsible:true, 
                            title:'酒店管理菜单',
                            layoutConfig:
                            {
                                animate:true
                            },
                            items:
                            [
                                {
                                    title:'日常酒店管理',
                                    border:false,
                                    html:'<div id="tree1" style="overflow:auto;width:100%;height:100%"></div>'
                                },
                                {
                                    title:'信息中心',
                                    border:false,
                                    html:'<div id="tree2" style="overflow:auto;width:100%;height:100%"></div>'
                                }
                            ]
                    },
                    //右边
                    {
                            region:'east',
                            width:160,
                            collapsible:true, 
                            title:'今日房价',
                            html:"<div id='moneyGrid'></div>"
                    }
                ]
            }
        );
        //树形菜单
        var root = new Ext.tree.TreeNode
        (
            {
                id:'root',
                text:'树的根'    
            }
        );
        
        //第一个根节点
        var a = new Ext.tree.TreeNode
        (
            {
                id:'a',
                icon:'/HotelUI/Images/user3.gif',//图标文件
                text:'普通日常管理',
                expanded:true //展开显示                
            }
        ); 
        
        //创建第一个根节点的第一个子节点
        var a1 = new Ext.tree.TreeNode
        (
            {
                id:'a1',
                icon:'/HotelUI/Images/write.gif',//图标文件
                text:'新开房间',
                listeners:
                {
                    'click':function()
                            {
                                OpenRoom(); //调用新开房间方法
                            }
                }
            }
        );
           
        
        //创建第一个根节点的第三个子节点
        var a2 = new Ext.tree.TreeNode
        (
            {
                id:'a2',
                icon:'/HotelUI/Images/select.gif',//图标文件
                text:'查询账目信息',
                listeners:
                {
                    'click':function()
                            {
                                SerachMoney(); //调用查账方法
                            }
                }
            }
        );
        
        //添加子节点到第一个根节点
        a.appendChild(a1);
        a.appendChild(a2);
        
        //第二个根节点
        var b = new Ext.tree.TreeNode
        (
            {
                id:'b',
                icon:'/HotelUI/Images/user3.gif',//图标文件
                text:'高级日常管理',
                expanded:true //展开显示
            }
        );
        
        //第三个根节点
        var c = new Ext.tree.TreeNode
        (
            {
                id:'c',
                icon:'/HotelUI/Images/user.gif',//图标文件
                text:'员工管理',
                expanded:true //展开显示
            }
        );
        
        //第三个根节点的第一个子节点
        var c1 = new Ext.tree.TreeNode
        (
            {
                id:'c1',
                icon:'/HotelUI/Images/write.gif',//图标文件
                text:'添加普通员工',
                listeners:
                {
                    'click':function(node,event)
                            {
                                AddUser();
                            }
                }
            }
        );
        
        //第三个根节点的第二个子节点
        var c2 = new Ext.tree.TreeNode
        (
            {
                id:'c2',
                icon:'/HotelUI/Images/write2.gif',//图标文件
                text:'删除员工',
                listeners:
                {
                    'click':function(node,event)
                            {
                                DelUser();
                            }
                }
            }
        );
        
        //添加子节点到第三个根节点
        c.appendChild(c1);
        c.appendChild(c2);
        
        //第四个根节点
        var d = new Ext.tree.TreeNode
        (
            {
                id:'d',
                icon:'/HotelUI/Images/user.gif',//图标文件
                text:'房间类型管理',
                expanded:true //展开显示
            }
        );
        
        //第四个根节点的第一个子节点
        var d1 = new Ext.tree.TreeNode
        (
            {
                id:'d1',
                icon:'/HotelUI/Images/write.gif',//图标文件
                text:'添加房间类型',
                listeners:
                {
                    'click':function(node,event)
                            {
                                AddRoomType();
                            }
                }
            }
        );
        
        //第四个根节点的第二个子节点
        var d2 = new Ext.tree.TreeNode
        (
            {
                id:'d2',
                icon:'/HotelUI/Images/write2.gif',//图标文件
                text:'删除房间类型',
                listeners:
                {
                    'click':function(node,event)
                            {
                                DelRoomType();
                            }
                }
            }
        );
        
        //第四个根节点的第三个子节点
        var d3 = new Ext.tree.TreeNode
        (
            {
                id:'d3',
                icon:'/HotelUI/Images/select.gif',//图标文件
                text:'查看房间类型',
                listeners:
                {
                    'click':function(node,event)
                            {
                                SerachRoomType();
                            }
                }
            }
        );
        
        
        //添加子节点到第四个根节点
        d.appendChild(d1);
        d.appendChild(d2);
        d.appendChild(d3);
        
        //第五个根节点
        var e = new Ext.tree.TreeNode
        (
            {
                id:'e',
                icon:'/HotelUI/Images/user.gif',//图标文件
                text:'客房管理',
                expanded:true //展开显示
            }
        );
        
        //第五个根节点的第一个子节点
        var e1 = new Ext.tree.TreeNode
        (
            {
                id:'e1',
                icon:'/HotelUI/Images/write.gif',//图标文件
                text:'添加酒店客房',
                listeners:
                {
                    'click':function(node,event)
                            {
                                AddRoom();
                            }
                }
            }
        );
        
        //第五个根节点的第二个子节点
        var e2 = new Ext.tree.TreeNode
        (
            {
                id:'e2',
                icon:'/HotelUI/Images/write2.gif',//图标文件
                text:'删除酒店客房',
                listeners:
                {
                    'click':function(node,event)
                            {
                                DelRoom();
                            }
                }
            }
        );
        
        //第五个根节点的第三个子节点
        var e3 = new Ext.tree.TreeNode
        (
            {
                id:'e3',
                icon:'/HotelUI/Images/select.gif',//图标文件
                text:'查看酒店客房',
                listeners:
                {
                    'click':function(node,event)
                            {
                                SerachRoom();
                            }
                }
            }
        );
        
        
        
        //添加各自的子节点到对应的根节点
        e.appendChild(e1);
        e.appendChild(e2);
        e.appendChild(e3);
        
        b.appendChild(c);
        b.appendChild(d);
        b.appendChild(e);
        
        root.appendChild(a)
        root.appendChild(b)

        var tree = new Ext.tree.TreePanel
        (
            {
                renderTo:"tree1",
	            root:root, //对应的根节点
	            animate:true, //动态显示
	            enableDD:false, //支持拖放
	            border:false,
	            lines:true, //虚线
	            rootVisible:false, //显示根节点
	            containerScroll: true
            }
        );
    }
);

