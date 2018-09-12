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
            foreach(Player playerItem in players)
            {
                if (player.PlayerName == playerItem.PlayerName)
                    return false;
            }
            return true;
        }

        public static Boolean UpdateScoreValidation(ICollection<Player> players, String playerName)
        {
            foreach(Player player in players)
            {
                if(player.PlayerName == playerName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
