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

        public void Create(Question question)
        {
            if(_context.Questions.Where(a => a.CategoryId == question.CategoryId)
                .Where(a => a.QuestionText == question.QuestionText).SingleOrDefault() != null)
            {
                _context.Questions.Add(question);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Question already exists!");
            }
        }

        public void Edit(Question question)
        {
            _context.Questions.Update(question);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var question = _context.Questions.SingleOrDefault(x => x.QuestionId == id);
            if(question != null)
            {
                _context.Questions.Remove(question);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Question not found!");
            }
        }

        public IEnumerable<Question> GetQuestions()
        {
            var questions = _context.Questions.ToList();
            if(questions != null)
            {
                return questions;
            }
            else
            {
                throw new Exception("No question was found!");
            }
        }

        public Question GetByID(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var question = _context.Questions.SingleOrDefault(p => p.QuestionId == id);
            if(question != null)
            {
                return question;
            }
            else
            {
                throw new Exception("Question not found!");
            }
        }
    }
}
