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
        [Route("{id}")]
        public ResultAction Get(int id)
        {
            return new ProposalBusiness().Get(id);
        }

        [HttpGet]
        [Route("ByUser/{idUser}")]
        public ResultAction GetByUser(int idUser)
        {
            return new ProposalBusiness().GetByUser(idUser);
        }

        [HttpPost]
        [Route("Post")]
        public ResultAction Post([FromBody]ProposalDTO proposal)
        {
            return new ProposalBusiness().Post(proposal);
        }

        [HttpPut]
        [Route("PutStatus/{idUser}/{idProposal}/{status}")]
        public ResultAction Put(int idUser, int idProposal, int status)
        {
            return new ProposalBusiness().Put(idUser, idProposal, status);
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
