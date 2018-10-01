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
			if (_context.Questions.Where(a => a.CategoryId == question.CategoryId)
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
			if (question != null)
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
			if (questions.Count > 0)
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
			if (question != null)
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
			var gameCategories = _context.CategoryGames.Include(a => a.Category).Where(a => a.GameId == gameRoomId).Select(a => a.Category).Include(a => a.Questions).ToList();

			List<Question> lowDifficultyQuestions = new List<Question>();
			List<Question> mediumDifficultyQuestions = new List<Question>();
			List<Question> highDifficultyQuestions = new List<Question>();

			List<Question> gameQuestions = new List<Question>();

			foreach (var auxCategory in gameCategories)
			{
				lowDifficultyQuestions.AddRange(auxCategory.Questions.Where(a => a.QuestionDifficulty == 1));
				mediumDifficultyQuestions.AddRange(auxCategory.Questions.Where(a => a.QuestionDifficulty == 2));
				highDifficultyQuestions.AddRange(auxCategory.Questions.Where(a => a.QuestionDifficulty == 3));
			}

			gameQuestions.Add(SelectQuestionByDifficulty(lowDifficultyQuestions));
			gameQuestions.Add(SelectQuestionByDifficulty(mediumDifficultyQuestions));
			gameQuestions.Add(SelectQuestionByDifficulty(highDifficultyQuestions));

			SelectQuestionByCategory(gameCategories, gameQuestions);

			gameQuestions.ForEach(a => a.Category = null);
			return gameQuestions;
		}

		public Question SelectQuestionByDifficulty(List<Question> list)
		{
			Random rnd = new Random();
			return list.ElementAt(rnd.Next(0, list.Count));
		}

		public void SelectQuestionByCategory(List<Category> gameCategories, List<Question> gameQuestions)
		{
			Random rnd = new Random();
			int i = 0;
			while (i < 7)
			{
				foreach (var category in gameCategories)
				{
					if (i >= 7)
					{
						break;
					}

					var questionToBeAdded = category.Questions.ElementAt(rnd.Next(0, category.Questions.Count));
					while (gameQuestions.Contains(questionToBeAdded))
					{
						questionToBeAdded = category.Questions.ElementAt(rnd.Next(0, category.Questions.Count));
					}
					gameQuestions.Add(questionToBeAdded);

					i++;

				}
			}
		}
	}
}
