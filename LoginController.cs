using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using PowerBI.Models;
using PowerBI.Web.Models;
namespace PowerBI.Web.Controllers
{
    public class LoginController : Controller
    {
        HttpClient client = new HttpClient();
        private readonly IConfiguration _config;
        public LoginController(IConfiguration config)
        {
            _config = config; 
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel login)
        {
                if (ModelState.IsValid)
                {
                    string BaseAddress= _config.GetValue<string>("BaseUrl:BaseAddress");
                    client.DefaultRequestHeaders.Add("Authorization", "Basic " + "YWRpZGFhczpEaXN5c0AzMjE=");
                    HttpResponseMessage response = client.GetAsync(BaseAddress + "?UserName=" + login.Username + "&Password=" + login.Password).Result;
                    var results = response.Content.ReadAsStringAsync().Result;
                    JObject jsons = JObject.Parse(results);
                    string username = jsons["user_Name"].ToString();
                    if (username != "" & response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("index", "Dashboard");
                    }
                else
                { 
                ModelState.AddModelError("Invalid Error", "Invalid username and password");
                  
                }
            }

            return View();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }

}
