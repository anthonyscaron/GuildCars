USE GuildCars
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DbReset')
DROP PROCEDURE DbReset
GO

CREATE PROCEDURE DbReset AS
BEGIN
	DELETE FROM Contact;
	DELETE FROM Special;
	DELETE FROM Sale;
	DELETE FROM PurchaseType;
	DELETE FROM [State];
	DELETE FROM Vehicle;
	DELETE FROM ColorEx;
	DELETE FROM ColorInt;
	DELETE FROM Trans;
	DELETE FROM BodyStyle;
	DELETE FROM [Type];
	DELETE FROM Model;
	DELETE FROM Make;
	--DELETE FROM AspNetUserRoles;
	--DELETE FROM AspNetRoles;
	--DELETE FROM AspNetUsers;

	DBCC CHECKIDENT ('Contact', RESEED, 1)
	DBCC CHECKIDENT ('Special', RESEED, 1)
	DBCC CHECKIDENT ('Sale', RESEED, 1)
	DBCC CHECKIDENT ('PurchaseType', RESEED, 1)
	DBCC CHECKIDENT ('[State]', RESEED, 1)
	DBCC CHECKIDENT ('Vehicle', RESEED, 1)
	DBCC CHECKIDENT ('ColorEx', RESEED, 1)
	DBCC CHECKIDENT ('ColorInt', RESEED, 1)
	DBCC CHECKIDENT ('Trans', RESEED, 1)
	DBCC CHECKIDENT ('BodyStyle', RESEED, 1)
	DBCC CHECKIDENT ('[Type]', RESEED, 1)
	DBCC CHECKIDENT ('Model', RESEED, 1)
	DBCC CHECKIDENT ('Make', RESEED, 1)

	SET IDENTITY_INSERT Make ON;

	INSERT INTO Make (MakeId, MakeName, DateAdded, AddedByUser)
	VALUES (1, 'Honda', '2022-07-01', 'robdenno@guildcars.com'),
	(2, 'Lexus', '2022-07-01', 'robdenno@guildcars.com'),
	(3, 'Mazda', '2022-07-10', 'robdenno@guildcars.com'),
	(4, 'Subaru', '2022-07-20', 'robdenno@guildcars.com'),
	(5, 'Toyota', '2022-07-20', 'robdenno@guildcars.com')

	SET IDENTITY_INSERT Make OFF;

	SET IDENTITY_INSERT Model ON;

	INSERT INTO Model (ModelId, MakeId, ModelName, DateAdded, AddedByUser)
	VALUES (1, 1, 'Civic', '2022-07-01', 'robdenno@guildcars.com'),
	(2, 1, 'Accord', '2022-07-01', 'robdenno@guildcars.com'),
	(3, 2, 'RX', '2022-07-01', 'robdenno@guildcars.com'),
	(4, 2, 'IS', '2022-07-01', 'robdenno@guildcars.com'),
	(5, 3, 'CX5', '2022-07-10', 'robdenno@guildcars.com'),
	(6, 3, '3', '2022-07-10', 'robdenno@guildcars.com'),
	(7, 4, 'Ascent', '2022-07-20', 'robdenno@guildcars.com'),
	(8, 4, 'Outback', '2022-07-20', 'robdenno@guildcars.com'),
	(9, 5, 'Camry', '2022-07-20', 'robdenno@guildcars.com'),
	(10, 5, 'Highlander', '2022-07-20', 'robdenno@guildcars.com')

	SET IDENTITY_INSERT Model OFF;

	SET IDENTITY_INSERT [Type] ON;

	INSERT INTO [Type] (TypeId, TypeName)
	VALUES (1, 'New'),
	(2, 'Used')

	SET IDENTITY_INSERT [Type] OFF;

	SET IDENTITY_INSERT BodyStyle ON;

	INSERT INTO BodyStyle (BodyStyleId, BodyStyleName)
	VALUES (1, 'Car'),
	(2, 'Truck'),
	(3, 'Van'),
	(4, 'SUV')

	SET IDENTITY_INSERT BodyStyle OFF;

	SET IDENTITY_INSERT Trans ON;

	INSERT INTO Trans (TransId, TransName)
	VALUES (1, 'Manual'),
	(2, 'Automatic')

	SET IDENTITY_INSERT Trans OFF;

	SET IDENTITY_INSERT ColorInt ON;

	INSERT INTO ColorInt (ColorIntId, ColorIntName)
	VALUES (1, 'Black'),
	(2, 'Gray'),
	(3, 'Tan'),
	(4, 'White'),
	(5, 'Red')

	SET IDENTITY_INSERT ColorInt OFF;

	SET IDENTITY_INSERT ColorEx ON;

	INSERT INTO ColorEx (ColorExId, ColorExName)
	VALUES (1, 'Black'),
	(2, 'Blue'),
	(3, 'Gray'),
	(4, 'Red'),
	(5, 'Silver'),
	(6, 'White')

	SET IDENTITY_INSERT ColorEx OFF;

	SET IDENTITY_INSERT Vehicle ON;

	INSERT INTO Vehicle (VehicleId, MakeId, ModelId, TypeId, BodyStyleId, TransId, ColorIntId, ColorExId, 
		VIN, [Year], SalePrice, MSRP, Mileage, [Description], Picture, Featured, IsDeleted)
	VALUES (1, 1, 1, 1, 1, 1, 1, 6, 'ABCDEFGH000000001', '2022-01-01', 25000.00, 26000.00, 0, '4 Cylinder with 30 City / 37 Hwy Fuel Efficiency', 'inventory-1.jpg', 0, 1),
	(2, 1, 1, 1, 1, 2, 1, 3, 'ABCDEFGH000000002', '2022-01-01', 26000.00, 27000.00, 0, '4 Cylinder with 33 City / 42 Hwy Fuel Efficiency', 'inventory-2.jpg', 1, 0),
	(3, 1, 1, 1, 1, 2, 1, 1, 'ABCDEFGH000000003', '2022-01-01', 28000.00, 29000.00, 0, '4 Cylinder with 31 City / 39 Hwy Fuel Efficiency', 'inventory-3.jpg', 0, 0),
	(4, 1, 2, 1, 1, 1, 1, 1, 'ABCDEFGH000000004', '2022-01-01', 29000.00, 30000.00, 0, '4 Cylinder with 29 City / 35 Hwy Fuel Efficiency', 'inventory-4.jpg', 0, 0),
	(5, 1, 2, 1, 1, 2, 1, 3, 'ABCDEFGH000000005', '2022-01-01', 35000.00, 36000.00, 0, '4 Cylinder with 22 City / 32 Hwy Fuel Efficiency', 'inventory-5.jpg', 1, 0),
	(6, 1, 2, 1, 1, 2, 2, 6, 'ABCDEFGH000000006', '2022-01-01', 27000.00, 28000.00, 0, '4 Cylinder with 30 City / 38 Hwy Fuel Efficiency', 'inventory-6.jpg', 0, 0),
	(7, 2, 3, 1, 4, 2, 1, 5, 'ABCDEFGH000000007', '2022-01-01', 55000.00, 57000.00, 0, '6 Cylinder with 19 City / 26 Hwy Fuel Efficiency', 'inventory-7.jpg', 0, 1),
	(8, 2, 3, 1, 4, 1, 3, 2, 'ABCDEFGH000000008', '2022-01-01', 58000.00, 60000.00, 0, '6 Cylinder with 19 City / 26 Hwy Fuel Efficiency', 'inventory-8.jpg', 0, 0),
	(9, 2, 3, 1, 4, 2, 1, 4, 'ABCDEFGH000000009', '2022-01-01', 56000.00, 58000.00, 0, '6 Cylinder with 19 City / 26 Hwy Fuel Efficiency', 'inventory-9.jpg', 1, 0),
	(10, 2, 4, 1, 1, 1, 1, 4, 'ABCDEFGH000000010', '2022-01-01', 50000.00, 52000.00, 0, '6 Cylinder with 20 City / 27 Hwy Fuel Efficiency', 'inventory-10.jpg', 0, 1),
	(11, 2, 4, 1, 2, 2, 2, 6, 'ABCDEFGH000000011', '2022-01-01', 52000.00, 54000.00, 0, '6 Cylinder with 20 City / 27 Hwy Fuel Efficiency', 'inventory-11.jpg', 1, 0),
	(12, 2, 4, 1, 2, 2, 1, 3, 'ABCDEFGH000000012', '2022-01-01', 51000.00, 53000.00, 0, '6 Cylinder with 20 City / 27 Hwy Fuel Efficiency', 'inventory-12.jpg', 0, 0),
	(13, 3, 5, 1, 4, 2, 1, 4, 'ABCDEFGH000000013', '2022-01-01', 30000.00, 31000.00, 0, '4 Cylinder with 24 City / 30 Hwy Fuel Efficiency', 'inventory-13.jpg', 0, 0),
	(14, 3, 5, 1, 4, 2, 1, 1, 'ABCDEFGH000000014', '2022-01-01', 27000.00, 28000.00, 0, '4 Cylinder with 24 City / 30 Hwy Fuel Efficiency', 'inventory-14.jpg', 0, 1),
	(15, 3, 5, 1, 4, 1, 2, 6, 'ABCDEFGH000000015', '2022-01-01', 30000.00, 31000.00, 0, '4 Cylinder with 24 City / 30 Hwy Fuel Efficiency', 'inventory-15.jpg', 1, 0),
	(16, 3, 6, 1, 1, 2, 3, 1, 'ABCDEFGH000000016', '2022-01-01', 35000.00, 36000.00, 0, '4 Cylinder with 23 City / 31 Hwy Fuel Efficiency', 'inventory-16.jpg', 1, 0),
	(17, 3, 6, 1, 1, 2, 3, 6, 'ABCDEFGH000000017', '2022-01-01', 35000.00, 36000.00, 0, '4 Cylinder with 23 City / 31 Hwy Fuel Efficiency', 'inventory-17.jpg', 0, 0),
	(18, 3, 6, 1, 1, 1, 3, 1, 'ABCDEFGH000000018', '2022-01-01', 34000.00, 35000.00, 0, '4 Cylinder with 23 City / 31 Hwy Fuel Efficiency', 'inventory-18.jpg', 0, 1),
	(19, 4, 7, 1, 4, 2, 1, 4, 'ABCDEFGH000000019', '2022-01-01', 44000.00, 46000.00, 0, '4 Cylinder with 20 City / 26 Hwy Fuel Efficiency', 'inventory-19.jpg', 0, 0),
	(20, 4, 7, 1, 4, 2, 3, 2, 'ABCDEFGH000000020', '2022-01-01', 44000.00, 46000.00, 0, '4 Cylinder with 20 City / 26 Hwy Fuel Efficiency', 'inventory-20.jpg', 0, 1),
	(21, 4, 7, 1, 4, 2, 2, 4, 'ABCDEFGH000000021', '2022-01-01', 38000.00, 39000.00, 0, '4 Cylinder with 20 City / 26 Hwy Fuel Efficiency', 'inventory-21.jpg', 0, 0),
	(22, 4, 8, 1, 3, 2, 1, 1, 'ABCDEFGH000000022', '2022-01-01', 35000.00, 36000.00, 0, '4 Cylinder with 26 City / 33 Hwy Fuel Efficiency', 'inventory-22.jpg', 0, 0),
	(23, 4, 8, 1, 3, 1, 1, 2, 'ABCDEFGH000000023', '2022-01-01', 30000.00, 31000.00, 0, '4 Cylinder with 26 City / 33 Hwy Fuel Efficiency', 'inventory-23.jpg', 0, 0),
	(24, 4, 8, 1, 3, 2, 2, 6, 'ABCDEFGH000000024', '2022-01-01', 34000.00, 35000.00, 0, '4 Cylinder with 26 City / 33 Hwy Fuel Efficiency', 'inventory-24.jpg', 1, 0),
	(25, 5, 9, 1, 1, 2, 1, 6, 'ABCDEFGH000000025', '2022-01-01', 34000.00, 35000.00, 0, '4 Cylinder with 25 City / 34 Hwy Fuel Efficiency', 'inventory-25.jpg', 0, 1),
	(26, 5, 9, 1, 1, 1, 1, 1, 'ABCDEFGH000000026', '2022-01-01', 35000.00, 36000.00, 0, '4 Cylinder with 25 City / 34 Hwy Fuel Efficiency', 'inventory-26.jpg', 1, 0),
	(27, 5, 9, 1, 1, 2, 1, 1, 'ABCDEFGH000000027', '2022-01-01', 34000.00, 35000.00, 0, '4 Cylinder with 25 City / 34 Hwy Fuel Efficiency', 'inventory-27.jpg', 0, 0),
	(28, 5, 10, 1, 4, 2, 1, 1, 'ABCDEFGH000000028', '2022-01-01', 43000.00, 45000.00, 0, '4 Cylinder with 20 City / 27 Hwy Fuel Efficiency', 'inventory-28.jpg', 0, 0),
	(29, 5, 10, 1, 4, 2, 1, 3, 'ABCDEFGH000000029', '2022-01-01', 46000.00, 48000.00, 0, '4 Cylinder with 20 City / 27 Hwy Fuel Efficiency', 'inventory-29.jpg', 0, 1),
	(30, 5, 10, 1, 4, 1, 2, 3, 'ABCDEFGH000000030', '2022-01-01', 44000.00, 46000.00, 0, '4 Cylinder with 20 City / 27 Hwy Fuel Efficiency', 'inventory-30.jpg', 0, 0),
	(31, 5, 10, 2, 4, 2, 1, 2, 'ABCDEFGH000000031', '2018-01-01', 39000.00, 40000.00, 45889, '4 Cylinder with 20 City / 26 Hwy Fuel Efficiency', 'inventory-31.jpg', 0, 0),
	(32, 1, 1, 2, 1, 2, 1, 3, 'ABCDEFGH000000032', '2016-01-01', 17500.00, 18000.00, 121151, '4 Cylinder with 31 City / 42 Hwy Fuel Efficiency', 'inventory-32.jpg', 0, 0),
	(33, 3, 5, 2, 4, 2, 1, 3, 'ABCDEFGH000000033', '2014-01-01', 15500.00, 16000.00, 130769, '4 Cylinder with 24 City / 30 Hwy Fuel Efficiency', 'inventory-33.jpg', 0, 0),
	(34, 1, 2, 2, 1, 1, 1, 2, 'ABCDEFGH000000034', '2016-01-01', 17500.00, 18000.00, 144726, '4 Cylinder with 27 City / 37 Hwy Fuel Efficiency', 'inventory-34.jpg', 0, 1),
	(35, 2, 3, 2, 4, 2, 1, 4, 'ABCDEFGH000000035', '2019-01-01', 40000.00, 42000.00, 32153, '6 Cylinder with 19 City / 26 Hwy Fuel Efficiency', 'inventory-35.jpg', 0, 0),
	(36, 3, 6, 2, 1, 2, 1, 4, 'ABCDEFGH000000036', '2019-01-01', 24000.00, 25000.00, 25128, '4 Cylinder with 26 City / 35 Hwy Fuel Efficiency', 'inventory-36.jpg', 0, 0),
	(37, 5, 10, 2, 4, 2, 1, 3, 'ABCDEFGH000000037', '2020-01-01', 40000.00, 42000.00, 10280, '4 Cylinder with 20 City / 27 Hwy Fuel Efficiency', 'inventory-37.jpg', 0, 0),
	(38, 2, 4, 2, 1, 1, 1, 1, 'ABCDEFGH000000038', '2019-01-01', 39000.00, 40000.00, 23507, '6 Cylinder with 20 City / 27 Hwy Fuel Efficiency', 'inventory-38.jpg', 0, 0),
	(39, 4, 8, 2, 3, 2, 2, 5, 'ABCDEFGH000000039', '2017-01-01', 22000.00, 23000.00, 91552, '4 Cylinder with 25 City / 32 Hwy Fuel Efficiency', 'inventory-39.jpg', 0, 1),
	(40, 4, 7, 2, 4, 2, 1, 1, 'ABCDEFGH000000040', '2021-01-01', 43000.00, 45000.00, 7701, '4 Cylinder with 20 City / 26 Hwy Fuel Efficiency', 'inventory-40.jpg', 0, 0)

	SET IDENTITY_INSERT Vehicle OFF;

	SET IDENTITY_INSERT [State] ON;

	INSERT INTO [State] (StateId, StateAbbreviation)
	VALUES (1, 'AK'),
	(2, 'AL'),
	(3, 'AR'),
	(4, 'AZ'),
	(5, 'CA'),
	(6, 'CO'),
	(7, 'CT'),
	(8, 'DE'),
	(9, 'FL'),
	(10, 'GA'),
	(11, 'HI'),
	(12, 'IA'),
	(13, 'ID'),
	(14, 'IL'),
	(15, 'IN'),
	(16, 'KS'),
	(17, 'KY'),
	(18, 'LA'),
	(19, 'MA'),
	(20, 'MD'),
	(21, 'ME'),
	(22, 'MI'),
	(23, 'MN'),
	(24, 'MO'),
	(25, 'MS'),
	(26, 'MT'),
	(27, 'NC'),
	(28, 'ND'),
	(29, 'NE'),
	(30, 'NH'),
	(31, 'NJ'),
	(32, 'NM'),
	(33, 'NV'),
	(34, 'NY'),
	(35, 'OH'),
	(36, 'OK'),
	(37, 'OR'),
	(38, 'PA'),
	(39, 'RI'),
	(40, 'SC'),
	(41, 'SD'),
	(42, 'TN'),
	(43, 'TX'),
	(44, 'UT'),
	(45, 'VA'),
	(46, 'VT'),
	(47, 'WA'),
	(48, 'WI'),
	(49, 'WV'),
	(50, 'WY')

	SET IDENTITY_INSERT [State] OFF;
	
	SET IDENTITY_INSERT PurchaseType ON;

	INSERT INTO PurchaseType (PurchaseTypeId, PurchaseTypeName)
	VALUES (1, 'Dealer Finance'),
	(2, 'Bank Finance'),
	(3, 'Cash')

	SET IDENTITY_INSERT PurchaseType OFF;

	SET IDENTITY_INSERT Sale ON;

	INSERT INTO Sale (SaleId, VehicleId, Username, SaleName, SaleEmail, SalePhone,
		Street1, Street2, City, StateId, Zipcode, PurchasePrice, PurchaseTypeId, SaleDate)
	VALUES (1, 1, 'billanmcmillan@guildcars.com', 'Carl First', 'carl@test.com', '5551112222', '123 Potato Street', 'Apt 1', 'Minneapolis', 23, 55408, 25000.00, 1, '2021-10-20'),
	(2, 7, 'devynsusquatch@guildcars.com', 'Gary Second', 'gary@test.com', '5552223333', '987 Carrot Avenue', 'Unit 9', 'Saint Paul', 23, 55102, 55000.00, 2, '2021-11-21'),
	(3, 10, 'teejayones@guildcars.com', 'Mary Third', 'mary@test.com', '5553334444', '5 Yam Street', null, 'Apple Valley', 23, 55124, 50000.00, 3, '2021-12-22'),
	(4, 14, 'teejayones@guildcars.com', 'Jaime Fourth', 'jaime@test.com', '5554445555', '456 Sweet Potato Avenue', null, 'Eagan', 23, 55123, 27000.00, 1, '2022-01-23'),
	(5, 18, 'devynsusquatch@guildcars.com', 'Rick Fifth', 'rick@test.com', '5555556666', '753 Parsnip Street', 'Apt 101', 'Burnsville', 23, 55337, 34000.00, 2, '2022-02-24'),
	(6, 20, 'billanmcmillan@guildcars.com', 'Jennifer Sixth', 'jennifer@test.com', '5556667777', '852 Turnip Avenue', 'Unit 6B', 'Farmington', 23, 55024, 44000.00, 3, '2022-03-25'),
	(7, 25, 'billanmcmillan@guildcars.com', 'Steve Seventh', 'steve@test.com', '5557778888', '1937 Radish Street', null, 'Lakeville', 23, 55044, 34000.00, 1, '2022-04-26'),
	(8, 29, 'devynsusquatch@guildcars.com', 'Oliver Eighth', 'oliver@test.com', '5558889999', '78523 Ginger Avenue', null, 'Rosemount', 23, 55068, 46000.00, 2, '2022-05-27'),
	(9, 34, 'teejayones@guildcars.com', 'Harold Nineth', 'harold@test.com', '5559990000', '96541 Beet Street', 'Apt 369', 'Inver Grove Heights', 23, 55077, 17500.00, 3, '2022-06-28'),
	(10, 39, 'teejayones@guildcars.com', 'Phil Tenth', 'phil@test.com', '5550001111', '7 Rutabaga Avenue', 'Unit 888', 'Mendota Heights', 23, 55121, 22000.00, 1, '2022-07-29')

	SET IDENTITY_INSERT Sale OFF;

	SET IDENTITY_INSERT Special ON;

	INSERT INTO Special (SpecialId, SpecialTitle, [Description])
	VALUES (1, 'Summer Sale Surge', 'All vehicles are up to $2,000.00 off all summer long!'),
	(2, 'Sunday SUV Special', 'Save up to $1,000.00 on all SUV any Sunday this month!'),
	(3, 'Labor Day Special', 'This coming Labor Day save up to $3,000.00!')

	SET IDENTITY_INSERT Special OFF;

	SET IDENTITY_INSERT Contact ON;

	INSERT INTO Contact (ContactId, ContactName, ContactEmail, ContactPhone, [Message])
	VALUES (1, 'Joe Schmoe', 'joeschmoe@test.com', '5551234567', 'Please call me tomorrow!'),
	(2, 'Judy Rudy', 'judyrudy@test.com', null, ('Hello, I am interested in VIN#: ABCDEFGH000000003. Please contact me.') )

	SET IDENTITY_INSERT Contact OFF;

	--INSERT INTO AspNetRoles (Id, [Name])
	--VALUES (1, 'Admin'),
	--(2, 'Sales'),
	--(3, 'Disabled')

	--INSERT INTO AspNetUsers (Id, FirstName, LastName, Email, EmailConfirmed, PasswordHash, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, UserName)
	--VALUES ('00000000-0000-0000-0000-000000000001', 'Rob', 'Denno', 'robdenno@guildcars.com', 1, 'Password123', 0, 0, 0, 0, 'robdenno@guildcars.com'),
	--('00000000-0000-0000-0000-000000000002', 'Billan', 'McMillan', 'billanmcmillan@guildcars.com', 1, 'Password123', 0, 0, 0, 0, 'billanmcmillan@guildcars.com'),
	--('00000000-0000-0000-0000-000000000003', 'Devyn', 'Susquatch', 'devynsusquatch@guildcars.com', 1, 'Password123', 0, 0, 0, 0, 'devynsusquatch@guildcars.com'),
	--('00000000-0000-0000-0000-000000000004', 'Teejay', 'Ones', 'teejayones@guildcars.com', 1, 'Password123', 0, 0, 0, 0, 'teejayones@guildcars.com'),
	--('00000000-0000-0000-0000-000000000005', 'Bitor', 'Himagahd', 'bitorhimagahd@guildcars.com', 1, 'Password123', 0, 0, 0, 0, 'bitorhimagahd@guildcars.com')

	--INSERT INTO AspNetUserRoles (UserId, RoleId)
	--VALUES ('00000000-0000-0000-0000-000000000001', 1),
	--('00000000-0000-0000-0000-000000000002', 2),
	--('00000000-0000-0000-0000-000000000003', 2),
	--('00000000-0000-0000-0000-000000000004', 2),
	--('00000000-0000-0000-0000-000000000005', 3)

END