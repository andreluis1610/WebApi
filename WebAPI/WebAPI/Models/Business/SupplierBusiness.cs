using System.Collections.Generic;
using System.Linq;
using WebAPI.Models.DTO;
using WebAPI.Models.Entities;
using WebAPI.Models.Services;

namespace WebAPI.Models.Business
{
    public class SupplierBusiness
    {
        internal ResultAction Get(int id)
        {
            Supplier x = new SupplierService().Get(id);

            ResultAction result = new ResultAction();

            if (x != null)
            {
                result.Result = new SupplierDTO
                {
                    Id = x.Id,
                    CpfCnpj = x.CpfCnpj,
                    Email = x.Email,
                    Name = x.Name,
                    PhoneNumber = x.PhoneNumber
                };

                result.IsOk = true;
            }
            else
            {
                result.Message = "Fornecedor não encontrado.";
            }

            return result;
        }

        internal ResultAction Get()
        {
            List<Supplier> suppliers = new SupplierService().Get();
            ResultAction result = new ResultAction();

            if (suppliers.Any())
            {
                result.IsOk = true;
                result.Result = suppliers
                                .Select(x => new SupplierDTO
                                {
                                    Id = x.Id,
                                    CpfCnpj = x.CpfCnpj,
                                    Email = x.Email,
                                    Name = x.Name,
                                    PhoneNumber = x.PhoneNumber
                                })
                                .ToList();
            }
            else
            {
                result.Message = "Nenhum fornecedor encontrado.";
            }

            return result;
        }

        internal ResultAction Post(SupplierDTO supplier)
        {
            Supplier newSupplier = new Supplier();
            newSupplier.CpfCnpj = supplier.CpfCnpj;
            newSupplier.Email = supplier.Email;
            newSupplier.Name = supplier.Name;
            newSupplier.PhoneNumber = supplier.PhoneNumber;

            int row = new SupplierService().Post(newSupplier);

            ResultAction result = new ResultAction();

            if (row > 0)
            {
                result.IsOk = true;
                result.Result = row;
                result.Message = "Fornecedor salvo com sucesso.";
            }
            else
            {
                result.Message = "Erro ao cadastrar um novo fornecedor.";
            }

            return result;
        }
        public ResultAction Put(SupplierDTO supplier)
        {
            ResultAction result = new ResultAction();
            int row = 0;
            if (supplier.Id != null)
            {
                row = new SupplierService().Put(supplier);

                if (row > 0)
                {
                    result.IsOk = true;
                    result.Result = row;
                }
                else
                {
                    result.Message = "Erro ao atualizar o fornecedor.";
                }
            }
            else
            {
                result.Message = "Fornecedor não encontrado.";
            }

            return result;
        }

        internal ResultAction Delete(int id)
        {
            int row = new SupplierService().Delete(id);
            ResultAction result = new ResultAction();

            if (row > 0)
            {
                result.IsOk = true;
                result.Result = row;
                result.Message = string.Empty;
            }
            else
            {
                result.Message = "Erro ao excluir a categoria.";
            }

            return result;
        }
    }
}