namespace WebAPI.Models.DTO
{
    public class ProposalDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string ExpiresIn { get; set; }
        public decimal Value { get; set; }
        public int? Status { get; set; }
        public string StatusDescription { get; set; }
        public int? StatusNow { get; set; }
        public string StatusNowDescription { get; set; }
        public string NameFile { get; set; }
        public int IdCategory { get; set; }
        public string CategoryName { get; set; }
        public int IdSupplier { get; set; }
        public string SupplierName { get; set; }
    }
}