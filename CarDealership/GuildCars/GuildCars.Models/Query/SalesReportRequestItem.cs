using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Query
{
    public class SalesReportRequestItem
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal TotalSales { get; set; }
        public int TotalVehicles { get; set; }
    }
}
