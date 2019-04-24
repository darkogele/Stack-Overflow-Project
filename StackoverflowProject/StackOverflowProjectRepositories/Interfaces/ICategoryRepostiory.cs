using StackOverFlowProjectDomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflowProjectRepositories.Interfaces
{
    public interface ICategoryRepostiory
    {
        void InsertCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int cid);
        List<Category> Categories();
        List<Category> GetCategoryByCategoryID(int categoryID);

    }
}
