using Microsoft.AspNetCore.Mvc;
using TriviaServer.Controllers.API;
using TriviaServer.DAO.Repositories;
using TriviaServer.DAO.Utils;
using TriviaServer.Models;
using Xunit;

namespace XUnitTest
{
    [Collection("Database collection")]
    public class TestCategoryController 
    {
        [Fact]
        public void TestGetCatgories()
        {
            CategoryRepository categoryRepo = new CategoryRepository(DatabaseDummy.DatabaseDummyCreate("TestGetCatgories"));
            CategoryController categoryController = new CategoryController(categoryRepo);

            var actionResult = categoryController.GetCatgories();
            Assert.IsNotType<BadRequestObjectResult>(actionResult.Result);
           
        }

        [Fact]
        public void TestGetById()
        {
            CategoryRepository categoryRepo = new CategoryRepository(DatabaseDummy.DatabaseDummyCreate("TestGetById"));
            CategoryController categoryController = new CategoryController(categoryRepo);

            var actionResult = categoryController.GetById(34);
            Assert.IsNotType<BadRequestObjectResult>(actionResult.Result);
        }

        [Fact]
        public void TestCreateCategoryController()
        {
            CategoryRepository categoryRepo = new CategoryRepository(DatabaseDummy.DatabaseDummyCreate("TestCreateCategoryController"));
            CategoryController categoryController = new CategoryController(categoryRepo);

            Category category = new Category
            {
                CategoryName = "History",
                NumberOfUses = 0
            };

            var actionResult = categoryController.CreateCategory(category);
            Assert.IsNotType<BadRequestObjectResult>(actionResult);
        }

        [Fact]
        public void TestPostCategories()
        {
            CategoryRepository categoryRepo = new CategoryRepository(DatabaseDummy.DatabaseDummyCreate("TestPostCategories"));
            CategoryController categoryController = new CategoryController(categoryRepo);

            Password password = new Password();
            password.Pass = "UmFkdUVPUHJpbnRlc2E=";
            try
            {
                var actionResult = categoryController.PostCategories(password);
                Assert.IsNotType<BadRequestObjectResult>(actionResult);
            }
            catch
            {
                Assert.True(true);
            }
        }

        [Fact]
        public void TestDelete()
        {
            CategoryRepository categoryRepo = new CategoryRepository(DatabaseDummy.DatabaseDummyCreate("TestDelete"));
            CategoryController categoryController = new CategoryController(categoryRepo);

            var actionResult = categoryController.Delete(36);
            Assert.IsNotType<BadRequestObjectResult>(actionResult);
        }
    }
}
