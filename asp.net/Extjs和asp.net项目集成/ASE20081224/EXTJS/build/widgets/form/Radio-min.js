/*
 * Ext JS Library 2.0.1
 * Copyright(c) 2006-2007, Ext JS, LLC.
 * licensing@extjs.com
 * 
 * http://extjs.com/license
 */


Ext.form.Radio=Ext.extend(Ext.form.Checkbox,{inputType:'radio',markInvalid:Ext.emptyFn,clearInvalid:Ext.emptyFn,getGroupValue:function(){var p=this.el.up('form')||Ext.getBody();return p.child('input[name='+this.el.dom.name+']:checked',true).value;},onClick:function(){if(this.el.dom.checked!=this.checked){var p=this.el.up('form')||Ext.getBody();var els=p.select('input[name='+this.el.dom.name+']');els.each(function(el){if(el.dom.id==this.id){this.setValue(true);}else{Ext.getCmp(el.dom.id).setValue(false);}},this);}}});Ext.reg('radio',Ext.form.Radio);