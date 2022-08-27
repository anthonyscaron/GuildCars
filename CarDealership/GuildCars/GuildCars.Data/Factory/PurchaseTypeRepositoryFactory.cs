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
    public static class PurchaseTypeRepositoryFactory
    {
        public static IPurchaseTypeRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "PROD":
                    return new PurchaseTypeRepositoryPROD();
                case "QA":
                    return new PurchaseTypeRepositoryQA();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}
