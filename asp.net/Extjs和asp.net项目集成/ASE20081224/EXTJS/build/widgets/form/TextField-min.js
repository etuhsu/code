/*
 * Ext JS Library 2.0.1
 * Copyright(c) 2006-2007, Ext JS, LLC.
 * licensing@extjs.com
 * 
 * http://extjs.com/license
 */


Ext.form.TextField=Ext.extend(Ext.form.Field,{grow:false,growMin:30,growMax:800,vtype:null,maskRe:null,disableKeyFilter:false,allowBlank:true,minLength:0,maxLength:Number.MAX_VALUE,minLengthText:"The minimum length for this field is {0}",maxLengthText:"The maximum length for this field is {0}",selectOnFocus:false,blankText:"This field is required",validator:null,regex:null,regexText:"",emptyText:null,emptyClass:'x-form-empty-field',initComponent:function(){Ext.form.TextField.superclass.initComponent.call(this);this.addEvents('autosize');},initEvents:function(){Ext.form.TextField.superclass.initEvents.call(this);if(this.validationEvent=='keyup'){this.validationTask=new Ext.util.DelayedTask(this.validate,this);this.el.on('keyup',this.filterValidation,this);}
else if(this.validationEvent!==false){this.el.on(this.validationEvent,this.validate,this,{buffer:this.validationDelay});}
if(this.selectOnFocus||this.emptyText){this.on("focus",this.preFocus,this);if(this.emptyText){this.on('blur',this.postBlur,this);this.applyEmptyText();}}
if(this.maskRe||(this.vtype&&this.disableKeyFilter!==true&&(this.maskRe=Ext.form.VTypes[this.vtype+'Mask']))){this.el.on("keypress",this.filterKeys,this);}
if(this.grow){this.el.on("keyup",this.onKeyUp,this,{buffer:50});this.el.on("click",this.autoSize,this);}},processValue:function(value){if(this.stripCharsRe){var newValue=value.replace(this.stripCharsRe,'');if(newValue!==value){this.setRawValue(newValue);return newValue;}}
return value;},filterValidation:function(e){if(!e.isNavKeyPress()){this.validationTask.delay(this.validationDelay);}},onKeyUp:function(e){if(!e.isNavKeyPress()){this.autoSize();}},reset:function(){Ext.form.TextField.superclass.reset.call(this);this.applyEmptyText();},applyEmptyText:function(){if(this.rendered&&this.emptyText&&this.getRawValue().length<1){this.setRawValue(this.emptyText);this.el.addClass(this.emptyClass);}},preFocus:function(){if(this.emptyText){if(this.el.dom.value==this.emptyText){this.setRawValue('');}
this.el.removeClass(this.emptyClass);}
if(this.selectOnFocus){this.el.dom.select();}},postBlur:function(){this.applyEmptyText();},filterKeys:function(e){var k=e.getKey();if(!Ext.isIE&&(e.isNavKeyPress()||k==e.BACKSPACE||(k==e.DELETE&&e.button==-1))){return;}
var c=e.getCharCode(),cc=String.fromCharCode(c);if(Ext.isIE&&(e.isSpecialKey()||!cc)){return;}
if(!this.maskRe.test(cc)){e.stopEvent();}},setValue:function(v){if(this.emptyText&&this.el&&v!==undefined&&v!==null&&v!==''){this.el.removeClass(this.emptyClass);}
Ext.form.TextField.superclass.setValue.apply(this,arguments);this.applyEmptyText();this.autoSize();},validateValue:function(value){if(value.length<1||value===this.emptyText){if(this.allowBlank){this.clearInvalid();return true;}else{this.markInvalid(this.blankText);return false;}}
if(value.length<this.minLength){this.markInvalid(String.format(this.minLengthText,this.minLength));return false;}
if(value.length>this.maxLength){this.markInvalid(String.format(this.maxLengthText,this.maxLength));return false;}
if(this.vtype){var vt=Ext.form.VTypes;if(!vt[this.vtype](value,this)){this.markInvalid(this.vtypeText||vt[this.vtype+'Text']);return false;}}
if(typeof this.validator=="function"){var msg=this.validator(value);if(msg!==true){this.markInvalid(msg);return false;}}
if(this.regex&&!this.regex.test(value)){this.markInvalid(this.regexText);return false;}
return true;},selectText:function(start,end){var v=this.getRawValue();if(v.length>0){start=start===undefined?0:start;end=end===undefined?v.length:end;var d=this.el.dom;if(d.setSelectionRange){d.setSelectionRange(start,end);}else if(d.createTextRange){var range=d.createTextRange();range.moveStart("character",start);range.moveEnd("character",end-v.length);range.select();}}},autoSize:function(){if(!this.grow||!this.rendered){return;}
if(!this.metrics){this.metrics=Ext.util.TextMetrics.createInstance(this.el);}
var el=this.el;var v=el.dom.value;var d=document.createElement('div');d.appendChild(document.createTextNode(v));v=d.innerHTML;d=null;v+="&#160;";var w=Math.min(this.growMax,Math.max(this.metrics.getWidth(v)+10,this.growMin));this.el.setWidth(w);this.fireEvent("autosize",this,w);}});Ext.reg('textfield',Ext.form.TextField);