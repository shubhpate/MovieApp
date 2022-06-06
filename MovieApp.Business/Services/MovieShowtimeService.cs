using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Data.Repositories;
using MovieApp.Entity;

namespace MovieApp.Business.Services
{
    public class MovieShowtimeService
    {
        IMovieShowtime _movieShowtime;

        public MovieShowtimeService(IMovieShowtime movieShowtime)
        {
            _movieShowtime = movieShowtime;
        }

        public string RegisterMovieShowtime(MovieShowtimeModel movieShowtimeModel)
        {
            return _movieShowtime.Register(movieShowtimeModel);
        }

        public List<MovieShowtimeModel> GetAllMovieShowtimes()
        {
            return _movieShowtime.GetAllMovieShowtime();
        }

        public string DeleteMovieShowtime(int id)
        {
            return _movieShowtime.DeleteMovieShowtime(id);
        }

        public MovieShowtimeModel GetMovieShowimeById(int id)
        {
            return _movieShowtime.GetMovieShowimeById(id);
        }

        public List<MovieShowtimeModel> GetShowtimeForSpecificMovieAndTheatre(int movieId)
        {
            return _movieShowtime.GetShowtimeForSpecificMovieAndTheatre(movieId);
        }

        public string UpdateMovieShowtime(MovieShowtimeModel movieShowTimeModel)
        {
            return _movieShowtime.UpdateMovieShowtime(movieShowTimeModel);
        }
    }
}
