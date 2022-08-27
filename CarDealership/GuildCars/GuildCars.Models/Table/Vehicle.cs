using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Table
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public int MakeId { get; set; }
        public int ModelId { get; set; }
        public int TypeId { get; set; }
        public int BodyStyleId { get; set; }
        public int TransId { get; set; }
        public int ColorExId { get; set; }
        public int ColorIntId { get; set; }
        public string VIN { get; set; }
        public DateTime Year { get; set; }
        public decimal SalePrice { get; set; }
        public decimal MSRP { get; set; }
        public int Mileage { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public bool Featured { get; set; }
        public bool IsDeleted { get; set; }
    }
}
