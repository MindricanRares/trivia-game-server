using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriviaServer.Controllers.API;
using TriviaServer.DAO.Utils;
using TriviaServer.Models;

namespace TriviaServer.DAO.Repositories
{
    public class CategoryGameRepository : ICategoryGame
    {
        private ApplicationContext _context;

        public CategoryGameRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Create(GameCategories gameCategories)
        {
            if (_context.Games.Where(a => a.GameId == gameCategories.GameId).FirstOrDefault() != null)
            {
                foreach(var categoryId in gameCategories.CategoriesId)
                {
                    if (_context.Categories.Where(a => a.CategoryId == categoryId).SingleOrDefault() != null)
                    {
                        CategoryGame categoryGame = new CategoryGame
                        {
                            GameId = gameCategories.GameId,
                            CategoryId = categoryId
                        };
                        _context.CategoryGames.Add(categoryGame);
                        _context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Category does not exist!");
                    }
                }
                
            }
            else
            {
                throw new Exception("Gameroom does not exist!");
            }
        }
    }
}
