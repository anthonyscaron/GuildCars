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
    public class ReportsAPIController : ApiController
    {
        [Route("reports/sales/search")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Search(string searchString, string fromYear, string toYear)
        {
            var repo = SaleRepositoryFactory.GetRepository();

            try
            {
                var parameters = new SearchSalesParameters();

                parameters.SearchString = searchString;
                parameters.FromYear = fromYear;
                parameters.ToYear = toYear;

                var result = repo.Search(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
