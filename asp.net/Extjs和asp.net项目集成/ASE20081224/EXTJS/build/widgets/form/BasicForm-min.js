/*
 * Ext JS Library 2.0.1
 * Copyright(c) 2006-2007, Ext JS, LLC.
 * licensing@extjs.com
 * 
 * http://extjs.com/license
 */


Ext.form.BasicForm=function(el,config){Ext.apply(this,config);this.items=new Ext.util.MixedCollection(false,function(o){return o.id||(o.id=Ext.id());});this.addEvents('beforeaction','actionfailed','actioncomplete');if(el){this.initEl(el);}
Ext.form.BasicForm.superclass.constructor.call(this);};Ext.extend(Ext.form.BasicForm,Ext.util.Observable,{timeout:30,activeAction:null,trackResetOnLoad:false,initEl:function(el){this.el=Ext.get(el);this.id=this.el.id||Ext.id();this.el.on('submit',this.onSubmit,this);this.el.addClass('x-form');},getEl:function(){return this.el;},onSubmit:function(e){e.stopEvent();},destroy:function(){this.items.each(function(f){Ext.destroy(f);});if(this.el){this.el.removeAllListeners();this.el.remove();}
this.purgeListeners();},isValid:function(){var valid=true;this.items.each(function(f){if(!f.validate()){valid=false;}});return valid;},isDirty:function(){var dirty=false;this.items.each(function(f){if(f.isDirty()){dirty=true;return false;}});return dirty;},doAction:function(action,options){if(typeof action=='string'){action=new Ext.form.Action.ACTION_TYPES[action](this,options);}
if(this.fireEvent('beforeaction',this,action)!==false){this.beforeAction(action);action.run.defer(100,action);}
return this;},submit:function(options){this.doAction('submit',options);return this;},load:function(options){this.doAction('load',options);return this;},updateRecord:function(record){record.beginEdit();var fs=record.fields;fs.each(function(f){var field=this.findField(f.name);if(field){record.set(f.name,field.getValue());}},this);record.endEdit();return this;},loadRecord:function(record){this.setValues(record.data);return this;},beforeAction:function(action){var o=action.options;if(o.waitMsg){if(this.waitMsgTarget===true){this.el.mask(o.waitMsg,'x-mask-loading');}else if(this.waitMsgTarget){this.waitMsgTarget=Ext.get(this.waitMsgTarget);this.waitMsgTarget.mask(o.waitMsg,'x-mask-loading');}else{Ext.MessageBox.wait(o.waitMsg,o.waitTitle||this.waitTitle||'Please Wait...');}}},afterAction:function(action,success){this.activeAction=null;var o=action.options;if(o.waitMsg){if(this.waitMsgTarget===true){this.el.unmask();}else if(this.waitMsgTarget){this.waitMsgTarget.unmask();}else{Ext.MessageBox.updateProgress(1);Ext.MessageBox.hide();}}
if(success){if(o.reset){this.reset();}
Ext.callback(o.success,o.scope,[this,action]);this.fireEvent('actioncomplete',this,action);}else{Ext.callback(o.failure,o.scope,[this,action]);this.fireEvent('actionfailed',this,action);}},findField:function(id){var field=this.items.get(id);if(!field){this.items.each(function(f){if(f.isFormField&&(f.dataIndex==id||f.id==id||f.getName()==id)){field=f;return false;}});}
return field||null;},markInvalid:function(errors){if(errors instanceof Array){for(var i=0,len=errors.length;i<len;i++){var fieldError=errors[i];var f=this.findField(fieldError.id);if(f){f.markInvalid(fieldError.msg);}}}else{var field,id;for(id in errors){if(typeof errors[id]!='function'&&(field=this.findField(id))){field.markInvalid(errors[id]);}}}
return this;},setValues:function(values){if(values instanceof Array){for(var i=0,len=values.length;i<len;i++){var v=values[i];var f=this.findField(v.id);if(f){f.setValue(v.value);if(this.trackResetOnLoad){f.originalValue=f.getValue();}}}}else{var field,id;for(id in values){if(typeof values[id]!='function'&&(field=this.findField(id))){field.setValue(values[id]);if(this.trackResetOnLoad){field.originalValue=field.getValue();}}}}
return this;},getValues:function(asString){var fs=Ext.lib.Ajax.serializeForm(this.el.dom);if(asString===true){return fs;}
return Ext.urlDecode(fs);},clearInvalid:function(){this.items.each(function(f){f.clearInvalid();});return this;},reset:function(){this.items.each(function(f){f.reset();});return this;},add:function(){this.items.addAll(Array.prototype.slice.call(arguments,0));return this;},remove:function(field){this.items.remove(field);return this;},render:function(){this.items.each(function(f){if(f.isFormField&&!f.rendered&&document.getElementById(f.id)){f.applyToMarkup(f.id);}});return this;},applyToFields:function(o){this.items.each(function(f){Ext.apply(f,o);});return this;},applyIfToFields:function(o){this.items.each(function(f){Ext.applyIf(f,o);});return this;}});Ext.BasicForm=Ext.form.BasicForm;