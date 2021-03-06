﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriviaServer.DAO.Utils;
using TriviaServer.Models;

namespace TriviaServer.DAO.Interfaces
{
    public interface IPlayerRepository
    {
        void Create(PlayerUniqueKey p);
        void Edit(Player p);
        void Delete(int id);
        IEnumerable<Player> GetPlayers();
        Player GetByID(int? id);
        void UpdatePlayerScore(int gameRoomId, String playerName, int score);
    }
}
