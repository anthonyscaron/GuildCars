using System;
using GuildCars.Models.Table;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interface
{
    public interface ITypeRepository
    {
        List<Models.Table.Type> GetAll();
    }
}
