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
        public ActionResult<IEnumerable<Question>> Get()
        {
            return _repo.GetQuestions().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Question> Get(int id)
        {
            var question = _repo.GetByID(id);
            return question;
        }

        [HttpPost]
        public void Post(Question q)
        {
            _repo.Create(q);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        [HttpPut]
        public void Put(Question q)
        {
            _repo.Edit(q);
        }
    }
}