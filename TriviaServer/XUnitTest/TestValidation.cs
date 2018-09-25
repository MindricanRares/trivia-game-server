using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TriviaServer;
using TriviaServer.DAO.Utils;
using TriviaServer.Models;
using Xunit;

namespace XUnitTest
{
    [Collection("Database collection")]
    public class TestValidation 
    {
        [Fact]
        public void TestCreatePlayerValidation()
        {
            ApplicationContext _context = DatabaseDummy.DatabaseDummyCreate("TestCreatePlayerValidation");
            Player player = new Player();
            player.PlayerName = "Paul";
            player.PlayerScore = 5000;
            player.GameroomId = 4;
            var players = _context.Players.Where(a => a.GameroomId == player.GameroomId).ToList();

            bool createPlayerValidationResult = Validation.CreatePlayerValidation(players, player);

            Assert.True(createPlayerValidationResult);
        }

        [Fact]
        public void TestUpdateScoreValidation()
        {
            ApplicationContext _context = DatabaseDummy.DatabaseDummyCreate("TestUpdateScoreValidation");
            var player = _context.Players.Where(a => a.PlayerName == "Elena").FirstOrDefault();
            var players = _context.Players.Where(a => a.GameroomId == player.GameroomId).ToList();

            bool updateScoreValidationResult = Validation.UpdateScoreValidation(players, player.PlayerName);

            Assert.True(updateScoreValidationResult);
        }
    }
}
