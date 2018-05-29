using System.Collections.Generic;
using System.Linq;
using WebAPI.Models.Database;
using WebAPI.Models.DTO;
using WebAPI.Models.Entities;

namespace WebAPI.Models.Services
{
    public class HistoryProposalService
    {
        private DBContextWebAPI context = new DBContextWebAPI();

        public List<HistoryProposalDTO> Get(int idProposal)
        {
            var list = context.Historic
                        .Where(x => x.IdProposal == idProposal)
                        .GroupJoin(
                            context.Users,
                            historic => historic.IdUser,
                            users => users.Id,
                            (historic, users) => new { historic, users })
                        .AsEnumerable()
                        .Select(item => new HistoryProposalDTO {
                            Action = (int)item.historic.Action,
                            ActionDate = item.historic.ActionDate,
                            ActionDescription = EnumDescription.GetDescription(item.historic.Action),
                            Id = item.historic.Id,
                            IdProposal = item.historic.IdProposal,
                            IdUser = item.historic.IdUser,
                            UserName = item.users.Where(x => x.Id == item.historic.IdUser).FirstOrDefault() == null ? "Sistema" : item.users.Where(x => x.Id == item.historic.IdUser).FirstOrDefault().Name
                        })
                        .ToList();

            return list;
        }

        internal int Post(HistoryProposal historic)
        {
            context.Historic.Add(historic);
            context.SaveChanges();
            return historic.Id;
        }
    }
}