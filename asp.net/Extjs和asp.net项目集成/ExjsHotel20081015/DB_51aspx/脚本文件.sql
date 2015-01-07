/*
==================�Ƶ����ϵͳ���ݾݿ�ű�==========================
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

/*��ɫ��Ϣ��*/
create table roleinfo
(
	roleid int identity(1,1) primary key,
	roleName varchar(20) not null,
	roleDesc varchar(50)--��ɫ����
)
go


/*�û���Ϣ��*/
create table userinfo
(
	id int identity(1,1) primary key,
	userid varchar(20) not null, --��½��
	userName varchar(20) not null,--��ʵ����
	userPwd varchar(20) not null,--��½����
	userState int check(userState in (0,1)) default(0) not null,--0:����,1:ͣ��
	roleid int not null --��ɫ��Ϣ���
)
go


/*����Ȩ�˵���*/
create table nav
(
	navid int identity(1,1) primary key,--��ʶID
	id int not null, --�ڵ�ID
	parentid int not null,--���ڵ�ID
	title varchar(50) not null,--�ڵ��ı�
	leaf int not null,
	iconCls varchar(50) not null,
	number int not null,
	url varchar(50) not null--�ڵ�url
	
)
go

---------------------------------------------/*�������ͱ�*/
create table roomtype
(
	typeid int identity(1,1) primary key,
	typeName varchar(20) not null,
	typePrice money not null,
	typeAddBed varchar(10) check (typeAddBed in('��','��')) not null,
	addbed money not null,--�Ӵ��۸�
	typeDesc varchar(100) not null
)
go


--------------------------------------------/*������Ϣ��*/
create table room
(
	roomid int identity(1,1) primary key,
	Number varchar(20) not null,--������
	bedNumber int not null,
	guestNumber int not null,--��ס���� 
	typeid int not null, --������������
	roomstate int not null,--����״̬
	roomDesc varchar(50) not null
)
go

-------------------------------------------/*������Ϣ��*/
create table GuestInfo
(
	Guestid int identity(1,1) primary key,
	GuestCardID numeric(18) not null,--���֤����
	GuestName varchar(20) not null,
	GuestSex int check(GuestSex in(0,1)) not null,
	GuestMobile numeric(13) not null,
	GuestAddress varchar(100) not null,
)
go
---------------------------------------------/*������ס��Ϣ��*/
create table OpenRoomInfo
(
	OpenRoomID int identity(1,1) primary key,
        Roomid int not null,--������
	Guestid int not null,--���˱��
	GuestMoney money not null,--����
	OpenTodayTime varchar(30) not null,
	OpenTime varchar(30)  not null,--����ʱ��
	Remark varchar(100)
)
go
---------------------------------------------------//������¼��
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

------------------------------------------------/*����Ԥ����Ϣ����ʱû��*/
create table OrderRoomInfo
(
	OrderID int identity(1,1) primary key,
 	Roomid int not null,--������
	Guestid int not null,--���˱��
	OrderTime datetime default(getdate()) not null,--�¶���ʱ��
	ArrvalTime datetime not null, --�ƻ�����ʱ��
	orderSate int default(0),--�Ƿ�Ԥ�� 0:δԤ��,1:��Ԥ��,2:��ס
	Remark varchar(50)
)
go

