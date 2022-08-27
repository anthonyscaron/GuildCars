USE GuildCars
GO

/* BodyStyleGetAll */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'BodyStyleGetAll')
	DROP PROCEDURE BodyStyleGetAll
GO

CREATE PROCEDURE BodyStyleGetAll AS
BEGIN
	SELECT *
	FROM BodyStyle
END
GO

/* ColorExGetAll */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ColorExGetAll')
	DROP PROCEDURE ColorExGetAll
GO

CREATE PROCEDURE ColorExGetAll AS
BEGIN
	SELECT *
	FROM ColorEx
END
GO

/* ColorIntGetAll */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ColorIntGetAll')
	DROP PROCEDURE ColorIntGetAll
GO

CREATE PROCEDURE ColorIntGetAll AS
BEGIN
	SELECT *
	FROM ColorInt
END
GO

/* ContactGetAll */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ContactGetAll')
	DROP PROCEDURE ContactGetAll
GO

CREATE PROCEDURE ContactGetAll AS
BEGIN
	SELECT *
	FROM Contact
END
GO


/* MakeGetAll */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'MakeGetAll')
	DROP PROCEDURE MakeGetAll
GO

CREATE PROCEDURE MakeGetAll AS
BEGIN
	SELECT *
	FROM Make
END
GO


/* ModelGetAll */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ModelGetAll')
	DROP PROCEDURE ModelGetAll
GO

CREATE PROCEDURE ModelGetAll AS
BEGIN
	SELECT *
	FROM Model
END
GO


/* PurchaseTypeGetAll */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'PurchaseTypeGetAll')
	DROP PROCEDURE PurchaseTypeGetAll
GO

CREATE PROCEDURE PurchaseTypeGetAll AS
BEGIN
	SELECT *
	FROM PurchaseType
END
GO


/* SaleGetAll */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SaleGetAll')
	DROP PROCEDURE SaleGetAll
GO

CREATE PROCEDURE SaleGetAll AS
BEGIN
	SELECT *
	FROM Sale
END
GO


/* SpecialGetAll */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SpecialGetAll')
	DROP PROCEDURE SpecialGetAll
GO

CREATE PROCEDURE SpecialGetAll AS
BEGIN
	SELECT *
	FROM Special
END
GO


/* StateGetAll */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'StateGetAll')
	DROP PROCEDURE StateGetAll
GO

CREATE PROCEDURE StateGetAll AS
BEGIN
	SELECT *
	FROM [State]
END
GO


/* TransGetAll */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'TransGetAll')
	DROP PROCEDURE TransGetAll
GO

CREATE PROCEDURE TransGetAll AS
BEGIN
	SELECT *
	FROM Trans
END
GO


/* TypeGetAll */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'TypeGetAll')
	DROP PROCEDURE TypeGetAll
GO

CREATE PROCEDURE TypeGetAll AS
BEGIN
	SELECT *
	FROM [Type]
END
GO


/* VehicleGetAll */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleGetAll')
	DROP PROCEDURE VehicleGetAll
GO

CREATE PROCEDURE VehicleGetAll AS
BEGIN
	SELECT *
	FROM Vehicle
END
GO

/* CreateContact */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CreateContact')
	DROP PROCEDURE CreateContact
GO

CREATE PROCEDURE CreateContact (
	@ContactId int output,
	@ContactName nvarchar(50),
	@ContactEmail nvarchar(50),
	@ContactPhone nvarchar(10),
	@Message nvarchar(200)
) AS
BEGIN
	INSERT INTO Contact (ContactName, ContactEmail, ContactPhone, [Message])
	VALUES (@ContactName, @ContactEmail, @ContactPhone, @Message)

	SET @ContactId = SCOPE_IDENTITY();
END
GO

/* CreateMake */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CreateMake')
	DROP PROCEDURE CreateMake
GO

CREATE PROCEDURE CreateMake (
	@MakeId int output,
	@MakeName nvarchar(10),
	@DateAdded datetime2,
	@AddedByUser nvarchar(128)
) AS
BEGIN
	INSERT INTO Make (MakeName, DateAdded, AddedByUser)
	VALUES (@MakeName, @DateAdded, @AddedByUser)

	SET @MakeId = SCOPE_IDENTITY();
END
GO

/* CreateModel */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CreateModel')
	DROP PROCEDURE CreateModel
GO

CREATE PROCEDURE CreateModel (
	@ModelId int output,
	@MakeId int,
	@ModelName nvarchar(10),
	@DateAdded datetime2,
	@AddedByUser nvarchar(128)
) AS
BEGIN
	INSERT INTO Model (MakeId, ModelName, DateAdded, AddedByUser)
	VALUES (@MakeId, @ModelName, @DateAdded, @AddedByUser)

	SET @ModelId = SCOPE_IDENTITY();
