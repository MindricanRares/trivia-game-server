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
    public class TestPlayerController 
    {
        [Fact]
        public void TestGetPlayersController()
        {
            PlayerRepository playerRepo = new PlayerRepository(DatabaseDummy.DatabaseDummyCreate("TestGetPlayersController"));
            PlayerController playerController = new PlayerController(playerRepo);

            var actionResult = playerController.GetPlayers();
            Assert.IsNotType<BadRequestObjectResult>(actionResult.Result);
        }

        [Fact]
        public void TestGetPlayerById()
        {
            PlayerRepository playerRepo = new PlayerRepository(DatabaseDummy.DatabaseDummyCreate("TestGetPlayerById"));
            PlayerController playerController = new PlayerController(playerRepo);

            var actionResult = playerController.GetById(10);
            Assert.IsNotType<BadRequestObjectResult>(actionResult.Result);
        }

        [Fact]
        public void TestPostPlayer()
        {
            PlayerRepository playerRepo = new PlayerRepository(DatabaseDummy.DatabaseDummyCreate("TestPostPlayer"));
            PlayerController playerController = new PlayerController(playerRepo);
            Player player = new Player()
            {
                PlayerName="Andreea",
                PlayerScore=500,
                GameroomId=4
            };
            var actionResult = playerController.PostPlayer(player);
            Assert.IsNotType<BadRequestObjectResult>(actionResult);
        }

        [Fact]
        public void TestUpdatePlayerScoreController()
        {
            PlayerRepository playerRepo = new PlayerRepository(DatabaseDummy.DatabaseDummyCreate("TestUpdatePlayerScoreController"));
            PlayerController playerController = new PlayerController(playerRepo);
            PlayerScore player = new PlayerScore()
            {
                Name="Dana",
                Score=50,
                GameroomId=4
            };
            var actionResult = playerController.UpdatePlayerScore(player);
            Assert.IsNotType<BadRequestObjectResult>(actionResult);
        }

        [Fact]
        public void TestDeletePlayerController()
        {
            PlayerRepository playerRepo = new PlayerRepository(DatabaseDummy.DatabaseDummyCreate("TestDeletePlayerController"));
            PlayerController playerController = new PlayerController(playerRepo);

            var actionResult = playerController.Delete(12);
            Assert.IsNotType<BadRequestObjectResult>(actionResult);
        }
    }
}
