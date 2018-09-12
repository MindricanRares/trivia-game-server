using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TriviaServer.DAO.Interfaces;
using TriviaServer.DAO.Utils;
using TriviaServer.Models;

namespace TriviaServer.Controllers.API
{
    [Route("api/player")]
    public class PlayerController : Controller
    {
        private readonly IPlayerRepository _repo;

        public PlayerController(IPlayerRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Player>> GetPlayers()
        {
            try
            {
                var players = _repo.GetPlayers().ToList();
                return new JsonResult(players);
            }
          catch
            {
                return BadRequest("No player was found!");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Player> Get(int id)
        {
            try
            {
                var player = _repo.GetByID(id);
                return new JsonResult(player);
            }
           catch
            {
                return BadRequest("Player with id " + id + " not found!" );
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Player player)
        {
            try
            {
                _repo.Create(player);
                return Ok(player);
            }
            catch
            {
                return BadRequest(player);
            }
        }

        [HttpPost("updatescore")]
        public ActionResult UpdatePlayerScore([FromBody] PlayerScore player)
        {
            try
            {
                _repo.UpdatePlayerScore(player.GameroomId, player.Name, player.Score);
                return Ok(player);
            }
            catch
            {
                return BadRequest(player);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _repo.Delete(id);
                return Ok("Player was succesfully deleted.");
            }
            catch
            {
                return BadRequest("Player with id " + id + " not found!");
            }
        }

        [HttpPut]
        public void Put(Player player)
        {
            _repo.Edit(player);
        }

    }
}