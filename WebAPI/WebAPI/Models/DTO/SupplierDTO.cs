using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.DTO
{
    public class SupplierDTO
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string CpfCnpj { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}