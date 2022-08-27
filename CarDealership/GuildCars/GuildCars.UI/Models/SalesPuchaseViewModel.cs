using GuildCars.Models.Query;
using GuildCars.Models.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class SalesPuchaseViewModel : IValidatableObject
    {
        public SearchVehicleRequestItem SearchVehicleRequestItem { get; set; }
        public SaleRequestItem SaleRequestItem { get; set; }
        public IEnumerable<SelectListItem> States { get; set; }
        public IEnumerable<SelectListItem> PurchaseTypes { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(SaleRequestItem.SaleName))
            {
                errors.Add(new ValidationResult("Name is required"));
            }
            else if (SaleRequestItem.SaleName.Length > 50)
            {
                errors.Add(new ValidationResult("The max length for Name is 50 characters"));
            }

            if (string.IsNullOrEmpty(SaleRequestItem.SaleEmail) && string.IsNullOrEmpty(SaleRequestItem.SalePhone))
            {
                errors.Add(new ValidationResult("Either Email or Phone must be provided"));
            }
            else
            {
                if (!string.IsNullOrEmpty(SaleRequestItem.SaleEmail) && SaleRequestItem.SaleEmail.Length > 50)
                {
                    errors.Add(new ValidationResult("The max length for Email is 50 characters"));
                }
                else if (!string.IsNullOrEmpty(SaleRequestItem.SaleEmail) && SaleRequestItem.SaleEmail.Length < 7)
                {
                    errors.Add(new ValidationResult("The min length for Email is 7 characters"));
                }

                if (!string.IsNullOrEmpty(SaleRequestItem.SalePhone) && SaleRequestItem.SalePhone.Length != 10)
                {
                    errors.Add(new ValidationResult("The length for Phone is 10 characters"));
                }
                else if (!string.IsNullOrEmpty(SaleRequestItem.SalePhone) && SaleRequestItem.SalePhone.Length == 10)
                {
                    var phoneAsNumber = Int64.TryParse(SaleRequestItem.SalePhone, out long result);

                    if (!phoneAsNumber)
                    {
                        errors.Add(new ValidationResult("Phone must be numbers only"));
                    }
                }
            }

            if (string.IsNullOrEmpty(SaleRequestItem.Street1))
            {
                errors.Add(new ValidationResult("Street 1 is required"));
            }
            else if (SaleRequestItem.Street1.Length > 50)
            {
                errors.Add(new ValidationResult("The max length for Street 1 is 50 characters"));
            }

            if (string.IsNullOrEmpty(SaleRequestItem.City))
            {
                errors.Add(new ValidationResult("City is required"));
            }
            else if (SaleRequestItem.City.Length > 50)
            {
                errors.Add(new ValidationResult("The max length for City is 50 characters"));
            }

            if (string.IsNullOrEmpty(SaleRequestItem.StateAbbreviation))
            {
                errors.Add(new ValidationResult("State is required"));
            }

            if (string.IsNullOrEmpty(SaleRequestItem.Zipcode.ToString()))
            {
                errors.Add(new ValidationResult("Zipcode is required"));
            }
            else if (SaleRequestItem.Zipcode.ToString().Length != 5)
            {
                errors.Add(new ValidationResult("The length for Zipcode is 5 characters"));
            }
            else if (SaleRequestItem.Zipcode.ToString().Length == 5)
            {
                var zipcodeAsNumber = Int64.TryParse(SaleRequestItem.Zipcode.ToString(), out long result);

                if (!zipcodeAsNumber)
                {
                    errors.Add(new ValidationResult("Zipcode must be numbers only"));
                }
            }

            if (string.IsNullOrEmpty(SaleRequestItem.PurchasePrice.ToString()))
            {
                errors.Add(new ValidationResult("Purchase Price is required"));
            }
            else
            {
                var purchasePriceAsNumber = Int64.TryParse(SaleRequestItem.PurchasePrice.ToString(), out long result);
                var minPrice = SearchVehicleRequestItem.MSRP * 0.95M;

                if (!purchasePriceAsNumber)
                {
                    errors.Add(new ValidationResult("Purchase Price must be numbers only"));
                }
                else if (SaleRequestItem.PurchasePrice < minPrice || SaleRequestItem.PurchasePrice > SearchVehicleRequestItem.MSRP)
                {
                    errors.Add(new ValidationResult("Purchase Price must be between " + minPrice + " and " + SearchVehicleRequestItem.MSRP));
                }
            }

            if (string.IsNullOrEmpty(SaleRequestItem.PurchaseTypeName))
            {
                errors.Add(new ValidationResult("Purchase Type is required"));
            }

            return errors;
        }
    }
}