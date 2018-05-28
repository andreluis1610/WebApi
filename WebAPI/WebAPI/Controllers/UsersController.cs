using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Models.Business;
using WebAPI.Models.DTO;
using WebAPI.Models.Entities;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:52597", headers: "*", methods: "*")]
    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        [HttpGet]
        [Route("")]
        public ResultAction Get()
        {
            return new UserBusiness().Get();
        }

        [HttpGet]
        [Route("{username}/{password}")]
        public ResultAction Get(string username, string password)
        {
            return new UserBusiness().Get(username, password);
        }

        [HttpGet]
        [Route("{id}")]
        public ResultAction Get(int id)
        {
            return new UserBusiness().Get(id);
        }

        [HttpPost]
        [Route("Post")]
        public ResultAction Post([FromBody]UserDTO user)
        {
            return new UserBusiness().Post(user);
        }

        [HttpPut]
        [Route("Put")]
        public ResultAction Put([FromBody]UserDTO user)
        {
            return new UserBusiness().Put(user);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public ResultAction Delete(int id)
        {
            return new UserBusiness().Delete(id);
        }
    }
}