END
GO

/* CreateSale */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CreateSale')
	DROP PROCEDURE CreateSale
GO

CREATE PROCEDURE CreateSale (
	@SaleId int output,
	@VehicleId int,
	@StateId int,
	@PurchaseTypeId int,
	@Username nvarchar(128),
	@SaleName nvarchar(50),
	@SaleEmail nvarchar(50),
	@SalePhone nvarchar(10),
	@Street1 nvarchar(50),
	@Street2 nvarchar(50),
	@City nvarchar(20),
	@Zipcode int,
	@PurchasePrice decimal(7,2),
	@SaleDate datetime2
) AS
BEGIN
	INSERT INTO Sale (VehicleId, StateId, PurchaseTypeId, Username, SaleName, SaleEmail, SalePhone, Street1, Street2, City, Zipcode, PurchasePrice, SaleDate)
	VALUES (@VehicleId, @StateId, @PurchaseTypeId, @Username, @SaleName, @SaleEmail, @SalePhone, @Street1, @Street2, @City, @Zipcode, @PurchasePrice, @SaleDate)

	SET @SaleId = SCOPE_IDENTITY();
END
GO

/* CreateSpecial */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CreateSpecial')
	DROP PROCEDURE CreateSpecial
GO

CREATE PROCEDURE CreateSpecial (
	@SpecialId int output,
	@SpecialTitle nvarchar(50),
	@Description nvarchar(200)
) AS
BEGIN
	INSERT INTO Special (SpecialTitle, [Description])
	VALUES (@SpecialTitle, @Description)

	SET @SpecialId = SCOPE_IDENTITY();
END
GO

/* CreateUser */


/* CreateVehicle */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CreateVehicle')
	DROP PROCEDURE CreateVehicle
GO

CREATE PROCEDURE CreateVehicle (
	@VehicleId int output,
	@MakeId int,
	@ModelId int,
	@TypeId int,
	@BodyStyleId int,
	@TransId int,
	@ColorIntId int,
	@ColorExId int,
	@VIN nvarchar(17),
	@Year datetime2,
	@SalePrice decimal(7,2),
	@MSRP decimal(7,2),
	@Mileage int,
	@Description nvarchar(200),
	@Picture nvarchar(50),
	@Featured bit,
	@IsDeleted bit
) AS
BEGIN
	INSERT INTO Vehicle (MakeId, ModelId, TypeId, BodyStyleId, TransId, ColorIntId, ColorExId, VIN, [Year], SalePrice, MSRP, Mileage, [Description], Picture, Featured, IsDeleted)
	VALUES (@MakeId, @ModelId, @TypeId, @BodyStyleId, @TransId, @ColorIntId, @ColorExId, @VIN, @Year, @SalePrice, @MSRP, @Mileage, @Description, @Picture, @Featured, @IsDeleted)

	SET @VehicleId = SCOPE_IDENTITY();
END
GO

/* UpdateVehicle */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'UpdateVehicle')
	DROP PROCEDURE UpdateVehicle
GO

CREATE PROCEDURE UpdateVehicle (
	@VehicleId int,
	@MakeId int,
	@ModelId int,
	@TypeId int,
	@BodyStyleId int,
	@TransId int,
	@ColorIntId int,
	@ColorExId int,
	@VIN nvarchar(17),
	@Year datetime2,
	@SalePrice decimal(7,2),
	@MSRP decimal(7,2),
	@Mileage int,
	@Description nvarchar(200),
	@Picture nvarchar(50),
	@Featured bit,
	@IsDeleted bit
) AS
BEGIN
	UPDATE Vehicle SET
		MakeId = @MakeId,
		ModelId = @ModelId,
		TypeId = @TypeId,
		BodyStyleId = @BodyStyleId,
		TransId = @TransId,
		ColorIntId = @ColorIntId,
		ColorExId = @ColorExId,
		VIN = @VIN,
		[Year] = @Year,
		SalePrice = @SalePrice,
		MSRP = @MSRP,
		Mileage = @Mileage,
		[Description] = @Description,
		Picture = @Picture,
		Featured = @Featured,
		IsDeleted = @IsDeleted
	WHERE VehicleId = @VehicleId
END
GO

/* DeleteSpecial */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DeleteSpecial')
	DROP PROCEDURE DeleteSpecial
GO

CREATE PROCEDURE DeleteSpecial (
	@SpecialId int
) AS
BEGIN
	BEGIN TRANSACTION

	DELETE FROM Special WHERE SpecialId = @SpecialId;

	COMMIT TRANSACTION
