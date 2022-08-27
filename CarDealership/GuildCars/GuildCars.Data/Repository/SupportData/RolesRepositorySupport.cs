using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repository.SupportData
{
    public class RolesRepositorySupport
    {
        public List<string> GetAll()
        {
            var roles = new List<string>()
            {
                "admin",
                "sales",
                "disabled"
            };

            return roles;
        }
    }
}
