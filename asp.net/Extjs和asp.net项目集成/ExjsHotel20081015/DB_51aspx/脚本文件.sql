/*
==================酒店管理系统数据据库脚本==========================
*/
use master
go

if exists(select * from sysdatabases where name='hotel')
begin
	drop database hotel
end
go

create database hotel
go

use hotel
go

/*角色信息表*/
create table roleinfo
(
	roleid int identity(1,1) primary key,
	roleName varchar(20) not null,
	roleDesc varchar(50)--角色描述
)
go


/*用户信息表*/
create table userinfo
(
	id int identity(1,1) primary key,
	userid varchar(20) not null, --登陆名
	userName varchar(20) not null,--真实姓名
	userPwd varchar(20) not null,--登陆密码
	userState int check(userState in (0,1)) default(0) not null,--0:启动,1:停用
	roleid int not null --角色信息编号
)
go


/*功能权菜单表*/
create table nav
(
	navid int identity(1,1) primary key,--标识ID
	id int not null, --节点ID
	parentid int not null,--父节点ID
	title varchar(50) not null,--节点文本
	leaf int not null,
	iconCls varchar(50) not null,
	number int not null,
	url varchar(50) not null--节点url
	
)
go

---------------------------------------------/*房间类型表*/
create table roomtype
(
	typeid int identity(1,1) primary key,
	typeName varchar(20) not null,
	typePrice money not null,
	typeAddBed varchar(10) check (typeAddBed in('是','否')) not null,
	addbed money not null,--加床价格
	typeDesc varchar(100) not null
)
go


--------------------------------------------/*房间信息表*/
create table room
(
	roomid int identity(1,1) primary key,
	Number varchar(20) not null,--房间编号
	bedNumber int not null,
	guestNumber int not null,--入住人数 
	typeid int not null, --所属房间类型
	roomstate int not null,--房间状态
	roomDesc varchar(50) not null
)
go

-------------------------------------------/*客人信息表*/
create table GuestInfo
(
	Guestid int identity(1,1) primary key,
	GuestCardID numeric(18) not null,--身份证号码
	GuestName varchar(20) not null,
	GuestSex int check(GuestSex in(0,1)) not null,
	GuestMobile numeric(13) not null,
	GuestAddress varchar(100) not null,
)
go
---------------------------------------------/*客人入住信息表*/
create table OpenRoomInfo
(
	OpenRoomID int identity(1,1) primary key,
        Roomid int not null,--房间编号
	Guestid int not null,--客人编号
	GuestMoney money not null,--订金
	OpenTodayTime varchar(30) not null,
	OpenTime varchar(30)  not null,--开房时间
	Remark varchar(100)
)
go
---------------------------------------------------//开房记录表
create table OpenRoomRecordInfo
(
	RecordID int identity(1,1) primary key,
	Roomid int not null,
	Guestid int not null,
	GuestMoney money not null,
	OpenTodayTime varchar(30) not null,
	OpenTime varchar(30) not null,
	EndTodayTime varchar(30) not null,
	EndTime varchar(30) not null,
	Remark varchar(100)
)
go

------------------------------------------------/*房间预订信息表暂时没用*/
create table OrderRoomInfo
(
	OrderID int identity(1,1) primary key,
 	Roomid int not null,--房间编号
	Guestid int not null,--客人编号
	OrderTime datetime default(getdate()) not null,--下订单时间
	ArrvalTime datetime not null, --计划到达时间
	orderSate int default(0),--是否预定 0:未预定,1:已预定,2:入住
	Remark varchar(50)
)
go

------------------------------------------------------/*酒店收入信息表*/
create table TotalInfo
(
	totalID int identity(1,1) primary key,
	totalType varchar(20) check(totalType in ('订金','房费')) not null,--收入来源
	totalMoney money not null,--金额
	totalTime datetime default(getdate()),--录入时间
	totalRemark varchar(50)
)
go



create table publish
(
	pubID int identity(1,1) primary key,
	pubperson varchar(20) not null,
	pubTitle varchar(50) not null,
	pubDate varchar(30)  not null,
	pubContent varchar(200) not null
)
go




