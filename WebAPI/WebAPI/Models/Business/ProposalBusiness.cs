using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using WebAPI.Models.DTO;
using WebAPI.Models.Entities;
using WebAPI.Models.Enums;
using WebAPI.Models.Services;

namespace WebAPI.Models.Business
{
    public class ProposalBusiness
    {
        internal ResultAction Get(int id)
        {
            Proposal x = new ProposalService().Get(id);

            ResultAction result = new ResultAction();

            if (x != null)
            {
                result.Result = new ProposalDTO
                {
                    CreationDate = x.CreationDate,
                    ExpirationDate = x.ExpirationDate,
                    Description = x.Description,
                    Id = x.Id,
                    IdCategory = x.IdCategory,
                    IdSupplier = x.IdSupplier,
                    Name = x.Name,
                    NameFile = x.NameFile,
                    Status = (int)x.Status,
                    StatusNow = (int)x.StatusNow,
                    Value = x.Value
                };
                result.IsOk = true;
            }
            else
            {
                result.Message = "Proposta não encontrada.";
            }

            return result;
        }

        internal ResultAction GetByUser(int idUser)
        {
            ResultAction result = new ResultAction();

            User user = new UserService().Get(idUser);
            if (user != null)
            {
                List<ProposalDTO> proposals = new ProposalService().Get();
                if (proposals.Any())
                {
                    proposals = proposals.Where(x => !x.Expireded).ToList();

                    if (proposals.Any())
                    {
                        result.IsOk = true;

                        if (user.UserProfile == Profile.FinancialAnalyst)
                        {
                            result.Result = proposals.Where(prop => (Status)prop.Status.Value == Status.Registred).ToList();
                        }
                        else if (user.UserProfile == Profile.CFO)
                        {
                            result.Result = proposals.Where(prop => (Status)prop.Status.Value == Status.Registred || (Status)prop.Status.Value == Status.PendingDirectors).ToList();
                        }
                    }
                    else
                    {
                        result.Message = "Nenhuma proposta para aprovação.";
                    }
                }
                else
                {
                    result.Message = "Nenhuma proposta cadastrada.";
                }
            }
            else
            {
                result.Message = "Usuário não encontrado.";
            }

            return result;
        }

        internal ResultAction Get()
        {
            List<ProposalDTO> proposals = new ProposalService().Get();

            if (proposals.Any(x => x.Expireded && (Status)x.Status != Status.Approved && (Status)x.Status != Status.Disapproved))
            {
                using (var scope = new TransactionScope())
                {
                    UpdateStatusExpired(proposals);

                    scope.Complete();
                    scope.Dispose();
                }
            }

            ResultAction result = new ResultAction();

            if (proposals.Any())
            {
                result.IsOk = true;
                result.Result = proposals.OrderBy(x => x.ExpirationDate).ToList();
            }
            else
            {
                result.Message = "Nenhuma proposta encontrada.";
            }

            return result;
        }

        internal ResultAction Post(ProposalDTO proposal)
        {
            ResultAction result = new ResultAction();

            using (var scope = new TransactionScope())
            {
                Proposal newProposal = new Proposal();
                newProposal.ExpirationDate = GetExpirationDate(newProposal.CreationDate);
                newProposal.Description = proposal.Description;
                newProposal.IdCategory = proposal.IdCategory;
                newProposal.IdSupplier = proposal.IdSupplier;
                newProposal.Name = proposal.Name;
                newProposal.NameFile = proposal.NameFile;
                newProposal.Status = Status.Registred;
                newProposal.StatusNow = StatusNow.Registred;
                newProposal.Value = proposal.Value;

                int id = new ProposalService().Post(newProposal);

                if (id > 0)
                {
                    CreateHistory(proposal.IdUser.Value, id, ActionHistoric.Registred);

                    result.IsOk = true;
                    result.Result = id;
                    result.Message = "Proposta salva com sucesso.";
                }
                else
                {
                    result.Message = "Erro ao criar uma nova proposta.";
                }

                scope.Complete();
                scope.Dispose();
            }

            return result;
        }

        public ResultAction Put(ProposalDTO proposal)
        {
            ResultAction result = new ResultAction();
            int row = 0;

            using (var scope = new TransactionScope())
            {
                if (proposal.Id != null)
                {
                    row = new ProposalService().Put(proposal);

                    if (row > 0)
                    {
                        CreateHistory(proposal.IdUser.Value, proposal.Id.Value, ActionHistoric.Edited);
                        result.IsOk = true;
                        result.Result = row;
                    }
                    else
                    {
                        result.Message = "Erro ao atualizar a proposta.";
                    }
                }
                else
                {
                    result.Message = "Proposta não encontrada.";
                }

                scope.Complete();
                scope.Dispose();
            }

            return result;
        }

