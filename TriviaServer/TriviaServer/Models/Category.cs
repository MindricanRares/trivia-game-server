using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TriviaServer.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int NumberOfUses { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<CategoryGame> CategoryGames { get; set; }

        public Category()
        {
            Questions = new List<Question>();
        }

        public override string ToString()
        {
            return "Category: " + CategoryId + " " + CategoryName + "  " + NumberOfUses;
        }

    }
}
