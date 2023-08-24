using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using ShoppingWEBUI.Core.DTO.Category;
using ShoppingWEBUI.Core.DTO.User;
using ShoppingWEBUI.Core.Result;
using ShoppingWEBUI.Helper.SessionHelper;
using System.Net;

namespace ShoppingWEBUI.WebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class UserController : Controller
    {
        [HttpGet("/Admin/Kullanicilar")]
        public async Task<IActionResult> Index()
        {
            var url = "http://localhost:5249/Users";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + SessionManager.Token);
            RestResponse response = await client.ExecuteAsync(request);
            var responseObject = JsonConvert.DeserializeObject<ApiResult<List<UserDTO>>>(response.Content);
            var userList = responseObject.Data;
            return View(userList.ToList());
        }

        //[HttpPost("/Admin/AddUser")]
        //public async Task<IActionResult> AddUser(UserDTO userDTO)
        //{
        //    var url = "http://localhost:5249/AddUser/";
        //    var client = new RestClient(url);
        //    var request = new RestRequest(url, Method.Post);
        //    request.AddHeader("Content-Type", "application/json");
        //    request.AddHeader("Authorization", "Bearer " + SessionManager.Token);
        //    var body = JsonConvert.SerializeObject(userDTO);
        //    request.AddBody(body, "application/json");
        //    RestResponse response = await client.ExecuteAsync(request);
        //    var responseObject = JsonConvert.DeserializeObject<ApiResult<bool>>(response.Content);

        //    if (response.StatusCode == HttpStatusCode.OK)
        //    {
        //        return Json(new { success = true, message = responseObject.Mesaj, data = responseObject.Data });
        //    }
        //    else if (response.StatusCode == HttpStatusCode.BadRequest)
        //    {
        //        return Json(new { success = false, message = responseObject.Mesaj, data = responseObject.HataBilgisi });
        //    }

        //    else
        //    {
        //        return Json(new { success = false, message = "Hata Oluştu" });
        //    }
        //}

       
    }
}
