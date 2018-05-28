using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models.Entities
{
    [Table("Suppliers")]
    public class Supplier : EntityModelBase
    {
        public string CpfCnpj { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}