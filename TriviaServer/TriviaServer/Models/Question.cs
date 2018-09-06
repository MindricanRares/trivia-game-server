using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TriviaServer.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public string CorrectAnswer { get; set; }
        public string WrongAnswer1 { get; set; }
        public string WrongAnswer2 { get; set; }
        public string WrongAnswer3 { get; set; }
        public int CategoryId { get; set; }
        public int QuestionDifficulty { get; set; }
        public Category Category { get; set; }
    }
}
