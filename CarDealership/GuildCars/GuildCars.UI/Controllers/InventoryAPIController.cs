using GuildCars.Data.Factory;
using GuildCars.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GuildCars.UI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class InventoryAPIController : ApiController
    {
        [Route("inventory/new/search")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchNew(string searchString, decimal? minPrice, decimal? maxPrice, string minYear, string maxYear)
        {
            var repo = VehicleRepositoryFactory.GetRepository();

            try
            {
                var parameters = new SearchVehicleParameters();

                parameters.SearchString = searchString;
                parameters.MinPrice = minPrice;
                parameters.MaxPrice = maxPrice;
                parameters.MinYear = minYear;
                parameters.MaxYear = maxYear;

                var result = repo.SearchNew(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("inventory/used/search")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchUsed(string searchString, decimal? minPrice, decimal? maxPrice, string minYear, string maxYear)
        {
            var repo = VehicleRepositoryFactory.GetRepository();

            try
            {
                var parameters = new SearchVehicleParameters();

                parameters.SearchString = searchString;
                parameters.MinPrice = minPrice;
                parameters.MaxPrice = maxPrice;
                parameters.MinYear = minYear;
                parameters.MaxYear = maxYear;

                var result = repo.SearchUsed(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("sales/index/search")]
        [AcceptVerbs("GET")]
        [Authorize(Roles = "sales")]
        public IHttpActionResult SearchSales(string searchString, decimal? minPrice, decimal? maxPrice, string minYear, string maxYear)
        {
            var repo = VehicleRepositoryFactory.GetRepository();

            try
            {
                var parameters = new SearchVehicleParameters();

                parameters.SearchString = searchString;
                parameters.MinPrice = minPrice;
                parameters.MaxPrice = maxPrice;
                parameters.MinYear = minYear;
                parameters.MaxYear = maxYear;

                var result = repo.SearchAllAvailableToSell(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("admin/vehicles/search")]
        [AcceptVerbs("GET")]
        [Authorize(Roles = "admin")]
        public IHttpActionResult SearchAdmin(string searchString, decimal? minPrice, decimal? maxPrice, string minYear, string maxYear)
        {
            var repo = VehicleRepositoryFactory.GetRepository();

            try
            {
                var parameters = new SearchVehicleParameters();

                parameters.SearchString = searchString;
                parameters.MinPrice = minPrice;
                parameters.MaxPrice = maxPrice;
                parameters.MinYear = minYear;
                parameters.MaxYear = maxYear;

                var result = repo.SearchAllAvailableToSell(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
