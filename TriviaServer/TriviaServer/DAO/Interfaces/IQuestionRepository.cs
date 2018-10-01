using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriviaServer.Models;

namespace TriviaServer.DAO.Interfaces
{
    public interface IQuestionRepository
    {
        void Create(Question q);
        void Edit(Question q);
        void Delete(int id);
        IEnumerable<Question> GetQuestions();
        Question GetByID(int? id);
        IEnumerable<Question> GenerateGameQuestions(int uniqueKey);
    }
}
