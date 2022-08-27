using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Query
{
    public class AddEditVehicleRequestItem
    {
        public int VehicleId { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public string TypeName { get; set; }
        public string BodyStyleName { get; set; }
        public DateTime Year { get; set; }
        public string TransName { get; set; }
        public string ColorExName { get; set; }
        public string ColorIntName { get; set; }
        public int Mileage { get; set; }
        public string VIN { get; set; }
        public decimal SalePrice { get; set; }
        public decimal MSRP { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public bool Featured { get; set; }
        public bool IsDeleted { get; set; }
    }
}
