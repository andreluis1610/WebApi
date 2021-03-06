﻿using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using WebAPI.Models.DTO;
using WebAPI.Models.Entities;
using WebAPI.Models.Services;

namespace WebAPI.Models.Business
{
    public class CategoryBusiness
    {
        internal ResultAction Get(int id)
        {
            Category x = new CategoryService().Get(id);

            ResultAction result = new ResultAction();

            if (x != null)
            {
                result.Result = new CategoryDTO
                {
                    Id = x.Id,
                    Description = x.Description,
                    Name = x.Name
                };
                result.IsOk = true;
            }
            else
            {
                result.Message = "Categoria não encontrada.";
            }

            return result;
        }

        internal ResultAction Get()
        {
            List<Category> categories = new CategoryService().Get();
            ResultAction result = new ResultAction();

            if (categories.Any())
            {
                result.IsOk = true;
                result.Result = categories
                                .Select(x => new CategoryDTO
                                {
                                    Id = x.Id,
                                    Description = x.Description,
                                    Name = x.Name
                                })
                                .ToList();
            }
            else
            {
                result.Message = "Nenhuma categoria encontrado.";
            }

            return result;
        }

        internal ResultAction Post(CategoryDTO category)
        {
            ResultAction result = new ResultAction();

            using (var scope = new TransactionScope())
            {
                Category newCategory = new Category();
                newCategory.Description = category.Description;
                newCategory.Name = category.Name;

                int row = new CategoryService().Post(newCategory);

                if (row > 0)
                {
                    result.IsOk = true;
                    result.Result = row;
                    result.Message = "Categoria salva com sucesso.";
                }
                else
                {
                    result.Message = "Erro ao criar uma nova categoria.";
                }

                scope.Complete();
                scope.Dispose();
            }

            return result;
        }
        public ResultAction Put(CategoryDTO category)
        {
            ResultAction result = new ResultAction();

            using (var scope = new TransactionScope())
            {
                int row = 0;
                if (category.Id != null)
                {
                    row = new CategoryService().Put(category);

                    if (row > 0)
                    {
                        result.IsOk = true;
                        result.Result = row;
                    }
                    else
                    {
                        result.Message = "Erro ao atualizar a categoria.";
                    }
                }
                else
                {
                    result.Message = "Categoria não encontrada.";
                }

                scope.Complete();
                scope.Dispose();
            }

            return result;
        }

        internal ResultAction Delete(int id)
        {
            ResultAction result = new ResultAction();

            using (var scope = new TransactionScope())
            {
                int row = new CategoryService().Delete(id);                

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

                scope.Complete();
                scope.Dispose();
            }

            return result;
        }
    }
}