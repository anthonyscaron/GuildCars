using GuildCars.Data.Repository.QA;
using GuildCars.Models.Query;
using GuildCars.Models.Table;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Tests.Unit
{
    [TestFixture]
    public class TestQA
    {
        [Test]
        public void aCanGetAllBodyStyles()
        {
            var repo = new BodyStyleRepositoryQA();
            var bodyStyles = repo.GetAll();

            Assert.AreEqual(4, bodyStyles.Count);
            Assert.AreEqual(4, bodyStyles[3].BodyStyleId);
            Assert.AreEqual("SUV", bodyStyles[3].BodyStyleName);
        }

        [Test]
        public void aCanGetAllColorExs()
        {
            var repo = new ColorExRepositoryQA();
            var colorExs = repo.GetAll();

            Assert.AreEqual(6, colorExs.Count);
            Assert.AreEqual(3, colorExs[2].ColorExId);
            Assert.AreEqual("Gray", colorExs[2].ColorExName);
        }

        [Test]
        public void aCanGetAllColorInts()
        {
            var repo = new ColorIntRepositoryQA();
            var colorInts = repo.GetAll();

            Assert.AreEqual(5, colorInts.Count);
            Assert.AreEqual(2, colorInts[1].ColorIntId);
            Assert.AreEqual("Gray", colorInts[1].ColorIntName);
        }

        [Test]
        public void aCanGetAllContacts()
        {
            var repo = new ContactRepositoryQA();
            var contacts = repo.GetAll();

            Assert.AreEqual(2, contacts.Count);
            Assert.AreEqual(1, contacts[0].ContactId);
            Assert.AreEqual("Joe Schmoe", contacts[0].ContactName);
            Assert.AreEqual("joeschmoe@test.com", contacts[0].ContactEmail);
            Assert.AreEqual("5551234567", contacts[0].ContactPhone);
            Assert.AreEqual("Please call me tomorrow!", contacts[0].Message);
        }

        [Test]
        public void bCanCreateContact()
        {
            var repo = new ContactRepositoryQA();
            var contact = new Contact();

            contact.ContactName = "Test Name";
            contact.ContactEmail = "testemail@test.com";
            contact.ContactPhone = "5551234567";
            contact.Message = "test";

            repo.CreateContact(contact);

            Assert.AreEqual(3, contact.ContactId);
        }

        [Test]
        public void aCanGetAllMakes()
        {
            var repo = new MakeRepositoryQA();
            var makes = repo.GetAll();
            DateTime databaseDateAdded = new DateTime(2022, 07, 20, 00, 00, 00);

            Assert.AreEqual(5, makes.Count);
            Assert.AreEqual(4, makes[3].MakeId);
            Assert.AreEqual("Subaru", makes[3].MakeName);
            Assert.AreEqual(databaseDateAdded, makes[3].DateAdded);
            Assert.AreEqual("robdenno@guildcars.com", makes[3].AddedByUser);
        }

        [Test]
        public void bCanCreateMake()
        {
            var repo = new MakeRepositoryQA();
            var make = new Make();
            var dateNow = DateTime.Now;
            var user = "robdenno@guildcars.com";

            make.MakeName = "Test Make";
            make.DateAdded = dateNow;
            make.AddedByUser = user;

            repo.CreateMake(make);

            Assert.AreEqual(6, make.MakeId);
        }

        [Test]
        public void aCanGetAllModels()
        {
            var repo = new ModelRepositoryQA();
            var models = repo.GetAll();
            DateTime databaseDateAdded = new DateTime(2022, 07, 20, 00, 00, 00);

            Assert.AreEqual(10, models.Count);
            Assert.AreEqual(7, models[6].ModelId);
            Assert.AreEqual("Ascent", models[6].ModelName);
            Assert.AreEqual(databaseDateAdded, models[6].DateAdded);
            Assert.AreEqual("robdenno@guildcars.com", models[6].AddedByUser);
        }

        [Test]
        public void bCanCreateModel()
        {
            var repo = new ModelRepositoryQA();
            var model = new Model();
            var dateNow = DateTime.Now;

            model.MakeId = 1;
            model.ModelName = "Test Model";
            model.DateAdded = dateNow;
            model.AddedByUser = "robdenno@guildcars.com";

            repo.CreateModel(model);

            Assert.AreEqual(11, model.ModelId);
        }

        [Test]
        public void aCanGetModelsByMakeName()
        {
            var repo = new ModelRepositoryQA();
            var models = repo.GetByMakeName("Honda");
            DateTime databaseDateAdded = new DateTime(2022, 07, 01, 00, 00, 00);

            Assert.AreEqual(2, models.Count);
            Assert.AreEqual(2, models[1].ModelId);
            Assert.AreEqual(1, models[1].MakeId);
            Assert.AreEqual("Accord", models[1].ModelName);
            Assert.AreEqual(databaseDateAdded, models[1].DateAdded);
            Assert.AreEqual("robdenno@guildcars.com", models[1].AddedByUser);
        }

        [Test]
        public void aCanGetAllPurchaseTypes()
        {
            var repo = new PurchaseTypeRepositoryQA();
            var purchaseTypes = repo.GetAll();

            Assert.AreEqual(3, purchaseTypes.Count);
            Assert.AreEqual(3, purchaseTypes[2].PurchaseTypeId);
            Assert.AreEqual("Cash", purchaseTypes[2].PurchaseTypeName);
        }

        [Test]
        public void aCanGetAllSales()
        {
            var repo = new SaleRepositoryQA();
            var sales = repo.GetAll();
            DateTime saleDate = new DateTime(2021, 10, 20, 00, 00, 00);

            Assert.AreEqual(10, sales.Count);
            Assert.AreEqual(1, sales[0].SaleId);
            Assert.AreEqual(1, sales[0].VehicleId);
            Assert.AreEqual(23, sales[0].StateId);
            Assert.AreEqual(1, sales[0].PurchaseTypeId);
            Assert.AreEqual("billanmcmillan@guildcars.com", sales[0].Username);
            Assert.AreEqual("Carl First", sales[0].SaleName);
            Assert.AreEqual("carl@test.com", sales[0].SaleEmail);
            Assert.AreEqual("5551112222", sales[0].SalePhone);
            Assert.AreEqual("123 Potato Street", sales[0].Street1);
            Assert.AreEqual("Apt 1", sales[0].Street2);
            Assert.AreEqual("Minneapolis", sales[0].City);
            Assert.AreEqual(55408, sales[0].Zipcode);
            Assert.AreEqual(25000.00, sales[0].PurchasePrice);
            Assert.AreEqual(saleDate, sales[0].SaleDate);
        }

        [Test]
        public void bCanCreateSale()
        {
            var repo = new SaleRepositoryQA();
            var sale = new Sale();
            var dateNow = DateTime.Now;

            sale.VehicleId = 40;
            sale.StateId = 23;
            sale.PurchaseTypeId = 2;
            sale.Username = "also test";
            sale.SaleName = "Testy McTester";
            sale.SaleEmail = "alsotest@test.com";
            sale.SalePhone = "5559876543";
            sale.Street1 = "555 Test Ave";
            sale.Street2 = "Unit 5";
            sale.City = "Saint Paul";
            sale.Zipcode = 55102;
            sale.PurchasePrice = 43000.00M;
            sale.SaleDate = dateNow;

            repo.CreateSale(sale);

            Assert.AreEqual(11, sale.SaleId);
        }

        [Test]
        public void aCanGetSalesReport()
        {
            var repo = new SaleRepositoryQA();
            var sales = repo.GetSalesReport();

            Assert.AreEqual(3, sales.Count);
            Assert.AreEqual("Devyn", sales[0].FirstName);
            Assert.AreEqual("Susquatch", sales[0].LastName);
            Assert.AreEqual(135000, sales[0].TotalSales);
            Assert.AreEqual(3, sales[0].TotalVehicles);
        }

        [Test]
        public void aCanSearchSalesReport()
        {
            var repo = new SaleRepositoryQA();
            var parameters = new SearchSalesParameters();
            var sales = repo.Search(parameters);

            Assert.AreEqual(3, sales.Count());
            Assert.AreEqual("Devyn", sales[0].FirstName);
            Assert.AreEqual("Susquatch", sales[0].LastName);
            Assert.AreEqual(135000, sales[0].TotalSales);
            Assert.AreEqual(3, sales[0].TotalVehicles);

            parameters.SearchString = "Devyn Susquatch";
            sales = repo.Search(parameters);

            Assert.AreEqual(1, sales.Count());
            Assert.AreEqual("Devyn", sales[0].FirstName);
            Assert.AreEqual("Susquatch", sales[0].LastName);
            Assert.AreEqual(135000, sales[0].TotalSales);
            Assert.AreEqual(3, sales[0].TotalVehicles);

            parameters.FromYear = "2022";
            sales = repo.Search(parameters);

            Assert.AreEqual(1, sales.Count());
            Assert.AreEqual("Devyn", sales[0].FirstName);
            Assert.AreEqual("Susquatch", sales[0].LastName);
            Assert.AreEqual(80000, sales[0].TotalSales);
            Assert.AreEqual(2, sales[0].TotalVehicles);
        }

        [Test]
        public void aCanGetAllSpecials()
        {
            var repo = new SpecialRepositoryQA();
            var specials = repo.GetAll();

            Assert.AreEqual(3, specials.Count);
            Assert.AreEqual(3, specials[2].SpecialId);
            Assert.AreEqual("Labor Day Special", specials[2].SpecialTitle);
            Assert.AreEqual("This coming Labor Day save up to $3,000.00!", specials[2].Description);
        }

        [Test]
        public void aCanGetSpecialById()
        {
            var repo = new SpecialRepositoryQA();
            var special = repo.GetSpecialById(3);

            Assert.IsNotNull(special);
            Assert.AreEqual(3, special.SpecialId);
            Assert.AreEqual("Labor Day Special", special.SpecialTitle);
            Assert.AreEqual("This coming Labor Day save up to $3,000.00!", special.Description);
        }

        [Test]
        public void bCanCreateSpecial()
        {
            var repo = new SpecialRepositoryQA();
            var special = new Special();

            special.SpecialTitle = "Random Test Giveaway!!!";
            special.Description = "Today only stop in to receive an addition $5,000 off!!!";

            repo.CreateSpecial(special);

            Assert.AreEqual(4, special.SpecialId);
        }

        [Test]
        public void cCanDeleteSpecial()
        {
            var repo = new SpecialRepositoryQA();

            var loaded = repo.GetSpecialById(4);

            Assert.IsNotNull(loaded);
            Assert.AreEqual("Random Test Giveaway!!!", loaded.SpecialTitle);
            Assert.AreEqual("Today only stop in to receive an addition $5,000 off!!!", loaded.Description);

            repo.DeleteSpecial(4);
            loaded = repo.GetSpecialById(4);

            Assert.IsNull(loaded);
        }

        [Test]
        public void aCanGetAllStates()
        {
            var repo = new StateRepositoryQA();
            var states = repo.GetAll();

            Assert.AreEqual(50, states.Count);
            Assert.AreEqual(23, states[22].StateId);
            Assert.AreEqual("MN", states[22].StateAbbreviation);
        }

        [Test]
        public void aCanGetAllTrans()
        {
            var repo = new TransRepositoryQA();
            var trans = repo.GetAll();

            Assert.AreEqual(2, trans.Count);
            Assert.AreEqual(2, trans[1].TransId);
            Assert.AreEqual("Automatic", trans[1].TransName);
        }

        [Test]
        public void aCanGetAllTypes()
        {
            var repo = new TypeRepositoryQA();
            var types = repo.GetAll();

            Assert.AreEqual(2, types.Count);
            Assert.AreEqual(2, types[1].TypeId);
            Assert.AreEqual("Used", types[1].TypeName);
        }

        [Test]
        public void aCanGetAllVehicles()
        {
            var repo = new VehicleRepositoryQA();
            var vehicles = repo.GetAll();
            DateTime year = new DateTime(2022, 01, 01, 00, 00, 00);

            Assert.AreEqual(40, vehicles.Count);
            Assert.AreEqual(1, vehicles[0].VehicleId);
            Assert.AreEqual(1, vehicles[0].MakeId);
            Assert.AreEqual(1, vehicles[0].ModelId);
            Assert.AreEqual(1, vehicles[0].TypeId);
            Assert.AreEqual(1, vehicles[0].BodyStyleId);
            Assert.AreEqual(1, vehicles[0].TransId);
            Assert.AreEqual(1, vehicles[0].ColorIntId);
            Assert.AreEqual(6, vehicles[0].ColorExId);
            Assert.AreEqual("ABCDEFGH000000001", vehicles[0].VIN);
            Assert.AreEqual(year, vehicles[0].Year);
            Assert.AreEqual(25000, vehicles[0].SalePrice);
            Assert.AreEqual(26000, vehicles[0].MSRP);
            Assert.AreEqual(0, vehicles[0].Mileage);
            Assert.AreEqual("4 Cylinder with 30 City / 37 Hwy Fuel Efficiency", vehicles[0].Description);
            Assert.AreEqual("inventory-1.jpg", vehicles[0].Picture);
            Assert.AreEqual(false, vehicles[0].Featured);
            Assert.AreEqual(true, vehicles[0].IsDeleted);
        }

        [Test]
        public void bCanCreateVehicle()
        {
            var repo = new VehicleRepositoryQA();
            var vehicle = new Vehicle();
            DateTime year = new DateTime(2022, 01, 01, 00, 00, 00);

            vehicle.MakeId = 3;
            vehicle.ModelId = 5;
            vehicle.TypeId = 1;
            vehicle.BodyStyleId = 1;
            vehicle.TransId = 1;
            vehicle.ColorIntId = 3;
            vehicle.ColorExId = 3;
            vehicle.VIN = "XTEST1TEST2TEST3X";
            vehicle.Year = year;
            vehicle.SalePrice = 90000.00M;
            vehicle.MSRP = 90000.00M;
            vehicle.Mileage = 0;
            vehicle.Description = "SPECIAL SG EDITION!!! ONE OF A KIND CAR!!!";
            vehicle.Picture = "placeholder.png";
            vehicle.Featured = true;
            vehicle.IsDeleted = false;

            repo.CreateVehicle(vehicle);

            Assert.AreEqual(41, vehicle.VehicleId);
        }

        [Test]
        public void aCanGetVehicleById()
        {
            var repo = new VehicleRepositoryQA();
            var vehicle = repo.GetVehicleById(1);
            DateTime year = new DateTime(2022, 01, 01, 00, 00, 00);

            Assert.IsNotNull(vehicle);
            Assert.AreEqual(1, vehicle.VehicleId);
            Assert.AreEqual(1, vehicle.MakeId);
            Assert.AreEqual(1, vehicle.ModelId);
            Assert.AreEqual(1, vehicle.TypeId);
            Assert.AreEqual(1, vehicle.BodyStyleId);
            Assert.AreEqual(1, vehicle.TransId);
            Assert.AreEqual(1, vehicle.ColorIntId);
            Assert.AreEqual(6, vehicle.ColorExId);
            Assert.AreEqual("ABCDEFGH000000001", vehicle.VIN);
            Assert.AreEqual(year, vehicle.Year);
            Assert.AreEqual(25000, vehicle.SalePrice);
            Assert.AreEqual(26000, vehicle.MSRP);
            Assert.AreEqual(0, vehicle.Mileage);
            Assert.AreEqual("4 Cylinder with 30 City / 37 Hwy Fuel Efficiency", vehicle.Description);
            Assert.AreEqual("inventory-1.jpg", vehicle.Picture);
            Assert.AreEqual(false, vehicle.Featured);
            Assert.AreEqual(true, vehicle.IsDeleted);
        }

        [Test]
        public void bCanUpdateVehicle()
        {
            var repo = new VehicleRepositoryQA();
            var vehicle = new Vehicle();
            DateTime year = new DateTime(2022, 01, 01, 00, 00, 00);
            DateTime yearUpdated = new DateTime(2021, 01, 01, 00, 00, 00);

            vehicle.MakeId = 3;
            vehicle.ModelId = 5;
            vehicle.TypeId = 1;
            vehicle.BodyStyleId = 1;
            vehicle.TransId = 1;
            vehicle.ColorIntId = 3;
            vehicle.ColorExId = 3;
            vehicle.VIN = "XTEST1TEST2TEST3X";
            vehicle.Year = year;
            vehicle.SalePrice = 90000.00M;
            vehicle.MSRP = 90000.00M;
            vehicle.Mileage = 0;
            vehicle.Description = "SPECIAL SG EDITION!!! ONE OF A KIND CAR!!!";
            vehicle.Picture = "placeholder.png";
            vehicle.Featured = true;
            vehicle.IsDeleted = false;

            repo.CreateVehicle(vehicle);

            vehicle = repo.GetVehicleById(41);

            vehicle.MakeId = 1;
            vehicle.ModelId = 1;
            vehicle.TypeId = 2;
            vehicle.BodyStyleId = 2;
            vehicle.TransId = 2;
            vehicle.ColorIntId = 1;
            vehicle.ColorExId = 1;
            vehicle.VIN = "UPDATE1ANDUPDATE2";
            vehicle.Year = yearUpdated;
            vehicle.SalePrice = 80000.00M;
            vehicle.MSRP = 80000.00M;
            vehicle.Mileage = 10000;
            vehicle.Description = "SPECIAL SG EDITION!!! ONE OF A KIND CAR... but now it's used";
            vehicle.Picture = "placeholder.png";
            vehicle.Featured = false;
            vehicle.IsDeleted = true;

            repo.UpdateVehicle(vehicle);

            var updatedVehicle = repo.GetVehicleById(41);

            Assert.AreEqual(1, updatedVehicle.MakeId);
            Assert.AreEqual(1, updatedVehicle.ModelId);
            Assert.AreEqual(2, updatedVehicle.TypeId);
            Assert.AreEqual(2, updatedVehicle.BodyStyleId);
            Assert.AreEqual(2, updatedVehicle.TransId);
            Assert.AreEqual(1, updatedVehicle.ColorIntId);
            Assert.AreEqual(1, updatedVehicle.ColorExId);
            Assert.AreEqual("UPDATE1ANDUPDATE2", updatedVehicle.VIN);
            Assert.AreEqual(yearUpdated, updatedVehicle.Year);
            Assert.AreEqual(80000.00M, updatedVehicle.SalePrice);
            Assert.AreEqual(80000.00M, updatedVehicle.MSRP);
            Assert.AreEqual(10000, updatedVehicle.Mileage);
            Assert.AreEqual("SPECIAL SG EDITION!!! ONE OF A KIND CAR... but now it's used", updatedVehicle.Description);
            Assert.AreEqual("placeholder.png", updatedVehicle.Picture);
            Assert.AreEqual(false, updatedVehicle.Featured);
            Assert.AreEqual(true, updatedVehicle.IsDeleted);
        }

        [Test]
        public void aCanGetAllSoldVehicles()
        {
            var repo = new VehicleRepositoryQA();
            var vehicles = repo.GetAllSold();
            DateTime year = new DateTime(2022, 01, 01, 00, 00, 00);

            Assert.AreEqual(10, vehicles.Count);
            Assert.AreEqual(1, vehicles[0].VehicleId);
            Assert.AreEqual(1, vehicles[0].MakeId);
            Assert.AreEqual(1, vehicles[0].ModelId);
            Assert.AreEqual(1, vehicles[0].TypeId);
            Assert.AreEqual(1, vehicles[0].BodyStyleId);
            Assert.AreEqual(1, vehicles[0].TransId);
            Assert.AreEqual(1, vehicles[0].ColorIntId);
            Assert.AreEqual(6, vehicles[0].ColorExId);
            Assert.AreEqual("ABCDEFGH000000001", vehicles[0].VIN);
            Assert.AreEqual(year, vehicles[0].Year);
            Assert.AreEqual(25000, vehicles[0].SalePrice);
            Assert.AreEqual(26000, vehicles[0].MSRP);
            Assert.AreEqual(0, vehicles[0].Mileage);
            Assert.AreEqual("4 Cylinder with 30 City / 37 Hwy Fuel Efficiency", vehicles[0].Description);
            Assert.AreEqual("inventory-1.jpg", vehicles[0].Picture);
            Assert.AreEqual(false, vehicles[0].Featured);
            Assert.AreEqual(true, vehicles[0].IsDeleted);
        }

        [Test]
        public void aCanGetAllAvailableVehicles()
        {
            var repo = new VehicleRepositoryQA();
            var vehicles = repo.GetAllAvailable();
            DateTime year = new DateTime(2022, 01, 01, 00, 00, 00);

            Assert.AreEqual(20, vehicles.Count);
            Assert.AreEqual(8, vehicles[0].VehicleId);
            Assert.AreEqual(2, vehicles[0].MakeId);
            Assert.AreEqual(3, vehicles[0].ModelId);
            Assert.AreEqual(1, vehicles[0].TypeId);
            Assert.AreEqual(4, vehicles[0].BodyStyleId);
            Assert.AreEqual(1, vehicles[0].TransId);
            Assert.AreEqual(3, vehicles[0].ColorIntId);
            Assert.AreEqual(2, vehicles[0].ColorExId);
            Assert.AreEqual("ABCDEFGH000000008", vehicles[0].VIN);
            Assert.AreEqual(year, vehicles[0].Year);
            Assert.AreEqual(58000.00m, vehicles[0].SalePrice);
            Assert.AreEqual(60000.00, vehicles[0].MSRP);
            Assert.AreEqual(0, vehicles[0].Mileage);
            Assert.AreEqual("6 Cylinder with 19 City / 26 Hwy Fuel Efficiency", vehicles[0].Description);
            Assert.AreEqual("inventory-8.jpg", vehicles[0].Picture);
            Assert.AreEqual(false, vehicles[0].Featured);
            Assert.AreEqual(false, vehicles[0].IsDeleted);
        }

        [Test]
        public void cCanDeleteVehicle()
        {
            var repo = new VehicleRepositoryQA();

            var loaded = repo.GetVehicleById(40);
            Assert.IsNotNull(loaded);

            repo.DeleteVehicle(loaded);
            loaded = repo.GetVehicleById(40);

            Assert.AreEqual(true, loaded.IsDeleted);
        }

        [Test]
        public void aCanGetAllFeaturedVehicles()
        {
            var repo = new VehicleRepositoryQA();
            var vehicles = repo.GetAllFeatured();
            DateTime year = new DateTime(2022, 01, 01, 00, 00, 00);

            Assert.AreEqual(8, vehicles.Count);
            Assert.AreEqual(9, vehicles[0].VehicleId);
            Assert.AreEqual("Lexus", vehicles[0].MakeName);
            Assert.AreEqual("RX", vehicles[0].ModelName);
            Assert.AreEqual(year, vehicles[0].Year);
            Assert.AreEqual(58000, vehicles[0].MSRP);
            Assert.AreEqual("inventory-9.jpg", vehicles[0].Picture);
        }

        [Test]
        public void NotFoundVehicleReturnsNull()
        {
            var repo = new VehicleRepositoryQA();
            var vehicle = repo.GetVehicleById(100000);

            Assert.IsNull(vehicle);
        }

        [Test]
        public void aCanGetAllUsedVehicles()
        {
            var repo = new VehicleRepositoryQA();
            var vehicles = repo.GetAllUsed();
            DateTime year = new DateTime(2021, 01, 01, 00, 00, 00);

            Assert.AreEqual(8, vehicles.Count);
            Assert.AreEqual(40, vehicles[0].VehicleId);
            Assert.AreEqual(year, vehicles[0].Year);
            Assert.AreEqual("Subaru", vehicles[0].MakeName);
            Assert.AreEqual("Ascent", vehicles[0].ModelName);
            Assert.AreEqual("inventory-40.jpg", vehicles[0].Picture);
            Assert.AreEqual("SUV", vehicles[0].BodyStyleName);
            Assert.AreEqual("Black", vehicles[0].ColorIntName);
            Assert.AreEqual(43000.00M, vehicles[0].SalePrice);
            Assert.AreEqual("Automatic", vehicles[0].TransName);
            Assert.AreEqual(7701, vehicles[0].Mileage);
            Assert.AreEqual(45000.00M, vehicles[0].MSRP);
            Assert.AreEqual("Black", vehicles[0].ColorExName);
            Assert.AreEqual("ABCDEFGH000000040", vehicles[0].VIN);
            Assert.AreEqual("4 Cylinder with 20 City / 26 Hwy Fuel Efficiency", vehicles[0].Description);
        }

        [Test]
        public void aCanGetAllNewVehicles()
        {
            var repo = new VehicleRepositoryQA();
            var vehicles = repo.GetAllNew();
            DateTime year = new DateTime(2022, 01, 01, 00, 00, 00);

            Assert.AreEqual(20, vehicles.Count);
            Assert.AreEqual(8, vehicles[0].VehicleId);
            Assert.AreEqual(year, vehicles[0].Year);
            Assert.AreEqual("Lexus", vehicles[0].MakeName);
            Assert.AreEqual("RX", vehicles[0].ModelName);
            Assert.AreEqual("inventory-8.jpg", vehicles[0].Picture);
            Assert.AreEqual("SUV", vehicles[0].BodyStyleName);
            Assert.AreEqual("Tan", vehicles[0].ColorIntName);
            Assert.AreEqual(58000.00M, vehicles[0].SalePrice);
            Assert.AreEqual("Manual", vehicles[0].TransName);
            Assert.AreEqual(0, vehicles[0].Mileage);
            Assert.AreEqual(60000.00M, vehicles[0].MSRP);
            Assert.AreEqual("Blue", vehicles[0].ColorExName);
            Assert.AreEqual("ABCDEFGH000000008", vehicles[0].VIN);
            Assert.AreEqual("6 Cylinder with 19 City / 26 Hwy Fuel Efficiency", vehicles[0].Description);
            Assert.AreEqual(false, vehicles[0].IsDeleted);
        }

        [Test]
        public void aCanSearchAllAvailableToSell()
        {
            var repo = new VehicleRepositoryQA();
            var parameters = new SearchVehicleParameters();
            var vehicles = repo.SearchAllAvailableToSell(parameters);
            DateTime year = new DateTime(2022, 01, 01, 00, 00, 00);

            Assert.AreEqual(30, vehicles.Count());
            Assert.AreEqual(8, vehicles[0].VehicleId);
            Assert.AreEqual(year, vehicles[0].Year);
            Assert.AreEqual("Lexus", vehicles[0].MakeName);
            Assert.AreEqual("RX", vehicles[0].ModelName);
            Assert.AreEqual("inventory-8.jpg", vehicles[0].Picture);
            Assert.AreEqual("SUV", vehicles[0].BodyStyleName);
            Assert.AreEqual("Tan", vehicles[0].ColorIntName);
            Assert.AreEqual(58000.00M, vehicles[0].SalePrice);
            Assert.AreEqual("Manual", vehicles[0].TransName);
            Assert.AreEqual(0, vehicles[0].Mileage);
            Assert.AreEqual(60000.00M, vehicles[0].MSRP);
            Assert.AreEqual("Blue", vehicles[0].ColorExName);
            Assert.AreEqual("ABCDEFGH000000008", vehicles[0].VIN);
            Assert.AreEqual("6 Cylinder with 19 City / 26 Hwy Fuel Efficiency", vehicles[0].Description);
            Assert.AreEqual(false, vehicles[0].IsDeleted);

            parameters.SearchString = "h";
            vehicles = repo.SearchAllAvailableToSell(parameters);

            Assert.AreEqual(10, vehicles.Count());
            Assert.AreEqual(30, vehicles[0].VehicleId);
            Assert.AreEqual(year, vehicles[0].Year);
            Assert.AreEqual("Toyota", vehicles[0].MakeName);
            Assert.AreEqual("Highlander", vehicles[0].ModelName);
            Assert.AreEqual("inventory-30.jpg", vehicles[0].Picture);
            Assert.AreEqual("SUV", vehicles[0].BodyStyleName);
            Assert.AreEqual("Gray", vehicles[0].ColorIntName);
            Assert.AreEqual(44000.00M, vehicles[0].SalePrice);
            Assert.AreEqual("Manual", vehicles[0].TransName);
            Assert.AreEqual(0, vehicles[0].Mileage);
            Assert.AreEqual(46000.00M, vehicles[0].MSRP);
            Assert.AreEqual("Gray", vehicles[0].ColorExName);
            Assert.AreEqual("ABCDEFGH000000030", vehicles[0].VIN);
            Assert.AreEqual("4 Cylinder with 20 City / 27 Hwy Fuel Efficiency", vehicles[0].Description);
            Assert.AreEqual(false, vehicles[0].IsDeleted);

            parameters.MinPrice = 27000.00M;
            parameters.MaxPrice = 45000.00M;
            vehicles = repo.SearchAllAvailableToSell(parameters);

            Assert.AreEqual(8, vehicles.Count());
            Assert.AreEqual(28, vehicles[0].VehicleId);
            Assert.AreEqual(year, vehicles[0].Year);
            Assert.AreEqual("Toyota", vehicles[0].MakeName);
            Assert.AreEqual("Highlander", vehicles[0].ModelName);
            Assert.AreEqual("inventory-28.jpg", vehicles[0].Picture);
            Assert.AreEqual("SUV", vehicles[0].BodyStyleName);
            Assert.AreEqual("Black", vehicles[0].ColorIntName);
            Assert.AreEqual(43000.00M, vehicles[0].SalePrice);
            Assert.AreEqual("Automatic", vehicles[0].TransName);
            Assert.AreEqual(0, vehicles[0].Mileage);
            Assert.AreEqual(45000.00M, vehicles[0].MSRP);
            Assert.AreEqual("Black", vehicles[0].ColorExName);
            Assert.AreEqual("ABCDEFGH000000028", vehicles[0].VIN);
            Assert.AreEqual("4 Cylinder with 20 City / 27 Hwy Fuel Efficiency", vehicles[0].Description);
            Assert.AreEqual(false, vehicles[0].IsDeleted);

            parameters.MinYear = "2020";
            parameters.MaxYear = "2020";
            year = new DateTime(2020, 01, 01, 00, 00, 00);
            vehicles = repo.SearchAllAvailableToSell(parameters);

            Assert.AreEqual(1, vehicles.Count());
            Assert.AreEqual(37, vehicles[0].VehicleId);
            Assert.AreEqual(year, vehicles[0].Year);
            Assert.AreEqual("Toyota", vehicles[0].MakeName);
            Assert.AreEqual("Highlander", vehicles[0].ModelName);
            Assert.AreEqual("inventory-37.jpg", vehicles[0].Picture);
            Assert.AreEqual("SUV", vehicles[0].BodyStyleName);
            Assert.AreEqual("Black", vehicles[0].ColorIntName);
            Assert.AreEqual(40000.00M, vehicles[0].SalePrice);
            Assert.AreEqual("Automatic", vehicles[0].TransName);
            Assert.AreEqual(10280, vehicles[0].Mileage);
            Assert.AreEqual(42000.00M, vehicles[0].MSRP);
            Assert.AreEqual("Gray", vehicles[0].ColorExName);
            Assert.AreEqual("ABCDEFGH000000037", vehicles[0].VIN);
            Assert.AreEqual("4 Cylinder with 20 City / 27 Hwy Fuel Efficiency", vehicles[0].Description);
            Assert.AreEqual(false, vehicles[0].IsDeleted);
        }

        [Test]
        public void aCanGetAllNewInventory()
        {
            var repo = new VehicleRepositoryQA();
            var inventory = repo.AdminGetNewInventoryReport();
            DateTime date = new DateTime(2022, 01, 01, 00, 00, 00);

            Assert.AreEqual(10, inventory.Count);
            Assert.AreEqual(date, inventory[0].Year);
            Assert.AreEqual("Honda", inventory[0].MakeName);
            Assert.AreEqual("Accord", inventory[0].ModelName);
            Assert.AreEqual(3, inventory[0].Count);
            Assert.AreEqual(94000.00M, inventory[0].StockValue);
        }

        [Test]
        public void aCanGetAllUsedInventory()
        {
            var repo = new VehicleRepositoryQA();
            var inventory = repo.AdminGetUsedInventoryReport();
            DateTime date = new DateTime(2021, 01, 01, 00, 00, 00);

            Assert.AreEqual(8, inventory.Count);
            Assert.AreEqual(date, inventory[0].Year);
            Assert.AreEqual("Subaru", inventory[0].MakeName);
            Assert.AreEqual("Ascent", inventory[0].ModelName);
            Assert.AreEqual(1, inventory[0].Count);
            Assert.AreEqual(45000.00M, inventory[0].StockValue);
        }

        [Test]
        public void aCanGetAllVehiclesToSell()
        {
            var repo = new VehicleRepositoryQA();
            var vehicles = repo.GetAllToSell();
            DateTime year = new DateTime(2022, 01, 01, 00, 00, 00);

            Assert.AreEqual(30, vehicles.Count());
            Assert.AreEqual(8, vehicles[0].VehicleId);
            Assert.AreEqual(year, vehicles[0].Year);
            Assert.AreEqual("Lexus", vehicles[0].MakeName);
            Assert.AreEqual("RX", vehicles[0].ModelName);
            Assert.AreEqual("inventory-8.jpg", vehicles[0].Picture);
            Assert.AreEqual("SUV", vehicles[0].BodyStyleName);
            Assert.AreEqual("Tan", vehicles[0].ColorIntName);
            Assert.AreEqual(58000.00M, vehicles[0].SalePrice);
            Assert.AreEqual("Manual", vehicles[0].TransName);
            Assert.AreEqual(0, vehicles[0].Mileage);
            Assert.AreEqual(60000.00M, vehicles[0].MSRP);
            Assert.AreEqual("Blue", vehicles[0].ColorExName);
            Assert.AreEqual("ABCDEFGH000000008", vehicles[0].VIN);
            Assert.AreEqual("6 Cylinder with 19 City / 26 Hwy Fuel Efficiency", vehicles[0].Description);
            Assert.AreEqual(false, vehicles[0].IsDeleted);
        }

        [Test]
        public void aCanSearchUsedVehicles()
        {
            var repo = new VehicleRepositoryQA();
            var parameters = new SearchVehicleParameters();
            var vehicles = repo.SearchUsed(parameters);
            DateTime year = new DateTime(2021, 01, 01, 00, 00, 00);

            Assert.AreEqual(8, vehicles.Count());
            Assert.AreEqual(40, vehicles[0].VehicleId);
            Assert.AreEqual(year, vehicles[0].Year);
            Assert.AreEqual("Subaru", vehicles[0].MakeName);
            Assert.AreEqual("Ascent", vehicles[0].ModelName);
            Assert.AreEqual("inventory-40.jpg", vehicles[0].Picture);
            Assert.AreEqual("SUV", vehicles[0].BodyStyleName);
            Assert.AreEqual("Black", vehicles[0].ColorIntName);
            Assert.AreEqual(43000.00M, vehicles[0].SalePrice);
            Assert.AreEqual("Automatic", vehicles[0].TransName);
            Assert.AreEqual(7701, vehicles[0].Mileage);
            Assert.AreEqual(45000.00M, vehicles[0].MSRP);
            Assert.AreEqual("Black", vehicles[0].ColorExName);
            Assert.AreEqual("ABCDEFGH000000040", vehicles[0].VIN);
            Assert.AreEqual("4 Cylinder with 20 City / 26 Hwy Fuel Efficiency", vehicles[0].Description);
            Assert.AreEqual(false, vehicles[0].IsDeleted);

            parameters.SearchString = "h";
            year = new DateTime(2020, 01, 01, 00, 00, 00);
            vehicles = repo.SearchUsed(parameters);

            Assert.AreEqual(3, vehicles.Count());
            Assert.AreEqual(37, vehicles[0].VehicleId);
            Assert.AreEqual(year, vehicles[0].Year);
            Assert.AreEqual("Toyota", vehicles[0].MakeName);
            Assert.AreEqual("Highlander", vehicles[0].ModelName);
            Assert.AreEqual("inventory-37.jpg", vehicles[0].Picture);
            Assert.AreEqual("SUV", vehicles[0].BodyStyleName);
            Assert.AreEqual("Black", vehicles[0].ColorIntName);
            Assert.AreEqual(40000.00M, vehicles[0].SalePrice);
            Assert.AreEqual("Automatic", vehicles[0].TransName);
            Assert.AreEqual(10280, vehicles[0].Mileage);
            Assert.AreEqual(42000.00M, vehicles[0].MSRP);
            Assert.AreEqual("Gray", vehicles[0].ColorExName);
            Assert.AreEqual("ABCDEFGH000000037", vehicles[0].VIN);
            Assert.AreEqual("4 Cylinder with 20 City / 27 Hwy Fuel Efficiency", vehicles[0].Description);
            Assert.AreEqual(false, vehicles[0].IsDeleted);

            parameters.MinPrice = 15000.00M;
            parameters.MaxPrice = 40000.00M;
            year = new DateTime(2018, 01, 01, 00, 00, 00);
            vehicles = repo.SearchUsed(parameters);

            Assert.AreEqual(2, vehicles.Count());
            Assert.AreEqual(31, vehicles[0].VehicleId);
            Assert.AreEqual(year, vehicles[0].Year);
            Assert.AreEqual("Toyota", vehicles[0].MakeName);
            Assert.AreEqual("Highlander", vehicles[0].ModelName);
            Assert.AreEqual("inventory-31.jpg", vehicles[0].Picture);
            Assert.AreEqual("SUV", vehicles[0].BodyStyleName);
            Assert.AreEqual("Black", vehicles[0].ColorIntName);
            Assert.AreEqual(39000.00M, vehicles[0].SalePrice);
            Assert.AreEqual("Automatic", vehicles[0].TransName);
            Assert.AreEqual(45889, vehicles[0].Mileage);
            Assert.AreEqual(40000.00M, vehicles[0].MSRP);
            Assert.AreEqual("Blue", vehicles[0].ColorExName);
            Assert.AreEqual("ABCDEFGH000000031", vehicles[0].VIN);
            Assert.AreEqual("4 Cylinder with 20 City / 26 Hwy Fuel Efficiency", vehicles[0].Description);
            Assert.AreEqual(false, vehicles[0].IsDeleted);

            parameters.MinYear = "2016";
            parameters.MaxYear = "2017";
            year = new DateTime(2016, 01, 01, 00, 00, 00);
            vehicles = repo.SearchUsed(parameters);

            Assert.AreEqual(1, vehicles.Count());
            Assert.AreEqual(32, vehicles[0].VehicleId);
            Assert.AreEqual(year, vehicles[0].Year);
            Assert.AreEqual("Honda", vehicles[0].MakeName);
            Assert.AreEqual("Civic", vehicles[0].ModelName);
            Assert.AreEqual("inventory-32.jpg", vehicles[0].Picture);
            Assert.AreEqual("Car", vehicles[0].BodyStyleName);
            Assert.AreEqual("Black", vehicles[0].ColorIntName);
            Assert.AreEqual(17500.00M, vehicles[0].SalePrice);
            Assert.AreEqual("Automatic", vehicles[0].TransName);
            Assert.AreEqual(121151, vehicles[0].Mileage);
            Assert.AreEqual(18000.00M, vehicles[0].MSRP);
            Assert.AreEqual("Gray", vehicles[0].ColorExName);
            Assert.AreEqual("ABCDEFGH000000032", vehicles[0].VIN);
            Assert.AreEqual("4 Cylinder with 31 City / 42 Hwy Fuel Efficiency", vehicles[0].Description);
            Assert.AreEqual(false, vehicles[0].IsDeleted);
        }

        [Test]
        public void aCanSearchNewVehicles()
        {
            var repo = new VehicleRepositoryQA();
            var parameters = new SearchVehicleParameters();
            var vehicles = repo.SearchNew(parameters);
            DateTime year = new DateTime(2022, 01, 01, 00, 00, 00);

            Assert.AreEqual(22, vehicles.Count());
            Assert.AreEqual(8, vehicles[0].VehicleId);
            Assert.AreEqual(year, vehicles[0].Year);
            Assert.AreEqual("Lexus", vehicles[0].MakeName);
            Assert.AreEqual("RX", vehicles[0].ModelName);
            Assert.AreEqual("inventory-8.jpg", vehicles[0].Picture);
            Assert.AreEqual("SUV", vehicles[0].BodyStyleName);
            Assert.AreEqual("Tan", vehicles[0].ColorIntName);
            Assert.AreEqual(58000.00M, vehicles[0].SalePrice);
            Assert.AreEqual("Manual", vehicles[0].TransName);
            Assert.AreEqual(0, vehicles[0].Mileage);
            Assert.AreEqual(60000.00M, vehicles[0].MSRP);
            Assert.AreEqual("Blue", vehicles[0].ColorExName);
            Assert.AreEqual("ABCDEFGH000000008", vehicles[0].VIN);
            Assert.AreEqual("6 Cylinder with 19 City / 26 Hwy Fuel Efficiency", vehicles[0].Description);
            Assert.AreEqual(false, vehicles[0].IsDeleted);

            parameters.SearchString = "h";
            vehicles = repo.SearchNew(parameters);

            Assert.AreEqual(7, vehicles.Count());
            Assert.AreEqual(30, vehicles[0].VehicleId);
            Assert.AreEqual(year, vehicles[0].Year);
            Assert.AreEqual("Toyota", vehicles[0].MakeName);
            Assert.AreEqual("Highlander", vehicles[0].ModelName);
            Assert.AreEqual("inventory-30.jpg", vehicles[0].Picture);
            Assert.AreEqual("SUV", vehicles[0].BodyStyleName);
            Assert.AreEqual("Gray", vehicles[0].ColorIntName);
            Assert.AreEqual(44000.00M, vehicles[0].SalePrice);
            Assert.AreEqual("Manual", vehicles[0].TransName);
            Assert.AreEqual(0, vehicles[0].Mileage);
            Assert.AreEqual(46000.00M, vehicles[0].MSRP);
            Assert.AreEqual("Gray", vehicles[0].ColorExName);
            Assert.AreEqual("ABCDEFGH000000030", vehicles[0].VIN);
            Assert.AreEqual("4 Cylinder with 20 City / 27 Hwy Fuel Efficiency", vehicles[0].Description);
            Assert.AreEqual(false, vehicles[0].IsDeleted);

            parameters.MinPrice = 15000.00M;
            parameters.MaxPrice = 40000.00M;
            vehicles = repo.SearchNew(parameters);

            Assert.AreEqual(5, vehicles.Count());
            Assert.AreEqual(5, vehicles[0].VehicleId);
            Assert.AreEqual(year, vehicles[0].Year);
            Assert.AreEqual("Honda", vehicles[0].MakeName);
            Assert.AreEqual("Accord", vehicles[0].ModelName);
            Assert.AreEqual("inventory-5.jpg", vehicles[0].Picture);
            Assert.AreEqual("Car", vehicles[0].BodyStyleName);
            Assert.AreEqual("Black", vehicles[0].ColorIntName);
            Assert.AreEqual(35000.00M, vehicles[0].SalePrice);
            Assert.AreEqual("Automatic", vehicles[0].TransName);
            Assert.AreEqual(0, vehicles[0].Mileage);
            Assert.AreEqual(36000.00M, vehicles[0].MSRP);
            Assert.AreEqual("Gray", vehicles[0].ColorExName);
            Assert.AreEqual("ABCDEFGH000000005", vehicles[0].VIN);
            Assert.AreEqual("4 Cylinder with 22 City / 32 Hwy Fuel Efficiency", vehicles[0].Description);
            Assert.AreEqual(false, vehicles[0].IsDeleted);
        }

        [Test]
        public void aCanSearchVehicleById()
        {
            var repo = new VehicleRepositoryQA();
            var vehicleId = 8;
            var vehicle = repo.SearchVehicleById(vehicleId);
            DateTime year = new DateTime(2022, 01, 01, 00, 00, 00);

            Assert.AreEqual(8, vehicle.VehicleId);
            Assert.AreEqual(year, vehicle.Year);
            Assert.AreEqual("Lexus", vehicle.MakeName);
            Assert.AreEqual("RX", vehicle.ModelName);
            Assert.AreEqual("inventory-8.jpg", vehicle.Picture);
            Assert.AreEqual("SUV", vehicle.BodyStyleName);
            Assert.AreEqual("Tan", vehicle.ColorIntName);
            Assert.AreEqual(58000.00M, vehicle.SalePrice);
            Assert.AreEqual("Manual", vehicle.TransName);
            Assert.AreEqual(0, vehicle.Mileage);
            Assert.AreEqual(60000.00M, vehicle.MSRP);
            Assert.AreEqual("Blue", vehicle.ColorExName);
            Assert.AreEqual("ABCDEFGH000000008", vehicle.VIN);
            Assert.AreEqual("6 Cylinder with 19 City / 26 Hwy Fuel Efficiency", vehicle.Description);
            Assert.AreEqual(false, vehicle.IsDeleted);
        }

        [Test]
        public void aAdminCanGetAllVehicles()
        {
            var repo = new VehicleRepositoryQA();
            var vehicles = repo.AdminGetAll();
            DateTime year = new DateTime(2022, 01, 01, 00, 00, 00);

            Assert.AreEqual(30, vehicles.Count());
            Assert.AreEqual(8, vehicles[0].VehicleId);
            Assert.AreEqual(year, vehicles[0].Year);
            Assert.AreEqual("Lexus", vehicles[0].MakeName);
            Assert.AreEqual("RX", vehicles[0].ModelName);
            Assert.AreEqual("inventory-8.jpg", vehicles[0].Picture);
            Assert.AreEqual("SUV", vehicles[0].BodyStyleName);
            Assert.AreEqual("Tan", vehicles[0].ColorIntName);
            Assert.AreEqual(58000.00M, vehicles[0].SalePrice);
            Assert.AreEqual("Manual", vehicles[0].TransName);
            Assert.AreEqual(0, vehicles[0].Mileage);
            Assert.AreEqual(60000.00M, vehicles[0].MSRP);
            Assert.AreEqual("Blue", vehicles[0].ColorExName);
            Assert.AreEqual("ABCDEFGH000000008", vehicles[0].VIN);
            Assert.AreEqual("6 Cylinder with 19 City / 26 Hwy Fuel Efficiency", vehicles[0].Description);
            Assert.AreEqual("New", vehicles[0].TypeName);
            Assert.AreEqual(false, vehicles[0].IsDeleted);
        }

        [Test]
        public void aAdminCanGetVehicleById()
        {
            var repo = new VehicleRepositoryQA();
            var vehicleId = 8;
            var vehicle = repo.AdminGetVehicleById(vehicleId);
            DateTime year = new DateTime(2022, 01, 01, 00, 00, 00);

            Assert.AreEqual(8, vehicle.VehicleId);
            Assert.AreEqual(year, vehicle.Year);
            Assert.AreEqual("Lexus", vehicle.MakeName);
            Assert.AreEqual("RX", vehicle.ModelName);
            Assert.AreEqual("inventory-8.jpg", vehicle.Picture);
            Assert.AreEqual("SUV", vehicle.BodyStyleName);
            Assert.AreEqual("Tan", vehicle.ColorIntName);
            Assert.AreEqual(58000.00M, vehicle.SalePrice);
            Assert.AreEqual("Manual", vehicle.TransName);
            Assert.AreEqual(0, vehicle.Mileage);
            Assert.AreEqual(60000.00M, vehicle.MSRP);
            Assert.AreEqual("Blue", vehicle.ColorExName);
            Assert.AreEqual("ABCDEFGH000000008", vehicle.VIN);
            Assert.AreEqual("6 Cylinder with 19 City / 26 Hwy Fuel Efficiency", vehicle.Description);
            Assert.AreEqual(false, vehicle.IsDeleted);
        }
    }
}
