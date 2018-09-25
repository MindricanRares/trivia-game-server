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
    public class TestGameController 
    {
        [Fact]
        public void TestGetGamesController()
        {
            GameRepository gameRepo = new GameRepository(DatabaseDummy.DatabaseDummyCreate("TestGetGamesController"));
            GameController gameController = new GameController(gameRepo);

            var actionResult = gameController.GetGames();
            Assert.IsNotType<BadRequestObjectResult>(actionResult.Result);
        }

        [Fact]
        public void TestGetGameByIdController()
        {
            GameRepository gameRepo = new GameRepository(DatabaseDummy.DatabaseDummyCreate("TestGetGameByIdController"));
            GameController gameController = new GameController(gameRepo);

            var actionResult = gameController.GetById(4);
            Assert.IsNotType<BadRequestObjectResult>(actionResult.Result);
        }

        [Fact]
        public void TestGetPlayersAndScore()
        {
            GameRepository gameRepo = new GameRepository(DatabaseDummy.DatabaseDummyCreate("TestGetPlayersAndScore"));
            GameController gameController = new GameController(gameRepo);

            var actionResult = gameController.GetPlayersAndScore(4);
            Assert.IsNotType<BadRequestObjectResult>(actionResult);
        }

        [Fact]
        public void TestGetPlayersName()
        {
            GameRepository gameRepo = new GameRepository(DatabaseDummy.DatabaseDummyCreate("TestGetPlayersName"));
            GameController gameController = new GameController(gameRepo);

            var actionResult = gameController.GetPlayersName(5);
            Assert.IsNotType<BadRequestObjectResult>(actionResult);
        }

        [Fact]
        public void TestGetNumberOfPlayers()
        {
            GameRepository gameRepo = new GameRepository(DatabaseDummy.DatabaseDummyCreate("TestGetNumberOfPlayers"));
            GameController gameController = new GameController(gameRepo);

            var actionResult = gameController.GetNumberOfPlayers(4);
            Assert.IsNotType<BadRequestObjectResult>(actionResult);
        }

        [Fact]
        public void TestGetStatistics()
        {
            GameRepository gameRepo = new GameRepository(DatabaseDummy.DatabaseDummyCreate("TestGetStatistics"));
            GameController gameController = new GameController(gameRepo);

            var actionResult = gameController.GetStatistics(5);
            Assert.IsNotType<BadRequestObjectResult>(actionResult);
        }

        [Fact]
        public void TestGetQuestionsAndAnswers()
        {
            GameRepository gameRepo = new GameRepository(DatabaseDummy.DatabaseDummyCreate("TestGetQuestionsAndAnswers"));
            GameController gameController = new GameController(gameRepo);

            var actionResult = gameController.GetQuestionsAndAnswers(5);
            Assert.IsNotType<BadRequestObjectResult>(actionResult);
        }

        [Fact]
        public void TestPostGames()
        {
            GameRepository gameRepo = new GameRepository(DatabaseDummy.DatabaseDummyCreate("TestPostGames"));
            GameController gameController = new GameController(gameRepo);
            Game game = new Game()
            {
                UniqueKey = 8,
            };
            var actionResult = gameController.PostGames(game);
            Assert.IsNotType<BadRequestObjectResult>(actionResult);
        }

        [Fact]
        public void TestDeleteGamesController()
        {
            GameRepository gameRepo = new GameRepository(DatabaseDummy.DatabaseDummyCreate("TestDeleteGamesController"));
            GameController gameController = new GameController(gameRepo);

            var actionResult = gameController.Delete(4);
            Assert.IsNotType<BadRequestObjectResult>(actionResult);
        }
    }
}
