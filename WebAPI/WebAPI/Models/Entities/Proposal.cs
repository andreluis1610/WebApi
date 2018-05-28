using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Models.Enums;

namespace WebAPI.Models.Entities
{
    [Table("Proposals")]
    public class Proposal : EntityModelBase
    {
        public int IdCategory { get; set; }
        public int IdSupplier { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public StatusNow StatusNow { get; set; }
        public string NameFile { get; set; }
    }
}