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
            if (_context.Games.Where(a => a.UniqueKey == game.UniqueKey).SingleOrDefault() != null)
            {
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
                _context.Games.Remove(game);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Gameroom not found!");
            }
        }

        public IEnumerable<Game> GetGames()
        {
            var games = _context.Games.ToList();
            if(games != null)
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
            var game = _context.Games.SingleOrDefault(p => p.GameId == id);
            if (game != null)
            {
                return game;
            }
            else
            {
                throw new Exception("Gameroom not found!");
            }
        }

        public List<PlayerScore> GetPlayerAndScoreByGameRoomId(int gameRoomId)
        {
            if (_context.Games.Where(a => a.GameId == gameRoomId).SingleOrDefault() != null)
            {
                var players = new List<PlayerScore>();
                _context.Players.Where(a => a.GameroomId == gameRoomId).ToList()
                    .ForEach(a => players.Add(new PlayerScore() { Name = a.PlayerName, Score = a.PlayerScore, GameroomId = a.GameroomId }));

                return players;
            }
            else
            {
                throw new Exception("Gameroom not found!");
            }
        }

        public List<PlayerName> GetPlayersByRoomId(int gameRoomId)
        {
            if (_context.Games.Where(a => a.GameId == gameRoomId).SingleOrDefault() != null)
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

        public double GetAverageScore(int gameRoomId)
        {
            var games = GetGames();
            if (_context.Games.Where(a => a.GameId == gameRoomId).SingleOrDefault() != null)
            {
                double sum = 0;
                _context.Players.Where(a => a.GameroomId == gameRoomId).ToList()
                    .ForEach(a => sum += a.PlayerScore);
                var numberOfPlayers = GetPlayersByRoomId(gameRoomId).Count;
                return sum / numberOfPlayers;
            }
            else
            {
                throw new Exception("Gameroom not found!");
            }
        }

        public List<QuestionAnswers> GetQuestionsAndAnswersByGameRoomId(int gameRoomId)
        {
            var games = GetGames();
            if (_context.Games.Where(a => a.GameId == gameRoomId).SingleOrDefault() != null)
            {
                var questions = new List<QuestionAnswers>();
                var categories = new List<Category>();
                _context.Categories.Where(a => a.GameroomId == gameRoomId).ToList()
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
