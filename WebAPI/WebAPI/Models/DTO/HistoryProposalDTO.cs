using System;

namespace WebAPI.Models.DTO
{
    public class HistoryProposalDTO
    {
        public int Id { get; set; }
        public int? IdUser { get; set; }
        public string UserName { get; set; }
        public int IdProposal { get; set; }
        public string ActionDescription { get; set; }
        public int Action { get; set; }
        public DateTime ActionDate { get; set; }
    }
}