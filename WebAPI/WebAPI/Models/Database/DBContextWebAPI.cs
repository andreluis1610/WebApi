using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using WebAPI.Models.Entities;

namespace WebAPI.Models.Database
{
    public class DBContextWebAPI : DbContext
    {
        public DBContextWebAPI() : base("DBContextWebAPI")
        {

        }

        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Proposal> Proposals { get; set; }
    }
}