﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TriviaServer.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public int UniqueKey{ get; set; }
        public bool IsActive { get; set; }
        public ICollection<Player> Players { get; set; }
        public ICollection<CategoryGame> CategoryGames { get; set; }
    }
}