/*测试数据*/--角色
insert into roleinfo values('收营员','本系统主要使用对象')
insert into roleinfo values('系统管理员','本系统权限最高者')
insert into roleinfo values('客人','目前为止无任何权限')
go
---用户表
insert into userinfo values('aaa','服务员','aaa',default,1)
insert into userinfo values('kkk','服务员','kkk',1,1)
insert into userinfo values('admin','总经理','admin',default,2)
go


------------------------------------------------管理员权限
insert into nav values(2,1,'<b><font color=#008B8B>系统管理菜单</font></b>',0,'sysmanagemenu',1,'')
insert into nav values(3,1,'<b><font color=#008B8B>房间管理菜单</font></b>',0,'homemanage',2,'')
insert into nav values(4,1,'<b><font color=#008B8B>综合信息管理</font></b>',0,'allmanagemenu',3,'')

insert into nav values(5,2,'公告信息管理',1,'publishicon',1,'')
insert into nav values(6,2,'用户信息管理',1,'usericon',2,'')
insert into nav values(7,2,'开房记录报表',1,'roolrecordicon',3,'')
insert into nav values(8,2,'酒店收入报表',1,'totalicon',4,'')

insert into nav values(9,3,'<font color=red>开设房间</font>',1,'openroomicon',2,'')
insert into nav values(10,3,'开房信息管理',1,'openroomiconinfo',3,'')
insert into nav values(11,3,'房间信息管理',1,'roomicons',3,'')
insert into nav values(12,3,'房间类型管理',1,'roomtypeicon',1,'')

insert into nav values(13,4,'客人信息管理',1,'guesticon',6,'')


------------------------------------------------业务员权限
insert into nav values(15,100,'<b><font color=#008B8B>系统管理菜单</font></b>',0,'sysmanagemenu',1,'')
insert into nav values(16,100,'<b><font color=#008B8B>房间管理菜单</font></b>',0,'homemanage',2,'')
insert into nav values(17,100,'<b><font color=#008B8B>综合信息管理</font></b>',0,'allmanagemenu',3,'')

insert into nav values(18,15,'修改帐户密码',1,'setuseridicon',3,'')

insert into nav values(19,16,'<font color=red>开设房间</font>',1,'openroomicon',1,'')
insert into nav values(20,16,'开房信息管理',1,'openroomiconinfo',2,'')
insert into nav values(21,16,'房间信息管理',1,'roomicons',3,'')
insert into nav values(22,16,'房间类型管理',1,'roomtypeicon',4,'')

insert into nav values(23,17,'客人信息管理',1,'guesticon',1,'')

----------------------------------------------------

---房间类型
insert into roomtype values('单人间',288,'否',0,'一间面积为16~20平方米的房间')
insert into roomtype values('标准间',388,'是',100,'房内设两张单人床或一张双人床的叫标准间')
insert into roomtype values('豪华间',666,'是',200,'房内设两张单人床或一张双人床，房间的装修')
insert into roomtype values('行政间',888,'是',200,'房内可以上网，满足商务客人的需求')
insert into roomtype values('高级套房',5888,'是',500,'由七至八间房组成的套间，走廊有小酒吧')
insert into roomtype values('豪华套房',8888,'是',888,'由楼上、楼下两层组成，楼上为卧室')


select * from room
----房间信息查询
insert into room values('101',1,1,1,0,'靠近大厅，偶尔声音比较杂')
insert into room values('102',2,2,2,1,'与102相近，房间比较好，也有102的特点')
insert into room values('103',2,2,2,0,'一楼最后一间，物美价廉')
insert into room values('201',2,2,2,3,'二楼第一间，风景不错')
insert into room values('202',4,4,3,0,'装修比较好，房间不错')
insert into room values('203',5,5,4,4,'该房间可以上上网，听听音乐')
insert into room values('301',4,4,3,0,'较安静适合一个人住-静心')
insert into room values('302',7,7,5,0,'三楼中间一间，价廉物美')
insert into room values('303',7,7,5,3,'该房间比较好，客人这么说的')
insert into room values('401',5,5,4,0,'装修比较好，房间不错')
insert into room values('402',2,2,2,2,'房间布置很好，东南朝向')
insert into room values('403',4,4,3,0,'该房间可以上上网，听听音乐')
insert into room values('501',10,10,6,0,'装修比较好，房间不错')
insert into room values('502',10,10,6,4,'从多明星也非常喜欢这间房')
insert into room values('503',10,10,6,1,'曾经姚明在此居住过，客源不断')
-----客人信息表

