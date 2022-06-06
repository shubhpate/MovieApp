using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using MovieApp.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.UI.Controllers
{
    public class MovieShowtimeController : Controller
    {
        IConfiguration _configuration;
        public MovieShowtimeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> ShowMovieTime()
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "MovieShowtime/GetAllMovieShowtimes";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var movieShowTimes = JsonConvert.DeserializeObject<List<MovieShowtimeModel>>(result);
                        return View(movieShowTimes);
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "No Data Found!";
                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> InsertMovieShowTimes()
        {

            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "Movie/GetMovies";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var movieModel = JsonConvert.DeserializeObject<List<MovieModel>>(result);
                        List<SelectListItem> selectListItemsMovies = new List<SelectListItem>();
                        foreach (var item in movieModel)
                        {
                            SelectListItem selectListItem = new SelectListItem();
                            selectListItem.Text = item.Name;
                            selectListItem.Value = item.Id.ToString();
                            selectListItemsMovies.Add(selectListItem);
                            ViewBag.movieData = selectListItemsMovies;
                        }
                    }
                }
            }
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "Theatre/SelectTheatres";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var theatreModel = JsonConvert.DeserializeObject<List<TheatreModel>>(result);
                        List<SelectListItem> selectListItemsTheatre = new List<SelectListItem>();
                        foreach (var item in theatreModel)
                        {
                            SelectListItem selectListItem = new SelectListItem();
                            selectListItem.Text = item.TheatreName;
                            selectListItem.Value = item.TheatreId.ToString();
                            selectListItemsTheatre.Add(selectListItem);
                            ViewBag.theatreData = selectListItemsTheatre;
                        }
                    }
                }
            }

            return View();
        }

        [HttpPost]

        // [ValidateAntiForgeryToken] [Bind("ShowId,MovieId,TheatreId,ShowTime,Date")]
        public async Task<IActionResult> RegisterMovieShowTimes(MovieShowtimeModel movieShowTimeModel)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(movieShowTimeModel), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiURL"] + "MovieShowtime/RegisterMovieShowtime";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Inserted!";
                        //return RedirectToAction("ShowMovieTime", "MovieShowtime");
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries!";
                    }
                }
            }

            return View();
        }

        public async Task<IActionResult> UpdateMovieshowTimes(int ShowId)
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "MovieShowtime/GetMovieShowtimeById?id=" + ShowId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var movieShowTimes = JsonConvert.DeserializeObject<MovieShowtimeModel>(result);
                        return View(movieShowTimes);
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "No Data Found!";
                    }
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMovieshowTimes(MovieShowtimeModel movieShowTimeModel)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(movieShowTimeModel), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiURL"] + "MovieShowtime/UpdateMovieShowtimeById";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "MovieShowTime-Updated-Successfuly!!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong-Entries!!";
                    }
                }
            }
            return View();
        }
        public async Task<IActionResult> DeleteMovieshowTimes(int ShowId)
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "MovieShowtime/GetMovieShowtimeById?id=" + ShowId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var movieShowtimes = JsonConvert.DeserializeObject<MovieShowtimeModel>(result);
                        return View(movieShowtimes);
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "No Data Found!";
                    }
                }
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteMovieshowTimes(MovieShowtimeModel movieShowtimeModel)
        {
            using (HttpClient client = new HttpClient())
            {

                string endPoint = _configuration["WebApiURL"] + "MovieShowtime/DeleteMovieShowtimeById?id=" + movieShowtimeModel.ShowId;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "MovieShowTime-Deleted-Successfuly!!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong-Entries!!";
                    }
                }
            }
            return View();
        }
    }
}
