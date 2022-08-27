using GuildCars.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class ReportsInventoryViewModel
    {
        public List<InventoryReportRequestItem> NewInventory { get; set; }
        public List<InventoryReportRequestItem> UsedInventory { get; set; }
    }
}