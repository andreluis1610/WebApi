using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Models.Business;
using WebAPI.Models.DTO;
using WebAPI.Models.Entities;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:52597", headers: "*", methods: "*")]
    [RoutePrefix("api/Suppliers")]
    public class SuppliersController : ApiController
    {
        [HttpGet]
        [Route("")]
        public ResultAction Get()
        {
            return new SupplierBusiness().Get();
        }

        [HttpGet]
        [Route("{id}")]
        public ResultAction Get(int id)
        {
            return new SupplierBusiness().Get(id);
        }

        [HttpPost]
        [Route("Post")]
        public ResultAction Post([FromBody]SupplierDTO supplier)
        {
            return new SupplierBusiness().Post(supplier);
        }

        [HttpPut]
        [Route("Put")]
        public ResultAction Put([FromBody]SupplierDTO supplier)
        {
            return new SupplierBusiness().Put(supplier);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public ResultAction Delete(int id)
        {
            return new SupplierBusiness().Delete(id);
        }
    }
}
