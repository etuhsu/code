
var strRowErr="请检查行数!";
var strColErr="请检查列数!";
//判断是否INT类型
function checkInt(str)
{
    if(str==null||str==""||isNaN(str))
    {
        return 0;
    }
    else
    {
        str=parseInt(str);
        if(str<1)
        {
            return 0;
        }  
    }
    return str;
}
//判断是否数字类型
function checkNum(str)
{
    if(str==null||str==""||isNaN(str))
    {
        return 0;
    }
    return str;
}
function checkStr(str,def)
{
    if(str==null||str=="")
    {
        return(def);
    }
    return(str);
}
function JGraphics()
{
    this.ac="green,yellow,red,blue,gray,#f7f7f7".split(",")
    this.ac="#FF0000,#00FF00,#0000FF,#FFFF00,#00FFFF,#FF00FF,#333333,#666666,#999999,#cccccc".split(",")

    this.getCss=function(css,k,df){
        if(css==null)
            return df==null ? "" : df
        var r=new RegExp("(^|)"+k+":([^\;]*)(\;|$)","gi")
        var a=r.exec(css.replace(/=/g,":").replace(/ /g,"").toLowerCase())
        return a==null ? (df==null ? "" : df) : (isNaN(a[2])||a[2]=="" ? a[2] : parseInt(a[2]))
    }
    /*画柱状图
    colNames：
    data：
    colors：
    css：
    */
    this.bar=function(colNames,data,step,colors,css)
    {
        var result="";
        var max_height=0;
        var row_height=40;
        
        var chart_width=this.getCss(css,"width",600);
        var chart_height=this.getCss(css,"height",500);
        
        var col_headers=colNames.split(",");
        if(chart_width<150||chart_height<150)
        {
            alert("图表区域太小，中断输出！");
            return;
        }
        
        var rows=data.split(";");
        
        //获取数据中最大的数据值
        for(var i=0;i<rows.length;i++)
        {
            var cols=rows[i].split(",");
            for(var j=0;j<cols.length;j++)
            {
                if(j>0)
                {
                    if(parseInt(cols[j])>max_height)
                    {
                        max_height=parseInt(cols[j]);
                    }
                }
            }
        }
        var hsz=(chart_height-100)/max_height;
        var max_width=(data.length-data.replace(/;/g,"").replace(/,/g,"").length)*30+20;
        if(chart_width<max_width)
        {
            chart_width=max_width;
        }
       // alert(chart_width);
        //开始设置柱状图背景
        result+="<v:rect fillcolor='"+this.getCss(css,"background","white")+"' style='position:absolute;left:0;top:0;width:"+chart_width+";height:"+chart_height+"'><v:shadow on=t type=emboss opacity=80% offset='3px,3px' offset2='5px,5px' /></v:rect>";
        result+="<v:line from=40,"+(chart_height-30)+" to="+40+","+10+"><v:stroke startarrow=none endarrow=classic /></v:line>";
        result+="<v:line from=40,"+(chart_height-30)+" to="+(chart_width-10)+","+(chart_height-30)+"><v:stroke startarrow=none endarrow=classic /></v:line>";
        result+="<span style='position:absolute;z-index:3;font:12;left:220;top:10'>"+col_headers[0]+"</span>";
        result+="<span style='position:absolute;z-index:3;font:12;left:"+(chart_width-50)+";top:"+(chart_height-20)+"'>"+col_headers[1]+"</span>";
        result+="<span style='position:absolute;z-index:3;font:12;left:10;top:10;width:5;word-break:break-all'>"+col_headers[2]+"</span>";
        
        for(i=0;i<step;i++){
            result+="<v:line from="+40+","+(70+i*(chart_height-100)/step)+" to="+(chart_width-10)+","+(70+i*(chart_height-100)/step)+" strokecolor=#c0c0c0><v:stroke dashstyle=dash /></v:line>";
            result+="<span style='position:absolute;z-index:3;font:12;left:"+10+";top:"+(65+i*(chart_height-100)/step)+"'>"+(parseInt(max_height)*(step-i)/step)+"</span>";
        }
        for(i=3;i<col_headers.length;i++)
        {
            result+="<v:rect fillcolor='"+colors[i-3]+"' style='position:absolute;left:"+((i-2)*80-20)+";top:30;width:20;height:20' />";
            result+="<span style='position:absolute;z-index:3;font:12;left:"+((i-2)*80+5)+";top:35'>"+col_headers[i]+"</span>";
        }
        
        for(var i=0;i<rows.length;i++)
        {
            var cols=rows[i].split(",");
            for(var j=0;j<cols.length;j++)
            {
                if(j>0)
                {
                    var ch=cols[j]*hsz;
                    result+="<v:rect title='"+cols[j]+"' fillcolor='"+colors[j-1]+"' style='position:absolute;left:"+row_height+";top:"+(chart_height-30-ch)+";width:20;height:"+ch+"' />";
                    if(this.getCss(css,"showVal")=="t")
                    {
                        result+="<span style='position:absolute;z-index:3;font:12;left:"+(row_height+3)+";top:"+(chart_height-42-ch)+"'>"+cols[j]+"</span>";
                    }
                    row_height+=20;
                }
                else
                {
                    result+="<span style='position:absolute;z-index:3;font:12;left:"+row_height+";top:"+(chart_height-25)+"'>"+cols[j]+"</span>";
                    
                }
            }
            row_height+=20;
        }
        return result;
    }
    //波形图
    this.wave=function(colNames,data,step,colors,css)
    {
        var result="";
        var max_height=0;
        var row_height=40;
        
        var chart_width=this.getCss(css,"width",600);
        var chart_height=this.getCss(css,"height",500);
        
        var col_headers=colNames.split(",");
        if(chart_width<150||chart_height<150)
        {
            alert("图表区域太小，中断输出！");
            return;
        }
        
        var rows=data.split(";");
        
        //获取数据中最大的数据值
        for(var i=0;i<rows.length;i++)
        {
            var cols=rows[i].split(",");
            for(var j=0;j<cols.length;j++)
            {
                if(j>0)
                {
                    if(parseInt(cols[j])>max_height)
                    {
                        max_height=parseInt(cols[j]);
                    }
                }
            }
        }
        var hsz=(chart_height-100)/max_height;
        var max_width=(data.length-data.replace(/;/g,"").replace(/,/g,"").length)*20+40;
    //    var max_width=data.length*30+40;
        
        if(chart_width<max_width)
        {
            chart_width=max_width;
        }
        
        result+="<v:rect fillcolor='"+this.getCss(css,"background","white")+"' style='position:absolute;left:0;top:0;width:"+chart_width+";height:"+chart_height+"'><v:shadow on=t type=emboss opacity=80% offset='3px,3px' offset2='5px,5px' /></v:rect>";
        result+="<v:line from=40,"+(chart_height-30)+" to="+40+","+10+"><v:stroke startarrow=none endarrow=classic /></v:line>";
        result+="<v:line from=40,"+(chart_height-30)+" to="+(chart_width-10)+","+(chart_height-30)+"><v:stroke startarrow=none endarrow=classic /></v:line>";
        result+="<span style='position:absolute;z-index:3;font:12;left:220;top:10'>"+col_headers[0]+"</span>";
        result+="<span style='position:absolute;z-index:3;font:12;left:"+(chart_width-50)+";top:"+(chart_height-20)+"'>"+col_headers[1]+"</span>";
        result+="<span style='position:absolute;z-index:3;font:12;left:10;top:10;width:5;word-break:break-all'>"+col_headers[2]+"</span>";
        
        for(i=0;i<step;i++){
            result+="<v:line from="+40+","+(70+i*(chart_height-100)/step)+" to="+(chart_width-10)+","+(70+i*(chart_height-100)/step)+" strokecolor=#c0c0c0><v:stroke dashstyle=dash /></v:line>";
            result+="<span style='position:absolute;z-index:3;font:12;left:"+10+";top:"+(65+i*(chart_height-100)/step)+"'>"+(parseInt(max_height)*(step-i)/step)+"</span>";
        }
        for(i=3;i<col_headers.length;i++)
        {
            result+="<v:rect fillcolor='"+colors[i-3]+"' style='position:absolute;left:"+((i-2)*80-20)+";top:30;width:20;height:20' />";
            result+="<span style='position:absolute;z-index:3;font:12;left:"+((i-2)*80+5)+";top:35'>"+col_headers[i]+"</span>";
        }
        
        for(var i=0;i<rows.length;i++)
        {
            var cols=rows[i].split(",");
            for(var j=0;j<cols.length;j++)
            {
                if(j>0)
                {
                    var ch=cols[j]*hsz;
                    if(i>=1)
                    {//绘制数据点之间的连线
                        var tmp=rows[i-1].split(",");
                        var oh=parseInt(tmp[j]*hsz);
                        result+="<v:line from="+(i*40)+","+(chart_height-oh-30)+" to="+((i+1)*40)+","+(chart_height-ch-30)+" strokecolor='"+colors[j-1]+"' />"//数据折线
                    }
                    result+="<v:rect title='"+cols[j]+"' fillcolor='"+colors[j-1]+"' style='z-index:3;position:absolute;left:"+((i+1)*40-1)+";top:"+(chart_height-ch-31)+";width:3;height:"+3+"' />"//数据点
                    if(this.getCss(css,"showVal")=="t")
                    {
                        result+="<span style='position:absolute;z-index:3;font:12;left:"+(i*40-5)+";top:"+(row_height-ch-42)+"'>"+cols[j]+"</span>"//数据值
                    }
                }
                else
                {//横坐标标刻
                    result+="<span style='position:absolute;z-index:3;font:12;left:"+((i+1)*40)+";top:"+(chart_height-25)+"'>"+cols[j]+"</span>";   
                }
                //绘制网格
                result+="<v:line from="+((i+1)*40)+","+(chart_height-30)+" to="+((i+1)*40)+","+10+" strokecolor=#c0c0c0><v:stroke dashstyle=dash /></v:line>"
            }
        }
        return result;
    }
    ///饼状图
    this.pie=function(colNames,data,step,colors,css)
    {
        var result="";
        var max_height=0;
        var row_height=0;
        var dx=0;//补充间距
        var circle=0;//圆周
        var chart_width=this.getCss(css,"width",680);
        var chart_height=this.getCss(css,"height",500);
        
        var col_headers=colNames.split(",");
        if(chart_width<150||chart_height<150)
        {
            alert("图表区域太小，中断输出！");
            return;
        }
        
        var rows=data.split(";");
     
        var max_width=rows.length*170;
        if(chart_width<max_width)
        {
            chart_width=max_width;
        }
        
        result+="<v:rect fillcolor='"+this.getCss(css,"background","white")+"' style='position:absolute;left:0;top:0;width:"+chart_width+";height:"+chart_height+"'><v:shadow on=t type=emboss opacity=80% offset='3px,3px' offset2='5px,5px' /></v:rect>";
        result+="<span style='position:absolute;z-index:3;font:12;left:220;top:10'>"+col_headers[0]+"</span>";
        
        
        for(i=3;i<col_headers.length;i++)
        {
            result+="<v:rect fillcolor='"+colors[i-3]+"' style='position:absolute;left:"+((i-2)*100-20)+";top:30;width:20;height:20' />";
            result+="<span style='position:absolute;z-index:3;font:12;left:"+((i-2)*100)+";top:35'>"+col_headers[i]+"</span>";
        }
        
        
        if(rows.length==1)
        {
            dx=chart_width/2-100;//如果只有一个圆饼则居中
        }
        if(rows.length==2)
        {
            dx=chart_width/2-180;//如果两个圆饼则居中处理
        }
        var PerCirclePoint=0;//上一个圆弧上的点
        for(var i=0;i<rows.length;i++)
        {
            var cols=rows[i].split(",");
            circle=0;
            for(var j=0;j<cols.length;j++)
            {
                if(j>0)
                {
                    circle+=parseFloat(cols[j]);//计算每一组数据的圆周总长
                }
            }
            for(var j=0;j<cols.length;j++)
            {
                if(j==0)
                {//绘制横坐标轴数据
                    result+="<span style='position:absolute;z-index:3;font:12;left:"+((i+1)*170-100+dx)+";top:"+(chart_height-50)+"'>"+cols[j]+"</span>";
                }
                else
                {//11,21,31,41
                    var curCirclePoint=cols[j]*360/circle+PerCirclePoint;//计算当前圆饼扇面绘制点
                    if(j==cols.length-1)
                    {
                        curCirclePoint=0;//即圆周循环360度回到起点
                    }
                    if(parseFloat(cols[j])>0)
                    {
                        //alert
                        result+=this.getPie(60,PerCirclePoint,curCirclePoint,"title:"+col_headers[j+2]+";val:"+(parseInt(Math.round((10000*cols[j]/circle)))/100)+"%;x:"+((i+1)*170-90+dx)+";y:"+(chart_height/2+10)+";background:"+colors[j-1])
                    }
                    PerCirclePoint=curCirclePoint;//将当前弧点复制给PerCirclePoint准备下一个
                }
            }
            
        }
        return result;
    }
    this.getPie=function(r,sa,ea,css){
        var sf,ef,sx,sy,ex,ey;
        var title=this.getCss(css,"title");
        var val=this.getCss(css,"val");
        var x=parseInt(this.getCss(css,"x",0));
        var y=parseInt(this.getCss(css,"y",0));
        sf=Math.PI*(sa/180);
        ef=Math.PI*(ea/180);
        sy=parseInt(r*Math.sin(sf));
        sx=parseInt(r*Math.cos(sf));
        ey=parseInt(r*Math.sin(ef));
        ex=parseInt(r*Math.cos(ef));
        
        s="m0,0l"+sx+","+sy+"ar-"+r+",-"+r+","+r+","+r+","+ex+","+ey+","+sx+","+sy+",l0,0xe";
        l="<v:shape path='"+s+"' title='"+title+"' coordsize=1,1 style='position:absolute;width:1;height:1;left:"+this.getCss(css,"x","0")+";top:"+this.getCss(css,"y","0")+"' fillcolor='"+this.getCss(css,"background","white")+"' />";
        if(ef==0)
            ef=270
        var cx=(r+10)*Math.cos((sf+ef)/2),cy=(r+10)*Math.sin((sf+ef)/2);
        l+="<span style='position:absolute;z-index:3;font:12;left:"+(cx+x-10)+";top:"+(cy+y-5)+"'>"+val+"</span>";
        return l
    }

    this.draw=function(colNames,data,step,colors,css)
    {
        var result;
        var type=this.getCss(css,"type");
        if(type=="pie")
        {
            result=this.pie(colNames,data,step,colors,css);//("测试报表,y轴,x轴,钢铁,电力,煤气,工商","1月份,11,21,31,41;2月份,15,45,32,42;3月份,25,32,33,34;4月份,29,36,34,12;5月份,45,40,34,46;6月份,32,43,34,14;7月份,35,44,34,22",10,['#FF0000','#00FF00','#0000FF','#FFFF00','#00FFFF','#FF00FF','#333333','#666666','#999999','#cccccc'],css);
        }
        else if(type=="wave")
        {
            result=this.wave(colNames,data,step,colors,css);//("测试报表,y轴,x轴,钢铁,电力,煤气,工商","1月份,11,21,31,41;2月份,15,45,32,42;3月份,25,32,33,34;4月份,29,36,34,12;5月份,45,40,34,46;6月份,32,43,34,14;7月份,35,44,34,22",10,['#FF0000','#00FF00','#0000FF','#FFFF00','#00FFFF','#FF00FF','#333333','#666666','#999999','#cccccc'],css);
        }
        else if(type=="bar")
        {
            result=this.bar(colNames,data,step,colors,css);//("测试报表,y轴,x轴,钢铁,电力,煤气,工商","1月份,11,21,31,41;2月份,12,22,32,42;3月份,13,23,33,43;4月份,14,24,34,44;5月份,14,24,34,44;6月份,14,24,34,44;7月份,14,24,34,44",10,['#FF0000','#00FF00','#0000FF','#FFFF00','#00FFFF','#FF00FF','#333333','#666666','#999999','#cccccc'],css);
        }
        return result;
    }
}