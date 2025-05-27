using BusinessObjects;

namespace Repositories.Interfaces
{
	public interface ICategoryRepository
	{
		List<Category> GetCategories();
	}
}
