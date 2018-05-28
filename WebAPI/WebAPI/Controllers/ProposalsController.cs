using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Models.Business;
using WebAPI.Models.DTO;
using WebAPI.Models.Entities;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:52597", headers: "*", methods: "*")]
    [RoutePrefix("api/Proposals")]
    public class ProposalsController : ApiController
    {
        [HttpGet]
        [Route("")]
        public ResultAction Get()
        {
            return new ProposalBusiness().Get();
        }

        [HttpGet]
        [Route("DeadLine")]
        public ResultAction Get(string date)
        {
            return new ProposalBusiness().Get();
        }

        [HttpGet]
        [Route("{id}")]
        public ResultAction Get(int id)
        {
            return new ProposalBusiness().Get(id);
        }

        [HttpPost]
        [Route("Post")]
        public ResultAction Post([FromBody]ProposalDTO proposal)
        {
            return new ProposalBusiness().Post(proposal);
        }

        [HttpPut]
        [Route("Put")]
        public ResultAction Put([FromBody]ProposalDTO proposal)
        {
            return new ProposalBusiness().Put(proposal);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public ResultAction Delete(int id)
        {
            return new ProposalBusiness().Delete(id);
        }
    }
}
