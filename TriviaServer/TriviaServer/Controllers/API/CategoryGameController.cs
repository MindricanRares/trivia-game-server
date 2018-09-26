using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TriviaServer.DAO.Utils;
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
        public ActionResult AddCategoriesToGame([FromBody] GameCategories gameCategories)
        {
            try
            {
               _repo.Create(gameCategories);
               return Ok("Categories were successfully added");
             
            }
            catch
            {
                return BadRequest("Categories were not added!");
            }
        }
    }
}