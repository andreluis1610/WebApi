using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Models.Enums;

namespace WebAPI.Models.Entities
{
    [Table("HistoryProposals")]
    public class HistoryProposal
    {
        public int Id { get; set; }
        public int? IdUser { get; set; }
        public int IdProposal { get; set; }
        public ActionHistoric Action { get; set; }
        public DateTime ActionDate { get; set; }

        public HistoryProposal()
        {
            ActionDate = DateTime.Now;
        }
    }
}