using GuildCars.Models.Query;
using GuildCars.Models.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interface
{
    public interface ISaleRepository
    {
        List<Sale> GetAll();
        void CreateSale(Sale sale);
        List<SalesReportRequestItem> GetSalesReport();
        List<SalesReportRequestItem> Search(SearchSalesParameters parameters);
    }
}
