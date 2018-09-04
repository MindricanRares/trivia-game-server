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
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly ICategoryRepository _repo;

        public CategoryController(ICategoryRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            return _repo.GetCategories().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Category> Get(int id)
        {
            var category = _repo.GetByID(id);
            return category;
        }


        [HttpPost]
        public void Post(Category c)
        {
            _repo.Create(c);
        }

        [HttpPost("refresh")]
        public void PostCategories()
        {
            _repo.PopulateCategories();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        [HttpPut]
        public void Put(Category c)
        {
            _repo.Edit(c);
        }
    }
}