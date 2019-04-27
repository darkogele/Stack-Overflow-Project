using StackOverflowProjectServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using StackOverflowProjectRepositories;
using StackOverflowProjectViewModels;
using StackOverFlowProjectDomainModels;
using AutoMapper;

namespace StackOverflowProjectServiceLayer
{
    public class CategoriesService : ICategoriesService
    {
        private CategoryRepository _cr;
        public CategoriesService(CategoryRepository cr)
        {
            _cr = cr;
        }

        public void DeleteCategory(int cid)
        {
            _cr.DeleteCategory(cid);
        }

        public List<CategoryViewModel> GetCategories()
        {
            var cl = _cr.Categories();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<List<Category>, List<CategoryViewModel>>(); cfg.IgnoreUnmapped(); });
            var mapper = config.CreateMapper();
            var cvm = mapper.Map<List<Category>, List<CategoryViewModel>>(cl);
            return cvm;
        }

        public CategoryViewModel GetCategoryByCategoryID(int cid)
        {
            var c = _cr.GetCategoryByCategoryID(cid).FirstOrDefault();
            CategoryViewModel cvm = null;
            if (c != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Category, CategoryViewModel>(); cfg.IgnoreUnmapped(); });
                var mapper = config.CreateMapper();
                cvm = mapper.Map<Category, CategoryViewModel>(c);
            }         
            return cvm;
        }

        public void InsertCategory(CategoryViewModel cvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<CategoryViewModel, Category>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Category c = mapper.Map<CategoryViewModel, Category>(cvm);
            _cr.InsertCategory(c);
        }

        public void UpdateCategory(CategoryViewModel cvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<CategoryViewModel, Category>(); cfg.IgnoreUnmapped(); });
            var mapper = config.CreateMapper();
            var uc = mapper.Map<CategoryViewModel, Category>(cvm);
            _cr.UpdateCategory(uc);
        }
    }
}
