using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriviaServer.DAO.Interfaces;
using TriviaServer.DAO.Utils;
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

        public void Create(Game game)
        {
            if (_context.Games.Where(a => a.UniqueKey == game.UniqueKey).FirstOrDefault() == null)
            {
                game.IsActive = true;
                _context.Games.Add(game);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Game already exists!");
            }
        }

        public void Edit(Game game)
        {
            _context.Games.Update(game);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var game = _context.Games.SingleOrDefault(x => x.GameId == id);
            if(game != null)
            {
                game.IsActive = false;
                Edit(game);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Gameroom not found!");
            }
        }

        public IEnumerable<Game> GetGames()
        {
            var games = _context.Games.Where(a => a.IsActive).ToList();
            if(games.Count > 0)
            {
                return games;
            }
            else
            {
                throw new Exception("No game was found!");
            }
        }

        public Game GetByID(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var game = _context.Games.Where(p => p.GameId == id).FirstOrDefault(a => a.IsActive);
            if (game != null)
            {
                return game;
            }
            else
            {
                throw new Exception("Gameroom not found!");
            }
        }

        public int GetGameroomIdByUniqueKey(int uniqueKey)
        {
            int? gameRoomId = _context.Games.Where(a => a.UniqueKey == uniqueKey).FirstOrDefault(a => a.IsActive).GameId;
            if (gameRoomId != null)
            {
                return gameRoomId.Value;
            }
            else
            {
                throw new Exception("UniqueKey not found");
            }
        }

        public int GetUniqueKeyByGameroomId(int gameRoomId)
        {
            int? uniqueKey = _context.Games.Where(a => a.GameId == gameRoomId).FirstOrDefault(a => a.IsActive).UniqueKey;
            if (uniqueKey != null)
            {
                return uniqueKey.Value;
            }
            else
            {
                throw new Exception("UniqueKey not found");
            }
        }

        public List<PlayerScore> GetPlayerAndScoreByUniqueKey(int uniqueKey)
        {
            int gameRoomId = GetGameroomIdByUniqueKey(uniqueKey);
            if (_context.Games.Where(a => a.GameId == gameRoomId).FirstOrDefault(a => a.IsActive) != null)
            {
                var players = new List<PlayerScore>();
                _context.Players.Where(a => a.GameroomId == gameRoomId).ToList()
                    .ForEach(a => players.Add(new PlayerScore() { Name = a.PlayerName, Score = a.PlayerScore, UniqueKey = GetUniqueKeyByGameroomId(a.GameroomId) }));

                return players;
            }
            else
            {
                throw new Exception("Gameroom not found!");
            }
        }

        public List<PlayerName> GetPlayersByUniqueKey(int uniqueKey)
        {
            int gameRoomId = GetGameroomIdByUniqueKey(uniqueKey);
            if (_context.Games.Where(a => a.GameId == gameRoomId).FirstOrDefault(a => a.IsActive) != null)
            {
                var players = new List<PlayerName>();
                _context.Players.Where(a => a.GameroomId == gameRoomId).ToList()
                    .ForEach(a => players.Add(new PlayerName() { Name = a.PlayerName }));
                return players;
            }
            else
            {
                throw new Exception("Gameroom not found!");
            }
        }

        public double GetAverageScore(int uniqueKey)
        {
            int gameRoomId = GetGameroomIdByUniqueKey(uniqueKey);
            var games = GetGames();
            if (_context.Games.Where(a => a.GameId == gameRoomId).FirstOrDefault(a => a.IsActive) != null)
            {
                double sum = 0;
                _context.Players.Where(a => a.GameroomId == gameRoomId).ToList()
                    .ForEach(a => sum += a.PlayerScore);
                var numberOfPlayers = GetPlayersByUniqueKey(uniqueKey).Count;
                return sum / numberOfPlayers;
            }
            else
            {
                throw new Exception("Gameroom not found!");
            }
        }

        public List<QuestionAnswers> GetQuestionsAndAnswersByUniqueKey(int uniqueKey)
        {
            int gameRoomId = GetGameroomIdByUniqueKey(uniqueKey);
            var games = GetGames();
            if (_context.Games.Where(a => a.GameId == gameRoomId).FirstOrDefault(a => a.IsActive) != null)
            {
                var questions = new List<QuestionAnswers>();
                var categories = new List<Category>();
                _context.CategoryGames.Where(a => a.GameId == gameRoomId).Select(a => a.Category).ToList()
                    .ForEach(a => categories.Add(a));
                foreach (Category c in categories)
                {
                    _context.Questions.Where(a => a.CategoryId == c.CategoryId).ToList()
                        .ForEach(a => questions.Add(new QuestionAnswers()
                        {
                            QuestionText = a.QuestionText,
                            CorrectAnswer = a.CorrectAnswer,
                            WrongAnswer1 = a.WrongAnswer1,
                            WrongAnswer2 = a.WrongAnswer2,
                            WrongAnswer3 = a.WrongAnswer3
                        }));
                }
                return questions;
            }
            else
            {
                throw new Exception("Gameroom not found!");
            }
        }

        
    }
}
