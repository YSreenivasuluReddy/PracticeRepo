using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HttpClientEx2.Models;

namespace HttpClientEx2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserHomeController : ControllerBase
    {
        
        [HttpGet]
        public async Task<IActionResult> GetUserDetailsFromApi()
        {
            //here by using HttpClient i will send the request to another localhost api.
            HttpClient _client = new HttpClient();

            //here i pass the request to that api url,
            //to get the response by using the HttpResponseMessage class.
            HttpResponseMessage response = await _client.GetAsync("https://localhost:7203/api/Users/GetUserDetails");

            var data = await response.Content.ReadAsStringAsync();

            var userdetails = (data, "Application/json");

            return Content(data, "application/json");
        }

        //here i'm going to build the logic to create new user and save it in another api.
        [HttpPost]
        public async Task<IActionResult> AddNewUserDetailsByApi(User user)
        {
            using HttpClient client = new HttpClient();

            var response = await client.PostAsJsonAsync(
                "https://localhost:7203/api/Users/AddUserDetails",
                user);

            var result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, result);
            }

            return Content(result, "application/json");
        }
    }
}
