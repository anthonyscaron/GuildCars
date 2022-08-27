using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class HomeContactViewModel : IValidatableObject
    {
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string Message { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(ContactName))
            {
                errors.Add(new ValidationResult("Name is required"));
            }
            else if (ContactName.Length > 50)
            {
                errors.Add(new ValidationResult("The max length for Name is 50 characters"));
            }

            if (string.IsNullOrEmpty(Message))
            {
                errors.Add(new ValidationResult("Message is required"));
            }
            else if (Message.Length > 200)
            {
                errors.Add(new ValidationResult("The max length for Message is 200 characters"));
            }

            if (string.IsNullOrEmpty(ContactEmail) && string.IsNullOrEmpty(ContactPhone))
            {
                errors.Add(new ValidationResult("Either Email or Phone must be provided"));
            }
            else
            {
                if (!string.IsNullOrEmpty(ContactEmail) && ContactEmail.Length > 50)
                {
                    errors.Add(new ValidationResult("The max length for Email is 50 characters"));
                }
                else if (!string.IsNullOrEmpty(ContactEmail) && ContactEmail.Length < 7)
                {
                    errors.Add(new ValidationResult("The min length for Email is 7 characters"));
                }

                if (!string.IsNullOrEmpty(ContactPhone) && ContactPhone.Length != 10)
                {
                    errors.Add(new ValidationResult("The length for Phone is 10 characters"));
                }
                else if (!string.IsNullOrEmpty(ContactPhone) && ContactPhone.Length == 10)
                {
                    var phoneAsNumber = Int64.TryParse(ContactPhone, out long result);

                    if (!phoneAsNumber)
                    {
                        errors.Add(new ValidationResult("Phone must be numbers only"));
                    }      
                }
            }

            return errors;
        }
    }
}