using GuildCars.Data.Factory;
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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new HomeIndexViewModel();

            var specialRepo = SpecialRepositoryFactory.GetRepository();
            model.Specials = specialRepo.GetAll();

            var featuredVehicleRepo = VehicleRepositoryFactory.GetRepository();
            model.FeaturedVehicles = featuredVehicleRepo.GetAllFeatured();

            model.FileNameForPicture = ImageUtilities.GetCurrentPictureForSpecial();

            return View(model);
        }

        public ActionResult Contact()
        {
            var model = new HomeContactViewModel();

            if(TempData.ContainsKey("vinMessage"))
            {
                model.Message = TempData["vinMessage"].ToString();
            }
            

            return View(model);
        }

        [HttpPost]
        public ActionResult Contact(HomeContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                var contact = new Contact();

                contact.ContactName = model.ContactName;
                contact.ContactEmail = model.ContactEmail;
                contact.ContactPhone = model.ContactPhone;
                contact.Message = model.Message;
                
                var repo = ContactRepositoryFactory.GetRepository();
                repo.CreateContact(contact);

                return RedirectToAction("Index");
            }

            model = new HomeContactViewModel();

            if (TempData.ContainsKey("vinMessage"))
            {
                model.Message = TempData["vinMessage"].ToString();
            }

            return View(model);
        }

        public ActionResult Specials()
        {
            var model = new HomeSpecialsViewModel();

            var repo = SpecialRepositoryFactory.GetRepository();
            model.Specials = repo.GetAll();

            model.FileNameForPicture = ImageUtilities.GetCurrentPictureForSpecial();
            model.FileNameForIcon = ImageUtilities.GetCurrentIconForSpecial();

            return View(model);
        }
    }
}