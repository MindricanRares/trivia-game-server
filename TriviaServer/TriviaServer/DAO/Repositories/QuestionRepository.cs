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
            if(_context.Questions.Where(a => a.CategoryId == q.CategoryId)
                .Where(a => a.QuestionText == q.QuestionText).SingleOrDefault() != null)
            {
                _context.Questions.Add(q);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Question already exists!");
            }
           
        }

        public void Edit(Question q)
        {
            _context.Questions.Update(q);
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
