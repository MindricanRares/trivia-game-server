using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TriviaServer;
using TriviaServer.DAO.Repositories;
using TriviaServer.Models;
using Xunit;

namespace XUnitTest
{
    [Collection("Database collection")]
    public class TestPlayer 
    {
        [Fact]
        public void TestCreatePlayer()
        {
            PlayerRepository playerRepo = new PlayerRepository(DatabaseDummy.DatabaseDummyCreate("TestCreatePlayer"));
            Player player = new Player
            {
                PlayerName = "Paul",
                GameroomId = 4,
                PlayerScore = 100
            };

            try
            {
                playerRepo.Create(player);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void TestDeletePlayer()
        {
            PlayerRepository playerRepo = new PlayerRepository(DatabaseDummy.DatabaseDummyCreate("TestDeletePlayer"));

            try
            {
                playerRepo.Delete(10);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void TestGetPlayers()
        {
            PlayerRepository playerRepo = new PlayerRepository(DatabaseDummy.DatabaseDummyCreate("TestGetPlayers"));

            try
            {
                var players = playerRepo.GetPlayers();
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void TestGetByIDPlayer()
        {
            PlayerRepository playerRepo = new PlayerRepository(DatabaseDummy.DatabaseDummyCreate("TestGetByIDPlayer"));

            try
            {
                var player = playerRepo.GetByID(10);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void TestUpdatePlayerScore()
        {
            PlayerRepository playerRepo = new PlayerRepository(DatabaseDummy.DatabaseDummyCreate("TestUpdatePlayerScore"));

            try
            {
                playerRepo.UpdatePlayerScore(4, "Elena", 50);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }
    }
}
