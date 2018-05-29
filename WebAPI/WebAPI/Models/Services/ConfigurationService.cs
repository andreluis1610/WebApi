using System.Collections.Generic;
using System.Linq;
using WebAPI.Models.Database;
using WebAPI.Models.DTO;
using WebAPI.Models.Enums;

namespace WebAPI.Models.Services
{
    public class ConfigurationService
    {
        private DBContextWebAPI context = new DBContextWebAPI();

        public List<Entities.Configuration> Get()
        {
            return context.Configurations.ToList();
        }

        public Entities.Configuration Get(decimal id)
        {
            return context.Configurations.Find(id);
        }

        internal int Post(Entities.Configuration configuration)
        {
            context.Configurations.Add(configuration);
            context.SaveChanges();
            return configuration.Id;
        }

        internal int Delete(int id)
        {
            Entities.Configuration configuration = new Entities.Configuration { Id = id };
            context.Configurations.Attach(configuration);
            context.Configurations.Remove(configuration);
            return context.SaveChanges();
        }

        internal int Put(ConfigurationDTO configuration)
        {
            Entities.Configuration upd = context.Configurations.First(x => x.Id == configuration.Id.Value);
            int row = 0;

            if (upd != null)
            {
                upd.TimeConfig = (TimeConfig)configuration.TimeConfig;
                upd.Value = configuration.Value;

                row = context.SaveChanges();
            }

            return row;
        }
    }
}