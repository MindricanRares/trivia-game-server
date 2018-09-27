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
        private readonly IGameRepository _repo;

        public GameController(IGameRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Game>> GetGames()
        {
            try
            {
                var games = _repo.GetGames().ToList();
                return new JsonResult(games);
            }
           catch
            {
                return BadRequest("No game was found!");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Game> GetById(int id)
        {
            try
            {
                var game = _repo.GetByID(id);
                return new JsonResult(game);
            }
            catch
            {
                return BadRequest("GameRoom not found!");
            }
        }

        [HttpGet("{uniqueKey}/players/score")]
        public ActionResult GetPlayersAndScore(int uniqueKey)
        {
            try
            {
                var players = _repo.GetPlayerAndScoreByUniqueKey(uniqueKey);
                return new JsonResult(players);
            }
            catch
            {
                return BadRequest("UniqueKey " + uniqueKey + " not found!");
            }
        }

        [HttpGet("{uniqueKey}/players")]
        public ActionResult GetPlayersName(int uniqueKey)
        {
            try
            {
                var players = _repo.GetPlayersByUniqueKey(uniqueKey);
                return new JsonResult(players);
            }
            catch
            {
                return BadRequest("UniqueKey " + uniqueKey + " not found!");
            }
        }

        [HttpGet("{uniqueKey}/players/number")]
        public ActionResult GetNumberOfPlayers(int uniqueKey)
        {
            try
            {
                var players = _repo.GetPlayersByUniqueKey(uniqueKey);
                return new JsonResult(players.Count);
            }
            catch
            {
                return BadRequest("UniqueKey " + uniqueKey + " not found!");
            }
        }

        [HttpGet("{uniqueKey}/statistics")]
        public ActionResult GetStatistics(int uniqueKey)
        {
            try
            {
                var averageScore = _repo.GetAverageScore(uniqueKey);
                return new JsonResult(averageScore);
            }
            catch
            {
                return BadRequest("UniqueKey " + uniqueKey + " not found!");
            }
        }

        [HttpGet("{uniqueKey}/questions")]
        public ActionResult GetQuestionsAndAnswers(int uniqueKey)
        {
            try
            {
                var questions = _repo.GetQuestionsAndAnswersByUniqueKey(uniqueKey);
                return new JsonResult(questions);
            }
            catch
            {
                return BadRequest("UniqueKey " + uniqueKey + " not found!");
            }
        }

        [HttpPost]
        public ActionResult PostGames([FromBody] Game game)
        {
            try
            {
                _repo.Create(game);
                return Ok(game);
            }
            catch
            {
                return BadRequest(game);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _repo.Delete(id);
                return Ok("Game successfully deleted.");
            }
            catch
            {
                return BadRequest("Game not found!");
            }
        }

        [HttpPut]
        public void Put(Game game)
        {
            _repo.Edit(game);
        }
    }
}