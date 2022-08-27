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
    public static class MakeRepositoryFactory
    {
        public static IMakeRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "PROD":
                    return new MakeRepositoryPROD();
                case "QA":
                    return new MakeRepositoryQA();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}
