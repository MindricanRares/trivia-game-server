using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriviaServer.Controllers.API;
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

        public void Create(CategoryGame categoryGame)
        {
            if (_context.Games.Where(a => a.GameId == categoryGame.GameId).SingleOrDefault() != null)
            {
                if (_context.Categories.Where(a => a.CategoryId == categoryGame.CategoryId).SingleOrDefault() != null)
                {
                    _context.CategoryGames.Add(categoryGame);
                    _context.SaveChanges();
                }
            }

        }
    }
}
