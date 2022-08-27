using GuildCars.Data.Interface;
using GuildCars.Models.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repository.QA
{
    public class ColorIntRepositoryQA : IColorIntRepository
    {
        private static List<ColorInt> _colors = new List<ColorInt>
        {
            new ColorInt { ColorIntId=1, ColorIntName="Black"},
            new ColorInt { ColorIntId=2, ColorIntName="Gray"},
            new ColorInt { ColorIntId=3, ColorIntName="Tan"},
            new ColorInt { ColorIntId=4, ColorIntName="White"},
            new ColorInt { ColorIntId=5, ColorIntName="Red"}
        };
        
        public List<ColorInt> GetAll()
        {
            return _colors;
        }
    }
}
