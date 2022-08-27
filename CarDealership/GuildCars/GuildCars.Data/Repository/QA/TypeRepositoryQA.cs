using GuildCars.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repository.QA
{
    public class TypeRepositoryQA : ITypeRepository
    {
        private static List<Models.Table.Type> _types = new List<Models.Table.Type>
        {
            new Models.Table.Type {TypeId=1, TypeName="New"},
            new Models.Table.Type {TypeId=2, TypeName="Used"}
        };
        
        public List<Models.Table.Type> GetAll()
        {
            return _types;
        }
    }
}
