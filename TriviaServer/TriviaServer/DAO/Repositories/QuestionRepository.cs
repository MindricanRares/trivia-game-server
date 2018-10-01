using Microsoft.EntityFrameworkCore;
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
                .Where(a => a.QuestionText == question.QuestionText).SingleOrDefault() == null)
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
            if(questions.Count > 0)
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

        public IEnumerable<Question> GenerateGameQuestions(int uniqueKey)
        {
            GameRepository gameRepo = new GameRepository(_context);
            int gameRoomId = gameRepo.GetGameroomIdByUniqueKey(uniqueKey);
            var gameCategories = _context.CategoryGames.Where(a => a.GameId == gameRoomId).ToList();
            List<List<Question>> lowDifficultyQuestions = new List<List<Question>>();
            List<List<Question>> mediumDifficultyQuestions = new List<List<Question>>();
            List<List<Question>> highDifficultyQuestions = new List<List<Question>>();
            List<Question> gameQuestions = new List<Question>();
            List<Category> categories = new List<Category>();
            foreach(var gc in gameCategories)
            {
                categories.Add(_context.Categories.Where(a => a.CategoryId == gc.CategoryId).FirstOrDefault());
            }

            foreach (var auxCategory in categories)
            {
                lowDifficultyQuestions.Add(_context.Questions.Where(a => a.QuestionDifficulty == 1).Where(a => a.CategoryId == auxCategory.CategoryId).ToList());
                mediumDifficultyQuestions.Add(_context.Questions.Where(a => a.QuestionDifficulty == 2).Where(a => a.CategoryId == auxCategory.CategoryId).ToList());
                highDifficultyQuestions.Add(_context.Questions.Where(a => a.QuestionDifficulty == 3).Where(a => a.CategoryId == auxCategory.CategoryId).ToList());
            }

            gameQuestions.Add(SelectQuestionByDifficulty(lowDifficultyQuestions,gameCategories));
            gameQuestions.Add(SelectQuestionByDifficulty(mediumDifficultyQuestions, gameCategories));
            gameQuestions.Add(SelectQuestionByDifficulty(highDifficultyQuestions, gameCategories));

            SelectQuestionByCategory(gameCategories,gameQuestions);

            gameQuestions.ForEach(a => a.Category = null);
            return gameQuestions;
        }

        public Question SelectQuestionByDifficulty(List<List<Question>> list, List<CategoryGame> gameCategories)
        {
            Random rnd = new Random();
            var categoryQuestions = list.ElementAt(rnd.Next(0, gameCategories.Count));
            var numberOfQuestions = categoryQuestions.Count;
            return categoryQuestions.ElementAt(rnd.Next(0, numberOfQuestions));
        }

        public void SelectQuestionByCategory(List<CategoryGame> gameCategories, List<Question> gameQuestions)
        {
            Random rnd = new Random();
            int i = 0;
            while (i < 7)
            {
                foreach (var c in gameCategories)
                {
                    if (i < 7)
                    {
                        var category = _context.Categories.Include(a => a.Questions).Where(a => a.CategoryId == c.CategoryId).FirstOrDefault();
                        var questions = category.Questions;

                        var questionToBeAdded = questions.ElementAt(rnd.Next(0, questions.Count));
                        while (gameQuestions.Contains(questionToBeAdded))
                        {
                            questionToBeAdded = questions.ElementAt(rnd.Next(0, questions.Count));
                        }
                        gameQuestions.Add(questionToBeAdded);
                        i++;
                    }
                }
            }
        }
    }
}
