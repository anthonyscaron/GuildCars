using GuildCars.Models.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class AdminSpecialsViewModel : IValidatableObject
    {
        public List<Special> Specials { get; set; }
        public string SpecialTitle { get; set; }
        public string SpecialDescription { get; set; }
        public string FileNameForPicture { get; set; }
        public string FileNameForIcon { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(SpecialTitle))
            {
                errors.Add(new ValidationResult("Title is required"));
            }
            else if (SpecialTitle.Length > 50)
            {
                errors.Add(new ValidationResult("The max length for Title is 50 characters"));
            }

            if (string.IsNullOrEmpty(SpecialDescription))
            {
                errors.Add(new ValidationResult("Description is required"));
            }
            else if (SpecialDescription.Length > 200)
            {
                errors.Add(new ValidationResult("The max length for Description is 200 characters"));
            }

            return errors;
        }
    }
}