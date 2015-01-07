/*
 * Ext JS Library 2.0.1
 * Copyright(c) 2006-2007, Ext JS, LLC.
 * licensing@extjs.com
 * 
 * http://extjs.com/license
 */


Ext.layout.AbsoluteLayout=Ext.extend(Ext.layout.AnchorLayout,{extraCls:'x-abs-layout-item',onLayout:function(ct,target){target.position();Ext.layout.AbsoluteLayout.superclass.onLayout.call(this,ct,target);}});Ext.Container.LAYOUTS['absolute']=Ext.layout.AbsoluteLayout;