using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Models.Business;
using WebAPI.Models.Entities;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:52597", headers: "*", methods: "*")]
    [RoutePrefix("api/HistoryProposals")]
    public class HistoryProposalsController : ApiController
    {
        [HttpGet]
        [Route("{idProposal}")]
        public ResultAction Get(int idProposal)
        {
            return new HistoryProposalBusiness().Get(idProposal);
        }
    }
}
