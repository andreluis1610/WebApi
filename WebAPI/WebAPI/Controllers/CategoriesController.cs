using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Models.Business;
using WebAPI.Models.DTO;
using WebAPI.Models.Entities;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:52597", headers: "*", methods: "*")]
    [RoutePrefix("api/Categories")]
    public class CategoriesController : ApiController
    {
        [HttpGet]
        [Route("")]
        public ResultAction Get()
        {
            return new CategoryBusiness().Get();
        }


        [HttpGet]
        [Route("{id}")]
        public ResultAction Get(int id)
        {
            return new CategoryBusiness().Get(id);
        }

        [HttpPost]
        [Route("Post")]
        public ResultAction Post([FromBody]CategoryDTO category)
        {
            return new CategoryBusiness().Post(category);
        }

        [HttpPut]
        [Route("Put")]
        public ResultAction Put([FromBody]CategoryDTO category)
        {
            return new CategoryBusiness().Put(category);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public ResultAction Delete(int id)
        {
            return new CategoryBusiness().Delete(id);
        }
    }
}