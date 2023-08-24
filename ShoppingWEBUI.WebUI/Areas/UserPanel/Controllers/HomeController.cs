using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using ShoppingWEBUI.Core.DTO.Category;
using ShoppingWEBUI.Core.DTO.Product;
using ShoppingWEBUI.Core.Model;
using ShoppingWEBUI.Core.Result;
using ShoppingWEBUI.Helper.SessionHelper;

namespace ShoppingWEBUI.WebUI.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    public class HomeController : Controller
    {
        [HttpGet("/User/Anasayfa")]
        public  async Task<IActionResult> Index()
        {
            var url = "http://localhost:5249/Products";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + SessionManager.Token);
            RestResponse response = await client.ExecuteAsync(request);
            var responseObject = JsonConvert.DeserializeObject<ApiResult<List<ProductDTO>>>(response.Content);
            var productList = responseObject.Data;


            return View(productList);



        }


    }
}
