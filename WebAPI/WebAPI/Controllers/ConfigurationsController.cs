using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Models.Business;
using WebAPI.Models.DTO;
using WebAPI.Models.Entities;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:52597", headers: "*", methods: "*")]
    [RoutePrefix("api/Configurations")]
    public class ConfigurationsController : ApiController
    {
        // GET: Configurations
        [HttpGet]
        [Route("")]
        public ResultAction Get()
        {
            return new ConfigurationBusiness().Get();
        }

        [HttpPut]
        [Route("Put")]
        public ResultAction Put([FromBody]ConfigurationDTO configuration)
        {
            return new ConfigurationBusiness().Put(configuration);
        }
    }
}
