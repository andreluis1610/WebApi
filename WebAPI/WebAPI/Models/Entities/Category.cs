using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models.Entities
{
    [Table("Categories")]
    public class Category : EntityModelBase
    {
        public string Description { get; set; }
    }
}