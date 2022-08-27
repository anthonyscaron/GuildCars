using GuildCars.Data.Interface;
using GuildCars.Models.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repository.QA
{
    public class SpecialRepositoryQA : ISpecialRepository
    {
        private static List<Special> _specials = new List<Special>
        {
            new Special {SpecialId=1, SpecialTitle="Summer Sale Surge", Description="All vehicles are up to $2,000.00 off all summer long!"},
            new Special {SpecialId=2, SpecialTitle="Sunday SUV Special", Description="Save up to $1,000.00 on all SUV any Sunday this month!"},
            new Special {SpecialId=3, SpecialTitle="Labor Day Special", Description="This coming Labor Day save up to $3,000.00!"}
        };
        
        public void CreateSpecial(Special special)
        {
            special.SpecialId = _specials.Max(m => m.SpecialId) + 1;
            _specials.Add(special);
        }

        public void DeleteSpecial(int specialId)
        {
            _specials.RemoveAll(m => m.SpecialId == specialId);
        }

        public List<Special> GetAll()
        {
            return _specials;
        }

        public Special GetSpecialById(int specialId)
        {
            var special = _specials.FirstOrDefault(m => m.SpecialId == specialId);
            return special;
        }
    }
}
