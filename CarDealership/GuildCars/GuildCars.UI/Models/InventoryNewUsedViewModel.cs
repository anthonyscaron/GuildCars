using GuildCars.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class InventoryNewUsedViewModel
    {
        public List<SearchVehicleRequestItem> SearchVehicleRequestItem { get; set; }
        public List<int> Years { get; set; }
        public List<decimal> Prices { get; set; }
    }
}