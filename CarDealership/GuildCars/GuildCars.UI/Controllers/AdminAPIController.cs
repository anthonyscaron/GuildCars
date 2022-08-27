using GuildCars.Data.Factory;
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
    public class AdminAPIController : ApiController
    {
        [Route("admin/addvehicle/getmodels")]
        [Route("admin/editvehicle/getmodels")]
        [AcceptVerbs("GET")]
        [Authorize(Roles = "admin")]
        public IHttpActionResult GetModels(string makeName)
        {
            var repo = ModelRepositoryFactory.GetRepository();

            try
            {
                var result = repo.GetByMakeName(makeName);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("admin/editvehicle/delete")]
        [AcceptVerbs("DELETE")]
        [Authorize(Roles = "admin")]
        public IHttpActionResult DeleteVehicle(int vehicleId)
        {
            var repo = VehicleRepositoryFactory.GetRepository();
            var vehicle = repo.GetVehicleById(vehicleId);

            try
            {
                repo.DeleteVehicle(vehicle);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("admin/specials/delete")]
        [AcceptVerbs("DELETE")]
        [Authorize(Roles = "admin")]
        public IHttpActionResult DeleteSpecial(int specialId)
        {
            var repo = SpecialRepositoryFactory.GetRepository();

            try
            {
                repo.DeleteSpecial(specialId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
