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
    public class TestCategoryGame
    {
        [Fact]
        public void TestCreateCategoryGame()
        {
            CategoryGameRepository cgr = new CategoryGameRepository(DatabaseDummy.DatabaseDummyCreate("TestCreateCategoryGame"));
            CategoryGame cg = new CategoryGame();
            cg.GameId = 4;
            cg.CategoryId = 34;

            try
            {
                cgr.Create(cg);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }
    }
}
