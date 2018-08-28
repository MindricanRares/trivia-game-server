using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TriviaServer.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public int GameroomId { get; set; }
        public int PlayerScore { get; set; }
        public Game Game { get; set; }
    }
}
