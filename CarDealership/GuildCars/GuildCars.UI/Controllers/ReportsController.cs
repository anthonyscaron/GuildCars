using GuildCars.Data.Factory;
using GuildCars.Data.Repository.SupportData;
using GuildCars.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class ReportsController : Controller
    {
        [Authorize(Roles = "admin")]
        public ActionResult Inventory()
        {
            var model = new ReportsInventoryViewModel();
            
            var repo = VehicleRepositoryFactory.GetRepository();
            model.NewInventory = repo.AdminGetNewInventoryReport();
            model.UsedInventory = repo.AdminGetUsedInventoryReport();

            return View(model);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Sales()
        {
            var model = new ReportsSalesViewModel();

            var saleRepo = SaleRepositoryFactory.GetRepository();
            model.SalesReportRequestItem = saleRepo.GetSalesReport();

            model.Users = new List<string>();
            foreach(var user in model.SalesReportRequestItem)
            {
                model.Users.Add(user.FirstName + " " + user.LastName);
            }

            var yearsRepo = new YearsRepositorySupport();
            model.Years = yearsRepo.GetAllSales();

            return View(model);
        }
    }
}