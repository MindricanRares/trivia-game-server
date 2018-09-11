using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriviaServer.DAO.Interfaces;
using TriviaServer.Models;
using TriviaServer.PopulateSQL;

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
            if(_context.Categories.Where(a => a.CategoryName == c.CategoryName).SingleOrDefault() != null)
            {
                _context.Categories.Add(c);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Category already exists!");
            }
          
        }

        public void Edit(Category c)
        {
            _context.Categories.Update(c);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = _context.Categories.SingleOrDefault(x => x.CategoryId == id);
            if(category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("No category was found!");
            }
          
        }

        public IEnumerable<Category> GetCategories()
        {
            var categories = _context.Categories.ToList();
            if(categories != null)
            {
                return categories;
            }
            else
            {
                throw new Exception("No category was found!");
            }
            
        }

        public Category GetByID(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var category = _context.Categories.SingleOrDefault(p => p.CategoryId == id);
            if (category != null)
            {
                return category;
            }
            else
            {
                throw new Exception("Category not found!");
            }
               
        }

        public void DeleteAllCategories()
        {
            var categories = GetCategories();
            foreach (Category c in categories)
            {
                Delete(c.CategoryId);

            }
        }

        public void PopulateCategories() {

            DeleteAllCategories();
            var categories = JSONConverter.ReadJsonFile();
            foreach(Category c in categories)
            {
                Create(c);
            }
        }
    }
}
