using GuildCars.Models.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class AdminAddEditVehicleViewModel : IValidatableObject
    {
        public AddEditVehicleRequestItem AddEditVehicleRequestItem { get; set; }
        public int Year { get; set; }
        public IEnumerable<SelectListItem> Makes { get; set; }
        public IEnumerable<SelectListItem> Models { get; set; }
        public IEnumerable<SelectListItem> Types { get; set; }
        public IEnumerable<SelectListItem> BodyStyles { get; set; }
        public IEnumerable<SelectListItem> Trans { get; set; }
        public IEnumerable<SelectListItem> ColorEx { get; set; }
        public IEnumerable<SelectListItem> ColorInt { get; set; }
        public HttpPostedFileBase PictureUpload { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(AddEditVehicleRequestItem.MakeName))
            {
                errors.Add(new ValidationResult("Make is required"));
            }

            if (string.IsNullOrEmpty(AddEditVehicleRequestItem.ModelName))
            {
                errors.Add(new ValidationResult("Model is required"));
            }

            if (string.IsNullOrEmpty(AddEditVehicleRequestItem.TypeName))
            {
                errors.Add(new ValidationResult("Type is required"));
            }

            if (string.IsNullOrEmpty(AddEditVehicleRequestItem.BodyStyleName))
            {
                errors.Add(new ValidationResult("Body Style is required"));
            }

            if (string.IsNullOrEmpty(Year.ToString()))
            {
                errors.Add(new ValidationResult("Year is required"));
            }
            else
            {
                if (Year.ToString().Length != 4)
                {
                    errors.Add(new ValidationResult("Year must be 4 digits"));
                }
                else if (Year < 2000 || Year > DateTime.Now.Year)
                {
                    errors.Add(new ValidationResult("Year must be between 2000 and " + DateTime.Now.Year));
                }
            }

            if (string.IsNullOrEmpty(AddEditVehicleRequestItem.TransName))
            {
                errors.Add(new ValidationResult("Transmission is required"));
            }

            if (string.IsNullOrEmpty(AddEditVehicleRequestItem.ColorExName))
            {
                errors.Add(new ValidationResult("Color is required"));
            }

            if (string.IsNullOrEmpty(AddEditVehicleRequestItem.ColorIntName))
            {
                errors.Add(new ValidationResult("Interior is required"));
            }

            if (string.IsNullOrEmpty(AddEditVehicleRequestItem.Mileage.ToString()))
            {
                errors.Add(new ValidationResult("Mileage is required"));
            }
            else
            {
                if (string.IsNullOrEmpty(AddEditVehicleRequestItem.TypeName))
                {
                    errors.Add(new ValidationResult("Type is required to enter Mileage"));
                }
                else if (AddEditVehicleRequestItem.TypeName == "New")
                {
                    if (AddEditVehicleRequestItem.Mileage < 0 || AddEditVehicleRequestItem.Mileage > 1000)
                    {
                        errors.Add(new ValidationResult("Mileage for New Types must be between 0 and 1000"));
                    }
                }
                else if (AddEditVehicleRequestItem.TypeName == "Used")
                {
                    if (AddEditVehicleRequestItem.Mileage < 1000)
                    {
                        errors.Add(new ValidationResult("Mileage for Used Types must be greater than 1000"));
                    }
                }

                if (string.IsNullOrEmpty(AddEditVehicleRequestItem.VIN))
                {
                    errors.Add(new ValidationResult("VIN is required"));
                }
                else
                {
                    if (AddEditVehicleRequestItem.VIN.Length != 17)
                    {
                        errors.Add(new ValidationResult("VIN must be 17 characters"));
                    }
                }

                if (string.IsNullOrEmpty(AddEditVehicleRequestItem.MSRP.ToString()))
                {
                    errors.Add(new ValidationResult("Year is required"));
                }
                else
                {
                    if (AddEditVehicleRequestItem.MSRP <= 0)
                    {
                        errors.Add(new ValidationResult("MSRP must be greater than 0"));
                    }

                    if (AddEditVehicleRequestItem.MSRP > 99999)
                    {
                        errors.Add(new ValidationResult("MSRP must be less than 99999"));
                    }
                }

                if (string.IsNullOrEmpty(AddEditVehicleRequestItem.SalePrice.ToString()))
                {
                    errors.Add(new ValidationResult("Sale Price is required"));
                }
                else
                {
                    if (string.IsNullOrEmpty(AddEditVehicleRequestItem.MSRP.ToString()))
                    {
                        errors.Add(new ValidationResult("MSRP is required to enter Sale Price"));
                    }
                    else if (AddEditVehicleRequestItem.SalePrice > AddEditVehicleRequestItem.MSRP)
                    {
                        errors.Add(new ValidationResult("Sale Price must be less than MSRP"));
                    }
                }

                if (string.IsNullOrEmpty(AddEditVehicleRequestItem.Description))
                {
                    errors.Add(new ValidationResult("Sale Price must be less than MSRP"));
                }
                else if (AddEditVehicleRequestItem.Description.Length > 200)
                {
                    errors.Add(new ValidationResult("Description must be less than or equal to 200 characters."));
                }

                if (PictureUpload != null && PictureUpload.ContentLength > 0)
                {
                    var extensions = new string[] { ".jpg", ".png", ".jpeg" };

                    var extension = Path.GetExtension(PictureUpload.FileName);

                    if (!extensions.Contains(extension))
                    {
                        errors.Add(new ValidationResult("Image file must be a png, jpg, or jpeg"));
                    }
                }
            }

            return errors;
        }
    }
}