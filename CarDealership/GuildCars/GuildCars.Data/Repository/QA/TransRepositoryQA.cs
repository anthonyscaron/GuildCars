using GuildCars.Data.Interface;
using GuildCars.Models.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repository.QA
{
    public class TransRepositoryQA : ITransRepository
    {
        private static List<Trans> _trans = new List<Trans>
        {
            new Trans {TransId=1,TransName="Manual"},
            new Trans {TransId=2,TransName="Automatic"}
        };
        
        public List<Trans> GetAll()
        {
            return _trans;
        }
    }
}
