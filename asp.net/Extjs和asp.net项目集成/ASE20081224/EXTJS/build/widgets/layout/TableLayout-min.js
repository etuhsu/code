/*
 * Ext JS Library 2.0.1
 * Copyright(c) 2006-2007, Ext JS, LLC.
 * licensing@extjs.com
 * 
 * http://extjs.com/license
 */


Ext.layout.TableLayout=Ext.extend(Ext.layout.ContainerLayout,{monitorResize:false,setContainer:function(ct){Ext.layout.TableLayout.superclass.setContainer.call(this,ct);this.currentRow=0;this.currentColumn=0;this.spanCells=[];},onLayout:function(ct,target){var cs=ct.items.items,len=cs.length,c,i;if(!this.table){target.addClass('x-table-layout-ct');this.table=target.createChild({tag:'table',cls:'x-table-layout',cellspacing:0,cn:{tag:'tbody'}},null,true);this.renderAll(ct,target);}},getRow:function(index){var row=this.table.tBodies[0].childNodes[index];if(!row){row=document.createElement('tr');this.table.tBodies[0].appendChild(row);}
return row;},getNextCell:function(c){var td=document.createElement('td'),row,colIndex;if(!this.columns){row=this.getRow(0);}else{colIndex=this.currentColumn;if(colIndex!==0&&(colIndex%this.columns===0)){this.currentRow++;colIndex=(c.colspan||1);}else{colIndex+=(c.colspan||1);}
var cell=this.getNextNonSpan(colIndex,this.currentRow);this.currentColumn=cell[0];if(cell[1]!=this.currentRow){this.currentRow=cell[1];if(c.colspan){this.currentColumn+=c.colspan-1;}}
row=this.getRow(this.currentRow);}
if(c.colspan){td.colSpan=c.colspan;}
td.className='x-table-layout-cell';if(c.rowspan){td.rowSpan=c.rowspan;var rowIndex=this.currentRow,colspan=c.colspan||1;for(var r=rowIndex+1;r<rowIndex+c.rowspan;r++){for(var col=this.currentColumn-colspan+1;col<=this.currentColumn;col++){if(!this.spanCells[col]){this.spanCells[col]=[];}
this.spanCells[col][r]=1;}}}
row.appendChild(td);return td;},getNextNonSpan:function(colIndex,rowIndex){var c=(colIndex<=this.columns?colIndex:this.columns),r=rowIndex;for(var i=c;i<=this.columns;i++){if(this.spanCells[i]&&this.spanCells[i][r]){if(++c>this.columns){return this.getNextNonSpan(1,++r);}}else{break;}}
return[c,r];},renderItem:function(c,position,target){if(c&&!c.rendered){c.render(this.getNextCell(c));}},isValidParent:function(c,target){return true;}});Ext.Container.LAYOUTS['table']=Ext.layout.TableLayout;