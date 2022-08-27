USE GuildCars
GO

IF EXISTS(SELECT * FROM sys.tables WHERE Name='Sale')
	DROP TABLE Sale
GO

IF EXISTS(SELECT * FROM sys.tables WHERE Name='State')
	DROP TABLE [State]
GO

IF EXISTS(SELECT * FROM sys.tables WHERE Name='PurchaseType')
	DROP TABLE PurchaseType
GO

IF EXISTS(SELECT * FROM sys.tables WHERE Name='Vehicle')
	DROP TABLE Vehicle
GO

IF EXISTS(SELECT * FROM sys.tables WHERE Name='Model')
	DROP TABLE Model
GO

IF EXISTS(SELECT * FROM sys.tables WHERE Name='Make')
	DROP TABLE Make
GO


IF EXISTS(SELECT * FROM sys.tables WHERE Name='Type')
	DROP TABLE [Type]
GO

IF EXISTS(SELECT * FROM sys.tables WHERE Name='BodyStyle')
	DROP TABLE BodyStyle
GO

IF EXISTS(SELECT * FROM sys.tables WHERE Name='Trans')
	DROP TABLE Trans
GO

IF EXISTS(SELECT * FROM sys.tables WHERE Name='ColorInt')
	DROP TABLE ColorInt
GO

IF EXISTS(SELECT * FROM sys.tables WHERE Name='ColorEx')
	DROP TABLE ColorEx
GO

IF EXISTS(SELECT * FROM sys.tables WHERE Name='Special')
	DROP TABLE Special
GO

IF EXISTS(SELECT * FROM sys.tables WHERE Name='Contact')
	DROP TABLE Contact
GO

CREATE TABLE Make (
	MakeId int identity(1,1) primary key NOT NULL,
	MakeName nvarchar(10) NOT NULL,
	DateAdded datetime2 NOT NULL,
	AddedByUser nvarchar(128) NOT NULL
)
GO

CREATE TABLE Model (
	ModelId int identity(1,1) primary key NOT NULL,
	MakeId int NOT NULL foreign key references Make(MakeId),
	ModelName nvarchar(20) NOT NULL,
	DateAdded datetime2 NOT NULL,
	AddedByUser nvarchar(128) NOT NULL
)
GO

CREATE TABLE [Type] (
	TypeId int identity(1,1) primary key NOT NULL,
	TypeName nvarchar(4) NOT NULL
)
GO

CREATE TABLE BodyStyle (
	BodyStyleId int identity(1,1) primary key NOT NULL,
	BodyStyleName nvarchar(10) NOT NULL
)
GO

CREATE TABLE Trans (
	TransId int identity(1,1) primary key NOT NULL,
	TransName nvarchar(10) NOT NULL
)
GO

CREATE TABLE ColorInt (
	ColorIntId int identity(1,1) primary key NOT NULL,
	ColorIntName nvarchar(10) NOT NULL
)
GO

CREATE TABLE ColorEx (
	ColorExId int identity(1,1) primary key NOT NULL,
	ColorExName nvarchar(10) NOT NULL
)
GO

CREATE TABLE Vehicle (
	VehicleId int identity(1,1) primary key not null,
	MakeId int NOT NULL foreign key references Make(MakeId),
	ModelId int NOT NULL foreign key references Model(ModelId),
	TypeId int NOT NULL foreign key references [Type](TypeId),
	BodyStyleId int NOT NULL foreign key references BodyStyle(BodyStyleId),
	TransId int NOT NULL foreign key references Trans(TransId),
	ColorIntId int NOT NULL foreign key references ColorInt(ColorIntId),
	ColorExId int NOT NULL foreign key references ColorEx(ColorExId),
	VIN nvarchar(17) NOT NULL,
	[Year] datetime2 NOT NULL,
	SalePrice decimal(7,2) NOT NULL,
	MSRP decimal(7,2) NOT NULL,
	Mileage int NOT NULL,
	[Description] nvarchar(200) NOT NULL,
	Picture nvarchar(50) NOT NULL,
	Featured bit,
	IsDeleted bit NOT NULL
)
GO

CREATE TABLE [State] (
	StateId int identity(1,1) primary key NOT NULL,
	StateAbbreviation nvarchar(2) NOT NULL
)
GO

CREATE TABLE PurchaseType (
	PurchaseTypeId int identity(1,1) primary key NOT NULL,
	PurchaseTypeName nvarchar(20) NOT NULL
)
GO

CREATE TABLE Sale (
	SaleId int identity(1,1) primary key NOT NULL,
	VehicleId int NOT NULL foreign key references Vehicle(VehicleId),
	StateId int NOT NULL foreign key references [State](StateId),
	PurchaseTypeId int NOT NULL foreign key references PurchaseType(PurchaseTypeId),
	Username nvarchar(128) NOT NULL,
	SaleName nvarchar(50) NOT NULL,
	SaleEmail nvarchar(50),
	SalePhone nvarchar(10),
	Street1 nvarchar(50) NOT NULL,
	Street2 nvarchar(50),
	City nvarchar(20) NOT NULL,
	Zipcode int NOT NULL,
	PurchasePrice decimal(7,2) NOT NULL,
	SaleDate datetime2 NOT NULL
)
GO

CREATE TABLE Special (
	SpecialId int identity(1,1) primary key NOT NULL,
	SpecialTitle nvarchar(50) NOT NULL,
	[Description] nvarchar(200) NOT NULL
)
GO

CREATE TABLE Contact (
	ContactId int identity(1,1) primary key NOT NULL,
	ContactName nvarchar(50) NOT NULL,
	ContactEmail nvarchar(50),
	ContactPhone nvarchar(10),
	[Message] nvarchar(200) NOT NULL
)
GO