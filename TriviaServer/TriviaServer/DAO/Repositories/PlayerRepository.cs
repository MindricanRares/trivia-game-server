using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriviaServer.DAO.Interfaces;
using TriviaServer.DAO.Utils;
using TriviaServer.Models;

namespace TriviaServer.DAO.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private ApplicationContext _context;

        public PlayerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Create(Player p)
        {
            _context.Players.Add(p);
            _context.SaveChanges();
        }

        public void Edit(Player p)
        {
            _context.Players.Update(p);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var player = _context.Players.SingleOrDefault(x => x.PlayerId == id);
            _context.Players.Remove(player);
            _context.SaveChanges();
        }

        public IEnumerable<Player> GetPlayers()
        {
            var players = _context.Players.ToList();
            return players;
        }

        public Player GetByID(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var player = _context.Players.SingleOrDefault(p => p.PlayerId == id);

            return player;
        }

        public void UpdatePlayerScore(int gameRoomId, String playerName, int score)
        {
            var player = _context.Players.Where(a => a.GameroomId == gameRoomId).ToList()
                .Where(a => a.PlayerName == playerName).First();
            player.PlayerScore += score;
            Edit(player);
        }
    }
}
