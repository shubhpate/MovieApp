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
    public class TheatreController : ControllerBase
    {
        TheatreService _theatreService;

        public TheatreController(TheatreService theatreService)
        {
            _theatreService = theatreService;
        }

        [HttpGet("SelectTheatres")]
        public IActionResult SelectTheatres()
        {
            return Ok(_theatreService.SelectTheatres());

        }

        [HttpPost("RegisterTheatre")]
        public IActionResult Register(TheatreModel theatreModel)
        {
            return Ok(_theatreService.Register(theatreModel));
        }

        [HttpDelete("DeleteTheatre")]
        public IActionResult Delete(int id)
        {
            return Ok(_theatreService.DeleteTheatre(id));
        }

        [HttpPut("UpdateTheatre")]
        public IActionResult Update(TheatreModel theatreModel)
        {
            return Ok(_theatreService.UpdateTheatre(theatreModel));
        }

        [HttpGet("GetTheatreById")]
        public IActionResult GetTheatreById(int id)
        {
            return Ok(_theatreService.GetById(id));
        }
    }
}