insert into guestinfo values(500113198801011010,'木马人',0,13987654321,'地球村月亮路太阳街宇宙3号')
insert into guestinfo values(500113124242142344,'乔丹',0,13298987877,'美国洛杉机')
insert into guestinfo values(500154321423142334,'科比',1,13098766672,'美国华圣顿')
insert into guestinfo values(509765325235745632,'易建连',0,13987654321,'中国村5号')
insert into guestinfo values(108923412543233455,'张三',1,13987654321,'中国上海8号')
insert into guestinfo values(500154321423142334,'李四',1,13098766672,'美国华圣顿')
insert into guestinfo values(509765325235745632,'王五',0,13987654321,'中国村5号')
insert into guestinfo values(108923412543233455,'王二小',1,13987654321,'中国上海8号')


--------入住信息表
select * from openroominfo
insert into openroominfo values('101',1,100,'2008-09-01','11:45:15','暂无描述信息')
insert into openroominfo values('102',2,100,'2008-09-01','10:24:15','暂无描述信息')
insert into openroominfo values('103',3,200,'2008-09-01','14:13:15','暂无描述信息')
insert into openroominfo values('201',4,200,'2008-09-02','16:25:15','暂无描述信息')
insert into openroominfo values('202',5,200,'2008-09-02','17:11:15','暂无描述信息')
insert into openroominfo values('203',6,100,'2008-09-02','18:16:15','暂无描述信息')
insert into openroominfo values('301',6,100,'2008-09-03','19:21:15','暂无描述信息')
insert into openroominfo values('302',5,200,'2008-09-03','11:25:15','暂无描述信息')
insert into openroominfo values('303',4,200,'2008-09-04','05:33:15','暂无描述信息')
insert into openroominfo values('401',3,200,'2008-09-04','09:25:15','暂无描述信息')
insert into openroominfo values('402',2,100,'2008-09-04','03:25:15','暂无描述信息')
insert into openroominfo values('403',1,100,'2008-09-05','02:12:15','暂无描述信息')
insert into openroominfo values('501',2,200,'2008-09-05','04:25:15','暂无描述信息')
insert into openroominfo values('502',3,200,'2008-09-05','15:22:15','暂无描述信息')
insert into openroominfo values('503',4,200,'2008-09-05','17:34:15','暂无描述信息')
insert into openroominfo values('101',5,100,'2008-09-05','18:25:15','暂无描述信息')
go
--插入收入信息

insert into totalinfo values('订金',200.00,'2008-10-01 10:11:12.000','暂无备注')
insert into totalinfo values('房费',12200.00,'2008-10-02 14:05:12','暂无备注')
insert into totalinfo values('订金',100.00,'2008-10-03 22:44:12','暂无备注')
insert into totalinfo values('房费',2288.00,'2008-10-04 21:32:12','暂无备注')
insert into totalinfo values('订金',100.00,'2008-10-05 08:11:12','暂无备注')
insert into totalinfo values('房费',2299.00,'2008-10-06 09:17:12','暂无备注')

--插入开房记录信息

insert into openroomrecordinfo values(101,1,200.00,'2008-10-01','10:00:25','2008-10-04','12:01:32','暂无备注信息')
insert into openroomrecordinfo values(202,2,150.00,'2008-10-02','08:11:25','2008-10-03','18:21:12','暂无备注信息')
insert into openroomrecordinfo values(301,3,500.00,'2008-10-03','06:35:25','2008-10-05','21:43:42','暂无备注信息')
insert into openroomrecordinfo values(501,4,600.00,'2008-10-04','07:45:25','2008-10-05','22:25:16','暂无备注信息')
insert into openroomrecordinfo values(303,5,700.00,'2008-10-05','18:66:25','2008-10-07','17:41:27','暂无备注信息')
go