END
GO

/* DeleteVehicle */
/* This is a soft delete instead of a hard delete.*/
/* This way the dealership can maintain information on cars that have been sold.*/
/* IsDeleted is changed to 1/true so Vehicle info remains and is linked to its sale.*/
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DeleteVehicle')
	DROP PROCEDURE DeleteVehicle
GO

CREATE PROCEDURE DeleteVehicle (
	@VehicleId int,
	@MakeId int,
	@ModelId int,
	@TypeId int,
	@BodyStyleId int,
	@TransId int,
	@ColorIntId int,
	@ColorExId int,
	@VIN nvarchar(17),
	@Year datetime2,
	@SalePrice decimal(7,2),
	@MSRP decimal(7,2),
	@Mileage int,
	@Description nvarchar(200),
	@Picture nvarchar(50),
	@Featured bit,
	@IsDeleted bit
) AS
BEGIN
	UPDATE Vehicle SET
		MakeId = @MakeId,
		ModelId = @ModelId,
		TypeId = @TypeId,
		BodyStyleId = @BodyStyleId,
		TransId = @TransId,
		ColorIntId = @ColorIntId,
		ColorExId = @ColorExId,
		VIN = @VIN,
		[Year] = @Year,
		SalePrice = @SalePrice,
		MSRP = @MSRP,
		Mileage = @Mileage,
		[Description] = @Description,
		Picture = @Picture,
		Featured = @Featured,
		IsDeleted = 1
	WHERE VehicleId = @VehicleId
END
GO

/* VehicleGetById */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleGetById')
	DROP PROCEDURE VehicleGetById
GO

CREATE PROCEDURE VehicleGetById (
	@VehicleId int
) AS
BEGIN
	SELECT *
	FROM Vehicle
	WHERE VehicleId = @VehicleId
END
GO

/* SpecialGetById */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SpecialGetById')
	DROP PROCEDURE SpecialGetById
GO

CREATE PROCEDURE SpecialGetById (
	@SpecialId int
) AS
BEGIN
	SELECT *
	FROM Special
	WHERE SpecialId = @SpecialId
END
GO

/* VehicleGetAllAvailable */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleGetAllAvailable')
	DROP PROCEDURE VehicleGetAllAvailable
GO

CREATE PROCEDURE VehicleGetAllAvailable AS
BEGIN
	SELECT TOP 20 *
	FROM Vehicle
	WHERE IsDeleted = 0
	ORDER BY MSRP DESC
END
GO

/* VehicleGetAllSold */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleGetAllSold')
	DROP PROCEDURE VehicleGetAllSold
GO

CREATE PROCEDURE VehicleGetAllSold AS
BEGIN
	SELECT *
	FROM Vehicle
	WHERE IsDeleted = 1
END
GO

/* VehicleGetAllFeatured */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleGetAllFeatured')
	DROP PROCEDURE VehicleGetAllFeatured
GO

CREATE PROCEDURE VehicleGetAllFeatured AS
BEGIN
	SELECT VehicleId, Picture, [Year], MakeName, ModelName, MSRP
	FROM Vehicle v
		INNER JOIN Make ma ON ma.MakeId = v.MakeId
		INNER JOIN Model mo ON mo.ModelId = v.ModelId
	WHERE IsDeleted = 0 AND Featured = 1
	ORDER BY MSRP DESC
END
GO

/* VehicleGetAllNew */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleGetAllNew')
	DROP PROCEDURE VehicleGetAllNew
GO

CREATE PROCEDURE VehicleGetAllNew AS
BEGIN
	SELECT TOP 20 VehicleId, [Year], MakeName, ModelName, Picture, BodyStyleName, ColorIntName, 
		SalePrice, TransName, Mileage, MSRP, ColorExName, VIN, [Description], IsDeleted
	FROM Vehicle V
		INNER JOIN Make ma ON ma.MakeId = v.MakeId
		INNER JOIN Model mo ON mo.ModelId = v.ModelId
		INNER JOIN BodyStyle b ON b.BodyStyleId = v.BodyStyleId
		INNER JOIN ColorInt ci ON ci.ColorIntId = v.ColorIntId
		INNER JOIN Trans t ON t.TransId = v.TransId
		INNER JOIN ColorEx ce ON ce.ColorExId = v.ColorExId
	WHERE IsDeleted = 0 AND V.TypeId = 1
	ORDER BY MSRP DESC
END
GO

/* VehicleGetAllUsed */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleGetAllUsed')
	DROP PROCEDURE VehicleGetAllUsed
GO

