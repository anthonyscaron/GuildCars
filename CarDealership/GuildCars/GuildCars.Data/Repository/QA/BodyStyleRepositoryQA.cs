using GuildCars.Data.Interface;
using GuildCars.Models.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repository.QA
{
    public class BodyStyleRepositoryQA : IBodyStyleRepository
    {
        private static List<BodyStyle> _bodyStyles = new List<BodyStyle>
        {
            new BodyStyle {BodyStyleId=1, BodyStyleName="Car"},
            new BodyStyle {BodyStyleId=2, BodyStyleName="Truck"},
            new BodyStyle {BodyStyleId=3, BodyStyleName="Van"},
            new BodyStyle {BodyStyleId=4, BodyStyleName="SUV"}
        };

        public List<BodyStyle> GetAll()
        {
            return _bodyStyles;
        }
    }
}
