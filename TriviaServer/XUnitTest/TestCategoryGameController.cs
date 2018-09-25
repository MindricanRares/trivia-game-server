using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using TriviaServer.Controllers.API;
using TriviaServer.DAO.Repositories;
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
            CategoryGame categoryGame = new CategoryGame()
            {
                CategoryId = 34,
                GameId = 4
            };
            var actionResult = categoryGameController.AddCategoriesToGame(categoryGame);
            Assert.IsNotType<BadRequestObjectResult>(actionResult);
        }
    }
}