CREATE PROCEDURE VehicleGetAllUsed AS
BEGIN
	SELECT TOP 20 VehicleId, [Year], MakeName, ModelName, Picture, BodyStyleName, ColorIntName, 
		SalePrice, TransName, Mileage, MSRP, ColorExName, VIN, [Description], IsDeleted
	FROM Vehicle V
		INNER JOIN Make ma ON ma.MakeId = v.MakeId
		INNER JOIN Model mo ON mo.ModelId = v.ModelId
		INNER JOIN BodyStyle b ON b.BodyStyleId = v.BodyStyleId
		INNER JOIN ColorInt ci ON ci.ColorIntId = v.ColorIntId
		INNER JOIN Trans t ON t.TransId = v.TransId
		INNER JOIN ColorEx ce ON ce.ColorExId = v.ColorExId
	WHERE IsDeleted = 0 AND V.TypeId = 2
	ORDER BY MSRP DESC
END
GO

/* SearchVehicleById */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SearchVehicleById')
	DROP PROCEDURE SearchVehicleById
GO

CREATE PROCEDURE SearchVehicleById (
	@VehicleId int
) AS
BEGIN
	SELECT VehicleId, [Year], MakeName, ModelName, Picture, BodyStyleName, ColorIntName, 
		SalePrice, TransName, Mileage, MSRP, ColorExName, VIN, [Description], IsDeleted
	FROM Vehicle V
		INNER JOIN Make ma ON ma.MakeId = v.MakeId
		INNER JOIN Model mo ON mo.ModelId = v.ModelId
		INNER JOIN BodyStyle b ON b.BodyStyleId = v.BodyStyleId
		INNER JOIN ColorInt ci ON ci.ColorIntId = v.ColorIntId
		INNER JOIN Trans t ON t.TransId = v.TransId
		INNER JOIN ColorEx ce ON ce.ColorExId = v.ColorExId
	WHERE VehicleId = @VehicleId
END
GO

/* VehicleGetAllToSell */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleGetAllToSell')
	DROP PROCEDURE VehicleGetAllToSell
GO

CREATE PROCEDURE VehicleGetAllToSell AS
BEGIN
	SELECT VehicleId, [Year], MakeName, ModelName, Picture, BodyStyleName, ColorIntName, 
		SalePrice, TransName, Mileage, MSRP, ColorExName, VIN, [Description], IsDeleted
	FROM Vehicle V
		INNER JOIN Make ma ON ma.MakeId = v.MakeId
		INNER JOIN Model mo ON mo.ModelId = v.ModelId
		INNER JOIN BodyStyle b ON b.BodyStyleId = v.BodyStyleId
		INNER JOIN ColorInt ci ON ci.ColorIntId = v.ColorIntId
		INNER JOIN Trans t ON t.TransId = v.TransId
		INNER JOIN ColorEx ce ON ce.ColorExId = v.ColorExId
	WHERE IsDeleted = 0
	ORDER BY MSRP DESC
END
GO

/* UsersGetAll */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'UsersGetAll')
	DROP PROCEDURE UsersGetAll
GO

CREATE PROCEDURE UsersGetAll AS
BEGIN
	SELECT u.Id, LastName, FirstName, Email, PasswordHash, r.[Name]
	FROM AspNetUsers u
		INNER JOIN AspNetUserRoles ur ON ur.UserId = u.Id
		INNER JOIN AspNetRoles r ON r.Id = ur.RoleId
	ORDER BY LastName, FirstName ASC
END
GO

/* UsersGetById */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'UsersGetById')
	DROP PROCEDURE UsersGetById
GO

CREATE PROCEDURE UsersGetById (
	@UserId nvarchar(128)
) AS
BEGIN
	SELECT u.Id, LastName, FirstName, Email, PasswordHash, r.[Name]
	FROM AspNetUsers u
		INNER JOIN AspNetUserRoles ur ON ur.UserId = u.Id
		INNER JOIN AspNetRoles r ON r.Id = ur.RoleId
	WHERE u.Id = @UserId
END
GO

/* ModelGetByMakeName */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ModelGetByMakeName')
	DROP PROCEDURE ModelGetByMakeName
GO

CREATE PROCEDURE ModelGetByMakeName (
	@MakeName nvarchar(10)
) AS
BEGIN
	SELECT ModelId, mo.MakeId, ModelName, mo.DateAdded, mo.AddedByUser
	FROM Model mo
		INNER JOIN Make ma ON ma.MakeId = mo.MakeId
	WHERE ma.MakeName = @MakeName
	ORDER BY mo.ModelId ASC
END
GO

