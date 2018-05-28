using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Models.Enums;

namespace WebAPI.Models.Entities
{
    [Table("Users")]
    public class User : EntityModelBase
    {
        public string UserName { get; set; }

        public DateTime Birthdate { get; set; }

        public string Cpf { get; set; }

        public string Password { get; set; }

        public Profile UserProfile { get; set; }
    }
}