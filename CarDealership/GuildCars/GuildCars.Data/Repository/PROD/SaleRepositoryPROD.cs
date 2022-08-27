using GuildCars.Data.Interface;
using GuildCars.Models.Query;
using GuildCars.Models.Table;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repository.PROD
{
    public class SaleRepositoryPROD : ISaleRepository
    {
        public void CreateSale(Sale sale)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CreateSale", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@SaleId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@VehicleId", sale.VehicleId);
                cmd.Parameters.AddWithValue("@StateId", sale.StateId);
                cmd.Parameters.AddWithValue("@PurchaseTypeId", sale.PurchaseTypeId);
                cmd.Parameters.AddWithValue("@Username", sale.Username);
                cmd.Parameters.AddWithValue("@SaleName", sale.SaleName);

                if (string.IsNullOrEmpty(sale.SaleEmail))
                {
                    cmd.Parameters.AddWithValue("@SaleEmail", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SaleEmail", sale.SaleEmail);
                }

                if (string.IsNullOrEmpty(sale.SalePhone))
                {
                    cmd.Parameters.AddWithValue("@SalePhone", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SalePhone", sale.SalePhone);
                }

                cmd.Parameters.AddWithValue("@Street1", sale.Street1);

                if (string.IsNullOrEmpty(sale.Street2))
                {
                    cmd.Parameters.AddWithValue("@Street2", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Street2", sale.Street2);
                }

                cmd.Parameters.AddWithValue("@City", sale.City);
                cmd.Parameters.AddWithValue("@Zipcode", sale.Zipcode);
                cmd.Parameters.AddWithValue("@PurchasePrice", sale.PurchasePrice);
                cmd.Parameters.AddWithValue("@SaleDate", sale.SaleDate);

                cn.Open();

                cmd.ExecuteNonQuery();

                sale.SaleId = (int)param.Value;
            }
        }

        public List<Sale> GetAll()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<Sale> sales = new List<Sale>();
                SqlCommand cmd = new SqlCommand("SaleGetAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Sale currentRow = new Sale();
                        currentRow.SaleId = (int)dr["SaleId"];
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.StateId = (int)dr["StateId"];
                        currentRow.PurchaseTypeId = (int)dr["PurchaseTypeId"];
                        currentRow.Username = dr["Username"].ToString();
                        currentRow.SaleName = dr["SaleName"].ToString();
                        currentRow.SaleEmail = dr["SaleEmail"].ToString();
                        currentRow.SalePhone = dr["SalePhone"].ToString();
                        currentRow.Street1 = dr["Street1"].ToString();

                        if (dr["Street2"] != DBNull.Value)
                        {
                            currentRow.Street2 = dr["Street2"].ToString();
                        }
                        
                        currentRow.City = dr["City"].ToString();
                        currentRow.Zipcode = (int)dr["Zipcode"];
                        currentRow.PurchasePrice = (decimal)dr["PurchasePrice"];
                        currentRow.SaleDate = (DateTime)dr["SaleDate"];

                        sales.Add(currentRow);
                    }
                }

                return sales;
            }
        }

        public List<SalesReportRequestItem> GetSalesReport()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<SalesReportRequestItem> sales = new List<SalesReportRequestItem>();
                SqlCommand cmd = new SqlCommand("AdminGetSalesReport", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SalesReportRequestItem currentRow = new SalesReportRequestItem();
                        currentRow.FirstName = dr["FirstName"].ToString();
                        currentRow.LastName = dr["LastName"].ToString();
                        currentRow.TotalSales = (decimal)dr["Total Sales"];
                        currentRow.TotalVehicles = (int)dr["Total Vehicles"];

                        sales.Add(currentRow);
                    }
                }

                return sales;
            }
        }

        public List<SalesReportRequestItem> Search(SearchSalesParameters parameters)
        {
            List<SalesReportRequestItem> sales = new List<SalesReportRequestItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "SELECT DISTINCT FirstName, LastName, SUM(PurchasePrice) [Total Sales], COUNT(VehicleId) [Total Vehicles]" +
                    "FROM Sale s " +
                    "INNER JOIN AspNetUsers a ON a.UserName = s.Username " +
                    "INNER JOIN AspNetUserRoles ur ON ur.UserId = a.Id " +
                    "INNER JOIN AspNetRoles r ON r.Id = ur.RoleId " +
                    "WHERE r.Name = 'sales' ";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                if (parameters.SearchString != null)
                {
                    query += "AND (FirstName + ' ' + LastName) LIKE @SearchString ";
                    cmd.Parameters.AddWithValue("@SearchString", parameters.SearchString + '%');
                }

                if (parameters.FromYear != null)
                {
                    query += "AND (DATEPART(year, SaleDate) >= @FromYear) ";
                    cmd.Parameters.AddWithValue("@FromYear", parameters.FromYear);
                }

                if (parameters.ToYear != null)
                {
                    query += "AND (DATEPART(year, SaleDate) <= @ToYear) ";
                    cmd.Parameters.AddWithValue("@ToYear", parameters.ToYear);
                }

                query += "GROUP BY a.LastName, a.FirstName ";
                query += "ORDER BY [Total Sales] DESC";
                cmd.CommandText = query;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SalesReportRequestItem currentRow = new SalesReportRequestItem();
                        currentRow.FirstName = dr["FirstName"].ToString();
                        currentRow.LastName = dr["LastName"].ToString();
                        currentRow.TotalSales = (decimal)dr["Total Sales"];
                        currentRow.TotalVehicles = (int)dr["Total Vehicles"];

                        sales.Add(currentRow);
                    }
                }
            }

            return sales;
        }
    }
}
