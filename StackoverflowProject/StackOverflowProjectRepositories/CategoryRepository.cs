using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackOverFlowProjectDomainModels;

namespace StackOverflowProjectRepositories
{
    public interface ICategoryRepostiory
    {
        void InsertCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int cid);
        List<Category> Categories();
        List<Category> GetCategoryByCategoryID(int categoryID);

    }

    public class CategoryRepository : ICategoryRepostiory
    {
        private StackOverflowDatabaseDbContext _db;

        public CategoryRepository(StackOverflowDatabaseDbContext db)
        {
            _db = db;
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
