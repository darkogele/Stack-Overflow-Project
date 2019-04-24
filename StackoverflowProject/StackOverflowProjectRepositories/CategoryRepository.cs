using System.Collections.Generic;
using System.Linq;
using StackOverFlowProjectDomainModels;
using StackOverflowProjectRepositories.Interfaces;

namespace StackOverflowProjectRepositories
{
    public class CategoryRepository : ICategoryRepostiory
    {
        private StackOverflowDatabaseDbContext _db;

        public CategoryRepository()
        {
            _db = new StackOverflowDatabaseDbContext();
        }

        public List<Category> Categories()
        {
            var allcategories = _db.Categories.ToList();
            return allcategories;
        }

        public void DeleteCategory(int cid)
        {
            var category = _db.Categories.Where(c => c.CategoryID == cid).FirstOrDefault();
            if (category != null)
            {
                _db.Categories.Remove(category);
                _db.SaveChanges();
            }
        }

        public List<Category> GetCategoryByCategoryID(int categoryID)
        {
            var category = _db.Categories.Where(c => c.CategoryID == categoryID).ToList();
            return category;
        }

        public void InsertCategory(Category category)
        {
            if (category != null)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
            }
        }

        public void UpdateCategory(Category category)
        {
            var updateCategory = _db.Categories.Where(c => c.CategoryID == category.CategoryID).FirstOrDefault();
            if (updateCategory != null)
            {
                updateCategory.CategoryName = category.CategoryName;
                _db.SaveChanges();
            }
        }
    }
}
