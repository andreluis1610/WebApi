using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                    Date = x.Date.ToString("dd/MM/yyyy"),
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

        internal ResultAction Get()
        {
            List<ProposalDTO> proposals = new ProposalService().Get();
            ResultAction result = new ResultAction();

            if (proposals.Any())
            {
                result.IsOk = true;
                result.Result = proposals;
            }
            else
            {
                result.Message = "Nenhuma proposta encontrada.";
            }

            return result;
        }

        internal ResultAction Post(ProposalDTO proposal)
        {
            Proposal newProposal = new Proposal();
            newProposal.Date = Convert.ToDateTime(proposal.Date);
            newProposal.Description = proposal.Description;
            newProposal.IdCategory = proposal.IdCategory;
            newProposal.IdSupplier = proposal.IdSupplier;
            newProposal.Name = proposal.Name;
            newProposal.NameFile = proposal.NameFile;
            newProposal.Status = Status.Registred;
            newProposal.StatusNow = StatusNow.Registred;
            newProposal.Value = proposal.Value;

            int row = new ProposalService().Post(newProposal);

            ResultAction result = new ResultAction();

            if (row > 0)
            {
                result.IsOk = true;
                result.Result = row;
                result.Message = "Proposta salva com sucesso.";
            }
            else
            {
                result.Message = "Erro ao criar uma nova proposta.";
            }

            return result;
        }
        public ResultAction Put(ProposalDTO proposal)
        {
            ResultAction result = new ResultAction();
            int row = 0;
            if (proposal.Id != null)
            {
                row = new ProposalService().Put(proposal);

                if (row > 0)
                {
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

            return result;
        }

        internal ResultAction Delete(int id)
        {
            int row = new ProposalService().Delete(id);
            ResultAction result = new ResultAction();

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

            return result;
        }

        internal string GetExpirationDate(DateTime dtCreate)
        {
            var ret = string.Empty;

            ConfigurationBusiness config = new ConfigurationBusiness();
            ResultAction result = config.Get();
            ConfigurationDTO dto = null;

            if (result.IsOk)
            {
                dto = (ConfigurationDTO)result.Result;
                if((TimeConfig)dto.TimeConfig == TimeConfig.Day)
                {
                    int days = (DateTime.Now.Subtract(dtCreate)).Days;
                    ret = string.Format("Expira em {0} dia(s).", days);
                }
                else
                {
                    int hours = (DateTime.Now.Subtract(dtCreate)).Hours;
                    ret = string.Format("Expira em {0} horas(s).", hours);
                }
            }

            return ret;
        }
    }
}