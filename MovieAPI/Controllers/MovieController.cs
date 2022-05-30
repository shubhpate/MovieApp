using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieApp.Business.Services;
using MovieApp.Entity;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        MovieService _movieService;

        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("GetMovies")]
        public IActionResult GetMovies()
        {
            return Ok(_movieService.GetMovies());
        }

        [HttpPost("RegisterMovie")]
        public IActionResult RegisterMovie(MovieModel movieModel)
        {
            return Ok(_movieService.Register(movieModel));
        }

        [HttpDelete("DeleteMovie")]
        public IActionResult DeleteMovie(int id)
        {
            return Ok(_movieService.Delete(id));
        }

        [HttpPut("UpdateMovie")]
        public IActionResult UpdateMovie(MovieModel movieModel)
        {
            return Ok(_movieService.Update(movieModel));
        }
    }
}
