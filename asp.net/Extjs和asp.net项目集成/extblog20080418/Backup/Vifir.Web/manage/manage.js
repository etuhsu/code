 Ext.BLANK_IMAGE_URL = '../plugins/extjs/ext-2.0/resources/images/default/s.gif';
 Ext.QuickTips.init();
Global = {
	topicCategoryLoader : new Ext.tree.TreeLoader( {
		url : "TopicCategory.aspx?cmd=GetCategory&PageSize=-1&treeData=true",
		listeners : {
			'beforeload' : function(treeLoader, node) {
				treeLoader.baseParams.id = (node.id != 'root' ? node.id : "");
			}
		}
	}),
	albumCategoryLoader : new Ext.tree.TreeLoader( {
		url : "AlbumCategory.aspx?cmd=GetCategory&PageSize=-1&treeData=true",
		listeners : {
			'beforeload' : function(treeLoader, node) {
				treeLoader.baseParams.id = (node.id != 'root' ? node.id : "");
			}
		}
	})
};

OtherMenuPanel = function() {
	OtherMenuPanel.superclass.constructor.call(this, {
		autoScroll : true,
		animate : true,
		border : false,
		rootVisible : false,
		root : new Ext.tree.TreeNode( {
			text : '其它管理菜单',
			draggable : false,
			expanded : true
		})
	});
	this.root.appendChild(new Ext.tree.TreeNode( {
		text : "评论管理",
		listeners : {
			'click' : function() {
				var panel = Ext.getCmp("commentPanel");
				if (!panel) {
					panel = new CommentPanel();
				}
				main.openTab(panel);
			}
		}
	}));
	this.root.appendChild(new Ext.tree.TreeNode( {
		text : "用户管理",
		listeners : {
			'click' : function() {
				var panel = Ext.getCmp("userPanel");
				if (!panel) {
					panel = new UserPanel( {});
				}
				main.openTab(panel);
			}
		}
	}));
	this.root.appendChild(new Ext.tree.TreeNode( {
		text : "友情连接管理",
		listeners : {
			'click' : function() {
				var panel = Ext.getCmp("linkPanel");
				if (!panel) {
					panel = new LinkPanel();
				}
				main.openTab(panel);
			}
		}
	}));
	this.root.appendChild(new Ext.tree.TreeNode( {
		text : "Blog属性设置",
		listeners : {
			'click' : function() {
				var panel = Ext.getCmp("blogPropertiesPanel");
				if (!panel) {
					panel = new BlogProperties();
				}
				main.openTab(panel);
			}
		}
	}));
	this.root.appendChild(new Ext.tree.TreeNode( {
		text : "系统文档",
		href:"http://www.vifir.com/tobeVIP.html",
		hrefTarget:"_blank"
	}));
	this.root.appendChild(new Ext.tree.TreeNode( {
		text : "该blog源码下载",
		href:"http://www.51aspx.com/CV/ExtJsBlog",
		hrefTarget:"_blank"
	}));
}
Ext.extend(OtherMenuPanel, Ext.tree.TreePanel);

MenuPanel = function() {
	MenuPanel.superclass.constructor.call(this, {
		id : 'menu',
		region : 'west',
		title : "系统菜单",
		split : true,
		width : 200,
		minSize : 175,
		maxSize : 500,
		collapsible : true,
		margins : '0 0 5 5',
		cmargins : '0 0 0 0',		
		layout : "accordion",
		layoutConfig : {
				titleCollapse : true,
				animate : true
			},
			items : [ {
				title : "日志管理",
				items : [new TopicMenuPanel()]
			}, {
				title : "相册管理",
				items : [new AlbumMenuPanel()]
			}, {
				title : "其它信息管理",
				items : [new OtherMenuPanel()]
			}]
		});
};
Ext.extend(MenuPanel, Ext.Panel);
MainPanel = function() {
	this.openTab = function(panel, id) {
		var o = (typeof panel == "string" ? panel : id || panel.id);
		var tab = this.getComponent(o);		
		if (tab) {
			this.setActiveTab(tab);
		} else if(typeof panel!="string"){
			panel.id = o;
			var p = this.add(panel);
			this.setActiveTab(p);
		}
	};
	this.closeTab = function(panel, id) {
		var o = (typeof panel == "string" ? panel : id || panel.id);
		var tab = this.getComponent(o);
		if (tab) {
			this.remove(tab);
		}
	};
	MainPanel.superclass.constructor.call(this, {
		id : 'main',
		region : 'center',
		margins : '0 5 5 0',
		resizeTabs : true,
		minTabWidth : 135,
		tabWidth : 135,
		enableTabScroll : true,
		activeTab : 0,
		items : {
			id : 'homePage',
			title : '主页',
			closable : false,
			autoLoad : {
				url : 'Default.aspx'
			},
			autoScroll : true,
			tbar : ['该系统是一个使用Ext+.Net+NHbernate+Spring.Net技术构建的Ajax应用示例，如果您对本系统所使用的技术感兴趣，',{text:'请与我们联系!',pressed: true,handler:function(){window.open("http://www.vifir.com/")}}]
		}
	});
};
Ext.extend(MainPanel, Ext.TabPanel);
var main, menu, header;
Ext.onReady(function() {
			header = new Ext.Panel( {
				border : true,
				region : 'north',
				height : 70,
				items : [{
					layout : "column",
					border : false,
					defaults : {
						border : false,
						bodyStyle : 'padding-top:6px'
					},
					items : [
							{
								columnWidth : .24,
								html : '<a href=http://www.51aspx.com/CV/ExtJsBlog target=_blank title="下载该源码"><img src="../images/logo.gif" border=0 /></a>'
							},
							{
								columnWidth : .6,
								html : '<a href=http://www.vifir.com target=_blank><img src="../images/title.jpg" width="600" border=0/></a>'
							},
							{
								columnWidth : .16,
								cls : 'link',
								html : '<a style="background:url(../images/user.gif) no-repeat left top; padding:3px 0 0 18px;" href="../Portal.aspx?cmd=adminLogout">注销用户</a>&nbsp;'
										+ '<a style="background:url(../images/key.gif) no-repeat left top; padding:3px 0 0 17px;" href="#">更改密码</a><br />'
										+ '<a style="background:url(../images/home.gif) no-repeat left top; padding:4px 0 0 18px;" href="Default.aspx">返回首页</a>&nbsp;'
										+ '<select onchange="changeSkin(this.value)">'
										+ '<option value="ext-all">默认风格</option>'
										+ '<option value="xtheme-gray">银白风格</option>'
										+ '<option value="xtheme-purple">紫色风格</option>'
										+ '<option value="xtheme-olive">绿色风格</option>'
										+ '<option value="xtheme-darkgray">灰色风格</option>'
										+ '<option value="xtheme-black">黑色风格</option>'
										+ '<option value="xtheme-slate">深蓝风格</option>'
										+ '</select>'
							}]
				}]
			});
			changeSkin = function(value) {
				Ext.util.CSS
						.swapStyleSheet('window',
								'../plugins/extjs/ext-2.0/resources/css/' + value
										+ '.css');
			};
			menu = new MenuPanel();
			main = new MainPanel();
			var viewport = new Ext.Viewport( {
				layout : 'border',
				items : [header, menu, main]
			});

			setTimeout(function() {
				Ext.get('loading').remove();
				Ext.get('loading-mask').fadeOut( {
					remove : true
				});
			}, 300);
		})
