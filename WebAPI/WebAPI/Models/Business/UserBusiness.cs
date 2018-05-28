using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Models.DTO;
using WebAPI.Models.Entities;
using WebAPI.Models.Enums;
using WebAPI.Models.Services;

namespace WebAPI.Models.Business
{
    public class UserBusiness
    {
        internal ResultAction Get(int id)
        {
            User x = new UserService().Get(id);

            ResultAction result = new ResultAction();

            if (x != null)
            {
                result.Result = new UserDTO
                                {
                                    Id = x.Id,
                                    Birthdate = x.Birthdate.ToString("dd/MM/yyyy"),
                                    Cpf = x.Cpf,
                                    Name = x.Name,
                                    UserProfile = (int)x.UserProfile,
                                    UserName = x.UserName
                                };
                result.IsOk = true;
            }
            else
            {
                result.Message = "Usuário não encontrado.";
            }

            return result;
        }

        internal ResultAction Get()
        {
            List<User> users = new UserService().Get();
            ResultAction result = new ResultAction();
            
            if (users.Any())
            {
                result.IsOk = true;
                result.Result = users
                                .Select(x => new UserDTO
                                {
                                    Id = x.Id,
                                    Birthdate = x.Birthdate.ToString("dd/MM/yyyy"),
                                    Name = x.Name,
                                    Cpf = x.Cpf,
                                    Profile = EnumDescription.GetDescription(x.UserProfile),
                                    UserName = x.UserName
                                })
                                .ToList();
            }
            else
            {
                result.Message = "Nenhum usuário encontrado.";
            }

            return result;
        }

        internal ResultAction Get(string username, string password)
        {
            User x = new UserService().Get(username, password);
            ResultAction result = new ResultAction();

            if (x != null)
            {
                result.IsOk = true;
                result.Result = new UserDTO
                                {
                                    Id = x.Id,
                                    Birthdate = x.Birthdate.ToString("dd/MM/yyyy"),
                                    Name = x.Name,
                                    UserProfile = (int)x.UserProfile,
                                    UserName = x.UserName
                                };
            }
            else {
                result.Message = "Usuário ou senha inválidos.";
            }

            return result;
        }

        internal ResultAction Post(UserDTO user)
        {
            User newUser = new User();
            newUser.Birthdate = Convert.ToDateTime(user.Birthdate);
            newUser.Cpf = user.Cpf;
            newUser.Name = user.Name;
            newUser.Password = user.Password;
            newUser.UserName = user.UserName;
            newUser.UserProfile = (Profile)user.UserProfile;

            int row = new UserService().Post(newUser);

            ResultAction result = new ResultAction();

            if(row > 0)
            {
                result.IsOk = true;
                result.Result = row;
                result.Message = "Usuário salvo com sucesso.";
            }
            else
            {
                result.Message = "Erro ao criar um novo usuário.";
            }

            return result;
        }
        public ResultAction Put(UserDTO user)
        {
            ResultAction result = new ResultAction();
            int row = 0;
            if (user.Id != null)
            {
                row = new UserService().Put(user);

                if(row > 0)
                {
                    result.IsOk = true;
                    result.Result = row;
                }
                else
                {
                    result.Message = "Erro ao atualizar o usuário.";
                }
            }
            else
            {
                result.Message = "Usuário não encontrado.";
            }

            return result;
        }

        internal ResultAction Delete(int id)
        {
            int row = new UserService().Delete(id);
            ResultAction result = new ResultAction();

            if (row > 0)
            {
                result.IsOk = true;
                result.Result = row;
                result.Message = string.Empty;
            }
            else
            {
                result.Message = "Erro ao excluir o usuário.";
            }

            return result;
        }
    }
}