using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriviaServer.Models;

namespace TriviaServer.DAO.Utils
{
    public class GameCategories
    {
        public int GameId { get; set; }
        public ICollection<int> CategoriesId { get; set; }
    }
}
