using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Query
{
    public class FeaturedVehicleRequestItem
    {
        public int VehicleId { get; set; }
        public string Picture { get; set; }
        public DateTime Year { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public decimal MSRP { get; set; }
    }
}
