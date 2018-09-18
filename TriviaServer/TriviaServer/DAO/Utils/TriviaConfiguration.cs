using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TriviaServer.DAO.Utils
{
    public sealed class TriviaConfiguration
    {
        private static TriviaConfiguration instance = null;
        private static IConfigurationRoot myConfiguration;

        private TriviaConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder()
               .AddJsonFile("C:/Git/trivia-game-server/TriviaServer/TriviaServer/appsettings.json")
               .AddEnvironmentVariables();
            myConfiguration = configurationBuilder.Build();
        }

        public static TriviaConfiguration Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TriviaConfiguration();
                }
                return instance;
            }
        }

        public String GetPassword()
        {

            return myConfiguration["Password:Pass"].ToString();
        }

        public int GetNumberOfCategories()
        {
            return Int32.Parse(myConfiguration["NoOfCategories:TotalNumber"]);
        }

        public int GetNumberOfQuestions(int index)
        {
            return Int32.Parse(myConfiguration[String.Format("NoOfCategories:C{0}", index)]);
        }
    }
}
