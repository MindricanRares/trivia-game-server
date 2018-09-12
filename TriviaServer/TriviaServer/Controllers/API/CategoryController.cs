using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TriviaServer.DAO.Interfaces;
using TriviaServer.Models;

namespace TriviaServer.Controllers.API
{
    [Route("api/category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _repo;

        public CategoryController(ICategoryRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            try
            {
                var categories = _repo.GetCategories().ToList();
                return new JsonResult(categories);

            }
            catch
            {
                return BadRequest("No category was found!");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Category> Get(int id)
        {
            try
            {
                var category = _repo.GetByID(id);
                return new JsonResult(category);
            }
            catch
            {
                return BadRequest("No category was found!");
            }
        }

        [HttpPost]
        public ActionResult Post(Category category)
        {
            try
            {
                _repo.Create(category);
                return Ok("Category succcesfully added.");
            }
            catch
            {
                return BadRequest("Category already exists!");
            }
        }

        [HttpPost("refresh")]
        public void PostCategories()
        {
            _repo.PopulateCategories();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _repo.Delete(id);
                return Ok("Category succesfully deleted.");
            }
            catch
            {
                return BadRequest("Category not found!");
            }
        }

        [HttpPut]
        public void Put(Category category)
        {
            _repo.Edit(category);
        }
    }
}