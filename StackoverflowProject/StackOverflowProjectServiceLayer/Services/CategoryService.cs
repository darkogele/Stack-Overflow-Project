using StackOverflowProjectRepositories.Interfaces;

namespace StackOverflowProjectServiceLayer.Services
{
    public class CategoryService
    {
        public UoW.UoW _uow { get; set; }
        private ICategoryRepostiory CatRepo { get; set; }

        public CategoryService(ICategoryRepostiory categoryRepository)
        {
            _uow = new UoW.UoW();
            CatRepo = categoryRepository;
        }
    }
}
