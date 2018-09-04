using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TriviaServer.DAO.Interfaces;
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
        public ActionResult<IEnumerable<Player>> Get()
        {
            return _repo.GetPlayers().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Player> Get(int id)
        {
            var player = _repo.GetByID(id);
            return player;
        }

        [HttpPost]
        public void Post(Player p)
        {
            _repo.Create(p);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        [HttpPut]
        public void Put(Player p)
        {
            _repo.Edit(p);
        }
    }
}