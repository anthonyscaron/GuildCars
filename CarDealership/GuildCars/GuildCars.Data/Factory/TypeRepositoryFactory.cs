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
    public class TypeRepositoryFactory
    {
        public static ITypeRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "PROD":
                    return new TypeRepositoryPROD();
                case "QA":
                    return new TypeRepositoryQA();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}
