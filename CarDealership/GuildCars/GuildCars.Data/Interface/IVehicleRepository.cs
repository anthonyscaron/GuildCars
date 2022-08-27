using GuildCars.Models.Query;
using GuildCars.Models.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interface
{
    public interface IVehicleRepository
    {
        List<Vehicle> GetAll();
        List<Vehicle> GetAllAvailable();
        List<Vehicle> GetAllSold();
        List<FeaturedVehicleRequestItem> GetAllFeatured();
        List<SearchVehicleRequestItem> GetAllUsed();
        List<SearchVehicleRequestItem> GetAllNew();
        List<SearchVehicleRequestItem> GetAllToSell();
        List<SearchVehicleRequestItem> SearchUsed(SearchVehicleParameters parameters);
        List<SearchVehicleRequestItem> SearchNew(SearchVehicleParameters parameters);
        List<SearchVehicleRequestItem> SearchAllAvailableToSell(SearchVehicleParameters parameters);
        Vehicle GetVehicleById(int vehicleId);
        SearchVehicleRequestItem SearchVehicleById(int vehicleId);
        AddEditVehicleRequestItem AdminGetVehicleById(int vehicleId);
        List<AddEditVehicleRequestItem> AdminGetAll();
        List<InventoryReportRequestItem> AdminGetNewInventoryReport();
        List<InventoryReportRequestItem> AdminGetUsedInventoryReport();
        void CreateVehicle(Vehicle vehicle);
        void UpdateVehicle(Vehicle vehicle);
        void DeleteVehicle(Vehicle vehicle);
    }
}
