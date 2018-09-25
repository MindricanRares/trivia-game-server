using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TriviaServer;
using TriviaServer.Models;
using Xunit;

public static class DatabaseDummy
{
    public static ApplicationContext DatabaseDummyCreate(string testName)
    {
        var options = new DbContextOptionsBuilder<ApplicationContext>()
                           .UseInMemoryDatabase(databaseName: testName)
                           .Options;

        var context = new ApplicationContext(options);

        context.Players.Add(new Player { PlayerId = 10, PlayerName = "Elena", GameroomId = 4, PlayerScore = 350 });
        context.Players.Add(new Player { PlayerId = 11, PlayerName = "Dana", GameroomId = 4, PlayerScore = 650 });
        context.Players.Add(new Player { PlayerId = 12, PlayerName = "Iulia", GameroomId = 4, PlayerScore = 420 });
        context.Players.Add(new Player { PlayerId = 13, PlayerName = "Madalin", GameroomId = 4, PlayerScore = 100 });
        context.Players.Add(new Player { PlayerId = 14, PlayerName = "Radu", GameroomId = 5, PlayerScore = 100 });

        context.Categories.Add(new Category { CategoryId = 34, CategoryName = "Math", NumberOfUses = 3 });
        context.Categories.Add(new Category { CategoryId = 35, CategoryName = "IT", NumberOfUses = 3 });
        context.Categories.Add(new Category { CategoryId = 36, CategoryName = "Geography", NumberOfUses = 5 });

        context.Games.Add(new Game { GameId = 4, UniqueKey = 1 });
        context.Games.Add(new Game { GameId = 5, UniqueKey = 2 });

        context.Questions.Add(new Question { QuestionId = 10, QuestionText = "Intrebare1", CorrectAnswer = "49", WrongAnswer1 = "1", WrongAnswer2 = "2", WrongAnswer3 = "3", CategoryId = 34, QuestionDifficulty = 1 });
        context.Questions.Add(new Question { QuestionId = 11, QuestionText = "Intrebare2", CorrectAnswer = "49", WrongAnswer1 = "1", WrongAnswer2 = "2", WrongAnswer3 = "3", CategoryId = 34, QuestionDifficulty = 1 });

        context.CategoryGames.Add(new CategoryGame { GameId = 4, CategoryId = 35 });
        context.CategoryGames.Add(new CategoryGame { GameId = 4, CategoryId = 36 });

        context.SaveChanges();

        return context;
    }
}