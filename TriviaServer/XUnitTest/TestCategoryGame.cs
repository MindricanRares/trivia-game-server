using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TriviaServer;
using TriviaServer.DAO.Repositories;
using TriviaServer.DAO.Utils;
using TriviaServer.Models;
using Xunit;

namespace XUnitTest
{
    [Collection("Database collection")]
    public class TestCategoryGame
    {
        [Fact]
        public void TestCreateCategoryGame()
        {
            CategoryGameRepository categoryGameRepo = new CategoryGameRepository(DatabaseDummy.DatabaseDummyCreate("TestCreateCategoryGame"));
            GameCategories gameCategories = new GameCategories
            {
                GameId = 4,
                CategoriesId = new List<int>() { 34,35}
            };

            try
            {
                categoryGameRepo.Create(gameCategories);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }
    }
}
