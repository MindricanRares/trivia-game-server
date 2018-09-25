using Microsoft.EntityFrameworkCore;
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

        public void Create(Category category)
        {
            if (_context.Categories.Where(a => a.CategoryName == category.CategoryName).SingleOrDefault() == null)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Category already exists!");
            }
        }

        public void Edit(Category category)
        {
            _context.Categories.Update(category);
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
            if(categories.Count() > 0)
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
            var category = _context.Categories.Include(a => a.Questions).SingleOrDefault(p => p.CategoryId == id);
            if (category != null)
            {
                return category;
            }
            else
            {
                throw new Exception("Category not found!");
            }
        }

        public void PopulateCategories()
        {
            var categories = JSONConverter.ReadJsonFile();
            foreach (Category category in categories)
            {
                var auxCategory = _context.Categories.Include(a => a.Questions).Where(a => a.CategoryName == category.CategoryName).FirstOrDefault();
                if (auxCategory != null)
                {
                    for(int i = 0; i< category.Questions.Count; i++)
                    {
                        if (_context.Questions.Where(a => a.QuestionText == category.Questions.ElementAt(i).QuestionText).FirstOrDefault() != null)
                        {
                            auxCategory.Questions.ElementAt(i).CorrectAnswer = category.Questions.ElementAt(i).CorrectAnswer;
                            auxCategory.Questions.ElementAt(i).WrongAnswer1 = category.Questions.ElementAt(i).WrongAnswer1;
                            auxCategory.Questions.ElementAt(i).WrongAnswer2 = category.Questions.ElementAt(i).WrongAnswer2;
                            auxCategory.Questions.ElementAt(i).WrongAnswer3 = category.Questions.ElementAt(i).WrongAnswer3;
                            auxCategory.Questions.ElementAt(i).QuestionDifficulty = category.Questions.ElementAt(i).QuestionDifficulty;
                        }
                        else
                        {
                            auxCategory.Questions.Add(category.Questions.ElementAt(i));
                        }
                    }
                    Edit(auxCategory);
                }
                else
                {
                    Create(category);
                }
            }
        }
    }
}
