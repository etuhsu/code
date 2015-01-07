/*
 * Ext JS Library 2.0.1
 * Copyright(c) 2006-2007, Ext JS, LLC.
 * licensing@extjs.com
 * 
 * http://extjs.com/license
 */


Ext.form.Field=Ext.extend(Ext.BoxComponent,{invalidClass:"x-form-invalid",invalidText:"The value in this field is invalid",focusClass:"x-form-focus",validationEvent:"keyup",validateOnBlur:true,validationDelay:250,defaultAutoCreate:{tag:"input",type:"text",size:"20",autocomplete:"off"},fieldClass:"x-form-field",msgTarget:'qtip',msgFx:'normal',readOnly:false,disabled:false,isFormField:true,hasFocus:false,initComponent:function(){Ext.form.Field.superclass.initComponent.call(this);this.addEvents('focus','blur','specialkey','change','invalid','valid');},getName:function(){return this.rendered&&this.el.dom.name?this.el.dom.name:(this.hiddenName||'');},onRender:function(ct,position){Ext.form.Field.superclass.onRender.call(this,ct,position);if(!this.el){var cfg=this.getAutoCreate();if(!cfg.name){cfg.name=this.name||this.id;}
if(this.inputType){cfg.type=this.inputType;}
this.el=ct.createChild(cfg,position);}
var type=this.el.dom.type;if(type){if(type=='password'){type='text';}
this.el.addClass('x-form-'+type);}
if(this.readOnly){this.el.dom.readOnly=true;}
if(this.tabIndex!==undefined){this.el.dom.setAttribute('tabIndex',this.tabIndex);}
this.el.addClass([this.fieldClass,this.cls]);this.initValue();},initValue:function(){if(this.value!==undefined){this.setValue(this.value);}else if(this.el.dom.value.length>0){this.setValue(this.el.dom.value);}},isDirty:function(){if(this.disabled){return false;}
return String(this.getValue())!==String(this.originalValue);},afterRender:function(){Ext.form.Field.superclass.afterRender.call(this);this.initEvents();},fireKey:function(e){if(e.isSpecialKey()){this.fireEvent("specialkey",this,e);}},reset:function(){this.setValue(this.originalValue);this.clearInvalid();},initEvents:function(){this.el.on(Ext.isIE?"keydown":"keypress",this.fireKey,this);this.el.on("focus",this.onFocus,this);this.el.on("blur",this.onBlur,this);this.originalValue=this.getValue();},onFocus:function(){if(!Ext.isOpera&&this.focusClass){this.el.addClass(this.focusClass);}
if(!this.hasFocus){this.hasFocus=true;this.startValue=this.getValue();this.fireEvent("focus",this);}},beforeBlur:Ext.emptyFn,onBlur:function(){this.beforeBlur();if(!Ext.isOpera&&this.focusClass){this.el.removeClass(this.focusClass);}
this.hasFocus=false;if(this.validationEvent!==false&&this.validateOnBlur&&this.validationEvent!="blur"){this.validate();}
var v=this.getValue();if(String(v)!==String(this.startValue)){this.fireEvent('change',this,v,this.startValue);}
this.fireEvent("blur",this);},isValid:function(preventMark){if(this.disabled){return true;}
var restore=this.preventMark;this.preventMark=preventMark===true;var v=this.validateValue(this.processValue(this.getRawValue()));this.preventMark=restore;return v;},validate:function(){if(this.disabled||this.validateValue(this.processValue(this.getRawValue()))){this.clearInvalid();return true;}
return false;},processValue:function(value){return value;},validateValue:function(value){return true;},markInvalid:function(msg){if(!this.rendered||this.preventMark){return;}
this.el.addClass(this.invalidClass);msg=msg||this.invalidText;switch(this.msgTarget){case'qtip':this.el.dom.qtip=msg;this.el.dom.qclass='x-form-invalid-tip';if(Ext.QuickTips){Ext.QuickTips.enable();}
break;case'title':this.el.dom.title=msg;break;case'under':if(!this.errorEl){var elp=this.el.findParent('.x-form-element',5,true);this.errorEl=elp.createChild({cls:'x-form-invalid-msg'});this.errorEl.setWidth(elp.getWidth(true)-20);}
this.errorEl.update(msg);Ext.form.Field.msgFx[this.msgFx].show(this.errorEl,this);break;case'side':if(!this.errorIcon){var elp=this.el.findParent('.x-form-element',5,true);this.errorIcon=elp.createChild({cls:'x-form-invalid-icon'});}
this.alignErrorIcon();this.errorIcon.dom.qtip=msg;this.errorIcon.dom.qclass='x-form-invalid-tip';this.errorIcon.show();this.on('resize',this.alignErrorIcon,this);break;default:var t=Ext.getDom(this.msgTarget);t.innerHTML=msg;t.style.display=this.msgDisplay;break;}
this.fireEvent('invalid',this,msg);},alignErrorIcon:function(){this.errorIcon.alignTo(this.el,'tl-tr',[2,0]);},clearInvalid:function(){if(!this.rendered||this.preventMark){return;}
this.el.removeClass(this.invalidClass);switch(this.msgTarget){case'qtip':this.el.dom.qtip='';break;case'title':this.el.dom.title='';break;case'under':if(this.errorEl){Ext.form.Field.msgFx[this.msgFx].hide(this.errorEl,this);}
break;case'side':if(this.errorIcon){this.errorIcon.dom.qtip='';this.errorIcon.hide();this.un('resize',this.alignErrorIcon,this);}
break;default:var t=Ext.getDom(this.msgTarget);t.innerHTML='';t.style.display='none';break;}
this.fireEvent('valid',this);},getRawValue:function(){var v=this.rendered?this.el.getValue():Ext.value(this.value,'');if(v===this.emptyText){v='';}
return v;},getValue:function(){if(!this.rendered){return this.value;}
var v=this.el.getValue();if(v===this.emptyText||v===undefined){v='';}
return v;},setRawValue:function(v){return this.el.dom.value=(v===null||v===undefined?'':v);},setValue:function(v){this.value=v;if(this.rendered){this.el.dom.value=(v===null||v===undefined?'':v);this.validate();}},adjustSize:function(w,h){var s=Ext.form.Field.superclass.adjustSize.call(this,w,h);s.width=this.adjustWidth(this.el.dom.tagName,s.width);return s;},adjustWidth:function(tag,w){tag=tag.toLowerCase();if(typeof w=='number'&&!Ext.isSafari){if(Ext.isIE&&(tag=='input'||tag=='textarea')){if(tag=='input'&&!Ext.isStrict){return w-3;}
if(tag=='input'&&Ext.isStrict){return w-(Ext.isIE6?4:1);}
if(tag='textarea'&&Ext.isStrict){return w-2;}}else if(Ext.isOpera&&Ext.isStrict){if(tag=='input'){return w+2;}
if(tag='textarea'){return w-2;}}}
return w;}});Ext.form.Field.msgFx={normal:{show:function(msgEl,f){msgEl.setDisplayed('block');},hide:function(msgEl,f){msgEl.setDisplayed(false).update('');}},slide:{show:function(msgEl,f){msgEl.slideIn('t',{stopFx:true});},hide:function(msgEl,f){msgEl.slideOut('t',{stopFx:true,useDisplay:true});}},slideRight:{show:function(msgEl,f){msgEl.fixDisplay();msgEl.alignTo(f.el,'tl-tr');msgEl.slideIn('l',{stopFx:true});},hide:function(msgEl,f){msgEl.slideOut('l',{stopFx:true,useDisplay:true});}}};Ext.reg('field',Ext.form.Field);