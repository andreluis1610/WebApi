using System.Collections.Generic;
using System.Linq;
using WebAPI.Models.DTO;
using WebAPI.Models.Entities;
using WebAPI.Models.Enums;
using WebAPI.Models.Services;

namespace WebAPI.Models.Business
{
    public class HistoryProposalBusiness
    {
        internal ResultAction Get(int idProposal)
        {
            List<HistoryProposalDTO> historic = new HistoryProposalService().Get(idProposal);
            ResultAction result = new ResultAction();

            if (historic.Any())
            {
                result.IsOk = true;
                result.Result = historic;
            }
            else
            {
                result.Message = "Nenhum histórico encontrado.";
            }

            return result;
        }

        internal ResultAction Post(HistoryProposalDTO historic)
        {
            HistoryProposal newHistoric = new HistoryProposal();
            newHistoric.IdUser = historic.IdUser;
            newHistoric.IdProposal = historic.IdProposal;
            newHistoric.Action = (ActionHistoric)historic.Action;

            int id = new HistoryProposalService().Post(newHistoric);

            ResultAction result = new ResultAction();

            if (id > 0)
            {
                result.IsOk = true;
                result.Result = id;
                result.Message = "Ação do usuário salvo com sucesso.";
            }
            else
            {
                result.Message = "Erro ao salvar a ação do usuário.";
            }

            return result;
        }
        
    }
}