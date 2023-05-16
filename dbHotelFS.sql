create database dbFourSeasonHotel

--drop database dbFourSeasonHotel

use dbFourSeasonHotel

create table [Role](
	RoleId int primary key identity,
	RoleName nvarchar(100) NOT NULL
)

create table [User](
	UserId int primary key identity,
	Email varchar(50) NOT NULL,
	[Password] varchar(50) NOT NULL,
	FullName nvarchar(255),
	[Address] nvarchar(255),
	Phone varchar(10),
	IDCard varchar(12),
	BirthDay date,
	RoleId int,
	Avatar varchar(max),
	[Status] varchar(20) NOT NULL,

	CONSTRAINT FK_User_Role FOREIGN KEY (RoleId) REFERENCES [Role](RoleId),
)

create table Room(
	RoomId int primary key identity,
	CategoryId int,
	RoomName nvarchar(255) NOT NULL,
	Price money NOT NULL,
	[Description] nvarchar(max),
	[Status] bit NOT NULL,

	CONSTRAINT FK_Room_Category FOREIGN KEY (CategoryId) REFERENCES Category(CategoryId),
)

create table Category(
	CategoryId int primary key identity,
	CategoryName nvarchar(255) NOT NULL,
	MaxPeople int NOT NULL,
	Size float NOT NULL,
	[Image] varchar(max),
	[Description] nvarchar(max),
	[Status] bit NOT NULL,
)

create table RoomImg(
	RoomId int,
	[Image] varchar(max) NOT NULL,

	CONSTRAINT FK_RoomImg_Room FOREIGN KEY (RoomId) REFERENCES Room(RoomId) ON DELETE CASCADE,
)

create table Booking(
	BookingId int primary key identity,
	UserId int NOT NULL,
	CreateDate datetime NOT NULL,
	CheckIn datetime NOT NULL,
	CheckOut datetime NOT NULL,
	TotalPrice money NOT NULL,
	[Status] nvarchar(100) NOT NULL,

	CONSTRAINT FK_User_Booking FOREIGN KEY (UserId) REFERENCES [User](UserId) ON DELETE CASCADE,
)

create table BookingDetail(
	BookingDetailId int primary key identity,
	
	BookingId int,
	RoomId int,

	CONSTRAINT FK_BookingDetail_Booking FOREIGN KEY (BookingId) REFERENCES Booking(BookingId) ON DELETE CASCADE,
	CONSTRAINT FK_BookingDetail_Room FOREIGN KEY (RoomId) REFERENCES Room(RoomId) ON DELETE CASCADE,

	--PRIMARY KEY (BookingId,RoomId)
)

INSERT INTO [Role](RoleName) VALUES ('Admin')
INSERT INTO [Role](RoleName) VALUES ('Manager')
INSERT INTO [Role](RoleName) VALUES ('Receptionist')
INSERT INTO [Role](RoleName) VALUES ('Guest')

INSERT INTO Category(CategoryName,MaxPeople,Size,[Status]) VALUES (N'Single Room',2,24,1)
INSERT INTO Category(CategoryName,MaxPeople,Size,[Status]) VALUES (N'Double Room',4,32,1)
INSERT INTO Category(CategoryName,MaxPeople,Size,[Status]) VALUES (N'President Room',12,300,1)

INSERT INTO Room(CategoryId,RoomName,Price,[Description],[Status]) VALUES (1,'Single Room 1',300000,
'Lorem Ipsum is simply dummy text of the printing and typesetting industry. 
Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, 
when an unknown printer took a galley of type and scrambled it to make a type specimen book.',1)

INSERT INTO Room(CategoryId,RoomName,Price,[Description],[Status]) VALUES (1,'Single Room 2',300000,
'Lorem Ipsum is simply dummy text of the printing and typesetting industry. 
Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, 
when an unknown printer took a galley of type and scrambled it to make a type specimen book.',1)

INSERT INTO Room(CategoryId,RoomName,Price,[Description],[Status]) VALUES (2,'Double Room 1',500000,
'Lorem Ipsum is simply dummy text of the printing and typesetting industry. 
Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, 
when an unknown printer took a galley of type and scrambled it to make a type specimen book.',1)

INSERT INTO Room(CategoryId,RoomName,Price,[Description],[Status]) VALUES (2,'Double Room 2',500000,
'Lorem Ipsum is simply dummy text of the printing and typesetting industry. 
Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, 
when an unknown printer took a galley of type and scrambled it to make a type specimen book.',1)

INSERT INTO Room(CategoryId,RoomName,Price,[Description],[Status]) VALUES (3,'President Room ',50000000,
'Lorem Ipsum is simply dummy text of the printing and typesetting industry. 
Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, 
when an unknown printer took a galley of type and scrambled it to make a type specimen book.',1)

INSERT INTO [User](Email,[Password],FullName,RoleId,[Status]) VALUES('Guest@gmail.com','123456','Guest',4,1)
INSERT INTO [User](Email,[Password],FullName,RoleId,[Status]) VALUES('Receptionist@gmail.com','123456','Receptionist',3,1)
INSERT INTO [User](Email,[Password],FullName,RoleId,[Status]) VALUES('Manager@gmail.com','123456','Manager',2,1)
INSERT INTO [User](Email,[Password],FullName,RoleId,[Status]) VALUES('Admin@gmail.com','123456','Admin',1,1)

SELECT *FROM [User]

INSERT INTO Booking(UserId,CreateDate,CheckIn,CheckOut,TotalPrice,[Status]) VALUES (1,GETDATE(),'2023/05/12','2023/05/16',1200000,1)
INSERT INTO Booking(UserId,CreateDate,CheckIn,CheckOut,TotalPrice,[Status]) VALUES (1,GETDATE(),'2023/05/12','2023/05/16',2000000,1)
INSERT INTO Booking(UserId,CreateDate,CheckIn,CheckOut,TotalPrice,[Status]) VALUES (1,GETDATE(),'2023/05/12','2023/05/16',200000000,1)

SELECT *FROM Room
SELECT *FROM Booking
SELECT *FROM BookingDetail

INSERT INTO BookingDetail(BookingId,RoomId) VALUES (4,1)
INSERT INTO BookingDetail(BookingId,RoomId) VALUES (5,3)
INSERT INTO BookingDetail(BookingId,RoomId) VALUES (6,5)