------------------------------------------------------/*�Ƶ�������Ϣ��*/
create table TotalInfo
(
	totalID int identity(1,1) primary key,
	totalType varchar(20) check(totalType in ('����','����')) not null,--������Դ
	totalMoney money not null,--���
	totalTime datetime default(getdate()),--¼��ʱ��
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




/*��������*/--��ɫ
insert into roleinfo values('��ӪԱ','��ϵͳ��Ҫʹ�ö���')
insert into roleinfo values('ϵͳ����Ա','��ϵͳȨ�������')
insert into roleinfo values('����','ĿǰΪֹ���κ�Ȩ��')
go
---�û���
insert into userinfo values('aaa','����Ա','aaa',default,1)
insert into userinfo values('kkk','����Ա','kkk',1,1)
insert into userinfo values('admin','�ܾ���','admin',default,2)
go


------------------------------------------------����ԱȨ��
insert into nav values(2,1,'<b><font color=#008B8B>ϵͳ����˵�</font></b>',0,'sysmanagemenu',1,'')
insert into nav values(3,1,'<b><font color=#008B8B>�������˵�</font></b>',0,'homemanage',2,'')
insert into nav values(4,1,'<b><font color=#008B8B>�ۺ���Ϣ����</font></b>',0,'allmanagemenu',3,'')

insert into nav values(5,2,'������Ϣ����',1,'publishicon',1,'')
insert into nav values(6,2,'�û���Ϣ����',1,'usericon',2,'')
insert into nav values(7,2,'������¼����',1,'roolrecordicon',3,'')
insert into nav values(8,2,'�Ƶ����뱨��',1,'totalicon',4,'')

insert into nav values(9,3,'<font color=red>���跿��</font>',1,'openroomicon',2,'')
insert into nav values(10,3,'������Ϣ����',1,'openroomiconinfo',3,'')
insert into nav values(11,3,'������Ϣ����',1,'roomicons',3,'')
insert into nav values(12,3,'�������͹���',1,'roomtypeicon',1,'')

insert into nav values(13,4,'������Ϣ����',1,'guesticon',6,'')


------------------------------------------------ҵ��ԱȨ��
insert into nav values(15,100,'<b><font color=#008B8B>ϵͳ����˵�</font></b>',0,'sysmanagemenu',1,'')
insert into nav values(16,100,'<b><font color=#008B8B>�������˵�</font></b>',0,'homemanage',2,'')
insert into nav values(17,100,'<b><font color=#008B8B>�ۺ���Ϣ����</font></b>',0,'allmanagemenu',3,'')

insert into nav values(18,15,'�޸��ʻ�����',1,'setuseridicon',3,'')

insert into nav values(19,16,'<font color=red>���跿��</font>',1,'openroomicon',1,'')
insert into nav values(20,16,'������Ϣ����',1,'openroomiconinfo',2,'')
insert into nav values(21,16,'������Ϣ����',1,'roomicons',3,'')
insert into nav values(22,16,'�������͹���',1,'roomtypeicon',4,'')

insert into nav values(23,17,'������Ϣ����',1,'guesticon',1,'')

----------------------------------------------------

---��������
insert into roomtype values('���˼�',288,'��',0,'һ�����Ϊ16~20ƽ���׵ķ���')
insert into roomtype values('��׼��',388,'��',100,'���������ŵ��˴���һ��˫�˴��Ľб�׼��')
insert into roomtype values('������',666,'��',200,'���������ŵ��˴���һ��˫�˴��������װ��')
insert into roomtype values('������',888,'��',200,'���ڿ�������������������˵�����')
insert into roomtype values('�߼��׷�',5888,'��',500,'�������˼䷿��ɵ��׼䣬������С�ư�')
insert into roomtype values('�����׷�',8888,'��',888,'��¥�ϡ�¥��������ɣ�¥��Ϊ����')


select * from room
----������Ϣ��ѯ
insert into room values('101',1,1,1,0,'����������ż�������Ƚ���')
insert into room values('102',2,2,2,1,'��102���������ȽϺã�Ҳ��102���ص�')
insert into room values('103',2,2,2,0,'һ¥���һ�䣬��������')
insert into room values('201',2,2,2,3,'��¥��һ�䣬�羰����')
insert into room values('202',4,4,3,0,'װ�ޱȽϺã����䲻��')
insert into room values('203',5,5,4,4,'�÷����������������������')
insert into room values('301',4,4,3,0,'�ϰ����ʺ�һ����ס-����')
insert into room values('302',7,7,5,0,'��¥�м�һ�䣬��������')
insert into room values('303',7,7,5,3,'�÷���ȽϺã�������ô˵��')
insert into room values('401',5,5,4,0,'װ�ޱȽϺã����䲻��')
insert into room values('402',2,2,2,2,'���䲼�úܺã����ϳ���')
insert into room values('403',4,4,3,0,'�÷����������������������')
insert into room values('501',10,10,6,0,'װ�ޱȽϺã����䲻��')
insert into room values('502',10,10,6,4,'�Ӷ�����Ҳ�ǳ�ϲ����䷿')
insert into room values('503',10,10,6,1,'����Ҧ���ڴ˾�ס������Դ����')
-----������Ϣ��

insert into guestinfo values(500113198801011010,'ľ����',0,13987654321,'���������·̫��������3��')
insert into guestinfo values(500113124242142344,'�ǵ�',0,13298987877,'������ɼ��')
insert into guestinfo values(500154321423142334,'�Ʊ�',1,13098766672,'������ʥ��')
insert into guestinfo values(509765325235745632,'�׽���',0,13987654321,'�й���5��')
insert into guestinfo values(108923412543233455,'����',1,13987654321,'�й��Ϻ�8��')
insert into guestinfo values(500154321423142334,'����',1,13098766672,'������ʥ��')
insert into guestinfo values(509765325235745632,'����',0,13987654321,'�й���5��')
insert into guestinfo values(108923412543233455,'����С',1,13987654321,'�й��Ϻ�8��')


--------��ס��Ϣ��
select * from openroominfo
insert into openroominfo values('101',1,100,'2008-09-01','11:45:15','����������Ϣ')
insert into openroominfo values('102',2,100,'2008-09-01','10:24:15','����������Ϣ')
insert into openroominfo values('103',3,200,'2008-09-01','14:13:15','����������Ϣ')
insert into openroominfo values('201',4,200,'2008-09-02','16:25:15','����������Ϣ')
insert into openroominfo values('202',5,200,'2008-09-02','17:11:15','����������Ϣ')
insert into openroominfo values('203',6,100,'2008-09-02','18:16:15','����������Ϣ')
insert into openroominfo values('301',6,100,'2008-09-03','19:21:15','����������Ϣ')
insert into openroominfo values('302',5,200,'2008-09-03','11:25:15','����������Ϣ')
insert into openroominfo values('303',4,200,'2008-09-04','05:33:15','����������Ϣ')
insert into openroominfo values('401',3,200,'2008-09-04','09:25:15','����������Ϣ')
insert into openroominfo values('402',2,100,'2008-09-04','03:25:15','����������Ϣ')
insert into openroominfo values('403',1,100,'2008-09-05','02:12:15','����������Ϣ')
insert into openroominfo values('501',2,200,'2008-09-05','04:25:15','����������Ϣ')
insert into openroominfo values('502',3,200,'2008-09-05','15:22:15','����������Ϣ')
insert into openroominfo values('503',4,200,'2008-09-05','17:34:15','����������Ϣ')
insert into openroominfo values('101',5,100,'2008-09-05','18:25:15','����������Ϣ')
go
--����������Ϣ

insert into totalinfo values('����',200.00,'2008-10-01 10:11:12.000','���ޱ�ע')
insert into totalinfo values('����',12200.00,'2008-10-02 14:05:12','���ޱ�ע')
insert into totalinfo values('����',100.00,'2008-10-03 22:44:12','���ޱ�ע')
insert into totalinfo values('����',2288.00,'2008-10-04 21:32:12','���ޱ�ע')
insert into totalinfo values('����',100.00,'2008-10-05 08:11:12','���ޱ�ע')
insert into totalinfo values('����',2299.00,'2008-10-06 09:17:12','���ޱ�ע')

--���뿪����¼��Ϣ

insert into openroomrecordinfo values(101,1,200.00,'2008-10-01','10:00:25','2008-10-04','12:01:32','���ޱ�ע��Ϣ')
insert into openroomrecordinfo values(202,2,150.00,'2008-10-02','08:11:25','2008-10-03','18:21:12','���ޱ�ע��Ϣ')
insert into openroomrecordinfo values(301,3,500.00,'2008-10-03','06:35:25','2008-10-05','21:43:42','���ޱ�ע��Ϣ')
insert into openroomrecordinfo values(501,4,600.00,'2008-10-04','07:45:25','2008-10-05','22:25:16','���ޱ�ע��Ϣ')
insert into openroomrecordinfo values(303,5,700.00,'2008-10-05','18:66:25','2008-10-07','17:41:27','���ޱ�ע��Ϣ')
go

--���뿪����Ϣ�洢����
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
	insert into TotalInfo values('����',@GuestMoney,default,@Remark)
go

--�����ɹ����޸ķ���״̬������
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
--���������Ϣ�洢����
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

-----ɾ��������Ϣ���ӿ�����¼���޸ķ���״̬������

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

--------------��ѯ���Ѵ洢���̲���һ�찴һ����
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

--���빫����Ϣ�洢����
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

exec proc_InsertPublish 'admin','9-1������ŵ�!����������','������ž�����9-1������ŵ�!����������,���׼ʱ'
exec proc_InsertPublish 'admin','9-5�ճ�����ʱȡ����ʱ�����!','9-5�ճ�����ʱȡ����ʱ����������໥ת��!'
exec proc_InsertPublish 'admin','9-20�ž�����Ӿ����!','20�ž�����Ӿ����,�������ѡ�ֻ���׼�����ó���õĳɼ�'
exec proc_InsertPublish 'admin','ף�Ƶ�Ա������ڿ���!','���������֮�ʣ�ףMarriott�Ƶ�ȫ��Ա���������!�ϼ��Ҹ�!'


/*�鿴����*/
select * from publish
select * from roleinfo
select * from userinfo 
select * from nav
select * from roomtype
select * from room
select * from OpenRoomInfo
select * from GuestInfo
select * from totalinfo