        internal ResultAction Put(int idUser, int idProposal, int status)
        {
            ResultAction result = new ResultAction();

            using (var scope = new TransactionScope())
            {
                Proposal prop = new ProposalService().Get(idProposal);
                User user = new UserService().Get(idUser);
                Status operationUser = (Status)status;
                ActionHistoric? action = null;

                if (user.UserProfile == Profile.FinancialAnalyst)
                {
                    if (prop.StatusNow == StatusNow.Registred)
                    {
                        if (operationUser == Status.Disapproved)
                        {
                            prop.StatusNow = StatusNow.DisapprovedByFinancialAnalyst;
                            prop.Status = Status.Disapproved;
                            action = ActionHistoric.DisapprovedByFinancialAnalyst;
                        }
                        else
                        {
                            prop.StatusNow = StatusNow.ApprovedByFinancialAnalyst;
                            action = ActionHistoric.ApprovedByFinancialAnalyst;

                            if (prop.Value <= 10000)
                            {
                                prop.Status = Status.Approved;
                            }
                            else
                            {
                                prop.Status = Status.PendingDirectors;
                            }
                        }
                    }
                }
                else if (user.UserProfile == Profile.CFO)
                {
                    if (prop.StatusNow == StatusNow.Registred || prop.Status == Status.PendingDirectors)
                    {
                        prop.Status = operationUser;

                        if (operationUser == Status.Disapproved)
                        {
                            prop.StatusNow = StatusNow.DisapprovedByCFO;
                            action = ActionHistoric.DisapprovedByCFO;
                        }
                        else
                        {
                            prop.StatusNow = StatusNow.ApprovedByCFO;
                            action = ActionHistoric.ApprovedByCFO;
                        }
                    }
                }

                int row = PutStatus(idUser, idProposal, prop.Status, prop.StatusNow, action.Value);

                if (row > 0)
                {
                    result.IsOk = true;
                    result.Result = row;
                    result.Message = "Status alterado.";
                }
                else
                {
                    result.Message = "Erro ao alterar status.";
                }

                scope.Complete();
                scope.Dispose();
            }

            return result;
        }

        internal int PutStatus(int? idUser, int idProposal, Status status, StatusNow statusNow, ActionHistoric action)
        {
            int row = new ProposalService().PutStatus(idProposal, status, statusNow);

            if(row > 0)
            {
                CreateHistory(idUser, idProposal, action);
            }

            return row;
        }

        internal ResultAction Delete(int id)
        {
            ResultAction result = new ResultAction();

            using (var scope = new TransactionScope())
            {
                int row = new ProposalService().Delete(id);

                if (row > 0)
                {
                    result.IsOk = true;
                    result.Result = row;
                    result.Message = string.Empty;
                }
                else
                {
                    result.Message = "Erro ao excluir a proposta.";
                }

                scope.Complete();
                scope.Dispose();
            }

            return result;
        }

        internal DateTime GetExpirationDate(DateTime creationDate)
        {
            DateTime expirationDate = new DateTime();
            ResultAction result = new ConfigurationBusiness().Get();

            if(result != null)
            {
                if (result.IsOk)
                {
                    ConfigurationDTO config = (ConfigurationDTO)result.Result;
                    if ((TimeConfig)config.TimeConfig == TimeConfig.Day)
                    {
                        expirationDate = creationDate.AddDays(config.Value);
                    }
                    else
                    {
                        expirationDate = creationDate.AddHours(config.Value);
                    }
                }
            }

            return expirationDate;
        }
        private void UpdateStatusExpired(List<ProposalDTO> proposals)
        {
            proposals.Where(x => x.Expireded)
                .ToList()
                .ForEach(prop =>
                {
                    prop.Status = (int)Status.Disapproved;
                    PutStatus(null, prop.Id.Value, Status.Disapproved, (StatusNow)prop.StatusNow, ActionHistoric.Expired);
                });
        }


        private bool CreateHistory(int? idUser, int id, ActionHistoric action)
        {
            HistoryProposalDTO historic = new HistoryProposalDTO
            {
                IdProposal = id,
                IdUser = idUser,
                Action = (int)action
            };

            HistoryProposalBusiness business = new HistoryProposalBusiness();
            ResultAction result = business.Post(historic);

            return (int)result.Result > 0;
        }
    }
}