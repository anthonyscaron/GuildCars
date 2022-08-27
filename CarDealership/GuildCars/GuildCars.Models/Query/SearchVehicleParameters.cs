using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Query
{
    public class SearchVehicleParameters
    {
        public string SearchString { get; set; }
        public string MinYear { get; set; }
        public string MaxYear { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
    }
}
