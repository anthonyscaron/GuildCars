using GuildCars.Models.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interface
{
    public interface IMakeRepository
    {
        List<Make> GetAll();
        void CreateMake(Make make);
    }
}
