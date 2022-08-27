using GuildCars.Data.Factory;
using GuildCars.Models.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class AdminModelsViewModel : IValidatableObject
    {
        public List<Model> Models { get; set; }
        public IEnumerable<SelectListItem> Makes { get; set; }
        public List<Make> MakesToQuery { get; set; }
        public Model ModelToCreate { get; set; }
        public string MakeName { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(ModelToCreate.ModelName))
            {
                errors.Add(new ValidationResult("New Model is required"));
            }
            else if (ModelToCreate.ModelName.Length > 10)
            {
                errors.Add(new ValidationResult("The max length for New Model is 20 characters"));
            }

            var makeRepo = MakeRepositoryFactory.GetRepository();
            var makes = makeRepo.GetAll();

            if (makes.FirstOrDefault(m => m.MakeName == MakeName) != null)
            {
                var modelRepo = ModelRepositoryFactory.GetRepository();
                var models = modelRepo.GetAll();

                var alreadyExists = models.Where(m => m.ModelName.IndexOf(ModelToCreate.ModelName, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

                if (alreadyExists.Count != 0)
                {
                    errors.Add(new ValidationResult("That Model already exists"));
                }
            }

            return errors;
        }
    }
}