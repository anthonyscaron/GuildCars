using GuildCars.Data.Interface;
using GuildCars.Models.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repository.QA
{
    public class MakeRepositoryQA : IMakeRepository
    {
        private static List<Make> _makes = new List<Make>
        {
            new Make {MakeId=1, MakeName="Honda", DateAdded= new DateTime(2022, 07, 01, 00, 00, 00),AddedByUser="robdenno@guildcars.com"},
            new Make {MakeId=2, MakeName="Lexus", DateAdded= new DateTime(2022, 07, 01, 00, 00, 00),AddedByUser="robdenno@guildcars.com"},
            new Make {MakeId=3, MakeName="Mazda", DateAdded= new DateTime(2022, 07, 10, 00, 00, 00),AddedByUser="robdenno@guildcars.com"},
            new Make {MakeId=4, MakeName="Subaru", DateAdded= new DateTime(2022, 07, 20, 00, 00, 00),AddedByUser="robdenno@guildcars.com"},
            new Make {MakeId=5, MakeName="Toyota", DateAdded= new DateTime(2022, 07, 20, 00, 00, 00),AddedByUser="robdenno@guildcars.com"}
        };
        
        public void CreateMake(Make make)
        {
            make.MakeId = _makes.Max(m => m.MakeId) + 1;
            _makes.Add(make);
        }

        public List<Make> GetAll()
        {
            return _makes;
        }
    }
}
