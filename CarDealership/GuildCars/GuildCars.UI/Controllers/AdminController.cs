using GuildCars.Data.Factory;
using GuildCars.Data.Repository.SupportData;
using GuildCars.Models.Table;
using GuildCars.UI.Models;
using GuildCars.UI.Models.Identity;
using GuildCars.UI.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        public ActionResult Vehicles()
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

        [Authorize(Roles = "admin")]
        public ActionResult Users()
        {
            var repo = UserRepositoryFactory.GetRepository();
            var model = repo.GetAll();
            
            return View(model);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Makes()
        {
            var model = new AdminMakesViewModel();

            var repo = MakeRepositoryFactory.GetRepository();
            model.Makes = repo.GetAll();

            model.MakeToCreate = new Make();

            return View(model);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Makes(AdminMakesViewModel model)
        {

            var repo = MakeRepositoryFactory.GetRepository();

            if (ModelState.IsValid)
            {
                var make = new Make();
                var user = AuthorizeUtilities.GetUserId(this);

                make.MakeName = model.MakeToCreate.MakeName;
                make.DateAdded = DateTime.Now;
                make.AddedByUser = user;

                repo.CreateMake(make);

                return RedirectToAction("Makes");
            }
            
            model = new AdminMakesViewModel();

            model.Makes = repo.GetAll();

            model.MakeToCreate = new Make();

            return View(model);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Models()
        {
            var model = new AdminModelsViewModel();

            var makeRepo = MakeRepositoryFactory.GetRepository();
            model.Makes = new SelectList(makeRepo.GetAll(), "MakeName", "MakeName");
            model.MakesToQuery = makeRepo.GetAll();

            var modelRepo = ModelRepositoryFactory.GetRepository();
            model.Models = modelRepo.GetAll();

            model.ModelToCreate = new Model();

            return View(model);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Models(AdminModelsViewModel model)
        {
            var makeRepo = MakeRepositoryFactory.GetRepository();
            var modelRepo = ModelRepositoryFactory.GetRepository();

            if (ModelState.IsValid)
            {
                var carModel = new Model();
                var user = AuthorizeUtilities.GetUserId(this);
                var make = makeRepo.GetAll().FirstOrDefault(m => m.MakeName == model.MakeName);

                carModel.ModelName = model.ModelToCreate.ModelName;
                carModel.MakeId = make.MakeId;
                carModel.DateAdded = DateTime.Now;
                carModel.AddedByUser = user;

                modelRepo.CreateModel(carModel);

                return RedirectToAction("Models");
            }

            model = new AdminModelsViewModel();
            
            model.Makes = new SelectList(makeRepo.GetAll(), "MakeName", "MakeName");
            model.MakesToQuery = makeRepo.GetAll();

            model.Models = modelRepo.GetAll();

            model.ModelToCreate = new Model();

            return View(model);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Specials()
        {
            var model = new AdminSpecialsViewModel();

            var repo = SpecialRepositoryFactory.GetRepository();
            model.Specials = repo.GetAll();

            model.FileNameForPicture = ImageUtilities.GetCurrentPictureForSpecial();
            model.FileNameForIcon = ImageUtilities.GetCurrentIconForSpecial();
            
            return View(model);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Specials(AdminSpecialsViewModel model)
        {
            var repo = SpecialRepositoryFactory.GetRepository();

            if (ModelState.IsValid)
            {
                var special = new Special();

                special.SpecialTitle = model.SpecialTitle;
                special.Description = model.SpecialDescription;

                repo.CreateSpecial(special);

                return RedirectToAction("Specials");
            }

            model = new AdminSpecialsViewModel();

            model.Specials = repo.GetAll();

            model.FileNameForPicture = ImageUtilities.GetCurrentPictureForSpecial();
            model.FileNameForIcon = ImageUtilities.GetCurrentIconForSpecial();

            return View(model);
        }

        [Authorize(Roles = "admin")]
        public ActionResult AddVehicle()
        {
            var model = new AdminAddEditVehicleViewModel();

            var makesRepo = MakeRepositoryFactory.GetRepository();
            model.Makes = new SelectList(makesRepo.GetAll(), "MakeName", "MakeName");

            var modelsRepo = ModelRepositoryFactory.GetRepository();
            model.Models = new SelectList(modelsRepo.GetAll(), "ModelName", "ModelName");

            var typesRepo = TypeRepositoryFactory.GetRepository();
            model.Types = new SelectList(typesRepo.GetAll(), "TypeName", "TypeName");

            var bodyStylesRepo = BodyStyleRepositoryFactory.GetRepository();
            model.BodyStyles = new SelectList(bodyStylesRepo.GetAll(), "BodyStyleName", "BodyStyleName");

            var transRepo = TransRepositoryFactory.GetRepository();
            model.Trans = new SelectList(transRepo.GetAll(), "TransName", "TransName");

            var colorExRepo = ColorExRepositoryFactory.GetRepository();
            model.ColorEx = new SelectList(colorExRepo.GetAll(), "ColorExName", "ColorExName");

            var colorIntRepo = ColorIntRepositoryFactory.GetRepository();
            model.ColorInt = new SelectList(colorIntRepo.GetAll(), "ColorIntName", "ColorIntName");

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult AddVehicle(AdminAddEditVehicleViewModel model)
        {
            var makesRepo = MakeRepositoryFactory.GetRepository();
            var modelsRepo = ModelRepositoryFactory.GetRepository();
            var typesRepo = TypeRepositoryFactory.GetRepository();
            var bodyStylesRepo = BodyStyleRepositoryFactory.GetRepository();
            var transRepo = TransRepositoryFactory.GetRepository();
            var colorExRepo = ColorExRepositoryFactory.GetRepository();
            var colorIntRepo = ColorIntRepositoryFactory.GetRepository();

            if (ModelState.IsValid)
            {
                var vehicle = new Vehicle();

                var make = makesRepo.GetAll().FirstOrDefault(m => m.MakeName == model.AddEditVehicleRequestItem.MakeName);
                vehicle.MakeId = make.MakeId;

                var modelToAdd = modelsRepo.GetAll().FirstOrDefault(m => m.ModelName == model.AddEditVehicleRequestItem.ModelName);
                vehicle.ModelId = modelToAdd.ModelId;

                var type = typesRepo.GetAll().FirstOrDefault(m => m.TypeName == model.AddEditVehicleRequestItem.TypeName);
                vehicle.TypeId = type.TypeId;

                var bodyStyle = bodyStylesRepo.GetAll().FirstOrDefault(m => m.BodyStyleName == model.AddEditVehicleRequestItem.BodyStyleName);
                vehicle.BodyStyleId = bodyStyle.BodyStyleId;

                var year = new DateTime(model.Year, 01, 01, 00, 00, 00);
                vehicle.Year = year;

                var trans = transRepo.GetAll().FirstOrDefault(m => m.TransName == model.AddEditVehicleRequestItem.TransName);
                vehicle.TransId = trans.TransId;

                var colorEx = colorExRepo.GetAll().FirstOrDefault(m => m.ColorExName == model.AddEditVehicleRequestItem.ColorExName);
                vehicle.ColorExId = colorEx.ColorExId;

                var colorInt = colorIntRepo.GetAll().FirstOrDefault(m => m.ColorIntName == model.AddEditVehicleRequestItem.ColorIntName);
                vehicle.ColorIntId = colorInt.ColorIntId;

                vehicle.Mileage = model.AddEditVehicleRequestItem.Mileage;
                vehicle.VIN = model.AddEditVehicleRequestItem.VIN;
                vehicle.MSRP = model.AddEditVehicleRequestItem.MSRP;
                vehicle.SalePrice = model.AddEditVehicleRequestItem.SalePrice;
                vehicle.Description = model.AddEditVehicleRequestItem.Description;

                var vehicles = VehicleRepositoryFactory.GetRepository();
                var inventoryNumber = vehicles.GetAll().Max(m=>m.VehicleId) + 1;
                var fileName = "inventory-" + inventoryNumber;

                var savePath = Server.MapPath("~/ImagesPROD");
                string extension = Path.GetExtension(model.PictureUpload.FileName);
                var filePath = Path.Combine(savePath, fileName + extension);
                model.PictureUpload.SaveAs(filePath);
                vehicle.Picture = fileName + extension;

                vehicles.CreateVehicle(vehicle);

                return RedirectToAction("EditVehicle", new { id = vehicle.VehicleId });
            }

            model = new AdminAddEditVehicleViewModel();
            model.Makes = new SelectList(makesRepo.GetAll(), "MakeName", "MakeName");
            model.Models = new SelectList(modelsRepo.GetAll(), "ModelName", "ModelName");
            model.Types = new SelectList(typesRepo.GetAll(), "TypeName", "TypeName");
            model.BodyStyles = new SelectList(bodyStylesRepo.GetAll(), "BodyStyleName", "BodyStyleName");
            model.Trans = new SelectList(transRepo.GetAll(), "TransName", "TransName");
            model.ColorEx = new SelectList(colorExRepo.GetAll(), "ColorExName", "ColorExName");
            model.ColorInt = new SelectList(colorIntRepo.GetAll(), "ColorIntName", "ColorIntName");

            return View(model);
        }

        [Authorize(Roles = "admin")]
        public ActionResult EditVehicle(int id)  
        {
            var model = new AdminAddEditVehicleViewModel();

            var vehicleRepo = VehicleRepositoryFactory.GetRepository();
            model.AddEditVehicleRequestItem = vehicleRepo.AdminGetVehicleById(id);

            var makesRepo = MakeRepositoryFactory.GetRepository();
            model.Makes = new SelectList(makesRepo.GetAll(), "MakeName", "MakeName");

            var modelsRepo = ModelRepositoryFactory.GetRepository();
            model.Models = new SelectList(modelsRepo.GetAll(), "ModelName", "ModelName");

            var typesRepo = TypeRepositoryFactory.GetRepository();
            model.Types = new SelectList(typesRepo.GetAll(), "TypeName", "TypeName");

            var bodyStylesRepo = BodyStyleRepositoryFactory.GetRepository();
            model.BodyStyles = new SelectList(bodyStylesRepo.GetAll(), "BodyStyleName", "BodyStyleName");

            var transRepo = TransRepositoryFactory.GetRepository();
            model.Trans = new SelectList(transRepo.GetAll(), "TransName", "TransName");

            var colorExRepo = ColorExRepositoryFactory.GetRepository();
            model.ColorEx = new SelectList(colorExRepo.GetAll(), "ColorExName", "ColorExName");

            var colorIntRepo = ColorIntRepositoryFactory.GetRepository();
            model.ColorInt = new SelectList(colorIntRepo.GetAll(), "ColorIntName", "ColorIntName");

            var vehicles = vehicleRepo.GetAll();

            if (id > vehicles.Max(m => m.VehicleId))
            {
                return RedirectToAction("Index", "Admin");
            }

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult EditVehicle(AdminAddEditVehicleViewModel model)
        {
            var modelId = model.AddEditVehicleRequestItem.VehicleId;

            var vehicleRepo = VehicleRepositoryFactory.GetRepository();
            var makesRepo = MakeRepositoryFactory.GetRepository();
            var modelsRepo = ModelRepositoryFactory.GetRepository();
            var typesRepo = TypeRepositoryFactory.GetRepository();
            var bodyStylesRepo = BodyStyleRepositoryFactory.GetRepository();
            var transRepo = TransRepositoryFactory.GetRepository();
            var colorExRepo = ColorExRepositoryFactory.GetRepository();
            var colorIntRepo = ColorIntRepositoryFactory.GetRepository();

            if (ModelState.IsValid)
            {
                var vehicle = new Vehicle();
                vehicle.VehicleId = modelId;

                var make = makesRepo.GetAll().FirstOrDefault(m => m.MakeName == model.AddEditVehicleRequestItem.MakeName);
                vehicle.MakeId = make.MakeId;

                var modelToAdd = modelsRepo.GetAll().FirstOrDefault(m => m.ModelName == model.AddEditVehicleRequestItem.ModelName);
                vehicle.ModelId = modelToAdd.ModelId;

                var type = typesRepo.GetAll().FirstOrDefault(m => m.TypeName == model.AddEditVehicleRequestItem.TypeName);
                vehicle.TypeId = type.TypeId;

                var bodyStyle = bodyStylesRepo.GetAll().FirstOrDefault(m => m.BodyStyleName == model.AddEditVehicleRequestItem.BodyStyleName);
                vehicle.BodyStyleId = bodyStyle.BodyStyleId;

                var year = new DateTime(model.Year, 01, 01, 00, 00, 00);
                vehicle.Year = year;

                var trans = transRepo.GetAll().FirstOrDefault(m => m.TransName == model.AddEditVehicleRequestItem.TransName);
                vehicle.TransId = trans.TransId;

                var colorEx = colorExRepo.GetAll().FirstOrDefault(m => m.ColorExName == model.AddEditVehicleRequestItem.ColorExName);
                vehicle.ColorExId = colorEx.ColorExId;

                var colorInt = colorIntRepo.GetAll().FirstOrDefault(m => m.ColorIntName == model.AddEditVehicleRequestItem.ColorIntName);
                vehicle.ColorIntId = colorInt.ColorIntId;

                vehicle.Mileage = model.AddEditVehicleRequestItem.Mileage;
                vehicle.VIN = model.AddEditVehicleRequestItem.VIN;
                vehicle.MSRP = model.AddEditVehicleRequestItem.MSRP;
                vehicle.SalePrice = model.AddEditVehicleRequestItem.SalePrice;
                vehicle.Description = model.AddEditVehicleRequestItem.Description;
                vehicle.Picture = model.AddEditVehicleRequestItem.Picture;

                var oldVehicle = vehicleRepo.GetVehicleById(modelId);

                if (model.PictureUpload != null && model.PictureUpload.ContentLength > 0)
                {
                    var inventoryNumber = model.AddEditVehicleRequestItem.VehicleId;
                    var fileName = "inventory-" + inventoryNumber;

                    var savePath = Server.MapPath("~/ImagesPROD");
                    string extension = Path.GetExtension(model.PictureUpload.FileName);
                    var filePath = Path.Combine(savePath, fileName + extension);

                    var oldPath = Path.Combine(savePath, oldVehicle.Picture);
                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                    }

                    model.PictureUpload.SaveAs(filePath);
                    vehicle.Picture = fileName + extension;
                }

                vehicle.Featured = model.AddEditVehicleRequestItem.Featured;

                vehicleRepo.UpdateVehicle(vehicle);

                return RedirectToAction("EditVehicle", vehicle.VehicleId);
            }

            model = new AdminAddEditVehicleViewModel();
            model.AddEditVehicleRequestItem = vehicleRepo.AdminGetVehicleById(modelId);
            model.Makes = new SelectList(makesRepo.GetAll(), "MakeName", "MakeName");
            model.Models = new SelectList(modelsRepo.GetAll(), "ModelName", "ModelName");
            model.Types = new SelectList(typesRepo.GetAll(), "TypeName", "TypeName");
            model.BodyStyles = new SelectList(bodyStylesRepo.GetAll(), "BodyStyleName", "BodyStyleName");
            model.Trans = new SelectList(transRepo.GetAll(), "TransName", "TransName");
            model.ColorEx = new SelectList(colorExRepo.GetAll(), "ColorExName", "ColorExName");
            model.ColorInt = new SelectList(colorIntRepo.GetAll(), "ColorIntName", "ColorIntName");

            return View(model);
        }

        [Authorize(Roles = "admin")]
        public ActionResult AddUser()
        {
            var model = new AdminAddUserViewModel();

            var repo = new RolesRepositorySupport();
            model.Roles = new SelectList(repo.GetAll());

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult AddUser(AdminAddUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var context = new GuildCarsDbContext();
                var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(context));

                var user = new AppUser();
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.UserName = model.Email;
                var password = model.Password;

                userMgr.Create(user, password);

                var userId = user.Id;
                var role = model.Role;
                userMgr.AddToRole(userId, role);

                return RedirectToAction("Users");
            }

            model = new AdminAddUserViewModel();

            var repo = new RolesRepositorySupport();
            model.Roles = new SelectList(repo.GetAll());

            return View(model);
        }

        [Authorize(Roles = "admin")]
        public ActionResult EditUser(string id)
        {
            var model = new AdminEditUserViewModel();

            var repo = new RolesRepositorySupport();
            model.Roles = new SelectList(repo.GetAll());

            var context = new GuildCarsDbContext();
            var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(context));

            var user = new AppUser();
            user = userMgr.FindById(id);

            if (user == null)
            {
                return RedirectToAction("Index", "Admin");
            }

            var role = userMgr.GetRoles(user.Id).FirstOrDefault();

            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.Email = user.Email;
            model.Role = role;

            var users = context.Users.ToList(); 

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult EditUser(AdminEditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var context = new GuildCarsDbContext();
                var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(context));

                var user = userMgr.FindById(model.Id);
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.UserName = model.Email;

                if (!string.IsNullOrEmpty(model.Password))
                {
                    var provider = new DpapiDataProtectionProvider();
                    userMgr.UserTokenProvider = new DataProtectorTokenProvider<AppUser>(provider.Create("UserToken"));
                    var token = userMgr.GeneratePasswordResetToken(user.Id);
                    userMgr.ResetPassword(user.Id, token, model.Password);
                }

                userMgr.Update(user);

                var oldRole = userMgr.GetRoles(user.Id).FirstOrDefault();
                var newRole = model.Role;

                if (oldRole != model.Role)
                {
                    userMgr.RemoveFromRole(user.Id, oldRole);
                    userMgr.AddToRole(user.Id, newRole);
                }

                return RedirectToAction("Users");
            }

            model = new AdminEditUserViewModel();

            var repo = new RolesRepositorySupport();
            model.Roles = new SelectList(repo.GetAll());

            return View(model);
        }

    }
}