---------------------------酒店管理系统-----51aspx.com------------------------------------------
use master
go
if exists(select * from sysdatabases where name='MyHotelManager')
	begin
		drop database MyHotelManager
	end
go
create database MyHotelManager
go
use MyHotelManager
go
---------------------------------------------------------------------------------------
/*用户表*/
create table UserInfo
(
	UserId int identity(1,1) primary key, --用户Id
	LoginName varchar(50) not null, --登录名
	LoginPass varchar(50) not null, --登录密码
	UserName varchar(50) not null, --真实姓名
	Remark varchar(200) --备注
)
go
insert into UserInfo values('admin','admin','陈万乐','老板撒')
insert into UserInfo values('aaa','aaa','不晓得','普通员工撒')
go
---------------------------------------------------------------------------------------
/*房间状态表*/
create table RoomState
(
	StateId int identity(1,1) primary key, --状态Id
	StateName varchar(20) not null --状态名称
)
go
insert into RoomState values('空闲')
insert into RoomState values('入住')
insert into RoomState values('已订')
insert into RoomState values('维修')
insert into RoomState values('自用')
go
---------------------------------------------------------------------------------------
/*是否表*/
create table  IsTable
(
	IsId int identity(1,1) primary key,
	IsName varchar(10) not null
)
go
insert into IsTable values('是')
insert into IsTable values('否')
go
---------------------------------------------------------------------------------------
/*房间类型表*/
create table RoomType
(
	TypeId int identity(1,1) primary key, --房间类型Id
	TypeName varchar(20) not null, --类型名称
	TypePrice money, --类型价格
	IsTv varchar(10) not null, --是否配备电视
	IsKongTiao varchar(10) not null, --是否配备空调
	Remark varchar(200) --房间类型备注 
)
go
insert into RoomType values('终点房',50,'是','否','普通的终点房，经济实惠')
insert into RoomType values('普通单间',70,'是','是','普通的单间，适合一个人住')
insert into RoomType values('豪华单间',90,'是','是','豪华的单间，但也不贵')
insert into RoomType values('双人间',120,'是','是','双人房，两个人住嘛')
insert into RoomType values('贵宾间',150,'是','是','有点贵哟')
insert into RoomType values('总统套房',200,'是','是','这个不说了，贵死人')
go
---------------------------------------------------------------------------------------
/*客房表*/
create table Room
(
	RoomId int identity(1,1) primary key, --客房表Id
	Number varchar(20) not null, --房间编号
	BedNumber int not null, --床位数
	TypeId int foreign key references RoomType(TypeId) not null, --房间类型Id
	StateId int foreign key references RoomState(StateId) not null, --房间状态Id
	Remark varchar(200) --房间备注
)
go
insert into Room values('301',1,1,1,'还可以哈')
insert into Room values('302',1,1,1,'还可以哈')
insert into Room values('303',1,1,1,'还可以哈')
insert into Room values('304',1,1,1,'还可以哈')
insert into Room values('305',1,1,1,'还可以哈')
insert into Room values('306',1,1,1,'还可以哈')
insert into Room values('307',1,2,1,'还可以哈')
insert into Room values('308',1,2,1,'还可以哈')
insert into Room values('309',1,2,1,'还可以哈')
insert into Room values('310',1,2,1,'还可以哈')
insert into Room values('311',1,2,1,'还可以哈')
insert into Room values('312',1,2,1,'还可以哈')
insert into Room values('313',1,3,1,'还可以哈')
insert into Room values('314',1,3,1,'还可以哈')
insert into Room values('315',1,3,1,'还可以哈')
insert into Room values('316',1,3,1,'还可以哈')
insert into Room values('317',1,3,1,'还可以哈')
insert into Room values('318',1,3,1,'还可以哈')
insert into Room values('319',1,3,1,'还可以哈')
insert into Room values('320',1,3,1,'还可以哈')
insert into Room values('321',1,3,1,'还可以哈')
insert into Room values('322',2,4,1,'还可以哈')
insert into Room values('323',2,4,1,'还可以哈')
insert into Room values('324',2,4,1,'还可以哈')
insert into Room values('325',2,4,1,'还可以哈')
insert into Room values('326',2,4,1,'还可以哈')
insert into Room values('327',2,4,1,'还可以哈')
insert into Room values('328',2,4,1,'还可以哈')
insert into Room values('329',3,5,1,'还可以哈')
insert into Room values('330',3,5,1,'还可以哈')
insert into Room values('331',3,5,1,'还可以哈')
insert into Room values('332',3,5,1,'还可以哈')
insert into Room values('333',4,6,1,'还可以哈')
insert into Room values('334',4,6,1,'还可以哈')
insert into Room values('335',4,6,1,'还可以哈')
go
---------------------------------------------------------------------------------------
/*开房信息表*/
create table OpenRoomInfo
(
	OpenRoomId int identity(1,1) primary key, --开房Id
	RoomId int foreign key references Room(RoomId) not null, --房间Id
	GuestNumber varchar(100) not null, --客人的身份证号
	GuestName varchar(50) not null, --客人姓名
	GuestMoney money not null, --预交金额
	OpenTime datetime default(getdate()) not null, --开房时间
	Remark varchar(200) --备注
)
go
---------------------------------------------------------------------------------------
/*酒店收入表*/
create table MoneyInfo
(
	MoneyInfoId int identity(1,1) primary key, --收入Id
	OpenTime datetime not null, --开房时间
	RoomNumber varchar(20) not null, --房间号,
	GuestNumber varchar(100) not null, --登记身份证
	GuestName varchar(50) not null, --登记姓名,
	MoneyDate datetime default(getdate()) not null, --账目时间(其实就是退房时间)
	DetailsMoney money check(DetailsMoney>0) not null --账目金额
)
go
insert into MoneyInfo values('2008-05-19 15:17:18.623','302','12345','chen','2008-05-20 15:15:13:123',50.000)
insert into MoneyInfo values('2008-05-19 18:17:18.623','303','54321','aaaa','2008-05-20 16:15:13:123',50.000)
insert into MoneyInfo values('2008-05-20 11:11:18.663','311','97854','bbbb','2008-05-21 09:10:13:123',70.000)
insert into MoneyInfo values('2008-05-20 15:17:18.623','313','12345','cccc','2008-05-21 13:13:13:123',90.000)
insert into MoneyInfo values('2008-05-23 13:09:20.623','305','32184','dddd','2008-05-24 06:06:23:123',50.000)
insert into MoneyInfo values('2008-05-27 22:02:15.233','319','05252','eeee','2008-05-28 05:03:13:123',90.000)
insert into MoneyInfo values('2008-05-30 21:21:22.623','320','52325','ffff','2008-06-01 09:22:32:123',90.000)
insert into MoneyInfo values('2008-06-05 20:30:10.665','315','45352','gggg','2008-06-06 11:22:33:123',90.000)
insert into MoneyInfo values('2008-06-11 19:55:25.623','323','65852','hhhh','2008-06-12 10:15:13:123',120.000)
insert into MoneyInfo values('2008-06-23 23:45:20.623','301','85236','jjjj','2008-06-24 08:45:13:123',50.000)
insert into MoneyInfo values('2008-07-29 20:35:35.623','314','17455','llll','2008-07-30 08:36:13:123',90.000)
insert into MoneyInfo values('2008-08-22 21:13:18.623','325','32512','rrrr','2008-08-23 10:10:15:123',120.000)
go
--------------------------------------是否表存储过程------------------------------------------
/*查询所有*/
create proc GetIsAll
as
	select * from IsTable
