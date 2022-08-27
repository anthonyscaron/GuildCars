using GuildCars.Models.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interface
{
    public interface IModelRepository
    {
        List<Model> GetAll();
        List<Model> GetByMakeName(string makeName);
        void CreateModel(Model model);
    }
}
