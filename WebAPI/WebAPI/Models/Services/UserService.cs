using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Models.Database;
using WebAPI.Models.DTO;
using WebAPI.Models.Entities;
using WebAPI.Models.Enums;

namespace WebAPI.Models.Services
{
    public class UserService
    {
        private DBContextWebAPI context = new DBContextWebAPI();

        public List<User> Get()
        {
            return context.Users.ToList();
        }

        public User Get(decimal id)
        {
            return context.Users.Find(id);
        }

        public User Get(string username, string password)
        {
            return context.Users.Where(x => x.UserName == username && x.Password == password).FirstOrDefault();
        }

        internal int Post(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return user.Id;
        }

        internal int Delete(int id)
        {
            User user = new User { Id = id };
            context.Users.Attach(user);
            context.Users.Remove(user);
            return context.SaveChanges();
        }

        internal int Put(UserDTO user)
        {
            User upd = context.Users.First(x => x.Id == user.Id.Value);
            int row = 0;

            if(upd != null)
            {
                upd.Birthdate = Convert.ToDateTime(user.Birthdate);
                upd.Cpf = user.Cpf;
                upd.Name = user.Name;
                upd.UserName = user.UserName;
                upd.UserProfile = (Profile)user.UserProfile;

                if (!string.IsNullOrEmpty(user.Password))
                    upd.Password = user.Password;

                row = context.SaveChanges();
            }

            return row;
        }
    }
}