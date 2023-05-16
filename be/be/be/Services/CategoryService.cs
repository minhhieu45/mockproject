using be.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace be.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly DbFourSeasonHotelContext _context;

        public CategoryService()
        {
            _context = new DbFourSeasonHotelContext();
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            var item = _context.Categories.Find(categoryId);
            _context.Categories.Remove(item);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        //public IList<Category> GetAllCategories()
        //{
        //    return _context.Categories.ToList();
        //}

        public IEnumerable<Category> GetAllCategories()
        {
            if (_context.Categories == null)
            {
                return null;
            }
            return _context.Categories.ToList();
        }

        public IEnumerable<Category> GetAllCategories(int id)
        {
            var result = _context.Categories.Where(x=>x.CategoryId == id).FirstOrDefault();

            if (result == null)
            {
                return null;
            }
            return (IEnumerable<Category>)result;
        }

        public Category GetCategory(int categoryId)
        {
            return _context.Categories.Find(categoryId);
        }

        public void UpdateCategory(Category category)
        {
            Category updateCategory = _context.Categories.Find(category.CategoryId);
            updateCategory = category;
            _context.SaveChanges();
        }
    }
}
