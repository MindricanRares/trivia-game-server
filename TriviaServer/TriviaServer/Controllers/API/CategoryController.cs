using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TriviaServer.DAO.Interfaces;
using TriviaServer.DAO.Utils;
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
        public ActionResult<IEnumerable<Category>> GetCatgories()
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
        public ActionResult<Category> GetById(int id)
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
        public ActionResult CreateCategory(Category category)
        {
            try
            {
                _repo.Create(category);
                return Ok("Category successfully added.");
            }
            catch
            {
                return BadRequest("Category already exists!");
            }
        }

        [HttpPost("refresh")]
        public ActionResult PostCategories([FromBody] Password password)
        {
            String configpassword = TriviaConfiguration.Instance.GetPassword();

            var decryptedPassword = StringEncryption.DecryptString(password.Pass);

            if (decryptedPassword == configpassword)
            {
                _repo.PopulateCategories();
                return Ok();
            }
            else
            {
                return BadRequest("Access denied!");
            }

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _repo.Delete(id);
                return Ok("Category successfully deleted.");
            }
            catch
            {
                return BadRequest("Category not found!");
            }
        }
    }
}