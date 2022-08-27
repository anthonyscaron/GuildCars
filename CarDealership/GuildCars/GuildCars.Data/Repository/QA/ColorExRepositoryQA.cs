using GuildCars.Data.Interface;
using GuildCars.Models.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repository.QA
{
    public class ColorExRepositoryQA : IColorExRepository
    {
        private static List<ColorEx> _colors = new List<ColorEx>
        {
            new ColorEx {ColorExId=1, ColorExName="Black"},
            new ColorEx {ColorExId=2, ColorExName="Blue"},
            new ColorEx {ColorExId=3, ColorExName="Gray"},
            new ColorEx {ColorExId=4, ColorExName="Red"},
            new ColorEx {ColorExId=5, ColorExName="Silver"},
            new ColorEx {ColorExId=6, ColorExName="White"}
        };

        public List<ColorEx> GetAll()
        {
            return _colors;
        }
    }
}
