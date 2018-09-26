using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using TriviaServer.Controllers.API;
using TriviaServer.DAO.Repositories;
using TriviaServer.DAO.Utils;
using TriviaServer.Models;
using Xunit;

namespace XUnitTest
{
    [Collection("Database collection")]
    public class TestCategoryGameController
    {
        [Fact]
        public void TestAddCategoriesToGame()
        {
            CategoryGameRepository categoryGameRepo = new CategoryGameRepository(DatabaseDummy.DatabaseDummyCreate("TestAddCategoriesToGame"));
            CategoryGameController categoryGameController = new CategoryGameController(categoryGameRepo);
            GameCategories gameCategories = new GameCategories
            {
                GameId = 4,
                CategoriesId = new List<int>() { 34,35}
            };
            var actionResult = categoryGameController.AddCategoriesToGame(gameCategories);
            Assert.IsNotType<BadRequestObjectResult>(actionResult);
        }
    }
}
