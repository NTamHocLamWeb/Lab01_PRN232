using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductManagementMVC.Models;

namespace ProductManagementMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient _httpClient;
        private const string _baseUrl = "https://localhost:7228/api";
        public ProductController()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IActionResult> Index()
        {
            var products = await _httpClient.GetFromJsonAsync<List<Product>>($"{_baseUrl}/products");
            return View(products);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _httpClient.GetFromJsonAsync<Product>($"{_baseUrl}/products/{id}");
            return View(product);
        }
        private async Task SetCategoryViewBagAsync()
        {
            var categories = await _httpClient.GetFromJsonAsync<List<Category>>($"{_baseUrl}/categories");
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await SetCategoryViewBagAsync();
            return View("Upsert", new Product());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                await SetCategoryViewBagAsync();
                return View("Upsert", product);
            }

            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/products", product);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            ModelState.AddModelError("", "Failed to create product.");
            await SetCategoryViewBagAsync();
            return View("Upsert", product);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _httpClient.GetFromJsonAsync<Product>($"{_baseUrl}/products/{id}");
            if (product == null) return NotFound();

            await SetCategoryViewBagAsync();
            return View("Upsert", product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                await SetCategoryViewBagAsync();
                return View("Upsert", product);
            }

            var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/products/{product.ProductId}", product);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            ModelState.AddModelError("", "Failed to update product.");
            await SetCategoryViewBagAsync();
            return View("Upsert", product);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _httpClient.GetFromJsonAsync<Product>($"{_baseUrl}/products/{id}");
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/products/{id}");
            return RedirectToAction(nameof(Index));
        }

    }
}
