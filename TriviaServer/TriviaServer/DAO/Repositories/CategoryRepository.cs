using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriviaServer.DAO.Interfaces;
using TriviaServer.Models;

namespace TriviaServer.DAO.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private ApplicationContext _context;

        public CategoryRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Create(Category c)
        {
            _context.Categories.Add(c);
            _context.SaveChanges();
        }

        public void Edit(Category c)
        {
            _context.Categories.Update(c);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = _context.Categories.SingleOrDefault(x => x.CategoryId == id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public IEnumerable<Category> GetCategories()
        {
            var categories = _context.Categories.ToList();
            return categories;
        }

        public Category GetByID(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var category = _context.Categories.SingleOrDefault(p => p.CategoryId == id);

            return category;
        }
    }
}
