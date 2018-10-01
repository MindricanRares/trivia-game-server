using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TriviaServer.DAO.Interfaces;
using TriviaServer.Models;

namespace TriviaServer.Controllers.API
{
    [Route("api/question")]
    public class QuestionController : Controller
    {
        private readonly IQuestionRepository _repo;

        public QuestionController(IQuestionRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Question>> GetQuestions()
        {
            try
            {
                var questions = _repo.GetQuestions().ToList();
                return new JsonResult(questions);
            }
            catch
            {
                return BadRequest("No question was found!");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Question> GetById(int id)
        {
            try
            {
                var question = _repo.GetByID(id);
                return new JsonResult(question);
            }
            catch
            {
                return BadRequest("Question not found!");
            }
        }

        [HttpGet("{uniqueKey}/random")]
        public ActionResult<IEnumerable<Question>> GenerateGameQuestions(int uniqueKey)
        {
            try
            {
                var questions = _repo.GenerateGameQuestions(uniqueKey);
                return new JsonResult(questions);
            }
            catch
            {
                return BadRequest("No question was found!");
            }
        }

        [HttpPost]
        public ActionResult PostQuestion(Question question)
        {
            try
            {
                _repo.Create(question);
                return Ok("Question successfully added.");
            }
            catch
            {
                return BadRequest("Question already exists!");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _repo.Delete(id);
                return Ok("Question successfully deleted.");
            }
            catch
            {
                return BadRequest("Question not found!");
            }
        }

        [HttpPut]
        public void Put(Question question)
        {
            _repo.Edit(question);
        }
    }
}