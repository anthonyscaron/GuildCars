using GuildCars.Data.Factory;
using GuildCars.Data.Repository.SupportData;
using GuildCars.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace GuildCars.UI.Controllers
{
    public class InventoryController : Controller
    {
        public ActionResult New()
        {
            var model = new InventoryNewUsedViewModel();

            var vehicleRepo = VehicleRepositoryFactory.GetRepository();
            model.SearchVehicleRequestItem = vehicleRepo.GetAllNew();

            var yearsRepo = new YearsRepositorySupport();
            model.Years = yearsRepo.GetAll();

            var pricesRepo = new PricesRepositorySupport();
            model.Prices = pricesRepo.GetAll();

            return View(model);
        }

        public ActionResult Used()
        {
            var model = new InventoryNewUsedViewModel();

            var vehicleRepo = VehicleRepositoryFactory.GetRepository();
            model.SearchVehicleRequestItem = vehicleRepo.GetAllUsed();

            var yearsRepo = new YearsRepositorySupport();
            model.Years = yearsRepo.GetAll();

            var pricesRepo = new PricesRepositorySupport();
            model.Prices = pricesRepo.GetAll();

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var repo = VehicleRepositoryFactory.GetRepository();
            var model = repo.SearchVehicleById(id);

            var vehicles = repo.GetAll();

            if (id > vehicles.Max(m => m.VehicleId))
            {
                return RedirectToAction("Index", "Home");
            }

            TempData["vinMessage"] = "Hello, I am interested in VIN#: " + model.VIN + ". Please contact me.";

            return View(model);
        }
    }
}