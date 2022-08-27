using GuildCars.Models.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interface
{
    public interface ISpecialRepository
    {
        List<Special> GetAll();
        Special GetSpecialById(int specialId);
        void CreateSpecial(Special special);
        void DeleteSpecial(int specialId);
    }
}
