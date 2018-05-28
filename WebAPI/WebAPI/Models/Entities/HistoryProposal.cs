using System;

namespace WebAPI.Models.Entities
{
    public class HistoryProposal
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string Action { get; set; }
        public DateTime DateTime { get; set; }
    }
}