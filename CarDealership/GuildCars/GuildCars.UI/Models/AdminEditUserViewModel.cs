using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class AdminEditUserViewModel : IValidatableObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Id { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(FirstName))
            {
                errors.Add(new ValidationResult("First Name is required"));
            }
            else if (FirstName.Length > 50)
            {
                errors.Add(new ValidationResult("The max length for First Name is 50 characters"));
            }

            if (string.IsNullOrEmpty(LastName))
            {
                errors.Add(new ValidationResult("Last Name is required"));
            }
            else if (LastName.Length > 50)
            {
                errors.Add(new ValidationResult("The max length for Last Name is 50 characters"));
            }

            if (string.IsNullOrEmpty(Email))
            {
                errors.Add(new ValidationResult("Email is required"));
            }
            else if (Email.Length > 50)
            {
                errors.Add(new ValidationResult("The max length for Email is 50 characters"));
            }
            else if (Email.Length < 17)
            {
                errors.Add(new ValidationResult("The min length for Email is 17 characters"));
            }
            else if (!Email.EndsWith("@guildcars.com"))
            {
                errors.Add(new ValidationResult("Email must be in this format: FirstNameLastName@guildcars.com"));
            }

            if (string.IsNullOrEmpty(Role))
            {
                errors.Add(new ValidationResult("Role is required"));
            }

            if (!string.IsNullOrEmpty(Password))
            {
                if (Password.Length > 30)
                {
                    errors.Add(new ValidationResult("The max length for Password is 30 characters"));
                }
                else if (Password.Length < 6)
                {
                    errors.Add(new ValidationResult("The min length for Password is 6 characters"));
                }

                if (string.IsNullOrEmpty(ConfirmPassword))
                {
                    errors.Add(new ValidationResult("Confirm Password is required"));
                }
                else if (ConfirmPassword != Password)
                {
                    errors.Add(new ValidationResult("Password and Confirm Password do not match"));
                }
            }

            return errors;
        }
    }
}