go
--------------------------------------用户表存储过程------------------------------------------
/*用户登录*/
create proc GetLogin(@LoginName varchar(50),@LoginPass varchar(50))
as
	select LoginName,LoginPass from UserInfo
		where LoginName = @LoginName and LoginPass = @LoginPass
go
---------------------------------------------------------------------------------------
/*添加普通员工*/
create proc AddUser(@LoginName varchar(50),@LoginPass varchar(50),
				@UserName varchar(50),@Remark varchar(200))
as
	insert into UserInfo values(@LoginName,@LoginPass,@UserName,@Remark)
go
---------------------------------------------------------------------------------------
/*删除员工(根据Id删除)*/
create proc DelUser(@UserId int)
as
	delete from UserInfo where UserId = @UserId
go
---------------------------------------------------------------------------------------
/*查询所有员工(删除用到)*/
create proc GetUser(@LoginName varchar(50))
as
	select UserId,LoginName from UserInfo where LoginName not in(@LoginName)
go
---------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------
/*检查登录名是否重复*/
create proc CheckUserId(@LoginName varchar(50))
as
	select LoginName from UserInfo where LoginName = @LoginName
go
--------------------------------------房间状态表存储过程------------------------------------------
/*查询房间状态表(所有)*/
create proc GetAllRoomState
as
	select * from RoomState
