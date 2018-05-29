using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using WebAPI.Models.DTO;
using WebAPI.Models.Entities;
using WebAPI.Models.Services;

namespace WebAPI.Models.Business
{
    public class ConfigurationBusiness
    {
        internal ResultAction Get()
        {
            List<Configuration> configurations = new ConfigurationService().Get();
            ResultAction result = new ResultAction();

            if (configurations.Any())
            {
                result.IsOk = true;
                result.Result = configurations
                                .Select(x => new ConfigurationDTO
                                {
                                    Id = x.Id,
                                    TimeConfig = (int)x.TimeConfig,
                                    Value = x.Value
                                })
                                .FirstOrDefault();
            }
            else
            {
                result.Message = "Nenhuma configuração encontrado.";
            }

            return result;
        }
        
        public ResultAction Put(ConfigurationDTO configuration)
        {
            ResultAction result = new ResultAction();

            using (var scope = new TransactionScope())
            {
                if (configuration.Id != null)
                {
                    result.IsOk = true;
                    result.Result = new ConfigurationService().Put(configuration); ;
                }
                else
                {
                    result.Message = "Erro ao atualizar a configuração não encontrada.";
                }

                scope.Complete();
                scope.Dispose();
            }

            return result;
        }
    }
}