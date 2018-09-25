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
    public class TestQuestion
    {
        [Fact]
        public void TestCreateQuestion()
        {
            QuestionRepository questionRepo = new QuestionRepository(DatabaseDummy.DatabaseDummyCreate("TestCreateQuestion"));
            Question question = new Question
            {
                QuestionText = "Intrebare3",
                CorrectAnswer = "49",
                WrongAnswer1 = "1",
                WrongAnswer2 = "2",
                WrongAnswer3 = "3",
                CategoryId = 34,
                QuestionDifficulty = 1
            };

            try
            {
                questionRepo.Create(question);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void TestDeleteQuestion()
        {
            QuestionRepository questionRepo = new QuestionRepository(DatabaseDummy.DatabaseDummyCreate("TestDeleteQuestion"));

            try
            {
                questionRepo.Delete(10);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void TestGetQuestions()
        {
            QuestionRepository questionRepo = new QuestionRepository(DatabaseDummy.DatabaseDummyCreate("TestGetQuestions"));

            try
            {
                var questions = questionRepo.GetQuestions();
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void TestGetQuestionByID()
        {
            QuestionRepository questionRepo = new QuestionRepository(DatabaseDummy.DatabaseDummyCreate("TestGetQuestionByID"));

            try
            {
                var question = questionRepo.GetByID(10);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }
    }
}
