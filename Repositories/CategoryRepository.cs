using BusinessObjects;
using DataAccessObjects;
using Repositories.Interfaces;

namespace Repositories
{
	public class CategoryRepository : ICategoryRepository
	{
		public List<Category> GetCategories() => CategoryDAO .GetCategories();
	}
}
