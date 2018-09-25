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
    public class TestQuestionController
    {
        [Fact]
        public void TestGetQuestionsController()
        {
            QuestionRepository questionRepo = new QuestionRepository(DatabaseDummy.DatabaseDummyCreate("TestGetQuestionsController"));
            QuestionController questionController = new QuestionController(questionRepo);
            
            var actionResult = questionController.GetQuestions();
            Assert.IsNotType<BadRequestObjectResult>(actionResult);
        }

        [Fact]
        public void TestGetQuestionByIdController()
        {
            QuestionRepository questionRepo = new QuestionRepository(DatabaseDummy.DatabaseDummyCreate("TestGetQuestionByIdController"));
            QuestionController questionController = new QuestionController(questionRepo);

            var actionResult = questionController.GetById(10);
            Assert.IsNotType<BadRequestObjectResult>(actionResult.Result);
        }

        [Fact]
        public void TestPostQuestion()
        {
            QuestionRepository questionRepo = new QuestionRepository(DatabaseDummy.DatabaseDummyCreate("TestPostQuestion"));
            QuestionController questionController = new QuestionController(questionRepo);
            Question question = new Question()
            {
                QuestionText="Cine esti?",
                CorrectAnswer="Persoana",
                WrongAnswer1=",jscbvghszd",
                WrongAnswer2="sdjkdcudhsf",
                WrongAnswer3="Mama",
                QuestionDifficulty=5
            };
            var actionResult = questionController.PostQuestion(question);
            Assert.IsNotType<BadRequestObjectResult>(actionResult);
        }

        [Fact]
        public void TestDeleteQuestionController()
        {
            QuestionRepository questionRepo = new QuestionRepository(DatabaseDummy.DatabaseDummyCreate("TestDeleteQuestionController"));
            QuestionController questionController = new QuestionController(questionRepo);

            var actionResult = questionController.Delete(11);
            Assert.IsNotType<BadRequestObjectResult>(actionResult);
        }
    }
}
