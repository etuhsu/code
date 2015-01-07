---------------------------�Ƶ����ϵͳ-----51aspx.com------------------------------------------
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
/*�û���*/
create table UserInfo
(
	UserId int identity(1,1) primary key, --�û�Id
	LoginName varchar(50) not null, --��¼��
	LoginPass varchar(50) not null, --��¼����
	UserName varchar(50) not null, --��ʵ����
	Remark varchar(200) --��ע
)
go
insert into UserInfo values('admin','admin','������','�ϰ���')
insert into UserInfo values('aaa','aaa','������','��ͨԱ����')
go
---------------------------------------------------------------------------------------
/*����״̬��*/
create table RoomState
(
	StateId int identity(1,1) primary key, --״̬Id
	StateName varchar(20) not null --״̬����
)
go
insert into RoomState values('����')
insert into RoomState values('��ס')
insert into RoomState values('�Ѷ�')
insert into RoomState values('ά��')
insert into RoomState values('����')
go
---------------------------------------------------------------------------------------
/*�Ƿ��*/
create table  IsTable
(
	IsId int identity(1,1) primary key,
	IsName varchar(10) not null
)
go
insert into IsTable values('��')
insert into IsTable values('��')
go
---------------------------------------------------------------------------------------
/*�������ͱ�*/
create table RoomType
(
	TypeId int identity(1,1) primary key, --��������Id
	TypeName varchar(20) not null, --��������
	TypePrice money, --���ͼ۸�
	IsTv varchar(10) not null, --�Ƿ��䱸����
	IsKongTiao varchar(10) not null, --�Ƿ��䱸�յ�
	Remark varchar(200) --�������ͱ�ע 
)
go
insert into RoomType values('�յ㷿',50,'��','��','��ͨ���յ㷿������ʵ��')
insert into RoomType values('��ͨ����',70,'��','��','��ͨ�ĵ��䣬�ʺ�һ����ס')
insert into RoomType values('��������',90,'��','��','�����ĵ��䣬��Ҳ����')
insert into RoomType values('˫�˼�',120,'��','��','˫�˷���������ס��')
insert into RoomType values('�����',150,'��','��','�е��Ӵ')
insert into RoomType values('��ͳ�׷�',200,'��','��','�����˵�ˣ�������')
go
---------------------------------------------------------------------------------------
/*�ͷ���*/
create table Room
(
	RoomId int identity(1,1) primary key, --�ͷ���Id
	Number varchar(20) not null, --������
	BedNumber int not null, --��λ��
	TypeId int foreign key references RoomType(TypeId) not null, --��������Id
	StateId int foreign key references RoomState(StateId) not null, --����״̬Id
	Remark varchar(200) --���䱸ע
)
go
insert into Room values('301',1,1,1,'�����Թ�')
insert into Room values('302',1,1,1,'�����Թ�')
insert into Room values('303',1,1,1,'�����Թ�')
insert into Room values('304',1,1,1,'�����Թ�')
insert into Room values('305',1,1,1,'�����Թ�')
insert into Room values('306',1,1,1,'�����Թ�')
insert into Room values('307',1,2,1,'�����Թ�')
insert into Room values('308',1,2,1,'�����Թ�')
insert into Room values('309',1,2,1,'�����Թ�')
insert into Room values('310',1,2,1,'�����Թ�')
insert into Room values('311',1,2,1,'�����Թ�')
insert into Room values('312',1,2,1,'�����Թ�')
insert into Room values('313',1,3,1,'�����Թ�')
insert into Room values('314',1,3,1,'�����Թ�')
insert into Room values('315',1,3,1,'�����Թ�')
insert into Room values('316',1,3,1,'�����Թ�')
insert into Room values('317',1,3,1,'�����Թ�')
insert into Room values('318',1,3,1,'�����Թ�')
insert into Room values('319',1,3,1,'�����Թ�')
insert into Room values('320',1,3,1,'�����Թ�')
insert into Room values('321',1,3,1,'�����Թ�')
insert into Room values('322',2,4,1,'�����Թ�')
insert into Room values('323',2,4,1,'�����Թ�')
insert into Room values('324',2,4,1,'�����Թ�')
insert into Room values('325',2,4,1,'�����Թ�')
insert into Room values('326',2,4,1,'�����Թ�')
insert into Room values('327',2,4,1,'�����Թ�')
insert into Room values('328',2,4,1,'�����Թ�')
insert into Room values('329',3,5,1,'�����Թ�')
insert into Room values('330',3,5,1,'�����Թ�')
insert into Room values('331',3,5,1,'�����Թ�')
insert into Room values('332',3,5,1,'�����Թ�')
insert into Room values('333',4,6,1,'�����Թ�')
insert into Room values('334',4,6,1,'�����Թ�')
insert into Room values('335',4,6,1,'�����Թ�')
go
---------------------------------------------------------------------------------------
/*������Ϣ��*/
create table OpenRoomInfo
(
	OpenRoomId int identity(1,1) primary key, --����Id
	RoomId int foreign key references Room(RoomId) not null, --����Id
	GuestNumber varchar(100) not null, --���˵����֤��
	GuestName varchar(50) not null, --��������
	GuestMoney money not null, --Ԥ�����
	OpenTime datetime default(getdate()) not null, --����ʱ��
	Remark varchar(200) --��ע
)
go
---------------------------------------------------------------------------------------
/*�Ƶ������*/
create table MoneyInfo
(
	MoneyInfoId int identity(1,1) primary key, --����Id
	OpenTime datetime not null, --����ʱ��
	RoomNumber varchar(20) not null, --�����,
	GuestNumber varchar(100) not null, --�Ǽ����֤
	GuestName varchar(50) not null, --�Ǽ�����,
	MoneyDate datetime default(getdate()) not null, --��Ŀʱ��(��ʵ�����˷�ʱ��)
	DetailsMoney money check(DetailsMoney>0) not null --��Ŀ���
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
--------------------------------------�Ƿ��洢����------------------------------------------
/*��ѯ����*/
create proc GetIsAll
as
	select * from IsTable
go
--------------------------------------�û���洢����------------------------------------------
/*�û���¼*/
create proc GetLogin(@LoginName varchar(50),@LoginPass varchar(50))
as
	select LoginName,LoginPass from UserInfo
		where LoginName = @LoginName and LoginPass = @LoginPass
go
---------------------------------------------------------------------------------------
/*�����ͨԱ��*/
create proc AddUser(@LoginName varchar(50),@LoginPass varchar(50),
				@UserName varchar(50),@Remark varchar(200))
as
	insert into UserInfo values(@LoginName,@LoginPass,@UserName,@Remark)
go
---------------------------------------------------------------------------------------
/*ɾ��Ա��(����Idɾ��)*/
create proc DelUser(@UserId int)
as
	delete from UserInfo where UserId = @UserId
go
---------------------------------------------------------------------------------------
/*��ѯ����Ա��(ɾ���õ�)*/
create proc GetUser(@LoginName varchar(50))
as
	select UserId,LoginName from UserInfo where LoginName not in(@LoginName)
go
---------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------
/*����¼���Ƿ��ظ�*/
create proc CheckUserId(@LoginName varchar(50))
as
	select LoginName from UserInfo where LoginName = @LoginName
go
--------------------------------------����״̬��洢����------------------------------------------
/*��ѯ����״̬��(����)*/
create proc GetAllRoomState
as
	select * from RoomState
go
---------------------------------------�������ͱ�洢����------------------------------------------
/*��ӷ�������*/
create proc AddRoomType(@TypeName varchar(20),@TypePrice money,@IsTv varchar(10),
				@IsKongTiao varchar(10),@Remark varchar(200))
as
	insert into RoomType values(@TypeName,@TypePrice,@IsTv,@IsKongTiao,
		@Remark)
go
---------------------------------------------------------------------------------------
/*ɾ����������(��������Id)*/
create proc DelRoomType(@TypeId int)
as
	delete from RoomType where TypeId = @TypeId
go
---------------------------------------------------------------------------------------
/*��ѯ���з�������(��ѯ���������õ�,������)*/
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
/*��ѯ����δ��ʹ�õķ�������(ɾ���õ�)*/
create proc GetRoomType
as
	select TypeId,TypeName from RoomType where TypeId not in(select TypeId from Room)
go
---------------------------------------------------------------------------------------
/*��ѯ���շ���*/
create proc GetTodyPrice
as
	select TypeName,TypePrice from RoomType
go
-----------------------------------------�ͷ���洢����--------------------------------------------
/*��ѯ���пͷ���Ϣ(�鿴�ͷ���Ϣ�õ�,������)*/
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
/*��ӿͷ���*/
create proc AddRoom(@Number varchar(20),@BedNumber int,@TypeId int,@StateId int,@Remark varchar(200))
as
	insert into Room values(@Number,@BedNumber,@TypeId,@StateId,@Remark)
go
---------------------------------------------------------------------------------------
/*ɾ���ͷ���(���ݷ�����)*/
create proc DelRoom(@Number varchar(20))
as
	delete from Room where Number = @Number
go
---------------------------------------------------------------------------------------
/*��������Id��ѯ���пͷ���Ϣ(״̬Ϊ����)*/
create proc GetRoomByTypeId(@TypeId int)
as
	select RoomId,Number from Room where StateId = 1 and TypeId=@TypeId
go
---------------------------------------------------------------------------------------
/*��ѯ����״̬Ϊ���еķ���(ɾ���ͷ�ʱ�õ�)*/
create proc GetRoom
as
	select RoomId,Number from Room where StateId = 1
go
----------------------------------------������Ϣ��洢����------------------------------------------
/*��ѯ���еĿ�����Ϣ(��ҳ��Grid,����������)*/
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
/*��������*/
create proc OpenRoom(@RoomId int,@GuestNumber varchar(100),@GuestName varchar(50),
				@GuestMoney money,@Remark varchar(200))
as
	insert into OpenRoomInfo values(@RoomId,@GuestNumber,@GuestName,@GuestMoney,
		default,@Remark)
go
---------------------------------------------------------------------------------------
/*��������������*/
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
/*�˷�����*/
create proc CloseRoom(@Number varchar(20))
as
	delete OpenRoomInfo where RoomId = (select RoomId from Room where Number = @Number)
go
---------------------------------------------------------------------------------------
/*�˷�����������*/
create trigger trig_Del
on OpenRoomInfo
for delete
as
	declare @RoomId int,@GuestNumber varchar(100),@GuestName varchar(50),@TypeId int,@RoomNumber varchar(20),
		@TypePrice money, @price money,@OpenTime datetime
	--��deleted���в鵽ɾ���ķ���Id,Ԥ�����,�Ǽ����֤,�Ǽ�����,����ʱ��
	select @RoomId = RoomId,@OpenTime = OpenTime,@GuestNumber = GuestNumber,@GuestName = GuestName from deleted
	select @TypeId = TypeId from Room where RoomId = @RoomId --�õ�����Id��Ӧ�ķ�������Id
	select @RoomNumber = Number from Room where RoomId = @RoomId --�õ�����ID��Ӧ�ķ�����
	select @TypePrice = TypePrice from RoomType where TypeId = @TypeId --�õ������͵ļ۸�
	insert into  MoneyInfo values(@OpenTime,@RoomNumber,@GuestNumber,@GuestName,default,@TypePrice)
go
insert into OpenRoomInfo values(1,'12345','chen',200,default,'������')
insert into OpenRoomInfo values(2,'54321','elva',200,default,'������')
insert into OpenRoomInfo values(4,'45678','jay',300,default,'������')
insert into OpenRoomInfo values(5,'78945','lele',400,default,'������')
insert into OpenRoomInfo values(9,'65487','aaaa',400,default,'������')
insert into OpenRoomInfo values(10,'32158','bbbb',500,default,'������')
insert into OpenRoomInfo values(15,'98789','cccc',500,default,'������')
insert into OpenRoomInfo values(19,'58256','dddd',800,default,'������')
insert into OpenRoomInfo values(21,'96965','eeee',1000,default,'������')
go
-------------------------------------------�Ƶ������洢����----------------------------------------
/*����(ȫ��,����ʱ���ѯ������)*/
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