go
---------------------------------------房间类型表存储过程------------------------------------------
/*添加房间类型*/
create proc AddRoomType(@TypeName varchar(20),@TypePrice money,@IsTv varchar(10),
				@IsKongTiao varchar(10),@Remark varchar(200))
as
	insert into RoomType values(@TypeName,@TypePrice,@IsTv,@IsKongTiao,
		@Remark)
go
---------------------------------------------------------------------------------------
/*删除房间类型(根据类型Id)*/
create proc DelRoomType(@TypeId int)
as
	delete from RoomType where TypeId = @TypeId
go
---------------------------------------------------------------------------------------
/*查询所有房间类型(查询房间类型用到,带搜索)*/
create proc GetAllRoomType(@message varchar(50))
as
	if (@message = '')
	begin
		select * from RoomType
	end
	else
	begin
		select * from RoomType where (TypeName like @message+'%' or IsTv like @message+'%' or
			IsKongTiao like @message+'%' or Remark like @message+'%')
	end
go
---------------------------------------------------------------------------------------
/*查询所有未被使用的房间类型(删除用到)*/
create proc GetRoomType
as
	select TypeId,TypeName from RoomType where TypeId not in(select TypeId from Room)
go
---------------------------------------------------------------------------------------
/*查询今日房价*/
create proc GetTodyPrice
as
	select TypeName,TypePrice from RoomType
go
-----------------------------------------客房表存储过程--------------------------------------------
/*查询所有客房信息(查看客房信息用到,带搜索)*/
create proc GetAllRoom(@message varchar(50))
as
	if (@message = '')
	begin
		select a.Number,a.BedNumber,b.TypeName,c.StateName,a.Remark from Room as a,RoomType as b,
			RoomState as c where a.TypeId = b.TypeId and a.StateId = c.StateId
	end
	else
	begin
		select a.Number,a.BedNumber,b.TypeName,c.StateName,a.Remark from Room as a,RoomType as b,
			RoomState as c where a.TypeId = b.TypeId and a.StateId = c.StateId and (a.Number like
				@message+'%' or b.TypeName like @message+'%' or c.StateName like @message+'%'
					or a.Remark like @message+'%')
	end
go
---------------------------------------------------------------------------------------
/*添加客房表*/
create proc AddRoom(@Number varchar(20),@BedNumber int,@TypeId int,@StateId int,@Remark varchar(200))
as
	insert into Room values(@Number,@BedNumber,@TypeId,@StateId,@Remark)
go
---------------------------------------------------------------------------------------
/*删除客房表(根据房间编号)*/
create proc DelRoom(@Number varchar(20))
as
	delete from Room where Number = @Number
go
---------------------------------------------------------------------------------------
/*根据类型Id查询所有客房信息(状态为空闲)*/
create proc GetRoomByTypeId(@TypeId int)
as
	select RoomId,Number from Room where StateId = 1 and TypeId=@TypeId
go
---------------------------------------------------------------------------------------
/*查询所有状态为空闲的房间(删除客房时用到)*/
create proc GetRoom
as
	select RoomId,Number from Room where StateId = 1
