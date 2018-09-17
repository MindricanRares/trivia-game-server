using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TriviaServer.Models;

namespace TriviaServer.Controllers.API
{
    [Route("api/categorygame")]
    public class CategoryGameController : Controller
    {
        private readonly ICategoryGame _repo;

        public CategoryGameController(ICategoryGame repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public ActionResult AddCategoriesToGame([FromBody] CategoryGame categoryGame)
        {
            try
            {
                _repo.Create(categoryGame);
                return Ok("Category was successfully added");
            }
            catch
            {
                return BadRequest("Category was not added!");
            }
        }
    }
}