using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        [HttpGet("{gameRoomId}/players/score")]
        public ActionResult GetPlayersAndScore(int gameRoomId)
        {
            var players = _repo.GetPlayerAndScoreByGameRoomId(gameRoomId);
            return new JsonResult(players);
        }

        [HttpGet("{gameRoomId}/players")]
        public ActionResult GetPlayersName(int gameRoomId)
        {
            var players = _repo.GetPlayersByRoomId(gameRoomId);
            return new JsonResult(players);
        }

        [HttpGet("{gameRoomId}/players/number")]
        public ActionResult GetNumberOfPlayers(int gameRoomId)
        {
            var players = _repo.GetPlayersByRoomId(gameRoomId);
            return new JsonResult(players.Count);
        }

        [HttpGet("{gameRoomId}/statistics")]
        public ActionResult GetStatistics(int gameRoomId)
        {
            var averageScore = _repo.GetAverageScore(gameRoomId);
            return new JsonResult(averageScore);
        }

        [HttpGet("{gameRoomId}/questions")]
        public ActionResult GetQuestionsAndAnswers(int gameRoomId)
        {
            var questions = _repo.GetQuestionsAndAnswersByGameRoomId(gameRoomId);
            return new JsonResult(questions);
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