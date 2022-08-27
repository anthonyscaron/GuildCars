using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Query
{
    public class SearchSalesParameters
    {
        public string SearchString { get; set; }
        public string ToYear { get; set; }
        public string FromYear { get; set; }
    }
}
