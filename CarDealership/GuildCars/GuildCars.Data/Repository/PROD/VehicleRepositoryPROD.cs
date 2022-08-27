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
    public class VehicleRepositoryPROD : IVehicleRepository
    {
        public List<AddEditVehicleRequestItem> AdminGetAll()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<AddEditVehicleRequestItem> vehicles = new List<AddEditVehicleRequestItem>();
                SqlCommand cmd = new SqlCommand("AdminGetAllAddEditVehicleViewModels", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        AddEditVehicleRequestItem currentRow = new AddEditVehicleRequestItem();
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.Year = (DateTime)dr["Year"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.Picture = dr["Picture"].ToString();
                        currentRow.BodyStyleName = dr["BodyStyleName"].ToString();
                        currentRow.ColorIntName = dr["ColorIntName"].ToString();
                        currentRow.TypeName = dr["TypeName"].ToString();
                        currentRow.SalePrice = (decimal)dr["SalePrice"];
                        currentRow.TransName = dr["TransName"].ToString();
                        currentRow.Mileage = (int)dr["Mileage"];
                        currentRow.MSRP = (decimal)dr["MSRP"];
                        currentRow.ColorExName = dr["ColorExName"].ToString();
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.Description = dr["Description"].ToString();
                        currentRow.IsDeleted = (bool)dr["IsDeleted"];
                        currentRow.Featured = (bool)dr["Featured"];

                        vehicles.Add(currentRow);
                    }
                }

                return vehicles;
            }
        }

        public List<InventoryReportRequestItem> AdminGetNewInventoryReport()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<InventoryReportRequestItem> inventory = new List<InventoryReportRequestItem>();
                SqlCommand cmd = new SqlCommand("AdminGetNewInventoryReport", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        InventoryReportRequestItem currentRow = new InventoryReportRequestItem();
                        currentRow.Year = (DateTime)dr["Year"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.Count = (int)dr["Count"];
                        currentRow.StockValue = (decimal)dr["Stock Value"];

                        inventory.Add(currentRow);
                    }
                }

                return inventory;
            }
        }

        public List<InventoryReportRequestItem> AdminGetUsedInventoryReport()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<InventoryReportRequestItem> inventory = new List<InventoryReportRequestItem>();
                SqlCommand cmd = new SqlCommand("AdminGetUsedInventoryReport", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        InventoryReportRequestItem currentRow = new InventoryReportRequestItem();
                        currentRow.Year = (DateTime)dr["Year"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.Count = (int)dr["Count"];
                        currentRow.StockValue = (decimal)dr["Stock Value"];

                        inventory.Add(currentRow);
                    }
                }

                return inventory;
            }
        }

        public AddEditVehicleRequestItem AdminGetVehicleById(int vehicleId)
        {
            AddEditVehicleRequestItem vehicle = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<Vehicle> vehicles = new List<Vehicle>();
                SqlCommand cmd = new SqlCommand("AdminGetAddEditVehicleViewModelById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleId", vehicleId);

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        vehicle = new AddEditVehicleRequestItem();

                        vehicle.VehicleId = (int)dr["VehicleId"];
                        vehicle.Year = (DateTime)dr["Year"];
                        vehicle.MakeName = dr["MakeName"].ToString();
                        vehicle.ModelName = dr["ModelName"].ToString();
                        vehicle.Picture = dr["Picture"].ToString();
                        vehicle.BodyStyleName = dr["BodyStyleName"].ToString();
                        vehicle.ColorIntName = dr["ColorIntName"].ToString();
                        vehicle.TypeName = dr["TypeName"].ToString();
                        vehicle.SalePrice = (decimal)dr["SalePrice"];
                        vehicle.TransName = dr["TransName"].ToString();
                        vehicle.Mileage = (int)dr["Mileage"];
                        vehicle.MSRP = (decimal)dr["MSRP"];
                        vehicle.ColorExName = dr["ColorExName"].ToString();
                        vehicle.VIN = dr["VIN"].ToString();
                        vehicle.Description = dr["Description"].ToString();
                        vehicle.IsDeleted = (bool)dr["IsDeleted"];
                        vehicle.Featured = (bool)dr["Featured"];
                    }
                }
            }

            return vehicle;
        }

        public void CreateVehicle(Vehicle vehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CreateVehicle", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@VehicleId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@MakeId", vehicle.MakeId);
                cmd.Parameters.AddWithValue("@ModelId", vehicle.ModelId);
                cmd.Parameters.AddWithValue("@TypeId", vehicle.TypeId);
                cmd.Parameters.AddWithValue("@BodyStyleId", vehicle.BodyStyleId);
                cmd.Parameters.AddWithValue("@TransId", vehicle.TransId);
                cmd.Parameters.AddWithValue("@ColorIntId", vehicle.ColorIntId);
                cmd.Parameters.AddWithValue("@ColorExId", vehicle.ColorExId);
                cmd.Parameters.AddWithValue("@VIN", vehicle.VIN);
                cmd.Parameters.AddWithValue("@Year", vehicle.Year);
                cmd.Parameters.AddWithValue("@SalePrice", vehicle.SalePrice);
                cmd.Parameters.AddWithValue("@MSRP", vehicle.MSRP);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@Description", vehicle.Description);
                cmd.Parameters.AddWithValue("@Picture", vehicle.Picture);
                cmd.Parameters.AddWithValue("@Featured", vehicle.Featured);
                cmd.Parameters.AddWithValue("@IsDeleted", vehicle.IsDeleted);

                cn.Open();

                cmd.ExecuteNonQuery();

                vehicle.VehicleId = (int)param.Value;
            }
        }

        public void DeleteVehicle(Vehicle vehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DeleteVehicle", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleId", vehicle.VehicleId);
                cmd.Parameters.AddWithValue("@MakeId", vehicle.MakeId);
                cmd.Parameters.AddWithValue("@ModelId", vehicle.ModelId);
                cmd.Parameters.AddWithValue("@TypeId", vehicle.TypeId);
                cmd.Parameters.AddWithValue("@BodyStyleId", vehicle.BodyStyleId);
                cmd.Parameters.AddWithValue("@TransId", vehicle.TransId);
                cmd.Parameters.AddWithValue("@ColorIntId", vehicle.ColorIntId);
                cmd.Parameters.AddWithValue("@ColorExId", vehicle.ColorExId);
                cmd.Parameters.AddWithValue("@VIN", vehicle.VIN);
                cmd.Parameters.AddWithValue("@Year", vehicle.Year);
                cmd.Parameters.AddWithValue("@SalePrice", vehicle.SalePrice);
                cmd.Parameters.AddWithValue("@MSRP", vehicle.MSRP);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@Description", vehicle.Description);
                cmd.Parameters.AddWithValue("@Picture", vehicle.Picture);
                cmd.Parameters.AddWithValue("@Featured", vehicle.Featured);
                cmd.Parameters.AddWithValue("@IsDeleted", vehicle.IsDeleted);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public List<Vehicle> GetAll()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<Vehicle> vehicles = new List<Vehicle>();
                SqlCommand cmd = new SqlCommand("VehicleGetAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle currentRow = new Vehicle();
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.MakeId = (int)dr["MakeId"];
                        currentRow.ModelId = (int)dr["ModelId"];
                        currentRow.TypeId = (int)dr["TypeId"];
                        currentRow.BodyStyleId = (int)dr["BodyStyleId"];
                        currentRow.TransId = (int)dr["TransId"];
                        currentRow.ColorIntId = (int)dr["ColorIntId"];
                        currentRow.ColorExId = (int)dr["ColorExId"];
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.Year = (DateTime)dr["Year"];
                        currentRow.SalePrice = (decimal)dr["SalePrice"];
                        currentRow.MSRP = (decimal)dr["MSRP"];
                        currentRow.Mileage = (int)dr["Mileage"];
                        currentRow.Description = dr["Description"].ToString();
                        currentRow.Picture = dr["Picture"].ToString();

                        if (dr["Featured"] != DBNull.Value)
                        {
                            currentRow.Featured = (bool)dr["Featured"];
                        }

                        currentRow.IsDeleted = (bool)dr["IsDeleted"];

                        vehicles.Add(currentRow);
                    }
                }

                return vehicles;
            }
        }

        public List<Vehicle> GetAllAvailable()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<Vehicle> vehicles = new List<Vehicle>();
                SqlCommand cmd = new SqlCommand("VehicleGetAllAvailable", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle currentRow = new Vehicle();
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.MakeId = (int)dr["MakeId"];
                        currentRow.ModelId = (int)dr["ModelId"];
                        currentRow.TypeId = (int)dr["TypeId"];
                        currentRow.BodyStyleId = (int)dr["BodyStyleId"];
                        currentRow.TransId = (int)dr["TransId"];
                        currentRow.ColorIntId = (int)dr["ColorIntId"];
                        currentRow.ColorExId = (int)dr["ColorExId"];
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.Year = (DateTime)dr["Year"];
                        currentRow.SalePrice = (decimal)dr["SalePrice"];
                        currentRow.MSRP = (decimal)dr["MSRP"];
                        currentRow.Mileage = (int)dr["Mileage"];
                        currentRow.Description = dr["Description"].ToString();
                        currentRow.Picture = dr["Picture"].ToString();

                        if (dr["Featured"] != DBNull.Value)
                        {
                            currentRow.Featured = (bool)dr["Featured"];
                        }

                        currentRow.IsDeleted = (bool)dr["IsDeleted"];

                        vehicles.Add(currentRow);
                    }
                }

                return vehicles;
            }
        }

        public List<FeaturedVehicleRequestItem> GetAllFeatured()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<FeaturedVehicleRequestItem> vehicles = new List<FeaturedVehicleRequestItem>();
                SqlCommand cmd = new SqlCommand("VehicleGetAllFeatured", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        FeaturedVehicleRequestItem currentRow = new FeaturedVehicleRequestItem();
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.Year = (DateTime)dr["Year"];
                        currentRow.MSRP = (decimal)dr["MSRP"];
                        currentRow.Picture = dr["Picture"].ToString();

                        vehicles.Add(currentRow);
                    }
                }

                return vehicles;
            }
        }

        public List<SearchVehicleRequestItem> GetAllNew()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<SearchVehicleRequestItem> vehicles = new List<SearchVehicleRequestItem>();
                SqlCommand cmd = new SqlCommand("VehicleGetAllNew", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SearchVehicleRequestItem currentRow = new SearchVehicleRequestItem();
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.Year = (DateTime)dr["Year"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.Picture = dr["Picture"].ToString();
                        currentRow.BodyStyleName = dr["BodyStyleName"].ToString();
                        currentRow.ColorIntName = dr["ColorIntName"].ToString();
                        currentRow.SalePrice = (decimal)dr["SalePrice"];
                        currentRow.TransName = dr["TransName"].ToString();
                        currentRow.Mileage = (int)dr["Mileage"];
                        currentRow.MSRP = (decimal)dr["MSRP"];
                        currentRow.ColorExName = dr["ColorExName"].ToString();
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.Description = dr["Description"].ToString();

                        vehicles.Add(currentRow);
                    }
                }

                return vehicles;
            }
        }

        public List<Vehicle> GetAllSold()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<Vehicle> vehicles = new List<Vehicle>();
                SqlCommand cmd = new SqlCommand("VehicleGetAllSold", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle currentRow = new Vehicle();
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.MakeId = (int)dr["MakeId"];
                        currentRow.ModelId = (int)dr["ModelId"];
                        currentRow.TypeId = (int)dr["TypeId"];
                        currentRow.BodyStyleId = (int)dr["BodyStyleId"];
                        currentRow.TransId = (int)dr["TransId"];
                        currentRow.ColorIntId = (int)dr["ColorIntId"];
                        currentRow.ColorExId = (int)dr["ColorExId"];
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.Year = (DateTime)dr["Year"];
                        currentRow.SalePrice = (decimal)dr["SalePrice"];
                        currentRow.MSRP = (decimal)dr["MSRP"];
                        currentRow.Mileage = (int)dr["Mileage"];
                        currentRow.Description = dr["Description"].ToString();
                        currentRow.Picture = dr["Picture"].ToString();

                        if (dr["Featured"] != DBNull.Value)
                        {
                            currentRow.Featured = (bool)dr["Featured"];
                        }

                        currentRow.IsDeleted = (bool)dr["IsDeleted"];

                        vehicles.Add(currentRow);
                    }
                }

                return vehicles;
            }
        }

        public List<SearchVehicleRequestItem> GetAllToSell()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<SearchVehicleRequestItem> vehicles = new List<SearchVehicleRequestItem>();
                SqlCommand cmd = new SqlCommand("VehicleGetAllToSell", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SearchVehicleRequestItem currentRow = new SearchVehicleRequestItem();
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.Year = (DateTime)dr["Year"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.Picture = dr["Picture"].ToString();
                        currentRow.BodyStyleName = dr["BodyStyleName"].ToString();
                        currentRow.ColorIntName = dr["ColorIntName"].ToString();
                        currentRow.SalePrice = (decimal)dr["SalePrice"];
                        currentRow.TransName = dr["TransName"].ToString();
                        currentRow.Mileage = (int)dr["Mileage"];
                        currentRow.MSRP = (decimal)dr["MSRP"];
                        currentRow.ColorExName = dr["ColorExName"].ToString();
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.Description = dr["Description"].ToString();

                        vehicles.Add(currentRow);
                    }
                }

                return vehicles;
            }
        }

        public List<SearchVehicleRequestItem> GetAllUsed()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<SearchVehicleRequestItem> vehicles = new List<SearchVehicleRequestItem>();
                SqlCommand cmd = new SqlCommand("VehicleGetAllUsed", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SearchVehicleRequestItem currentRow = new SearchVehicleRequestItem();
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.Year = (DateTime)dr["Year"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.Picture = dr["Picture"].ToString();
                        currentRow.BodyStyleName = dr["BodyStyleName"].ToString();
                        currentRow.ColorIntName = dr["ColorIntName"].ToString();
                        currentRow.SalePrice = (decimal)dr["SalePrice"];
                        currentRow.TransName = dr["TransName"].ToString();
                        currentRow.Mileage = (int)dr["Mileage"];
                        currentRow.MSRP = (decimal)dr["MSRP"];
                        currentRow.ColorExName = dr["ColorExName"].ToString();
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.Description = dr["Description"].ToString();

                        vehicles.Add(currentRow);
                    }
                }

                return vehicles;
            }
        }

        public Vehicle GetVehicleById(int vehicleId)
        {
            Vehicle vehicle = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<Vehicle> vehicles = new List<Vehicle>();
                SqlCommand cmd = new SqlCommand("VehicleGetById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleId", vehicleId);

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        vehicle = new Vehicle();
                        vehicle.VehicleId = (int)dr["VehicleId"];
                        vehicle.MakeId = (int)dr["MakeId"];
                        vehicle.ModelId = (int)dr["ModelId"];
                        vehicle.TypeId = (int)dr["TypeId"];
                        vehicle.BodyStyleId = (int)dr["BodyStyleId"];
                        vehicle.TransId = (int)dr["TransId"];
                        vehicle.ColorIntId = (int)dr["ColorIntId"];
                        vehicle.ColorExId = (int)dr["ColorExId"];
                        vehicle.VIN = dr["VIN"].ToString();
                        vehicle.Year = (DateTime)dr["Year"];
                        vehicle.SalePrice = (decimal)dr["SalePrice"];
                        vehicle.MSRP = (decimal)dr["MSRP"];
                        vehicle.Mileage = (int)dr["Mileage"];
                        vehicle.Description = dr["Description"].ToString();
                        vehicle.Picture = dr["Picture"].ToString();

                        if (dr["Featured"] != DBNull.Value)
                        {
                            vehicle.Featured = (bool)dr["Featured"];
                        }

                        vehicle.IsDeleted = (bool)dr["IsDeleted"];
                    }
                }
            }

            return vehicle;
        }

        public List<SearchVehicleRequestItem> SearchAllAvailableToSell(SearchVehicleParameters parameters)
        {
            List<SearchVehicleRequestItem> vehicles = new List<SearchVehicleRequestItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "SELECT VehicleId, [Year], MakeName, ModelName, Picture, BodyStyleName, ColorIntName, " +
                    "SalePrice, TransName, Mileage, MSRP, ColorExName, VIN, [Description], IsDeleted " +
                    "FROM Vehicle V " +
                    "INNER JOIN Make ma ON ma.MakeId = v.MakeId " +
                    "INNER JOIN Model mo ON mo.ModelId = v.ModelId " +
                    "INNER JOIN BodyStyle b ON b.BodyStyleId = v.BodyStyleId " +
                    "INNER JOIN ColorInt ci ON ci.ColorIntId = v.ColorIntId " +
                    "INNER JOIN Trans t ON t.TransId = v.TransId " +
                    "INNER JOIN ColorEx ce ON ce.ColorExId = v.ColorExId " +
                    "WHERE (IsDeleted = 0) ";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                if (parameters.SearchString != null)
                {
                    query += "AND (MakeName LIKE @SearchString " +
                       "OR ModelName LIKE @SearchString " +
                       "OR DATEPART(year,[Year]) LIKE @SearchString) ";
                    cmd.Parameters.AddWithValue("@SearchString", parameters.SearchString + '%');
                }

                if (parameters.MinYear != null)
                {
                    query += "AND (DATEPART(year,[Year]) >= @MinYear) ";
                    cmd.Parameters.AddWithValue("@MinYear", parameters.MinYear);
                }

                if (parameters.MaxYear != null)
                {
                    query += "AND (DATEPART(year,[Year]) <= @MaxYear) ";
                    cmd.Parameters.AddWithValue("@MaxYear", parameters.MaxYear);
                }

                if (parameters.MinPrice != null)
                {
                    query += "AND (MSRP >= @MinPrice) ";
                    cmd.Parameters.AddWithValue("@MinPrice", parameters.MinPrice.Value);
                }

                if (parameters.MaxPrice != null)
                {
                    query += "AND (MSRP <= @MaxPrice) ";
                    cmd.Parameters.AddWithValue("@MaxPrice", parameters.MaxPrice.Value);
                }

                query += "ORDER BY MSRP DESC";
                cmd.CommandText = query;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SearchVehicleRequestItem currentRow = new SearchVehicleRequestItem();

                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.Year = (DateTime)dr["Year"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.Picture = dr["Picture"].ToString();
                        currentRow.BodyStyleName = dr["BodyStyleName"].ToString();
                        currentRow.ColorIntName = dr["ColorIntName"].ToString();
                        currentRow.SalePrice = (decimal)dr["SalePrice"];
                        currentRow.TransName = dr["TransName"].ToString();
                        currentRow.Mileage = (int)dr["Mileage"];
                        currentRow.MSRP = (decimal)dr["MSRP"];
                        currentRow.ColorExName = dr["ColorExName"].ToString();
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.Description = dr["Description"].ToString();
                        currentRow.IsDeleted = (bool)dr["IsDeleted"];

                        vehicles.Add(currentRow);
                    }
                }
            }

            return vehicles;
        }

        public List<SearchVehicleRequestItem> SearchNew(SearchVehicleParameters parameters)
        {
            List<SearchVehicleRequestItem> vehicles = new List<SearchVehicleRequestItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "SELECT TOP 20 VehicleId, [Year], MakeName, ModelName, Picture, BodyStyleName, ColorIntName, " +
                    "SalePrice, TransName, Mileage, MSRP, ColorExName, VIN, [Description], IsDeleted " +
                    "FROM Vehicle V " +
                    "INNER JOIN Make ma ON ma.MakeId = v.MakeId " +
                    "INNER JOIN Model mo ON mo.ModelId = v.ModelId " +
                    "INNER JOIN BodyStyle b ON b.BodyStyleId = v.BodyStyleId " +
                    "INNER JOIN ColorInt ci ON ci.ColorIntId = v.ColorIntId " +
                    "INNER JOIN Trans t ON t.TransId = v.TransId " +
                    "INNER JOIN ColorEx ce ON ce.ColorExId = v.ColorExId " +
                    "WHERE (IsDeleted = 0 AND V.TypeId = 1) ";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                if (parameters.SearchString != null)
                {
                    query += "AND (MakeName LIKE @SearchString " +
                       "OR ModelName LIKE @SearchString " +
                       "OR DATEPART(year,[Year]) LIKE @SearchString) ";
                    cmd.Parameters.AddWithValue("@SearchString", parameters.SearchString + '%');
                }

                if (parameters.MinYear != null)
                {
                    query += "AND (DATEPART(year,[Year]) >= @MinYear) ";
                    cmd.Parameters.AddWithValue("@MinYear", parameters.MinYear);
                }

                if (parameters.MaxYear != null)
                {
                    query += "AND (DATEPART(year,[Year]) <= @MaxYear) ";
                    cmd.Parameters.AddWithValue("@MaxYear", parameters.MaxYear);
                }

                if (parameters.MinPrice != null)
                {
                    query += "AND (MSRP >= @MinPrice) ";
                    cmd.Parameters.AddWithValue("@MinPrice", parameters.MinPrice.Value);
                }

                if (parameters.MaxPrice != null)
                {
                    query += "AND (MSRP <= @MaxPrice) ";
                    cmd.Parameters.AddWithValue("@MaxPrice", parameters.MaxPrice.Value);
                }

                query += "ORDER BY MSRP DESC";
                cmd.CommandText = query;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SearchVehicleRequestItem currentRow = new SearchVehicleRequestItem();

                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.Year = (DateTime)dr["Year"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.Picture = dr["Picture"].ToString();
                        currentRow.BodyStyleName = dr["BodyStyleName"].ToString();
                        currentRow.ColorIntName = dr["ColorIntName"].ToString();
                        currentRow.SalePrice = (decimal)dr["SalePrice"];
                        currentRow.TransName = dr["TransName"].ToString();
                        currentRow.Mileage = (int)dr["Mileage"];
                        currentRow.MSRP = (decimal)dr["MSRP"];
                        currentRow.ColorExName = dr["ColorExName"].ToString();
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.Description = dr["Description"].ToString();
                        currentRow.IsDeleted = (bool)dr["IsDeleted"];

                        vehicles.Add(currentRow);
                    }
                }
            }

            return vehicles;
        }

        public List<SearchVehicleRequestItem> SearchUsed(SearchVehicleParameters parameters)
        {
            List<SearchVehicleRequestItem> vehicles = new List<SearchVehicleRequestItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "SELECT TOP 20 VehicleId, [Year], MakeName, ModelName, Picture, BodyStyleName, ColorIntName, " +
                    "SalePrice, TransName, Mileage, MSRP, ColorExName, VIN, [Description], IsDeleted " +
                    "FROM Vehicle V " +
                    "INNER JOIN Make ma ON ma.MakeId = v.MakeId " +
                    "INNER JOIN Model mo ON mo.ModelId = v.ModelId " +
                    "INNER JOIN BodyStyle b ON b.BodyStyleId = v.BodyStyleId " +
                    "INNER JOIN ColorInt ci ON ci.ColorIntId = v.ColorIntId " +
                    "INNER JOIN Trans t ON t.TransId = v.TransId " +
                    "INNER JOIN ColorEx ce ON ce.ColorExId = v.ColorExId " +
                    "WHERE (IsDeleted = 0 and V.TypeId = 2) ";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                if (parameters.SearchString != null)
                {
                    query += "AND (MakeName LIKE @SearchString " +
                       "OR ModelName LIKE @SearchString " +
                       "OR DATEPART(year,[Year]) LIKE @SearchString) ";
                    cmd.Parameters.AddWithValue("@SearchString", parameters.SearchString + '%');
                }

                if (parameters.MinYear != null)
                {
                    query += "AND (DATEPART(year,[Year]) >= @MinYear) ";
                    cmd.Parameters.AddWithValue("@MinYear", parameters.MinYear);
                }

                if (parameters.MaxYear != null)
                {
                    query += "AND (DATEPART(year,[Year]) <= @MaxYear) ";
                    cmd.Parameters.AddWithValue("@MaxYear", parameters.MaxYear);
                }

                if (parameters.MinPrice != null)
                {
                    query += "AND (MSRP >= @MinPrice) ";
                    cmd.Parameters.AddWithValue("@MinPrice", parameters.MinPrice.Value);
                }

                if (parameters.MaxPrice != null)
                {
                    query += "AND (MSRP <= @MaxPrice) ";
                    cmd.Parameters.AddWithValue("@MaxPrice", parameters.MaxPrice.Value);
                }

                query += "ORDER BY MSRP DESC";
                cmd.CommandText = query;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SearchVehicleRequestItem currentRow = new SearchVehicleRequestItem();

                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.Year = (DateTime)dr["Year"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.Picture = dr["Picture"].ToString();
                        currentRow.BodyStyleName = dr["BodyStyleName"].ToString();
                        currentRow.ColorIntName = dr["ColorIntName"].ToString();
                        currentRow.SalePrice = (decimal)dr["SalePrice"];
                        currentRow.TransName = dr["TransName"].ToString();
                        currentRow.Mileage = (int)dr["Mileage"];
                        currentRow.MSRP = (decimal)dr["MSRP"];
                        currentRow.ColorExName = dr["ColorExName"].ToString();
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.Description = dr["Description"].ToString();
                        currentRow.IsDeleted = (bool)dr["IsDeleted"];

                        vehicles.Add(currentRow);
                    }
                }
            }

            return vehicles;
        }

        public SearchVehicleRequestItem SearchVehicleById(int vehicleId)
        {
            SearchVehicleRequestItem vehicle = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<Vehicle> vehicles = new List<Vehicle>();
                SqlCommand cmd = new SqlCommand("SearchVehicleById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleId", vehicleId);

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        vehicle = new SearchVehicleRequestItem();

                        vehicle.VehicleId = (int)dr["VehicleId"];
                        vehicle.Year = (DateTime)dr["Year"];
                        vehicle.MakeName = dr["MakeName"].ToString();
                        vehicle.ModelName = dr["ModelName"].ToString();
                        vehicle.Picture = dr["Picture"].ToString();
                        vehicle.BodyStyleName = dr["BodyStyleName"].ToString();
                        vehicle.ColorIntName = dr["ColorIntName"].ToString();
                        vehicle.SalePrice = (decimal)dr["SalePrice"];
                        vehicle.TransName = dr["TransName"].ToString();
                        vehicle.Mileage = (int)dr["Mileage"];
                        vehicle.MSRP = (decimal)dr["MSRP"];
                        vehicle.ColorExName = dr["ColorExName"].ToString();
                        vehicle.VIN = dr["VIN"].ToString();
                        vehicle.Description = dr["Description"].ToString();
                        vehicle.IsDeleted = (bool)dr["IsDeleted"];
                    }
                }
            }

            return vehicle;
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("UpdateVehicle", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleId", vehicle.VehicleId);
                cmd.Parameters.AddWithValue("@MakeId", vehicle.MakeId);
                cmd.Parameters.AddWithValue("@ModelId", vehicle.ModelId);
                cmd.Parameters.AddWithValue("@TypeId", vehicle.TypeId);
                cmd.Parameters.AddWithValue("@BodyStyleId", vehicle.BodyStyleId);
                cmd.Parameters.AddWithValue("@TransId", vehicle.TransId);
                cmd.Parameters.AddWithValue("@ColorIntId", vehicle.ColorIntId);
                cmd.Parameters.AddWithValue("@ColorExId", vehicle.ColorExId);
                cmd.Parameters.AddWithValue("@VIN", vehicle.VIN);
                cmd.Parameters.AddWithValue("@Year", vehicle.Year);
                cmd.Parameters.AddWithValue("@SalePrice", vehicle.SalePrice);
                cmd.Parameters.AddWithValue("@MSRP", vehicle.MSRP);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@Description", vehicle.Description);
                cmd.Parameters.AddWithValue("@Picture", vehicle.Picture);
                cmd.Parameters.AddWithValue("@Featured", vehicle.Featured);
                cmd.Parameters.AddWithValue("@IsDeleted", vehicle.IsDeleted);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
