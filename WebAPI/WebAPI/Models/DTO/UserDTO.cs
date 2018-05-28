namespace WebAPI.Models.DTO
{
    public class UserDTO
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string Cpf { get; set; }

        public string UserName { get; set; }

        public string Birthdate { get; set; }

        public int UserProfile { get; set; }

        public string Profile { get; set; }
    }
}