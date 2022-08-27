using GuildCars.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class ReportsSalesViewModel
    {
        public List<SalesReportRequestItem> SalesReportRequestItem { get; set; }
        public List<string> Users { get; set; }
        public List<int> Years { get; set; }
    }
}