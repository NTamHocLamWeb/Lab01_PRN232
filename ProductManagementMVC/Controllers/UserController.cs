using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
namespace ProductManagementMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "https://localhost:7228/api";

        public UserController()
        {
            _httpClient = new HttpClient();
        }
        [HttpGet]
        public async Task<IActionResult> Search(string userId)
        {
            AccountMember foundUser = null;

            if (!string.IsNullOrWhiteSpace(userId))
            {
                try
                {
                    foundUser = await _httpClient.GetFromJsonAsync<AccountMember>($"{_apiBaseUrl}/accountmembers/{userId}");
                }
                catch (HttpRequestException)
                {
                    // user not found or API error
                }
            }

            ViewBag.CurrentSearch = userId;
            return View(foundUser); // model là User hoặc null
        }
    }
}
