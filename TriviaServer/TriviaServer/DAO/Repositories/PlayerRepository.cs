using Microsoft.EntityFrameworkCore;
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
            var players = _context.Players.Where(a => a.GameroomId == p.GameroomId).ToList();
            if (Validation.CreatePlayerValidation(players,p))
            {
                _context.Players.Add(p);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Nume deja existent!");
            }

        }

        public void Edit(Player p)
        {
            _context.Players.Update(p);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var player = _context.Players.SingleOrDefault(x => x.PlayerId == id);
            if(player != null)
            {
                _context.Players.Remove(player);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Player not found!");
            }
          
        }

        public IEnumerable<Player> GetPlayers()
        {
            var players = _context.Players.ToList();
            if(players != null)
            {
                return players;
            }
            else
            {
                throw new Exception("No player was found!");
            }
 
        }

        public Player GetByID(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var player = _context.Players.SingleOrDefault(p => p.PlayerId == id);
            if (player != null)
            {
                return player;
            }
            else
            {
                throw new Exception("Player not found!");
            }
             
        }

        public void UpdatePlayerScore(int gameRoomId, String playerName, int score)
        {
            var players = _context.Players.Where(a => a.GameroomId == gameRoomId).ToList();
            if (Validation.UpdateScoreValidation(players, playerName))
            {
                var player = _context.Players.Where(a => a.GameroomId == gameRoomId).ToList()
                .Where(a => a.PlayerName == playerName).First();
                player.PlayerScore += score;
                Edit(player);
            }
            else
            {
                throw new Exception("Player not found!");
            }
            
        }
    }
}
