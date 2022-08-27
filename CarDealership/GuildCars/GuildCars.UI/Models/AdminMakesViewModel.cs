using GuildCars.Data.Factory;
using GuildCars.Models.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class AdminMakesViewModel : IValidatableObject
    {
        public List<Make> Makes { get; set; }
        public Make MakeToCreate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(MakeToCreate.MakeName))
            {
                errors.Add(new ValidationResult("New Make is required"));
            }
            else if (MakeToCreate.MakeName.Length > 10)
            {
                errors.Add(new ValidationResult("The max length for New Make is 10 characters"));
            }

            var repo = MakeRepositoryFactory.GetRepository();
            var makes = repo.GetAll();
            var alreadyExists = makes.Where(m=> m.MakeName.IndexOf(MakeToCreate.MakeName, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            if (alreadyExists.Count != 0)
            {
                errors.Add(new ValidationResult("That Make already exists"));
            }

            return errors;
        }
    }
}