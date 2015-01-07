/*
 * Ext JS Library 2.0.1
 * Copyright(c) 2006-2007, Ext JS, LLC.
 * licensing@extjs.com
 * 
 * http://extjs.com/license
 */


Ext.CycleButton=Ext.extend(Ext.SplitButton,{getItemText:function(item){if(item&&this.showText===true){var text='';if(this.prependText){text+=this.prependText;}
text+=item.text;return text;}
return undefined;},setActiveItem:function(item,suppressEvent){if(item){if(!this.rendered){this.text=this.getItemText(item);this.iconCls=item.iconCls;}else{var t=this.getItemText(item);if(t){this.setText(t);}
this.setIconClass(item.iconCls);}
this.activeItem=item;if(!suppressEvent){this.fireEvent('change',this,item);}}},getActiveItem:function(){return this.activeItem;},initComponent:function(){this.addEvents("change");if(this.changeHandler){this.on('change',this.changeHandler,this.scope||this);delete this.changeHandler;}
this.itemCount=this.items.length;this.menu={cls:'x-cycle-menu',items:[]};var checked;for(var i=0,len=this.itemCount;i<len;i++){var item=this.items[i];item.group=item.group||this.id;item.itemIndex=i;item.checkHandler=this.checkHandler;item.scope=this;item.checked=item.checked||false;this.menu.items.push(item);if(item.checked){checked=item;}}
this.setActiveItem(checked,true);Ext.CycleButton.superclass.initComponent.call(this);this.on('click',this.toggleSelected,this);},checkHandler:function(item,pressed){if(pressed){this.setActiveItem(item);}},toggleSelected:function(){this.menu.render();var nextIdx,checkItem;for(var i=1;i<this.itemCount;i++){nextIdx=(this.activeItem.itemIndex+i)%this.itemCount;checkItem=this.menu.items.itemAt(nextIdx);if(!checkItem.disabled){checkItem.setChecked(true);break;}}}});Ext.reg('cycle',Ext.CycleButton);