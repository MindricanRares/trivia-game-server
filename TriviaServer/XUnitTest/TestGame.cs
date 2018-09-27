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
    public class TestGame 
    {
        [Fact]
        public void TestCreateGame()
        {
            GameRepository gameRepo = new GameRepository(DatabaseDummy.DatabaseDummyCreate("TestCreateGame"));
            Game game = new Game();
            game.UniqueKey = 3;

            try
            {
                gameRepo.Create(game);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void TestDeleteGame()
        {
            GameRepository gameRepo = new GameRepository(DatabaseDummy.DatabaseDummyCreate("TestDeleteGame"));

            try
            {
                gameRepo.Delete(4);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void TestGetGames()
        {
            GameRepository gameRepo = new GameRepository(DatabaseDummy.DatabaseDummyCreate("TestGetGames"));

            try
            {
                var games = gameRepo.GetGames();
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void TestGetByIDGame()
        {
            GameRepository gameRepo = new GameRepository(DatabaseDummy.DatabaseDummyCreate("TestGetByIDGame"));

            try
            {
                var game = gameRepo.GetByID(4);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void TestGetPlayerAndScoreByUniqueKey()
        {
            GameRepository gameRepo = new GameRepository(DatabaseDummy.DatabaseDummyCreate("TestGetPlayerAndScoreByGameRoomId"));

            try
            {
                var playersAndScore = gameRepo.GetPlayerAndScoreByUniqueKey(1);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void TestGetPlayersByUniqueKey()
        {
            GameRepository gameRepo = new GameRepository(DatabaseDummy.DatabaseDummyCreate("TestGetPlayersByRoomId"));

            try
            {
                var players = gameRepo.GetPlayersByUniqueKey(1);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void TestGetAverageScore()
        {
            GameRepository gameRepo = new GameRepository(DatabaseDummy.DatabaseDummyCreate("TestGetAverageScore"));

            try
            {
                var averageScore = gameRepo.GetAverageScore(1);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }
        [Fact]
        public void TestGetQuestionsAndAnswersByUniqueKey()
        {
            GameRepository gameRepo = new GameRepository(DatabaseDummy.DatabaseDummyCreate("TestGetQuestionsAndAnswersByGameRoomId"));

            try
            {
                var questions = gameRepo.GetQuestionsAndAnswersByUniqueKey(1);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }
    }
}
