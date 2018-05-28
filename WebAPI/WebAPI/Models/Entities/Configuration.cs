using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Models.Enums;

namespace WebAPI.Models.Entities
{
    [Table("Configurations")]
    public class Configuration
    {
        public int Id { get; set; }
        public TimeConfig TimeConfig { get; set; }
        public int Value { get; set; }
    }
}