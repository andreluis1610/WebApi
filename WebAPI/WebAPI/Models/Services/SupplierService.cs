using System.Collections.Generic;
using System.Linq;
using WebAPI.Models.Database;
using WebAPI.Models.DTO;
using WebAPI.Models.Entities;

namespace WebAPI.Models.Services
{
    public class SupplierService
    {
        private DBContextWebAPI context = new DBContextWebAPI();

        public List<Supplier> Get()
        {
            return context.Suppliers.ToList();
        }

        public Supplier Get(decimal id)
        {
            return context.Suppliers.Find(id);
        }

        internal int Post(Supplier supplier)
        {
            context.Suppliers.Add(supplier);
            context.SaveChanges();
            return supplier.Id;
        }

        internal int Delete(int id)
        {
            Supplier supplier = new Supplier { Id = id };
            context.Suppliers.Attach(supplier);
            context.Suppliers.Remove(supplier);
            return context.SaveChanges();
        }

        internal int Put(SupplierDTO supplier)
        {
            Supplier upd = context.Suppliers.First(x => x.Id == supplier.Id.Value);
            int row = 0;

            if (upd != null)
            {
                upd.CpfCnpj = supplier.CpfCnpj;
                upd.Email = supplier.Email;
                upd.Name = supplier.Name;
                upd.PhoneNumber = supplier.PhoneNumber;

                row = context.SaveChanges();
            }

            return row;
        }
    }
}