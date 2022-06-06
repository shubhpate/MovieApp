using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Entity;

namespace MovieApp.Data.Repositories
{
    public interface IMovieShowtime
    {
        public string Register(MovieShowtimeModel movieShowTimeModel);
        public List<MovieShowtimeModel> GetAllMovieShowtime();
        string DeleteMovieShowtime(int id);
        string UpdateMovieShowtime(MovieShowtimeModel movieShowTimeModel);
        MovieShowtimeModel GetMovieShowimeById(int id);
        List<MovieShowtimeModel> GetShowtimeForSpecificMovieAndTheatre(int movieId);
    }
}
