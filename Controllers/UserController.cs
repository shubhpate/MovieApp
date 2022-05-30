using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MovieApp.Entity;
using Newtonsoft.Json;
using System.Text;

namespace MovieApp.UI.Controllers
{
    public class UserController : Controller
    {
        IConfiguration _iConfiguration;

        public UserController(IConfiguration configuration)
        {
            _iConfiguration = configuration;
        }
        public async Task<IActionResult> ShowUserDetails()
        {
            using(HttpClient client= new HttpClient())
            {
                string endPoint = _iConfiguration["WebApiUrl"] + "User/SelectUsers";
                using(var response= await client.GetAsync(endPoint))
                {
                    if(response.StatusCode== System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var userModel = JsonConvert.DeserializeObject<List<UserModel>>(result);
                        return View(userModel);
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Cant fetch any data";
                    }
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserModel userModel)
        {
            using(HttpClient client= new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(userModel), Encoding.UTF8, "application/json");
                string endpoint = _iConfiguration["WebApiUrl"] + "User/Register";
                using(var response= await client.PostAsync(endpoint,content))
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Registration Successful";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Registration Unsuccessful";
                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> UpdateUser(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _iConfiguration["WebApiUrl"] + "User/GetUserById?id="+id;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var userModel = JsonConvert.DeserializeObject<UserModel>(result);
                        return View(userModel);
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Cant fetch any data";
                    }
                }
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserModel userModel)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(userModel), Encoding.UTF8, "application/json");
                string endpoint = _iConfiguration["WebApiUrl"] + "User/Update";
                using (var response = await client.PutAsync(endpoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Updation Successful";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Registration Unsuccessful";
                    }
                }
            }
            return View();
        }


        public async Task<IActionResult> DeleteUser(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _iConfiguration["WebApiUrl"] + "User/GetUserById?id=" + id;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var userModel = JsonConvert.DeserializeObject<UserModel>(result);
                        return View(userModel);
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Cant fetch any data";
                    }
                }
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> DeleteUser(UserModel userModel)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(userModel), Encoding.UTF8, "application/json");
                string endpoint = _iConfiguration["WebApiUrl"] + "User/Delete?id="+userModel.UserId;
                using (var response = await client.PutAsync(endpoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Deletion Successful";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Registration Unsuccessful";
                    }
                }
            }
            return View();
        }
    }
}
