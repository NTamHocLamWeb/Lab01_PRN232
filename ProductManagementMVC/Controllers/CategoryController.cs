using BusinessObjects;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagementMVC.Controllers
{
	public class CategoryController : Controller
	{
		private readonly HttpClient _httpClient;
		private const string _baseUrl = "https://localhost:7228/api";

		public CategoryController()
		{
            _httpClient = new HttpClient();
        }
		public async Task<IActionResult> Index()
		{
			var categories = await _httpClient.GetFromJsonAsync<List<Category>>($"{_baseUrl}/categories");
			return View(categories);
		}
	}
}
