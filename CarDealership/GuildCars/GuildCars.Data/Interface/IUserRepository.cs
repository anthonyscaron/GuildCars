using GuildCars.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interface
{
    public interface IUserRepository
    {
        List<AdminUserRequestItem> GetAll();
        AdminUserRequestItem GetById(string userId);
    }
}
