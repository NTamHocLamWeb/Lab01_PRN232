using BusinessObjects;
using Repositories;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services
{
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository iCategoryRepository;

		public CategoryService()
		{
			iCategoryRepository = new CategoryRepository();
		}

		public List<Category> GetCategories()
		{
			return iCategoryRepository.GetCategories();
		}
	}
}
