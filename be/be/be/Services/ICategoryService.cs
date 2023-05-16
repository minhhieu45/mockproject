using be.Models;
using Microsoft.AspNetCore.Mvc;

namespace be.Services
{
    public interface ICategoryService : IDisposable
    {
        Category GetCategory(int categoryId);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int categoryId);
        //IList<Category> GetAllCategories();
        IEnumerable<Category> GetAllCategories();
        IEnumerable<Category> GetAllCategories(int id);
    }
}