--插入开房信息存储过程
create proc proc_OpenRoomInfo
(
	@Roomid int,
	@GuestMoney money,
	@Remark varchar(100)
)
as
	declare @OpenTodayTime varchar(30)
	declare @OpenTime varchar(30)
	declare @Guestid int
	set @OpenTodayTime=(Select CONVERT(varchar(100), GETDATE(), 23))
	set @OpenTime=(Select CONVERT(varchar(100), GETDATE(), 24))
	set @Guestid=(select top 1 guestid from guestinfo order by guestid desc)
	insert into openroominfo values(@Roomid,@Guestid,@GuestMoney,@OpenTodayTime,@OpenTime,@Remark)
	insert into TotalInfo values('订金',@GuestMoney,default,@Remark)
go

--开房成功后修改房间状态触发器
create trigger tri_Room_state
on openroominfo
after insert
as
	declare @roomid int
begin
	select @roomid=roomid from inserted
	update room set roomstate=1 where number=''+@roomid+''
end
go
--插入客人信息存储过程
create proc proc_AddGuestInfo
(
	@GuestCardID numeric(18),
	@GuestName varchar(20),
	@GuestSex int,
	@GuestMobile numeric(13),
	@GuestAddress varchar(100)
)
as
begin
	insert into GuestInfo values(@GuestCardID,@GuestName,@GuestSex,@GuestMobile,@GuestAddress)
end
go

-----删除开房信息增加开房记录并修改房间状态触发器

create trigger tri_OpenRoomRecordInfo
on OpenRoomInfo
after delete
as
	declare @Roomid int,
	@Guestid int, 
	@GuestMoney money,
	@OpenTodayTime varchar(30),
	@OpenTime varchar(30),
	@Remark varchar(100),
	@EndTodayTime varchar(30),
	@EndTime varchar(30)
	set @EndTodayTime=(Select CONVERT(varchar(100), GETDATE(), 23))
	set @EndTime=(Select CONVERT(varchar(100), GETDATE(), 24))
	
begin
	select @Roomid=Roomid,@Guestid=Guestid,@GuestMoney=GuestMoney,@OpenTodayTime=OpenTodayTime,@OpenTime=OpenTime,@Remark=Remark from deleted
	insert into OpenRoomRecordInfo values(@Roomid,@Guestid,@GuestMoney,@OpenTodayTime,@OpenTime,@EndTodayTime,@EndTime,@Remark)
	update room set roomstate=0 where number=''+@Roomid+''
end
go

--------------查询房费存储过程不足一天按一天算
create proc proc_GetAllRoomMoney
(
	@roomid varchar(10),
	@AllMoney money output
)
as
declare @Days int,
 	 @RoomTypeMoney money,
 	 @GuestMoney money
begin
	 set @Days=(select top 1 datediff(dd,OpenTodayTime,getdate()) from openroomrecordinfo where roomid=@roomid order by RecordID desc)
	 if(@Days<1)
	 begin
		set @Days=1
	 end
	 set @RoomTypeMoney=(select typeprice from roomtype where typeid=(select typeid from room where number=@roomid))
	 set @GuestMoney=(select top 1 GuestMoney from openroomrecordinfo where roomid=@roomid order by RecordID desc)
	 set @AllMoney=((@Days*@RoomTypeMoney)-@GuestMoney)
end
go

--插入公告信息存储过程
create proc proc_InsertPublish
(
	@pubperson varchar(20),
	@pubTitle varchar(50),
	@pubContent varchar(200)
)
as
begin
	declare @pubDate varchar(30)
	set @pubDate=(Select CONVERT(varchar(100), GETDATE(), 102))
	insert into publish values(@pubperson,@pubTitle,@pubDate,@pubContent)
end
go

exec proc_InsertPublish 'admin','9-1日上午九点!朝辉厅开会','请各部门经理于9-1日上午九点!朝辉厅开会,勿必准时'
exec proc_InsertPublish 'admin','9-5日晨会临时取消，时间待定!','9-5日晨会临时取消，时间待定请大家相互转告!'
exec proc_InsertPublish 'admin','9-20号举行游泳比赛!','20号举行游泳比赛,请各部门选手积极准备，拿出最好的成绩'
exec proc_InsertPublish 'admin','祝酒店员工国庆节快乐!','国庆节来临之际！祝Marriott酒店全体员工国庆快乐!合家幸福!'


/*查看数据*/
select * from publish
select * from roleinfo
select * from userinfo 
select * from nav
select * from roomtype
select * from room
select * from OpenRoomInfo
select * from GuestInfo
select * from totalinfo

