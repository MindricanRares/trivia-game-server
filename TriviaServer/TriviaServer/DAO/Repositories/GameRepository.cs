using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriviaServer.DAO.Interfaces;
using TriviaServer.Models;

namespace TriviaServer.DAO.Repositories
{
    public class GameRepository : IGameRepository
    {
        private ApplicationContext _context;

        public GameRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Create(Game g)
        {
            _context.Games.Add(g);
            _context.SaveChanges();
        }

        public void Edit(Game g)
        {
            _context.Games.Update(g);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var game = _context.Games.SingleOrDefault(x => x.GameId == id);
            _context.Games.Remove(game);
            _context.SaveChanges();
        }

        public IEnumerable<Game> GetGames()
        {
            var games = _context.Games.ToList();
            return games;
        }

        public Game GetByID(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var game = _context.Games.SingleOrDefault(p => p.GameId == id);

            return game;
        }

        public List<(String,int)> GetByGameRoomId(int gameRoomId)
        {
            var players = new List<(String, int)>();
            //var gameRoom = _context.Games.Find(gameRoomId);
            //foreach (Player p in gameRoom.Players)
            //{
            //    players.Add((p.PlayerName, p.PlayerScore));
            //}
            _context.Players.Where(a => a.GameroomId == gameRoomId).ToList()
                .ForEach(a => players.Add((a.PlayerName, a.PlayerScore)));

            return players;
        }
    }
}
