using GuildCars.Data.Factory;
using GuildCars.Data.Repository.SupportData;
using GuildCars.Models.Query;
using GuildCars.Models.Table;
using GuildCars.UI.Models;
using GuildCars.UI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class SalesController : Controller
    {
        [Authorize(Roles = "sales")]
        public ActionResult Index()
        {
            var model = new InventoryNewUsedViewModel();

            var vehicleRepo = VehicleRepositoryFactory.GetRepository();
            model.SearchVehicleRequestItem = vehicleRepo.GetAllToSell();

            var yearsRepo = new YearsRepositorySupport();
            model.Years = yearsRepo.GetAll();

            var pricesRepo = new PricesRepositorySupport();
            model.Prices = pricesRepo.GetAll();

            return View(model);
        }

        [Authorize(Roles = "sales")]
        public ActionResult Purchase(int id)
        {
            var model = new SalesPuchaseViewModel();

            var vehicleRepo = VehicleRepositoryFactory.GetRepository();
            model.SearchVehicleRequestItem = vehicleRepo.SearchVehicleById(id);

            model.SaleRequestItem = new SaleRequestItem();

            var stateRepo = StateRepositoryFactory.GetRepository();
            model.States = new SelectList(stateRepo.GetAll(), "StateAbbreviation", "StateAbbreviation");

            var purchaseTypeRepo = PurchaseTypeRepositoryFactory.GetRepository();
            model.PurchaseTypes = new SelectList(purchaseTypeRepo.GetAll(), "PurchaseTypeName", "PurchaseTypeName");

            var vehicles = vehicleRepo.GetAll();

            if (id > vehicles.Max(m => m.VehicleId))
            {
                return RedirectToAction("Index", "Sales");
            }

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "sales")]
        public ActionResult Purchase(SalesPuchaseViewModel model)
        {
            var id = model.SearchVehicleRequestItem.VehicleId;
            var stateRepo = StateRepositoryFactory.GetRepository();
            var purchaseTypeRepo = PurchaseTypeRepositoryFactory.GetRepository();
            var vehicleRepo = VehicleRepositoryFactory.GetRepository();

            if (ModelState.IsValid)
            {   
                var sale = new Sale();
                var state = stateRepo.GetAll().FirstOrDefault(m => m.StateAbbreviation == model.SaleRequestItem.StateAbbreviation);
                var purchaseType = purchaseTypeRepo.GetAll().FirstOrDefault(m => m.PurchaseTypeName == model.SaleRequestItem.PurchaseTypeName);
                var user = AuthorizeUtilities.GetUserId(this);

                sale.SaleName = model.SaleRequestItem.SaleName;
                sale.SaleEmail = model.SaleRequestItem.SaleEmail;
                sale.SalePhone = model.SaleRequestItem.SalePhone;
                sale.Street1 = model.SaleRequestItem.Street1;
                sale.Street2 = model.SaleRequestItem.Street2;
                sale.City = model.SaleRequestItem.City;
                sale.StateId = state.StateId;
                sale.Zipcode = model.SaleRequestItem.Zipcode;
                sale.PurchasePrice = model.SaleRequestItem.PurchasePrice;
                sale.PurchaseTypeId = purchaseType.PurchaseTypeId;
                sale.VehicleId = id;
                sale.SaleDate = DateTime.Now;
                sale.Username = user;

                var saleRepo = SaleRepositoryFactory.GetRepository();
                saleRepo.CreateSale(sale);

                var vehicle = vehicleRepo.GetVehicleById(id);
                vehicle.IsDeleted = true;
                vehicleRepo.DeleteVehicle(vehicle);

                return RedirectToAction("Index");
            }

            model = new SalesPuchaseViewModel();

            model.SearchVehicleRequestItem = vehicleRepo.SearchVehicleById(id);

            model.SaleRequestItem = new SaleRequestItem();

            model.States = new SelectList(stateRepo.GetAll(), "StateAbbreviation", "StateAbbreviation");

            model.PurchaseTypes = new SelectList(purchaseTypeRepo.GetAll(), "PurchaseTypeName", "PurchaseTypeName");

            return View(model);
        }
    }
}