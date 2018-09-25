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
    public class TestCategory 
    {

        [Fact]
        public void TestCreateCategory()
        {
            var categoryRepo = new CategoryRepository(DatabaseDummy.DatabaseDummyCreate("TestCreateCategory"));
            Category category = new Category();
            category.CategoryName = "History";
            category.NumberOfUses = 0;

            try
            {
                categoryRepo.Create(category);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void TestDeleteCategory()
        {
            CategoryRepository categoryRepo = new CategoryRepository(DatabaseDummy.DatabaseDummyCreate("TestDeleteCategory"));

            try
            {
                categoryRepo.Delete(34);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void TestGetCategories()
        {
            CategoryRepository categoryRepo = new CategoryRepository(DatabaseDummy.DatabaseDummyCreate("TestGetCategories"));

            try
            {
                var categories = categoryRepo.GetCategories();
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void TestGetByIDCategory()
        {
            CategoryRepository categoryRepo = new CategoryRepository(DatabaseDummy.DatabaseDummyCreate("TestGetByIDCategory"));

            try
            {
                var category = categoryRepo.GetByID(35);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }
    }
}
