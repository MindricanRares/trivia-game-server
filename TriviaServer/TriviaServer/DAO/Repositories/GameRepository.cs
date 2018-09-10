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

        public List<PlayerScore> GetPlayerAndScoreByGameRoomId(int gameRoomId)
        {
            var players = new List<PlayerScore>();
            _context.Players.Where(a => a.GameroomId == gameRoomId).ToList()
                .ForEach(a => players.Add(new PlayerScore() { Name = a.PlayerName, Score = a.PlayerScore, GameroomId = a.GameroomId }));

            return players;
        }

        public List<PlayerName> GetPlayersByRoomId(int gameRoomId)
        {
            var players = new List<PlayerName>();
            _context.Players.Where(a => a.GameroomId == gameRoomId).ToList()
                .ForEach(a => players.Add(new PlayerName() { Name = a.PlayerName}));
            return players;
        }

        public double GetAverageScore(int gameRoomId)
        {
            double sum = 0;
            _context.Players.Where(a => a.GameroomId == gameRoomId).ToList()
                .ForEach(a => sum += a.PlayerScore);
            var numberOfPlayers = GetPlayersByRoomId(gameRoomId).Count;
            return sum / numberOfPlayers;
        }

        public List<QuestionAnswers> GetQuestionsAndAnswersByGameRoomId(int gameRoomId)
        {
            var questions = new List<QuestionAnswers>();
            var categories = new List<Category>();
            _context.Categories.Where(a => a.GameroomId == gameRoomId).ToList()
                .ForEach(a => categories.Add(a));
            foreach(Category c in categories)
            {
                _context.Questions.Where(a => a.CategoryId == c.CategoryId).ToList()
                    .ForEach(a => questions.Add(new QuestionAnswers() { QuestionText=a.QuestionText ,
                        CorrectAnswer = a.CorrectAnswer, WrongAnswer1=a.WrongAnswer1, WrongAnswer2=a.WrongAnswer2
                    ,WrongAnswer3=a.WrongAnswer3}));
            }
            return questions;
        }

     
    }
}
