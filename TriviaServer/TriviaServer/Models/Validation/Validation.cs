using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriviaServer.Models;

namespace TriviaServer.DAO.Utils
{
    public class Validation
    {
        public static Boolean CreatePlayerValidation(ICollection<Player> players, Player player)
        {
            foreach(Player p in players)
            {
                if (player.PlayerName == p.PlayerName)
                    return false;
            }
            return true;
        }

        public static Boolean UpdateScoreValidation(ICollection<Player> players, String playerName)
        {
            foreach(Player p in players)
            {
                if(p.PlayerName == playerName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
