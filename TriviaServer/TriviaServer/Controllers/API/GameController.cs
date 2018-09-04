using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TriviaServer.DAO.Interfaces;
using TriviaServer.Models;

namespace TriviaServer.Controllers.API
{
    [Route("api/game")]
    public class GameController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly IGameRepository _repo;

        public GameController(IGameRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Game>> Get()
        {
            return _repo.GetGames().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Game> Get(int id)
        {
            var game = _repo.GetByID(id);
            return game;
        }

        [HttpPost]
        public void Post(Game g)
        {
            _repo.Create(g);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        [HttpPut]
        public void Put(Game g)
        {
            _repo.Edit(g);
        }
    }
}