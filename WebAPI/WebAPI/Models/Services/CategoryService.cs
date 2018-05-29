using System.Collections.Generic;
using System.Linq;
using WebAPI.Models.Database;
using WebAPI.Models.DTO;
using WebAPI.Models.Entities;

namespace WebAPI.Models.Services
{
    public class CategoryService
    {
        private DBContextWebAPI context = new DBContextWebAPI();

        public List<Category> Get()
        {
            return context.Categories.ToList();
        }

        public Category Get(decimal id)
        {
            return context.Categories.Find(id);
        }

        internal int Post(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return category.Id;
        }

        internal int Delete(int id)
        {
            Category category = new Category { Id = id };
            context.Categories.Attach(category);
            context.Categories.Remove(category);
            return context.SaveChanges();
        }

        internal int Put(CategoryDTO category)
        {
            Category upd = context.Categories.First(x => x.Id == category.Id.Value);
            int row = 0;

            if (upd != null)
            {
                upd.Description = category.Description;
                upd.Name = category.Name;

                row = context.SaveChanges();
            }

            return row;
        }
    }
}