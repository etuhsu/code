/*
 * Ext JS Library 2.0.1
 * Copyright(c) 2006-2007, Ext JS, LLC.
 * licensing@extjs.com
 * 
 * http://extjs.com/license
 */


Ext.Container=Ext.extend(Ext.BoxComponent,{autoDestroy:true,defaultType:'panel',initComponent:function(){Ext.Container.superclass.initComponent.call(this);this.addEvents('afterlayout','beforeadd','beforeremove','add','remove');var items=this.items;if(items){delete this.items;if(items instanceof Array){this.add.apply(this,items);}else{this.add(items);}}},initItems:function(){if(!this.items){this.items=new Ext.util.MixedCollection(false,this.getComponentId);this.getLayout();}},setLayout:function(layout){if(this.layout&&this.layout!=layout){this.layout.setContainer(null);}
this.initItems();this.layout=layout;layout.setContainer(this);},render:function(){Ext.Container.superclass.render.apply(this,arguments);if(this.layout){if(typeof this.layout=='string'){this.layout=new Ext.Container.LAYOUTS[this.layout.toLowerCase()](this.layoutConfig);}
this.setLayout(this.layout);if(this.activeItem!==undefined){var item=this.activeItem;delete this.activeItem;this.layout.setActiveItem(item);return;}}
if(!this.ownerCt){this.doLayout();}
if(this.monitorResize===true){Ext.EventManager.onWindowResize(this.doLayout,this);}},getLayoutTarget:function(){return this.el;},getComponentId:function(comp){return comp.itemId||comp.id;},add:function(comp){if(!this.items){this.initItems();}
var a=arguments,len=a.length;if(len>1){for(var i=0;i<len;i++){this.add(a[i]);}
return;}
var c=this.lookupComponent(this.applyDefaults(comp));var pos=this.items.length;if(this.fireEvent('beforeadd',this,c,pos)!==false&&this.onBeforeAdd(c)!==false){this.items.add(c);c.ownerCt=this;this.fireEvent('add',this,c,pos);}
return c;},insert:function(index,comp){if(!this.items){this.initItems();}
var a=arguments,len=a.length;if(len>2){for(var i=len-1;i>=1;--i){this.insert(index,a[i]);}
return;}
var c=this.lookupComponent(this.applyDefaults(comp));if(c.ownerCt==this&&this.items.indexOf(c)<index){--index;}
if(this.fireEvent('beforeadd',this,c,index)!==false&&this.onBeforeAdd(c)!==false){this.items.insert(index,c);c.ownerCt=this;this.fireEvent('add',this,c,index);}
return c;},applyDefaults:function(c){if(this.defaults){if(typeof c=='string'){c=Ext.ComponentMgr.get(c);Ext.apply(c,this.defaults);}else if(!c.events){Ext.applyIf(c,this.defaults);}else{Ext.apply(c,this.defaults);}}
return c;},onBeforeAdd:function(item){if(item.ownerCt){item.ownerCt.remove(item,false);}
if(this.hideBorders===true){item.border=(item.border===true);}},remove:function(comp,autoDestroy){var c=this.getComponent(comp);if(c&&this.fireEvent('beforeremove',this,c)!==false){this.items.remove(c);delete c.ownerCt;if(autoDestroy===true||(autoDestroy!==false&&this.autoDestroy)){c.destroy();}
if(this.layout&&this.layout.activeItem==c){delete this.layout.activeItem;}
this.fireEvent('remove',this,c);}
return c;},getComponent:function(comp){if(typeof comp=='object'){return comp;}
return this.items.get(comp);},lookupComponent:function(comp){if(typeof comp=='string'){return Ext.ComponentMgr.get(comp);}else if(!comp.events){return this.createComponent(comp);}
return comp;},createComponent:function(config){return Ext.ComponentMgr.create(config,this.defaultType);},doLayout:function(){if(this.rendered&&this.layout){this.layout.layout();}
if(this.items){var cs=this.items.items;for(var i=0,len=cs.length;i<len;i++){var c=cs[i];if(c.doLayout){c.doLayout();}}}},getLayout:function(){if(!this.layout){var layout=new Ext.layout.ContainerLayout(this.layoutConfig);this.setLayout(layout);}
return this.layout;},onDestroy:function(){if(this.items){var cs=this.items.items;for(var i=0,len=cs.length;i<len;i++){Ext.destroy(cs[i]);}}
if(this.monitorResize){Ext.EventManager.removeResizeListener(this.doLayout,this);}
Ext.Container.superclass.onDestroy.call(this);},bubble:function(fn,scope,args){var p=this;while(p){if(fn.apply(scope||p,args||[p])===false){break;}
p=p.ownerCt;}},cascade:function(fn,scope,args){if(fn.apply(scope||this,args||[this])!==false){if(this.items){var cs=this.items.items;for(var i=0,len=cs.length;i<len;i++){if(cs[i].cascade){cs[i].cascade(fn,scope,args);}else{fn.apply(scope||this,args||[cs[i]]);}}}}},findById:function(id){var m,ct=this;this.cascade(function(c){if(ct!=c&&c.id===id){m=c;return false;}});return m||null;},findByType:function(xtype){return typeof xtype=='function'?this.findBy(function(c){return c.constructor===xtype;}):this.findBy(function(c){return c.constructor.xtype===xtype;});},find:function(prop,value){return this.findBy(function(c){return c[prop]===value;});},findBy:function(fn,scope){var m=[],ct=this;this.cascade(function(c){if(ct!=c&&fn.call(scope||c,c,ct)===true){m.push(c);}});return m;}});Ext.Container.LAYOUTS={};Ext.reg('container',Ext.Container);