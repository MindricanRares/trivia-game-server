using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriviaServer.DAO.Interfaces;
using TriviaServer.Models;

namespace TriviaServer.DAO.Repositories 
{
    public class QuestionRepository : IQuestionRepository
    {
        private ApplicationContext _context;

        public QuestionRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Create(Question q)
        {
            _context.Questions.Add(q);
            _context.SaveChanges();
        }

        public void Edit(Question q)
        {
            _context.Questions.Update(q);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var question = _context.Questions.SingleOrDefault(x => x.QuestionId == id);
            _context.Questions.Remove(question);
            _context.SaveChanges();
        }

        public IEnumerable<Question> GetQuestions()
        {
            var questions = _context.Questions.ToList();
            return questions;
        }

        public Question GetByID(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var question = _context.Questions.SingleOrDefault(p => p.QuestionId == id);

            return question;
        }
    }
}
