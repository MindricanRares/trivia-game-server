using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriviaServer.Models;

namespace TriviaServer.DAO.Interfaces
{
    public interface IGameRepository
    {
        void Create(Game g);
        void Edit(Game g);
        void Delete(int id);
        IEnumerable<Game> GetGames();
        Game GetByID(int? id);
    }
}
