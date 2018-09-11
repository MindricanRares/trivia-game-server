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
        public ActionResult<IEnumerable<Game>> Get()
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
        public ActionResult<Game> Get(int id)
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

        [HttpGet("{gameRoomId}/players/score")]
        public ActionResult GetPlayersAndScore(int gameRoomId)
        {
            try
            {
                var players = _repo.GetPlayerAndScoreByGameRoomId(gameRoomId);
                return new JsonResult(players);
            }
            catch
            {
                return BadRequest("Gameroom " + gameRoomId + " not found!");
            }
        }

        [HttpGet("{gameRoomId}/players")]
        public ActionResult GetPlayersName(int gameRoomId)
        {
            try
            {
                var players = _repo.GetPlayersByRoomId(gameRoomId);
                return new JsonResult(players);
            }
            catch
            {
                return BadRequest("Gameroom " + gameRoomId + " not found!");
            }
        }

        [HttpGet("{gameRoomId}/players/number")]
        public ActionResult GetNumberOfPlayers(int gameRoomId)
        {
            try
            {
                var players = _repo.GetPlayersByRoomId(gameRoomId);
                return new JsonResult(players.Count);
            }
            catch
            {
                return BadRequest("Gameroom " + gameRoomId + " not found!");
            }
       
        }

        [HttpGet("{gameRoomId}/statistics")]
        public ActionResult GetStatistics(int gameRoomId)
        {
            try
            {
                var averageScore = _repo.GetAverageScore(gameRoomId);
                return new JsonResult(averageScore);
            }
            catch
            {
                return BadRequest("Gameroom " + gameRoomId + " not found!");
            }
        }

        [HttpGet("{gameRoomId}/questions")]
        public ActionResult GetQuestionsAndAnswers(int gameRoomId)
        {
            try
            {
                var questions = _repo.GetQuestionsAndAnswersByGameRoomId(gameRoomId);
                return new JsonResult(questions);
            }
            catch
            {
                return BadRequest("Gameroom " + gameRoomId + " not found!");
            }
        }

        [HttpPost]
        public ActionResult Post(Game g)
        {
            try
            {
                _repo.Create(g);
                return Ok(g);
            }
            catch
            {
                return BadRequest(g);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _repo.Delete(id);
                return Ok("Game succesfully deleted.");
            }
            catch
            {
                return BadRequest("Game not found!");
            }
        }

        [HttpPut]
        public void Put(Game g)
        {
            _repo.Edit(g);
        }
    }
}