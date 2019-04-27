using StackOverflowProjectViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflowProjectServiceLayer.Interfaces
{
    public interface ICategoriesService
    {
        void InsertCategory(CategoryViewModel cvm);
        void UpdateCategory(CategoryViewModel cvm);
        void DeleteCategory(int cid);
        List<CategoryViewModel> GetCategories();
        CategoryViewModel GetCategoryByCategoryID(int cid);
    }
}
