using GuildCars.Data.Interface;
using GuildCars.Data.Repository.PROD;
using GuildCars.Data.Repository.QA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Factory
{
    public static class UserRepositoryFactory
    {
        public static IUserRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "PROD":
                    return new UserRepositoryPROD();
                case "QA":
                    return new UserRepositoryQA();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }

        }
    }
}
