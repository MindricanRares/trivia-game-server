using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriviaServer.Models;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;

namespace TriviaServer.PopulateSQL
{
    public class JSONConverter
    {
        public static List<Category> ReadJsonFile()
        {
            //var config = new ConfigurationBuilder()
            //        .SetBasePath(Directory.GetCurrentDirectory())
            //        .AddIniFile("appsettings.json", optional: true, reloadOnChange: true)
            //        .Build();

            //var asda = config.GetValue<string>("NrofCategories.TotalNumber");


            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("C:/Git/trivia-game-server/TriviaServer/TriviaServer/appsettings.json").
                AddEnvironmentVariables();

            var myConfiguration = configurationBuilder.Build();


            int numberOfCategories = Int32.Parse( myConfiguration["NoOfCategories:TotalNumber"]);

            List<int> categoriesNr = new List<int>();
            for(int i = 0;i< numberOfCategories;i++)
                categoriesNr.Add(Int32.Parse(myConfiguration[String.Format("NoOfCategories:C{0}",i+1)]));


            List<Category> categoryList = new List<Category>();

            string filepath = "Resources/modeldata.json";
            using (StreamReader r = new StreamReader(filepath))
            {
                
                var json = r.ReadToEnd();
                JObject jarray = JObject.Parse(json);

              
                for (int i = 0; i < numberOfCategories; i++)
                {
                    Category newCategory = new Category();
                    newCategory.CategoryName = jarray.SelectToken(string.Format("categoryList[{0}].categoryName", i)).ToString();
                    newCategory.NumberOfUses = 0;

                    for (int j = 0; j < categoriesNr[i]; j++)
                    {
                        Question newquestion = new Question();
                        newquestion.QuestionText = jarray.SelectToken(string.Format("categoryList[{0}].questionList[{1}].questionText", i, j)).ToString();
                        newquestion.CorrectAnswer = jarray.SelectToken(string.Format("categoryList[{0}].questionList[{1}].correctAnswer", i, j)).ToString();
                        newquestion.WrongAnswer1 = jarray.SelectToken(string.Format("categoryList[{0}].questionList[{1}].wrongAnswer1", i, j)).ToString();
                        newquestion.WrongAnswer2 = jarray.SelectToken(string.Format("categoryList[{0}].questionList[{1}].wrongAnswer2", i, j)).ToString();
                        newquestion.WrongAnswer3 = jarray.SelectToken(string.Format("categoryList[{0}].questionList[{1}].wrongAnswer3", i, j)).ToString();
                        newquestion.QuestionDifficulty = Int32.Parse(jarray.SelectToken(string.Format("categoryList[{0}].questionList[{1}].questionDifficulty", i, j)).ToString());
                        newCategory.Questions.Add(newquestion);
                    }
                    categoryList.Add(newCategory);
                }
            }
            return categoryList;
        }
    }
}

