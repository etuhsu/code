// JScript 文件
ALLEvents=function(node)
{
	
	//房间类型管理
    if(node.id==12 || node.id==22)
    {
       	RoomTypeManage(node);
    }
    //开房信息
    if(node.id==10 || node.id==20)
    {
        node.id=10;
        RoomOpenInfoManage(node);
    }
    //开设房间
    if(node.id==9 || node.id==19)
    {
        node.id=10;
        node.text="开房信息管理";
        AddGuestInfoWin.show();
        RoomOpenInfoManage(node);
        node.id=9;
    }
    //房间信息查看
    if(node.id==11 || node.id==21)
    {
        RoomManage(node);
    }
    //开房记录
    if(node.id==7)
    {
        OpenRoomRecordManage(node);
    }
    //酒店收入
    if(node.id==8)
    {
        TotalInfoManage(node);
    }
    //客人信息管理
    if(node.id==13 || node.id==23)
    {
        RoomGuestInfoManage(node);
    }
    //用户信息管理
    if(node.id==6)
    {
        UserRoleInfoManage(node);
    }
    //个人信息管理
    if(node.id==18)
    {
        EditUserPwdInfo(loginid);
    }
    
    //公告管理
    if(node.id==5)
    {
        PublishManage(node);
    }
}

//关闭TabPanel标签
Ext.ux.TabCloseMenu = function(){
      var tabs, menu, ctxItem;
      this.init = function(tp) {
         tabs = tp;
         tabs.on('contextmenu', onContextMenu);
      }
      function onContextMenu(ts, item, me) {
         if (!menu) { // create context menu on first right click
            menu = new Ext.menu.Menu([{
               id: tabs.id + '-close',
               text: '关闭当前标签',
               iconCls:"closetabone",
               handler : function() {
                  tabs.remove(ctxItem);
               }
            },{
               id: tabs.id + '-close-others',
               text: '除此之外全部关闭',
               iconCls:"closetaball",
               handler : function() {
                  tabs.items.each(function(item){
                     if(item.closable && item != ctxItem){
                        tabs.remove(item);
                     }
                  });
               }
            }]);
         }
         ctxItem = item;
         var items = menu.items;
         items.get(tabs.id + '-close').setDisabled(!item.closable);
         var disableOthers = true;
         tabs.items.each(function() {
            if (this != item && this.closable) {
               disableOthers = false;
               return false;
            }
         });
         items.get(tabs.id + '-close-others').setDisabled(disableOthers);
         menu.showAt(me.getXY());
      }
   };
   
   
//内容为Grid
GridMain=function(node,grid,icon){
    var tab = center.getItem(node.id);
	    if(!tab){
		   var tab = center.add({
			    id:node.id,
			    iconCls:icon,
			    
			    xtype:"panel",
			    title:node.text,
			    closable:true,
			    layout:"fit",
			    items:[grid]
			   
		    });
	    }
  center.setActiveTab(tab);
 }
 