/* AdminGetAddEditVehicleViewModelById */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'AdminGetAddEditVehicleViewModelById')
	DROP PROCEDURE AdminGetAddEditVehicleViewModelById
GO

CREATE PROCEDURE AdminGetAddEditVehicleViewModelById (
	@VehicleId int
) AS
BEGIN
	SELECT VehicleId, [Year], MakeName, ModelName, Picture, BodyStyleName, ColorIntName, TypeName,
		SalePrice, TransName, Mileage, MSRP, ColorExName, VIN, [Description], Featured, IsDeleted
	FROM Vehicle V
		INNER JOIN Make ma ON ma.MakeId = v.MakeId
		INNER JOIN Model mo ON mo.ModelId = v.ModelId
		INNER JOIN BodyStyle b ON b.BodyStyleId = v.BodyStyleId
		INNER JOIN ColorInt ci ON ci.ColorIntId = v.ColorIntId
		INNER JOIN Trans t ON t.TransId = v.TransId
		INNER JOIN ColorEx ce ON ce.ColorExId = v.ColorExId
		INNER JOIN [Type] ty ON ty.TypeId = v.TypeId
	WHERE VehicleId = @VehicleId
END
GO

/* AdminGetAllAddEditVehicleViewModels*/
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'AdminGetAllAddEditVehicleViewModels')
	DROP PROCEDURE AdminGetAllAddEditVehicleViewModels
GO

CREATE PROCEDURE AdminGetAllAddEditVehicleViewModels AS
BEGIN
	SELECT VehicleId, [Year], MakeName, ModelName, Picture, BodyStyleName, ColorIntName, TypeName,
		SalePrice, TransName, Mileage, MSRP, ColorExName, VIN, [Description], Featured, IsDeleted
	FROM Vehicle V
		INNER JOIN Make ma ON ma.MakeId = v.MakeId
		INNER JOIN Model mo ON mo.ModelId = v.ModelId
		INNER JOIN BodyStyle b ON b.BodyStyleId = v.BodyStyleId
		INNER JOIN ColorInt ci ON ci.ColorIntId = v.ColorIntId
		INNER JOIN Trans t ON t.TransId = v.TransId
		INNER JOIN ColorEx ce ON ce.ColorExId = v.ColorExId
		INNER JOIN [Type] ty ON ty.TypeId = v.TypeId
	WHERE IsDeleted = 0
	ORDER BY MSRP DESC
END
GO

/* AdminGetNewInventoryReport*/
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'AdminGetNewInventoryReport')
	DROP PROCEDURE AdminGetNewInventoryReport
GO

CREATE PROCEDURE AdminGetNewInventoryReport AS
BEGIN
	SELECT DISTINCT v.[Year], ma.MakeName, mo.ModelName, COUNT(v.VehicleId) [Count], SUM(v.MSRP) [Stock Value]
	FROM Vehicle v
		INNER JOIN Make ma ON ma.MakeId = v.MakeId
		INNER JOIN Model mo ON mo.ModelId = v.ModelId
	WHERE TypeId = 1 AND IsDeleted = 0
	GROUP BY v.[Year], ma.MakeName, mo.ModelName
	ORDER BY v.[Year] DESC, ma.MakeName ASC, mo.ModelName ASC
END
GO

/* AdminGetUsedInventoryReport*/
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'AdminGetUsedInventoryReport')
	DROP PROCEDURE AdminGetUsedInventoryReport
GO

CREATE PROCEDURE AdminGetUsedInventoryReport AS
BEGIN
	SELECT DISTINCT v.[Year], ma.MakeName, mo.ModelName, COUNT(v.VehicleId) [Count], SUM(v.MSRP) [Stock Value]
	FROM Vehicle v
		INNER JOIN Make ma ON ma.MakeId = v.MakeId
		INNER JOIN Model mo ON mo.ModelId = v.ModelId
	WHERE TypeId = 2 AND IsDeleted = 0
	GROUP BY v.[Year], ma.MakeName, mo.ModelName
	ORDER BY v.[Year] DESC, ma.MakeName ASC, mo.ModelName ASC
END
GO

/* AdminGetSalesReport*/
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'AdminGetSalesReport')
	DROP PROCEDURE AdminGetSalesReport
GO

CREATE PROCEDURE AdminGetSalesReport AS
BEGIN
	SELECT DISTINCT FirstName, LastName, SUM(PurchasePrice) [Total Sales], COUNT(VehicleId) [Total Vehicles]
	FROM Sale s
		INNER JOIN AspNetUsers a ON a.UserName = s.Username
	GROUP BY a.LastName, a.FirstName
	ORDER BY [Total Sales] DESC
END
GO