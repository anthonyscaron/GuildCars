using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Query
{
    public class SaleRequestItem
    {
        public int SaleId { get; set; }
        public int VehicleId { get; set; }
        public string SaleName { get; set; }
        public string SaleEmail { get; set; }
        public string SalePhone { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string StateAbbreviation { get; set; }
        public int Zipcode { get; set; }
        public decimal PurchasePrice { get; set; }
        public string PurchaseTypeName { get; set; }
        public string Username { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
