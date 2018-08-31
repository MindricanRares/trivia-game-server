using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriviaServer.Models;

namespace TriviaServer.DAO.Interfaces
{
    public interface ICategoryRepository
    {
        void Create(Category c);
        void Edit(Category c);
        void Delete(int id);
        IEnumerable<Category> GetCategories();
        Category GetByID(int? id);
    }
}
