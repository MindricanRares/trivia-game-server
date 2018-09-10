using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriviaServer.DAO.Utils;
using TriviaServer.Models;

namespace TriviaServer.DAO.Interfaces
{
    public interface IGameRepository
    {
        void Create(Game g);
        void Edit(Game g);
        void Delete(int id);
        IEnumerable<Game> GetGames();
        Game GetByID(int? id);
        List<PlayerScore> GetPlayerAndScoreByGameRoomId(int gameRoomId);
        List<PlayerName> GetPlayersByRoomId(int gameRoomId);
        double GetAverageScore(int gameRoomId);
        List<QuestionAnswers> GetQuestionsAndAnswersByGameRoomId(int gameRoomId);
    }
}
