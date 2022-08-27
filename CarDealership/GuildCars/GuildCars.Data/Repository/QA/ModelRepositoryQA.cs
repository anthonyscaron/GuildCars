using GuildCars.Data.Interface;
using GuildCars.Models.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repository.QA
{
    public class ModelRepositoryQA : IModelRepository
    {
        private static List<Model> _models = new List<Model>
        {
            new Model {ModelId=1, MakeId=1, ModelName="Civic", DateAdded=new DateTime(2022, 07, 01, 00, 00, 00), 
                AddedByUser="robdenno@guildcars.com"},
            new Model {ModelId=2, MakeId=1, ModelName="Accord", DateAdded=new DateTime(2022, 07, 01, 00, 00, 00),
                AddedByUser="robdenno@guildcars.com"},
            new Model {ModelId=3, MakeId=2, ModelName="RX", DateAdded=new DateTime(2022, 07, 01, 00, 00, 00),
                AddedByUser="robdenno@guildcars.com"},
            new Model {ModelId=4, MakeId=2, ModelName="IS", DateAdded=new DateTime(2022, 07, 01, 00, 00, 00),
                AddedByUser="robdenno@guildcars.com"},
            new Model {ModelId=5, MakeId=3, ModelName="CX5", DateAdded=new DateTime(2022, 07, 10, 00, 00, 00),
                AddedByUser="robdenno@guildcars.com"},
            new Model {ModelId=6, MakeId=3, ModelName="3", DateAdded=new DateTime(2022, 07, 10, 00, 00, 00),
                AddedByUser="robdenno@guildcars.com"},
            new Model {ModelId=7, MakeId=4, ModelName="Ascent", DateAdded=new DateTime(2022, 07, 20, 00, 00, 00),
                AddedByUser="robdenno@guildcars.com"},
            new Model {ModelId=8, MakeId=4, ModelName="Outback", DateAdded=new DateTime(2022, 07, 20, 00, 00, 00),
                AddedByUser="robdenno@guildcars.com"},
            new Model {ModelId=9, MakeId=5, ModelName="Camry", DateAdded=new DateTime(2022, 07, 20, 00, 00, 00),
                AddedByUser="robdenno@guildcars.com"},
            new Model {ModelId=10, MakeId=5, ModelName="Highlander", DateAdded=new DateTime(2022, 07, 20, 00, 00, 00),
                AddedByUser="robdenno@guildcars.com"}
        };

        public void CreateModel(Model model)
        {
            model.ModelId = _models.Max(m => m.ModelId) + 1;
            _models.Add(model);
        }

        public List<Model> GetAll()
        {
            return _models;
        }

        public List<Model> GetByMakeName(string makeName)
        {
            var makeRepo = new MakeRepositoryQA();
            var make = makeRepo.GetAll().FirstOrDefault(m => m.MakeName == makeName);
            var modelsByMakeName = _models.Where(m => m.MakeId == make.MakeId).ToList();

            return modelsByMakeName;
        }
    }
}
