using System.Collections.Generic;
using System.Linq;
using System.Transactions;
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
            ResultAction result = new ResultAction();

            using (var scope = new TransactionScope())
            {
                HistoryProposal newHistoric = new HistoryProposal();
                newHistoric.IdUser = historic.IdUser;
                newHistoric.IdProposal = historic.IdProposal;
                newHistoric.Action = (ActionHistoric)historic.Action;

                int id = new HistoryProposalService().Post(newHistoric);

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

                scope.Complete();
                scope.Dispose();
            }

            return result;
        }
        
    }
}