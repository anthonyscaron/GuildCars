using GuildCars.Data.Interface;
using GuildCars.Models.Query;
using GuildCars.Models.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repository.QA
{
    public class SaleRepositoryQA : ISaleRepository
    {
        private static List<Sale> _sales = new List<Sale>
        {
            new Sale{SaleId=1, VehicleId=1, Username="billanmcmillan@guildcars.com", SaleName="Carl First", SaleEmail="carl@test.com",
                SalePhone="5551112222", Street1="123 Potato Street", Street2="Apt 1", City="Minneapolis", StateId=23, Zipcode=55408,
                PurchasePrice=25000.00M, PurchaseTypeId=1, SaleDate=new DateTime(2021, 10, 20, 00, 00, 00)},

            new Sale{SaleId=2, VehicleId=7, Username="devynsusquatch@guildcars.com", SaleName="Gary Second", SaleEmail="gary@test.com",
                SalePhone="5552223333", Street1="987 Carrot Avenue", Street2="Unit 9", City="Saint Paul", StateId=23, Zipcode=55102,
                PurchasePrice=55000.00M, PurchaseTypeId=2, SaleDate=new DateTime(2021, 11, 21, 00, 00, 00)},

            new Sale{SaleId=3, VehicleId=10, Username="teejayones@guildcars.com", SaleName="Mary Third", SaleEmail="mary@test.com",
                SalePhone="5553334444", Street1="5 Yam Street", Street2=null, City="Apple Valley", StateId=23, Zipcode=55124,
                PurchasePrice=50000.00M, PurchaseTypeId=3, SaleDate=new DateTime(2021, 12, 22, 00, 00, 00)},

            new Sale{SaleId=4, VehicleId=14, Username="teejayones@guildcars.com", SaleName="Jaime Fourth", SaleEmail="jaime@test.com",
                SalePhone="5554445555", Street1="456 Sweet Potato Avenue", Street2=null, City="Eagan", StateId=23, Zipcode=55123,
                PurchasePrice=27000.00M, PurchaseTypeId=1, SaleDate=new DateTime(2022, 01, 23, 00, 00, 00)},

            new Sale{SaleId=5, VehicleId=18, Username="devynsusquatch@guildcars.com", SaleName="Rick Fifth", SaleEmail="rick@test.com",
                SalePhone="5555556666", Street1="753 Parsnip Street", Street2="Apt 101", City="Burnsville", StateId=23, Zipcode=55337,
                PurchasePrice=34000.00M, PurchaseTypeId=2, SaleDate=new DateTime(2022, 02, 24, 00, 00, 00)},

            new Sale{SaleId=6, VehicleId=20, Username="billanmcmillan@guildcars.com", SaleName="Jennifer Sixth", SaleEmail="jennifer@test.com",
                SalePhone="5556667777", Street1="852 Turnip Avenue", Street2="Unit 6B", City="Farmington", StateId=23, Zipcode=55024,
                PurchasePrice=44000.00M, PurchaseTypeId=3, SaleDate=new DateTime(2022, 03, 25, 00, 00, 00)},

            new Sale{SaleId=7, VehicleId=25, Username="billanmcmillan@guildcars.com", SaleName="Steve Seventh", SaleEmail="steve@test.com",
                SalePhone="5557778888", Street1="1937 Radish Street", Street2=null, City="Lakeville", StateId=23, Zipcode=55044,
                PurchasePrice=34000.00M, PurchaseTypeId=1, SaleDate=new DateTime(2022, 04, 26, 00, 00, 00)},

            new Sale{SaleId=8, VehicleId=29, Username="devynsusquatch@guildcars.com", SaleName="Oliver Eighth", SaleEmail="oliver@test.com",
                SalePhone="5558889999", Street1="78523 Ginger Avenue", Street2=null, City="Rosemount", StateId=23, Zipcode=55068,
                PurchasePrice=46000.00M, PurchaseTypeId=2, SaleDate=new DateTime(2022, 05, 27, 00, 00, 00)},

            new Sale{SaleId=9, VehicleId=34, Username="teejayones@guildcars.com", SaleName="Harold Nineth", SaleEmail="harold@test.com",
                SalePhone="5559990000", Street1="96541 Beet Street", Street2="Apt 369", City="Inver Grove Heights", StateId=23, Zipcode=55077,
                PurchasePrice=17500.00M, PurchaseTypeId=3, SaleDate=new DateTime(2022, 06, 28, 00, 00, 00)},

            new Sale{SaleId=10, VehicleId=39, Username="teejayones@guildcars.com", SaleName="Phil Tenth", SaleEmail="phil@test.com",
                SalePhone="5550001111", Street1="7 Rutabaga Avenue", Street2="Unit 888", City="Mendota Heights", StateId=23, Zipcode=55121,
                PurchasePrice=22000.00M, PurchaseTypeId=1, SaleDate=new DateTime(2022, 07, 29, 00, 00, 00)}
        };
        
        public void CreateSale(Sale sale)
        {
            sale.SaleId = _sales.Max(m => m.SaleId) + 1;
            _sales.Add(sale);
        }

        public List<Sale> GetAll()
        {
            return _sales;
        }

        public List<SalesReportRequestItem> GetSalesReport()
        {
            var salesReports = new List<SalesReportRequestItem>();
            
            var salesRepo = new SaleRepositoryQA();
            var sales = salesRepo.GetAll();

            var userRepo = new UserRepositoryQA();
            var users = userRepo.GetAll();

            foreach (var user in users)
            {
                if (user.Role == "sales")
                {
                    var salesByUser = sales.Where(m => m.Username == user.Email).ToList();

                    if (salesByUser != null)
                    {
                        var salesReport = new SalesReportRequestItem();
                        salesReport.FirstName = user.FirstName;
                        salesReport.LastName = user.LastName;
                        salesReport.TotalSales = 0;
                        salesReport.TotalVehicles = 0;

                        foreach (var sale in salesByUser)
                        {
                            salesReport.TotalSales += sale.PurchasePrice;
                            salesReport.TotalVehicles++;
                        }

                        salesReports.Add(salesReport);
                    }
                }
     
            }

            salesReports = salesReports.OrderByDescending(m => m.TotalSales).ToList();

            return salesReports;
        }

        public List<SalesReportRequestItem> Search(SearchSalesParameters parameters)
        {
            var sales = _sales;
            
            if (!string.IsNullOrEmpty(parameters.FromYear))
            {
                var year = Int32.TryParse(parameters.FromYear, out int result);
                var fromYear = new DateTime(result, 01, 01, 00, 00, 00);
                sales = sales.Where(m => m.SaleDate >= fromYear).ToList();
            }

            if (!string.IsNullOrEmpty(parameters.ToYear))
            {
                var year = Int32.TryParse(parameters.ToYear, out int result);
                var toYear = new DateTime(result, 07, 29, 00, 00, 00);
                sales = sales.Where(m => m.SaleDate <= toYear).ToList();
            }

            var salesReports = new List<SalesReportRequestItem>();

            var userRepo = new UserRepositoryQA();
            var users = userRepo.GetAll();

            foreach (var user in users)
            {
                if (user.Role == "sales")
                {
                    var salesByUser = sales.Where(m => m.Username == user.Email).ToList();

                    if (salesByUser != null)
                    {
                        var salesReport = new SalesReportRequestItem();
                        salesReport.FirstName = user.FirstName;
                        salesReport.LastName = user.LastName;
                        salesReport.TotalSales = 0;
                        salesReport.TotalVehicles = 0;

                        foreach (var sale in salesByUser)
                        {
                            salesReport.TotalSales += sale.PurchasePrice;
                            salesReport.TotalVehicles++;
                        }

                        salesReports.Add(salesReport);
                    }
                }

            }

            foreach (var r in salesReports)
            {
                if (!string.IsNullOrEmpty(parameters.SearchString))
                {
                    if ((r.FirstName + ' ' + r.LastName) == parameters.SearchString)
                    {
                        salesReports = salesReports.Where(m => (m.FirstName + ' ' + m.LastName).Contains(parameters.SearchString)).ToList();
                    }
                }
            }

            salesReports = salesReports.OrderByDescending(m => m.TotalSales).ToList();

            return salesReports;
        }
    }
}
