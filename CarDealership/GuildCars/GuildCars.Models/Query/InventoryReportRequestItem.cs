using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Query
{
    public class InventoryReportRequestItem
    {
        public DateTime Year { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public int Count { get; set; }
        public decimal StockValue { get; set; }
    }
}