go
----------------------------------------开房信息表存储过程------------------------------------------
/*查询所有的开房信息(首页的Grid,带搜索功能)*/
create proc GetOpenRoomInfoAll(@message varchar(50))
as
	if (@message = '')
	begin
		select a.OpenRoomId,b.Number,c.TypeName,c.TypePrice,a.OpenTime,a.GuestMoney,a.GuestNumber,a.GuestName,
		a.Remark from OpenRoomInfo as a,Room as b,RoomType as c where a.RoomId = b.RoomId and
			 b.TypeId = c.TypeId
	end
	else
	begin
		select a.OpenRoomId,b.Number,c.TypeName,c.TypePrice,a.OpenTime,a.GuestMoney,a.GuestNumber,a.GuestName,
		a.Remark from OpenRoomInfo as a,Room as b,RoomType as c where a.RoomId = b.RoomId and
			 b.TypeId = c.TypeId and (b.Number like @message+'%' or c.TypeName like @message+'%'
				or a.GuestNumber like @message+'%' or a.GuestName like @message+'%' or 
					a.Remark like @message+'%')
	end
go
---------------------------------------------------------------------------------------
/*开房操作*/
create proc OpenRoom(@RoomId int,@GuestNumber varchar(100),@GuestName varchar(50),
				@GuestMoney money,@Remark varchar(200))
as
	insert into OpenRoomInfo values(@RoomId,@GuestNumber,@GuestName,@GuestMoney,
		default,@Remark)
go
---------------------------------------------------------------------------------------
/*开房操作触发器*/
create trigger trig_Insert
on OpenRoomInfo
for insert
as
	declare @RoomId int
	select @RoomId = RoomId from inserted
	update Room set StateId = 2 
		where RoomId = @RoomId
go
---------------------------------------------------------------------------------------
/*退房操作*/
create proc CloseRoom(@Number varchar(20))
as
	delete OpenRoomInfo where RoomId = (select RoomId from Room where Number = @Number)
go
---------------------------------------------------------------------------------------
/*退房操作触发器*/
create trigger trig_Del
on OpenRoomInfo
for delete
as
	declare @RoomId int,@GuestNumber varchar(100),@GuestName varchar(50),@TypeId int,@RoomNumber varchar(20),
		@TypePrice money, @price money,@OpenTime datetime
	--从deleted表中查到删除的房间Id,预交金额,登记身份证,登记姓名,开房时间
	select @RoomId = RoomId,@OpenTime = OpenTime,@GuestNumber = GuestNumber,@GuestName = GuestName from deleted
	select @TypeId = TypeId from Room where RoomId = @RoomId --得到房间Id对应的房间类型Id
	select @RoomNumber = Number from Room where RoomId = @RoomId --得到房间ID对应的房间编号
	select @TypePrice = TypePrice from RoomType where TypeId = @TypeId --得到该类型的价格
	insert into  MoneyInfo values(@OpenTime,@RoomNumber,@GuestNumber,@GuestName,default,@TypePrice)
go
insert into OpenRoomInfo values(1,'12345','chen',200,default,'才来的')
insert into OpenRoomInfo values(2,'54321','elva',200,default,'才来的')
insert into OpenRoomInfo values(4,'45678','jay',300,default,'才来的')
insert into OpenRoomInfo values(5,'78945','lele',400,default,'才来的')
insert into OpenRoomInfo values(9,'65487','aaaa',400,default,'才来的')
insert into OpenRoomInfo values(10,'32158','bbbb',500,default,'才来的')
insert into OpenRoomInfo values(15,'98789','cccc',500,default,'才来的')
insert into OpenRoomInfo values(19,'58256','dddd',800,default,'才来的')
insert into OpenRoomInfo values(21,'96965','eeee',1000,default,'不晓得')
go
-------------------------------------------酒店收入表存储过程----------------------------------------
/*查账(全查,根据时间查询都可以)*/
create proc SerachMoney(@BeginTime datetime,@EndTime datetime)
as
	if (@BeginTime = '')
	begin
		select * from MoneyInfo
	end
	else
	begin
		select * from MoneyInfo where MoneyDate >= @BeginTime and MoneyDate <= @EndTime
	end
go
---------------------------------------------------------------------------------------

